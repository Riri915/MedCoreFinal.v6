<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DOCTORPAGES
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.PanelSidebar = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnRecords = New System.Windows.Forms.Button()
        Me.btnConsultation = New System.Windows.Forms.Button()
        Me.btnQueue = New System.Windows.Forms.Button()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.PanelContent = New System.Windows.Forms.Panel()
        Me.UC_NEWDASHBOARD1 = New MedCoreVB.UC_NEWDASHBOARD()
        Me.PanelTop.SuspendLayout()
        Me.PanelSidebar.SuspendLayout()
        Me.PanelContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.lblDateTime)
        Me.PanelTop.Controls.Add(Me.lblTitle)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1284, 60)
        Me.PanelTop.TabIndex = 0
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(1050, 18)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(211, 23)
        Me.lblDateTime.TabIndex = 1
        Me.lblDateTime.Text = "February 23, 2026 10:12:42"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(163, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "MEDCORE"
        '
        'PanelSidebar
        '
        Me.PanelSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.PanelSidebar.Controls.Add(Me.btnLogout)
        Me.PanelSidebar.Controls.Add(Me.btnRecords)
        Me.PanelSidebar.Controls.Add(Me.btnConsultation)
        Me.PanelSidebar.Controls.Add(Me.btnQueue)
        Me.PanelSidebar.Controls.Add(Me.btnDashboard)
        Me.PanelSidebar.Controls.Add(Me.lblMenu)
        Me.PanelSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelSidebar.Location = New System.Drawing.Point(0, 60)
        Me.PanelSidebar.Name = "PanelSidebar"
        Me.PanelSidebar.Size = New System.Drawing.Size(220, 590)
        Me.PanelSidebar.TabIndex = 1
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(0, 540)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(220, 50)
        Me.btnLogout.TabIndex = 5
        Me.btnLogout.Text = "Log Out"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnRecords
        '
        Me.btnRecords.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRecords.FlatAppearance.BorderSize = 0
        Me.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecords.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnRecords.ForeColor = System.Drawing.Color.White
        Me.btnRecords.Location = New System.Drawing.Point(0, 203)
        Me.btnRecords.Name = "btnRecords"
        Me.btnRecords.Size = New System.Drawing.Size(220, 50)
        Me.btnRecords.TabIndex = 4
        Me.btnRecords.Text = "Records"
        Me.btnRecords.UseVisualStyleBackColor = True
        '
        'btnConsultation
        '
        Me.btnConsultation.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnConsultation.FlatAppearance.BorderSize = 0
        Me.btnConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnConsultation.ForeColor = System.Drawing.Color.White
        Me.btnConsultation.Location = New System.Drawing.Point(0, 153)
        Me.btnConsultation.Name = "btnConsultation"
        Me.btnConsultation.Size = New System.Drawing.Size(220, 50)
        Me.btnConsultation.TabIndex = 3
        Me.btnConsultation.Text = "Consultation"
        Me.btnConsultation.UseVisualStyleBackColor = True
        '
        'btnQueue
        '
        Me.btnQueue.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnQueue.FlatAppearance.BorderSize = 0
        Me.btnQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQueue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnQueue.ForeColor = System.Drawing.Color.White
        Me.btnQueue.Location = New System.Drawing.Point(0, 103)
        Me.btnQueue.Name = "btnQueue"
        Me.btnQueue.Size = New System.Drawing.Size(220, 50)
        Me.btnQueue.TabIndex = 2
        Me.btnQueue.Text = "Queue"
        Me.btnQueue.UseVisualStyleBackColor = True
        '
        'btnDashboard
        '
        Me.btnDashboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDashboard.FlatAppearance.BorderSize = 0
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDashboard.ForeColor = System.Drawing.Color.White
        Me.btnDashboard.Location = New System.Drawing.Point(0, 53)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(220, 50)
        Me.btnDashboard.TabIndex = 1
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMenu.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblMenu.ForeColor = System.Drawing.Color.White
        Me.lblMenu.Location = New System.Drawing.Point(0, 0)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Padding = New System.Windows.Forms.Padding(15, 15, 0, 10)
        Me.lblMenu.Size = New System.Drawing.Size(87, 53)
        Me.lblMenu.TabIndex = 0
        Me.lblMenu.Text = "MENU"
        '
        'PanelContent
        '
        Me.PanelContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PanelContent.Controls.Add(Me.UC_NEWDASHBOARD1)
        Me.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContent.Location = New System.Drawing.Point(220, 60)
        Me.PanelContent.Name = "PanelContent"
        Me.PanelContent.Size = New System.Drawing.Size(1064, 590)
        Me.PanelContent.TabIndex = 2
        '
        'UC_NEWDASHBOARD1
        '
        Me.UC_NEWDASHBOARD1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_NEWDASHBOARD1.Location = New System.Drawing.Point(0, 0)
        Me.UC_NEWDASHBOARD1.Name = "UC_NEWDASHBOARD1"
        Me.UC_NEWDASHBOARD1.Size = New System.Drawing.Size(1064, 590)
        Me.UC_NEWDASHBOARD1.TabIndex = 0
        '
        'DOCTORPAGES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 650)
        Me.Controls.Add(Me.PanelContent)
        Me.Controls.Add(Me.PanelSidebar)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "DOCTORPAGES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MEDCORE - Doctor Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.PanelSidebar.ResumeLayout(False)
        Me.PanelSidebar.PerformLayout()
        Me.PanelContent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents PanelSidebar As Panel
    Friend WithEvents lblMenu As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnQueue As Button
    Friend WithEvents btnConsultation As Button
    Friend WithEvents btnRecords As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents PanelContent As Panel
    Friend WithEvents UC_NEWDASHBOARD1 As UC_NEWDASHBOARD
End Class