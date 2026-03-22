<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReturnPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTransactionID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirmReturn = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.cmbCondition = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCashierName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRefund = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(709, 62)
        Me.Panel1.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Return Item"
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.White
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(28, 319)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(279, 30)
        Me.txtQuantity.TabIndex = 82
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 294)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(186, 22)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Quantity to Returned :"
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.Color.White
        Me.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(28, 247)
        Me.txtProductName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(279, 30)
        Me.txtProductName.TabIndex = 80
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 22)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Product Name :"
        '
        'txtProductID
        '
        Me.txtProductID.BackColor = System.Drawing.Color.White
        Me.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductID.Location = New System.Drawing.Point(28, 175)
        Me.txtProductID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(279, 30)
        Me.txtProductID.TabIndex = 78
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 22)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Product ID :"
        '
        'txtTransactionID
        '
        Me.txtTransactionID.BackColor = System.Drawing.Color.White
        Me.txtTransactionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransactionID.Location = New System.Drawing.Point(28, 108)
        Me.txtTransactionID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTransactionID.Name = "txtTransactionID"
        Me.txtTransactionID.Size = New System.Drawing.Size(279, 30)
        Me.txtTransactionID.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 22)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Transaction ID :"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.IndianRed
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnCancel.Location = New System.Drawing.Point(329, 489)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 39)
        Me.btnCancel.TabIndex = 74
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnConfirmReturn
        '
        Me.btnConfirmReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmReturn.BackColor = System.Drawing.Color.Lime
        Me.btnConfirmReturn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnConfirmReturn.Location = New System.Drawing.Point(545, 489)
        Me.btnConfirmReturn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnConfirmReturn.Name = "btnConfirmReturn"
        Me.btnConfirmReturn.Size = New System.Drawing.Size(101, 39)
        Me.btnConfirmReturn.TabIndex = 73
        Me.btnConfirmReturn.Text = "Confirm"
        Me.btnConfirmReturn.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 364)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 22)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Condition"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClear.Location = New System.Drawing.Point(437, 489)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(101, 39)
        Me.btnClear.TabIndex = 90
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'cmbCondition
        '
        Me.cmbCondition.BackColor = System.Drawing.Color.White
        Me.cmbCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCondition.ForeColor = System.Drawing.Color.LightGray
        Me.cmbCondition.FormattingEnabled = True
        Me.cmbCondition.Items.AddRange(New Object() {"Good Condition", "Damaged", "Expired", "Wrong Item Delivered"})
        Me.cmbCondition.Location = New System.Drawing.Point(28, 390)
        Me.cmbCondition.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbCondition.Name = "cmbCondition"
        Me.cmbCondition.Size = New System.Drawing.Size(279, 33)
        Me.cmbCondition.TabIndex = 91
        Me.cmbCondition.Text = "(Select options...)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(341, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 22)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Refund Amount :"
        '
        'txtCashierName
        '
        Me.txtCashierName.BackColor = System.Drawing.Color.White
        Me.txtCashierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCashierName.Enabled = False
        Me.txtCashierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashierName.Location = New System.Drawing.Point(345, 107)
        Me.txtCashierName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCashierName.Name = "txtCashierName"
        Me.txtCashierName.Size = New System.Drawing.Size(279, 30)
        Me.txtCashierName.TabIndex = 88
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(341, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 22)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Cashier :"
        '
        'txtRefund
        '
        Me.txtRefund.BackColor = System.Drawing.Color.White
        Me.txtRefund.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefund.Enabled = False
        Me.txtRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefund.Location = New System.Drawing.Point(345, 181)
        Me.txtRefund.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtRefund.Name = "txtRefund"
        Me.txtRefund.Size = New System.Drawing.Size(279, 30)
        Me.txtRefund.TabIndex = 84
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(341, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 22)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Reason for return :"
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.Color.White
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Location = New System.Drawing.Point(345, 249)
        Me.txtReason.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(279, 175)
        Me.txtReason.TabIndex = 93
        Me.txtReason.Text = ""
        '
        'ReturnPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 556)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbCondition)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtCashierName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtRefund)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtProductID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTransactionID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirmReturn)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ReturnPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReturnPage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTransactionID As TextBox
    Friend WithEvents Label2 As Label
    Private WithEvents btnCancel As Button
    Private WithEvents btnConfirmReturn As Button
    Friend WithEvents Label8 As Label
    Private WithEvents btnClear As Button
    Friend WithEvents cmbCondition As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCashierName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRefund As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReason As RichTextBox
End Class
