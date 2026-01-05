using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private int _userId;

        public ChangePasswordForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 9F);
            this.StartPosition = FormStartPosition.CenterParent;

            panelContainer.BackColor = Color.White;

            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(34, 139, 34);

            buttonChange.BackColor = Color.FromArgb(34, 139, 34);
            buttonChange.ForeColor = Color.White;
            buttonChange.FlatStyle = FlatStyle.Flat;
            buttonChange.FlatAppearance.BorderSize = 0;
            buttonChange.Cursor = Cursors.Hand;

            buttonCancel.BackColor = Color.FromArgb(200, 200, 200);
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.Cursor = Cursors.Hand;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ChangePassword();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                MessageBox.Show("Please enter a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNewPassword.Focus();
                return false;
            }

            if (textBoxNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNewPassword.Focus();
                return false;
            }

            if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private void ChangePassword()
        {
            try
            {
                if (UserRepository.ChangePassword(_userId, textBoxNewPassword.Text))
                {
                    MessageBox.Show("Your password has been changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
