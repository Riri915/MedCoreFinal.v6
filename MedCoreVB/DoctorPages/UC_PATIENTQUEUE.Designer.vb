<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_PATIENTQUEUE
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
        Me.dgvQueue = New System.Windows.Forms.DataGridView()
        Me.ColID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCONCERN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSTATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblPatientCount = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        CType(Me.dgvQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvQueue
        '
        Me.dgvQueue.AllowUserToAddRows = False
        Me.dgvQueue.AllowUserToDeleteRows = False
        Me.dgvQueue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvQueue.BackgroundColor = System.Drawing.Color.White
        Me.dgvQueue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvQueue.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvQueue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvQueue.ColumnHeadersHeight = 60
        Me.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvQueue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColID, Me.ColNAME, Me.ColCONCERN, Me.ColSTATUS})
        Me.dgvQueue.EnableHeadersVisualStyles = False
        Me.dgvQueue.GridColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.dgvQueue.Location = New System.Drawing.Point(0, 100)
        Me.dgvQueue.Name = "dgvQueue"
        Me.dgvQueue.ReadOnly = True
        Me.dgvQueue.RowHeadersVisible = False
        Me.dgvQueue.RowHeadersWidth = 51
        Me.dgvQueue.RowTemplate.Height = 60
        Me.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQueue.Size = New System.Drawing.Size(1200, 600)
        Me.dgvQueue.TabIndex = 20
        '
        'ColID
        '
        Me.ColID.HeaderText = "QUEUE NO."
        Me.ColID.MinimumWidth = 6
        Me.ColID.Name = "ColID"
        Me.ColID.ReadOnly = True
        '
        'ColNAME
        '
        Me.ColNAME.HeaderText = "PATIENT NAME"
        Me.ColNAME.MinimumWidth = 6
        Me.ColNAME.Name = "ColNAME"
        Me.ColNAME.ReadOnly = True
        '
        'ColCONCERN
        '
        Me.ColCONCERN.HeaderText = "SERVICE TYPE"
        Me.ColCONCERN.MinimumWidth = 6
        Me.ColCONCERN.Name = "ColCONCERN"
        Me.ColCONCERN.ReadOnly = True
        '
        'ColSTATUS
        '
        Me.ColSTATUS.HeaderText = "STATUS"
        Me.ColSTATUS.MinimumWidth = 6
        Me.ColSTATUS.Name = "ColSTATUS"
        Me.ColSTATUS.ReadOnly = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(30, 25)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(325, 54)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "PATIENT QUEUE"
        '
        'lblPatientCount
        '
        Me.lblPatientCount.AutoSize = True
        Me.lblPatientCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblPatientCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblPatientCount.Location = New System.Drawing.Point(950, 35)
        Me.lblPatientCount.Name = "lblPatientCount"
        Me.lblPatientCount.Size = New System.Drawing.Size(165, 41)
        Me.lblPatientCount.TabIndex = 22
        Me.lblPatientCount.Text = "Waiting: 0"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblPatientCount)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1200, 100)
        Me.pnlHeader.TabIndex = 23
        '
        'UC_PATIENTQUEUE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.dgvQueue)
        Me.Name = "UC_PATIENTQUEUE"
        Me.Size = New System.Drawing.Size(1200, 700)
        CType(Me.dgvQueue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvQueue As DataGridView
    Friend WithEvents ColID As DataGridViewTextBoxColumn
    Friend WithEvents ColNAME As DataGridViewTextBoxColumn
    Friend WithEvents ColCONCERN As DataGridViewTextBoxColumn
    Friend WithEvents ColSTATUS As DataGridViewTextBoxColumn
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblPatientCount As Label
    Friend WithEvents pnlHeader As Panel
End Class