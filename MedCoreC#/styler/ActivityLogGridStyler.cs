using System.Drawing;
using System.Windows.Forms;

namespace MedCoreC_
{
    public static class ActivityLogGridStyler
    {
        public static void Apply(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = 38;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 120, 200);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.Padding =
                new Padding(10, 0, 0, 0);

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5f, FontStyle.Regular);
            grid.DefaultCellStyle.Padding =
                new Padding(10, 6, 10, 6);
            grid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(190, 225, 245);
            grid.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(235, 245, 252);

            grid.GridColor = Color.FromArgb(220, 230, 240);

            grid.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.RowTemplate.Height = 36;

            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;


        }
        public static void ApplyRoundedEdges(Panel panel, int radius = 16)
        {
            panel.Resize += (s, e) =>
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int d = radius * 2;
                    var r = panel.ClientRectangle;

                    path.AddArc(r.X, r.Y, d, d, 180, 90);
                    path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                    path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                    path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                    path.CloseFigure();

                    panel.Region = new Region(path);
                }
            };
        }

    }
}
