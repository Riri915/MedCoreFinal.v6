using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MedCoreC_.CMSpages
{
    public partial class SalesReportCon : UserControl
    {
        private string connectionString = "server=localhost;userid=root;password=;database=medcore";
        private MySqlConnection connection;
        private string currentFilter = "today";

        public SalesReportCon()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void SalesReportCon_Load(object sender, EventArgs e)
        {
            currentFilter = "today";
            lblReportTitle.Text = "Today's Report";

            LoadSalesData(currentFilter);

      
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
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"
                    SELECT TransactionID, DateTime, ItemName, Price, Quantity, Subtotal 
                    FROM sales_records 
                    WHERE 1=1 ";
                switch (filter)
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

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += "AND (ItemName LIKE @term OR CAST(TransactionID AS CHAR) LIKE @term) ";
                }

                query += "ORDER BY `DateTime` DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@term", "%" + searchTerm.Trim() + "%");
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
            currentFilter = "today";
            lblReportTitle.Text = "Today's Report";
            LoadSalesData(currentFilter, txtSearch.Text.Trim());
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            currentFilter = "week";
            lblReportTitle.Text = "Weekly Report";
            LoadSalesData(currentFilter, txtSearch.Text.Trim());
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            currentFilter = "month";
            lblReportTitle.Text = "Monthly Report";
            LoadSalesData(currentFilter, txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSalesData(currentFilter, txtSearch.Text.Trim());
        }

        
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadSalesData(currentFilter, txtSearch.Text.Trim());
            }
        }
    }
}