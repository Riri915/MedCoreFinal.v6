Imports CoreLibrary
Imports MedCoreC_
Imports System.Drawing
Imports System.Windows.Forms

Public Class LoginForm

    Public Sub New()
        InitializeComponent()

        btnLogin.Select()

        usertxt.Text = "Username"
        usertxt.ForeColor = Color.Gray

        pwtxt.Text = "Password"
        pwtxt.ForeColor = Color.Gray
        pwtxt.UseSystemPasswordChar = False
    End Sub

    Private Sub loginPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DatabaseInitializer.InitializeTABLE()
        Me.AcceptButton = btnLogin
    End Sub

    Private Sub usertxt_Enter(sender As Object, e As EventArgs) Handles usertxt.Enter
        If usertxt.Text = "Username" Then
            usertxt.Text = ""
            usertxt.ForeColor = Color.Black
        End If
    End Sub

    Private Sub usertxt_Leave(sender As Object, e As EventArgs) Handles usertxt.Leave
        If String.IsNullOrWhiteSpace(usertxt.Text) Then
            usertxt.Text = "Username"
            usertxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub pwtxt_Enter(sender As Object, e As EventArgs) Handles pwtxt.Enter
        If pwtxt.Text = "Password" Then
            pwtxt.Text = ""
            pwtxt.ForeColor = Color.Black
            pwtxt.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub pwtxt_Leave(sender As Object, e As EventArgs) Handles pwtxt.Leave
        If String.IsNullOrWhiteSpace(pwtxt.Text) Then
            pwtxt.UseSystemPasswordChar = False
            pwtxt.Text = "Password"
            pwtxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim username As String = usertxt.Text.Trim()
        Dim password As String = pwtxt.Text
        Dim account_type As String = ""

        If username = "" OrElse password = "" OrElse username = "Username" OrElse password = "Password" Then
            MessageBox.Show("Please enter username and password.")
            Return
        End If

        If Not DatabaseInitializer.DatabaseSuccess Then
            MessageBox.Show("Database not initialized yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If AuthHelper.LoginUser(username, password, account_type) Then

            ResetFields()

            usertxt.Focus()

            If account_type.Equals("Admin", StringComparison.OrdinalIgnoreCase) Then
                Dim cmsForm As New CMS()
                AddHandler cmsForm.FormClosed, Sub() Me.Show()
                cmsForm.Show()
                Me.Hide()

            ElseIf account_type.Equals("Cashier", StringComparison.OrdinalIgnoreCase) Then
                Dim cashier As New CashierPanel()
                AddHandler cashier.FormClosed, Sub() Me.Show()
                cashier.Show()
                Me.Hide()

            Else
                MessageBox.Show("Access role not supported.", "Access Denied")
            End If

        Else
            MessageBox.Show("Invalid username or password.", "Login Failed")

            ResetFields()
        End If

    End Sub
    Private Sub ResetFields()
        usertxt.Text = "Username"
        usertxt.ForeColor = Color.Gray

        pwtxt.UseSystemPasswordChar = False
        pwtxt.Text = "Password"
        pwtxt.ForeColor = Color.Gray
    End Sub

End Class