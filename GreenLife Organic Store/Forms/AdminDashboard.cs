using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AdminDashboard : Form
    {
        private User _currentAdmin;

        public AdminDashboard(User admin)
        {
            InitializeComponent();
            _currentAdmin = admin;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                // Hide this form and show the actual admin dashboard
                this.Hide();

                // Create and show new admin dashboard as main window
                var adminDashboardEcommerce = new AdminDashboardEcommerce(_currentAdmin);
                adminDashboardEcommerce.ShowDialog();

                // Close this form when admin dashboard closes
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading admin dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonRegisterCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}


