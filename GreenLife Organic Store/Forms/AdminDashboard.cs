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
            // Redirect to new e-commerce admin dashboard
            AdminDashboardEcommerce ecommerceDashboard = new AdminDashboardEcommerce(_currentAdmin);
            ecommerceDashboard.Show();
            this.Close();
        }
    }
}

