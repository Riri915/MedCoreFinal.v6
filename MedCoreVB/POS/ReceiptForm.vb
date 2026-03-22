Public Class ReceiptForm
    Public Property TransactionID As String
    Public Property CashierFirstName As String
    Public Property CashierLastName As String
    Public Property Payment As Decimal
    Public Property Change As Decimal
    Public Property Total As Decimal
    Public Property ItemsTable As DataTable

    Private Sub ReceiptForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDateTime.Text = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
        lblTransactionID.Text = If(String.IsNullOrWhiteSpace(TransactionID), "-", TransactionID)

        Dim fullName As String = (CashierFirstName & " " & CashierLastName).Trim()
        lblCashier.Text = If(String.IsNullOrWhiteSpace(fullName), "-", fullName)

        lblPayment.Text = "₱" & Payment.ToString("N2")
        lblChange.Text = "₱" & Change.ToString("N2")
        lblTotal.Text = "₱" & Total.ToString("N2")

        Try
            If ItemsTable IsNot Nothing AndAlso ItemsTable.Rows.Count > 0 Then
                dgvItems.DataSource = ItemsTable

                If dgvItems.Columns.Contains("ProductName") Then
                    dgvItems.Columns("ProductName").HeaderText = "Item"
                    dgvItems.Columns("ProductName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

                If dgvItems.Columns.Contains("Subtotal") Then
                    dgvItems.Columns("Subtotal").HeaderText = "Subtotal"
                    dgvItems.Columns("Subtotal").DefaultCellStyle.Format = "N2"
                    dgvItems.Columns("Subtotal").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Else
                Dim dt As New DataTable()
                dt.Columns.Add("Item")
                dt.Columns.Add("Subtotal")
                dgvItems.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading receipt items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dgvItems.ReadOnly = True
        dgvItems.AllowUserToAddRows = False
        dgvItems.AllowUserToResizeRows = False
        dgvItems.RowHeadersVisible = False
        dgvItems.ColumnHeadersVisible = False
        dgvItems.BorderStyle = BorderStyle.None
        dgvItems.BackgroundColor = Me.BackColor

        AdjustFormHeight()
    End Sub

    Private Sub AdjustFormHeight()
        Dim baseHeight As Integer = 400
        Dim rowHeight As Integer = 25

        Dim itemCount As Integer = 0
        If ItemsTable IsNot Nothing Then
            itemCount = Math.Max(ItemsTable.Rows.Count, 0)
        End If

        Dim newHeight As Integer = baseHeight + (itemCount * rowHeight)
        If newHeight > 800 Then newHeight = 800

        Me.Height = newHeight
    End Sub

    Private Sub AdjustPanelHeight()
        Dim baseHeight As Integer = 420
        Dim rowHeight As Integer = dgvItems.RowTemplate.Height
        Dim itemCount As Integer = If(ItemsTable IsNot Nothing, ItemsTable.Rows.Count, 0)
        Dim newHeight As Integer = baseHeight + (rowHeight * itemCount)

        If newHeight > 900 Then newHeight = 900
        If newHeight < baseHeight Then newHeight = baseHeight

        Panel1.Height = newHeight
        Me.Height = newHeight + 40
    End Sub
End Class