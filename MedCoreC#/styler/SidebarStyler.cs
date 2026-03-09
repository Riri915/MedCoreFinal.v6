using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace MedCoreC_
{
    public static class SidebarStyler
    {
        private static Button _activeButton;

        public static void ApplySidebar(Panel sidebar)
        {
            EnableDoubleBuffer(sidebar);

            sidebar.Paint += Sidebar_Paint;

            foreach (Control c in sidebar.Controls)
            {
                if (c is Button btn)
                    StyleButton(btn);
            }
        }

        private static void Sidebar_Paint(object sender, PaintEventArgs e)
        {
            Panel sidebar = (Panel)sender;

            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    sidebar.ClientRectangle,
                    Color.FromArgb(45, 85, 200),
                    Color.FromArgb(110, 175, 255),
                    LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, sidebar.ClientRectangle);
            }
        }

        private static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;

            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(18, 0, 0, 0);
            btn.Height = 42;
            btn.Cursor = Cursors.Hand;

            btn.Click += (s, e) => SetActive(btn);
            btn.Paint += DrawButtonHighlight;
        }

        public static void SetActive(Button btn)
        {
            if (_activeButton != null)
                _activeButton.Invalidate();

            _activeButton = btn;
            btn.Invalidate();
        }

        private static void DrawButtonHighlight(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != _activeButton) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                4, 4,
                btn.Width - 8,
                btn.Height - 8);

            using (GraphicsPath path = RoundedRect(rect, 10))
            using (Pen pen = new Pen(Color.FromArgb(200, 220, 255), 2))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static void EnableDoubleBuffer(Control c)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(c, true, null);
        }
    }
}
