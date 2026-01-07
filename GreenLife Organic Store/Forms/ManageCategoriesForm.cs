using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ManageCategoriesForm : Form
    {
        private List<Category> _categories = new();

        public ManageCategoriesForm()
        {
            this.Text = "Manage Categories";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Load += ManageCategoriesForm_Load;
        }

        private void ManageCategoriesForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadCategories();
        }

        private void InitializeUI()
        {
            Panel pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.LightGray
            };

            IconButton btnAdd = new IconButton
            {
                Text = "Add Category",
                Location = new Point(10, 10),
                Size = new Size(150, 30),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Plus,
                IconColor = Color.White,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnAdd.Click += (s, e) => AddCategory();
            pnlToolbar.Controls.Add(btnAdd);

            IconButton btnRefresh = new IconButton
            {
                Text = "Refresh",
                Location = new Point(170, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Sync,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnRefresh.Click += (s, e) => LoadCategories();
            pnlToolbar.Controls.Add(btnRefresh);

            this.Controls.Add(pnlToolbar);

            DataGridView dgvCategories = new DataGridView
            {
                Name = "dgvCategories",
                Dock = DockStyle.Top,
                Height = 300,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvCategories.Columns.Add("ID", "ID");
            dgvCategories.Columns.Add("CategoryName", "Category Name");
            dgvCategories.Columns.Add("Description", "Description");
            dgvCategories.Columns.Add("Status", "Status");
            this.Controls.Add(dgvCategories);

            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            IconButton btnEdit = new IconButton
            {
                Text = "Edit",
                Location = new Point(10, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Edit,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnEdit.Click += (s, e) => EditCategory();
            pnlActions.Controls.Add(btnEdit);

            IconButton btnDelete = new IconButton
            {
                Text = "Delete",
                Location = new Point(120, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightCoral,
                Cursor = Cursors.Hand,
                IconChar = IconChar.TrashAlt,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnDelete.Click += (s, e) => DeleteCategory();
            pnlActions.Controls.Add(btnDelete);

            IconButton btnClose = new IconButton
            {
                Text = "Close",
                Location = new Point(230, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightGray,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Times,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnClose.Click += (s, e) => this.Close();
            pnlActions.Controls.Add(btnClose);

            this.Controls.Add(pnlActions);
        }

        private void LoadCategories()
        {
            try
            {
                _categories = CategoryRepository.GetAllCategories();
                DataGridView dgv = (DataGridView)this.Controls[1];
                dgv.Rows.Clear();

                foreach (var cat in _categories)
                {
                    dgv.Rows.Add(cat.ID, cat.CategoryName, cat.Description ?? "", cat.IsActive ? "Active" : "Inactive");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCategory()
        {
            var form = new Form
            {
                Text = "Add Category",
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            Label lblName = new Label { Text = "Category Name:", Location = new Point(10, 20), Size = new Size(120, 20) };
            TextBox txtName = new TextBox { Location = new Point(150, 20), Size = new Size(300, 25) };

            Label lblDesc = new Label { Text = "Description:", Location = new Point(10, 60), Size = new Size(120, 20) };
            TextBox txtDesc = new TextBox { Location = new Point(150, 60), Size = new Size(300, 60), Multiline = true };

            IconButton btnSave = new IconButton
            {
                Text = "Save",
                Location = new Point(150, 140),
                Size = new Size(120, 35),
                BackColor = Color.Green,
                ForeColor = Color.White,
                IconChar = IconChar.Save,
                IconColor = Color.White,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    var cat = new Category
                    {
                        CategoryName = txtName.Text,
                        Description = txtDesc.Text
                    };
                    CategoryRepository.CreateCategory(cat);
                    MessageBox.Show("Category added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form.Close();
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            IconButton btnCancel = new IconButton
            {
                Text = "Cancel",
                Location = new Point(280, 140),
                Size = new Size(120, 35),
                BackColor = Color.LightGray,
                IconChar = IconChar.Times,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnCancel.Click += (s, e) => form.Close();

            form.Controls.Add(lblName);
            form.Controls.Add(txtName);
            form.Controls.Add(lblDesc);
            form.Controls.Add(txtDesc);
            form.Controls.Add(btnSave);
            form.Controls.Add(btnCancel);

            form.ShowDialog();
        }

        private void EditCategory()
        {
            DataGridView dgv = (DataGridView)this.Controls[1];
            if (dgv.SelectedRows.Count > 0)
            {
                int id = (int)dgv.SelectedRows[0].Cells["ID"].Value;
                var cat = _categories.FirstOrDefault(c => c.ID == id);
                if (cat != null)
                {
                    var form = new Form
                    {
                        Text = "Edit Category",
                        Size = new Size(500, 300),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false
                    };

                    Label lblName = new Label { Text = "Category Name:", Location = new Point(10, 20), Size = new Size(120, 20) };
                    TextBox txtName = new TextBox { Location = new Point(150, 20), Size = new Size(300, 25), Text = cat.CategoryName };

                    Label lblDesc = new Label { Text = "Description:", Location = new Point(10, 60), Size = new Size(120, 20) };
                    TextBox txtDesc = new TextBox { Location = new Point(150, 60), Size = new Size(300, 60), Multiline = true, Text = cat.Description ?? "" };

                    IconButton btnSave = new IconButton
                    {
                        Text = "Update",
                        Location = new Point(150, 140),
                        Size = new Size(120, 35),
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        IconChar = IconChar.Save,
                        IconColor = Color.White,
                        IconSize = 20,
                        TextImageRelation = TextImageRelation.ImageBeforeText
                    };
                    btnSave.Click += (s, e) =>
                    {
                        try
                        {
                            cat.CategoryName = txtName.Text;
                            cat.Description = txtDesc.Text;
                            CategoryRepository.UpdateCategory(cat);
                            MessageBox.Show("Category updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            form.Close();
                            LoadCategories();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    IconButton btnCancel = new IconButton
                    {
                        Text = "Cancel",
                        Location = new Point(280, 140),
                        Size = new Size(120, 35),
                        BackColor = Color.LightGray,
                        IconChar = IconChar.Times,
                        IconColor = Color.Black,
                        IconSize = 20,
                        TextImageRelation = TextImageRelation.ImageBeforeText
                    };
                    btnCancel.Click += (s, e) => form.Close();

                    form.Controls.Add(lblName);
                    form.Controls.Add(txtName);
                    form.Controls.Add(lblDesc);
                    form.Controls.Add(txtDesc);
                    form.Controls.Add(btnSave);
                    form.Controls.Add(btnCancel);

                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a category to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteCategory()
        {
            DataGridView dgv = (DataGridView)this.Controls[1];
            if (dgv.SelectedRows.Count > 0 && MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = (int)dgv.SelectedRows[0].Cells["ID"].Value;
                try
                {
                    CategoryRepository.DeleteCategory(id);
                    MessageBox.Show("Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}