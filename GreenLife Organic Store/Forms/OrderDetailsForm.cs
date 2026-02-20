using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class OrderDetailsForm : Form
    {
        private Order _order = null!;

        public OrderDetailsForm()
        {
            InitializeComponent();
            this.Text = "Order Details";
            this.Size = new Size(700, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = FormThemeManager.Background;
            this.ForeColor = FormThemeManager.TextColor;
            this.DoubleBuffered = true;
            if (!DesignMode)
                this.Load += OrderDetailsForm_Load;
        }

        public OrderDetailsForm(Order order) : this()
        {
            _order = order;
            this.Text = $"Order Details - {order.OrderNumber}";
        }

        private void OrderDetailsForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            if (_order != null)
                lblOrderHeader.Text = $"Order #{_order.OrderNumber}";
            LoadOrderData();
            FormThemeManager.ApplyToForm(this);
            void CenterCloseButton()
            {
                try
                {
                    btnClose.Left = Math.Max(10, (pnlMain.Width - btnClose.Width) / 2);
                }
                catch { }
            }
            CenterCloseButton();
            pnlMain.Resize += (s, _) => CenterCloseButton();
        }

        private void PnlProgress_Paint(object? sender, PaintEventArgs e)
        {
            if (pnlProgress == null) return;
            DrawProgressBar(e.Graphics, pnlProgress.ClientRectangle, _order?.Status ?? OrderStatus.Pending);
        }

        private void BtnClose_Click(object? sender, EventArgs e) => Close();

        private void LoadOrderData()
        {
            if (_order == null) return;

            lblOrderDate.Text = _order.OrderDate.ToString("dd/MM/yyyy HH:mm");
            lblStatus.Text = _order.GetStatusText();
            lblTotal.Text = _order.GetFormattedTotal();
            lblName.Text = _order.CustomerName;
            lblPhone.Text = _order.CustomerPhone;
            lblEmail.Text = _order.CustomerEmail;
            lblAddress.Text = _order.ShippingAddress;

            dgvItems.Rows.Clear();
            foreach (var item in _order.Items)
            {
                dgvItems.Rows.Add(
                    item.ProductName,
                    item.Quantity,
                    $"Rs. {item.UnitPrice:N2}",
                    $"Rs. {item.Subtotal:N2}"
                );
            }

            pnlProgress.Invalidate();
        }
        private void DrawProgressBar(Graphics g, Rectangle rect, OrderStatus status)
        {
            // Create status indicators
            string[] statuses = { "Pending", "Processing", "Shipped", "Delivered" };
            int statusIndex = (int)status;

            // Prepare drawing
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // leave extra left margin to avoid overlapping left-side labels/icons
            int startX = rect.Left + 40;
            int available = Math.Max(10, rect.Width - 80);
            int spacing = Math.Max(1, available / Math.Max(1, statuses.Length));
            // Limit spacing to a reasonable max so labels don't overflow
            spacing = Math.Min(spacing, 180);
            int circleRadius = 8;
            int y = rect.Top + rect.Height / 2 - 6;

            using (var penActive = new Pen(Color.FromArgb(34, 139, 34), 3))
            using (var penInactive = new Pen(Color.LightGray, 3))
            using (var brushActive = new SolidBrush(Color.FromArgb(34, 139, 34)))
            using (var brushInactive = new SolidBrush(Color.LightGray))
            using (var textBrush = new SolidBrush(Color.FromArgb(34,34,34)))
            {
                for (int i = 0; i < statuses.Length; i++)
                {
                    int x = startX + (i * spacing);

                    if (i < statuses.Length - 1)
                    {
                        g.DrawLine(i < statusIndex ? penActive : penInactive, x + circleRadius, y, x + spacing - circleRadius, y);
                    }

                    g.FillEllipse(i <= statusIndex ? brushActive : brushInactive, x - circleRadius, y - circleRadius, circleRadius * 2, circleRadius * 2);

                    // Draw status text below the indicators using a compact font
                    using (var textFont = new Font("Segoe UI", 8F))
                    {
                        var textSize = g.MeasureString(statuses[i], textFont);
                        g.DrawString(statuses[i], textFont, textBrush, x - (textSize.Width / 2), y + circleRadius + 6);
                    }
                }
            }
        }
    }
}
