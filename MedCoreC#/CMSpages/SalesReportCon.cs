using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MedCoreC_.CMSpages
{
    public partial class SalesReportCon : UserControl
    {
        string connectionString = "server=localhost;userid=root;password=;database=StockBiteDB";
        MySqlConnection connection;

        public SalesReportCon()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void SalesReportCon_Load(object sender, EventArgs e)
        {
            LoadSalesData("today");

            LabelPanelGradientStyler.Apply(pnlReportType);
            LabelPanelGradientStyler.Apply(LabelPanel);
            ActivityLogGridStyler.Apply(dgvSalesReport);
            ActivityLogGridStyler.ApplyRoundedEdges(Panel4);

            dgvSalesReport.Dock = DockStyle.Fill;
            dgvSalesReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void LoadSalesData(string filter, string searchTerm = "")
        {
            try
            {
                connection.Open();

                string query = @"
                    SELECT TransactionID, DateTime, ItemName, Price, Quantity, Subtotal 
                    FROM sales_records 
                    WHERE 1=1 ";

                switch (filter)
                {
                    case "today":
                        query += "AND DATE(DateTime) = CURDATE() ";
                        break;

                    case "week":
                        query += "AND YEARWEEK(DateTime, 1) = YEARWEEK(CURDATE(), 1) ";
                        break;

                    case "month":
                        query += @"AND MONTH(`DateTime`) = MONTH(CURDATE()) 
                       AND YEAR(`DateTime`) = YEAR(CURDATE()) ";
                        break;
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += "AND (ItemName LIKE @term OR TransactionID LIKE @term) ";
                }

                query += "ORDER BY DateTime DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@term", "%" + searchTerm + "%");
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSalesReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Database Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            lblReportTitle.Text = "Today's Report";
            LoadSalesData("today", txtSearch.Text);
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            lblReportTitle.Text = "This Week's Report";
            LoadSalesData("week", txtSearch.Text);
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            lblReportTitle.Text = "This Month's Report";
            LoadSalesData("month", txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterType = "today";

            if (lblReportTitle.Text.Contains("Week"))
                filterType = "week";
            else if (lblReportTitle.Text.Contains("Month"))
                filterType = "month";

            LoadSalesData(filterType, txtSearch.Text);
        }
    }
}