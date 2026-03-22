Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class ReturnPage
    Public Property CurrentCashierName As String
    Private connStr As String = "server=localhost;userid=root;password=;database=medcore"

    Private Sub ReturnPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FrostedPanelStyler.ApplyGradient(Panel1)
        InfoPanelStyler.MakeLabelTransparent(Label1, Panel1)

        If Not String.IsNullOrEmpty(CurrentCashierName) Then
            txtCashierName.Text = CurrentCashierName
            txtCashierName.ReadOnly = True
        End If

        cmbCondition.Items.Clear()
        cmbCondition.Items.AddRange(New String() {"Good", "Damaged", "Expired"})
        cmbCondition.SelectedIndex = 0

        txtRefund.ReadOnly = True
        Me.AcceptButton = btnConfirmReturn
        Me.CancelButton = btnCancel
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        CalculateRefund()
    End Sub

    Private Sub txtProductID_TextChanged(sender As Object, e As EventArgs) Handles txtProductID.TextChanged
        CalculateRefund()
    End Sub

    Private Sub CalculateRefund()
        txtRefund.Text = ""

        Dim prodID As String = txtProductID.Text.Trim()
        Dim qty As Integer

        If Not Integer.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            Return
        End If

        If Not Regex.IsMatch(prodID, "^\d{4}$") Then
            Return
        End If

        Dim unitPrice As Decimal = GetProductPrice(prodID)
        If unitPrice > 0 Then
            txtRefund.Text = (unitPrice * qty).ToString("0.00")
        End If
    End Sub

    Private Function GetProductPrice(productId As String) As Decimal
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim query As String = "SELECT UnitPrice FROM products WHERE ProductID = @pid LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@pid", productId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving price: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0D
    End Function

    Private Sub btnConfirmReturn_Click(sender As Object, e As EventArgs) Handles btnConfirmReturn.Click
        Dim transID As String = txtTransactionID.Text.Trim()
        Dim prodID As String = txtProductID.Text.Trim()
        Dim prodName As String = txtProductName.Text.Trim()
        Dim qtyText As String = txtQuantity.Text.Trim()
        Dim refundText As String = txtRefund.Text.Trim()
        Dim reason As String = txtReason.Text.Trim()
        Dim condition As String = cmbCondition.Text.Trim()

        If String.IsNullOrWhiteSpace(transID) OrElse
           String.IsNullOrWhiteSpace(prodID) OrElse
           String.IsNullOrWhiteSpace(prodName) OrElse
           String.IsNullOrWhiteSpace(qtyText) OrElse
           String.IsNullOrWhiteSpace(refundText) OrElse
           String.IsNullOrWhiteSpace(reason) OrElse
           String.IsNullOrWhiteSpace(condition) Then

            MessageBox.Show("All fields must be filled.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not Regex.IsMatch(transID, "^MC-\d+$") Then
            MessageBox.Show("Transaction ID must start with 'SB-' followed by numbers (e.g. SB-1001).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not Regex.IsMatch(prodID, "^\d{4}$") Then
            MessageBox.Show("Product ID must be exactly 4 digits (e.g. 1234).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim qty As Integer
        If Not Integer.TryParse(qtyText, qty) OrElse qty <= 0 Then
            MessageBox.Show("Quantity must be a valid positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim refund As Decimal
        If Not Decimal.TryParse(refundText, refund) OrElse refund < 0 Then
            MessageBox.Show("Refund amount must be a valid non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If reason.Length < 3 Then
            MessageBox.Show("Please enter a more detailed reason for return.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim authForm As New ReturnAuthorizationForm()
        authForm.ReturnParent = Me
        authForm.ShowDialog()
    End Sub

    Private Function CalculateRefundAmount(productId As String, qty As Integer) As Decimal
        Dim price As Decimal = GetProductPrice(productId)
        Dim refund As Decimal = price * qty
        txtRefund.Text = refund.ToString("0.00")
        Return refund
    End Function

    Public Sub ProcessReturn()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim qty As Integer = Integer.Parse(txtQuantity.Text)
                Dim refundAmount As Decimal = CalculateRefundAmount(txtProductID.Text, qty)
                Dim conditionStatus As String = If(cmbCondition.SelectedItem IsNot Nothing, cmbCondition.SelectedItem.ToString(), "Good")

                Dim insertSql As String = "
                    INSERT INTO return_transactions
                        (TransactionID, ProductID, ProductName, QuantityReturned, ConditionStatus, RefundAmount, ReasonForReturn, Cashier, ReturnDate)
                    VALUES
                        (@TransactionID, @ProductID, @ProductName, @QuantityReturned, @ConditionStatus, @RefundAmount, @ReasonForReturn, @Cashier, NOW());
                "

                Using cmd As New MySqlCommand(insertSql, conn)
                    cmd.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text.Trim())
                    cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim())
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim())
                    cmd.Parameters.AddWithValue("@QuantityReturned", qty)
                    cmd.Parameters.AddWithValue("@ConditionStatus", conditionStatus)
                    cmd.Parameters.AddWithValue("@RefundAmount", refundAmount)
                    cmd.Parameters.AddWithValue("@ReasonForReturn", txtReason.Text.Trim())
                    cmd.Parameters.AddWithValue("@Cashier", CurrentCashierName)
                    cmd.ExecuteNonQuery()
                End Using

                If conditionStatus = "Good" Then
                    Dim updateStock As String = "UPDATE products SET UnitInStock = UnitInStock + @qty WHERE ProductID = @pid"
                    Using cmd As New MySqlCommand(updateStock, conn)
                        cmd.Parameters.AddWithValue("@qty", qty)
                        cmd.Parameters.AddWithValue("@pid", txtProductID.Text.Trim())
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            MessageBox.Show("Return processed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error processing return: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearFields()
        txtTransactionID.Clear()
        txtProductID.Clear()
        txtProductName.Clear()
        txtQuantity.Clear()
        txtRefund.Clear()
        txtReason.Clear()
        cmbCondition.SelectedIndex = 0
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim result = MessageBox.Show("Clear all fields?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then ClearFields()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result = MessageBox.Show("Are you sure you want to cancel the return?", "Cancel Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRefund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRefund.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If
        If e.KeyChar = "."c AndAlso txtRefund.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCashierName_TextChanged(sender As Object, e As EventArgs) Handles txtCashierName.TextChanged

    End Sub
End Class
