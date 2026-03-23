using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MedCoreC_.CMSpages
{
    public partial class AddItem : Form
    {
        private readonly string connString =
            "server=localhost;user id=root;password=;database=medcore;";

        public string Barcode => txtBarcode.Text.Trim();
        public string ProductName => txtProductName.Text.Trim();
        public DateTime? ExpirationDate =>
            chkNoExpiration.Checked ? (DateTime?)null : dtpExpiration.Value.Date;
        public decimal UnitPrice { get; private set; }
        public int UnitInStock { get; private set; }
        public string ProductID =>
            Barcode.Length >= 4 ? Barcode.Substring(Barcode.Length - 4) : "";

        public AddItem()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (txtBarcode.Text.Length < 4)
            {
                MessageBox.Show("Barcode must be at least 4 digits.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price format.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Invalid stock quantity.");
                return;
            }

            UnitPrice = price;
            UnitInStock = stock;

            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM products WHERE Barcode = @barcode";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@barcode", Barcode);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("This barcode already exists.");
                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO products
                        (ProductID, Barcode, ProductName, ExpirationDate, UnitPrice, UnitInStock)
                        VALUES
                        (@pid, @barcode, @name, @exp, @price, @stock);
                    ";

                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", ProductID);
                        cmd.Parameters.AddWithValue("@barcode", Barcode);
                        cmd.Parameters.AddWithValue("@name", ProductName);
                        cmd.Parameters.AddWithValue("@exp",
                            ExpirationDate.HasValue ? (object)ExpirationDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@price", UnitPrice);
                        cmd.Parameters.AddWithValue("@stock", UnitInStock);
                        cmd.ExecuteNonQuery();
                    }
                }


                MessageBox.Show("Item added successfully!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to cancel?\nAny unsaved data will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void chkNoExpiration_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpiration.Enabled = !chkNoExpiration.Checked;
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            LabelPanelGradientStyler.Apply(labelPanel);
        }
    }
}
