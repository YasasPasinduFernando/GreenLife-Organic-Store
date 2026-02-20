using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;
using System.IO;
using System.Linq;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AddEditDiscountForm : Form
    {
        private Discount? _existingDiscount;
        private int? _existingProductId;
        private List<Product> _products = new();

        public AddEditDiscountForm()
        {
            InitializeComponent();
            _products = new List<Product>();
            this.Text = "Add New Discount";
            this.Size = new Size(500, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.AutoScroll = true;
            if (!DesignMode)
                this.Load += AddEditDiscountForm_Load;
        }

        public AddEditDiscountForm(List<Product> products) : this()
        {
            _products = products;
        }

        public AddEditDiscountForm(List<Product> products, Discount discount) : this(products)
        {
            _existingDiscount = discount;
            _existingProductId = discount.ProductID;
            this.Text = "Edit Discount";
        }

        private void AddEditDiscountForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            foreach (var product in _products)
                cmbProduct.Items.Add($"{product.ProductName} (ID: {product.ID})");
            if (cmbProduct.Items.Count > 0)
                cmbProduct.SelectedIndex = 0;
            UpdateProductImage();
            if (_existingDiscount != null)
                PopulateForm();
        }

        private void CmbProduct_SelectedIndexChanged(object? sender, EventArgs e) => UpdateProductImage();
        private void BtnCancel_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void PopulateForm()
        {
            if (_existingDiscount == null) return;
            txtName.Text = _existingDiscount.DiscountName;
            numPercent.Value = _existingDiscount.DiscountPercent;
            txtDescription.Text = _existingDiscount.Description ?? "";
            dtpStartDate.Value = _existingDiscount.StartDate;
            dtpEndDate.Value = _existingDiscount.EndDate;
            chkActive.Checked = _existingDiscount.IsActive;

            for (int i = 0; i < cmbProduct.Items.Count; i++)
            {
                if (cmbProduct.Items[i].ToString().Contains($"ID: {_existingDiscount.ProductID}"))
                {
                    cmbProduct.SelectedIndex = i;
                    break;
                }
            }

            UpdateProductImage();
        }

        private void UpdateProductImage()
        {
            if (cmbProduct.SelectedIndex < 0)
            {
                picProduct.Image = null;
                picProduct.ImageLocation = null;
                return;
            }

            string selectedItem = cmbProduct.SelectedItem?.ToString() ?? "";
            if (!selectedItem.Contains("ID: "))
            {
                picProduct.Image = null;
                picProduct.ImageLocation = null;
                return;
            }

            string idStr = selectedItem.Substring(selectedItem.LastIndexOf("ID: ") + 4).TrimEnd(')');
            if (!int.TryParse(idStr, out int productId))
            {
                picProduct.Image = null;
                picProduct.ImageLocation = null;
                return;
            }

            var product = _products.FirstOrDefault(p => p.ID == productId);
            if (product == null || string.IsNullOrWhiteSpace(product.ImagePath))
            {
                picProduct.Image = null;
                picProduct.ImageLocation = null;
                return;
            }

            var fullPath = ImageStore.GetFullPath(product.ImagePath);
            if (!File.Exists(fullPath))
            {
                picProduct.Image = null;
                picProduct.ImageLocation = null;
                return;
            }

            picProduct.ImageLocation = fullPath;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a discount name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPercent.Value <= 0 || numPercent.Value > 100)
            {
                MessageBox.Show("Discount percentage must be between 1 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show("End date must be after start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectedItem = cmbProduct.SelectedItem?.ToString() ?? "";
                string idStr = selectedItem.Substring(selectedItem.LastIndexOf("ID: ") + 4).TrimEnd(')');
                int productId = int.Parse(idStr);

                var discount = new Discount
                {
                    DiscountName = txtName.Text ?? "",
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text,
                    DiscountPercent = numPercent.Value,
                    ProductID = productId,
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    IsActive = chkActive.Checked
                };

                if (_existingDiscount != null)
                {
                    discount.ID = _existingDiscount.ID;
                    if (DiscountRepository.UpdateDiscount(discount))
                    {
                        DiscountRepository.SyncActiveDiscountForProduct(productId);
                        if (_existingProductId.HasValue && _existingProductId.Value != productId)
                        {
                            DiscountRepository.SyncActiveDiscountForProduct(_existingProductId.Value);
                        }
                        MessageBox.Show("Discount updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    var newId = DiscountRepository.CreateDiscount(discount);
                    if (newId > 0)
                    {
                        discount.ID = newId;
                        bool deactivatedOld = false;
                        try
                        {
                            var existing = DiscountRepository.GetDiscountsByProductId(productId);
                            foreach (var old in existing)
                            {
                                if (old.ID != newId && old.IsActive)
                                {
                                    old.IsActive = false;
                                    old.EndDate = DateTime.Now;
                                    DiscountRepository.UpdateDiscount(old);
                                    deactivatedOld = true;
                                }
                            }
                        }
                        catch
                        {
                        }
                        DiscountRepository.SyncActiveDiscountForProduct(productId);
                        var msg = deactivatedOld
                            ? "Discount created successfully! Previous discounts for this product were deactivated."
                            : "Discount created successfully!";
                        MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
