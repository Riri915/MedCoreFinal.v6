Imports System.Drawing
Imports System.Windows.Forms
Imports CoreLibrary
Imports MedCoreC_
Imports MySql.Data.MySqlClient

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

        If username = "" OrElse password = "" OrElse username = "Username" OrElse password = "Password" Then
            MessageBox.Show("Please enter username and password.")
            Return
        End If

        If Not DatabaseInitializer.DatabaseSuccess Then
            MessageBox.Show("Database not initialized yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim dbAccountType As String = ""
        If AuthHelper.LoginUser(username, password, dbAccountType) Then

            ' Fetch user details from DB
            Using conn As New MySqlConnection("server=localhost;userid=root;password=;database=medcore")
                conn.Open()
                Dim query As String = "SELECT employee_id, first_name, last_name, account_type FROM users WHERE username=@user LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@user", username)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Session.EmployeeID = reader("employee_id").ToString()
                            Session.Username = username
                            Session.FirstName = reader("first_name").ToString()
                            Session.LastName = reader("last_name").ToString()
                            Session.AccountType = reader("account_type").ToString()
                            Session.Position = reader("account_type").ToString()
                        End If
                    End Using
                End Using
                Dim fullName As String = Session.FirstName & " " & Session.LastName
                ActivityLogger.Log(conn, Session.EmployeeID, fullName, "Logged in")
            End Using

            ResetFields()
            usertxt.Focus()

            Dim role As String = Session.AccountType.Trim().ToLower()

            Select Case role
                Case "admin"
                    Dim cmsForm As New CMS()
                    AddHandler cmsForm.FormClosed, Sub() Me.Show()
                    cmsForm.Show()
                    Me.Hide()

                Case "cashier"
                    Dim cashierForm As New CashierPanel()
                    AddHandler cashierForm.FormClosed, Sub() Me.Show()
                    cashierForm.Show()
                    Me.Hide()

                Case Else
                    MessageBox.Show($"Access role '{Session.AccountType}' not supported.", "Access Denied")
            End Select

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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class