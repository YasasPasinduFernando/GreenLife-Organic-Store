using GreenLife_Organic_Store.Models;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class OrderDetailsForm : Form
    {
        private Order _order = null!;

        public OrderDetailsForm()
        {
            this.Text = "Order Details";
            this.Size = new Size(700, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            // Improve visual theming to avoid default black backgrounds
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.ForeColor = Color.FromArgb(34, 34, 34);
            this.DoubleBuffered = true;
            this.Load += OrderDetailsForm_Load;
        }

        public OrderDetailsForm(Order order) : this()
        {
            _order = order;
            this.Text = $"Order Details - {order.OrderNumber}";
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadOrderData();
        }

        private void InitializeUI()
        {
            int yPosition = 10;
            // allow scrolling if content is taller than the window
            this.AutoScroll = true;

            // Order Header
            // Header icon
            IconPictureBox headerIcon = new IconPictureBox
            {
                IconChar = IconChar.ShoppingBag,
                IconColor = Color.FromArgb(34, 139, 34),
                IconSize = 28,
                Location = new Point(10, yPosition - 2),
                Size = new Size(34, 34),
                BackColor = Color.Transparent
            };
            this.Controls.Add(headerIcon);

            Label lblOrderHeader = new Label
            {
                Text = $"Order #{_order.OrderNumber}",
                Location = new Point(54, yPosition),
                AutoSize = true,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 139, 34),
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblOrderHeader);
            yPosition += 35;

            // Order Date
            Label lblOrderDateLabel = new Label { Text = "Order Date:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            Label lblOrderDate = new Label
            {
                Name = "lblOrderDate",
                Location = new Point(120, yPosition),
                Size = new Size(300, 20)
            };
            this.Controls.Add(lblOrderDateLabel);
            this.Controls.Add(lblOrderDate);
            yPosition += 30;

            // Status
            Label lblStatusLabel = new Label { Text = "Status:", Location = new Point(10, yPosition), AutoSize = true };
            Label lblStatus = new Label
            {
                Name = "lblStatus",
                Location = new Point(120, yPosition),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            this.Controls.Add(lblStatusLabel);
            this.Controls.Add(lblStatus);
            yPosition += 40; // add extra spacing so the progress indicators don't overlap the status label

            // Status Tracking Progress
            Panel pnlProgress = new Panel
            {
                Name = "pnlProgress",
                Location = new Point(10, yPosition),
                Size = new Size(680, 70),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White
            };

            // Paint progress in the panel to avoid CreateGraphics flicker/blank issues
            pnlProgress.Paint += (s, e) => DrawProgressBar(e.Graphics, pnlProgress.ClientRectangle, _order?.Status ?? OrderStatus.Pending);
            pnlProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(pnlProgress);
            yPosition += 80;

            // Items Section
            Label lblItemsHeader = new Label
            {
                Text = "ITEMS ORDERED",
                Location = new Point(10, yPosition),
                Size = new Size(300, 20),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            this.Controls.Add(lblItemsHeader);
            yPosition += 30;

            // Items DataGridView
            DataGridView dgvItems = new DataGridView
            {
                Name = "dgvItems",
                Location = new Point(10, yPosition),
                Size = new Size(680, 180),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                GridColor = Color.LightGray,
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = { BackColor = Color.FromArgb(230, 230, 230), ForeColor = Color.FromArgb(34,34,34) },
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            dgvItems.Columns.Add("ProductName", "Product");
            dgvItems.Columns.Add("Quantity", "Qty");
            dgvItems.Columns.Add("UnitPrice", "Unit Price");
            dgvItems.Columns.Add("Subtotal", "Subtotal");
            this.Controls.Add(dgvItems);
            yPosition += 160;

            // Total
            Label lblTotalLabel = new Label { Text = "Total:", Location = new Point(10, yPosition), Size = new Size(100, 25), Font = new Font("Arial", 12, FontStyle.Bold) };
            Label lblTotal = new Label
            {
                Name = "lblTotal",
                Location = new Point(120, yPosition),
                Size = new Size(300, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 139, 34),
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblTotalLabel);
            this.Controls.Add(lblTotal);
            yPosition += 40;

            // Delivery Information
            Label lblDeliveryHeader = new Label
            {
                Text = "DELIVERY INFORMATION",
                Location = new Point(10, yPosition),
                Size = new Size(300, 20),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 139, 34),
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblDeliveryHeader);
            yPosition += 30;

            // Customer Name
            Label lblNameLabel = new Label { Text = "Name:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            Label lblName = new Label
            {
                Name = "lblName",
                Location = new Point(120, yPosition),
                Size = new Size(400, 20)
            };
            this.Controls.Add(lblNameLabel);
            this.Controls.Add(lblName);
            yPosition += 25;

            // Phone
            Label lblPhoneLabel = new Label { Text = "Phone:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            Label lblPhone = new Label
            {
                Name = "lblPhone",
                Location = new Point(120, yPosition),
                Size = new Size(400, 20)
            };
            this.Controls.Add(lblPhoneLabel);
            this.Controls.Add(lblPhone);
            yPosition += 25;

            // Email
            Label lblEmailLabel = new Label { Text = "Email:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            Label lblEmail = new Label
            {
                Name = "lblEmail",
                Location = new Point(120, yPosition),
                Size = new Size(400, 20)
            };
            this.Controls.Add(lblEmailLabel);
            this.Controls.Add(lblEmail);
            yPosition += 25;

            // Address
            Label lblAddressLabel = new Label { Text = "Address:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            Label lblAddress = new Label
            {
                Name = "lblAddress",
                Location = new Point(120, yPosition),
                Size = new Size(400, 60),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblAddressLabel);
            this.Controls.Add(lblAddress);

            // Move yPosition past the address so the Close button sits well below content
            yPosition = lblAddress.Bottom + 30;

            // Close button - place below all content and center
            Button btnClose = new Button
            {
                Text = "Close",
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnClose.Location = new Point(Math.Max(10, (this.ClientSize.Width - btnClose.Width) / 2), yPosition);
            btnClose.Anchor = AnchorStyles.Top;
            // keep horizontally centered when the form resizes
            this.Resize += (s, e) =>
            {
                try
                {
                    btnClose.Left = Math.Max(10, (this.ClientSize.Width - btnClose.Width) / 2);
                }
                catch { }
            };
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadOrderData()
        {
            Label lblOrderDate = (Label)this.Controls["lblOrderDate"];
            Label lblStatus = (Label)this.Controls["lblStatus"];
            DataGridView dgvItems = (DataGridView)this.Controls["dgvItems"];
            Label lblTotal = (Label)this.Controls["lblTotal"];
            Label lblName = (Label)this.Controls["lblName"];
            Label lblPhone = (Label)this.Controls["lblPhone"];
            Label lblEmail = (Label)this.Controls["lblEmail"];
            Label lblAddress = (Label)this.Controls["lblAddress"];

            lblOrderDate.Text = _order.OrderDate.ToString("dd/MM/yyyy HH:mm");
            lblStatus.Text = _order.GetStatusText();
            lblTotal.Text = _order.GetFormattedTotal();
            lblName.Text = _order.CustomerName;
            lblPhone.Text = _order.CustomerPhone;
            lblEmail.Text = _order.CustomerEmail;
            lblAddress.Text = _order.ShippingAddress;

            // Load items
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

            // Ensure progress panel repaints with updated status
            var pnl = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "pnlProgress") as Panel;
            pnl?.Invalidate();
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
