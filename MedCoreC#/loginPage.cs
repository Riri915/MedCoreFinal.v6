using CoreLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MedCoreC_
{
    public partial class loginPage : Form
    {
        public loginPage()
        {
            InitializeComponent();
            btnLogin.Select();

            usertxt.Text = "Username";
            usertxt.ForeColor = Color.Gray;
            usertxt.Enter += Usertxt_Enter;
            usertxt.Leave += Usertxt_Leave;

            pwtxt.Text = "Password";
            pwtxt.ForeColor = Color.Gray;
            pwtxt.UseSystemPasswordChar = false;
            pwtxt.Enter += Pwtxt_Enter;
            pwtxt.Leave += Pwtxt_Leave;
        }

        private void Usertxt_Enter(object sender, EventArgs e)
        {
            if (usertxt.Text == "Username")
            {
                usertxt.Text = "";
                usertxt.ForeColor = Color.Black;
            }
        }

        private void Usertxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usertxt.Text))
            {
                usertxt.Text = "Username";
                usertxt.ForeColor = Color.Gray;
            }
        }

        private void Pwtxt_Enter(object sender, EventArgs e)
        {
            if (pwtxt.Text == "Password")
            {
                pwtxt.Text = "";
                pwtxt.ForeColor = Color.Black;
                pwtxt.UseSystemPasswordChar = true;
            }
        }

        private void Pwtxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwtxt.Text))
            {
                pwtxt.UseSystemPasswordChar = false;
                pwtxt.Text = "Password";
                pwtxt.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = usertxt.Text.Trim();
            string password = pwtxt.Text;

            if (username == "" || password == "" || username == "Username" || password == "Password")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            if (!CoreLibrary.DatabaseInitializer.DatabaseSuccess)
            {
                MessageBox.Show("Database not initialized yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AuthHelper.LoginUser(username, password, out string account_type))
            {
                UserSession.Username = username;
                UserSession.EmployeeID = "EMP001"; 

                using (var conn = new MySqlConnection("server=localhost;userid=root;password=;database=medcore"))
                {
                    conn.Open();
                    ActivityLogger.Log(conn,
                    UserSession.EmployeeID,
                    UserSession.Username,
                    "Logged in");
                }

                if (account_type.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    CMS cmsForm = new CMS();
                    cmsForm.FormClosed += (s, args) => this.Show();
                    cmsForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Access role not supported.", "Access Denied");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed");
            }

        }

        private void loginPage_Load(object sender, EventArgs e)
        {
            DatabaseInitializer.InitializeTABLE();
            this.AcceptButton = btnLogin;
        }
    }
}
