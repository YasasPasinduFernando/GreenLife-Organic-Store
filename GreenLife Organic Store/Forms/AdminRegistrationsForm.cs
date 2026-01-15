using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public class AdminRegistrationsForm : Form
    {
        private DataGridView _dgvAdmins;
        private Button _btnRefresh;
        private Button _btnClose;
        private Button _btnAdd;
        private Button _btnEdit;
        private Button _btnDelete;

        public AdminRegistrationsForm()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.Text = "Admin Registrations - Logs";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(245, 245, 245);

            InitializeComponents();
            LoadAdminRegistrations();
        }

        private void InitializeComponents()
        {
            _dgvAdmins = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 380,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray }
            };

            _dgvAdmins.Columns.Add("ID", "ID");
            _dgvAdmins.Columns.Add("Name", "Name");
            _dgvAdmins.Columns.Add("Email", "Email");
            _dgvAdmins.Columns.Add("Phone", "Phone");
            _dgvAdmins.Columns.Add("Age", "Age");
            _dgvAdmins.Columns.Add("Address", "Address");
            _dgvAdmins.Columns.Add("CreatedDate", "Created Date");

            _btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(10, 390),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(34, 139, 34),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            _btnRefresh.Click += (s, e) => LoadAdminRegistrations();

            _btnAdd = new Button
            {
                Text = "Add Admin",
                Location = new Point(230, 390),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(34, 139, 34),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            _btnAdd.Click += (s, e) =>
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
            };

            _btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(340, 390),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(34, 139, 34),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            _btnEdit.Click += (s, e) => EditSelectedAdmin();

            _btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(450, 390),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(200, 50, 50),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            _btnDelete.Click += (s, e) => DeleteSelectedAdmin();

            _btnClose = new Button
            {
                Text = "Close",
                Location = new Point(120, 390),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.Black,
                Cursor = Cursors.Hand
            };
            _btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(_dgvAdmins);
            this.Controls.Add(_btnRefresh);
            this.Controls.Add(_btnAdd);
            this.Controls.Add(_btnEdit);
            this.Controls.Add(_btnDelete);
            this.Controls.Add(_btnClose);

            _dgvAdmins.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    EditSelectedAdmin();
                }
            };
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
