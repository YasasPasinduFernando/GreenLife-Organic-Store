using System;
using System.Windows.Forms;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ResetPasswordForm : Form
    {
        private string _email;
        private Label labelEmail;
        private TextBox textBoxCode;
        private TextBox textBoxNewPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonResetPassword;

        public ResetPasswordForm(string email)
        {
            _email = email;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Reset Password";
            this.Size = new System.Drawing.Size(420, 320);
            this.StartPosition = FormStartPosition.CenterParent;

            labelEmail = new Label { Text = $"Email: {_email}", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.Controls.Add(labelEmail);

            var lblCode = new Label { Text = "Reset Code:", Location = new System.Drawing.Point(20, 55), AutoSize = true };
            this.Controls.Add(lblCode);
            textBoxCode = new TextBox { Location = new System.Drawing.Point(20, 75), Size = new System.Drawing.Size(360, 25) };
            this.Controls.Add(textBoxCode);

            var lblNew = new Label { Text = "New Password:", Location = new System.Drawing.Point(20, 110), AutoSize = true };
            this.Controls.Add(lblNew);
            textBoxNewPassword = new TextBox { Location = new System.Drawing.Point(20, 130), Size = new System.Drawing.Size(360, 25), UseSystemPasswordChar = true };
            this.Controls.Add(textBoxNewPassword);

            var lblConfirm = new Label { Text = "Confirm Password:", Location = new System.Drawing.Point(20, 165), AutoSize = true };
            this.Controls.Add(lblConfirm);
            textBoxConfirmPassword = new TextBox { Location = new System.Drawing.Point(20, 185), Size = new System.Drawing.Size(360, 25), UseSystemPasswordChar = true };
            this.Controls.Add(textBoxConfirmPassword);

            buttonResetPassword = new Button { Text = "Reset Password", Location = new System.Drawing.Point(20, 225), Size = new System.Drawing.Size(150, 30) };
            buttonResetPassword.Click += ButtonResetPassword_Click;
            this.Controls.Add(buttonResetPassword);
        }

        private void ButtonResetPassword_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCode.Text))
            {
                MessageBox.Show("Please enter the reset code sent to your email.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                MessageBox.Show("Please enter a new password.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNewPassword.Focus();
                return;
            }

            if (textBoxNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNewPassword.Focus();
                return;
            }

            if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxConfirmPassword.Focus();
                return;
            }

            try
            {
                Console.WriteLine($"[ResetPasswordForm] Attempting to reset password for email: {_email}");
                bool success = UserRepository.ResetPassword(_email, textBoxCode.Text.Trim(), textBoxNewPassword.Text);
                
                if (success)
                {
                    Console.WriteLine($"[ResetPasswordForm] Password reset successful for email: {_email}");
                    MessageBox.Show("? Your password has been reset successfully!\n\nYou can now login with your new password.", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    Console.WriteLine($"[ResetPasswordForm] Password reset failed - Invalid or expired code for email: {_email}");
                    MessageBox.Show("The reset code is invalid or has expired.\n\nPlease:\n1. Go back and request a new code\n2. Make sure you enter the code within 15 minutes\n3. Check the code matches exactly", 
                        "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxCode.Clear();
                    textBoxCode.Focus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResetPasswordForm] Exception: {ex}");
                MessageBox.Show($"Error resetting password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
