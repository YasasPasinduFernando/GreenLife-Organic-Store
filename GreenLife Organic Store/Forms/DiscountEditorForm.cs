using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class DiscountEditorForm : Form
    {
        private Product _product;
        private decimal _originalDiscountPrice;

        public DiscountEditorForm()
            : this(new Product { ID = 0, ProductName = "Product", Price = 0, Stock = 0 })
        { }

        public DiscountEditorForm(Product product)
        {
            InitializeComponent();
            _product = product;
            _originalDiscountPrice = product.DiscountPrice ?? 0;
            this.Text = "Edit Discount";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);
            if (!DesignMode)
                this.Load += DiscountEditorForm_Load;
        }

        private void DiscountEditorForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            lblTitle.Text = $"Edit Discount - {_product.ProductName}";
            txtProductName.Text = _product.ProductName;
            txtCategory.Text = _product.CategoryName;
            txtOriginalPrice.Text = _product.Price.ToString("N2");
            _numDiscountPrice.Value = _originalDiscountPrice > 0 ? (decimal)_originalDiscountPrice : (decimal)_product.Price;
            UpdateDiscountInfo();
        }

        private void NumDiscountPrice_ValueChanged(object? sender, EventArgs e) => UpdateDiscountInfo();
        private void BtnSave_Click(object? sender, EventArgs e) => SaveDiscount();
        private void BtnCancel_Click(object? sender, EventArgs e) => DialogResult = DialogResult.Cancel;

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
