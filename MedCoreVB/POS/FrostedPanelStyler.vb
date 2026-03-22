Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class FrostedPanelStyler

    Public Shared Sub ApplyGradient(panel As Panel, Optional startColor As Color = Nothing, Optional endColor As Color = Nothing)
        If startColor = Nothing Then startColor = Color.FromArgb(0, 76, 170)
        If endColor = Nothing Then endColor = Color.FromArgb(222, 255, 255)

        RemoveHandler panel.Paint, AddressOf OnPanelPaint
        AddHandler panel.Paint, AddressOf OnPanelPaint

        panel.Tag = New GradientInfo With {
            .StartColor = startColor,
            .EndColor = endColor,
            .Radius = 20
        }

        panel.BackColor = Color.Transparent
        EnableDoubleBuffer(panel)

        AddHandler panel.Resize, Sub() panel.Invalidate()
        panel.Invalidate()
    End Sub

    Private Shared Sub OnPanelPaint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim rect As Rectangle = panel.ClientRectangle
        If rect.Width <= 0 OrElse rect.Height <= 0 Then Return

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic

        Dim info As GradientInfo = TryCast(panel.Tag, GradientInfo)
        If info Is Nothing Then Return
        Dim radius As Integer = info.Radius

        Using path As GraphicsPath = GetRoundedPath(New Rectangle(0, 0, rect.Width - 1, rect.Height - 1), radius)

            Using shadowBrush As New SolidBrush(Color.FromArgb(45, 0, 0, 0))
                Dim shadowMatrix As New Matrix()
                shadowMatrix.Translate(4, 4)
                e.Graphics.Transform = shadowMatrix
                e.Graphics.FillPath(shadowBrush, path)
                e.Graphics.ResetTransform()
            End Using

            Using brush As New LinearGradientBrush(rect, info.StartColor, info.EndColor, LinearGradientMode.ForwardDiagonal)
                e.Graphics.FillPath(brush, path)
            End Using

            Using borderPen As New Pen(Color.FromArgb(230, 255, 255, 255), 2)
                e.Graphics.DrawPath(borderPen, path)
            End Using
        End Using
    End Sub

    Private Shared Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Shared Sub EnableDoubleBuffer(ctrl As Control)
        ctrl.GetType().GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)?.SetValue(ctrl, True, Nothing)
    End Sub

    Private Class GradientInfo
        Public Property StartColor As Color
        Public Property EndColor As Color
        Public Property Radius As Integer
    End Class

End Class
