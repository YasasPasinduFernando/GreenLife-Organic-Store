using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;
using System.IO;

namespace GreenLife_Organic_Store.Forms
{
    public partial class DiscountManagementForm : Form
    {
        private List<Discount> _allDiscounts = new();
        private List<Product> _allProducts = new();

        public DiscountManagementForm()
        {
            InitializeComponent();
            this.Text = "Manage Discounts";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            if (!DesignMode)
                this.Load += DiscountManagementForm_Load;
        }

        private void DiscountManagementForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadData();
        }

        private void BtnAdd_Click(object? sender, EventArgs e) => AddDiscount();
        private void BtnRefresh_Click(object? sender, EventArgs e) => LoadData();
        private void BtnEdit_Click(object? sender, EventArgs e) => EditSelectedDiscount();
        private void BtnDelete_Click(object? sender, EventArgs e) => DeleteSelectedDiscount();
        private void BtnClose_Click(object? sender, EventArgs e) => Close();
        private void DgvDiscounts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditSelectedDiscount();
        }

        private void LoadData()
        {
            try
            {
                _allDiscounts = DiscountRepository.GetAllDiscounts();
                _allProducts = ProductRepository.GetAllProducts();
                foreach (var productId in _allDiscounts.Select(d => d.ProductID).Distinct())
                {
                    DiscountRepository.SyncActiveDiscountForProduct(productId);
                }
                LoadDiscounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDiscounts()
        {
            try
            {
                _dgvDiscounts.Rows.Clear();

                foreach (var discount in _allDiscounts)
                {
                    Image? thumb = null;
                    try
                    {
                        var product = _allProducts.FirstOrDefault(p => p.ID == discount.ProductID);
                        if (product != null && !string.IsNullOrWhiteSpace(product.ImagePath))
                        {
                            var fullPath = ImageStore.GetFullPath(product.ImagePath);
                            if (File.Exists(fullPath))
                            {
                                using var img = Image.FromFile(fullPath);
                                thumb = new Bitmap(img, new Size(60, 60));
                            }
                        }
                    }
                    catch { }

                    _dgvDiscounts.Rows.Add(
                        thumb,
                        discount.ID,
                        discount.DiscountName,
                        discount.ProductName,
                        discount.GetFormattedPercent(),
                        discount.StartDate.ToString("dd/MM/yyyy"),
                        discount.EndDate.ToString("dd/MM/yyyy"),
                        discount.GetStatusText()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading discounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDiscount()
        {
            AddEditDiscountForm form = new AddEditDiscountForm(_allProducts);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void EditSelectedDiscount()
        {
            if (_dgvDiscounts.SelectedRows.Count > 0)
            {
                int discountId = (int)_dgvDiscounts.SelectedRows[0].Cells["ID"].Value;
                var discount = _allDiscounts.FirstOrDefault(d => d.ID == discountId);
                if (discount != null)
                {
                    AddEditDiscountForm form = new AddEditDiscountForm(_allProducts, discount);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a discount to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteSelectedDiscount()
        {
            if (_dgvDiscounts.SelectedRows.Count > 0)
            {
                int discountId = (int)_dgvDiscounts.SelectedRows[0].Cells["ID"].Value;
                var discount = _allDiscounts.FirstOrDefault(d => d.ID == discountId);
                if (MessageBox.Show("Are you sure you want to delete this discount?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (DiscountRepository.DeleteDiscount(discountId))
                        {
                            if (discount != null)
                            {
                                DiscountRepository.SyncActiveDiscountForProduct(discount.ProductID);
                            }
                            MessageBox.Show("Discount deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting discount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a discount to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
