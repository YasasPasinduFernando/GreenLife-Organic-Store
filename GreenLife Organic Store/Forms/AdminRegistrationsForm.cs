using System;
using System.Linq;
using System.Windows.Forms;
using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AdminRegistrationsForm : Form
    {
        public AdminRegistrationsForm()
        {
            InitializeComponent();
            if (!DesignMode)
                LoadAdminRegistrations();
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadAdminRegistrations();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            try
            {
                var frm = new AdminRegistrationForm();
                frm.ShowDialog();
                LoadAdminRegistrations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding admin: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            EditSelectedAdmin();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            DeleteSelectedAdmin();
        }

        private void DgvAdmins_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                EditSelectedAdmin();
        }

        private void LoadAdminRegistrations()
        {
            try
            {
                _dgvAdmins.Rows.Clear();
                var allUsers = UserRepository.GetAllUsers();
                var admins = allUsers.Where(u => u.UserType == UserType.Admin).OrderByDescending(u => u.CreatedDate).ToList();

                foreach (var admin in admins)
                {
                    _dgvAdmins.Rows.Add(
                        admin.ID,
                        admin.Name,
                        admin.Email,
                        admin.Phone ?? string.Empty,
                        admin.Age.HasValue ? admin.Age.Value.ToString() : string.Empty,
                        admin.Address ?? string.Empty,
                        admin.CreatedDate.ToString("dd/MM/yyyy HH:mm")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading admin registrations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditSelectedAdmin()
        {
            try
            {
                if (_dgvAdmins.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an admin to edit.", "Select Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var row = _dgvAdmins.SelectedRows[0];
                if (row.Cells["ID"].Value == null) return;
                int id = Convert.ToInt32(row.Cells["ID"].Value);

                var user = UserRepository.GetUserById(id);
                if (user == null)
                {
                    MessageBox.Show("Selected admin could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var detailsForm = new UserDetailsForm(user, true);
                detailsForm.ShowDialog();
                LoadAdminRegistrations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing admin: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSelectedAdmin()
        {
            try
            {
                if (_dgvAdmins.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an admin to delete.", "Select Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var row = _dgvAdmins.SelectedRows[0];
                if (row.Cells["ID"].Value == null) return;
                int id = Convert.ToInt32(row.Cells["ID"].Value);

                if (MessageBox.Show("Are you sure you want to delete the selected admin? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                bool success = UserRepository.DeleteUser(id);
                if (success)
                {
                    MessageBox.Show("Admin deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAdminRegistrations();
                }
                else
                {
                    MessageBox.Show("Failed to delete admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting admin: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
