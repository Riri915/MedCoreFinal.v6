Imports MySql.Data.MySqlClient

Public Class ReturnAuthorizationForm

    Private connStr As String = "server=localhost;userid=root;password=;database=POS"

    Public Property ReturnParent As ReturnPage

    Private Sub btnAuthorize_Click(sender As Object, e As EventArgs) Handles btnAuthorize.Click
        Dim adminPassword As String = txtAdminPassword.Text.Trim()

        If adminPassword = "" Then
            MessageBox.Show("Please enter the administrator password.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim query As String = "SELECT * FROM employees WHERE Position='Admin' AND Password=@pass LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@pass", adminPassword)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            MessageBox.Show("Authorization granted. Proceeding with return.", "Authorized", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                            ReturnParent.ProcessReturn()
                        Else
                            MessageBox.Show("Invalid administrator password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnAuthorizationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrostedPanelStyler.ApplyGradient(Me.Panel1)
        InfoPanelStyler.MakeLabelTransparent(lblAuthTitle, Panel1)
    End Sub
End Class