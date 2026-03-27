Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class UC_RECORDS
    Private WithEvents txtSearch As New TextBox()
    Private WithEvents cmbSearchBy As New ComboBox()
    Private WithEvents dtpSearchDate As New DateTimePicker()
    Private WithEvents btnSearch As New Button()
    Private WithEvents btnReset As New Button()

    Private pnlDetails As New Panel()
    Private lblDetailsTitle As New Label()
    Private lblID As New Label()
    Private lblName As New Label()
    Private lblGender As New Label()
    Private lblAge As New Label()
    Private lblBirthday As New Label()
    Private lblAddress As New Label()
    Private lblPhone As New Label()
    Private lblEmergencyContact As New Label()
    Private lblDate As New Label()
    Private lblDiagnosis As New Label()
    Private lblPrescription As New Label()
    Private txtDiagnosis As New TextBox()
    Private txtPrescription As New TextBox()
    Private btnClose As New Button()

    Private Sub UC_RECORDS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleMainPanel()
        AddSmartSearchControls()
        CreateDetailedView()
        LoadAllRecords()
    End Sub

    Private Sub StyleMainPanel()
        Me.BackColor = Color.FromArgb(240, 242, 245)
        Me.Size = New Size(1200, 700)

        Panel1.BackColor = Color.White
        Panel1.Size = New Size(1160, 660)
        Panel1.Location = New Point(20, 20)
        AddHandler Panel1.Paint, AddressOf MainPanel_Paint

        Label5.Text = "PATIENT RECORDS"
        Label5.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        Label5.ForeColor = Color.FromArgb(52, 73, 94)
        Label5.Location = New Point(20, 20)

        DataGridView1.Size = New Size(1110, 300)
        DataGridView1.Location = New Point(20, 110)
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.GridColor = Color.FromArgb(230, 230, 230)
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219)
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White

        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        DataGridView1.ColumnHeadersHeight = 45
        DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        DataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80)
        DataGridView1.RowTemplate.Height = 38
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250)

        Label1.Text = "SELECTED RECORD DETAILS"
        Label1.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(52, 73, 94)
        Label1.Location = New Point(20, 440)

        Label2.BackColor = Color.FromArgb(248, 249, 250)
        Label2.ForeColor = Color.FromArgb(44, 62, 80)
        Label2.Font = New Font("Segoe UI", 10)
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Size = New Size(600, 40)
        Label2.TextAlign = ContentAlignment.MiddleLeft
        Label2.Padding = New Padding(10, 0, 0, 0)
        Label2.Location = New Point(20, 480)

        Label3.BackColor = Color.FromArgb(248, 249, 250)
        Label3.ForeColor = Color.FromArgb(44, 62, 80)
        Label3.Font = New Font("Segoe UI", 10)
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Size = New Size(600, 40)
        Label3.TextAlign = ContentAlignment.MiddleLeft
        Label3.Padding = New Padding(10, 0, 0, 0)
        Label3.Location = New Point(20, 520)

        Label4.BackColor = Color.FromArgb(248, 249, 250)
        Label4.ForeColor = Color.FromArgb(44, 62, 80)
        Label4.Font = New Font("Segoe UI", 10)
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label4.Size = New Size(600, 40)
        Label4.TextAlign = ContentAlignment.MiddleLeft
        Label4.Padding = New Padding(10, 0, 0, 0)
        Label4.Location = New Point(20, 560)

        Button1.Text = "VIEW FULL DETAILS"
        Button1.BackColor = Color.FromArgb(52, 152, 219)
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Button1.Size = New Size(150, 40)
        Button1.Location = New Point(830, 610)
        Button1.Cursor = Cursors.Hand

        btnDelete.Text = "🗑️ DELETE RECORD"
        btnDelete.BackColor = Color.FromArgb(231, 76, 60)
        btnDelete.ForeColor = Color.White
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnDelete.Size = New Size(150, 40)
        btnDelete.Location = New Point(990, 610)
        btnDelete.Cursor = Cursors.Hand
    End Sub

    Private Sub AddSmartSearchControls()
        Dim searchPanel As New Panel()
        searchPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        searchPanel.BackColor = Color.FromArgb(248, 249, 250)
        searchPanel.Size = New Size(1110, 70)
        searchPanel.Location = New Point(20, 70)
        searchPanel.BorderStyle = BorderStyle.None
        AddHandler searchPanel.Paint, AddressOf SearchPanel_Paint

        cmbSearchBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        cmbSearchBy.Items.AddRange(New String() {"All", "Queue #", "Patient Name", "Date"})
        cmbSearchBy.SelectedIndex = 0
        cmbSearchBy.Location = New Point(15, 20)
        cmbSearchBy.Size = New Size(120, 30)
        cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSearchBy.Font = New Font("Segoe UI", 10)
        cmbSearchBy.FlatStyle = FlatStyle.Flat

        txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        txtSearch.Location = New Point(145, 20)
        txtSearch.Size = New Size(350, 30)
        txtSearch.Font = New Font("Segoe UI", 10)
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Text = "Search records..."
        txtSearch.ForeColor = Color.Gray

        AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
        AddHandler txtSearch.Enter, AddressOf TxtSearch_Enter
        AddHandler txtSearch.Leave, AddressOf TxtSearch_Leave

        dtpSearchDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dtpSearchDate.Location = New Point(145, 20)
        dtpSearchDate.Size = New Size(350, 30)
        dtpSearchDate.Font = New Font("Segoe UI", 10)
        dtpSearchDate.Format = DateTimePickerFormat.Short
        dtpSearchDate.Visible = False

        btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        btnSearch.Text = "🔍 SEARCH"
        btnSearch.Location = New Point(505, 20)
        btnSearch.Size = New Size(100, 30)
        btnSearch.BackColor = Color.FromArgb(52, 152, 219)
        btnSearch.ForeColor = Color.White
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.FlatAppearance.BorderSize = 0
        btnSearch.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnSearch.Cursor = Cursors.Hand

        btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        btnReset.Text = "↻ RESET"
        btnReset.Location = New Point(615, 20)
        btnReset.Size = New Size(100, 30)
        btnReset.BackColor = Color.FromArgb(149, 165, 166)
        btnReset.ForeColor = Color.White
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.FlatAppearance.BorderSize = 0
        btnReset.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnReset.Cursor = Cursors.Hand

        Dim lblSearchInfo As New Label()
        lblSearchInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        lblSearchInfo.Text = "💡 Tip: Search by Queue #, Name, or Date"
        lblSearchInfo.Font = New Font("Segoe UI", 9, FontStyle.Italic)
        lblSearchInfo.ForeColor = Color.Gray
        lblSearchInfo.Location = New Point(725, 25)
        lblSearchInfo.AutoSize = True
        lblSearchInfo.BackColor = Color.Transparent

        searchPanel.Controls.Add(cmbSearchBy)
        searchPanel.Controls.Add(txtSearch)
        searchPanel.Controls.Add(dtpSearchDate)
        searchPanel.Controls.Add(btnSearch)
        searchPanel.Controls.Add(btnReset)
        searchPanel.Controls.Add(lblSearchInfo)

        Panel1.Controls.Add(searchPanel)
    End Sub

    Private Sub CreateDetailedView()
        pnlDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        pnlDetails.Size = New Size(700, 580)
        pnlDetails.Location = New Point(200, 30)
        pnlDetails.BackColor = Color.White
        pnlDetails.BorderStyle = BorderStyle.None
        pnlDetails.Visible = False
        AddHandler pnlDetails.Paint, AddressOf DetailsPanel_Paint

        lblDetailsTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        lblDetailsTitle.Text = "PATIENT COMPLETE DETAILS"
        lblDetailsTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblDetailsTitle.ForeColor = Color.FromArgb(52, 73, 94)
        lblDetailsTitle.Location = New Point(200, 20)
        lblDetailsTitle.AutoSize = True

        ' All labels with Anchor = Top, Left
        lblID.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblID.Location = New Point(30, 70)
        lblID.Size = New Size(300, 30)
        lblID.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblName.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblName.Location = New Point(30, 105)
        lblName.Size = New Size(300, 30)
        lblName.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblGender.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblGender.Location = New Point(30, 140)
        lblGender.Size = New Size(150, 30)
        lblGender.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblAge.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblAge.Location = New Point(200, 140)
        lblAge.Size = New Size(150, 30)
        lblAge.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblBirthday.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblBirthday.Location = New Point(30, 175)
        lblBirthday.Size = New Size(300, 30)
        lblBirthday.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblAddress.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAddress.Location = New Point(30, 210)
        lblAddress.Size = New Size(620, 30)
        lblAddress.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblPhone.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblPhone.Location = New Point(30, 245)
        lblPhone.Size = New Size(300, 30)
        lblPhone.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblEmergencyContact.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblEmergencyContact.Location = New Point(350, 245)
        lblEmergencyContact.Size = New Size(300, 30)
        lblEmergencyContact.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblDate.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblDate.Location = New Point(30, 280)
        lblDate.Size = New Size(300, 30)
        lblDate.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        lblDiagnosis.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblDiagnosis.Text = "DIAGNOSIS:"
        lblDiagnosis.Location = New Point(30, 320)
        lblDiagnosis.Size = New Size(200, 25)
        lblDiagnosis.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        txtDiagnosis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        txtDiagnosis.Location = New Point(30, 350)
        txtDiagnosis.Size = New Size(620, 70)
        txtDiagnosis.Multiline = True
        txtDiagnosis.ReadOnly = True
        txtDiagnosis.BackColor = Color.FromArgb(248, 249, 250)
        txtDiagnosis.BorderStyle = BorderStyle.FixedSingle
        txtDiagnosis.Font = New Font("Segoe UI", 11)

        lblPrescription.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        lblPrescription.Text = "PRESCRIPTION:"
        lblPrescription.Location = New Point(30, 430)
        lblPrescription.Size = New Size(200, 25)
        lblPrescription.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        txtPrescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        txtPrescription.Location = New Point(30, 460)
        txtPrescription.Size = New Size(620, 70)
        txtPrescription.Multiline = True
        txtPrescription.ReadOnly = True
        txtPrescription.BackColor = Color.FromArgb(248, 249, 250)
        txtPrescription.BorderStyle = BorderStyle.FixedSingle
        txtPrescription.Font = New Font("Segoe UI", 11)

        btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        btnClose.Text = "← BACK TO RECORDS"
        btnClose.Location = New Point(250, 540)
        btnClose.Size = New Size(200, 40)
        btnClose.BackColor = Color.FromArgb(52, 152, 219)
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnClose.Cursor = Cursors.Hand
        AddHandler btnClose.Click, AddressOf BtnClose_Click

        pnlDetails.Controls.Add(lblDetailsTitle)
        pnlDetails.Controls.Add(lblID)
        pnlDetails.Controls.Add(lblName)
        pnlDetails.Controls.Add(lblGender)
        pnlDetails.Controls.Add(lblAge)
        pnlDetails.Controls.Add(lblBirthday)
        pnlDetails.Controls.Add(lblAddress)
        pnlDetails.Controls.Add(lblPhone)
        pnlDetails.Controls.Add(lblEmergencyContact)
        pnlDetails.Controls.Add(lblDate)
        pnlDetails.Controls.Add(lblDiagnosis)
        pnlDetails.Controls.Add(txtDiagnosis)
        pnlDetails.Controls.Add(lblPrescription)
        pnlDetails.Controls.Add(txtPrescription)
        pnlDetails.Controls.Add(btnClose)

        Panel1.Controls.Add(pnlDetails)
        pnlDetails.BringToFront()
    End Sub

    Private Sub MainPanel_Paint(sender As Object, e As PaintEventArgs)
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

    Private Sub SearchPanel_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim rect As New Rectangle(0, 0, panel.Width - 1, panel.Height - 1)
        Dim path As New GraphicsPath()
        Dim radius As Integer = 10
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

    Private Sub DetailsPanel_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim rect As New Rectangle(0, 0, panel.Width - 1, panel.Height - 1)
        Dim path As New GraphicsPath()
        Dim radius As Integer = 20
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        panel.Region = New Region(path)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using pen As New Pen(Color.FromArgb(52, 152, 219), 2)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
        If txtSearch.Text <> "Search records..." Then
            PerformSmartSearch()
        End If
    End Sub

    Private Sub TxtSearch_Enter(sender As Object, e As EventArgs)
        If txtSearch.Text = "Search records..." Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtSearch_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search records..."
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        If cmbSearchBy.Text = "Date" Then
            txtSearch.Visible = False
            dtpSearchDate.Visible = True
        Else
            txtSearch.Visible = True
            dtpSearchDate.Visible = False
        End If
        PerformSmartSearch()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PerformSmartSearch()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Text = "Search records..."
        txtSearch.ForeColor = Color.Gray
        cmbSearchBy.SelectedIndex = 0
        dtpSearchDate.Value = DateTime.Now
        LoadAllRecords()
    End Sub

    Private Sub PerformSmartSearch()
        Dim searchTerm As String = txtSearch.Text.Trim()
        Dim searchBy As String = cmbSearchBy.Text
        Dim searchDate As String = dtpSearchDate.Value.ToString("yyyy-MM-dd")

        If searchTerm = "Search records..." OrElse String.IsNullOrEmpty(searchTerm) Then
            LoadAllRecords()
            Return
        End If

        Dim dt As DataTable = DatabaseHelper.SearchRecords(searchTerm, searchBy)
        DataGridView1.Rows.Clear()

        For Each row As DataRow In dt.Rows
            DataGridView1.Rows.Add(row("ID"), row("Name"), row("Concern"), row("Date"), row("Status"))
        Next

        If DataGridView1.Rows.Count = 0 Then
            Label2.Text = "No records found."
            Label3.Text = ""
            Label4.Text = ""
        End If
    End Sub

    Private Sub LoadAllRecords()
        Dim dt As DataTable = DatabaseHelper.GetAllRecords()
        DataGridView1.Rows.Clear()

        For Each row As DataRow In dt.Rows
            DataGridView1.Rows.Add(row("ID"), row("Name"), row("Concern"), row("Date"), row("Status"))
        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim queueNumber As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            Dim dt As DataTable = DatabaseHelper.GetPatientByQueueNumber(queueNumber)

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Label2.Text = $"Queue: {row("queue_number")} | Name: {row("patient_name")} | Service: {row("service_type")}"
                Label3.Text = $"Status: {row("status")} | Date: {Convert.ToDateTime(row("created_at")):yyyy-MM-dd}"
                Label4.Text = $"Gender: {If(IsDBNull(row("gender")), "N/A", row("gender"))} | Age: {If(IsDBNull(row("age")), "N/A", row("age"))}"
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim queueNumber As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Dim dt As DataTable = DatabaseHelper.GetPatientByQueueNumber(queueNumber)

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                lblID.Text = "Queue #: " & row("queue_number").ToString()
                lblName.Text = "Name: " & row("patient_name").ToString()
                lblGender.Text = "Gender: " & If(IsDBNull(row("gender")), "N/A", row("gender"))
                lblAge.Text = "Age: " & If(IsDBNull(row("age")), "N/A", row("age"))
                lblBirthday.Text = "Birthday: " & If(IsDBNull(row("birthday")), "N/A", Convert.ToDateTime(row("birthday")).ToString("yyyy-MM-dd"))
                lblAddress.Text = "Address: " & If(IsDBNull(row("address")), "N/A", row("address"))
                lblPhone.Text = "Phone: " & If(IsDBNull(row("phone")), "N/A", row("phone"))
                lblEmergencyContact.Text = "Emergency: " & If(IsDBNull(row("emergency_contact")), "N/A", row("emergency_contact"))
                lblDate.Text = "Date: " & Convert.ToDateTime(row("created_at")).ToString("yyyy-MM-dd HH:mm")
                txtDiagnosis.Text = If(IsDBNull(row("diagnosis")), "No diagnosis recorded", row("diagnosis").ToString())
                txtPrescription.Text = If(IsDBNull(row("prescription")), "No prescription recorded", row("prescription").ToString())

                pnlDetails.Visible = True
            End If
        Else
            MessageBox.Show("Please select a record first!", "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim queueNumber As String = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Dim patientName As String = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()

            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete record for {patientName} (Queue #{queueNumber})?",
                                                         "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If DatabaseHelper.DeletePatientRecord(queueNumber) Then
                    MessageBox.Show("Record deleted successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadAllRecords()
                    Label2.Text = "Patient:"
                    Label3.Text = "Diagnosis:"
                    Label4.Text = "Prescription:"
                Else
                    MessageBox.Show("Failed to delete record!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a record to delete!", "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        pnlDetails.Visible = False
    End Sub
End Class