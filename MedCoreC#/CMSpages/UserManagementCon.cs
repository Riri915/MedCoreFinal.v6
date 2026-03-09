using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MedCoreC_.CMSpages
{
    public partial class UserManagementCon : UserControl
    {
        private DataTable usersTable;

        private readonly string connStr =
            "server=localhost;user id=root;password=;database=medcore;";

        public UserManagementCon()
        {
            InitializeComponent();
        }

        private void UserManagementCon_Load(object sender, EventArgs e)
        {
            LoadUsers();
            dgvUsers.Columns["Password"].Visible = false;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            LabelPanelGradientStyler.Apply(panel2);

            ActivityLogGridStyler.Apply(dgvUsers);
            ActivityLogGridStyler.ApplyRoundedEdges(panel1, 18);
            ActivityLogGridStyler.ApplyRoundedEdges(panel2, 18);

        }

        private void LoadUsers()
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            employee_id AS 'Employee ID',
                            CONCAT(first_name, ' ', last_name) AS 'Full Name',
                            account_type AS 'Account Type',
                            username AS 'Username',
                            password_hash AS 'Password',
                            created_at AS 'Date Created'
                        FROM users;
                    ";

                    using (var da = new MySqlDataAdapter(query, conn))
                    {
                        usersTable = new DataTable();
                        da.Fill(usersTable);

                        dgvUsers.DataSource = usersTable;
                        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvUsers.ReadOnly = true;
                        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvUsers.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load users:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (usersTable == null) return;

            string keyword = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrWhiteSpace(keyword))
            {
                usersTable.DefaultView.RowFilter = "";
            }
            else
            {
                usersTable.DefaultView.RowFilter = $@"
                    [Employee ID] LIKE '%{keyword}%' OR
                    [Full Name] LIKE '%{keyword}%' OR
                    [Account Type] LIKE '%{keyword}%' OR
                    [Username] LIKE '%{keyword}%'
                ";
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUsers addForm = new AddUsers();
            addForm.FormClosed += (s, args) => LoadUsers();
            addForm.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string username = dgvUsers.SelectedRows[0]
                .Cells["Username"].Value.ToString();

            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Default admin account cannot be deleted.",
                    "Action Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete user '{username}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE username = @username";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to delete user:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}