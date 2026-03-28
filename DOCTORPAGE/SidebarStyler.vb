Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class StyledSidebar
    Inherits Panel

    Private activeButton As Button = Nothing

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Width = 220
        Me.Dock = DockStyle.Left
    End Sub

    ' 🎨 Gradient Background
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim brush As New LinearGradientBrush(
            Me.ClientRectangle,
            Color.FromArgb(45, 95, 200),
            Color.FromArgb(100, 160, 255),
            LinearGradientMode.Vertical)

        e.Graphics.FillRectangle(brush, Me.ClientRectangle)
    End Sub

    ' ➕ Add Styled Button
    Public Function AddButton(text As String) As Button
        Dim btn As New Button()

        btn.Text = text
        btn.Height = 45
        btn.Dock = DockStyle.Top
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.ForeColor = Color.White
        btn.BackColor = Color.Transparent
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Padding = New Padding(15, 0, 0, 0)
        btn.Cursor = Cursors.Hand

        ' Hover effect
        AddHandler btn.MouseEnter, AddressOf OnHover
        AddHandler btn.MouseLeave, AddressOf OnLeave
        AddHandler btn.Click, AddressOf OnClick

        Me.Controls.Add(btn)
        Me.Controls.SetChildIndex(btn, 0)

        RoundButton(btn)

        Return btn
    End Function

    ' ✨ Hover
    Private Sub OnHover(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Button)
        If btn IsNot activeButton Then
            btn.BackColor = Color.FromArgb(255, 255, 255, 40)
        End If
    End Sub

    Private Sub OnLeave(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Button)
        If btn IsNot activeButton Then
            btn.BackColor = Color.Transparent
        End If
    End Sub

    ' 🎯 Active Click
    Private Sub OnClick(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Button)

        If activeButton IsNot Nothing Then
            activeButton.BackColor = Color.Transparent
        End If

        activeButton = btn
        btn.BackColor = Color.FromArgb(255, 255, 255, 80)
    End Sub

    ' 🔘 Rounded Button
    Private Sub RoundButton(btn As Button)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        path.AddArc(New Rectangle(btn.Width - 20, 0, 20, 20), -90, 90)
        path.AddArc(New Rectangle(btn.Width - 20, btn.Height - 20, 20, 20), 0, 90)
        path.AddArc(New Rectangle(0, btn.Height - 20, 20, 20), 90, 90)
        path.CloseFigure()

        btn.Region = New Region(path)
    End Sub

End Class