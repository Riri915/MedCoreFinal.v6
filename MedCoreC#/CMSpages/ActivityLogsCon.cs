using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using CoreLibrary;

namespace MedCoreC_.CMSpages
{
    public partial class ActivityLogsCon : UserControl
    {
        private DataTable logsTable;
        private readonly string connStr = "server=localhost;user id=root;password=;database=medcore;";

        public ActivityLogsCon()
        {
            InitializeComponent();
        }

        private void ActivityLogsCon_Load(object sender, EventArgs e)
        {
            LabelPanelGradientStyler.Apply(panel2);
            ActivityLogGridStyler.Apply(dgvActivityLogs);
            ActivityLogGridStyler.ApplyRoundedEdges(dgvPanel);

            LoadActivityLogs();

            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void LoadActivityLogs()
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            employee_id AS 'Employee ID', 
                            username AS 'Username', 
                            action AS 'Action', 
                            DATE_FORMAT(created_at, '%Y-%m-%d %h:%i %p') AS 'Date & Time'
                        FROM activity_logs
                        ORDER BY created_at DESC
                        LIMIT 50;";

                    using (var da = new MySqlDataAdapter(query, conn))
                    {
                        logsTable = new DataTable();
                        da.Fill(logsTable);

                        dgvActivityLogs.DataSource = logsTable;
                        dgvActivityLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvActivityLogs.ReadOnly = true;
                        dgvActivityLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvActivityLogs.AllowUserToAddRows = false;
                        dgvActivityLogs.AllowUserToDeleteRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load activity logs:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (logsTable == null) return;

            string keyword = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrWhiteSpace(keyword))
            {
                logsTable.DefaultView.RowFilter = "";
            }
            else
            {
                logsTable.DefaultView.RowFilter = $@"
                    [Employee ID] LIKE '%{keyword}%' OR 
                    [Username] LIKE '%{keyword}%' OR 
                    [Action] LIKE '%{keyword}%'";
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}