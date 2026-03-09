using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using BCrypt.Net;

namespace MedCoreC_
{
    public partial class AddUsers : Form
    {
        private readonly string connStr =
            "server=localhost;user id=root;password=;database=medcore;";

        public AddUsers()
        {
            InitializeComponent();
            LoadAccountTypes();
        }

        private void LoadAccountTypes()
        {
            cmbAccountType.Items.Clear();
            cmbAccountType.Items.Add("Admin");
            cmbAccountType.Items.Add("Cashier");
            cmbAccountType.Items.Add("Doctor");
            cmbAccountType.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;
            string accountType = cmbAccountType.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            string employeeId = GenerateEmployeeID();

            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO users
                        (employee_id, first_name, last_name, username, password_hash, account_type)
                        VALUES
                        (@empId, @fname, @lname, @username, @pass, @type);
                    ";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empId", employeeId);
                        cmd.Parameters.AddWithValue("@fname", firstName);
                        cmd.Parameters.AddWithValue("@lname", lastName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@pass", hashedPassword);
                        cmd.Parameters.AddWithValue("@type", accountType);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error adding user:\n" + ex.Message);
            }
        }

        private string GenerateEmployeeID()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT employee_id
                    FROM users
                    WHERE employee_id LIKE 'EMP%'
                    ORDER BY employee_id DESC
                    LIMIT 1;
                ";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string lastId = reader.GetString(0);
                        int number = int.Parse(lastId.Substring(3));
                        return $"EMP{(number + 1).ToString("D3")}";
                    }
                }
            }

            return "EMP001";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
