using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public class ManageCustomersForm : Form
    {
        private List<User> _allCustomers = new();
        private DataGridView _dgvCustomers;
        private Button _btnEditCustomer;
        private Button _btnChangePassword;

        public ManageCustomersForm()
        {
            this.Text = "Manage Customers";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Load += ManageCustomersForm_Load;
        }

        private void EditCustomerDetails()
        {
            if (_dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int customerId = (int)_dgvCustomers.SelectedRows[0].Cells["ID"].Value;
            var customer = _allCustomers.FirstOrDefault(c => c.ID == customerId);

            if (customer == null)
            {
                MessageBox.Show("Selected customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detailsForm = new UserDetailsForm(customer);
            detailsForm.ShowDialog();
            LoadCustomers();
        }

        private void ChangeSelectedCustomerPassword()
        {
            if (_dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to change password.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int customerId = (int)_dgvCustomers.SelectedRows[0].Cells["ID"].Value;

            var changeForm = new ChangePasswordForm(customerId);
            changeForm.ShowDialog();
        }

        private void ManageCustomersForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadCustomers();
        }

        private void InitializeUI()
        {
            // Toolbar
            Panel pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.LightGray
            };

            TextBox txtSearch = new TextBox
            {
                Name = "txtSearch",
                Location = new Point(10, 10),
                Size = new Size(200, 30),
                Text = "Search..."
            };
            pnlToolbar.Controls.Add(txtSearch);

            IconButton btnSearch = new IconButton
            {
                Text = "Search",
                Location = new Point(220, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Search,
                IconColor = Color.Black,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnSearch.Click += (s, e) => SearchCustomers(txtSearch.Text);
            pnlToolbar.Controls.Add(btnSearch);

            IconButton btnRefresh = new IconButton
            {
                Text = "Refresh",
                Location = new Point(330, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Sync,
                IconColor = Color.Black,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnRefresh.Click += (s, e) => LoadCustomers();
            pnlToolbar.Controls.Add(btnRefresh);

            Button btnExport = new Button
            {
                Text = "Export to CSV",
                Location = new Point(440, 10),
                Size = new Size(120, 30),
                BackColor = Color.LightGreen,
                Cursor = Cursors.Hand
            };
            btnExport.Click += (s, e) => ExportToCSV();
            pnlToolbar.Controls.Add(btnExport);

            this.Controls.Add(pnlToolbar);

            // DataGridView
            _dgvCustomers = new DataGridView
            {
                Name = "dgvCustomers",
                Dock = DockStyle.Top,
                Height = 350,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White
            };
            _dgvCustomers.Columns.Add("ID", "ID");
            _dgvCustomers.Columns.Add("Name", "Customer Name");
            _dgvCustomers.Columns.Add("Email", "Email");
            _dgvCustomers.Columns.Add("Phone", "Phone");
            _dgvCustomers.Columns.Add("Address", "Address");
            _dgvCustomers.Columns.Add("RegistrationDate", "Registered Date");
            _dgvCustomers.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditCustomerDetails(); };
            this.Controls.Add(_dgvCustomers);

            // Action Buttons Panel - Changed from DockStyle.Fill to Top
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            Button btnViewDetails = new Button
            {
                Text = "View Details",
                Location = new Point(10, 10),
                Size = new Size(150, 35),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnViewDetails.Click += (s, e) => ViewCustomerDetails();
            pnlActions.Controls.Add(btnViewDetails);

            _btnEditCustomer = new Button
            {
                Text = "Edit",
                Location = new Point(10, 55),
                Size = new Size(150, 35),
                BackColor = Color.LightGreen,
                Cursor = Cursors.Hand
            };
            _btnEditCustomer.Click += (s, e) => EditCustomerDetails();
            pnlActions.Controls.Add(_btnEditCustomer);

            _btnChangePassword = new Button
            {
                Text = "Change Password",
                Location = new Point(170, 55),
                Size = new Size(150, 35),
                BackColor = Color.LightSkyBlue,
                Cursor = Cursors.Hand
            };
            _btnChangePassword.Click += (s, e) => ChangeSelectedCustomerPassword();
            pnlActions.Controls.Add(_btnChangePassword);

            Button btnDeleteAccount = new Button
            {
                Text = "Delete Account",
                Location = new Point(170, 10),
                Size = new Size(150, 35),
                BackColor = Color.LightCoral,
                Cursor = Cursors.Hand
            };
            btnDeleteAccount.Click += (s, e) => DeleteCustomerAccount();
            pnlActions.Controls.Add(btnDeleteAccount);

            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(330, 10),
                Size = new Size(150, 35),
                BackColor = Color.LightGray,
                Cursor = Cursors.Hand
            };
            btnClose.Click += (s, e) => this.Close();
            pnlActions.Controls.Add(btnClose);

            this.Controls.Add(pnlActions);
        }

        private void LoadCustomers()
        {
            try
            {
                var allUsers = UserRepository.GetAllUsers();
                _allCustomers = allUsers.Where(u => u.UserType == UserType.Customer).ToList();
                
                _dgvCustomers.Rows.Clear();

                foreach (var customer in _allCustomers)
                {
                    _dgvCustomers.Rows.Add(
                        customer.ID,
                        customer.Name,
                        customer.Email,
                        customer.Phone ?? "N/A",
                        customer.Address ?? "N/A",
                        customer.CreatedDate.ToString("dd/MM/yyyy")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchCustomers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm == "Search...")
            {
                LoadCustomers();
                return;
            }

            _dgvCustomers.Rows.Clear();

            var filtered = _allCustomers.Where(c =>
                c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                (c.Phone != null && c.Phone.Contains(searchTerm))
            ).ToList();

            foreach (var customer in filtered)
            {
                _dgvCustomers.Rows.Add(
                    customer.ID,
                    customer.Name,
                    customer.Email,
                    customer.Phone ?? "N/A",
                    customer.Address ?? "N/A",
                    customer.CreatedDate.ToString("dd/MM/yyyy")
                );
            }
        }

        private void ViewCustomerDetails()
        {
            if (_dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = (int)_dgvCustomers.SelectedRows[0].Cells["ID"].Value;
                var customer = _allCustomers.FirstOrDefault(c => c.ID == customerId);

                if (customer != null)
                {
                    var detailsForm = new Form
                    {
                        Text = "Customer Details",
                        Size = new Size(500, 400),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false
                    };

                    int yPos = 20;

                    Label lblName = new Label { Text = "Name:", Location = new Point(20, yPos), Size = new Size(100, 20), Font = new Font("Arial", 10, FontStyle.Bold) };
                    TextBox txtName = new TextBox { Location = new Point(150, yPos), Size = new Size(300, 25), Text = customer.Name, ReadOnly = true };
                    detailsForm.Controls.Add(lblName);
                    detailsForm.Controls.Add(txtName);
                    yPos += 40;

                    Label lblEmail = new Label { Text = "Email:", Location = new Point(20, yPos), Size = new Size(100, 20), Font = new Font("Arial", 10, FontStyle.Bold) };
                    TextBox txtEmail = new TextBox { Location = new Point(150, yPos), Size = new Size(300, 25), Text = customer.Email, ReadOnly = true };
                    detailsForm.Controls.Add(lblEmail);
                    detailsForm.Controls.Add(txtEmail);
                    yPos += 40;

                    Label lblPhone = new Label { Text = "Phone:", Location = new Point(20, yPos), Size = new Size(100, 20), Font = new Font("Arial", 10, FontStyle.Bold) };
                    TextBox txtPhone = new TextBox { Location = new Point(150, yPos), Size = new Size(300, 25), Text = customer.Phone ?? "N/A", ReadOnly = true };
                    detailsForm.Controls.Add(lblPhone);
                    detailsForm.Controls.Add(txtPhone);
                    yPos += 40;

                    Label lblAddress = new Label { Text = "Address:", Location = new Point(20, yPos), Size = new Size(100, 20), Font = new Font("Arial", 10, FontStyle.Bold) };
                    TextBox txtAddress = new TextBox { Location = new Point(150, yPos), Size = new Size(300, 60), Text = customer.Address ?? "N/A", ReadOnly = true, Multiline = true };
                    detailsForm.Controls.Add(lblAddress);
                    detailsForm.Controls.Add(txtAddress);
                    yPos += 70;

                    Label lblRegistered = new Label { Text = "Registered:", Location = new Point(20, yPos), Size = new Size(100, 20), Font = new Font("Arial", 10, FontStyle.Bold) };
                    TextBox txtRegistered = new TextBox { Location = new Point(150, yPos), Size = new Size(300, 25), Text = customer.CreatedDate.ToString("dd/MM/yyyy HH:mm"), ReadOnly = true };
                    detailsForm.Controls.Add(lblRegistered);
                    detailsForm.Controls.Add(txtRegistered);
                    yPos += 40;

                    Button btnClose = new Button
                    {
                        Text = "Close",
                        Location = new Point(350, yPos),
                        Size = new Size(100, 35),
                        BackColor = Color.LightGray
                    };
                    btnClose.Click += (s, e) => detailsForm.Close();
                    detailsForm.Controls.Add(btnClose);

                    detailsForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to view details.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteCustomerAccount()
        {
            if (_dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = (int)_dgvCustomers.SelectedRows[0].Cells["ID"].Value;
                string customerName = _dgvCustomers.SelectedRows[0].Cells["Name"].Value.ToString();

                if (MessageBox.Show($"Are you sure you want to delete {customerName}'s account? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (UserRepository.DeleteUser(customerId))
                        {
                            MessageBox.Show("Customer account deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomers();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete customer account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToCSV()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    FileName = $"Customers_{DateTime.Now:yyyyMMdd}.csv",
                    Filter = "CSV Files (*.csv)|*.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        // Write headers
                        writer.WriteLine("GreenLife Organic Store - Customer List");
                        writer.WriteLine($"Generated: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        writer.WriteLine();

                        writer.WriteLine("ID,Name,Email,Phone,Address,Registered Date");

                        foreach (var customer in _allCustomers)
                        {
                            writer.WriteLine($"{customer.ID},\"{customer.Name}\",\"{customer.Email}\",\"{customer.Phone ?? "N/A"}\",\"{customer.Address ?? "N/A"}\",{customer.CreatedDate:dd/MM/yyyy}");
                        }
                    }

                    MessageBox.Show("Customer list exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting customer list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}