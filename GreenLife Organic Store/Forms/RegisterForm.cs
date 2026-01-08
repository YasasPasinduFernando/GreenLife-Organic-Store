using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            // Form styling
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 9F);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel styling
            panelContainer.BackColor = Color.White;
            panelContainer.BorderStyle = BorderStyle.None;

            // Label styling
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(34, 139, 34);

            // TextBox styling
            foreach (var textBox in GetAllTextBoxes(panelContainer))
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            // Button styling
            buttonRegister.BackColor = Color.FromArgb(34, 139, 34);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.Cursor = Cursors.Hand;

            buttonCancel.BackColor = Color.FromArgb(200, 200, 200);
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.Cursor = Cursors.Hand;

            linkLabelLogin.LinkColor = Color.FromArgb(34, 139, 34);
            linkLabelLogin.ActiveLinkColor = Color.FromArgb(0, 100, 0);
        }

        private IEnumerable<TextBox> GetAllTextBoxes(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                    yield return textBox;
                foreach (var child in GetAllTextBoxes(control))
                    yield return child;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                PerformRegistration();
            }
        }

        private bool ValidateInput()
        {
            // Email validation
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter an email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            if (!IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            // Check if email already exists
            if (UserRepository.GetUserByEmail(textBoxEmail.Text) != null)
            {
                MessageBox.Show("This email address is already registered.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            // Name validation
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return false;
            }

            // Phone validation
            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Please enter your phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPhone.Focus();
                return false;
            }

            // Age validation
            if (string.IsNullOrWhiteSpace(textBoxAge.Text) || !int.TryParse(textBoxAge.Text, out int age) || age < 18 || age > 120)
            {
                MessageBox.Show("Please enter a valid age (18-120).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxAge.Focus();
                return false;
            }

            // Address validation
            if (string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                MessageBox.Show("Please enter your address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxAddress.Focus();
                return false;
            }

            // Gender validation
            if (!radioButtonMale.Checked && !radioButtonFemale.Checked)
            {
                MessageBox.Show("Please select your gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Password validation
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            if (textBoxPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            // Confirm password validation
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void PerformRegistration()
        {
            try
            {
                var newUser = new User
                {
                    Email = textBoxEmail.Text.Trim(),
                    Name = textBoxName.Text.Trim(),
                    Phone = textBoxPhone.Text.Trim(),
                    Age = int.Parse(textBoxAge.Text),
                    Address = textBoxAddress.Text.Trim(),
                    Sex = radioButtonMale.Checked ? Gender.Male : Gender.Female,
                    UserType = UserType.Customer,
                    Password = textBoxPassword.Text
                };

                int newUserId = UserRepository.CreateUser(newUser);

                if (newUserId > 0)
                {
                    // Send welcome email (best-effort)
                    bool emailSent = false;
                    try
                    {
                        Console.WriteLine($"[RegisterForm] Sending welcome email to {newUser.Email}");
                        emailSent = GreenLife_Organic_Store.Utilities.EmailService.SendWelcomeEmail(newUser.Email, newUser.Name);
                    }
                    catch (Exception emailEx)
                    {
                        Console.WriteLine($"[RegisterForm] Welcome email failed: {emailEx.Message}");
                    }

                    string message = $"Registration successful! Your account has been created.";
                    if (!emailSent)
                    {
                        message += $"\n\n??  Welcome email could not be sent.\nThis may be due to email not being configured.";
                        message += $"\n\nYou can still login and use your account.";
                        message += $"\nCheck EMAIL_CONFIG.md for email setup instructions.";
                    }
                    else
                    {
                        message += $"\n\n? A welcome email has been sent to {newUser.Email}";
                    }

                    message += $"\n\nYou can now login with your email and password.";

                    MessageBox.Show(message, "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
