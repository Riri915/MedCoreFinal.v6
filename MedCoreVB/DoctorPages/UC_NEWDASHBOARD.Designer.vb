<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_NEWDASHBOARD
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblPastaTitle = New System.Windows.Forms.Label()
        Me.UC_PANELCHARTS1 = New MedCoreVB.UC_PANELCHARTS()
        Me.UC_PANEL_STATS1 = New MedCoreVB.UC_PANEL_STATS()
        Me.SuspendLayout()
        '
        'lblPastaTitle
        '
        Me.lblPastaTitle.AutoSize = True
        Me.lblPastaTitle.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPastaTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblPastaTitle.Location = New System.Drawing.Point(54, 24)
        Me.lblPastaTitle.Name = "lblPastaTitle"
        Me.lblPastaTitle.Size = New System.Drawing.Size(488, 62)
        Me.lblPastaTitle.TabIndex = 15
        Me.lblPastaTitle.Text = "GOOD DAY,DOCTOR!"
        '
        'UC_PANELCHARTS1
        '
        Me.UC_PANELCHARTS1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UC_PANELCHARTS1.Location = New System.Drawing.Point(65, 108)
        Me.UC_PANELCHARTS1.Name = "UC_PANELCHARTS1"
        Me.UC_PANELCHARTS1.Size = New System.Drawing.Size(935, 150)
        Me.UC_PANELCHARTS1.TabIndex = 7
        '
        'UC_PANEL_STATS1
        '
        Me.UC_PANEL_STATS1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UC_PANEL_STATS1.Location = New System.Drawing.Point(65, 283)
        Me.UC_PANEL_STATS1.Name = "UC_PANEL_STATS1"
        Me.UC_PANEL_STATS1.Size = New System.Drawing.Size(935, 265)
        Me.UC_PANEL_STATS1.TabIndex = 6
        '
        'UC_NEWDASHBOARD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPastaTitle)
        Me.Controls.Add(Me.UC_PANELCHARTS1)
        Me.Controls.Add(Me.UC_PANEL_STATS1)
        Me.Name = "UC_NEWDASHBOARD"
        Me.Size = New System.Drawing.Size(1064, 590)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UC_PANEL_STATS1 As UC_PANEL_STATS
    Friend WithEvents UC_PANELCHARTS1 As UC_PANELCHARTS
    Friend WithEvents lblPastaTitle As Label
End Class
