<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiscountInfo
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
        Me.cmbDiscountType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtMiddleInital = New System.Windows.Forms.Label()
        Me.txtMiddleInitial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnApplyDiscount = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbDiscountType
        '
        Me.cmbDiscountType.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiscountType.FormattingEnabled = True
        Me.cmbDiscountType.Items.AddRange(New Object() {"PWD", "Senior Citizen"})
        Me.cmbDiscountType.Location = New System.Drawing.Point(32, 53)
        Me.cmbDiscountType.Name = "cmbDiscountType"
        Me.cmbDiscountType.Size = New System.Drawing.Size(163, 37)
        Me.cmbDiscountType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "First Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(32, 125)
        Me.txtFirstName.Multiline = True
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(210, 36)
        Me.txtFirstName.TabIndex = 2
        '
        'txtMiddleInital
        '
        Me.txtMiddleInital.AutoSize = True
        Me.txtMiddleInital.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleInital.Location = New System.Drawing.Point(430, 93)
        Me.txtMiddleInital.Name = "txtMiddleInital"
        Me.txtMiddleInital.Size = New System.Drawing.Size(155, 29)
        Me.txtMiddleInital.TabIndex = 3
        Me.txtMiddleInital.Text = "Middle Initial:"
        '
        'txtMiddleInitial
        '
        Me.txtMiddleInitial.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleInitial.Location = New System.Drawing.Point(479, 125)
        Me.txtMiddleInitial.Multiline = True
        Me.txtMiddleInitial.Name = "txtMiddleInitial"
        Me.txtMiddleInitial.Size = New System.Drawing.Size(53, 36)
        Me.txtMiddleInitial.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(257, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 29)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Last Name:"
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(262, 125)
        Me.txtLastName.Multiline = True
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(172, 36)
        Me.txtLastName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 29)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ID Number:"
        '
        'txtIDNumber
        '
        Me.txtIDNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNumber.Location = New System.Drawing.Point(32, 205)
        Me.txtIDNumber.Multiline = True
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(281, 41)
        Me.txtIDNumber.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.IndianRed
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(360, 32)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "DISCOUNT VERIFICATION"
        '
        'btnApplyDiscount
        '
        Me.btnApplyDiscount.BackColor = System.Drawing.Color.LimeGreen
        Me.btnApplyDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyDiscount.Location = New System.Drawing.Point(83, 271)
        Me.btnApplyDiscount.Name = "btnApplyDiscount"
        Me.btnApplyDiscount.Size = New System.Drawing.Size(210, 50)
        Me.btnApplyDiscount.TabIndex = 10
        Me.btnApplyDiscount.Text = "Apply Discount"
        Me.btnApplyDiscount.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(341, 273)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(190, 47)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(101, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(414, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "============================================="
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(101, 323)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(414, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "============================================="
        '
        'frmDiscountInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 355)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApplyDiscount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIDNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMiddleInitial)
        Me.Controls.Add(Me.txtMiddleInital)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbDiscountType)
        Me.MaximumSize = New System.Drawing.Size(617, 402)
        Me.MinimumSize = New System.Drawing.Size(617, 402)
        Me.Name = "frmDiscountInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDiscountInfo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbDiscountType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtMiddleInital As Label
    Friend WithEvents txtMiddleInitial As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIDNumber As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnApplyDiscount As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
End Class
