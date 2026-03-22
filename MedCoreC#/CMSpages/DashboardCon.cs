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
    public partial class DashboardCon : UserControl
    {
        public DashboardCon()
        {
            InitializeComponent();
        }

        private void UpperPanel_Paint(object sender, PaintEventArgs e)
        {
            LabelPanelGradientStyler.Apply(panel2);
            ActivityLogGridStyler.ApplyRoundedEdges(panel2);

        }
    }
}
