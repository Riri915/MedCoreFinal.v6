using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MedCoreC_
{
    public partial class StockInReports : UserControl
    {
        private readonly string connString =
            "server=localhost;user id=root;password=;database=medcore;";

        public StockInReports()
        {
            InitializeComponent();

            LoadTodayReport();

            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void btnDailyReports_Click(object sender, EventArgs e)
        {
            lblReportType.Text = "Today's Report";
            LoadTodayReport();
        }

        private void btnWeeklyReports_Click(object sender, EventArgs e)
        {
            lblReportType.Text = "This Week Report";
            LoadWeeklyReport();
        }

        private void btnMonthlyReports_Click(object sender, EventArgs e)
        {
            lblReportType.Text = "This Month's Report";
            LoadMonthlyReport();
        }

        private void LoadTodayReport(string keyword = "")
        {
            string query = @"
                SELECT TransactionID, ProductID, ProductName, Quantity, DateTime
                FROM stock_in
                WHERE DATE(DateTime) = CURDATE()
                  AND (ProductName LIKE @search OR ProductID LIKE @search)
                ORDER BY DateTime DESC;
            ";

            LoadToGrid(query, keyword);
        }

        private void LoadWeeklyReport(string keyword = "")
        {
            string query = @"
                SELECT TransactionID, ProductID, ProductName, Quantity, DateTime
                FROM stock_in
                WHERE YEARWEEK(DateTime, 1) = YEARWEEK(CURDATE(), 1)
                  AND (ProductName LIKE @search OR ProductID LIKE @search)
                ORDER BY DateTime DESC;
            ";

            LoadToGrid(query, keyword);
        }

        private void LoadMonthlyReport(string keyword = "")
        {
            string query = @"
                SELECT TransactionID, ProductID, ProductName, Quantity, DateTime
                FROM stock_in
                WHERE MONTH(DateTime) = MONTH(CURDATE())
                  AND YEAR(DateTime) = YEAR(CURDATE())
                  AND (ProductName LIKE @search OR ProductID LIKE @search)
                ORDER BY DateTime DESC;
            ";

            LoadToGrid(query, keyword);
        }

        private void LoadToGrid(string query, string keyword)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);

                    dgvStockIn.DataSource = dt;
                }
            }

            FormatGrid();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (lblReportType.Text.Contains("Today"))
                LoadTodayReport(txtSearch.Text.Trim());
            else if (lblReportType.Text.Contains("Week"))
                LoadWeeklyReport(txtSearch.Text.Trim());
            else
                LoadMonthlyReport(txtSearch.Text.Trim());
        }

        private void FormatGrid()
        {
            dgvStockIn.ReadOnly = true;
            dgvStockIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockIn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockIn.AllowUserToAddRows = false;
        }

        private void StockInReports_Load(object sender, EventArgs e)
        {
            LabelPanelGradientStyler.Apply(pnlReportType);
            LabelPanelGradientStyler.Apply(LabelPanel);
            ActivityLogGridStyler.Apply(dgvStockIn);
            ActivityLogGridStyler.ApplyRoundedEdges(pnlDgv);
        }

        private void lblStockInReports_Click(object sender, EventArgs e)
        {

        }
    }
}
