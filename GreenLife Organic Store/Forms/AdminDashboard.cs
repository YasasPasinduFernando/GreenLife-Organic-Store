using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AdminDashboard : Form
    {
        private User _currentAdmin;
        private List<User> _allUsers = new();

        public AdminDashboard(User admin)
        {
            InitializeComponent();
            _currentAdmin = admin;
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 9F);

            labelWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelWelcome.ForeColor = Color.FromArgb(34, 139, 34);

            buttonRegisterAdmin.BackColor = Color.FromArgb(34, 139, 34);
            buttonRegisterAdmin.ForeColor = Color.White;
            buttonRegisterAdmin.FlatStyle = FlatStyle.Flat;
            buttonRegisterAdmin.FlatAppearance.BorderSize = 0;
            buttonRegisterAdmin.Cursor = Cursors.Hand;

            buttonRegisterCustomer.BackColor = Color.FromArgb(34, 139, 34);
            buttonRegisterCustomer.ForeColor = Color.White;
            buttonRegisterCustomer.FlatStyle = FlatStyle.Flat;
            buttonRegisterCustomer.FlatAppearance.BorderSize = 0;
            buttonRegisterCustomer.Cursor = Cursors.Hand;

            buttonViewUsers.BackColor = Color.FromArgb(34, 139, 34);
            buttonViewUsers.ForeColor = Color.White;
            buttonViewUsers.FlatStyle = FlatStyle.Flat;
            buttonViewUsers.FlatAppearance.BorderSize = 0;
            buttonViewUsers.Cursor = Cursors.Hand;

            buttonLogout.BackColor = Color.FromArgb(200, 50, 50);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.Cursor = Cursors.Hand;

            dataGridViewUsers.BackgroundColor = Color.White;
            dataGridViewUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 240);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 139, 34);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = $"Welcome, {_currentAdmin.Name}!";
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                _allUsers = UserRepository.GetAllUsers();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = _allUsers;
            
            // Hide the Password column for security
            if (dataGridViewUsers.Columns.Contains("Password"))
            {
                dataGridViewUsers.Columns["Password"].Visible = false;
            }

            // Configure columns
            foreach (DataGridViewColumn column in dataGridViewUsers.Columns)
            {
                column.HeaderText = column.Name;
            }
        }

        private void buttonViewUsers_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void buttonRegisterAdmin_Click(object sender, EventArgs e)
        {
            AdminRegistrationForm adminRegForm = new AdminRegistrationForm();
            adminRegForm.ShowDialog();
            LoadUsers();
        }

        private void buttonRegisterCustomer_Click(object sender, EventArgs e)
        {
            CustomerRegistrationForm custRegForm = new CustomerRegistrationForm();
            custRegForm.ShowDialog();
            LoadUsers();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                User selectedUser = _allUsers[e.RowIndex];
                UserDetailsForm detailsForm = new UserDetailsForm(selectedUser, true);
                detailsForm.ShowDialog();
                LoadUsers();
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewUsers.SelectedRows[0].Index;
                User selectedUser = _allUsers[rowIndex];

                if (selectedUser.ID == _currentAdmin.ID)
                {
                    MessageBox.Show("You cannot delete your own account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete {selectedUser.Name}?", "Confirm Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (UserRepository.DeleteUser(selectedUser.ID))
                        {
                            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewUsers.SelectedRows[0].Index;
                User selectedUser = _allUsers[rowIndex];
                UserDetailsForm detailsForm = new UserDetailsForm(selectedUser, true);
                detailsForm.ShowDialog();
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
