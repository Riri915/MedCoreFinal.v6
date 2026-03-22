Imports MySql.Data.MySqlClient

Public Class frmAdminAuth

    Public CashierRef As CashierPanel
    Public Property IsAuthenticated As Boolean = False
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        Dim conn As New MySqlConnection("server=localhost;user=root;password=;database=medcore")
        Dim cmd As New MySqlCommand("SELECT * FROM employees WHERE position='Admin' AND password=@pass", conn)
        cmd.Parameters.AddWithValue("@pass", txtPassword.Text)

        Try
            conn.Open()
            Dim reader = cmd.ExecuteReader()

            If reader.HasRows Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Incorrect admin password.")
                txtPassword.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

        txtPassword.Clear()
        Me.Close()
    End Sub

    Private Sub frmAdminAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnConfirm
    End Sub
End Class
