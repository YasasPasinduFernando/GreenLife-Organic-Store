using System;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Threading.Tasks;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private TextBox textBoxEmail;
        private Button buttonSendCode;
        private Label labelStatus;
        private ProgressBar progressBar;
        private Label labelProgress;
        private IconPictureBox iconEmailStatus;

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Forgot Password";
            this.Size = new System.Drawing.Size(480, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

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

            // Progress bar (hidden by default) - marquee style while sending
            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Location = new System.Drawing.Point(190, 120),
                Size = new System.Drawing.Size(270, 25),
                Visible = false
            };
            this.Controls.Add(progressBar);

            // Progress / status label shown while sending
            labelProgress = new Label
            {
                Text = string.Empty,
                Location = new System.Drawing.Point(190, 145),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = System.Drawing.Color.Black,
                Visible = false
            };
            this.Controls.Add(labelProgress);

            // Configuration status (icon + label)
            bool isConfigured = GreenLife_Organic_Store.Utilities.EmailConfigValidator.IsEmailConfigured();

            iconEmailStatus = new IconPictureBox
            {
                IconChar = isConfigured ? IconChar.CheckCircle : IconChar.ExclamationTriangle,
                IconColor = isConfigured ? System.Drawing.Color.FromArgb(34, 139, 34) : System.Drawing.Color.DarkOrange,
                Location = new System.Drawing.Point(20, 170),
                Size = new System.Drawing.Size(20, 20),
                BackColor = System.Drawing.Color.Transparent
            };
            this.Controls.Add(iconEmailStatus);

            labelStatus = new Label 
            { 
                Text = isConfigured ? "Email service is configured" : "Email service may not be configured",
                Location = new System.Drawing.Point(48, 168), 
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = isConfigured ? System.Drawing.Color.FromArgb(34, 139, 34) : System.Drawing.Color.DarkOrange,
                BackColor = System.Drawing.Color.Transparent
            };
            this.Controls.Add(labelStatus);

            // Help link
            var lblHelp = new Label 
            { 
                Text = "A reset code will be sent to your registered email.", 
                Location = new System.Drawing.Point(20, 230),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 8F),
                ForeColor = System.Drawing.Color.Gray
            };
            this.Controls.Add(lblHelp);

            // Log configuration on form load
            GreenLife_Organic_Store.Utilities.EmailConfigValidator.LogConfigurationStatus();
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
                        $"• Your email address is correct\n" +
                        $"• Your internet connection is stable\n\n" +
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
