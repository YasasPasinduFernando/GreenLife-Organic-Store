using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class UserDetailsForm : Form
    {
        private User _user;
        private bool _isAdmin;

        public UserDetailsForm(User user, bool isAdmin = false)
        {
            InitializeComponent();
            _user = user;
            _isAdmin = isAdmin;
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

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            labelTitle.Text = $"Edit User Details - {_user.Name}";
            LoadUserData();
        }

        private void LoadUserData()
        {
            textBoxName.Text = _user.Name;
            textBoxPhone.Text = _user.Phone ?? string.Empty;
            textBoxAge.Text = _user.Age?.ToString() ?? string.Empty;
            textBoxAddress.Text = _user.Address ?? string.Empty;

            if (_user.Sex == Gender.Male)
                radioButtonMale.Checked = true;
            else
                radioButtonFemale.Checked = true;

            labelEmail.Text = $"Email: {_user.Email}";
            labelUserType.Text = $"User Type: {_user.UserType}";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveUserData();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please enter a name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Please enter a phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textBoxAge.Text) && (!int.TryParse(textBoxAge.Text, out int age) || age < 18))
            {
                MessageBox.Show("Please enter a valid age (18+).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                MessageBox.Show("Please enter an address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!radioButtonMale.Checked && !radioButtonFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SaveUserData()
        {
            try
            {
                _user.Name = textBoxName.Text.Trim();
                _user.Phone = textBoxPhone.Text.Trim();
                _user.Age = string.IsNullOrWhiteSpace(textBoxAge.Text) ? null : int.Parse(textBoxAge.Text);
                _user.Address = textBoxAddress.Text.Trim();
                _user.Sex = radioButtonMale.Checked ? Gender.Male : Gender.Female;

                if (UserRepository.UpdateUser(_user))
                {
                    MessageBox.Show("User details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update user details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
