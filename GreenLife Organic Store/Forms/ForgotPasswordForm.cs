using System;
using System.Windows.Forms;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private TextBox textBoxEmail;
        private Button buttonSendCode;
        private Label labelStatus;

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Forgot Password";
            this.Size = new System.Drawing.Size(480, 280);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // Title
            var lblTitle = new Label 
            { 
                Text = "Reset Your Password", 
                Location = new System.Drawing.Point(20, 15),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(34, 139, 34)
            };
            this.Controls.Add(lblTitle);

            // Instructions
            var lblInstructions = new Label 
            { 
                Text = "Enter your registered email address and we'll send you a reset code:", 
                Location = new System.Drawing.Point(20, 50),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 9F)
            };
            this.Controls.Add(lblInstructions);

            // Email input
            textBoxEmail = new TextBox 
            { 
                Name = "textBoxEmail", 
                Location = new System.Drawing.Point(20, 75), 
                Size = new System.Drawing.Size(440, 25),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            this.Controls.Add(textBoxEmail);

            // Send button
            buttonSendCode = new Button 
            { 
                Text = "Send Reset Code", 
                Location = new System.Drawing.Point(20, 115), 
                Size = new System.Drawing.Size(150, 35),
                BackColor = System.Drawing.Color.FromArgb(34, 139, 34),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            buttonSendCode.FlatAppearance.BorderSize = 0;
            buttonSendCode.Click += ButtonSendCode_Click;
            this.Controls.Add(buttonSendCode);

            // Configuration status
            bool isConfigured = GreenLife_Organic_Store.Utilities.EmailConfigValidator.IsEmailConfigured();
            
            labelStatus = new Label 
            { 
                Text = isConfigured ? 
                    "? Email is configured and ready" : 
                    "??  Warning: Email not properly configured. Check console for details.",
                Location = new System.Drawing.Point(20, 160), 
                Size = new System.Drawing.Size(440, 50),
                AutoSize = false,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = isConfigured ? System.Drawing.Color.Green : System.Drawing.Color.DarkOrange,
                BackColor = System.Drawing.Color.Transparent
            };
            this.Controls.Add(labelStatus);

            // Help link
            var lblHelp = new Label 
            { 
                Text = "Need help? See EMAIL_CONFIG.md for setup instructions.", 
                Location = new System.Drawing.Point(20, 230),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 8F),
                ForeColor = System.Drawing.Color.Gray
            };
            this.Controls.Add(lblHelp);

            // Log configuration on form load
            GreenLife_Organic_Store.Utilities.EmailConfigValidator.LogConfigurationStatus();
        }

        private void ButtonSendCode_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                buttonSendCode.Enabled = false;
                buttonSendCode.Text = "Sending...";

                string email = textBoxEmail.Text.Trim();
                Console.WriteLine($"[ForgotPasswordForm] Attempting to reset password for email: {email}");

                // Verify user exists in database
                var user = UserRepository.GetUserByEmail(email);
                if (user == null)
                {
                    Console.WriteLine($"[ForgotPasswordForm] User not found for email: {email}");
                    MessageBox.Show($"No account found for email: {email}\n\nPlease check the email address and try again, or register a new account.", 
                        "Email Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    buttonSendCode.Enabled = true;
                    buttonSendCode.Text = "Send Reset Code";
                    return;
                }

                Console.WriteLine($"[ForgotPasswordForm] User found: {user.Name}. Sending reset code...");

                bool success = UserRepository.RequestPasswordReset(email);

                if (success)
                {
                    Console.WriteLine($"[ForgotPasswordForm] Reset code sent successfully to {email}");
                    MessageBox.Show($"A password reset code has been sent to {email}.\n\nCheck your email for the 6-digit code (expires in 15 minutes).", 
                        "Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var resetForm = new ResetPasswordForm(email);
                    this.Hide();
                    resetForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    Console.WriteLine($"[ForgotPasswordForm] Failed to send reset code for email: {email}");
                    MessageBox.Show($"Failed to send reset code to your email.\n\nPlease check that email is properly configured.\n\nCheck the console output for more details.", 
                        "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonSendCode.Enabled = true;
                    buttonSendCode.Text = "Send Reset Code";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ForgotPasswordForm] Exception: {ex}");
                MessageBox.Show($"Error: {ex.Message}\n\nPlease try again or contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonSendCode.Enabled = true;
                buttonSendCode.Text = "Send Reset Code";
            }
        }
    }
}
