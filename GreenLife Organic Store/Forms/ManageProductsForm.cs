using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ManageProductsForm : Form
    {
        private List<Product> _allProducts = new();
        private DataGridView _dgvProducts;

        public ManageProductsForm()
        {
            this.Text = "Manage Products";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Load += ManageProductsForm_Load;
        }

        private void ManageProductsForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadProducts();
        }

        private void InitializeUI()
        {
            // Toolbar
            Panel pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.LightGray
            };

            IconButton btnAdd = new IconButton
            {
                Text = "Add New Product",
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
            btnAdd.Click += (s, e) => AddProduct();
            pnlToolbar.Controls.Add(btnAdd);

            TextBox txtSearch = new TextBox
            {
                Name = "txtSearch",
                Location = new Point(170, 10),
                Size = new Size(200, 30),
                Text = "Search..."
            };
            pnlToolbar.Controls.Add(txtSearch);

            IconButton btnSearch = new IconButton
            {
                Text = "Search",
                Location = new Point(380, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Search,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnSearch.Click += (s, e) => SearchProducts(txtSearch.Text);
            pnlToolbar.Controls.Add(btnSearch);

            IconButton btnRefresh = new IconButton
            {
                Text = "Refresh",
                Location = new Point(490, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Sync,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnRefresh.Click += (s, e) => LoadProducts();
            pnlToolbar.Controls.Add(btnRefresh);

            this.Controls.Add(pnlToolbar);

            // DataGridView
            _dgvProducts = new DataGridView
            {
                Name = "dgvProducts",
                Dock = DockStyle.Top,
                Height = 400,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            // Add image thumbnail column
            var imgCol = new DataGridViewImageColumn { Name = "Image", HeaderText = "Image", ImageLayout = DataGridViewImageCellLayout.Zoom, Width = 60 };
            _dgvProducts.Columns.Add(imgCol);
            _dgvProducts.Columns.Add("ID", "ID");
            _dgvProducts.Columns.Add("ProductName", "Product Name");
            _dgvProducts.Columns.Add("Category", "Category");
            _dgvProducts.Columns.Add("Price", "Price");
            _dgvProducts.Columns.Add("Stock", "Stock");
            _dgvProducts.Columns.Add("Status", "Status");
            _dgvProducts.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditSelectedProduct(); };
            this.Controls.Add(_dgvProducts);

            // Action Buttons
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            IconButton btnEdit = new IconButton
            {
                Text = "Edit Product",
                Location = new Point(10, 10),
                Size = new Size(130, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Edit,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnEdit.Click += (s, e) => EditSelectedProduct();
            pnlActions.Controls.Add(btnEdit);

            IconButton btnDelete = new IconButton
            {
                Text = "Delete Product",
                Location = new Point(150, 10),
                Size = new Size(130, 30),
                BackColor = Color.LightCoral,
                Cursor = Cursors.Hand,
                IconChar = IconChar.TrashAlt,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnDelete.Click += (s, e) => DeleteSelectedProduct();
            pnlActions.Controls.Add(btnDelete);

            IconButton btnClose = new IconButton
            {
                Text = "Close",
                Location = new Point(290, 10),
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