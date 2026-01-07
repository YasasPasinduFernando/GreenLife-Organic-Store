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
            this.Text = "Admin Dashboard - GreenLife Organic Store";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
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
            // Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(34, 139, 34)
            };
            Label lblHeader = new Label
            {
                Text = $"Admin Dashboard - Welcome, {_currentAdmin.Name}",
                Location = new Point(10, 10),
                Size = new Size(600, 30),
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White
            };
            Button btnLogout = new Button
            {
                Text = "Logout",
                Location = new Point(900, 10),
                Size = new Size(80, 30),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Arial", 10)
            };
            btnLogout.Click += (s, e) => LogoutAdmin();
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnLogout);
            this.Controls.Add(pnlHeader);

            // Statistics Panel
            Panel pnlStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            _controls["lblTotalProducts"] = CreateStatCard(pnlStats, "Total Products", 10, 10, "lblTotalProducts");
            _controls["lblPendingOrders"] = CreateStatCard(pnlStats, "Pending Orders", 210, 10, "lblPendingOrders");
            _controls["lblTotalCustomers"] = CreateStatCard(pnlStats, "Total Customers", 410, 10, "lblTotalCustomers");
            _controls["lblLowStock"] = CreateStatCard(pnlStats, "Low Stock Items", 610, 10, "lblLowStock");

            this.Controls.Add(pnlStats);

            // Menu Buttons Panel
            Panel pnlMenu = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            CreateMenuButton(pnlMenu, "?? Manage Products", 10, 10, () => OpenManageProducts());
            CreateMenuButton(pnlMenu, "?? Manage Orders", 220, 10, () => OpenManageOrders());
            CreateMenuButton(pnlMenu, "?? Manage Categories", 430, 10, () => OpenManageCategories());
            CreateMenuButton(pnlMenu, "?? Manage Customers", 640, 10, () => OpenManageCustomers());
            CreateMenuButton(pnlMenu, "?? Sales Reports", 10, 60, () => OpenSalesReports());
            // Add Admin Registrations log button
            CreateMenuButton(pnlMenu, "?? Admin Registrations", 220, 60, () => OpenAdminRegistrations());

            this.Controls.Add(pnlMenu);

            // Recent Orders
            Panel pnlRecent = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            Label lblRecent = new Label
            {
                Text = "Recent Orders (Last 10)",
                Location = new Point(10, 10),
                Size = new Size(400, 20),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            pnlRecent.Controls.Add(lblRecent);

            DataGridView dgvRecent = new DataGridView
            {
                Name = "dgvRecent",
                Location = new Point(10, 40),
                Size = new Size(960, 300),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackColor = Color.White,
                ForeColor = Color.Black,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray }
            };
            dgvRecent.Columns.Add("OrderNumber", "Order #");
            dgvRecent.Columns.Add("CustomerName", "Customer");
            dgvRecent.Columns.Add("Status", "Status");
            dgvRecent.Columns.Add("Amount", "Amount");
            dgvRecent.Columns.Add("Date", "Date");
            pnlRecent.Controls.Add(dgvRecent);
            _controls["dgvRecent"] = dgvRecent;

            this.Controls.Add(pnlRecent);
        }

        private Label CreateStatCard(Panel parent, string title, int x, int y, string labelName)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(190, 90),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Label lblTitle = new Label
            {
                Text = title,
                Location = new Point(10, 10),
                Size = new Size(170, 25),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };

            Label lblValue = new Label
            {
                Name = labelName,
                Text = "0",
                Location = new Point(10, 45),
                Size = new Size(170, 30),
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            parent.Controls.Add(card);

            return lblValue;
        }

        private void CreateMenuButton(Panel parent, string text, int x, int y, Action onClick)
        {
            // Map keywords to FontAwesome icons
            IconChar icon = IconChar.QuestionCircle;
            if (text.Contains("Product", StringComparison.OrdinalIgnoreCase)) icon = IconChar.Cubes;
            else if (text.Contains("Order", StringComparison.OrdinalIgnoreCase)) icon = IconChar.ClipboardList;
            else if (text.Contains("Category", StringComparison.OrdinalIgnoreCase)) icon = IconChar.Tags;
            else if (text.Contains("Customer", StringComparison.OrdinalIgnoreCase)) icon = IconChar.Users;
            else if (text.Contains("Sales", StringComparison.OrdinalIgnoreCase)) icon = IconChar.ChartBar;

            IconButton btn = new IconButton
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(200, 40),
                BackColor = Color.LightGreen,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                TabStop = true,
                TabIndex = parent.Controls.Count,
                IconChar = icon,
                IconColor = Color.DarkGreen,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
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
