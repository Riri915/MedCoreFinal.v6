namespace MedCoreC_
{
    partial class kiosk
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kiosk));
            this.panelWelcome_Click = new System.Windows.Forms.Panel();
            this.Click = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_Background_Click = new System.Windows.Forms.PictureBox();
            this.panelWelcome_Click.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Background_Click)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWelcome_Click
            // 
            this.panelWelcome_Click.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelWelcome_Click.Controls.Add(this.Click);
            this.panelWelcome_Click.Controls.Add(this.label2);
            this.panelWelcome_Click.Controls.Add(this.label1);
            this.panelWelcome_Click.Controls.Add(this.pb_Background_Click);
            this.panelWelcome_Click.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWelcome_Click.Location = new System.Drawing.Point(0, 0);
            this.panelWelcome_Click.Name = "panelWelcome_Click";
            this.panelWelcome_Click.Size = new System.Drawing.Size(980, 529);
            this.panelWelcome_Click.TabIndex = 3;
            // 
            // Click
            // 
            this.Click.AutoSize = true;
            this.Click.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Click.Font = new System.Drawing.Font("Rockwell Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Click.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Click.Location = new System.Drawing.Point(774, 457);
            this.Click.Name = "Click";
            this.Click.Size = new System.Drawing.Size(194, 41);
            this.Click.TabIndex = 4;
            this.Click.Text = "Click Anywhere";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(440, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gentle care for every smile.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to MedCore Dental Clinic";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pb_Background_Click
            // 
            this.pb_Background_Click.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pb_Background_Click.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Background_Click.BackgroundImage")));
            this.pb_Background_Click.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Background_Click.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_Background_Click.InitialImage")));
            this.pb_Background_Click.Location = new System.Drawing.Point(1, 0);
            this.pb_Background_Click.Name = "pb_Background_Click";
            this.pb_Background_Click.Size = new System.Drawing.Size(979, 529);
            this.pb_Background_Click.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Background_Click.TabIndex = 0;
            this.pb_Background_Click.TabStop = false;
            this.pb_Background_Click.Click += new System.EventHandler(this.pb_Background_Click_Click);
            // 
            // kiosk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(980, 529);
            this.Controls.Add(this.panelWelcome_Click);
            this.DoubleBuffered = true;
            this.Name = "kiosk";
            this.Text = "kiosk";
            this.Load += new System.EventHandler(this.kiosk_Load);
            this.panelWelcome_Click.ResumeLayout(false);
            this.panelWelcome_Click.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Background_Click)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelWelcome_Click;
        private System.Windows.Forms.PictureBox pb_Background_Click;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Click;
    }
}