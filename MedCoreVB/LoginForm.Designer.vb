<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.usertxt = New System.Windows.Forms.TextBox()
        Me.pwtxt = New System.Windows.Forms.TextBox()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.btnLogin)
        Me.panel1.Controls.Add(Me.usertxt)
        Me.panel1.Controls.Add(Me.pwtxt)
        Me.panel1.Location = New System.Drawing.Point(103, 51)
        Me.panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1059, 578)
        Me.panel1.TabIndex = 5
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Magneto", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(297, 67)
        Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(521, 117)
        Me.label1.TabIndex = 0
        Me.label1.Text = "MedCore"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnLogin.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(439, 363)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(176, 35)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Log In"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'usertxt
        '
        Me.usertxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.usertxt.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usertxt.Location = New System.Drawing.Point(369, 287)
        Me.usertxt.Margin = New System.Windows.Forms.Padding(2)
        Me.usertxt.Name = "usertxt"
        Me.usertxt.Size = New System.Drawing.Size(330, 30)
        Me.usertxt.TabIndex = 1
        Me.usertxt.Text = "Username"
        '
        'pwtxt
        '
        Me.pwtxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pwtxt.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pwtxt.Location = New System.Drawing.Point(369, 321)
        Me.pwtxt.Margin = New System.Windows.Forms.Padding(2)
        Me.pwtxt.Name = "pwtxt"
        Me.pwtxt.Size = New System.Drawing.Size(330, 30)
        Me.pwtxt.TabIndex = 2
        Me.pwtxt.Text = "Password"
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoginForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panel1 As Panel
    Private WithEvents label1 As Label
    Private WithEvents btnLogin As Button
    Private WithEvents usertxt As TextBox
    Private WithEvents pwtxt As TextBox
End Class
