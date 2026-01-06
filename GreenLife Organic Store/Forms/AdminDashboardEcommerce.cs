using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AdminDashboardEcommerce : Form
    {
        private User _currentAdmin;

        public AdminDashboardEcommerce(User admin)
        {
            _currentAdmin = admin;
            this.Text = "Admin Dashboard - GreenLife Organic Store";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void AdminDashboardEcommerce_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadStatistics();
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
                Location = new Point(800, 10),
                Size = new Size(80, 30),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
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

            CreateStatCard(pnlStats, "Total Products", 10, 10, "lblTotalProducts");
            CreateStatCard(pnlStats, "Pending Orders", 210, 10, "lblPendingOrders");
            CreateStatCard(pnlStats, "Total Customers", 410, 10, "lblTotalCustomers");
            CreateStatCard(pnlStats, "Low Stock Items", 610, 10, "lblLowStock");

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
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            pnlRecent.Controls.Add(lblRecent);

            DataGridView dgvRecent = new DataGridView
            {
                Name = "dgvRecent",
                Location = new Point(10, 40),
                Size = new Size(860, 200),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackColor = Color.White
            };
            dgvRecent.Columns.Add("OrderNumber", "Order #");
            dgvRecent.Columns.Add("CustomerName", "Customer");
            dgvRecent.Columns.Add("Status", "Status");
            dgvRecent.Columns.Add("Amount", "Amount");
            dgvRecent.Columns.Add("Date", "Date");
            pnlRecent.Controls.Add(dgvRecent);

            this.Controls.Add(pnlRecent);
        }

        private void CreateStatCard(Panel parent, string title, int x, int y, string labelName)
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
        }

        private void CreateMenuButton(Panel parent, string text, int x, int y, Action onClick)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(200, 40),
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.Click += (s, e) => onClick();
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

                Panel pnlStats = this.Controls[1] as Panel;
                ((Label)pnlStats.Controls["lblTotalProducts"]).Text = allProducts.Count.ToString();
                ((Label)pnlStats.Controls["lblPendingOrders"]).Text = pendingOrders.Count.ToString();
                ((Label)pnlStats.Controls["lblTotalCustomers"]).Text = allUsers.Count(u => u.UserType == UserType.Customer).ToString();
                ((Label)pnlStats.Controls["lblLowStock"]).Text = lowStockProducts.Count.ToString();

                // Load recent orders
                Panel pnlRecent = this.Controls[3] as Panel;
                DataGridView dgvRecent = (DataGridView)pnlRecent.Controls["dgvRecent"];
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenManageProducts()
        {
            ManageProductsForm form = new ManageProductsForm();
            form.ShowDialog();
            LoadStatistics();
        }

        private void OpenManageOrders()
        {
            ManageOrdersForm form = new ManageOrdersForm();
            form.ShowDialog();
            LoadStatistics();
        }

        private void OpenManageCategories()
        {
            ManageCategoriesForm form = new ManageCategoriesForm();
            form.ShowDialog();
        }

        private void OpenManageCustomers()
        {
            var form = new Form { Text = "Manage Customers", Size = new Size(900, 600), StartPosition = FormStartPosition.CenterScreen };
            MessageBox.Show("Customer management form to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            form.ShowDialog();
        }

        private void OpenSalesReports()
        {
            SalesReportForm form = new SalesReportForm();
            form.ShowDialog();
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
