using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class DiscountEditorForm : Form
    {
        private Product _product;
        private decimal _originalDiscountPrice;
        private Label _lblPercentValue;
        private Label _lblSavingsValue;
        private NumericUpDown _numDiscountPrice;

        public DiscountEditorForm(Product product)
        {
            _product = product;
            _originalDiscountPrice = product.DiscountPrice ?? 0;

            this.Text = "Edit Discount";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Load += DiscountEditorForm_Load;
        }

        private void DiscountEditorForm_Load(object? sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Header Panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(52, 152, 219),
                Padding = new Padding(15)
            };

            Label lblTitle = new Label
            {
                Text = $"Edit Discount - {_product.ProductName}",
                Location = new Point(15, 12),
                Size = new Size(450, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            // Content Panel
            Panel pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            // Product Info
            Label lblProductInfo = new Label
            {
                Text = "Product Information",
                Location = new Point(20, 20),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblProductInfo);

            // Product Name
            Label lblProductName = new Label
            {
                Text = "Product Name:",
                Location = new Point(20, 55),
                Size = new Size(120, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblProductName);

            TextBox txtProductName = new TextBox
            {
                Text = _product.ProductName,
                Location = new Point(150, 52),
                Size = new Size(300, 25),
                ReadOnly = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlContent.Controls.Add(txtProductName);

            // Category
            Label lblCategory = new Label
            {
                Text = "Category:",
                Location = new Point(20, 85),
                Size = new Size(120, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblCategory);

            TextBox txtCategory = new TextBox
            {
                Text = _product.CategoryName,
                Location = new Point(150, 82),
                Size = new Size(300, 25),
                ReadOnly = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlContent.Controls.Add(txtCategory);

            // Pricing Section
            Label lblPricing = new Label
            {
                Text = "Pricing",
                Location = new Point(20, 125),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblPricing);

            // Original Price
            Label lblOriginalPrice = new Label
            {
                Text = "Original Price (Rs.):",
                Location = new Point(20, 160),
                Size = new Size(120, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblOriginalPrice);

            TextBox txtOriginalPrice = new TextBox
            {
                Text = _product.Price.ToString("N2"),
                Location = new Point(150, 157),
                Size = new Size(300, 25),
                ReadOnly = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlContent.Controls.Add(txtOriginalPrice);

            // Discount Price
            Label lblDiscountPrice = new Label
            {
                Text = "Discount Price (Rs.):",
                Location = new Point(20, 190),
                Size = new Size(120, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblDiscountPrice);

            _numDiscountPrice = new NumericUpDown
            {
                Name = "numDiscountPrice",
                Location = new Point(150, 187),
                Size = new Size(300, 25),
                Minimum = 0,
                Maximum = 999999,
                DecimalPlaces = 2,
                Value = _originalDiscountPrice > 0 ? (decimal)_originalDiscountPrice : (decimal)_product.Price,
                Font = new Font("Segoe UI", 10)
            };
            _numDiscountPrice.ValueChanged += (s, e) => UpdateDiscountInfo();
            pnlContent.Controls.Add(_numDiscountPrice);

            // Discount Percentage Display
            Label lblDiscountPercent = new Label
            {
                Text = "Discount Percentage:",
                Location = new Point(20, 220),
                Size = new Size(120, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblDiscountPercent);

            _lblPercentValue = new Label
            {
                Name = "lblPercentValue",
                Text = "0%",
                Location = new Point(150, 220),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113)
            };
            pnlContent.Controls.Add(_lblPercentValue);

            // Savings Display
            Label lblSavings = new Label
            {
                Text = "You Save:",
                Location = new Point(20, 250),
                Size = new Size(120, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlContent.Controls.Add(lblSavings);

            _lblSavingsValue = new Label
            {
                Name = "lblSavingsValue",
                Text = "Rs. 0.00",
                Location = new Point(150, 250),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219)
            };
            pnlContent.Controls.Add(_lblSavingsValue);

            this.Controls.Add(pnlContent);

            // Button Panel
            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.White,
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            IconButton btnSave = new IconButton
            {
                Text = "Save Discount",
                Location = new Point(150, 10),
                Size = new Size(140, 30),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Save,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += (s, e) => SaveDiscount();
            pnlButtons.Controls.Add(btnSave);

            IconButton btnCancel = new IconButton
            {
                Text = "Cancel",
                Location = new Point(300, 10),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Times,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            pnlButtons.Controls.Add(btnCancel);

            this.Controls.Add(pnlButtons);

            // Initial calculation
            UpdateDiscountInfo();
        }

        private void UpdateDiscountInfo()
        {
            if (_numDiscountPrice == null || _lblPercentValue == null || _lblSavingsValue == null)
                return;

            decimal discountPrice = _numDiscountPrice.Value;
            decimal originalPrice = (decimal)_product.Price;

            if (discountPrice >= originalPrice)
            {
                _lblPercentValue.Text = "0%";
                _lblPercentValue.ForeColor = Color.FromArgb(149, 165, 166);
                _lblSavingsValue.Text = "Rs. 0.00";
                _lblSavingsValue.ForeColor = Color.FromArgb(149, 165, 166);
            }
            else
            {
                decimal savings = originalPrice - discountPrice;
                int discountPercent = (int)(((savings) / originalPrice) * 100);
                _lblPercentValue.Text = $"{discountPercent}%";
                _lblPercentValue.ForeColor = Color.FromArgb(46, 204, 113);
                _lblSavingsValue.Text = $"Rs. {savings:N2}";
                _lblSavingsValue.ForeColor = Color.FromArgb(52, 152, 219);
            }
        }

        private void SaveDiscount()
        {
            if (_numDiscountPrice == null)
                return;

            decimal discountPrice = _numDiscountPrice.Value;
            decimal originalPrice = (decimal)_product.Price;

            if (discountPrice >= originalPrice)
            {
                MessageBox.Show("Discount price must be less than the original price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (discountPrice < 0)
            {
                MessageBox.Show("Discount price cannot be negative.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _product.DiscountPrice = discountPrice;
                if (ProductRepository.UpdateProduct(_product))
                {
                    MessageBox.Show($"Discount updated successfully! Saving {_product.GetDiscountPercent()}% on {_product.ProductName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving discount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
