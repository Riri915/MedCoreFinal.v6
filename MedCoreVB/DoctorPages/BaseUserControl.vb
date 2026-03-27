Imports System.Drawing
Imports System.Windows.Forms

Public Class BaseUserControl
    Inherits UserControl

    Private Sub BaseUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterControl()
    End Sub

    Private Sub CenterControl()
        ' Set uniform size for all UCs
        Me.Size = New Size(1200, 700)

        ' Center sa parent container
        If Me.Parent IsNot Nothing Then
            Me.Left = (Me.Parent.Width - Me.Width) \ 2
            Me.Top = (Me.Parent.Height - Me.Height) \ 2
            Me.Anchor = AnchorStyles.None
        End If
    End Sub

    ' Auto-center kapag nag-resize ang parent
    Protected Overrides Sub OnParentChanged(e As EventArgs)
        MyBase.OnParentChanged(e)
        If Me.Parent IsNot Nothing Then
            AddHandler Me.Parent.Resize, AddressOf Parent_Resize
        End If
    End Sub

    Private Sub Parent_Resize(sender As Object, e As EventArgs)
        CenterControl()
    End Sub
End Class