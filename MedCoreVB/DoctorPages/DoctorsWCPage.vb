Imports System.Drawing.Drawing2D

Public Class DoctorsWCPage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dgvQueue.Rows.Add(TextBox1.Text, TextBox2.Text, TextBox3.Text, ComboBox1.Text)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub dgvQueue_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQueue.CellContentClick
        If e.RowIndex >= 0 Then
            TextBox1.Text = dgvQueue.Rows(e.RowIndex).Cells(0).Value.ToString()
            TextBox2.Text = dgvQueue.Rows(e.RowIndex).Cells(1).Value.ToString()
            TextBox3.Text = dgvQueue.Rows(e.RowIndex).Cells(2).Value.ToString()
            ComboBox1.Text = dgvQueue.Rows(e.RowIndex).Cells(3).Value.ToString()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PatientConsultvb.Show()
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
        Using pen As New Pen(Color.Black, 2)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub
End Class
