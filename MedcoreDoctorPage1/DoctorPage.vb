Imports System.Drawing
Imports System.Windows.Forms

Public Class DoctorPage
    Inherits Form

    Private sidebarPanel As Panel
    Private topBar As Panel
    Private contentPanel As Panel
    Private btnDashboard As Button
    Private btnPatientQueue As Button
    Private btnConsultation As Button
    Private btnRecords As Button
    Private lblPageTitle As Label
    Private lblDoctorName As Label
    Private currentUC As UserControl

    Public Sub New()
        InitializeForm()
        SetupSidebar()
        SetupTopBar()
        SetupContentPanel()
        LoadDashboard()
    End Sub

    Private Sub InitializeForm()
        Me.Text = "Dental Clinic Management System"
        Me.Size = New Size(1920, 1080)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.FromArgb(248, 249, 250)
    End Sub

    Private Sub SetupSidebar()
        ' Sidebar Panel
        sidebarPanel = New Panel()
        sidebarPanel.BackColor = Color.FromArgb(26, 115, 232)
        sidebarPanel.Dock = DockStyle.Left
        sidebarPanel.Width = 280

        ' Logo Panel
        Dim logoPanel As New Panel()
        logoPanel.Dock = DockStyle.Top
        logoPanel.Height = 120
        logoPanel.BackColor = Color.FromArgb(26, 115, 232)

        Dim lblClinic As New Label()
        lblClinic.Text = "🦷 DENTAL CARE"
        lblClinic.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblClinic.ForeColor = Color.White
        lblClinic.Location = New Point(70, 70)
        lblClinic.AutoSize = True

        Dim picLogo As New PictureBox()
        picLogo.BackColor = Color.White
        picLogo.Size = New Size(50, 50)
        picLogo.Location = New Point(20, 35)

        logoPanel.Controls.Add(lblClinic)
        logoPanel.Controls.Add(picLogo)

        ' Dashboard Button
        btnDashboard = CreateSidebarButton("📊  DASHBOARD", 200)
        AddHandler btnDashboard.Click, AddressOf btnDashboard_Click

        ' Patient Queue Button
        btnPatientQueue = CreateSidebarButton("👥  PATIENT QUEUE", 260)
        AddHandler btnPatientQueue.Click, AddressOf btnPatientQueue_Click

        ' Consultation Button
        btnConsultation = CreateSidebarButton("🦷  CONSULTATION", 320)
        AddHandler btnConsultation.Click, AddressOf btnConsultation_Click

        ' Records Button
        btnRecords = CreateSidebarButton("📋  RECORDS", 380)
        AddHandler btnRecords.Click, AddressOf btnRecords_Click

        sidebarPanel.Controls.Add(btnRecords)
        sidebarPanel.Controls.Add(btnConsultation)
        sidebarPanel.Controls.Add(btnPatientQueue)
        sidebarPanel.Controls.Add(btnDashboard)
        sidebarPanel.Controls.Add(logoPanel)

        Me.Controls.Add(sidebarPanel)
    End Sub

    Private Function CreateSidebarButton(text As String, topPosition As Integer) As Button
        Dim btn As New Button()
        btn.Text = text
        btn.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        btn.ForeColor = Color.White
        btn.BackColor = Color.FromArgb(26, 115, 232)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Padding = New Padding(20, 0, 0, 0)
        btn.Size = New Size(280, 60)
        btn.Location = New Point(0, topPosition)
        btn.Dock = DockStyle.Top
        Return btn
    End Function

    Private Sub SetupTopBar()
        topBar = New Panel()
        topBar.BackColor = Color.White
        topBar.Dock = DockStyle.Top
        topBar.Height = 80
        topBar.Location = New Point(280, 0)

        ' Page Title
        lblPageTitle = New Label()
        lblPageTitle.Text = "Dashboard"
        lblPageTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblPageTitle.ForeColor = Color.FromArgb(26, 115, 232)
        lblPageTitle.Location = New Point(20, 22)
        lblPageTitle.AutoSize = True

        ' Doctor Name
        lblDoctorName = New Label()
        lblDoctorName.Text = "Dr. Maria Santos"
        lblDoctorName.Font = New Font("Segoe UI", 11)
        lblDoctorName.ForeColor = Color.FromArgb(64, 64, 64)
        lblDoctorName.Location = New Point(1500, 28)
        lblDoctorName.AutoSize = True

        ' Doctor Avatar
        Dim picDoctor As New PictureBox()
        picDoctor.BackColor = Color.FromArgb(26, 115, 232)
        picDoctor.Size = New Size(45, 45)
        picDoctor.Location = New Point(1650, 17)

        topBar.Controls.Add(picDoctor)
        topBar.Controls.Add(lblDoctorName)
        topBar.Controls.Add(lblPageTitle)
        Me.Controls.Add(topBar)
    End Sub

    Private Sub SetupContentPanel()
        contentPanel = New Panel()
        contentPanel.BackColor = Color.FromArgb(248, 249, 250)
        contentPanel.Dock = DockStyle.Fill
        contentPanel.Location = New Point(280, 80)
        Me.Controls.Add(contentPanel)
    End Sub

    Private Sub LoadDashboard()
        LoadUserControl(New UC_Dashboard())
        SetActiveButton(btnDashboard)
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        LoadUserControl(New UC_Dashboard())
        SetActiveButton(btnDashboard)
        lblPageTitle.Text = "Dashboard"
    End Sub

    Private Sub btnPatientQueue_Click(sender As Object, e As EventArgs)

        SetActiveButton(btnPatientQueue)
        lblPageTitle.Text = "Patient Queue"
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs)
        LoadUserControl(New UC_Consultation())
        SetActiveButton(btnConsultation)
        lblPageTitle.Text = "Consultation"
    End Sub

    Private Sub btnRecords_Click(sender As Object, e As EventArgs)
        LoadUserControl(New UC_Records())
        SetActiveButton(btnRecords)
        lblPageTitle.Text = "Patient Records"
    End Sub

    Private Sub LoadUserControl(uc As UserControl)
        If currentUC IsNot Nothing Then
            contentPanel.Controls.Remove(currentUC)
            currentUC.Dispose()
        End If

        currentUC = uc
        currentUC.Dock = DockStyle.Fill
        contentPanel.Controls.Add(currentUC)
    End Sub

    Private Sub SetActiveButton(activeButton As Button)
        Dim buttons() As Button = {btnDashboard, btnPatientQueue, btnConsultation, btnRecords}

        For Each btn In buttons
            btn.BackColor = Color.FromArgb(26, 115, 232)
            btn.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        Next

        activeButton.BackColor = Color.FromArgb(20, 255, 255, 255)
        activeButton.Font = New Font("Segoe UI", 11, FontStyle.Bold)
    End Sub
End Class