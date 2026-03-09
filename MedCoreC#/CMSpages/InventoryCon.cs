using MedCoreC_.CMSpages;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MedCoreC_
{
    public partial class InventoryCon : UserControl
    {
        private readonly string connString =
            "server=localhost;user id=root;password=;database=medcore;";

        public InventoryCon()
        {
            InitializeComponent();
            LoadInventory();
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void LoadInventory(string keyword = "")
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        ProductID,
                        Barcode,
                        ProductName,
                        ExpirationDate,
                        UnitPrice,
                        UnitInStock
                    FROM products
                    WHERE ProductName LIKE @search
                       OR Barcode LIKE @search
                       OR ProductID LIKE @search
                    ORDER BY ProductName ASC;
                ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + keyword + "%");
                    DataTable dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    dgvInventory.DataSource = dt;
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadInventory(txtSearch.Text.Trim());
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            using (AddItem form = new AddItem())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadInventory(); 
                }
            }
        }



        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            string productId =
                dgvInventory.CurrentRow.Cells["ProductID"].Value.ToString();
            string productName =
                dgvInventory.CurrentRow.Cells["ProductName"].Value.ToString();

            string input = ShowInputDialog("Stock Entry", "Enter quantity to add:");
            if (!int.TryParse(input, out int addQty) || addQty <= 0)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        string updateProduct = @"
                    UPDATE products
                    SET UnitInStock = UnitInStock + @qty
                    WHERE ProductID = @id;
                ";

                        using (var cmd = new MySqlCommand(updateProduct, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@qty", addQty);
                            cmd.Parameters.AddWithValue("@id", productId);
                            cmd.ExecuteNonQuery();
                        }

                        string insertStockIn = @"
                    INSERT INTO stock_in
                    (TransactionID, ProductID, ProductName, Quantity)
                    VALUES
                    (@tid, @pid, @pname, @qty);
                ";

                        using (var cmd = new MySqlCommand(insertStockIn, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@tid", GenerateTransactionId());
                            cmd.Parameters.AddWithValue("@pid", productId);
                            cmd.Parameters.AddWithValue("@pname", productName);
                            cmd.Parameters.AddWithValue("@qty", addQty);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Stock entry failed:\n" + ex.Message);
                        return;
                    }
                }
            }

            MessageBox.Show("Stock added and recorded successfully.");
            LoadInventory();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dgvInventory.EndEdit();

            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }

            try
            {
                string productId =
                    dgvInventory.CurrentRow.Cells["ProductID"].Value.ToString();

                string name =
                    dgvInventory.CurrentRow.Cells["ProductName"].Value.ToString();

                decimal price =
                    Convert.ToDecimal(dgvInventory.CurrentRow.Cells["UnitPrice"].Value);

                DateTime? exp =
                    dgvInventory.CurrentRow.Cells["ExpirationDate"].Value == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(dgvInventory.CurrentRow.Cells["ExpirationDate"].Value);

                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string query = @"
                UPDATE products
                SET 
                    ProductName = @name,
                    UnitPrice = @price,
                    ExpirationDate = @exp
                WHERE ProductID = @id;
            ";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@exp",
                            exp.HasValue ? (object)exp.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", productId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product updated successfully.");
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed:\n" + ex.Message);
            }
        }

        // 🔹 DELETE PRODUCT
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Select a product to delete.");
                return;
            }

            if (MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            string productId =
                dgvInventory.CurrentRow.Cells["ProductID"].Value.ToString();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM products WHERE ProductID = @id;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadInventory();
        }

        private void InventoryCon_Load(object sender, EventArgs e)
        {
            ConfigureGridEditability();

            LabelPanelGradientStyler.Apply(labelPanel);
            ActivityLogGridStyler.Apply(dgvInventory);
            ActivityLogGridStyler.ApplyRoundedEdges(panelDGV);
        }
        private string ShowInputDialog(string title, string prompt)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = prompt;
            textBox.Width = 200;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 10, 372, 13);
            textBox.SetBounds(12, 30, 372, 20);
            buttonOk.SetBounds(228, 60, 75, 23);
            buttonCancel.SetBounds(309, 60, 75, 23);

            label.AutoSize = true;
            form.ClientSize = new System.Drawing.Size(396, 100);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
        private void ConfigureGridEditability()
        {
            dgvInventory.ReadOnly = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            dgvInventory.Columns["ProductID"].ReadOnly = true;
            dgvInventory.Columns["Barcode"].ReadOnly = true;
            dgvInventory.Columns["UnitInStock"].ReadOnly = true;

            dgvInventory.Columns["ProductName"].ReadOnly = false;
            dgvInventory.Columns["ExpirationDate"].ReadOnly = false;
            dgvInventory.Columns["UnitPrice"].ReadOnly = false;

            dgvInventory.Columns["UnitPrice"].DefaultCellStyle.Format = "0.00";
            dgvInventory.Columns["ExpirationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
        private string GenerateTransactionId()
        {
            return "MDC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }


    }
}
