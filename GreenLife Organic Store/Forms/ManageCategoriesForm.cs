using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;
using System.IO;
using System;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ManageCategoriesForm : Form
    {
        private List<Category> _categories = new();

        public ManageCategoriesForm()
        {
            InitializeComponent();
            this.Text = "Manage Categories";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            if (!DesignMode)
                this.Load += ManageCategoriesForm_Load;
        }

        private void ManageCategoriesForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadCategories();
        }

        private void BtnAdd_Click(object? sender, EventArgs e) => AddCategory();
        private void BtnRefresh_Click(object? sender, EventArgs e) => LoadCategories();
        private void BtnEdit_Click(object? sender, EventArgs e) => EditCategory();
        private void BtnDelete_Click(object? sender, EventArgs e) => DeleteCategory();
        private void BtnClose_Click(object? sender, EventArgs e) => Close();

        private void LoadCategories()
        {
            try
            {
                _categories = CategoryRepository.GetAllCategories();
                _dgvCategories.Rows.Clear();

                foreach (var cat in _categories)
                {
                    Image? thumb = null;
                    try
                    {
                    if (!string.IsNullOrWhiteSpace(cat.ImagePath))
                    {
                        var full = ImageStore.GetFullPath(cat.ImagePath);
                        if (File.Exists(full))
                        {
                            using var img = Image.FromFile(full);
                            thumb = new Bitmap(img, new Size(60, 60));
                        }
                    }
                    }
                    catch { }

                    _dgvCategories.Rows.Add(thumb, cat.ID, cat.CategoryName, cat.Description ?? "", cat.IsActive ? "Active" : "Inactive");
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

            // Image selection
            Label lblImage = new Label { Text = "Image:", Location = new Point(10, 130), Size = new Size(120, 20) };
            PictureBox picPreview = new PictureBox { Name = "picPreview", Location = new Point(150, 130), Size = new Size(80, 80), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            Button btnChoose = new Button { Text = "Choose Image...", Location = new Point(240, 150), Size = new Size(120, 30) };
            btnChoose.Click += (s, e) =>
            {
                using OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var relative = ImageStore.SaveImageFile(ofd.FileName);
                        var full = ImageStore.GetFullPath(relative);
                        picPreview.ImageLocation = full;
                        picPreview.Tag = relative;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to add image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            IconButton btnSave = new IconButton
            {
                Text = "Save",
                // move below image preview
                Location = new Point(150, 220),
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
                    // Check for image from preview
                    if (form.Controls.Find("picPreview", true).FirstOrDefault() is PictureBox pp && pp.Tag is string imgPath)
                    {
                        cat.ImagePath = imgPath;
                    }
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
                Location = new Point(280, 220),
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
            form.Controls.Add(lblImage);
            form.Controls.Add(picPreview);
            form.Controls.Add(btnChoose);
            form.Controls.Add(btnSave);
            form.Controls.Add(btnCancel);

            form.ShowDialog();
        }

        private void EditCategory()
        {
            if (_dgvCategories.SelectedRows.Count > 0)
            {
                int id = (int)_dgvCategories.SelectedRows[0].Cells["ID"].Value;
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

                    // Image selection for edit
                    Label lblImage = new Label { Text = "Image:", Location = new Point(10, 130), Size = new Size(120, 20) };
                    PictureBox picPreview = new PictureBox { Name = "picPreview", Location = new Point(150, 130), Size = new Size(80, 80), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
                    if (!string.IsNullOrWhiteSpace(cat.ImagePath))
                    {
                        var full = ImageStore.GetFullPath(cat.ImagePath);
                        if (File.Exists(full))
                            picPreview.ImageLocation = full;
                    }
                    Button btnChoose = new Button { Text = "Choose Image...", Location = new Point(240, 150), Size = new Size(120, 30) };
                    btnChoose.Click += (s, e) =>
                    {
                        using OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                        var relative = ImageStore.SaveImageFile(ofd.FileName);
                        var full = ImageStore.GetFullPath(relative);
                        picPreview.ImageLocation = full;
                        picPreview.Tag = relative;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to add image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    IconButton btnSave = new IconButton
                    {
                        Text = "Update",
                        // move below image preview
                        Location = new Point(150, 220),
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
                            // Keep existing image unless new chosen
                            if (picPreview.Tag is string newImg)
                                cat.ImagePath = newImg;
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
                        Location = new Point(280, 220),
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
                    // Add image controls for edit dialog
                    form.Controls.Add(lblImage);
                    form.Controls.Add(picPreview);
                    form.Controls.Add(btnChoose);
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
            if (_dgvCategories.SelectedRows.Count > 0 && MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = (int)_dgvCategories.SelectedRows[0].Cells["ID"].Value;
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