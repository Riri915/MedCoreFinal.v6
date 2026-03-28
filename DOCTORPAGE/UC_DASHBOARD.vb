Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class UC_DASHBOARD
    Private doctorName As String = "DOCTOR"
    Private timerRefresh As New Timer()

    Public Sub SetDoctorName(name As String)
        doctorName = name
        lblWelcome.Text = "GOOD DAY, " & doctorName.ToUpper() & "!"
    End Sub

    Private Sub UC_DASHBOARD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(doctorName) AndAlso doctorName <> "DOCTOR" Then
            lblWelcome.Text = "GOOD DAY, " & doctorName.ToUpper() & "!"
        End If

        ' Add rounded corners to panels
        AddHandler PanelTotal.Paint, AddressOf Panel_Paint
        AddHandler PanelWaiting.Paint, AddressOf Panel_Paint
        AddHandler PanelServing.Paint, AddressOf Panel_Paint
        AddHandler PanelDone.Paint, AddressOf Panel_Paint
        AddHandler PanelCharts.Paint, AddressOf Panel_Paint

        ' Load data from database
        LoadDashboardData()

        ' Click handlers for stats panels (go to queue)
        AddHandler PanelTotal.Click, AddressOf StatPanel_Click
        AddHandler PanelWaiting.Click, AddressOf StatPanel_Click
        AddHandler PanelServing.Click, AddressOf StatPanel_Click
        AddHandler PanelDone.Click, AddressOf StatPanel_Click

        ' Auto-refresh every 5 seconds
        timerRefresh.Interval = 5000
        AddHandler timerRefresh.Tick, AddressOf TimerRefresh_Tick
        timerRefresh.Start()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim rect As New Rectangle(0, 0, panel.Width - 1, panel.Height - 1)
        Dim path As New GraphicsPath()
        Dim radius As Integer = 15

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        panel.Region = New Region(path)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using pen As New Pen(Color.FromArgb(200, 200, 200), 1)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Private Sub LoadDashboardData()
        ' Get data from database
        lblTotalValue.Text = DatabaseHelper.GetTotalPatients().ToString()
        lblWaitingValue.Text = DatabaseHelper.GetWaitingCount().ToString()
        lblServingValue.Text = DatabaseHelper.GetServingCount().ToString()
        lblDoneValue.Text = DatabaseHelper.GetDoneCount().ToString()

        ' Get counts by service type
        Dim pastaCount As Integer = DatabaseHelper.GetCountByServiceType("Pasta")
        Dim checkupCount As Integer = DatabaseHelper.GetCountByServiceType("Check-up")
        Dim otherCount As Integer = DatabaseHelper.GetTotalPatients() - pastaCount - checkupCount
        If otherCount < 0 Then otherCount = 0

        lblPastaCount.Text = pastaCount.ToString()
        lblCheckupCount.Text = checkupCount.ToString()
        lblOtherCount.Text = otherCount.ToString()

        ' Update bar heights based on counts
        Dim maxCount As Integer = Math.Max(pastaCount, Math.Max(checkupCount, otherCount))
        If maxCount > 0 Then
            barPasta.Height = CInt(120 * pastaCount / maxCount)
            barCheckup.Height = CInt(120 * checkupCount / maxCount)
            barOther.Height = CInt(120 * otherCount / maxCount)

            barPasta.Top = 170 - barPasta.Height
            barCheckup.Top = 170 - barCheckup.Height
            barOther.Top = 170 - barOther.Height
        End If

        ' Update average times
        Dim avgTime As Double = DatabaseHelper.GetAverageConsultationTime()
        lblAvgTimeValue.Text = avgTime.ToString() & " min"

        lblPastaTime.Text = "Avg: " & GetAverageTimeByService("Pasta").ToString() & " min"
        lblCheckupTime.Text = "Avg: " & GetAverageTimeByService("Check-up").ToString() & " min"
        lblOtherTime.Text = "Avg: " & GetAverageTimeByService("Other").ToString() & " min"
    End Sub

    Private Function GetAverageTimeByService(serviceType As String) As Double
        Dim query As String = ""

        If serviceType = "Other" Then
            query = "SELECT AVG(TIMESTAMPDIFF(MINUTE, created_at, updated_at)) FROM patient_queue " &
                    "WHERE updated_at IS NOT NULL AND status = 'Done' " &
                    "AND service_type NOT LIKE '%Pasta%' AND service_type NOT LIKE '%Check-up%'"
        Else
            query = "SELECT AVG(TIMESTAMPDIFF(MINUTE, created_at, updated_at)) FROM patient_queue " &
                    "WHERE updated_at IS NOT NULL AND status = 'Done' AND service_type LIKE '%" & serviceType & "%'"
        End If

        Dim result As Object = DatabaseHelper.ExecuteScalar(query)
        Return If(result IsNot Nothing AndAlso result IsNot DBNull.Value, Math.Round(Convert.ToDouble(result), 1), 0)
    End Function

    Private Sub StatPanel_Click(sender As Object, e As EventArgs)
        Dim parentForm As DOCTORPAGES = TryCast(Me.ParentForm, DOCTORPAGES)
        If parentForm IsNot Nothing Then
            parentForm.LoadPatientQueue()
        End If
    End Sub

    Private Sub TimerRefresh_Tick(sender As Object, e As EventArgs)
        LoadDashboardData()
    End Sub

    Private Sub PanelMain_Paint(sender As Object, e As PaintEventArgs) Handles PanelMain.Paint

    End Sub

    Private Sub lblWelcome_Click(sender As Object, e As EventArgs) Handles lblWelcome.Click

    End Sub
End Class