using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MedCoreC_.CMSpages
{
    public partial class ReturnedItemsReportCon : UserControl
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=;database=medcore");
        private string currentFilter = "today";
        public ReturnedItemsReportCon()
        {
            InitializeComponent();
        }
        private void ReturnedItemsReportCon_Load(object sender, EventArgs e)
        {
            LoadReturnReport("today");
            LabelPanelGradientStyler.Apply(LabelPanel);
            LabelPanelGradientStyler.Apply(pnlReportType);
            lblReportType.Text = "Today's Report";
            ActivityLogGridStyler.Apply(dgvReturnReport);
            ActivityLogGridStyler.ApplyRoundedEdges(Panel4);
            dgvReturnReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReturnReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReturnReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        private void LoadReturnReport(string filter)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                string query = @"
                    SELECT ReturnID, TransactionID, ProductName, QuantityReturned, RefundAmount, 
                           ReasonForReturn AS Reason, Cashier, ReturnDate AS DateTime
                    FROM return_transactions
                    WHERE 1=1 ";
                switch (filter)
                {
                    case "today":
                        query += "AND DATE(ReturnDate) = CURDATE() ";
                        break;
                    case "week":
                        query += "AND YEARWEEK(ReturnDate, 1) = YEARWEEK(CURDATE(), 1) ";
                        break;
                    case "month":
                        query += @"AND MONTH(ReturnDate) = MONTH(CURDATE()) 
                                   AND YEAR(ReturnDate) = YEAR(CURDATE()) ";
                        break;
                }
                query += "ORDER BY ReturnDate DESC";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvReturnReport.DataSource = dt;
                    UpdateSummary(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading return report: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void UpdateSummary(DataTable dt)
        {
            int totalReturns = dt.Rows.Count;
            int totalItems = 0;
            decimal totalRefund = 0m;
            foreach (DataRow row in dt.Rows)
            {
                if (row["QuantityReturned"] != DBNull.Value)
                    totalItems += Convert.ToInt32(row["QuantityReturned"]);
                if (row["RefundAmount"] != DBNull.Value)
                    totalRefund += Convert.ToDecimal(row["RefundAmount"]);
            }
            lblTotalReturns.Text = "Total Returns: " + totalReturns;
            lblItemsReturned.Text = "Items Returned: " + totalItems;
            lblTotalRefund.Text = "Total Refund: ₱" + totalRefund.ToString("F2");
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadReturnReport(currentFilter);
                return;
            }
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                string searchQuery = @"
    SELECT ReturnID, TransactionID, ProductName, QuantityReturned, RefundAmount, 
           ReasonForReturn AS Reason, Cashier, ReturnDate AS DateTime
    FROM return_transactions
    WHERE 1=1 ";
                switch (currentFilter)
                {
                    case "today":
                        searchQuery += "AND DATE(ReturnDate) = CURDATE() ";
                        break;
                    case "week":
                        searchQuery += "AND YEARWEEK(ReturnDate, 1) = YEARWEEK(CURDATE(), 1) ";
                        break;
                    case "month":
                        searchQuery += @"AND MONTH(ReturnDate) = MONTH(CURDATE()) 
                         AND YEAR(ReturnDate) = YEAR(CURDATE()) ";
                        break;
                }
                searchQuery += @"
    AND (
        TransactionID LIKE @search 
        OR ProductName LIKE @search 
        OR Cashier LIKE @search
        OR ReasonForReturn LIKE @search
    )
    ORDER BY ReturnDate DESC";
                using (MySqlCommand cmd = new MySqlCommand(searchQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text.Trim() + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvReturnReport.DataSource = dt;
                    UpdateSummary(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void btnToday_Click(object sender, EventArgs e)
        {
            currentFilter = "today";
            lblReportType.Text = "Today's Report";
            LoadReturnReport("today");
        }
        private void btnWeek_Click(object sender, EventArgs e)
        {
            currentFilter = "week";
            lblReportType.Text = "This Week's Report";
            LoadReturnReport("week");
        }
        private void btnMonth_Click(object sender, EventArgs e)
        {
            currentFilter = "month";
            lblReportType.Text = "This Month's Report";
            LoadReturnReport("month");
        }
    }
}