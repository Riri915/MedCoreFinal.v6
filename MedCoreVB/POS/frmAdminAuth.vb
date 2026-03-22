Imports MySql.Data.MySqlClient
Imports BCrypt.Net

Public Class frmAdminAuth

    Public CashierRef As CashierPanel
    Public Property IsAuthenticated As Boolean = False

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim conn As New MySqlConnection("server=localhost;user=root;password=;database=medcore")

        ' ONLY GET HASH
        Dim cmd As New MySqlCommand("SELECT password_hash FROM users WHERE account_type='Admin' LIMIT 1", conn)

        Try
            conn.Open()
            Dim reader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim storedHash As String = reader("password_hash").ToString()

                ' VERIFY HASH HERE
                If BCrypt.Net.BCrypt.Verify(txtPassword.Text, storedHash) Then
                    IsAuthenticated = True
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Incorrect admin password.")
                    txtPassword.Clear()
                End If
            Else
                MessageBox.Show("No admin account found.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        txtPassword.Clear()
        Me.Close()
    End Sub

    Private Sub frmAdminAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnConfirm
    End Sub

End Class