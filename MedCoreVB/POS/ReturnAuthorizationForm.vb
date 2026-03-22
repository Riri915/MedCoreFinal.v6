Imports MySql.Data.MySqlClient
Imports BCrypt.Net

Public Class ReturnAuthorizationForm

    Private connStr As String = "server=localhost;userid=root;password=;database=medcore"
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

                Dim query As String = "SELECT password_hash FROM users WHERE account_type='Admin' LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        If reader.Read() Then
                            Dim storedHash As String = reader("password_hash").ToString()

                            If BCrypt.Net.BCrypt.Verify(adminPassword, storedHash) Then
                                MessageBox.Show("Authorization granted. Proceeding with return.", "Authorized", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Me.Close()

                                If ReturnParent IsNot Nothing Then
                                    ReturnParent.ProcessReturn()
                                End If
                            Else
                                MessageBox.Show("Invalid administrator password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("No admin account found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ ADD THIS (Cancel button)
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ReturnAuthorizationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrostedPanelStyler.ApplyGradient(Me.Panel1)
        InfoPanelStyler.MakeLabelTransparent(lblAuthTitle, Panel1)
    End Sub

End Class