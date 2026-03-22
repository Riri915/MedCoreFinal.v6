Imports System.Collections.Specialized.BitVector32
Imports System.Data.SqlClient
Imports CoreLibrary
Imports MedCoreC_
Imports MySql.Data.MySqlClient

Public Class CashierPanel
    Private originalTotal As Decimal = 0
    Private discountAmount As Decimal = 0
    Public Property EmployeeID As String
    Public Property FirstNameValue As String
    Public Property LastNameValue As String
    Public Property Position As String

    Private connStr As String = "server=localhost;userid=root;password=;database=POS"
    Private isLoggingOut As Boolean = False

    Dim idleTime As Integer = 0
    Const MAX_IDLE As Integer = 180
    Private Sub LogoutUser()
        isLoggingOut = True
        IdleTimer.Stop()
        Timer1.Stop()
        Me.Hide()
        LoginForm.Show()
    End Sub
    Private Sub AnyUserActivity(sender As Object, e As EventArgs) _
    Handles Me.MouseMove, Me.MouseClick, Me.KeyDown, Me.KeyPress

        ResetIdle()
    End Sub
    Private Sub CashierPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.Bounds = Screen.PrimaryScreen.Bounds
        idleTime = 0
        IdleTimer.Interval = 1000
        IdleTimer.Start()
        Me.KeyPreview = True

        FrostedPanelStyler.ApplyGradient(Panel3)
        InfoPanelStyler.MakeLabelTransparent(Label2, Panel3)
        InfoPanelStyler.MakeLabelTransparent(datelabel, Panel3)

        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.Manual
        Me.Bounds = Screen.PrimaryScreen.WorkingArea
        txtQuantity.Text = "1"
        Timer1.Enabled = True
        IdleTimer.Enabled = True

        txtEmployeeID.Text = Session.EmployeeID
        FirstName.Text = Session.FirstName
        LastName.Text = Session.LastName
        txtPosition.Text = Session.Position

        dgvCart.Columns.Clear()
        With dgvCart.Columns
            .Add("colID", "ID")
            .Add("colProdID", "Product ID")
            .Add("colBarcode", "Barcode")
            .Add("colProdName", "Product Name")
            .Add("colExpiration", "Expiration Date")
            .Add("colPrice", "Unit Price")
            .Add("colQty", "Quantity")
            .Add("colSubtotal", "Subtotal")
            .Add("colStock", "Unit in Stock")
        End With

        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCart.MultiSelect = False
        dgvCart.ClearSelection()

        DataGridViewStyler.ApplyStyle(dgvCart)
        DataGridViewStyler.ApplyRoundedCorners(dgvCart)
    End Sub

    Private Sub IdleTimer_Tick(sender As Object, e As EventArgs) Handles IdleTimer.Tick
        idleTime += 1

        If idleTime >= MAX_IDLE Then
            MessageBox.Show("Session expired due to inactivity.", "Logged Out",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)

            LogoutUser()
        End If
    End Sub

    Private Sub ResetIdle()
        idleTime = 0
    End Sub

    Private Sub CashierPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ResetIdle()
    End Sub

    Private Sub CashierPanel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ResetIdle()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to log out?",
        "Confirm Logout",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )

        If result = DialogResult.Yes Then
            LogoutUser()
        End If
    End Sub

    Private Sub CashierPanel_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing AndAlso Not isLoggingOut Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit? You will be automatically logged out.", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then e.Cancel = True
        End If
    End Sub

    Private Sub addtocart_Click(sender As Object, e As EventArgs)
        If textProductID.Text = "" Or txtProductName.Text = "" Then
            MessageBox.Show("Please search and select a valid product first.")
            Exit Sub
        End If

        Dim prodID As String = textProductID.Text
        Dim prodName As String = txtProductName.Text
        Dim expiration As String = txtExpiration.Text
        Dim price As Decimal = Decimal.Parse(txtPrice.Text)
        Dim qty As Integer

        If Not Integer.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            qty = 1
            txtQuantity.Text = "1"
        End If

        Dim stock As Integer = Integer.Parse(txtStock.Text)
        Dim subtotal As Decimal = price * qty

        Dim existingRow As DataGridViewRow = Nothing
        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colProdID").Value IsNot Nothing AndAlso row.Cells("colProdID").Value.ToString() = prodID Then
                existingRow = row
                Exit For
            End If
        Next

        If existingRow IsNot Nothing Then
            Dim existingQty As Integer = Convert.ToInt32(existingRow.Cells("colQty").Value)
            Dim newQty As Integer = existingQty + qty
            If newQty > stock Then
                MessageBox.Show("Not enough stock available for this product.")
                Exit Sub
            End If
            existingRow.Cells("colQty").Value = newQty
            existingRow.Cells("colSubtotal").Value = newQty * price
        Else
            Dim rowID As Integer = dgvCart.Rows.Count + 1
            dgvCart.Rows.Add(rowID, prodID, txtBarcode.Text, prodName, expiration, price, qty, subtotal, stock)
        End If

        UpdateTotal()
        SearchBar.Clear()
        textProductID.Clear()
        txtProductName.Clear()
        txtExpiration.Clear()
        txtPrice.Clear()
        txtStock.Clear()
        txtStatus.Clear()
        txtQuantity.Text = "1"
    End Sub

    Private Sub dgvCart_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then
            dgvCart.ClearSelection()
            dgvCart.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub UpdateTotal()

        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.Cells("colSubtotal").Value IsNot Nothing Then
                total += Convert.ToDecimal(row.Cells("colSubtotal").Value)
            End If
        Next

        originalTotal = total

        Dim finalTotal As Decimal = originalTotal - discountAmount

        If finalTotal < 0 Then finalTotal = 0

        txtTotal.Text = finalTotal.ToString("F2")

    End Sub

    Private Sub SearchBar_TextChanged(sender As Object, e As EventArgs)
        Dim keyword As String = SearchBar.Text.Trim()

        Try
            Using conn As New MySqlConnection(connStr)

                Dim query As String = "
            SELECT * FROM products 
            WHERE Barcode = @kw 
               OR ProductID = @kw 
               OR ProductName LIKE CONCAT('%', @kw, '%')
            LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@kw", keyword)

                    conn.Open()

                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        If reader.Read() Then

                            txtBarcode.Text = reader("Barcode").ToString()
                            textProductID.Text = reader("ProductID").ToString()
                            txtProductName.Text = reader("ProductName").ToString()

                            If IsDBNull(reader("ExpirationDate")) Then
                                txtExpiration.Text = ""
                            Else
                                txtExpiration.Text = Convert.ToDateTime(reader("ExpirationDate")).ToString("yyyy-MM-dd")
                            End If

                            txtPrice.Text = Convert.ToDecimal(reader("UnitPrice")).ToString("F2")

                            Dim stockCount As Integer = Convert.ToInt32(reader("UnitInStock"))
                            txtStock.Text = stockCount.ToString()

                            If stockCount > 0 Then
                                txtStatus.Text = "In-stock"
                            Else
                                txtStatus.Text = "Out of stock"
                            End If

                        Else
                            ClearProductFields()
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        End Try

        If keyword = "" Then
            ClearProductFields()
        End If

    End Sub

    Private Sub ClearProductFields()
        txtBarcode.Clear()
        textProductID.Clear()
        txtProductName.Clear()
        txtExpiration.Clear()
        txtPrice.Clear()
        txtStock.Clear()
        txtStatus.Clear()
    End Sub

    Private Sub dgvCart_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvCart.Columns("colQty").Index Then
            Dim qty As Integer
            Dim unitPrice As Decimal
            If Integer.TryParse(dgvCart.Rows(e.RowIndex).Cells("colQty").Value.ToString(), qty) AndAlso
                Decimal.TryParse(dgvCart.Rows(e.RowIndex).Cells("colPrice").Value.ToString(), unitPrice) Then
                dgvCart.Rows(e.RowIndex).Cells("colSubtotal").Value = qty * unitPrice
                UpdateTotal()
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If dgvCart.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvCart.SelectedRows(0)
            Dim qtyInput As String = InputBox("Enter new quantity for " & row.Cells("colProdName").Value, "Edit Quantity")
            Dim newQty As Integer
            If Integer.TryParse(qtyInput, newQty) AndAlso newQty > 0 Then
                row.Cells("colQty").Value = newQty
                row.Cells("colSubtotal").Value = newQty * Convert.ToDecimal(row.Cells("colPrice").Value)
                UpdateTotal()
            Else
                MessageBox.Show("Invalid quantity.")
            End If
        Else
            MessageBox.Show("Please select a row to edit.")
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs)
        If dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to remove.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim authForm As New frmAdminAuth()
        If authForm.ShowDialog() = DialogResult.OK Then
            Dim itemName As String = dgvCart.SelectedRows(0).Cells("colProdName").Value.ToString()
            Dim confirmResult As DialogResult = MessageBox.Show(
                "Are you sure you want to remove """ & itemName & """ from the cart?",
                "Confirm Remove",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            )
            If confirmResult = DialogResult.Yes Then
                dgvCart.Rows.Remove(dgvCart.SelectedRows(0))
                UpdateTotal()
                MessageBox.Show(itemName & " has been removed from the cart.", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtPayment_keypress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then e.Handled = True
        If e.KeyChar = "."c AndAlso txtPayment.Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub txtPayment_TextChanged(sender As Object, e As EventArgs)

        Dim total As Decimal = originalTotal - discountAmount
        Dim payment As Decimal

        If Decimal.TryParse(txtPayment.Text, payment) Then
            Dim change As Decimal = payment - total
            If payment < total Then
                txtChange.ForeColor = Color.Red
                txtChange.Text = "Invalid amount"
                btnCheckout.Enabled = False
            Else
                txtChange.ForeColor = Color.Black
                txtChange.Text = change.ToString("F2")
                btnCheckout.Enabled = True
            End If
        Else
            txtChange.Clear()
            btnCheckout.Enabled = False
        End If
    End Sub
    Private Sub btnCheckout_Click(sender As Object, e As EventArgs)

        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("Cart is empty. Add items first.")
            Exit Sub
        End If

        Dim total As Decimal = originalTotal - discountAmount
        Dim payment As Decimal
        Dim change As Decimal

        If Not Decimal.TryParse(txtPayment.Text, payment) Then
            MessageBox.Show("Invalid payment.")
            Exit Sub
        End If

        change = payment - total

        If payment < total Then
            MessageBox.Show("Insufficient payment.")
            Exit Sub
        End If

        Dim transactionID As String = "SB-" & DateTime.Now.ToString("yyyyMMddHHmmss")

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim queryTrans As String =
                "INSERT INTO transactions (TransactionID, CashierName, Total, Payment, ChangeAmt)
                 VALUES (@tid, @cashier, @total, @pay, @chg)"

                Using cmd As New MySqlCommand(queryTrans, conn)
                    cmd.Parameters.AddWithValue("@tid", transactionID)
                    cmd.Parameters.AddWithValue("@cashier", $"{FirstName.Text} {LastName.Text}")
                    cmd.Parameters.AddWithValue("@total", total)
                    cmd.Parameters.AddWithValue("@pay", payment)
                    cmd.Parameters.AddWithValue("@chg", change)
                    cmd.ExecuteNonQuery()
                End Using

                For Each row As DataGridViewRow In dgvCart.Rows
                    If Not row.IsNewRow Then

                        Dim prodID = row.Cells("colProdID").Value.ToString()
                        Dim itemName = row.Cells("colProdName").Value.ToString()
                        Dim qtySold = Convert.ToInt32(row.Cells("colQty").Value)
                        Dim price = Convert.ToDecimal(row.Cells("colPrice").Value)
                        Dim subtotal = Convert.ToDecimal(row.Cells("colSubtotal").Value)

                        Dim queryItem As String =
                        "INSERT INTO transaction_items (TransactionID, ItemName, Quantity, Price, Subtotal)
                         VALUES (@tid, @iname, @qty, @price, @sub)"

                        Using cmd As New MySqlCommand(queryItem, conn)
                            cmd.Parameters.AddWithValue("@tid", transactionID)
                            cmd.Parameters.AddWithValue("@iname", itemName)
                            cmd.Parameters.AddWithValue("@qty", qtySold)
                            cmd.Parameters.AddWithValue("@price", price)
                            cmd.Parameters.AddWithValue("@sub", subtotal)
                            cmd.ExecuteNonQuery()
                        End Using

                        Dim deductQuery As String =
                        "UPDATE products SET UnitInStock = UnitInStock - @qty WHERE ProductID = @pid"

                        Using cmd As New MySqlCommand(deductQuery, conn)
                            cmd.Parameters.AddWithValue("@qty", qtySold)
                            cmd.Parameters.AddWithValue("@pid", prodID)
                            cmd.ExecuteNonQuery()
                        End Using

                    End If
                Next
            End Using
            dgvCart.Rows.Clear()
            txtTotal.Clear()
            txtPayment.Clear()
            txtChange.Clear()

            originalTotal = 0
            discountAmount = 0

            btnCheckout.Enabled = False

            MessageBox.Show("Transaction completed successfully!")

        Catch ex As Exception
            MessageBox.Show("Checkout failed: " & ex.Message)
        End Try
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs)
        Dim returnForm As New ReturnPage()
        returnForm.CurrentCashierName = $"{FirstName.Text.Trim()} {LastName.Text.Trim()}"
        returnForm.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        datelabel.Text = DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss")
    End Sub

    Private Sub txtQuantity_keypressed(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click

        Dim frm As New frmAdminAuth()

        If frm.ShowDialog() = DialogResult.OK Then

            Dim selectFrm As New frmDiscountInfo()
            selectFrm.CashierRef = Me
            selectFrm.ShowDialog()

        Else
            MessageBox.Show("Admin authentication required!", "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Public Sub ApplyDiscount(discountType As String)

        If originalTotal <= 0 Then
            MessageBox.Show("Cart is empty.")
            Exit Sub
        End If

        If discountAmount > 0 Then
            MessageBox.Show("Discount already applied!")
            Exit Sub
        End If

        Dim rate As Decimal = 0.2D
        discountAmount = originalTotal * rate

        Dim finalTotal As Decimal = originalTotal - discountAmount
        If finalTotal < 0 Then finalTotal = 0
        txtTotal.Text = finalTotal.ToString("F2")
        MessageBox.Show("Discount applied: -" & discountAmount.ToString("F2"))
    End Sub
End Class