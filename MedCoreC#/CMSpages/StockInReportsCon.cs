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

        private string currentFilter = "today";

        public StockInReports()
        {
            InitializeComponent();

            currentFilter = "today";
            lblReportType.Text = "Today's Report";

            LoadData();

            txtSearch.TextChanged += TxtSearch_TextChanged;
        }
        private void btnDailyReports_Click(object sender, EventArgs e)
        {
            currentFilter = "today";
            lblReportType.Text = "Today's Report";
            LoadData();
        }

        private void btnWeeklyReports_Click(object sender, EventArgs e)
        {
            currentFilter = "week";
            lblReportType.Text = "This Week Report";
            LoadData();
        }

        private void btnMonthlyReports_Click(object sender, EventArgs e)
        {
            currentFilter = "month";
            lblReportType.Text = "This Month's Report";
            LoadData();
        }

        private void LoadData(string keyword = "")
        {
            string query = @"
                SELECT TransactionID, ProductID, ProductName, Quantity, DateTime
                FROM stock_in
                WHERE 1=1 ";

            switch (currentFilter)
            {
                case "today":
                    query += "AND DATE(`DateTime`) = CURDATE() ";
                    break;

                case "week":
                    query += "AND YEARWEEK(`DateTime`, 1) = YEARWEEK(CURDATE(), 1) ";
                    break;

                case "month":
                    query += @"AND MONTH(`DateTime`) = MONTH(CURDATE()) 
                               AND YEAR(`DateTime`) = YEAR(CURDATE()) ";
                    break;
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query += "AND (ProductName LIKE @search OR CAST(ProductID AS CHAR) LIKE @search) ";
            }

            query += "ORDER BY `DateTime` DESC";

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + keyword.Trim() + "%");
                    }

                    DataTable dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);

                    dgvStockIn.DataSource = dt;
                }
            }

            FormatGrid();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
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