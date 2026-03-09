Imports System.Drawing.Drawing2D
Public Class PatientConsultvb
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DoctorsWCPage.dgvQueue.Rows.Count > 0 Then

            TextBox1.Text = DoctorsWCPage.dgvQueue.Rows(0).Cells(1).Value.ToString()
            TextBox2.Text = DoctorsWCPage.dgvQueue.Rows(0).Cells(2).Value.ToString()
            ComboBox1.Text = DoctorsWCPage.dgvQueue.Rows(0).Cells(3).Value.ToString()

        Else
            MessageBox.Show("No patient in queue")
        End If
    End Sub




    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim rect As Rectangle = Panel1.ClientRectangle
        rect.Width -= 1
        rect.Height -= 1

        Dim radius As Integer = 25

        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        Panel1.Region = New Region(path)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using pen As New Pen(Color.SteelBlue, 2)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DoctorsWCPage.dgvQueue.Rows.Count = 0 Then
            MessageBox.Show("No patient in queue.")
            Exit Sub
        End If

        Dim newStatus As String = ComboBox1.Text

        ' Update status
        DoctorsWCPage.dgvQueue.Rows(0).Cells(3).Value = newStatus

        ' If Done, remove and proceed to next
        If newStatus = "Done" Then
            DoctorsWCPage.dgvQueue.Rows.RemoveAt(0)
            MessageBox.Show("Patient finished. Proceeding to next.")
        Else
            MessageBox.Show("Status updated.")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DoctorsWCPage.Show()
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Dim g = e.Graphics
        Dim pen As New Pen(Color.DodgerBlue, 2)
        g.DrawRectangle(pen, 1, 1, Panel1.Width - 3, Panel1.Height - 3)
    End Sub
End Class