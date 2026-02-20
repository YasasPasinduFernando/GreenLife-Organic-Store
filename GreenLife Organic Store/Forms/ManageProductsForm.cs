using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ManageProductsForm : Form
    {
        private List<Product> _allProducts = new();

        public ManageProductsForm()
        {
            InitializeComponent();
            this.Text = "Manage Products";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            if (!DesignMode)
                this.Load += ManageProductsForm_Load;
        }

        private void ManageProductsForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadProducts();
        }

        private void TxtSearch_Enter(object? sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...") txtSearch.Text = "";
        }
        private void TxtSearch_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) txtSearch.Text = "Search...";
        }
        private void BtnAdd_Click(object? sender, EventArgs e) => AddProduct();
        private void BtnSearch_Click(object? sender, EventArgs e) => SearchProducts(txtSearch.Text);
        private void BtnRefresh_Click(object? sender, EventArgs e) => LoadProducts();
        private void BtnEdit_Click(object? sender, EventArgs e) => EditSelectedProduct();
        private void BtnDelete_Click(object? sender, EventArgs e) => DeleteSelectedProduct();
        private void BtnClose_Click(object? sender, EventArgs e) => Close();
        private void DgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditSelectedProduct();
        }

        private void LoadProducts()
        {
            try
            {
                _allProducts = ProductRepository.GetAllProducts();
                _dgvProducts.Rows.Clear();

                foreach (var product in _allProducts)
                {
                    Image? thumb = null;
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(product.ImagePath))
                        {
                            // Use ImageStore to get the full path
                            var fullPath = ImageStore.GetFullPath(product.ImagePath);
                            if (File.Exists(fullPath))
                            {
                                using var img = Image.FromFile(fullPath);
                                thumb = new Bitmap(img, new Size(60, 60));
                            }
                        }
                    }
                    catch { }

                    _dgvProducts.Rows.Add(
                        thumb,
                        product.ID,
                        product.ProductName,
                        product.CategoryName,
                        product.GetFormattedPrice(),
                        product.HasDiscount() ? $"{product.GetDiscountPercent()}%" : "No",
                        product.Stock,
                        product.GetStockStatus()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchProducts(string searchTerm)
        {
            var results = ProductRepository.SearchProducts(searchTerm);
            _dgvProducts.Rows.Clear();

            foreach (var product in results)
            {
                Image? thumb = null;
                try
                {
                    if (!string.IsNullOrWhiteSpace(product.ImagePath))
                    {
                        // Use ImageStore to get the full path
                        var fullPath = ImageStore.GetFullPath(product.ImagePath);
                        if (File.Exists(fullPath))
                        {
                            using var img = Image.FromFile(fullPath);
                            thumb = new Bitmap(img, new Size(60, 60));
                        }
                    }
                }
                catch { }

                _dgvProducts.Rows.Add(
                    thumb,
                    product.ID,
                    product.ProductName,
                    product.CategoryName,
                    product.GetFormattedPrice(),
                    product.HasDiscount() ? $"{product.GetDiscountPercent()}%" : "No",
                    product.Stock,
                    product.GetStockStatus()
                );
            }
        }

        private void AddProduct()
        {
            AddEditProductForm form = new AddEditProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void EditSelectedProduct()
        {
            if (_dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)_dgvProducts.SelectedRows[0].Cells["ID"].Value;
                var product = _allProducts.FirstOrDefault(p => p.ID == productId);
                if (product != null)
                {
                    AddEditProductForm form = new AddEditProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteSelectedProduct()
        {
            if (_dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)_dgvProducts.SelectedRows[0].Cells["ID"].Value;
                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (ProductRepository.DeleteProduct(productId))
                        {
                            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProducts();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}