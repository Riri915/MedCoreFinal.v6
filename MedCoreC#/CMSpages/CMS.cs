using MedCoreC_.CMSpages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedCoreC_
{
    public partial class CMS : Form
    {
        public CMS()
        {
            InitializeComponent();
        }
        private void LoadControl(UserControl control)
        {
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void CMS_Load(object sender, EventArgs e)
        {
            LoadControl(new DashboardCon());
            SidebarStyler.ApplySidebar(sidebarPanel);

            SidebarStyler.SetActive(btnDashboard);

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new DashboardCon());
        }

        private void btnActLogs_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new ActivityLogsCon());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new InventoryCon());
        }

        private void btnDoctorSchedule_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new DoctorsScheduleCon());
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new UserManagementCon());
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new SalesReportCon());
        }

        private void btnStockInReports_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new StockInReports());
        }

        private void btnReturnedItemsReport_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            LoadControl(new ReturnedItemsReportCon());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            SidebarStyler.SetActive((Button)sender);
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                loginPage login = new loginPage();
                login.Show();

                this.Close();
            }
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
