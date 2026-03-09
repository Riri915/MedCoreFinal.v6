namespace MedCoreC_
{
    partial class DashboardCon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UpperPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDashboard = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelActLogs = new System.Windows.Forms.Label();
            this.LowerPanel = new System.Windows.Forms.Panel();
            this.dgvActivity = new System.Windows.Forms.DataGridView();
            this.UpperPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LowerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // UpperPanel
            // 
            this.UpperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpperPanel.Controls.Add(this.panel2);
            this.UpperPanel.Controls.Add(this.panel1);
            this.UpperPanel.Location = new System.Drawing.Point(0, 0);
            this.UpperPanel.Name = "UpperPanel";
            this.UpperPanel.Size = new System.Drawing.Size(870, 605);
            this.UpperPanel.TabIndex = 0;
            this.UpperPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.UpperPanel_Paint);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.labelDashboard);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 50);
            this.panel2.TabIndex = 1;
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDashboard.ForeColor = System.Drawing.Color.Transparent;
            this.labelDashboard.Location = new System.Drawing.Point(35, 5);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(167, 40);
            this.labelDashboard.TabIndex = 0;
            this.labelDashboard.Text = "Dashboard";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.labelActLogs);
            this.panel1.Location = new System.Drawing.Point(0, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 50);
            this.panel1.TabIndex = 0;
            // 
            // labelActLogs
            // 
            this.labelActLogs.AutoSize = true;
            this.labelActLogs.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActLogs.ForeColor = System.Drawing.Color.Transparent;
            this.labelActLogs.Location = new System.Drawing.Point(35, 5);
            this.labelActLogs.Name = "labelActLogs";
            this.labelActLogs.Size = new System.Drawing.Size(189, 40);
            this.labelActLogs.TabIndex = 0;
            this.labelActLogs.Text = "Activity Logs";
            // 
            // LowerPanel
            // 
            this.LowerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LowerPanel.Controls.Add(this.dgvActivity);
            this.LowerPanel.Location = new System.Drawing.Point(3, 611);
            this.LowerPanel.Name = "LowerPanel";
            this.LowerPanel.Size = new System.Drawing.Size(867, 75);
            this.LowerPanel.TabIndex = 1;
            // 
            // dgvActivity
            // 
            this.dgvActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivity.Location = new System.Drawing.Point(0, 0);
            this.dgvActivity.Name = "dgvActivity";
            this.dgvActivity.RowHeadersWidth = 51;
            this.dgvActivity.RowTemplate.Height = 24;
            this.dgvActivity.Size = new System.Drawing.Size(867, 75);
            this.dgvActivity.TabIndex = 1;
            // 
            // DashboardCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LowerPanel);
            this.Controls.Add(this.UpperPanel);
            this.Name = "DashboardCon";
            this.Size = new System.Drawing.Size(870, 686);
            this.UpperPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.LowerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UpperPanel;
        private System.Windows.Forms.Panel LowerPanel;
        internal System.Windows.Forms.DataGridView dgvActivity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelActLogs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDashboard;
    }
}
