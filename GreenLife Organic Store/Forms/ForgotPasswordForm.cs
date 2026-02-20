using System;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Threading.Tasks;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
            Load += ForgotPasswordForm_Load;
        }

        private void ForgotPasswordForm_Load(object? sender, EventArgs e)
        {
            try
            {
                bool isConfigured = GreenLife_Organic_Store.Utilities.EmailConfigValidator.IsEmailConfigured();
                iconEmailStatus.IconChar = isConfigured ? IconChar.CheckCircle : IconChar.ExclamationTriangle;
                iconEmailStatus.IconColor = isConfigured ? System.Drawing.Color.FromArgb(34, 139, 34) : System.Drawing.Color.DarkOrange;
                labelStatus.Text = isConfigured ? "Email service is configured" : "Email service may not be configured";
                labelStatus.ForeColor = isConfigured ? System.Drawing.Color.FromArgb(34, 139, 34) : System.Drawing.Color.DarkOrange;
                GreenLife_Organic_Store.Utilities.EmailConfigValidator.LogConfigurationStatus();
            }
            catch
            {
                labelStatus.Text = "Email configuration status unavailable.";
                labelStatus.ForeColor = System.Drawing.Color.DarkGray;
            }
        }

        private async void ButtonSendCode_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Disable UI and show progress
                buttonSendCode.Enabled = false;
                buttonSendCode.Text = "Sending...";
                progressBar.Visible = true;
                labelProgress.Visible = true;
                labelProgress.Text = "Sending reset code...";

                string email = textBoxEmail.Text.Trim();

                // Verify user exists in database
                var user = UserRepository.GetUserByEmail(email);
                if (user == null)
                {
                    MessageBox.Show(
                        $"? No account found for this email.\n\n" +
                        $"Email: {email}\n\n" +
                        $"Please check the email address or create a new account.", 
                        "Account Not Found", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    buttonSendCode.Enabled = true;
                    buttonSendCode.Text = "Send Reset Code";
                    return;
                }

                Console.WriteLine($"[ForgotPasswordForm] User found: {user.Name}. Sending reset code...");

                // Send reset code on background thread so UI stays responsive
                bool success = await Task.Run(() => UserRepository.RequestPasswordReset(email));

                if (success)
                {
                    MessageBox.Show(
                        $"? Password reset code sent successfully!\n\n" +
                        $"Email: {email}\n\n" +
                        $"Check your inbox for the reset code.\n" +
                        $"(Code expires in 15 minutes)", 
                        "Code Sent", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    var resetForm = new ResetPasswordForm(email);
                    this.Hide();
                    resetForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        $"? Failed to send reset code.\n\n" +
                        $"Please check:\n" +
                        $" Your email address is correct\n" +
                        $" Your internet connection is stable\n\n" +
                        $"Try again later or contact support.",
                        "Email Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    buttonSendCode.Enabled = true;
                    buttonSendCode.Text = "Send Reset Code";
                    progressBar.Visible = false;
                    labelProgress.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"? An error occurred.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"Please try again or contact support.",
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                buttonSendCode.Enabled = true;
                buttonSendCode.Text = "Send Reset Code";
                progressBar.Visible = false;
                labelProgress.Visible = false;
            }
        }
    }
}
