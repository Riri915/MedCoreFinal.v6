Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class UC_PATIENTQUEUE
    Private timerRefresh As New Timer()

    Private Sub UC_PATIENTQUEUE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleDataGridView()
        RefreshQueueDisplay()

        timerRefresh.Interval = 3000
        AddHandler timerRefresh.Tick, AddressOf TimerRefresh_Tick
        timerRefresh.Start()
    End Sub

    Private Sub StyleDataGridView()
        dgvQueue.DefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Regular)
        dgvQueue.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        dgvQueue.RowTemplate.Height = 60
        dgvQueue.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219)
        dgvQueue.DefaultCellStyle.SelectionForeColor = Color.White
        dgvQueue.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250)

        dgvQueue.EnableHeadersVisualStyles = False
        dgvQueue.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
        dgvQueue.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvQueue.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvQueue.GridColor = Color.FromArgb(230, 230, 230)
        dgvQueue.Dock = DockStyle.Fill
        dgvQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub RefreshQueueDisplay()
        If InvokeRequired Then
            Invoke(New MethodInvoker(AddressOf RefreshQueueDisplay))
            Return
        End If

        Dim dt As DataTable = DatabaseHelper.GetWaitingPatients()

        dgvQueue.Rows.Clear()
        For Each row As DataRow In dt.Rows
            dgvQueue.Rows.Add(row("ID"), row("Name"), row("Concern"), row("Status"))
        Next

        lblPatientCount.Text = "Waiting: " & dt.Rows.Count.ToString()
    End Sub

    Private Sub dgvQueue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQueue.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim queueNumber As String = dgvQueue.Rows(e.RowIndex).Cells(0).Value.ToString()
            Dim patientName As String = dgvQueue.Rows(e.RowIndex).Cells(1).Value.ToString()

            Dim result As DialogResult = MessageBox.Show($"Call patient {patientName} (Queue #{queueNumber}) for consultation?",
                                                         "Call Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                DatabaseHelper.UpdatePatientStatus(queueNumber, "In progress")
                RefreshQueueDisplay()

                Dim parentForm As DOCTORPAGES = TryCast(Me.ParentForm, DOCTORPAGES)
                If parentForm IsNot Nothing Then
                    parentForm.LoadConsultationWithPatient(queueNumber)
                End If
            End If
        End If
    End Sub

    Private Sub TimerRefresh_Tick(sender As Object, e As EventArgs)
        RefreshQueueDisplay()
    End Sub
End Class