using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MedCoreC_
{
    public partial class DashboardCon : UserControl
    {
        private string connString = "server=localhost;userid=root;password=;database=medcore";

        public DashboardCon()
        {
            InitializeComponent();

        }

        private void DashboardCon_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
            LabelPanelGradientStyler.Apply(pnlDashboard);

            ActivityLogGridStyler.ApplyRoundedEdges(pnlTotalProducts);
            ActivityLogGridStyler.ApplyRoundedEdges(pnlTotalSales);
            ActivityLogGridStyler.ApplyRoundedEdges(pnlLowStock);
            ActivityLogGridStyler.ApplyRoundedEdges(pnlUsers);
            ActivityLogGridStyler.ApplyRoundedEdges(pnlTotalRevenue);

            LabelPanelGradientStyler.Apply(pnlGraphs);

            InitializeSalesChart();
            LoadSalesChartData();
            LoadTopProductsChart();

        }

        private void RefreshDashboard()
        {
            LoadMetricsFromDB();
        }

        private void LoadMetricsFromDB()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    lblTotalProducts.Text = ExecuteScalar(conn, "SELECT COUNT(*) FROM products");
                    lblTotalSales.Text = ExecuteScalar(conn, "SELECT COUNT(*) FROM transactions");
                    lblUsers.Text = ExecuteScalar(conn, "SELECT COUNT(*) FROM users");

                    decimal totalRevenue = Convert.ToDecimal(
                        ExecuteScalar(conn, "SELECT IFNULL(SUM(Total),0) FROM transactions")
                    );

                    lblTotalRevenue.Text = totalRevenue.ToString("C2");

                    lblLowStock.Text = ExecuteScalar(conn, "SELECT COUNT(*) FROM products WHERE UnitInStock < 10");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading metrics: " + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string ExecuteScalar(MySqlConnection conn, string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "0";
            }
        }
        private void InitializeSalesChart()
        {
            
            chartSales.Series.Clear();
            chartSales.ChartAreas.Clear();

            ChartArea area = new ChartArea();
            area.AxisX.Title = "Date";
            area.AxisY.Title = "Sales";
            chartSales.ChartAreas.Add(area);

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 100;
            area.AxisY.Interval = 10;

            Series series = new Series();
            series.Name = "Sales";
            series.ChartType = SeriesChartType.Spline;
            series.BorderWidth = 3;

            chartSales.Series.Add(series);

            Series yesterdaySeries = new Series();
            yesterdaySeries.Name = "Yesterday";
            yesterdaySeries.ChartType = SeriesChartType.Spline;
            yesterdaySeries.BorderDashStyle = ChartDashStyle.Dash;
            yesterdaySeries.Color = Color.Gray;

            chartSales.Series.Add(yesterdaySeries);
        }
        private void LoadSalesChartData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"
                SELECT DATE_FORMAT(DateTime, '%H:%i') AS TimeSlot, 
                       SUM(Total) AS TotalSales
                FROM transactions
                WHERE DATE(DateTime) = CURDATE()
                GROUP BY TimeSlot
                ORDER BY DateTime ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        chartSales.Series["Sales"].Points.Clear();

                        while (reader.Read())
                        {
                            string time = reader["TimeSlot"].ToString();
                            decimal total = Convert.ToDecimal(reader["TotalSales"]);

                            chartSales.Series["Sales"].Points.AddXY(time, total);
                        }
                    }
                }

                using (MySqlConnection conn2 = new MySqlConnection(connString))
                {
                    conn2.Open();

                    string yesterdayQuery = @"
                SELECT DATE_FORMAT(DateTime, '%H:%i') AS TimeSlot, 
                       SUM(Total) AS TotalSales
                FROM transactions
                WHERE DATE(DateTime) = CURDATE() - INTERVAL 1 DAY
                GROUP BY TimeSlot
                ORDER BY DateTime ASC";

                    using (MySqlCommand cmd2 = new MySqlCommand(yesterdayQuery, conn2))
                    using (MySqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        chartSales.Series["Yesterday"].Points.Clear();

                        while (reader2.Read())
                        {
                            string time = reader2["TimeSlot"].ToString();
                            decimal total = Convert.ToDecimal(reader2["TotalSales"]);

                            chartSales.Series["Yesterday"].Points.AddXY(time, total);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message);
            }
        }
        private void LoadTopProductsChart()
        {
            chartProducts.Series.Clear();
            chartProducts.ChartAreas.Clear();

            ChartArea area = new ChartArea();
            chartProducts.ChartAreas.Add(area);

            Series series = new Series();
            series.ChartType = SeriesChartType.Bar;

            chartProducts.Series.Add(series);

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        DATE_FORMAT(DateTime, '%H:%i') AS TimeSlot,
                        SUM(Total) AS TotalSales
                    FROM transactions
                    GROUP BY TimeSlot
                    ORDER BY DateTime ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string time = reader["TimeSlot"].ToString();
                        decimal total = Convert.ToDecimal(reader["TotalSales"]);

                        series.Points.AddXY(time, total);
                    }
                }
            }
        }

        private void pnlActivityLogs_Paint(object sender, PaintEventArgs e)
        {
        }

        private void chartSales_Click(object sender, EventArgs e)
        {

        }
    }
}