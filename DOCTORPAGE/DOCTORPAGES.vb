Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class DOCTORPAGES
    Private currentUC As UserControl = Nothing
    Private consultationUC As UC_CONSULTATION = Nothing

    Private Sub DOCTORPAGES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDoctorInCharge()
        LoadDashboard()

        AddHandler Me.Resize, AddressOf Form_Resize
    End Sub

    Private Sub Form_Resize(sender As Object, e As EventArgs)
        If currentUC IsNot Nothing Then
            currentUC.Size = New Size(PanelContent.Width, PanelContent.Height)
            currentUC.Location = New Point(0, 0)
        End If
    End Sub

    Public Sub LoadDashboard()
        PanelContent.Controls.Clear()
        Dim uc As New UC_DASHBOARD()

        If CurrentDoctor IsNot Nothing Then
            uc.SetDoctorName(CurrentDoctor.FullName)
        End If

        uc.Size = New Size(PanelContent.Width, PanelContent.Height)
        uc.Location = New Point(0, 0)
        PanelContent.Controls.Add(uc)
        currentUC = uc
    End Sub

    Public Sub LoadPatientQueue()
        PanelContent.Controls.Clear()
        Dim uc As New UC_PATIENTQUEUE()

        uc.Size = New Size(PanelContent.Width, PanelContent.Height)
        uc.Location = New Point(0, 0)
        PanelContent.Controls.Add(uc)
        currentUC = uc
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
    End Sub

    Public Sub LoadConsultationWithPatient(queueNumber As String)
        PanelContent.Controls.Clear()
        consultationUC = New UC_CONSULTATION()
        consultationUC.SetCurrentPatient(queueNumber)
        consultationUC.Size = New Size(PanelContent.Width, PanelContent.Height)
        consultationUC.Location = New Point(0, 0)
        PanelContent.Controls.Add(consultationUC)
        currentUC = consultationUC
    End Sub

    Public Sub LoadRecords()
        PanelContent.Controls.Clear()
        Dim uc As New UC_RECORDS()

        uc.Size = New Size(PanelContent.Width, PanelContent.Height)
        uc.Location = New Point(0, 0)
        PanelContent.Controls.Add(uc)
        currentUC = uc
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        LoadDashboard()
    End Sub

    Private Sub btnQueue_Click(sender As Object, e As EventArgs) Handles btnQueue.Click
        LoadPatientQueue()
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadConsultation()
    End Sub

    Private Sub btnRecords_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadRecords()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Logout",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub


    Private Sub PanelSidebar_Paint(sender As Object, e As PaintEventArgs) Handles PanelSidebar.Paint
        Dim brush As New Drawing2D.LinearGradientBrush(
        PanelSidebar.ClientRectangle,
        Color.FromArgb(45, 95, 200),
        Color.FromArgb(100, 160, 255),
        Drawing2D.LinearGradientMode.Vertical)

        e.Graphics.FillRectangle(brush, PanelSidebar.ClientRectangle)

    End Sub
End Class