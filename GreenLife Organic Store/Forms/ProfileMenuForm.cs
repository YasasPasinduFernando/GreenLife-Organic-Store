using FontAwesome.Sharp;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ProfileMenuForm : Form
    {
        private User _currentCustomer;

        public ProfileMenuForm(User currentCustomer)
        {
            _currentCustomer = currentCustomer;
            InitializeComponent();
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            CustomerProfileEditForm editForm = new CustomerProfileEditForm(_currentCustomer);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _currentCustomer = editForm.UpdatedUser;
            }
            Close();
        }

        private void buttonMyOrders_Click(object sender, EventArgs e)
        {
            MyOrdersForm ordersForm = new MyOrdersForm(_currentCustomer);
            ordersForm.ShowDialog();
            Close();
        }

        private void buttonReviewOrders_Click(object sender, EventArgs e)
        {
            ReviewOrdersForm reviewForm = new ReviewOrdersForm(_currentCustomer);
            reviewForm.ShowDialog();
            Close();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePassForm = new ChangePasswordForm(_currentCustomer.ID);
            changePassForm.ShowDialog();
            Close();
        }
    }
}
