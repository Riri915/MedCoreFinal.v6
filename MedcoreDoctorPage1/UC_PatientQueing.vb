Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_PatientQueuing
    Inherits UserControl

    Public Sub New()
        InitializeQueuing()
    End Sub

    Private Sub InitializeQueuing()
        Me.BackColor = Color.FromArgb(248, 249, 250)
        Me.Dock = DockStyle.Fill

        ' Main Layout
        Dim mainLayout As New TableLayoutPanel()
        mainLayout.Dock = DockStyle.Fill
        mainLayout.ColumnCount = 2
        mainLayout.RowCount = 1
        mainLayout.Padding = New Padding(20)

        mainLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65))
        mainLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35))

        ' Queue List Panel
        Dim queuePanel As New Panel()
        queuePanel.BackColor = Color.White
        queuePanel.Padding = New Padding(15)

        Dim lblQueueTitle As New Label()
        lblQueueTitle.Text = "Current Patient Queue"
        lblQueueTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblQueueTitle.ForeColor = Color.FromArgb(26, 115, 232)
        lblQueueTitle.Dock = DockStyle.Top
        lblQueueTitle.Height = 50

        Dim queueList As New ListView()
        queueList.Dock = DockStyle.Fill
        queueList.View = View.Details
        queueList.FullRowSelect = True
        queueList.Font = New Font("Segoe UI", 10)

        queueList.Columns.Add("Queue #", 80)
        queueList.Columns.Add("Patient Name", 200)
        queueList.Columns.Add("Time", 100)
        queueList.Columns.Add("Concern", 200)
        queueList.Columns.Add("Status", 100)

        ' Sample Data
        queueList.Items.Add(New ListViewItem(New String() {"001", "Juan Dela Cruz", "9:00 AM", "Tooth Extraction", "Waiting"}))
        queueList.Items.Add(New ListViewItem(New String() {"002", "Maria Reyes", "9:30 AM", "Cleaning", "In Consultation"}))
        queueList.Items.Add(New ListViewItem(New String() {"003", "Pedro Santos", "10:00 AM", "Root Canal", "Waiting"}))
        queueList.Items.Add(New ListViewItem(New String() {"004", "Ana Lopez", "10:30 AM", "Braces", "Waiting"}))
        queueList.Items.Add(New ListViewItem(New String() {"005", "Carlos Mendoza", "11:00 AM", "Checkup", "Waiting"}))
        queueList.Items.Add(New ListViewItem(New String() {"006", "Rosa Fernandez", "1:00 PM", "Cleaning", "Waiting"}))
        queueList.Items.Add(New ListViewItem(New String() {"007", "Jose Santos", "1:30 PM", "Extraction", "Waiting"}))
        queueList.Items.Add(New ListViewItem(New String() {"008", "Luzviminda Cruz", "2:00 PM", "Root Canal", "Waiting"}))

        queuePanel.Controls.Add(queueList)
        queuePanel.Controls.Add(lblQueueTitle)

        ' Controls Panel
        Dim controlsPanel As New Panel()
        controlsPanel.BackColor = Color.White
        controlsPanel.Padding = New Padding(15)

        Dim lblControlsTitle As New Label()
        lblControlsTitle.Text = "Queue Management"
        lblControlsTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblControlsTitle.ForeColor = Color.FromArgb(26, 115, 232)
        lblControlsTitle.Dock = DockStyle.Top
        lblControlsTitle.Height = 50

        Dim btnNext As New Button()
        btnNext.Text = "➡️  Next Patient"
        btnNext.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnNext.BackColor = Color.FromArgb(26, 115, 232)
        btnNext.ForeColor = Color.White
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Size = New Size(200, 50)
        btnNext.Location = New Point(20, 80)

        Dim btnAdd As New Button()
        btnAdd.Text = "➕  Add to Queue"
        btnAdd.Font = New Font("Segoe UI", 12)
        btnAdd.BackColor = Color.FromArgb(52, 168, 83)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Size = New Size(200, 50)
        btnAdd.Location = New Point(20, 150)

        Dim btnCall As New Button()
        btnCall.Text = "📢  Call Patient"
        btnCall.Font = New Font("Segoe UI", 12)
        btnCall.BackColor = Color.FromArgb(251, 188, 5)
        btnCall.ForeColor = Color.White
        btnCall.FlatStyle = FlatStyle.Flat
        btnCall.Size = New Size(200, 50)
        btnCall.Location = New Point(20, 220)

        Dim btnComplete As New Button()
        btnComplete.Text = "✅  Mark Complete"
        btnComplete.Font = New Font("Segoe UI", 12)
        btnComplete.BackColor = Color.FromArgb(234, 67, 53)
        btnComplete.ForeColor = Color.White
        btnComplete.FlatStyle = FlatStyle.Flat
        btnComplete.Size = New Size(200, 50)
        btnComplete.Location = New Point(20, 290)

        controlsPanel.Controls.Add(btnComplete)
        controlsPanel.Controls.Add(btnCall)
        controlsPanel.Controls.Add(btnAdd)
        controlsPanel.Controls.Add(btnNext)
        controlsPanel.Controls.Add(lblControlsTitle)

        mainLayout.Controls.Add(queuePanel, 0, 0)
        mainLayout.Controls.Add(controlsPanel, 1, 0)

        Me.Controls.Add(mainLayout)
    End Sub
End Class