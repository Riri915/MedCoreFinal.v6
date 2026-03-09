namespace MedCoreC_
{
    partial class StockInReports
    {

        private System.ComponentModel.IContainer components = null;

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
            this.LabelPanel = new System.Windows.Forms.Panel();
            this.lblStockInReports = new System.Windows.Forms.Label();
            this.pnlReportType = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvStockIn = new System.Windows.Forms.DataGridView();
            this.LabelPanel.SuspendLayout();
            this.pnlReportType.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelPanel
            // 
            this.LabelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.LabelPanel.Controls.Add(this.lblStockInReports);
            this.LabelPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelPanel.Name = "LabelPanel";
            this.LabelPanel.Size = new System.Drawing.Size(1280, 50);
            this.LabelPanel.TabIndex = 3;
            // 
            // lblStockInReports
            // 
            this.lblStockInReports.AutoSize = true;
            this.lblStockInReports.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockInReports.ForeColor = System.Drawing.Color.Transparent;
            this.lblStockInReports.Location = new System.Drawing.Point(35, 5);
            this.lblStockInReports.Name = "lblStockInReports";
            this.lblStockInReports.Size = new System.Drawing.Size(243, 40);
            this.lblStockInReports.TabIndex = 0;
            this.lblStockInReports.Text = "Stock-In Reports";
            // 
            // pnlReportType
            // 
            this.pnlReportType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReportType.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlReportType.Controls.Add(this.label1);
            this.pnlReportType.Controls.Add(this.lblReportType);
            this.pnlReportType.Controls.Add(this.txtSearch);
            this.pnlReportType.Location = new System.Drawing.Point(0, 143);
            this.pnlReportType.Name = "pnlReportType";
            this.pnlReportType.Size = new System.Drawing.Size(1280, 50);
            this.pnlReportType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(760, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search :";
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.ForeColor = System.Drawing.Color.Transparent;
            this.lblReportType.Location = new System.Drawing.Point(35, 5);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(220, 40);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "Today\'s Report";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(852, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(410, 34);
            this.txtSearch.TabIndex = 8;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnMonth);
            this.pnlButtons.Controls.Add(this.btnWeek);
            this.pnlButtons.Controls.Add(this.btnToday);
            this.pnlButtons.Location = new System.Drawing.Point(0, 68);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(631, 57);
            this.pnlButtons.TabIndex = 5;
            // 
            // btnMonth
            // 
            this.btnMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMonth.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMonth.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.ForeColor = System.Drawing.Color.Black;
            this.btnMonth.Location = new System.Drawing.Point(416, 10);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(192, 36);
            this.btnMonth.TabIndex = 7;
            this.btnMonth.Text = "Monthly Reports";
            this.btnMonth.UseVisualStyleBackColor = false;
            // 
            // btnWeek
            // 
            this.btnWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWeek.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWeek.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeek.ForeColor = System.Drawing.Color.Black;
            this.btnWeek.Location = new System.Drawing.Point(218, 10);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(192, 36);
            this.btnWeek.TabIndex = 6;
            this.btnWeek.Text = "Weekly Reports";
            this.btnWeek.UseVisualStyleBackColor = false;
            // 
            // btnToday
            // 
            this.btnToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToday.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnToday.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToday.ForeColor = System.Drawing.Color.Black;
            this.btnToday.Location = new System.Drawing.Point(20, 10);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(192, 36);
            this.btnToday.TabIndex = 5;
            this.btnToday.Text = "Daily Reports";
            this.btnToday.UseVisualStyleBackColor = false;
            // 
            // pnlDgv
            // 
            this.pnlDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDgv.Controls.Add(this.dgvStockIn);
            this.pnlDgv.Location = new System.Drawing.Point(0, 211);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(1277, 496);
            this.pnlDgv.TabIndex = 6;
            // 
            // dgvStockIn
            // 
            this.dgvStockIn.AllowUserToAddRows = false;
            this.dgvStockIn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockIn.Location = new System.Drawing.Point(0, 0);
            this.dgvStockIn.MultiSelect = false;
            this.dgvStockIn.Name = "dgvStockIn";
            this.dgvStockIn.ReadOnly = true;
            this.dgvStockIn.RowHeadersWidth = 51;
            this.dgvStockIn.RowTemplate.Height = 24;
            this.dgvStockIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockIn.Size = new System.Drawing.Size(1277, 496);
            this.dgvStockIn.TabIndex = 0;
            // 
            // StockInReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDgv);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlReportType);
            this.Controls.Add(this.LabelPanel);
            this.Name = "StockInReports";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.StockInReports_Load);
            this.LabelPanel.ResumeLayout(false);
            this.LabelPanel.PerformLayout();
            this.pnlReportType.ResumeLayout(false);
            this.pnlReportType.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LabelPanel;
        private System.Windows.Forms.Label lblStockInReports;
        private System.Windows.Forms.Panel pnlReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvStockIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
