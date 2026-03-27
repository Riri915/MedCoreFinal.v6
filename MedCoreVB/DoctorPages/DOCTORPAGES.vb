Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class DOCTORPAGES
    Private currentUC As UserControl = Nothing
    Private consultationUC As UC_CONSULTATION = Nothing
    Private timerDateTime As New Timer()

    Private Sub DOCTORPAGES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' SAME FUNCTIONALITY - walang binago
        LoadDoctorInCharge()

        timerDateTime.Interval = 1000
        AddHandler timerDateTime.Tick, AddressOf UpdateDateTime
        timerDateTime.Start()

        AddHandler Me.Resize, AddressOf Form_Resize
    End Sub

    Private Sub UpdateDateTime(sender As Object, e As EventArgs)
        lblDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy  hh:mm:ss tt")
    End Sub

    Private Sub Form_Resize(sender As Object, e As EventArgs)
        If currentUC IsNot Nothing Then
            currentUC.Size = New Size(PanelContent.Width, PanelContent.Height)
            currentUC.Location = New Point(0, 0)
        End If
    End Sub

    ' ============ SAME FUNCTIONS AS BEFORE ============



    Public Sub LoadPatientQueue()
        PanelContent.Controls.Clear()
        Dim uc As New UC_PATIENTQUEUE()
        uc.Size = New Size(PanelContent.Width, PanelContent.Height)
        uc.Location = New Point(0, 0)
        PanelContent.Controls.Add(uc)
        currentUC = uc
        HighlightActiveButton("UC_PATIENTQUEUE")
    End Sub

    Public Sub LoadConsultation()
        PanelContent.Controls.Clear()

        If ConsultationSession.ContainsKey("IsActive") AndAlso ConsultationSession("IsActive") Then
            consultationUC = New UC_CONSULTATION()
            consultationUC.LoadSavedConsultation()
        Else
            consultationUC = New UC_CONSULTATION()
        End If

        consultationUC.Size = New Size(PanelContent.Width, PanelContent.Height)
        consultationUC.Location = New Point(0, 0)
        PanelContent.Controls.Add(consultationUC)
        currentUC = consultationUC
        HighlightActiveButton("UC_CONSULTATION")
    End Sub

    Public Sub LoadConsultationWithPatient(queueNumber As String)
        PanelContent.Controls.Clear()
        consultationUC = New UC_CONSULTATION()
        consultationUC.SetCurrentPatient(queueNumber)
        consultationUC.Size = New Size(PanelContent.Width, PanelContent.Height)
        consultationUC.Location = New Point(0, 0)
        PanelContent.Controls.Add(consultationUC)
        currentUC = consultationUC
        HighlightActiveButton("UC_CONSULTATION")
    End Sub

    Public Sub LoadRecords()
        PanelContent.Controls.Clear()
        Dim uc As New UC_RECORDS()
        uc.Size = New Size(PanelContent.Width, PanelContent.Height)
        uc.Location = New Point(0, 0)
        PanelContent.Controls.Add(uc)
        currentUC = uc
        HighlightActiveButton("UC_RECORDS")
    End Sub

    Private Sub HighlightActiveButton(ucName As String)
        btnDashboard.BackColor = Color.FromArgb(52, 73, 94)
        btnQueue.BackColor = Color.FromArgb(52, 73, 94)
        btnConsultation.BackColor = Color.FromArgb(52, 73, 94)
        btnRecords.BackColor = Color.FromArgb(52, 73, 94)

        btnDashboard.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnQueue.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnConsultation.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnRecords.Font = New Font("Segoe UI", 10, FontStyle.Regular)

        Select Case ucName
            Case "UC_DASHBOARD"
                btnDashboard.BackColor = Color.FromArgb(52, 152, 219)
                btnDashboard.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            Case "UC_PATIENTQUEUE"
                btnQueue.BackColor = Color.FromArgb(52, 152, 219)
                btnQueue.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            Case "UC_CONSULTATION"
                btnConsultation.BackColor = Color.FromArgb(52, 152, 219)
                btnConsultation.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            Case "UC_RECORDS"
                btnRecords.BackColor = Color.FromArgb(52, 152, 219)
                btnRecords.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        End Select
    End Sub



    Private Sub btnQueue_Click(sender As Object, e As EventArgs) Handles btnQueue.Click
        LoadPatientQueue()
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        LoadConsultation()
    End Sub

    Private Sub btnRecords_Click(sender As Object, e As EventArgs) Handles btnRecords.Click
        LoadRecords()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Logout",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub UC_NEWDASHBOARD1_Load(sender As Object, e As EventArgs) Handles UC_NEWDASHBOARD1.Load

    End Sub
End Class
