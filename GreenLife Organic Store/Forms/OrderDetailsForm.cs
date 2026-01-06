using GreenLife_Organic_Store.Models;

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

            // Order Header
            Label lblOrderHeader = new Label
            {
                Text = $"Order #{_order.OrderNumber}",
                Location = new Point(10, yPosition),
                Size = new Size(300, 25),
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkGreen
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
            Label lblStatusLabel = new Label { Text = "Status:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            Label lblStatus = new Label
            {
                Name = "lblStatus",
                Location = new Point(120, yPosition),
                Size = new Size(200, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            this.Controls.Add(lblStatusLabel);
            this.Controls.Add(lblStatus);
            yPosition += 30;

            // Status Tracking Progress
            Panel pnlProgress = new Panel
            {
                Location = new Point(10, yPosition),
                Size = new Size(680, 50),
                BorderStyle = BorderStyle.FixedSingle
            };

            DrawProgressBar(pnlProgress, _order.Status);
            this.Controls.Add(pnlProgress);
            yPosition += 60;

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
                Size = new Size(680, 150),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackColor = Color.White
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
                ForeColor = Color.DarkGreen
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
                ForeColor = Color.DarkGreen
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
                AutoSize = true
            };
            this.Controls.Add(lblAddressLabel);
            this.Controls.Add(lblAddress);

            // Close button
            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(300, 580),
                Size = new Size(100, 35),
                BackColor = Color.LightGray
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
        }

        private void DrawProgressBar(Panel panel, OrderStatus status)
        {
            // Create status indicators
            string[] statuses = { "Pending", "Processing", "Shipped", "Delivered" };
            int statusIndex = (int)status;

            // Draw circles and lines
            using (Graphics g = panel.CreateGraphics())
            {
                int startX = 20;
                int spacing = 150;
                int circleRadius = 10;
                int y = 25;

                for (int i = 0; i < statuses.Length; i++)
                {
                    int x = startX + (i * spacing);

                    // Draw line to next circle
                    if (i < statuses.Length - 1)
                    {
                        Pen linePen = new Pen(i < statusIndex ? Color.Green : Color.LightGray, 3);
                        g.DrawLine(linePen, x + circleRadius, y, x + spacing - circleRadius, y);
                    }

                    // Draw circle
                    Brush circleBrush = i <= statusIndex ? Brushes.Green : Brushes.LightGray;
                    g.FillEllipse(circleBrush, x - circleRadius, y - circleRadius, circleRadius * 2, circleRadius * 2);

                    // Draw text
                    g.DrawString(statuses[i], this.Font, Brushes.Black, x - 25, y + 15);
                }
            }
        }
    }
}
