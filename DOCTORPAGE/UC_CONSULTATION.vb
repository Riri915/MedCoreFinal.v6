Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class UC_CONSULTATION
    Private currentQueueNumber As String = ""
    Private timerAutoSave As New Timer()
    Private currentServiceCode As String = ""
    Private currentServicePrice As Decimal = 0
    Private currentServiceName As String = ""

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
            currentServiceName = ConsultationSession("ServiceName").ToString()
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
            currentServiceCode,
            currentServiceName
        )
    End Sub

    Private Sub AutoSaveTimer_Tick(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            SaveToSession()
        End If
    End Sub

    ' ==================== SET CURRENT PATIENT WITH AUTO TRANSACTION ====================

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

            ' Get service code based on service type from database
            currentServiceCode = DatabaseHelper.GetServiceCodeByConcern(TextBox2.Text)
            currentServiceName = DatabaseHelper.GetServiceName(currentServiceCode)
            currentServicePrice = DatabaseHelper.GetServicePrice(currentServiceCode)

            ' AUTO GENERATE TRANSACTION NUMBER
            GenerateTransactionNumber()

            RichTextBox1.Clear()
            RichTextBox2.Clear()
            SaveToSession()
        End If
    End Sub

    ' ==================== AUTO GENERATE TRANSACTION NUMBER ====================

    Private Sub GenerateTransactionNumber()
        If String.IsNullOrEmpty(currentServiceCode) Then
            txtTransactionNo.Text = ""
            Return
        End If

        ' Use service code as transaction number
        Dim transNo As String = currentServiceCode

        ' Check if transaction already exists today
        Dim checkSql As String = "SELECT COUNT(*) FROM billing_transactions WHERE transaction_number = @TransNo"
        Dim checkParams As New List(Of MySqlParameter) From {New MySqlParameter("@TransNo", transNo)}
        Dim exists As Integer = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkSql, checkParams))

        If exists > 0 Then
            ' Add count if duplicate
            Dim countSql As String = "SELECT COUNT(*) FROM billing_transactions WHERE service_code = @Code"
            Dim countParams As New List(Of MySqlParameter) From {New MySqlParameter("@Code", currentServiceCode)}
            Dim count As Integer = Convert.ToInt32(DatabaseHelper.ExecuteScalar(countSql, countParams))
            transNo = currentServiceCode & "-" & (count + 1).ToString()
        End If

        txtTransactionNo.Text = transNo

        ' Save to billing_transactions
        Dim sql As String = "INSERT INTO billing_transactions (transaction_number, queue_number, patient_name, " &
                           "service_type, service_code, amount) VALUES (@TransNo, @QueueNo, @Name, @Service, @Code, @Amount)"
        Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@TransNo", transNo),
            New MySqlParameter("@QueueNo", currentQueueNumber),
            New MySqlParameter("@Name", TextBox1.Text),
            New MySqlParameter("@Service", TextBox2.Text),
            New MySqlParameter("@Code", currentServiceCode),
            New MySqlParameter("@Amount", currentServicePrice)
        }

        DatabaseHelper.ExecuteNonQuery(sql, params)

        ' Update patient_queue with transaction number
        Dim updateSql As String = "UPDATE patient_queue SET transaction_number = @TransNo, amount = @Amount " &
                                 "WHERE queue_number = @QueueNo"
        Dim updateParams As New List(Of MySqlParameter) From {
            New MySqlParameter("@TransNo", transNo),
            New MySqlParameter("@Amount", currentServicePrice),
            New MySqlParameter("@QueueNo", currentQueueNumber)
        }
        DatabaseHelper.ExecuteNonQuery(updateSql, updateParams)
    End Sub

    ' ==================== CALL NEXT PATIENT (AUTO GENERATE TRANSACTION) ====================

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

            MessageBox.Show($"Patient {row("Name")} is now in consultation!{vbCrLf}" &
                           $"Transaction Code: {txtTransactionNo.Text}{vbCrLf}" &
                           $"Amount: ₱{currentServicePrice:N2}",
                           "Patient Called", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No waiting patients in queue!", "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' ==================== PRINT BILL ====================

    Private Sub btnPrintBill_Click(sender As Object, e As EventArgs) Handles btnPrintBill.Click
        If String.IsNullOrWhiteSpace(txtTransactionNo.Text) Then
            MessageBox.Show("No transaction to print! Please call a patient first.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, AddressOf PrintBillPage
        printDoc.Print()
    End Sub

    Private Sub PrintBillPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim font As New Font("Arial", 12)
        Dim boldFont As New Font("Arial", 18, FontStyle.Bold)
        Dim titleFont As New Font("Arial", 14, FontStyle.Bold)
        Dim smallFont As New Font("Arial", 8)
        Dim y As Integer = 80

        ' Clinic Header
        e.Graphics.DrawString("MEDCORE CLINIC", boldFont, Brushes.Black, 140, 30)
        e.Graphics.DrawString("123 Health Street, Manila", smallFont, Brushes.Black, 130, 65)
        y = 100

        ' Draw Border Box
        Dim borderRect As New Rectangle(50, y, 300, 120)
        e.Graphics.DrawRectangle(New Pen(Color.Black, 2), borderRect)

        ' Transaction Code inside box
        e.Graphics.DrawString("TRANSACTION CODE:", font, Brushes.Black, 110, y + 20)
        e.Graphics.DrawString(txtTransactionNo.Text, boldFont, Brushes.DarkBlue, 120, y + 55)

        y = 240

        ' Patient Information
        e.Graphics.DrawString("Patient: " & TextBox1.Text, font, Brushes.Black, 50, y)
        y += 25
        e.Graphics.DrawString("Service: " & TextBox2.Text, font, Brushes.Black, 50, y)
        y += 25
        e.Graphics.DrawString("Amount: ₱" & currentServicePrice.ToString("N2"), font, Brushes.Black, 50, y)
        y += 35

        ' Divider
        e.Graphics.DrawLine(New Pen(Color.LightGray, 1), 50, y, 350, y)
        y += 20

        ' Thank You Message
        e.Graphics.DrawString("Thank you for choosing MEDCORE!", titleFont, Brushes.DarkGreen, 70, y)
        y += 35
        e.Graphics.DrawString("Please present this code to the cashier.", smallFont, Brushes.Gray, 70, y)
        y += 25
        e.Graphics.DrawString("Transaction Code: " & txtTransactionNo.Text, font, Brushes.Black, 70, y)

        ' Footer
        y = 340
        e.Graphics.DrawString("This is your official transaction slip.", smallFont, Brushes.Gray, 60, y)
    End Sub

    ' ==================== REGENERATE TRANSACTION (Optional) ====================



    ' ==================== SAVE CONSULTATION ====================

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
        currentServiceName = ""
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