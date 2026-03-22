using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedCoreC_.Kiosk
{
    public partial class Service : UserControl
    {
        private KioskForm mainForm;
        public Service()
        {
            InitializeComponent();
            mainForm = mainForm;

            // Click Event
            WireClick(CheckUp_panel, CheckUp_pb, "Check Up");
            WireClick(ToothFilling_panel, ToothFilling_pb, "Tooth Filling");
            WireClick(TeethCleaning_panel, TeethCleaning_pb, "Teeth Cleaning");
            WireClick(ToothExtraction_panel, ToothExtraction_pb, "Tooth Extraction");
            WireClick(Braces_panel, Braces_pb, "Braces");
            WireClick(Denture_panel, Denture_pb, "Denture");

            //Apply gradient styler
            LabelPanelGradientStyler.Apply(Service_panel,
            startColor: Color.FromArgb(45, 85, 200),
            endColor: Color.FromArgb(110, 175, 255),
            cornerRadius: 20);
        }

        //Panel and PictureBox Click Wiring
        private void WireClick(Panel panel, PictureBox pictureBox, string serviceName)
        {
            panel.Click += (s, e) => SelectService(serviceName);
            pictureBox.Click += (s, e) => SelectService(serviceName);
        }

        // Service Selection Logic
        private void SelectService(string serviceName)
        {
            AppState.SelectedService = serviceName;

            DialogResult result = MessageBox.Show(
            $"You selected: {serviceName}",
            "Service Selected",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Information
            );

            if (result == DialogResult.OK)
            {
                mainForm.LoadUserControl(new Queuing(mainForm));
            }
        }
    }
}
