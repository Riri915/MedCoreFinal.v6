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
    public partial class kiosk : Form
    {
        public kiosk()
        {
            InitializeComponent();
        }

        private void kiosk_Load(object sender, EventArgs e)
        {

        }

        private void pb_Background_Click_Click(object sender, EventArgs e)
        {
            menu formMenu = new menu();
            formMenu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
