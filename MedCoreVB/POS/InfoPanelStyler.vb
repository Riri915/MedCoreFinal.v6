Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class InfoPanelStyler

    Public Shared Sub ApplyGradient(panel As Panel, Optional startColor As Color = Nothing, Optional endColor As Color = Nothing)
        If startColor = Nothing Then startColor = Color.FromArgb(151, 181, 255)
        If endColor = Nothing Then endColor = Color.FromArgb(222, 255, 255)

        RemoveHandler panel.Paint, AddressOf OnPanelPaint
        AddHandler panel.Paint, AddressOf OnPanelPaint

        panel.Tag = New GradientInfo With {.StartColor = startColor, .EndColor = endColor, .Radius = 18}

        panel.BackColor = Color.Transparent

        EnableDoubleBuffer(panel)

        RemoveHandler panel.Resize, Nothing
        AddHandler panel.Resize, Sub() panel.Invalidate()

        EnableHoverEffect(panel, 18)

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
        Using mainPath As GraphicsPath = GetRoundedPath(rect, radius)

            Dim shadowInset As Integer = Math.Min(6, CInt(Math.Round(Math.Min(rect.Width, rect.Height) * 0.05)))
            If shadowInset > 0 Then
                Dim shadowRect As Rectangle = Rectangle.Inflate(rect, -shadowInset, -shadowInset)
                shadowRect.Offset(shadowInset \ 2, shadowInset \ 2)
                Using shadowPath As GraphicsPath = GetRoundedPath(shadowRect, Math.Max(4, radius - shadowInset))
                    Using shadowBrush As New PathGradientBrush(shadowPath)
                        shadowBrush.CenterColor = Color.FromArgb(60, Color.Black)
                        shadowBrush.SurroundColors = New Color() {Color.FromArgb(0, Color.Transparent)}
                        shadowBrush.FocusScales = New PointF(0.6F, 0.6F)
                        e.Graphics.FillPath(shadowBrush, shadowPath)
                    End Using
                End Using
            End If

            Using brush As New LinearGradientBrush(rect, info.StartColor, info.EndColor, LinearGradientMode.ForwardDiagonal)
                e.Graphics.FillPath(brush, mainPath)
            End Using

            Using borderPen As New Pen(Color.FromArgb(160, Color.White), 2)
                e.Graphics.DrawPath(borderPen, mainPath)
            End Using

            panel.Region = New Region(mainPath)
        End Using
    End Sub

    Private Shared Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = Math.Max(0, radius * 2)

        path.StartFigure()
        If d = 0 Then
            path.AddRectangle(rect)
        Else
            path.AddArc(rect.X, rect.Y, d, d, 180, 90)
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        End If
        path.CloseFigure()
        Return path
    End Function

    Private Shared Sub EnableDoubleBuffer(ctrl As Control)
        ctrl.GetType().GetProperty("DoubleBuffered",
            Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic
        )?.SetValue(ctrl, True, Nothing)
    End Sub

    Public Shared Sub EnableHoverEffect(panel As Panel, Optional hoverLighten As Integer = 20)
        RemoveHandler panel.MouseEnter, Nothing
        RemoveHandler panel.MouseLeave, Nothing

        AddHandler panel.MouseEnter,
            Sub()
                Dim info As GradientInfo = TryCast(panel.Tag, GradientInfo)
                If info IsNot Nothing Then
                    info.StartColor = LightenColor(info.StartColor, hoverLighten)
                    info.EndColor = LightenColor(info.EndColor, hoverLighten)
                    panel.Invalidate()
                End If
            End Sub

        AddHandler panel.MouseLeave,
            Sub()
                Dim info As GradientInfo = TryCast(panel.Tag, GradientInfo)
                If info IsNot Nothing Then
                    info.StartColor = DarkenColor(info.StartColor, hoverLighten)
                    info.EndColor = DarkenColor(info.EndColor, hoverLighten)
                    panel.Invalidate()
                End If
            End Sub
    End Sub

    Private Shared Function LightenColor(color As Color, amount As Integer) As Color
        Return Color.FromArgb(color.A,
                              Math.Min(255, color.R + amount),
                              Math.Min(255, color.G + amount),
                              Math.Min(255, color.B + amount))
    End Function

    Private Shared Function DarkenColor(color As Color, amount As Integer) As Color
        Return Color.FromArgb(color.A,
                              Math.Max(0, color.R - amount),
                              Math.Max(0, color.G - amount),
                              Math.Max(0, color.B - amount))
    End Function

    Public Shared Sub MakeLabelTransparent(lbl As Label, parentPanel As Panel)
        lbl.Parent = parentPanel
        lbl.BackColor = Color.Transparent
    End Sub

    Private Class GradientInfo
        Public Property StartColor As Color
        Public Property EndColor As Color
        Public Property Radius As Integer
    End Class

End Class
