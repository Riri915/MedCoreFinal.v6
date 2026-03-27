Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class UC_CONSULTATION
    Private currentQueueNumber As String = ""
    Private timerAutoSave As New Timer()
    Private currentServiceCode As String = ""
    Private currentServicePrice As Decimal = 0

    Private Sub UC_CONSULTATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StylePanels()
        LoadSavedConsultation()

        timerAutoSave.Interval = 2000
        AddHandler timerAutoSave.Tick, AddressOf AutoSaveTimer_Tick
        timerAutoSave.Start()
    End Sub

    Private Sub StylePanels()
        AddHandler Panel1.Paint, AddressOf Panel_Paint
        AddHandler Panel2.Paint, AddressOf Panel_Paint
        AddHandler grpBilling.Paint, AddressOf GroupBox_Paint
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

    Private Sub GroupBox_Paint(sender As Object, e As PaintEventArgs)
        Dim groupBox As GroupBox = DirectCast(sender, GroupBox)
        e.Graphics.Clear(groupBox.BackColor)
        Using pen As New Pen(Color.FromArgb(52, 152, 219), 2)
            Dim rect As New Rectangle(0, 0, groupBox.Width - 1, groupBox.Height - 1)
            e.Graphics.DrawRectangle(pen, rect)
        End Using
    End Sub

    Public Sub LoadSavedConsultation()
        If ConsultationSession.ContainsKey("IsActive") AndAlso ConsultationSession("IsActive") Then
            currentQueueNumber = ConsultationSession("QueueNumber").ToString()
            TextBox1.Text = ConsultationSession("PatientName").ToString()
            TextBox2.Text = ConsultationSession("Concern").ToString()
            cmbGender.Text = ConsultationSession("Gender").ToString()
            txtAge.Text = ConsultationSession("Age").ToString()
            RichTextBox1.Text = ConsultationSession("Diagnosis").ToString()
            RichTextBox2.Text = ConsultationSession("Prescription").ToString()
            txtTransactionNo.Text = ConsultationSession("TransactionNumber").ToString()
            ComboBox1.Text = ConsultationSession("Status").ToString()
            currentServiceCode = ConsultationSession("ServiceCode").ToString()
            currentServicePrice = Convert.ToDecimal(ConsultationSession("Amount"))
        End If
    End Sub

    Private Sub SaveToSession()
        SaveConsultationToSession(
            currentQueueNumber,
            TextBox1.Text,
            TextBox2.Text,
            cmbGender.Text,
            txtAge.Text,
            RichTextBox1.Text,
            RichTextBox2.Text,
            currentServicePrice.ToString(),
            txtTransactionNo.Text,
            ComboBox1.Text,
            currentServiceCode
        )
    End Sub

    Private Sub AutoSaveTimer_Tick(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            SaveToSession()
        End If
    End Sub

    Public Sub SetCurrentPatient(queueNumber As String)
        currentQueueNumber = queueNumber
        Dim dt As DataTable = DatabaseHelper.GetPatientByQueueNumber(queueNumber)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            TextBox1.Text = row("patient_name").ToString()
            TextBox2.Text = row("service_type").ToString()
            cmbGender.Text = If(IsDBNull(row("gender")), "", row("gender").ToString())
            txtAge.Text = If(IsDBNull(row("age")), "", row("age").ToString())
            ComboBox1.Text = row("status").ToString()

            If Not IsDBNull(row("transaction_number")) Then
                txtTransactionNo.Text = row("transaction_number").ToString()
                currentServiceCode = ""
                currentServicePrice = 0
            Else
                txtTransactionNo.Clear()
            End If

            RichTextBox1.Clear()
            RichTextBox2.Clear()
            SaveToSession()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            SaveToSession()
        End If

        Dim dt As DataTable = DatabaseHelper.GetNextWaitingPatient()

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            SetCurrentPatient(row("ID").ToString())
            DatabaseHelper.UpdatePatientStatus(currentQueueNumber, "In progress")
            ComboBox1.Text = "In progress"

            MessageBox.Show($"Patient {row("Name")} is now in consultation!",
                           "Patient Called", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No waiting patients in queue!", "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnGenerateTransaction_Click(sender As Object, e As EventArgs) Handles btnGenerateTransaction.Click
        If String.IsNullOrWhiteSpace(currentQueueNumber) Then
            MessageBox.Show("No patient selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get service code based on concern
        currentServiceCode = DatabaseHelper.GetServiceCodeByConcern(TextBox2.Text)

        If String.IsNullOrEmpty(currentServiceCode) Then
            MessageBox.Show("Cannot determine service code for this concern!", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get price from database
        currentServicePrice = DatabaseHelper.GetServicePrice(currentServiceCode)
        Dim serviceName As String = DatabaseHelper.GetServiceName(currentServiceCode)

        ' Generate transaction
        Dim transNo As String = DatabaseHelper.CreateTransaction(currentQueueNumber, TextBox1.Text,
                                                                  currentServiceCode, serviceName, currentServicePrice)

        If Not String.IsNullOrEmpty(transNo) Then
            txtTransactionNo.Text = transNo
            SaveToSession()

            MessageBox.Show($"Transaction #{transNo} generated successfully! Amount: ₱{currentServicePrice:N2}",
                           "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnPrintBill_Click(sender As Object, e As EventArgs) Handles btnPrintBill.Click
        If String.IsNullOrWhiteSpace(txtTransactionNo.Text) Then
            MessageBox.Show("No transaction to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, AddressOf PrintBillPage
        printDoc.Print()
    End Sub

    Private Sub PrintBillPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim font As New Font("Arial", 12)
        Dim boldFont As New Font("Arial", 16, FontStyle.Bold)
        Dim smallFont As New Font("Arial", 8)
        Dim y As Integer = 100
        Dim lineHeight As Integer = 25

        ' Clinic Header
        e.Graphics.DrawString("MEDCORE CLINIC", boldFont, Brushes.Black, 150, 50)
        e.Graphics.DrawString("123 Health Street, Manila", smallFont, Brushes.Black, 130, 85)
        y += 40

        ' Transaction Number (Big and Bold)
        e.Graphics.DrawString("TRANSACTION NUMBER:", font, Brushes.Black, 80, y)
        y += 40
        e.Graphics.DrawString(txtTransactionNo.Text, boldFont, Brushes.DarkBlue, 80, y)
        y += 70

        ' Divider
        e.Graphics.DrawLine(New Pen(Color.LightGray, 1), 50, y, 350, y)
        y += 20

        ' Thank You Message
        e.Graphics.DrawString("Thank you for choosing MEDCORE!", font, Brushes.DarkGreen, 70, y)
        y += 40
        e.Graphics.DrawString("Please proceed to the cashier for payment.", smallFont, Brushes.Gray, 70, y)

        ' Footer
        y = 280
        e.Graphics.DrawString("This serves as your official transaction slip.", smallFont, Brushes.Gray, 60, y)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("No patient in consultation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim age As Integer
        If Not Integer.TryParse(txtAge.Text, age) Then
            MessageBox.Show("Please enter a valid age!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim updateSql As String = "UPDATE patient_queue SET gender = @Gender, age = @Age, " &
                                 "diagnosis = @Diagnosis, prescription = @Prescription " &
                                 "WHERE queue_number = @QueueNumber"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@Gender", cmbGender.Text),
            New MySqlParameter("@Age", age),
            New MySqlParameter("@Diagnosis", RichTextBox1.Text),
            New MySqlParameter("@Prescription", RichTextBox2.Text),
            New MySqlParameter("@QueueNumber", currentQueueNumber)
        }

        If DatabaseHelper.ExecuteNonQuery(updateSql, params) Then
            DatabaseHelper.UpdatePatientStatus(currentQueueNumber, "Done")
            MessageBox.Show("Consultation completed and saved!", "Success",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearConsultation()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearConsultation()
    End Sub

    Private Sub ClearConsultation()
        TextBox1.Clear()
        TextBox2.Clear()
        RichTextBox1.Clear()
        RichTextBox2.Clear()
        cmbGender.SelectedIndex = -1
        txtAge.Clear()
        txtTransactionNo.Clear()
        ComboBox1.SelectedIndex = -1
        currentQueueNumber = ""
        currentServiceCode = ""
        currentServicePrice = 0
        ClearConsultationSession()
    End Sub

    Private Sub AutoSaveOnTextChange(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged,
        cmbGender.SelectedIndexChanged, txtAge.TextChanged, RichTextBox1.TextChanged, RichTextBox2.TextChanged,
        ComboBox1.SelectedIndexChanged
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            SaveToSession()
        End If
    End Sub
End Class