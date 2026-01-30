using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;
using System.IO;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AddEditDiscountForm : Form
    {
        private Discount? _existingDiscount;
        private int? _existingProductId;
        private List<Product> _products = new();

        public AddEditDiscountForm(List<Product> products)
        {
            this.Text = "Add New Discount";
            this.Size = new Size(500, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.AutoScroll = true;
            this.Load += AddEditDiscountForm_Load;
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
            InitializeUI();
            if (_existingDiscount != null)
            {
                PopulateForm();
            }
        }

        private void InitializeUI()
        {
            int yPosition = 10;

            // Discount Name
            Label lblName = new Label { Text = "Discount Name:", Location = new Point(10, yPosition), Size = new Size(120, 20), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            TextBox txtName = new TextBox { Name = "txtName", Location = new Point(140, yPosition), Size = new Size(330, 25) };
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            yPosition += 35;

            // Product Selection
            Label lblProduct = new Label { Text = "Select Product:", Location = new Point(10, yPosition), Size = new Size(120, 20), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            ComboBox cmbProduct = new ComboBox
            {
                Name = "cmbProduct",
                Location = new Point(140, yPosition),
                Size = new Size(330, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblProduct);
            this.Controls.Add(cmbProduct);
            cmbProduct.SelectedIndexChanged += (s, e) => UpdateProductImage();
            yPosition += 35;

            // Discount Percent
            Label lblPercent = new Label { Text = "Discount %:", Location = new Point(10, yPosition), Size = new Size(120, 20), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            NumericUpDown numPercent = new NumericUpDown
            {
                Name = "numPercent",
                Location = new Point(140, yPosition),
                Size = new Size(330, 25),
                Minimum = 1,
                Maximum = 100,
                DecimalPlaces = 2,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblPercent);
            this.Controls.Add(numPercent);
            yPosition += 35;

            // Description
            Label lblDescription = new Label { Text = "Description:", Location = new Point(10, yPosition), Size = new Size(120, 20), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            TextBox txtDescription = new TextBox
            {
                Name = "txtDescription",
                Location = new Point(140, yPosition),
                Size = new Size(330, 60),
                Multiline = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            yPosition += 70;

            // Start Date
            Label lblStartDate = new Label { Text = "Start Date:", Location = new Point(10, yPosition), Size = new Size(120, 20), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            DateTimePicker dtpStartDate = new DateTimePicker
            {
                Name = "dtpStartDate",
                Location = new Point(140, yPosition),
                Size = new Size(330, 25),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(lblStartDate);
            this.Controls.Add(dtpStartDate);
            yPosition += 35;

            // End Date
            Label lblEndDate = new Label { Text = "End Date:", Location = new Point(10, yPosition), Size = new Size(120, 20), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            DateTimePicker dtpEndDate = new DateTimePicker
            {
                Name = "dtpEndDate",
                Location = new Point(140, yPosition),
                Size = new Size(330, 25),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10)
            };
            dtpEndDate.Value = DateTime.Now.AddDays(30);
            this.Controls.Add(lblEndDate);
            this.Controls.Add(dtpEndDate);
            yPosition += 35;

            // Active checkbox
            CheckBox chkActive = new CheckBox
            {
                Name = "chkActive",
                Text = "Active",
                Location = new Point(140, yPosition),
                Size = new Size(150, 25),
                Checked = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(chkActive);
            yPosition += 40;

            // Product Image Preview
            Label lblImage = new Label { Text = "Product Image:", Location = new Point(10, yPosition), Size = new Size(120, 20), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            PictureBox picProduct = new PictureBox
            {
                Name = "picProduct",
                Location = new Point(140, yPosition),
                Size = new Size(120, 120),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(lblImage);
            this.Controls.Add(picProduct);
            yPosition += 140;

            // Save Button
            IconButton btnSave = new IconButton
            {
                Text = "Save Discount",
                Location = new Point(100, yPosition),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                IconChar = IconChar.Save,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Cancel Button
            IconButton btnCancel = new IconButton
            {
                Text = "Cancel",
                Location = new Point(260, yPosition),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand,
                IconChar = IconChar.Times,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);

            // Populate products combo
            foreach (var product in _products)
            {
                cmbProduct.Items.Add($"{product.ProductName} (ID: {product.ID})");
            }

            if (cmbProduct.Items.Count > 0)
                cmbProduct.SelectedIndex = 0;
            UpdateProductImage();
        }

        private void PopulateForm()
        {
            TextBox txtName = (TextBox)this.Controls["txtName"];
            ComboBox cmbProduct = (ComboBox)this.Controls["cmbProduct"];
            NumericUpDown numPercent = (NumericUpDown)this.Controls["numPercent"];
            TextBox txtDescription = (TextBox)this.Controls["txtDescription"];
            DateTimePicker dtpStartDate = (DateTimePicker)this.Controls["dtpStartDate"];
            DateTimePicker dtpEndDate = (DateTimePicker)this.Controls["dtpEndDate"];
            CheckBox chkActive = (CheckBox)this.Controls["chkActive"];

            txtName.Text = _existingDiscount.DiscountName;
            numPercent.Value = _existingDiscount.DiscountPercent;
            txtDescription.Text = _existingDiscount.Description ?? "";
            dtpStartDate.Value = _existingDiscount.StartDate;
            dtpEndDate.Value = _existingDiscount.EndDate;
            chkActive.Checked = _existingDiscount.IsActive;

            // Select the product in combo
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
            if (this.Controls["cmbProduct"] is not ComboBox cmbProduct ||
                this.Controls["picProduct"] is not PictureBox picProduct)
            {
                return;
            }

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
            TextBox? txtName = this.Controls["txtName"] as TextBox;
            ComboBox? cmbProduct = this.Controls["cmbProduct"] as ComboBox;
            NumericUpDown? numPercent = this.Controls["numPercent"] as NumericUpDown;
            TextBox? txtDescription = this.Controls["txtDescription"] as TextBox;
            DateTimePicker? dtpStartDate = this.Controls["dtpStartDate"] as DateTimePicker;
            DateTimePicker? dtpEndDate = this.Controls["dtpEndDate"] as DateTimePicker;
            CheckBox? chkActive = this.Controls["chkActive"] as CheckBox;

            // Validation
            if (string.IsNullOrWhiteSpace(txtName?.Text))
            {
                MessageBox.Show("Please enter a discount name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProduct?.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPercent?.Value <= 0 || numPercent?.Value > 100)
            {
                MessageBox.Show("Discount percentage must be between 1 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate?.Value >= dtpEndDate?.Value)
            {
                MessageBox.Show("End date must be after start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Extract product ID from selected item
                string selectedItem = cmbProduct?.SelectedItem?.ToString() ?? "";
                string idStr = selectedItem.Substring(selectedItem.LastIndexOf("ID: ") + 4).TrimEnd(')');
                int productId = int.Parse(idStr);

                var discount = new Discount
                {
                    DiscountName = txtName?.Text ?? "",
                    Description = string.IsNullOrWhiteSpace(txtDescription?.Text) ? null : txtDescription.Text,
                    DiscountPercent = numPercent?.Value ?? 0,
                    ProductID = productId,
                    StartDate = dtpStartDate?.Value ?? DateTime.Now,
                    EndDate = dtpEndDate?.Value ?? DateTime.Now.AddDays(30),
                    IsActive = chkActive?.Checked ?? true
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
                            // non-fatal
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
