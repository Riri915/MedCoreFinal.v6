Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_Records
    Inherits UserControl

    Public Sub New()
        InitializeRecords()
    End Sub

    Private Sub InitializeRecords()
        Me.BackColor = Color.FromArgb(248, 249, 250)
        Me.Dock = DockStyle.Fill

        Dim mainLayout As New TableLayoutPanel()
        mainLayout.Dock = DockStyle.Fill
        mainLayout.RowCount = 2
        mainLayout.Padding = New Padding(20)

        mainLayout.RowStyles.Add(New RowStyle(SizeType.Absolute, 80))
        mainLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))

        ' Search Panel
        Dim searchPanel As New Panel()
        searchPanel.BackColor = Color.White
        searchPanel.Padding = New Padding(15)

        Dim lblSearch As New Label()
        lblSearch.Text = "Search Patient Records"
        lblSearch.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblSearch.ForeColor = Color.FromArgb(26, 115, 232)
        lblSearch.Location = New Point(15, 15)
        lblSearch.AutoSize = True

        Dim txtSearch As New TextBox()
        txtSearch.Font = New Font("Segoe UI", 11)
        txtSearch.Size = New Size(400, 30)
        txtSearch.Location = New Point(15, 50)
        txtSearch.Text = "Search by name, ID, or date..."
        ' Note: PlaceholderText is not available in standard TextBox
        ' Use Text property instead and handle enter/leave events if needed

        Dim btnSearch As New Button()
        btnSearch.Text = "🔍 Search"
        btnSearch.Font = New Font("Segoe UI", 10)
        btnSearch.BackColor = Color.FromArgb(26, 115, 232)
        btnSearch.ForeColor = Color.White
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Size = New Size(100, 32)
        btnSearch.Location = New Point(430, 50)

        Dim btnAdd As New Button()
        btnAdd.Text = "➕ Add New Record"
        btnAdd.Font = New Font("Segoe UI", 10)
        btnAdd.BackColor = Color.FromArgb(52, 168, 83)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Size = New Size(130, 32)
        btnAdd.Location = New Point(540, 50)

        searchPanel.Controls.Add(btnAdd)
        searchPanel.Controls.Add(btnSearch)
        searchPanel.Controls.Add(txtSearch)
        searchPanel.Controls.Add(lblSearch)

        ' Records List Panel
        Dim recordsPanel As New Panel()
        recordsPanel.BackColor = Color.White
        recordsPanel.Padding = New Padding(15)

        Dim lblRecords As New Label()
        lblRecords.Text = "Patient Records"
        lblRecords.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblRecords.ForeColor = Color.FromArgb(26, 115, 232)
        lblRecords.Dock = DockStyle.Top
        lblRecords.Height = 40

        Dim recordsList As New ListView()
        recordsList.Dock = DockStyle.Fill
        recordsList.View = View.Details
        recordsList.FullRowSelect = True
        recordsList.Font = New Font("Segoe UI", 10)

        recordsList.Columns.Add("ID", 80)
        recordsList.Columns.Add("Patient Name", 200)
        recordsList.Columns.Add("Age", 60)
        recordsList.Columns.Add("Last Visit", 120)
        recordsList.Columns.Add("Dentist", 150)
        recordsList.Columns.Add("Treatment", 200)
        recordsList.Columns.Add("Status", 100)

        ' Sample Data
        Dim item1 As New ListViewItem(New String() {"PT001", "Juan Dela Cruz", "35", "2024-03-15", "Dr. Santos", "Tooth Extraction", "Completed"})
        recordsList.Items.Add(item1)

        Dim item2 As New ListViewItem(New String() {"PT002", "Maria Reyes", "28", "2024-03-14", "Dr. Reyes", "Dental Cleaning", "Completed"})
        recordsList.Items.Add(item2)

        Dim item3 As New ListViewItem(New String() {"PT003", "Pedro Santos", "42", "2024-03-14", "Dr. Santos", "Root Canal", "Ongoing"})
        recordsList.Items.Add(item3)

        Dim item4 As New ListViewItem(New String() {"PT004", "Ana Lopez", "19", "2024-03-13", "Dr. Cruz", "Braces", "Ongoing"})
        recordsList.Items.Add(item4)

        Dim item5 As New ListViewItem(New String() {"PT005", "Carlos Mendoza", "55", "2024-03-13", "Dr. Santos", "Checkup", "Completed"})
        recordsList.Items.Add(item5)

        Dim item6 As New ListViewItem(New String() {"PT006", "Rosa Fernandez", "31", "2024-03-12", "Dr. Reyes", "Whitening", "Completed"})
        recordsList.Items.Add(item6)

        Dim item7 As New ListViewItem(New String() {"PT007", "Jose Santos", "47", "2024-03-12", "Dr. Cruz", "Extraction", "Completed"})
        recordsList.Items.Add(item7)

        Dim item8 As New ListViewItem(New String() {"PT008", "Luzviminda Cruz", "63", "2024-03-11", "Dr. Santos", "Dentures", "Ongoing"})
        recordsList.Items.Add(item8)

        recordsPanel.Controls.Add(recordsList)
        recordsPanel.Controls.Add(lblRecords)

        mainLayout.Controls.Add(searchPanel, 0, 0)
        mainLayout.Controls.Add(recordsPanel, 0, 1)

        Me.Controls.Add(mainLayout)
    End Sub
End Class