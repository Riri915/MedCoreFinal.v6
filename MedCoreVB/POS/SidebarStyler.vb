Imports System.Drawing.Drawing2D

Public Class SidebarStyler
    Private Shared activeButton As Button = Nothing

    Public Shared Sub ApplyStyle(sidebar As Panel)
        AddHandler sidebar.Paint, Sub(sender, e)
                                      Dim rect As Rectangle = sidebar.ClientRectangle
                                      Using brush As New LinearGradientBrush(rect,
                                            Color.FromArgb(40, 80, 200),
                                            Color.FromArgb(100, 170, 255),
                                            LinearGradientMode.Vertical)
                                          e.Graphics.FillRectangle(brush, rect)
                                      End Using
                                  End Sub

        For Each ctrl As Control In sidebar.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.BackColor = Color.Transparent
                btn.ForeColor = Color.White
                btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                btn.Cursor = Cursors.Hand
                btn.TextAlign = ContentAlignment.MiddleLeft
                btn.Padding = New Padding(15, 0, 0, 0)
                btn.Margin = New Padding(0, 5, 0, 5)

                AddHandler btn.Paint, AddressOf Button_Paint
                AddHandler btn.MouseEnter, AddressOf Button_MouseEnter
                AddHandler btn.MouseLeave, AddressOf Button_MouseLeave
            End If
        Next
    End Sub

    Public Shared Sub SetActiveButton(btn As Button)
        activeButton = btn
        btn.Invalidate()
    End Sub

    Private Shared Sub Button_Paint(sender As Object, e As PaintEventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim rect As Rectangle = btn.ClientRectangle
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim isActive As Boolean = (btn Is activeButton)
        Dim isHovered As Boolean = btn.Tag IsNot Nothing AndAlso btn.Tag.ToString() = "hover"

        Dim radius As Integer = 6
        Dim path As New GraphicsPath()
        path.AddArc(rect.X + 1, rect.Y + 1, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius - 1, rect.Y + 1, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius - 1, rect.Bottom - radius - 1, radius, radius, 0, 90)
        path.AddArc(rect.X + 1, rect.Bottom - radius - 1, radius, radius, 90, 90)
        path.CloseFigure()

        If isActive Then
            Using pen As New Pen(Color.FromArgb(230, 180, 255, 255), 3)
                g.DrawPath(pen, path)
            End Using
        ElseIf isHovered Then
            Using pen As New Pen(Color.FromArgb(20, 255, 255, 255), 2)
                g.DrawPath(pen, path)
            End Using
        End If

        btn.ForeColor = Color.White
    End Sub

    Private Shared Sub Button_MouseEnter(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        btn.Tag = "hover"
        btn.Invalidate()
    End Sub

    Private Shared Sub Button_MouseLeave(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        btn.Tag = Nothing
        btn.Invalidate()
    End Sub
End Class
