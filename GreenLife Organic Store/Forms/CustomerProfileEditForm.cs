using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class CustomerProfileEditForm : Form
    {
        private User _originalUser;
        public User UpdatedUser { get; private set; }

        public CustomerProfileEditForm(User customer)
        {
            InitializeComponent();
            _originalUser = customer;
            UpdatedUser = new User { 
                ID = customer.ID,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone,
                Age = customer.Age,
                Address = customer.Address,
                Sex = customer.Sex,
                UserType = customer.UserType,
                Password = customer.Password,
                CreatedDate = customer.CreatedDate,
                UpdatedDate = customer.UpdatedDate,
                IsActive = customer.IsActive
            };
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

        private void CustomerProfileEditForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            labelEmail.Text = $"Email: {_originalUser.Email}";
            textBoxName.Text = _originalUser.Name;
            textBoxPhone.Text = _originalUser.Phone ?? string.Empty;
            textBoxAge.Text = _originalUser.Age?.ToString() ?? string.Empty;
            textBoxAddress.Text = _originalUser.Address ?? string.Empty;

            if (_originalUser.Sex == Gender.Male)
                radioButtonMale.Checked = true;
            else
                radioButtonFemale.Checked = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveProfileChanges();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Please enter your phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textBoxAge.Text) && (!int.TryParse(textBoxAge.Text, out int age) || age < 18))
            {
                MessageBox.Show("Please enter a valid age (18+).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                MessageBox.Show("Please enter your address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!radioButtonMale.Checked && !radioButtonFemale.Checked)
            {
                MessageBox.Show("Please select your gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SaveProfileChanges()
        {
            try
            {
                UpdatedUser.Name = textBoxName.Text.Trim();
                UpdatedUser.Phone = textBoxPhone.Text.Trim();
                UpdatedUser.Age = string.IsNullOrWhiteSpace(textBoxAge.Text) ? null : int.Parse(textBoxAge.Text);
                UpdatedUser.Address = textBoxAddress.Text.Trim();
                UpdatedUser.Sex = radioButtonMale.Checked ? Gender.Male : Gender.Female;

                if (UserRepository.UpdateUser(UpdatedUser))
                {
                    MessageBox.Show("Your profile has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update your profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
