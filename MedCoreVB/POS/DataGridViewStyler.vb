Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class DataGridViewStyler

    Public Shared Sub ApplyStyle(dgv As DataGridView)
        With dgv
            .BorderStyle = BorderStyle.None
            .BackgroundColor = Color.White
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .MultiSelect = False
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.FromArgb(230, 230, 230)
            .RowTemplate.Height = 36

            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            .DefaultCellStyle.Font = New Font("Segoe UI", 11)
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248)
        End With
    End Sub

    Public Shared Sub ApplyRoundedCorners(dgv As DataGridView, Optional radius As Integer = 12)
        AddHandler dgv.Resize, Sub(sender As Object, e As EventArgs)
                                   Dim ctrl = DirectCast(sender, DataGridView)
                                   Dim rect As New Rectangle(0, 0, ctrl.Width, ctrl.Height)
                                   Dim path As New GraphicsPath()

                                   path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
                                   path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
                                   path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
                                   path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
                                   path.CloseAllFigures()

                                   ctrl.Region = New Region(path)
                               End Sub

        Dim r As New Rectangle(0, 0, dgv.Width, dgv.Height)
        Dim p As New GraphicsPath()
        p.AddArc(r.X, r.Y, radius, radius, 180, 90)
        p.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90)
        p.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90)
        p.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90)
        p.CloseAllFigures()
        dgv.Region = New Region(p)
    End Sub

End Class
