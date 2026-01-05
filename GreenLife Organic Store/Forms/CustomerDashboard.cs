using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class CustomerDashboard : Form
    {
        private User _currentCustomer;

        public CustomerDashboard(User customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 9F);

            labelWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelWelcome.ForeColor = Color.FromArgb(34, 139, 34);

            labelInfoTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            panelInfo.BackColor = Color.White;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;

            buttonEditProfile.BackColor = Color.FromArgb(34, 139, 34);
            buttonEditProfile.ForeColor = Color.White;
            buttonEditProfile.FlatStyle = FlatStyle.Flat;
            buttonEditProfile.FlatAppearance.BorderSize = 0;
            buttonEditProfile.Cursor = Cursors.Hand;

            buttonChangePassword.BackColor = Color.FromArgb(34, 139, 34);
            buttonChangePassword.ForeColor = Color.White;
            buttonChangePassword.FlatStyle = FlatStyle.Flat;
            buttonChangePassword.FlatAppearance.BorderSize = 0;
            buttonChangePassword.Cursor = Cursors.Hand;

            buttonLogout.BackColor = Color.FromArgb(200, 50, 50);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.Cursor = Cursors.Hand;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = $"Welcome, {_currentCustomer.Name}!";
            DisplayCustomerInfo();
        }

        private void DisplayCustomerInfo()
        {
            labelInfoContent.Text = $@"Name: {_currentCustomer.Name}
Email: {_currentCustomer.Email}
Phone: {_currentCustomer.Phone ?? "Not provided"}
Age: {_currentCustomer.Age?.ToString() ?? "Not provided"}
Address: {_currentCustomer.Address ?? "Not provided"}
Gender: {_currentCustomer.Sex}
Member Since: {_currentCustomer.CreatedDate:dd/MM/yyyy}";
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            CustomerProfileEditForm editForm = new CustomerProfileEditForm(_currentCustomer);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _currentCustomer = editForm.UpdatedUser;
                DisplayCustomerInfo();
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePassForm = new ChangePasswordForm(_currentCustomer.ID);
            changePassForm.ShowDialog();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
