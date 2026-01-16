using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public class AdminDashboardEcommerce : Form
    {
        private User _currentAdmin;
        private Dictionary<string, Control> _controls = new();

        public AdminDashboardEcommerce(User admin)
        {
            _currentAdmin = admin;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.Text = "Admin Dashboard - GreenLife Organic Store";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.AutoScroll = true;
            this.AutoScrollMargin = new Size(20, 20);
            // Prevent maximizing the window
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += AdminDashboardEcommerce_Load;
        }

        private void AdminDashboardEcommerce_Load(object? sender, EventArgs? e)
        {
            try
            {
                this.Controls.Clear();
                _controls.Clear();
                InitializeUI();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUI()
        {
            // Header - KEEP AT TOP
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(34, 139, 34)
            };

            // Logo Icon
            IconPictureBox iconLogo = new IconPictureBox
            {
                IconChar = IconChar.Leaf,
                IconColor = Color.White,
                IconSize = 45,
                Location = new Point(15, 12),
                Size = new Size(45, 45),
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(iconLogo);

            Label lblHeader = new Label
            {
                Text = $"Admin Dashboard - Welcome, {_currentAdmin.Name}",
                Location = new Point(70, 22),
                Size = new Size(650, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(lblHeader);

            IconButton btnLogout = new IconButton
            {
                Text = "Logout",
                Location = new Point(870, 17),
                Size = new Size(110, 38),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                IconChar = IconChar.SignOutAlt,
                IconColor = Color.White,
                IconSize = 22,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => LogoutAdmin();
            pnlHeader.Controls.Add(btnLogout);

            // Header will be added after other top-docked panels so it appears above them

            // Menu Buttons Panel
            Panel pnlMenu = new Panel
            {
                Dock = DockStyle.Top,
                Height = 155,
                BackColor = Color.White,
                Padding = new Padding(15, 15, 15, 10)
            };

            CreateMenuButton(pnlMenu, "Manage Products", 15, 15, () => OpenManageProducts(), IconChar.BoxOpen, Color.FromArgb(46, 204, 113));
            CreateMenuButton(pnlMenu, "Manage Orders", 230, 15, () => OpenManageOrders(), IconChar.ShoppingCart, Color.FromArgb(52, 152, 219));
            CreateMenuButton(pnlMenu, "Manage Categories", 445, 15, () => OpenManageCategories(), IconChar.Tags, Color.FromArgb(155, 89, 182));
            CreateMenuButton(pnlMenu, "Manage Customers", 660, 15, () => OpenManageCustomers(), IconChar.UserFriends, Color.FromArgb(26, 188, 156));
            CreateMenuButton(pnlMenu, "Sales Reports", 15, 80, () => OpenSalesReports(), IconChar.ChartLine, Color.FromArgb(52, 73, 94));
            CreateMenuButton(pnlMenu, "Admin Registrations", 230, 80, () => OpenAdminRegistrations(), IconChar.UserShield, Color.FromArgb(230, 126, 34));

            this.Controls.Add(pnlMenu);

            // Content area with actions / quick info (placed before the stat cards)
            Panel pnlContent = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            Label lblContentTitle = new Label
            {
                Text = "Quick Actions",
                Location = new Point(10, 10),
                Size = new Size(200, 28),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                BackColor = Color.Transparent
            };
            pnlContent.Controls.Add(lblContentTitle);
            // Simple description under the title (buttons removed)
            Label lblContentNote = new Label
            {
                Text = "Use the menu below to access management sections and reports.",
                Location = new Point(10, 38),
                Size = new Size(700, 24),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(127, 140, 141),
                BackColor = Color.Transparent
            };
            pnlContent.Controls.Add(lblContentNote);

            // Add some visual separator
            Panel separator = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 6,
                BackColor = Color.FromArgb(200, 200, 200)
            };
            pnlContent.Controls.Add(separator);

            this.Controls.Add(pnlContent);

            // Statistics Panel
            Panel pnlStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 140,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(15, 10, 15, 10)
            };

            _controls["lblTotalProducts"] = CreateStatCard(pnlStats, "Total Products", 15, 10, "lblTotalProducts", IconChar.Cubes, Color.FromArgb(52, 152, 219));
            _controls["lblPendingOrders"] = CreateStatCard(pnlStats, "Pending Orders", 260, 10, "lblPendingOrders", IconChar.ClipboardList, Color.FromArgb(230, 126, 34));
            _controls["lblTotalCustomers"] = CreateStatCard(pnlStats, "Total Customers", 505, 10, "lblTotalCustomers", IconChar.Users, Color.FromArgb(155, 89, 182));
            _controls["lblLowStock"] = CreateStatCard(pnlStats, "Low Stock Items", 750, 10, "lblLowStock", IconChar.ExclamationTriangle, Color.FromArgb(231, 76, 60));

            this.Controls.Add(pnlStats);

            // Recent Orders
            Panel pnlRecent = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            Label lblRecent = new Label
            {
                Text = "Recent Orders",
                Location = new Point(15, 15),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlRecent.Controls.Add(lblRecent);

            DataGridView dgvRecent = new DataGridView
            {
                Name = "dgvRecent",
                Location = new Point(15, 55),
                Size = new Size(950, 250),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle 
                { 
                    BackColor = Color.FromArgb(52, 73, 94),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Padding = new Padding(5)
                },
                ColumnHeadersHeight = 40,
                RowTemplate = new DataGridViewRow { Height = 35 },
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(250, 250, 250) }
            };
            dgvRecent.Columns.Add("OrderNumber", "Order #");
            dgvRecent.Columns.Add("CustomerName", "Customer");
            dgvRecent.Columns.Add("Status", "Status");
            dgvRecent.Columns.Add("Amount", "Amount");
            dgvRecent.Columns.Add("Date", "Date");
            pnlRecent.Controls.Add(dgvRecent);
            _controls["dgvRecent"] = dgvRecent;

            this.Controls.Add(pnlRecent);

            // Add header last so its Dock=Top positions it above other top-docked panels
            this.Controls.Add(pnlHeader);
        }

        private Label CreateStatCard(Panel parent, string title, int x, int y, string labelName, IconChar iconChar, Color accentColor)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(230, 120),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Add subtle shadow effect with a border panel
            Panel shadowPanel = new Panel
            {
                Location = new Point(x + 3, y + 3),
                Size = new Size(230, 120),
                BackColor = Color.FromArgb(220, 220, 220)
            };
            parent.Controls.Add(shadowPanel);

            // Accent bar on the left
            Panel accentBar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(5, 120),
                BackColor = accentColor
            };
            card.Controls.Add(accentBar);

            // Icon
            IconPictureBox iconPic = new IconPictureBox
            {
                IconChar = iconChar,
                IconColor = accentColor,
                IconSize = 45,
                Location = new Point(15, 20),
                Size = new Size(45, 45),
                BackColor = Color.Transparent
            };
            card.Controls.Add(iconPic);

            Label lblTitle = new Label
            {
                Text = title,
                Location = new Point(70, 25),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(127, 140, 141)
            };
            card.Controls.Add(lblTitle);

            Label lblValue = new Label
            {
                Name = labelName,
                Text = "0",
                Location = new Point(70, 55),
                Size = new Size(150, 50),
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            card.Controls.Add(lblValue);

            parent.Controls.Add(card);
            card.BringToFront();

            return lblValue;
        }

        private void CreateMenuButton(Panel parent, string text, int x, int y, Action onClick, IconChar icon, Color buttonColor)
        {
            IconButton btn = new IconButton
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(210, 55),
                BackColor = buttonColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                TabStop = true,
                TabIndex = parent.Controls.Count,
                IconChar = icon,
                IconColor = Color.White,
                IconSize = 28,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) =>
            {
                try
                {
                    onClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            // Hover effect
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(buttonColor, 0.2f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = buttonColor;
            };
            
            parent.Controls.Add(btn);
        }

        private void LoadStatistics()
        {
            try
            {
                var allProducts = ProductRepository.GetAllProducts();
                var allOrders = OrderRepository.GetAllOrders();
                var allUsers = UserRepository.GetAllUsers();
                var lowStockProducts = ProductRepository.GetLowStockProducts();
                var pendingOrders = allOrders.Where(o => o.Status == OrderStatus.Pending).ToList();

                // Update stat cards
                if (_controls.TryGetValue("lblTotalProducts", out var ctrl1) && ctrl1 is Label lbl1)
                    lbl1.Text = allProducts.Count.ToString();

                if (_controls.TryGetValue("lblPendingOrders", out var ctrl2) && ctrl2 is Label lbl2)
                    lbl2.Text = pendingOrders.Count.ToString();

                if (_controls.TryGetValue("lblTotalCustomers", out var ctrl3) && ctrl3 is Label lbl3)
                    lbl3.Text = allUsers.Count(u => u.UserType == UserType.Customer).ToString();

                if (_controls.TryGetValue("lblLowStock", out var ctrl4) && ctrl4 is Label lbl4)
                    lbl4.Text = lowStockProducts.Count.ToString();

                // Load recent orders
                if (_controls.TryGetValue("dgvRecent", out var ctrl5) && ctrl5 is DataGridView dgvRecent)
                {
                    dgvRecent.Rows.Clear();

                    var recent = allOrders.OrderByDescending(o => o.OrderDate).Take(10).ToList();
                    foreach (var order in recent)
                    {
                        dgvRecent.Rows.Add(
                            order.OrderNumber,
                            order.CustomerName,
                            order.GetStatusText(),
                            order.GetFormattedTotal(),
                            order.OrderDate.ToString("dd/MM/yyyy")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenManageProducts()
        {
            try
            {
                ManageProductsForm form = new ManageProductsForm();
                form.ShowDialog();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenManageOrders()
        {
            try
            {
                ManageOrdersForm form = new ManageOrdersForm();
                form.ShowDialog();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenManageCategories()
        {
            try
            {
                ManageCategoriesForm form = new ManageCategoriesForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenManageCustomers()
        {
            try
            {
                ManageCustomersForm form = new ManageCustomersForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenSalesReports()
        {
            try
            {
                SalesReportForm form = new SalesReportForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Sales Reports: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAdminRegistrations()
        {
            try
            {
                AdminRegistrationsForm form = new AdminRegistrationsForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Admin Registrations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogoutAdmin()
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
