Imports MySql.Data.MySqlClient

Public Class frmDiscountInfo
    Public CashierRef As CashierPanel
    Public Property DiscountType As String
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscountType.SelectedIndexChanged
        cmbDiscountType.Items.Add("PWD")
        cmbDiscountType.Items.Add("Senior Citizen")
        cmbDiscountType.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub frmDiscountInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbDiscountType.Items.Clear()
        cmbDiscountType.Items.Add("PWD")
        cmbDiscountType.Items.Add("Senior Citizen")
        cmbDiscountType.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub btnApplyDiscount_Click(sender As Object, e As EventArgs) Handles btnApplyDiscount.Click

        If cmbDiscountType.SelectedItem Is Nothing Or
       txtFirstName.Text = "" Or
       txtLastName.Text = "" Or
       txtIDNumber.Text = "" Then

            MessageBox.Show("Please complete all fields.")
            Exit Sub
        End If

        Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=POS")

        Dim query As String = "INSERT INTO discount_records 
    (DiscountType, FirstName, MiddleInitial, LastName, IDNumber, DateCreated)
    VALUES (@type, @fname, @mname, @lname, @id, NOW())"

        Dim cmd As New MySqlCommand(query, conn)

        cmd.Parameters.AddWithValue("@type", cmbDiscountType.SelectedItem.ToString())
        cmd.Parameters.AddWithValue("@fname", txtFirstName.Text)
        cmd.Parameters.AddWithValue("@mname", txtMiddleInitial.Text)
        cmd.Parameters.AddWithValue("@lname", txtLastName.Text)
        cmd.Parameters.AddWithValue("@id", txtIDNumber.Text)

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        If CashierRef IsNot Nothing Then
            CashierRef.ApplyDiscount(cmbDiscountType.SelectedItem.ToString())
        End If

        MessageBox.Show("20% Discount Applied Successfully!")

        Me.Close()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class