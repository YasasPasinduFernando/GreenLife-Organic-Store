using System;
using System.Windows.Forms;
using FontAwesome.Sharp;
using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Utilities;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ResetPasswordForm : Form
    {
        private string _email;

        public ResetPasswordForm(string email)
        {
            _email = email;
            InitializeComponent();
            labelEmail.Text = $"Email: {_email}";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            try
            {
                FormThemeManager.ApplyToForm(this);
                FormThemeManager.ApplyIconButton(buttonResetPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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
                    MessageBox.Show("Your password has been reset successfully!\n\nYou can now login with your new password.",
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
