using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using System.IO;
using System;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AddEditProductForm : Form
    {
        private Product? _existingProduct;
        private List<Category> _categories = new();

        public AddEditProductForm()
        {
            this.Text = "Add New Product";
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Load += AddEditProductForm_Load;
        }

        public AddEditProductForm(Product product) : this()
        {
            _existingProduct = product;
            this.Text = "Edit Product";
        }

        private void AddEditProductForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadCategories();
            if (_existingProduct != null)
            {
                PopulateForm();
            }
        }

        private void InitializeUI()
        {
            int yPosition = 10;

            // Product Name
            Label lblName = new Label { Text = "Product Name:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtName = new TextBox { Name = "txtName", Location = new Point(120, yPosition), Size = new Size(400, 25) };
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            yPosition += 35;

            // Category
            Label lblCategory = new Label { Text = "Category:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            ComboBox cmbCategory = new ComboBox
            {
                Name = "cmbCategory",
                Location = new Point(120, yPosition),
                Size = new Size(400, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(lblCategory);
            this.Controls.Add(cmbCategory);
            yPosition += 35;

            // Description
            Label lblDescription = new Label { Text = "Description:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtDescription = new TextBox
            {
                Name = "txtDescription",
                Location = new Point(120, yPosition),
                Size = new Size(400, 60),
                Multiline = true
            };
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            yPosition += 70;

            // Price
            Label lblPrice = new Label { Text = "Price (Rs.):", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            NumericUpDown numPrice = new NumericUpDown
            {
                Name = "numPrice",
                Location = new Point(120, yPosition),
                Size = new Size(150, 25),
                Maximum = 1000000,
                DecimalPlaces = 2
            };
            this.Controls.Add(lblPrice);
            this.Controls.Add(numPrice);
            yPosition += 35;

            // Discount Price
            Label lblDiscount = new Label { Text = "Discount Price:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            NumericUpDown numDiscount = new NumericUpDown
            {
                Name = "numDiscount",
                Location = new Point(120, yPosition),
                Size = new Size(150, 25),
                Maximum = 1000000,
                DecimalPlaces = 2
            };
            this.Controls.Add(lblDiscount);
            this.Controls.Add(numDiscount);
            yPosition += 35;

            // Stock
            Label lblStock = new Label { Text = "Stock Quantity:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            NumericUpDown numStock = new NumericUpDown
            {
                Name = "numStock",
                Location = new Point(120, yPosition),
                Size = new Size(150, 25),
                Maximum = 10000
            };
            this.Controls.Add(lblStock);
            this.Controls.Add(numStock);
            yPosition += 35;

            // Supplier
            Label lblSupplier = new Label { Text = "Supplier:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtSupplier = new TextBox { Name = "txtSupplier", Location = new Point(120, yPosition), Size = new Size(400, 25) };
            this.Controls.Add(lblSupplier);
            this.Controls.Add(txtSupplier);
            yPosition += 35;

            // Featured
            CheckBox chkFeatured = new CheckBox
            {
                Name = "chkFeatured",
                Text = "Mark as Featured",
                Location = new Point(120, yPosition),
                Size = new Size(150, 25)
            };
            this.Controls.Add(chkFeatured);
            yPosition += 35;

            // Active
            CheckBox chkActive = new CheckBox
            {
                Name = "chkActive",
                Text = "Active",
                Location = new Point(120, yPosition),
                Size = new Size(150, 25),
                Checked = true
            };
            this.Controls.Add(chkActive);
            yPosition += 45;

            // Image selection
            Label lblImage = new Label { Text = "Image:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            PictureBox picPreview = new PictureBox { Name = "picPreview", Location = new Point(120, yPosition), Size = new Size(120, 120), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            Button btnChooseImage = new Button { Name = "btnChooseImage", Text = "Choose Image...", Location = new Point(250, yPosition + 45), Size = new Size(140, 30) };
            btnChooseImage.Click += BtnChooseImage_Click;
            this.Controls.Add(lblImage);
            this.Controls.Add(picPreview);
            this.Controls.Add(btnChooseImage);
            yPosition += 140;

            // Save button
            Button btnSave = new Button
            {
                Text = "Save Product",
                Location = new Point(150, yPosition),
                Size = new Size(150, 40),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Cancel button
            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(310, yPosition + 10),
                Size = new Size(150, 40),
                BackColor = Color.LightGray
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
        }

        private void LoadCategories()
        {
            try
            {
                _categories = CategoryRepository.GetAllCategories();
                ComboBox cmbCategory = (ComboBox)this.Controls["cmbCategory"];

                foreach (var category in _categories)
                {
                    cmbCategory.Items.Add(category.CategoryName);
                }

                if (cmbCategory.Items.Count > 0)
                    cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateForm()
        {
            TextBox txtName = (TextBox)this.Controls["txtName"];
            ComboBox cmbCategory = (ComboBox)this.Controls["cmbCategory"];
            TextBox txtDescription = (TextBox)this.Controls["txtDescription"];
            NumericUpDown numPrice = (NumericUpDown)this.Controls["numPrice"];
            NumericUpDown numDiscount = (NumericUpDown)this.Controls["numDiscount"];
            NumericUpDown numStock = (NumericUpDown)this.Controls["numStock"];
            TextBox txtSupplier = (TextBox)this.Controls["txtSupplier"];
            CheckBox chkFeatured = (CheckBox)this.Controls["chkFeatured"];
            CheckBox chkActive = (CheckBox)this.Controls["chkActive"];

            txtName.Text = _existingProduct.ProductName;
            cmbCategory.SelectedItem = _existingProduct.CategoryName;
            txtDescription.Text = _existingProduct.Description ?? "";
            numPrice.Value = _existingProduct.Price;
            numDiscount.Value = _existingProduct.DiscountPrice ?? 0;
            numStock.Value = _existingProduct.Stock;
            txtSupplier.Text = _existingProduct.Supplier ?? "";
            chkFeatured.Checked = _existingProduct.IsFeatured;
            chkActive.Checked = _existingProduct.IsActive;

            // Populate image preview if available
            try
            {
                var pic = (PictureBox)this.Controls["picPreview"];
                if (!string.IsNullOrWhiteSpace(_existingProduct.ImagePath) && File.Exists(_existingProduct.ImagePath))
                {
                    pic.ImageLocation = _existingProduct.ImagePath;
                    pic.Tag = _existingProduct.ImagePath;
                }
                else
                {
                    pic.Image = null;
                    pic.Tag = _existingProduct.ImagePath; // keep path in tag even if missing file so save logic can preserve value
                }
            }
            catch
            {
                // ignore if preview not available
            }
        }

        private void InitializeComponent()
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TextBox txtName = (TextBox)this.Controls["txtName"];
            ComboBox cmbCategory = (ComboBox)this.Controls["cmbCategory"];
            TextBox txtDescription = (TextBox)this.Controls["txtDescription"];
            NumericUpDown numPrice = (NumericUpDown)this.Controls["numPrice"];
            NumericUpDown numDiscount = (NumericUpDown)this.Controls["numDiscount"];
            NumericUpDown numStock = (NumericUpDown)this.Controls["numStock"];
            TextBox txtSupplier = (TextBox)this.Controls["txtSupplier"];
            CheckBox chkFeatured = (CheckBox)this.Controls["chkFeatured"];
            CheckBox chkActive = (CheckBox)this.Controls["chkActive"];

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var category = _categories.FirstOrDefault(c => c.CategoryName == cmbCategory.SelectedItem.ToString());
                if (category == null)
                {
                    MessageBox.Show("Please select a valid category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = new Product
                {
                    ProductName = txtName.Text,
                    CategoryID = category.ID,
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text,
                    Price = numPrice.Value,
                    DiscountPrice = numDiscount.Value > 0 ? numDiscount.Value : null,
                    Stock = (int)numStock.Value,
                    Supplier = string.IsNullOrWhiteSpace(txtSupplier.Text) ? null : txtSupplier.Text,
                ImagePath = ((PictureBox)this.Controls["picPreview"]).Tag as string,
                    IsFeatured = chkFeatured.Checked,
                    IsActive = chkActive.Checked
                };

                if (_existingProduct != null)
                {
                    product.ID = _existingProduct.ID;
                    // If no new image selected, keep existing path
                    if (string.IsNullOrWhiteSpace(product.ImagePath))
                        product.ImagePath = _existingProduct.ImagePath;
                    if (ProductRepository.UpdateProduct(product))
                    {
                        MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    if (ProductRepository.CreateProduct(product) > 0)
                    {
                        MessageBox.Show("Product created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var imagesDir = Path.Combine(Application.StartupPath, "images");
                    Directory.CreateDirectory(imagesDir);
                    var destFileName = Path.Combine(imagesDir, Path.GetFileName(ofd.FileName));
                    // If file exists, create a unique name
                    if (File.Exists(destFileName))
                    {
                        var unique = Guid.NewGuid().ToString().Split('-')[0];
                        destFileName = Path.Combine(imagesDir, Path.GetFileNameWithoutExtension(ofd.FileName) + "_" + unique + Path.GetExtension(ofd.FileName));
                    }
                    File.Copy(ofd.FileName, destFileName);
                    var pic = (PictureBox)this.Controls["picPreview"];
                    pic.ImageLocation = destFileName;
                    pic.Tag = destFileName; // store path in Tag so it can be saved to DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
