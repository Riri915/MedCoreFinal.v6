using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using BCrypt.Net;

namespace MedCoreC_
{
    internal static class DatabaseInitializer
    {
        private static readonly string ConnString =
            "server=localhost;user id=root;password=;Allow User Variables=True;";

        public static bool DatabaseSuccess { get; private set; }

        public static void InitializeTABLE()
        {
            try
            {
                using (var conn = new MySqlConnection(ConnString))
                {
                    conn.Open();
                    new MySqlCommand(
                        "CREATE DATABASE IF NOT EXISTS medcore;",
                        conn
                    ).ExecuteNonQuery();
                }

                string dbConnString = ConnString + "database=medcore;";
                using (var dbConn = new MySqlConnection(dbConnString))
                {
                    dbConn.Open();

                    string createUsersTable = @"
                        CREATE TABLE IF NOT EXISTS users (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            employee_id VARCHAR(20),
                            first_name VARCHAR(50),
                            last_name VARCHAR(50),
                            username VARCHAR(50) NOT NULL UNIQUE,
                            password_hash VARCHAR(255) NOT NULL,
                            account_type VARCHAR(50) NOT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );
                    ";
                    new MySqlCommand(createUsersTable, dbConn).ExecuteNonQuery();

                    string createProductsTable = @"
                        CREATE TABLE IF NOT EXISTS products (
                            ProductID CHAR(4) NOT NULL,
                            Barcode VARCHAR(50) NOT NULL UNIQUE,
                            ProductName VARCHAR(100) NOT NULL,
                            ExpirationDate DATE,
                            UnitPrice DECIMAL(10,2) NOT NULL,
                            UnitInStock INT NOT NULL DEFAULT 0,
                            PRIMARY KEY (ProductID)
                        );
                    ";
                    new MySqlCommand(createProductsTable, dbConn).ExecuteNonQuery();

                    string createActivityLogsTable = @"
                        CREATE TABLE IF NOT EXISTS activity_logs (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            employee_id VARCHAR(20),
                            username VARCHAR(50),
                            action VARCHAR(255),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );
                    ";
                    new MySqlCommand(createActivityLogsTable, dbConn).ExecuteNonQuery();

                    InsertDefaultUser(dbConn, "EMP001", "System", "Admin", "admin", "admin123", "Admin");
                    InsertDefaultUser(dbConn, "EMP002", "Default", "Cashier", "cashier", "cashier123", "Cashier");
                    InsertDefaultUser(dbConn, "EMP003", "Default", "Doctor", "doctor", "doctor123", "Doctor");
                    InsertDefaultUser(dbConn, "EMP004", "Self", "Service", "kiosk", "kiosk123", "Kiosk");

                    InsertDefaultProducts(dbConn);

                    LogActivity(dbConn, "EMP001", "admin", "System initialized");
                }

                DatabaseSuccess = true;
            }
            catch (Exception ex)
            {
                DatabaseSuccess = false;
                MessageBox.Show(
                    "Database initialization failed:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static void InsertDefaultProducts(MySqlConnection conn)
        {
            string query = @"
                INSERT INTO products
                (ProductID, Barcode, ProductName, ExpirationDate, UnitPrice, UnitInStock)
                SELECT @pid, @barcode, @name, @exp, @price, @stock
                WHERE NOT EXISTS (
                    SELECT 1 FROM products WHERE Barcode = @barcode
                );
            ";

            void Add(string barcode, string name, DateTime exp, decimal price, int stock)
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", barcode.Substring(barcode.Length - 4));
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@exp", exp);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.ExecuteNonQuery();
                }
            }

            Add("480015280058", "Paracetamol 500mg", new DateTime(2027, 12, 31), 5.00m, 100);
            Add("480650830012", "Ibuprofen 200mg", new DateTime(2027, 10, 31), 8.50m, 80);
            Add("480901234567", "Amoxicillin 500mg", new DateTime(2026, 8, 31), 12.00m, 60);
            Add("480778899001", "Chlorhexidine Mouthwash", new DateTime(2026, 6, 30), 95.00m, 40);
            Add("480334455667", "Mefenamic Acid 500mg", new DateTime(2027, 3, 31), 10.00m, 70);
        }

        private static void InsertDefaultUser(
            MySqlConnection conn,
            string empId,
            string firstName,
            string lastName,
            string username,
            string plainPassword,
            string accountType)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            string query = @"
                INSERT INTO users
                (employee_id, first_name, last_name, username, password_hash, account_type)
                SELECT
                    @empId, @first, @last, @user, @hash, @type
                WHERE NOT EXISTS (
                    SELECT 1 FROM users WHERE username = @user
                );
            ";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Parameters.AddWithValue("@first", firstName);
                cmd.Parameters.AddWithValue("@last", lastName);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.Parameters.AddWithValue("@type", accountType);
                cmd.ExecuteNonQuery();
            }
        }

        public static void LogActivity(
            MySqlConnection conn,
            string employeeId,
            string username,
            string action)
        {
            string query = @"
                INSERT INTO activity_logs (employee_id, username, action)
                VALUES (@empId, @user, @action);
            ";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@empId", employeeId);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@action", action);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
