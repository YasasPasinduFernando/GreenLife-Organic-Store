using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AdminRegistrationForm : Form
    {
        public AdminRegistrationForm()
        {
            InitializeComponent();
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

            foreach (var textBox in GetAllTextBoxes(panelContainer))
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            buttonSave.BackColor = Color.FromArgb(34, 139, 34);
            buttonSave.ForeColor = Color.White;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.Cursor = Cursors.Hand;

            buttonCancel.BackColor = Color.FromArgb(200, 200, 200);
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.Cursor = Cursors.Hand;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                RegisterAdmin();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || !IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (UserRepository.GetUserByEmail(textBoxEmail.Text) != null)
            {
                MessageBox.Show("This email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please enter the admin's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text) || textBoxPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!radioButtonMale.Checked && !radioButtonFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void RegisterAdmin()
        {
            try
            {
                var newAdmin = new User
                {
                    Email = textBoxEmail.Text.Trim(),
                    Name = textBoxName.Text.Trim(),
                    Phone = textBoxPhone.Text.Trim(),
                    Age = string.IsNullOrWhiteSpace(textBoxAge.Text) ? null : int.Parse(textBoxAge.Text),
                    Address = textBoxAddress.Text.Trim(),
                    Sex = radioButtonMale.Checked ? Gender.Male : Gender.Female,
                    UserType = UserType.Admin,
                    Password = textBoxPassword.Text
                };

                int newAdminId = UserRepository.CreateUser(newAdmin);

                if (newAdminId > 0)
                {
                    MessageBox.Show("Admin registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering admin: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
