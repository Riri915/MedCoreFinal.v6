using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedCoreC_.Kiosk
{
    public partial class OldPatient : UserControl
    {
        private readonly KioskForm mainForm;
        public OldPatient(KioskForm mainForm)
        {
            InitializeComponent();
            mainForm = mainForm;

            Submit_btn.Click += Submit_btn_Click;
            Back_btn.Click += Back_btn_Click;

            //Apply gradient styler
            LabelPanelGradientStyler.Apply(OldPatientForm_panel,
            startColor: Color.FromArgb(45, 85, 200),
            endColor: Color.FromArgb(110, 175, 255),
            cornerRadius: 20);
            this.mainForm = mainForm;
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {
            string patientID = PatientID_txt.Text.Trim();
            if (patientID == "")
            {
                MessageBox.Show("Please enter your Patient ID.");
                return;
            }
            mainForm.LoadUserControl(new Service(mainForm));
        }
        private void Back_btn_Click(object sender, EventArgs e)
        {
            mainForm.LoadUserControl(new Patient(mainForm));
        }

        public class RoundedTextBox : TextBox
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 15; // change for roundness
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();
                    this.Region = new Region(path);
                }
            }
        }
        private void submitButton_MouseEnter(object sender, EventArgs e)
        {
            Submit_btn.BackColor = Color.LightBlue; // change color on hover
        }

        private void submitButton_MouseLeave(object sender, EventArgs e)
        {
            Submit_btn.BackColor = Color.DodgerBlue; // original color
        }

    }
}
