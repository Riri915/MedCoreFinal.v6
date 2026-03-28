<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_DASHBOARD
    Inherits System.Windows.Forms.UserControl

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
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.PanelStats = New System.Windows.Forms.Panel()
        Me.PanelDone = New System.Windows.Forms.Panel()
        Me.lblDoneValue = New System.Windows.Forms.Label()
        Me.lblDoneTitle = New System.Windows.Forms.Label()
        Me.PanelServing = New System.Windows.Forms.Panel()
        Me.lblServingValue = New System.Windows.Forms.Label()
        Me.lblServingTitle = New System.Windows.Forms.Label()
        Me.PanelWaiting = New System.Windows.Forms.Panel()
        Me.lblWaitingValue = New System.Windows.Forms.Label()
        Me.lblWaitingTitle = New System.Windows.Forms.Label()
        Me.PanelTotal = New System.Windows.Forms.Panel()
        Me.lblTotalValue = New System.Windows.Forms.Label()
        Me.lblTotalTitle = New System.Windows.Forms.Label()
        Me.PanelCharts = New System.Windows.Forms.Panel()
        Me.lblAvgTimeValue = New System.Windows.Forms.Label()
        Me.lblAvgTimeTitle = New System.Windows.Forms.Label()
        Me.lblOtherTime = New System.Windows.Forms.Label()
        Me.lblCheckupTime = New System.Windows.Forms.Label()
        Me.lblPastaTime = New System.Windows.Forms.Label()
        Me.lblOtherCount = New System.Windows.Forms.Label()
        Me.lblCheckupCount = New System.Windows.Forms.Label()
        Me.lblPastaCount = New System.Windows.Forms.Label()
        Me.barOther = New System.Windows.Forms.Panel()
        Me.barCheckup = New System.Windows.Forms.Panel()
        Me.barPasta = New System.Windows.Forms.Panel()
        Me.lblOtherTitle = New System.Windows.Forms.Label()
        Me.lblCheckupTitle = New System.Windows.Forms.Label()
        Me.lblPastaTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelMain.SuspendLayout()
        Me.PanelStats.SuspendLayout()
        Me.PanelDone.SuspendLayout()
        Me.PanelServing.SuspendLayout()
        Me.PanelWaiting.SuspendLayout()
        Me.PanelTotal.SuspendLayout()
        Me.PanelCharts.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PanelMain.Controls.Add(Me.Panel1)
        Me.PanelMain.Controls.Add(Me.PanelStats)
        Me.PanelMain.Controls.Add(Me.PanelCharts)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1200, 700)
        Me.PanelMain.TabIndex = 0
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblWelcome.Location = New System.Drawing.Point(17, 19)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(501, 62)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "GOOD DAY, DOCTOR!"
        '
        'PanelStats
        '
        Me.PanelStats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelStats.Controls.Add(Me.PanelDone)
        Me.PanelStats.Controls.Add(Me.PanelServing)
        Me.PanelStats.Controls.Add(Me.PanelWaiting)
        Me.PanelStats.Controls.Add(Me.PanelTotal)
        Me.PanelStats.Location = New System.Drawing.Point(30, 120)
        Me.PanelStats.Name = "PanelStats"
        Me.PanelStats.Size = New System.Drawing.Size(1140, 200)
        Me.PanelStats.TabIndex = 1
        '
        'PanelDone
        '
        Me.PanelDone.BackColor = System.Drawing.Color.White
        Me.PanelDone.Controls.Add(Me.lblDoneValue)
        Me.PanelDone.Controls.Add(Me.lblDoneTitle)
        Me.PanelDone.Location = New System.Drawing.Point(855, 0)
        Me.PanelDone.Name = "PanelDone"
        Me.PanelDone.Size = New System.Drawing.Size(280, 180)
        Me.PanelDone.TabIndex = 3
        '
        'lblDoneValue
        '
        Me.lblDoneValue.AutoSize = True
        Me.lblDoneValue.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold)
        Me.lblDoneValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lblDoneValue.Location = New System.Drawing.Point(110, 60)
        Me.lblDoneValue.Name = "lblDoneValue"
        Me.lblDoneValue.Size = New System.Drawing.Size(91, 106)
        Me.lblDoneValue.TabIndex = 1
        Me.lblDoneValue.Text = "0"
        '
        'lblDoneTitle
        '
        Me.lblDoneTitle.AutoSize = True
        Me.lblDoneTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblDoneTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblDoneTitle.Location = New System.Drawing.Point(95, 20)
        Me.lblDoneTitle.Name = "lblDoneTitle"
        Me.lblDoneTitle.Size = New System.Drawing.Size(82, 32)
        Me.lblDoneTitle.TabIndex = 0
        Me.lblDoneTitle.Text = "DONE"
        '
        'PanelServing
        '
        Me.PanelServing.BackColor = System.Drawing.Color.White
        Me.PanelServing.Controls.Add(Me.lblServingValue)
        Me.PanelServing.Controls.Add(Me.lblServingTitle)
        Me.PanelServing.Location = New System.Drawing.Point(570, 0)
        Me.PanelServing.Name = "PanelServing"
        Me.PanelServing.Size = New System.Drawing.Size(280, 180)
        Me.PanelServing.TabIndex = 2
        '
        'lblServingValue
        '
        Me.lblServingValue.AutoSize = True
        Me.lblServingValue.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold)
        Me.lblServingValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblServingValue.Location = New System.Drawing.Point(110, 60)
        Me.lblServingValue.Name = "lblServingValue"
        Me.lblServingValue.Size = New System.Drawing.Size(91, 106)
        Me.lblServingValue.TabIndex = 1
        Me.lblServingValue.Text = "0"
        '
        'lblServingTitle
        '
        Me.lblServingTitle.AutoSize = True
        Me.lblServingTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblServingTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblServingTitle.Location = New System.Drawing.Point(80, 20)
        Me.lblServingTitle.Name = "lblServingTitle"
        Me.lblServingTitle.Size = New System.Drawing.Size(116, 32)
        Me.lblServingTitle.TabIndex = 0
        Me.lblServingTitle.Text = "SERVING"
        '
        'PanelWaiting
        '
        Me.PanelWaiting.BackColor = System.Drawing.Color.White
        Me.PanelWaiting.Controls.Add(Me.lblWaitingValue)
        Me.PanelWaiting.Controls.Add(Me.lblWaitingTitle)
        Me.PanelWaiting.Location = New System.Drawing.Point(285, 0)
        Me.PanelWaiting.Name = "PanelWaiting"
        Me.PanelWaiting.Size = New System.Drawing.Size(280, 180)
        Me.PanelWaiting.TabIndex = 1
        '
        'lblWaitingValue
        '
        Me.lblWaitingValue.AutoSize = True
        Me.lblWaitingValue.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold)
        Me.lblWaitingValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.lblWaitingValue.Location = New System.Drawing.Point(110, 60)
        Me.lblWaitingValue.Name = "lblWaitingValue"
        Me.lblWaitingValue.Size = New System.Drawing.Size(91, 106)
        Me.lblWaitingValue.TabIndex = 1
        Me.lblWaitingValue.Text = "0"
        '
        'lblWaitingTitle
        '
        Me.lblWaitingTitle.AutoSize = True
        Me.lblWaitingTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblWaitingTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblWaitingTitle.Location = New System.Drawing.Point(85, 20)
        Me.lblWaitingTitle.Name = "lblWaitingTitle"
        Me.lblWaitingTitle.Size = New System.Drawing.Size(120, 32)
        Me.lblWaitingTitle.TabIndex = 0
        Me.lblWaitingTitle.Text = "WAITING"
        '
        'PanelTotal
        '
        Me.PanelTotal.BackColor = System.Drawing.Color.White
        Me.PanelTotal.Controls.Add(Me.lblTotalValue)
        Me.PanelTotal.Controls.Add(Me.lblTotalTitle)
        Me.PanelTotal.Location = New System.Drawing.Point(0, 0)
        Me.PanelTotal.Name = "PanelTotal"
        Me.PanelTotal.Size = New System.Drawing.Size(280, 180)
        Me.PanelTotal.TabIndex = 0
        '
        'lblTotalValue
        '
        Me.lblTotalValue.AutoSize = True
        Me.lblTotalValue.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblTotalValue.Location = New System.Drawing.Point(110, 60)
        Me.lblTotalValue.Name = "lblTotalValue"
        Me.lblTotalValue.Size = New System.Drawing.Size(91, 106)
        Me.lblTotalValue.TabIndex = 1
        Me.lblTotalValue.Text = "0"
        '
        'lblTotalTitle
        '
        Me.lblTotalTitle.AutoSize = True
        Me.lblTotalTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTotalTitle.Location = New System.Drawing.Point(40, 20)
        Me.lblTotalTitle.Name = "lblTotalTitle"
        Me.lblTotalTitle.Size = New System.Drawing.Size(202, 32)
        Me.lblTotalTitle.TabIndex = 0
        Me.lblTotalTitle.Text = "TOTAL PATIENTS"
        '
        'PanelCharts
        '
        Me.PanelCharts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelCharts.BackColor = System.Drawing.Color.White
        Me.PanelCharts.Controls.Add(Me.lblAvgTimeValue)
        Me.PanelCharts.Controls.Add(Me.lblAvgTimeTitle)
        Me.PanelCharts.Controls.Add(Me.lblOtherTime)
        Me.PanelCharts.Controls.Add(Me.lblCheckupTime)
        Me.PanelCharts.Controls.Add(Me.lblPastaTime)
        Me.PanelCharts.Controls.Add(Me.lblOtherCount)
        Me.PanelCharts.Controls.Add(Me.lblCheckupCount)
        Me.PanelCharts.Controls.Add(Me.lblPastaCount)
        Me.PanelCharts.Controls.Add(Me.barOther)
        Me.PanelCharts.Controls.Add(Me.barCheckup)
        Me.PanelCharts.Controls.Add(Me.barPasta)
        Me.PanelCharts.Controls.Add(Me.lblOtherTitle)
        Me.PanelCharts.Controls.Add(Me.lblCheckupTitle)
        Me.PanelCharts.Controls.Add(Me.lblPastaTitle)
        Me.PanelCharts.Location = New System.Drawing.Point(30, 340)
        Me.PanelCharts.Name = "PanelCharts"
        Me.PanelCharts.Size = New System.Drawing.Size(1140, 320)
        Me.PanelCharts.TabIndex = 2
        '
        'lblAvgTimeValue
        '
        Me.lblAvgTimeValue.AutoSize = True
        Me.lblAvgTimeValue.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblAvgTimeValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblAvgTimeValue.Location = New System.Drawing.Point(947, 189)
        Me.lblAvgTimeValue.Name = "lblAvgTimeValue"
        Me.lblAvgTimeValue.Size = New System.Drawing.Size(129, 54)
        Me.lblAvgTimeValue.TabIndex = 13
        Me.lblAvgTimeValue.Text = "0 min"
        '
        'lblAvgTimeTitle
        '
        Me.lblAvgTimeTitle.AutoSize = True
        Me.lblAvgTimeTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAvgTimeTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblAvgTimeTitle.Location = New System.Drawing.Point(907, 142)
        Me.lblAvgTimeTitle.Name = "lblAvgTimeTitle"
        Me.lblAvgTimeTitle.Size = New System.Drawing.Size(216, 28)
        Me.lblAvgTimeTitle.TabIndex = 12
        Me.lblAvgTimeTitle.Text = "Average Consultation"
        '
        'lblOtherTime
        '
        Me.lblOtherTime.AutoSize = True
        Me.lblOtherTime.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblOtherTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblOtherTime.Location = New System.Drawing.Point(770, 260)
        Me.lblOtherTime.Name = "lblOtherTime"
        Me.lblOtherTime.Size = New System.Drawing.Size(98, 23)
        Me.lblOtherTime.TabIndex = 11
        Me.lblOtherTime.Text = "Avg: 0 min"
        '
        'lblCheckupTime
        '
        Me.lblCheckupTime.AutoSize = True
        Me.lblCheckupTime.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckupTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblCheckupTime.Location = New System.Drawing.Point(510, 260)
        Me.lblCheckupTime.Name = "lblCheckupTime"
        Me.lblCheckupTime.Size = New System.Drawing.Size(98, 23)
        Me.lblCheckupTime.TabIndex = 10
        Me.lblCheckupTime.Text = "Avg: 0 min"
        '
        'lblPastaTime
        '
        Me.lblPastaTime.AutoSize = True
        Me.lblPastaTime.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPastaTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblPastaTime.Location = New System.Drawing.Point(250, 260)
        Me.lblPastaTime.Name = "lblPastaTime"
        Me.lblPastaTime.Size = New System.Drawing.Size(98, 23)
        Me.lblPastaTime.TabIndex = 9
        Me.lblPastaTime.Text = "Avg: 0 min"
        '
        'lblOtherCount
        '
        Me.lblOtherCount.AutoSize = True
        Me.lblOtherCount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblOtherCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblOtherCount.Location = New System.Drawing.Point(770, 170)
        Me.lblOtherCount.Name = "lblOtherCount"
        Me.lblOtherCount.Size = New System.Drawing.Size(46, 54)
        Me.lblOtherCount.TabIndex = 8
        Me.lblOtherCount.Text = "0"
        '
        'lblCheckupCount
        '
        Me.lblCheckupCount.AutoSize = True
        Me.lblCheckupCount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckupCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblCheckupCount.Location = New System.Drawing.Point(510, 170)
        Me.lblCheckupCount.Name = "lblCheckupCount"
        Me.lblCheckupCount.Size = New System.Drawing.Size(46, 54)
        Me.lblCheckupCount.TabIndex = 7
        Me.lblCheckupCount.Text = "0"
        '
        'lblPastaCount
        '
        Me.lblPastaCount.AutoSize = True
        Me.lblPastaCount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblPastaCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblPastaCount.Location = New System.Drawing.Point(250, 170)
        Me.lblPastaCount.Name = "lblPastaCount"
        Me.lblPastaCount.Size = New System.Drawing.Size(46, 54)
        Me.lblPastaCount.TabIndex = 6
        Me.lblPastaCount.Text = "0"
        '
        'barOther
        '
        Me.barOther.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.barOther.Location = New System.Drawing.Point(770, 50)
        Me.barOther.Name = "barOther"
        Me.barOther.Size = New System.Drawing.Size(70, 120)
        Me.barOther.TabIndex = 5
        '
        'barCheckup
        '
        Me.barCheckup.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.barCheckup.Location = New System.Drawing.Point(510, 50)
        Me.barCheckup.Name = "barCheckup"
        Me.barCheckup.Size = New System.Drawing.Size(70, 120)
        Me.barCheckup.TabIndex = 4
        '
        'barPasta
        '
        Me.barPasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.barPasta.Location = New System.Drawing.Point(250, 50)
        Me.barPasta.Name = "barPasta"
        Me.barPasta.Size = New System.Drawing.Size(70, 120)
        Me.barPasta.TabIndex = 3
        '
        'lblOtherTitle
        '
        Me.lblOtherTitle.AutoSize = True
        Me.lblOtherTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblOtherTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblOtherTitle.Location = New System.Drawing.Point(770, 10)
        Me.lblOtherTitle.Name = "lblOtherTitle"
        Me.lblOtherTitle.Size = New System.Drawing.Size(78, 32)
        Me.lblOtherTitle.TabIndex = 2
        Me.lblOtherTitle.Text = "Other"
        '
        'lblCheckupTitle
        '
        Me.lblCheckupTitle.AutoSize = True
        Me.lblCheckupTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckupTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblCheckupTitle.Location = New System.Drawing.Point(490, 10)
        Me.lblCheckupTitle.Name = "lblCheckupTitle"
        Me.lblCheckupTitle.Size = New System.Drawing.Size(120, 32)
        Me.lblCheckupTitle.TabIndex = 1
        Me.lblCheckupTitle.Text = "Check-up"
        '
        'lblPastaTitle
        '
        Me.lblPastaTitle.AutoSize = True
        Me.lblPastaTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPastaTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblPastaTitle.Location = New System.Drawing.Point(250, 10)
        Me.lblPastaTitle.Name = "lblPastaTitle"
        Me.lblPastaTitle.Size = New System.Drawing.Size(74, 32)
        Me.lblPastaTitle.TabIndex = 0
        Me.lblPastaTitle.Text = "Pasta"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblWelcome)
        Me.Panel1.Location = New System.Drawing.Point(30, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1140, 100)
        Me.Panel1.TabIndex = 3
        '
        'UC_DASHBOARD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Name = "UC_DASHBOARD"
        Me.Size = New System.Drawing.Size(1200, 700)
        Me.PanelMain.ResumeLayout(False)
        Me.PanelStats.ResumeLayout(False)
        Me.PanelDone.ResumeLayout(False)
        Me.PanelDone.PerformLayout()
        Me.PanelServing.ResumeLayout(False)
        Me.PanelServing.PerformLayout()
        Me.PanelWaiting.ResumeLayout(False)
        Me.PanelWaiting.PerformLayout()
        Me.PanelTotal.ResumeLayout(False)
        Me.PanelTotal.PerformLayout()
        Me.PanelCharts.ResumeLayout(False)
        Me.PanelCharts.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelMain As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents PanelStats As Panel
    Friend WithEvents PanelTotal As Panel
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents lblTotalTitle As Label
    Friend WithEvents PanelWaiting As Panel
    Friend WithEvents lblWaitingValue As Label
    Friend WithEvents lblWaitingTitle As Label
    Friend WithEvents PanelServing As Panel
    Friend WithEvents lblServingValue As Label
    Friend WithEvents lblServingTitle As Label
    Friend WithEvents PanelDone As Panel
    Friend WithEvents lblDoneValue As Label
    Friend WithEvents lblDoneTitle As Label
    Friend WithEvents PanelCharts As Panel
    Friend WithEvents lblPastaTitle As Label
    Friend WithEvents lblCheckupTitle As Label
    Friend WithEvents lblOtherTitle As Label
    Friend WithEvents barPasta As Panel
    Friend WithEvents barCheckup As Panel
    Friend WithEvents barOther As Panel
    Friend WithEvents lblPastaCount As Label
    Friend WithEvents lblCheckupCount As Label
    Friend WithEvents lblOtherCount As Label
    Friend WithEvents lblPastaTime As Label
    Friend WithEvents lblCheckupTime As Label
    Friend WithEvents lblOtherTime As Label
    Friend WithEvents lblAvgTimeValue As Label
    Friend WithEvents lblAvgTimeTitle As Label
    Friend WithEvents Panel1 As Panel
End Class