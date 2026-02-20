using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
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
            InitializeComponent();
            if (!DesignMode)
                this.Load += AddEditProductForm_Load;
        }

        public AddEditProductForm(Product product) : this()
        {
            _existingProduct = product;
            this.Text = "Edit Product";
        }

        private void AddEditProductForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadCategories();
            if (_existingProduct != null)
                PopulateForm();
        }

        private void BtnManageDiscounts_Click(object? sender, EventArgs e)
        {
            using var form = new DiscountManagementForm();
            form.ShowDialog();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadCategories()
        {
            try
            {
                _categories = CategoryRepository.GetAllCategories();
                cmbCategory.Items.Clear();
                foreach (var category in _categories)
                    cmbCategory.Items.Add(category.CategoryName);
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
            if (_existingProduct == null) return;
            txtName.Text = _existingProduct.ProductName;
            cmbCategory.SelectedItem = _existingProduct.CategoryName;
            txtDescription.Text = _existingProduct.Description ?? "";
            numPrice.Value = _existingProduct.Price;
            numStock.Value = _existingProduct.Stock;
            txtSupplier.Text = _existingProduct.Supplier ?? "";
            chkFeatured.Checked = _existingProduct.IsFeatured;
            chkActive.Checked = _existingProduct.IsActive;
            if (_existingProduct.DiscountPrice.HasValue && _existingProduct.DiscountPrice.Value > 0)
                lblDiscountValue.Text = $"Rs. {_existingProduct.DiscountPrice.Value:N2}";
            else
                lblDiscountValue.Text = "-";

            try
            {
                if (!string.IsNullOrWhiteSpace(_existingProduct.ImagePath))
                {
                    var full = ImageStore.GetFullPath(_existingProduct.ImagePath);
                    if (File.Exists(full))
                    {
                        picPreview.ImageLocation = full;
                        try
                        {
                            var imagesDir = ImageStore.GetImagesDirectory();
                            var fullNormalized = Path.GetFullPath(full);
                            var imagesDirNormalized = Path.GetFullPath(imagesDir);
                            if (fullNormalized.StartsWith(imagesDirNormalized, StringComparison.OrdinalIgnoreCase))
                            {
                                var relFromImages = Path.GetRelativePath(imagesDirNormalized, fullNormalized)
                                    .Replace(Path.DirectorySeparatorChar, '/');
                                picPreview.Tag = "Images/" + relFromImages;
                            }
                            else
                                picPreview.Tag = _existingProduct.ImagePath;
                        }
                        catch
                        {
                            picPreview.Tag = _existingProduct.ImagePath;
                        }
                    }
                    else
                    {
                        picPreview.Image = null;
                        picPreview.Tag = _existingProduct.ImagePath;
                    }
                }
                else
                {
                    picPreview.Image = null;
                    picPreview.Tag = null;
                }
            }
            catch { }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
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
                var category = _categories.FirstOrDefault(c => c.CategoryName == cmbCategory.SelectedItem?.ToString());
                if (category == null)
                {
                    MessageBox.Show("Please select a valid category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var rawImagePath = picPreview.Tag as string;
                if (!string.IsNullOrWhiteSpace(rawImagePath))
                {
                    try
                    {
                        var fullPath = ImageStore.GetFullPath(rawImagePath);
                        var imagesDir = ImageStore.GetImagesDirectory();
                        var fullNormalized = Path.GetFullPath(fullPath);
                        var imagesDirNormalized = Path.GetFullPath(imagesDir);
                        if (fullNormalized.StartsWith(imagesDirNormalized, StringComparison.OrdinalIgnoreCase))
                        {
                            var relFromImages = Path.GetRelativePath(imagesDirNormalized, fullNormalized)
                                .Replace(Path.DirectorySeparatorChar, '/');
                            rawImagePath = "Images/" + relFromImages;
                        }
                    }
                    catch { }
                }

                var product = new Product
                {
                    ProductName = txtName.Text,
                    CategoryID = category.ID,
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text,
                    Price = numPrice.Value,
                    DiscountPrice = _existingProduct?.DiscountPrice,
                    Stock = (int)numStock.Value,
                    Supplier = string.IsNullOrWhiteSpace(txtSupplier.Text) ? null : txtSupplier.Text,
                    ImagePath = rawImagePath,
                    IsFeatured = chkFeatured.Checked,
                    IsActive = chkActive.Checked
                };

                if (_existingProduct != null)
                {
                    product.ID = _existingProduct.ID;
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
        }
    }
}
