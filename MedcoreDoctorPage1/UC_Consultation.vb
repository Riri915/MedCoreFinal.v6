Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_Consultation
    Inherits UserControl

    Public Sub New()
        InitializeConsultation()
    End Sub

    Private Sub InitializeConsultation()
        Me.BackColor = Color.FromArgb(248, 249, 250)
        Me.Dock = DockStyle.Fill

        Dim mainLayout As New TableLayoutPanel()
        mainLayout.Dock = DockStyle.Fill
        mainLayout.ColumnCount = 2
        mainLayout.RowCount = 1
        mainLayout.Padding = New Padding(20)

        mainLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
        mainLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))

        ' Patient Information Panel
        Dim patientPanel As New Panel()
        patientPanel.BackColor = Color.White
        patientPanel.Padding = New Padding(20)

        Dim lblPatientTitle As New Label()
        lblPatientTitle.Text = "Patient Information"
        lblPatientTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblPatientTitle.ForeColor = Color.FromArgb(26, 115, 232)
        lblPatientTitle.Dock = DockStyle.Top
        lblPatientTitle.Height = 50

        ' Patient Details
        Dim txtPatientName As New TextBox()
        txtPatientName.Font = New Font("Segoe UI", 11)
        txtPatientName.Size = New Size(400, 30)
        txtPatientName.Location = New Point(20, 80)
        txtPatientName.Text = "Patient Name"

        Dim txtAge As New TextBox()
        txtAge.Font = New Font("Segoe UI", 11)
        txtAge.Size = New Size(150, 30)
        txtAge.Location = New Point(20, 130)
        txtAge.Text = "Age"

        Dim cbGender As New ComboBox()
        cbGender.Font = New Font("Segoe UI", 11)
        cbGender.Size = New Size(150, 30)
        cbGender.Location = New Point(200, 130)
        cbGender.Items.AddRange(New String() {"Male", "Female", "Other"})

        Dim txtConcern As New TextBox()
        txtConcern.Font = New Font("Segoe UI", 11)
        txtConcern.Size = New Size(400, 80)
        txtConcern.Location = New Point(20, 180)
        txtConcern.Multiline = True
        txtConcern.Text = "Patient Concern / Symptoms"

        Dim txtDentalHistory As New TextBox()
        txtDentalHistory.Font = New Font("Segoe UI", 11)
        txtDentalHistory.Size = New Size(400, 80)
        txtDentalHistory.Location = New Point(20, 280)
        txtDentalHistory.Multiline = True
        txtDentalHistory.Text = "Dental History"

        patientPanel.Controls.Add(txtDentalHistory)
        patientPanel.Controls.Add(txtConcern)
        patientPanel.Controls.Add(cbGender)
        patientPanel.Controls.Add(txtAge)
        patientPanel.Controls.Add(txtPatientName)
        patientPanel.Controls.Add(lblPatientTitle)

        ' Consultation Details Panel
        Dim consultationPanel As New Panel()
        consultationPanel.BackColor = Color.White
        consultationPanel.Padding = New Padding(20)

        Dim lblConsultTitle As New Label()
        lblConsultTitle.Text = "Consultation Details"
        lblConsultTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblConsultTitle.ForeColor = Color.FromArgb(26, 115, 232)
        lblConsultTitle.Dock = DockStyle.Top
        lblConsultTitle.Height = 50

        Dim txtDiagnosis As New TextBox()
        txtDiagnosis.Font = New Font("Segoe UI", 11)
        txtDiagnosis.Size = New Size(400, 80)
        txtDiagnosis.Location = New Point(20, 80)
        txtDiagnosis.Multiline = True
        txtDiagnosis.Text = "Diagnosis"

        Dim txtTreatment As New TextBox()
        txtTreatment.Font = New Font("Segoe UI", 11)
        txtTreatment.Size = New Size(400, 80)
        txtTreatment.Location = New Point(20, 180)
        txtTreatment.Multiline = True
        txtTreatment.Text = "Treatment Plan"

        Dim txtPrescription As New TextBox()
        txtPrescription.Font = New Font("Segoe UI", 11)
        txtPrescription.Size = New Size(400, 80)
        txtPrescription.Location = New Point(20, 280)
        txtPrescription.Multiline = True
        txtPrescription.Text = "Prescription"

        Dim txtNotes As New TextBox()
        txtNotes.Font = New Font("Segoe UI", 11)
        txtNotes.Size = New Size(400, 80)
        txtNotes.Location = New Point(20, 380)
        txtNotes.Multiline = True
        txtNotes.Text = "Additional Notes"

        Dim btnSave As New Button()
        btnSave.Text = "💾  Save Consultation"
        btnSave.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnSave.BackColor = Color.FromArgb(26, 115, 232)
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Size = New Size(200, 45)
        btnSave.Location = New Point(20, 480)

        Dim btnPrint As New Button()
        btnPrint.Text = "🖨️  Print Prescription"
        btnPrint.Font = New Font("Segoe UI", 12)
        btnPrint.BackColor = Color.FromArgb(52, 168, 83)
        btnPrint.ForeColor = Color.White
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Size = New Size(200, 45)
        btnPrint.Location = New Point(240, 480)

        consultationPanel.Controls.Add(btnPrint)
        consultationPanel.Controls.Add(btnSave)
        consultationPanel.Controls.Add(txtNotes)
        consultationPanel.Controls.Add(txtPrescription)
        consultationPanel.Controls.Add(txtTreatment)
        consultationPanel.Controls.Add(txtDiagnosis)
        consultationPanel.Controls.Add(lblConsultTitle)

        mainLayout.Controls.Add(patientPanel, 0, 0)
        mainLayout.Controls.Add(consultationPanel, 1, 0)

        Me.Controls.Add(mainLayout)
    End Sub
End Class