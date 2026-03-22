using BCrypt.Net;
using MySql.Data.MySqlClient;

namespace CoreLibrary
{
    public static class AuthHelper
    {
        private static readonly string connStr =
            "server=localhost;user id=root;password=;database=medcore;";

        public static string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }

        public static bool LoginUser(string username, string password, out string account_type)
        {
            account_type = string.Empty;

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT employee_id, first_name, last_name, account_type, password_hash
                    FROM users
                    WHERE username = @username
                    LIMIT 1;
                ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        string storedHash = reader["password_hash"].ToString();

                        if (!BCrypt.Net.BCrypt.Verify(password, storedHash))
                            return false;

                        // ✅ NOW SAFE (columns exist)
                        Session.EmployeeID = reader["employee_id"].ToString();
                        Session.FirstName = reader["first_name"].ToString();
                        Session.LastName = reader["last_name"].ToString();
                        Session.Position = reader["account_type"].ToString();

                        account_type = reader["account_type"].ToString();

                        return true;
                    }
                }
            }
        }

    }
}
