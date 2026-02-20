using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;
using System.Linq;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AdminDashboardEcommerce : Form
    {
        private User _currentAdmin;

        public AdminDashboardEcommerce()
            : this(new User { ID = 0, Name = "Admin", Email = "admin@example.com", UserType = UserType.Admin })
        { }

        public AdminDashboardEcommerce(User admin)
        {
            InitializeComponent();
            _currentAdmin = admin;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.Text = "Admin Dashboard - GreenLife Organic Store";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            if (!DesignMode)
                this.Load += AdminDashboardEcommerce_Load;
        }

        private void AdminDashboardEcommerce_Load(object? sender, EventArgs? e)
        {
            if (DesignMode) return;
            try
            {
                lblHeader.Text = $"Admin Dashboard - Welcome, {_currentAdmin.Name}";
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object? sender, EventArgs e) => LogoutAdmin();
        private void BtnManageProducts_Click(object? sender, EventArgs e) { try { OpenManageProducts(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void BtnManageOrders_Click(object? sender, EventArgs e) { try { OpenManageOrders(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void BtnManageCategories_Click(object? sender, EventArgs e) { try { OpenManageCategories(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void BtnManageCustomers_Click(object? sender, EventArgs e) { try { OpenManageCustomers(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void BtnSalesReports_Click(object? sender, EventArgs e) { try { OpenSalesReports(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void BtnAdminRegistrations_Click(object? sender, EventArgs e) { try { OpenAdminRegistrations(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void BtnOrderReviews_Click(object? sender, EventArgs e) { try { OpenOrderReviews(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void BtnManageDiscounts_Click(object? sender, EventArgs e) { try { OpenManageDiscounts(); } catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void LoadStatistics()
        {
            try
            {
                var allProducts = ProductRepository.GetAllProducts();
                var allOrders = OrderRepository.GetAllOrders();
                var allUsers = UserRepository.GetAllUsers();
                var lowStockProducts = ProductRepository.GetLowStockProducts();
                var pendingOrders = allOrders.Where(o => o.Status == OrderStatus.Pending).ToList();

                lblTotalProducts.Text = allProducts.Count.ToString();
                lblPendingOrders.Text = pendingOrders.Count.ToString();
                lblTotalCustomers.Text = allUsers.Count(u => u.UserType == UserType.Customer).ToString();
                lblLowStock.Text = lowStockProducts.Count.ToString();

                if (lowStockProducts.Count > 0)
                {
                    var adminEmails = UserRepository.GetAdminEmails();
                    var items = lowStockProducts.Select(p => (p.ProductName, p.Stock));
                    _ = EmailService.SendLowStockAlertsToAdminsAsync(adminEmails, items);
                }

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

        private void OpenOrderReviews()
        {
            try
            {
                AdminOrderReviewsForm form = new AdminOrderReviewsForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Order Reviews: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenManageDiscounts()
        {
            try
            {
                DiscountManagementForm form = new DiscountManagementForm();
                form.ShowDialog();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Discounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
