Imports System.Drawing
Imports System.Windows.Forms

Public Class DoctorPage
    Private activeButton As Button = Nothing
    Private currentUC As UserControl = Nothing
    Private timer As Timer

    Private Sub DoctorPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set current date
        lblDateToday.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")

        ' Setup timer for clock
        timer = New Timer()
        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf UpdateClock
        timer.Start()

        ' Setup button hover effects
        SetupButtonHoverEffects()

        ' Load default dashboard

        ' Set active button initially
        activeButton = btnDashboard
        activeButton.BackColor = Color.FromArgb(44, 125, 160)
        activeButton.ForeColor = Color.White

        ' Handle resize
        AddHandler Me.Resize, AddressOf DoctorPage_Resize
    End Sub

    Private Sub SetupButtonHoverEffects()
        Dim buttons As Button() = {btnDashboard, btnQueue, btnConsultation, btnRecords}
        For Each btn In buttons
            AddHandler btn.MouseEnter, Sub(s, e)
                                           If activeButton IsNot btn Then btn.BackColor = Color.FromArgb(30, 70, 90)
                                       End Sub
            AddHandler btn.MouseLeave, Sub(s, e)
                                           If activeButton IsNot btn Then btn.BackColor = Color.Transparent
                                       End Sub
        Next
    End Sub

    Private Sub UpdateClock()
        timeLabel.Text = DateTime.Now.ToString("hh:mm tt")
        timeLabel.Left = topBar.Width - timeLabel.Width - 30
    End Sub

    Private Sub DoctorPage_Resize(sender As Object, e As EventArgs)
        If timeLabel IsNot Nothing Then
            timeLabel.Left = topBar.Width - timeLabel.Width - 30
        End If
    End Sub

    Private Sub LoadUserControl(newUC As UserControl, activeBtn As Button)
        ' Update active button styling
        If activeButton IsNot Nothing Then
            activeButton.BackColor = Color.Transparent
            activeButton.ForeColor = Color.FromArgb(220, 240, 255)
        End If
        activeButton = activeBtn
        activeButton.BackColor = Color.FromArgb(44, 125, 160)
        activeButton.ForeColor = Color.White

        ' Update page title
        Dim titleText As String = activeBtn.Text.Replace("📊", "").Replace("👥", "").Replace("🦷", "").Replace("📁", "").Trim()
        lblPageTitle.Text = titleText

        ' Load new user control
        If currentUC IsNot Nothing Then
            ucContainer.Controls.Remove(currentUC)
            currentUC.Dispose()
        End If

        currentUC = newUC
        currentUC.Dock = DockStyle.Fill
        ucContainer.Controls.Clear()
        ucContainer.Controls.Add(currentUC)
        currentUC.Show()
    End Sub


    Private Sub btnQueue_Click(sender As Object, e As EventArgs) Handles btnQueue.Click
        LoadUserControl(New UC_PatientQueing(), btnQueue)
    End Sub



    Private Sub btnRecords_Click(sender As Object, e As EventArgs) Handles btnRecords.Click
        LoadUserControl(New UC_Records(), btnRecords)
    End Sub
End Class