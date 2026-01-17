using FontAwesome.Sharp;
using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class LoginForm : Form
    {
        private User? _currentUser;
        private bool _passwordVisible;

        public LoginForm()
        {
            InitializeComponent();
            ApplyStyles();

            // Make sure Load event is hooked (in case designer didn't)
            this.Load += LoginForm_Load;
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
            labelTitle.ForeColor = Color.FromArgb(34, 139, 34); // Forest Green

            labelEmail.Font = new Font("Segoe UI", 10F);
            labelPassword.Font = new Font("Segoe UI", 10F);
            labelUserType.Font = new Font("Segoe UI", 10F);

            // TextBox styling
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;

            // Button styling
            buttonLogin.BackColor = Color.FromArgb(34, 139, 34); // Forest Green
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Cursor = Cursors.Hand;

            linkLabelRegister.LinkColor = Color.FromArgb(34, 139, 34);
            linkLabelRegister.ActiveLinkColor = Color.FromArgb(0, 100, 0);
        }

        // ✅ Async Load - prevents "open but can't click" freeze
        private async void LoginForm_Load(object? sender, EventArgs e)
        {
            // Default selection
            radioButtonCustomer.Checked = true;

            // Let UI render first
            await Task.Delay(50);

            bool ok;
            try
            {
                ok = await Task.Run(() => DatabaseConnection.TestConnection());
            }
            catch
            {
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show(
                    "Warning: Unable to connect to the database.\n\n" +
                    "• If you are using MySQL: make sure MySQL/XAMPP is running.\n" +
                    "• If you are using SQLite: make sure the .db file path is correct.\n\n" +
                    "The app will still open, but login may not work until the DB is available.",
                    "Database Connection Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // ✅ Keep this event in designer, but now it calls async login safely
        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            // Prevent double click + show busy cursor
            buttonLogin.Enabled = false;
            UseWaitCursor = true;

            try
            {
                await PerformLoginAsync();
            }
            finally
            {
                UseWaitCursor = false;
                buttonLogin.Enabled = true;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            if (!IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
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

        // ✅ Async login - prevents freeze when DB/auth is slow
        private async Task PerformLoginAsync()
        {
            try
            {
                string email = textBoxEmail.Text.Trim();
                string password = textBoxPassword.Text;

                _currentUser = await Task.Run(() => UserRepository.AuthenticateUser(email, password));

                if (_currentUser == null)
                {
                    MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                    return;
                }

                // Verify user type matches selected radio button
                string selectedUserType = radioButtonAdmin.Checked ? "Admin" : "Customer";

                if (_currentUser.UserType.ToString() != selectedUserType)
                {
                    MessageBox.Show(
                        "The selected user type does not match your account. Please select the correct user type.",
                        "User Type Mismatch",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Login successful
                MessageBox.Show($"Welcome, {_currentUser.Name}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open appropriate dashboard
                Form dash = _currentUser.UserType == UserType.Admin
                    ? new AdminDashboard(_currentUser)
                    : new CustomerDashboard(_currentUser);

                this.Hide();
                dash.ShowDialog();
                this.Show();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            textBoxEmail.Clear();
            textBoxPassword.Clear();
            radioButtonCustomer.Checked = true;
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        private void linkLabelForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgot = new ForgotPasswordForm();
            this.Hide();
            forgot.ShowDialog();
            this.Show();
        }

        // Keep these (empty handlers ok)
        private void labelTitle_Click(object sender, EventArgs e) { }
        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e) { }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;
            textBoxPassword.UseSystemPasswordChar = !_passwordVisible;
            buttonShowPassword.IconChar = _passwordVisible ? IconChar.EyeSlash : IconChar.Eye;
        }
    }
}
