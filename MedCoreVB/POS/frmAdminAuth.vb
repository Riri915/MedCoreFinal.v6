Imports MySql.Data.MySqlClient

Public Class frmAdminAuth
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim conn As New MySqlConnection("server=localhost;user=root;password=;database=medcore")
        Dim cmd As New MySqlCommand("SELECT * FROM employees WHERE position='Admin' AND password=@pass", conn)
        cmd.Parameters.AddWithValue("@pass", txtPassword.Text)

        Try
            conn.Open()
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Incorrect admin password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAdminAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnConfirm
    End Sub
End Class
