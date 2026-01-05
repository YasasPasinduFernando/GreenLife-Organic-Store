using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class LoginForm : Form
    {
        private User? _currentUser;

        public LoginForm()
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                PerformLogin();
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

        private void PerformLogin()
        {
            try
            {
                string email = textBoxEmail.Text.Trim();
                string password = textBoxPassword.Text;

                _currentUser = UserRepository.AuthenticateUser(email, password);

                if (_currentUser != null)
                {
                    // Verify user type matches selected radio button
                    string selectedUserType = radioButtonAdmin.Checked ? "Admin" : "Customer";
                    
                    if (_currentUser.UserType.ToString() != selectedUserType)
                    {
                        MessageBox.Show("The selected user type does not match your account. Please select the correct user type.", 
                            "User Type Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Login successful
                    MessageBox.Show($"Welcome, {_currentUser.Name}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Open appropriate dashboard
                    if (_currentUser.UserType == UserType.Admin)
                    {
                        AdminDashboard adminDash = new AdminDashboard(_currentUser);
                        this.Hide();
                        adminDash.ShowDialog();
                        this.Show();
                        ClearForm();
                    }
                    else
                    {
                        CustomerDashboard customerDash = new CustomerDashboard(_currentUser);
                        this.Hide();
                        customerDash.ShowDialog();
                        this.Show();
                        ClearForm();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                }
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Set default selection
            radioButtonCustomer.Checked = true;

            // Test database connection on form load
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Warning: Unable to connect to the database. Please ensure MySQL is running and the database is configured correctly.", 
                    "Database Connection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
