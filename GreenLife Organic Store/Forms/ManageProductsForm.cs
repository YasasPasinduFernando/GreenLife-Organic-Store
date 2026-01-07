using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ManageProductsForm : Form
    {
        private List<Product> _allProducts = new();

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

            Button btnAdd = new Button
            {
                Text = "Add New Product",
                Location = new Point(10, 10),
                Size = new Size(150, 30),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
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

            Button btnSearch = new Button
            {
                Text = "Search",
                Location = new Point(380, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnSearch.Click += (s, e) => SearchProducts(txtSearch.Text);
            pnlToolbar.Controls.Add(btnSearch);

            Button btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(490, 10),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnRefresh.Click += (s, e) => LoadProducts();
            pnlToolbar.Controls.Add(btnRefresh);

            this.Controls.Add(pnlToolbar);

            // DataGridView
            DataGridView dgvProducts = new DataGridView
            {
                Name = "dgvProducts",
                Dock = DockStyle.Top,
                Height = 350,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White
            };
            dgvProducts.Columns.Add("ID", "ID");
            dgvProducts.Columns.Add("ProductName", "Product Name");
            dgvProducts.Columns.Add("Category", "Category");
            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns.Add("Stock", "Stock");
            dgvProducts.Columns.Add("Status", "Status");
            this.Controls.Add(dgvProducts);

            // Action Buttons
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            Button btnEdit = new Button
            {
                Text = "Edit Product",
                Location = new Point(10, 10),
                Size = new Size(150, 35),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnEdit.Click += (s, e) => EditSelectedProduct();
            pnlActions.Controls.Add(btnEdit);

            Button btnDelete = new Button
            {
                Text = "Delete Product",
                Location = new Point(170, 10),
                Size = new Size(150, 35),
                BackColor = Color.LightCoral,
                Cursor = Cursors.Hand
            };
            btnDelete.Click += (s, e) => DeleteSelectedProduct();
            pnlActions.Controls.Add(btnDelete);

            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(330, 10),
                Size = new Size(150, 35),
                BackColor = Color.LightGray,
                Cursor = Cursors.Hand
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
                DataGridView dgvProducts = (DataGridView)this.Controls[1];
                dgvProducts.Rows.Clear();

                foreach (var product in _allProducts)
                {
                    dgvProducts.Rows.Add(
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
            DataGridView dgvProducts = (DataGridView)this.Controls[1];
            dgvProducts.Rows.Clear();

            foreach (var product in results)
            {
                dgvProducts.Rows.Add(
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
            DataGridView dgvProducts = (DataGridView)this.Controls[1];
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)dgvProducts.SelectedRows[0].Cells["ID"].Value;
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
            DataGridView dgvProducts = (DataGridView)this.Controls[1];
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = (int)dgvProducts.SelectedRows[0].Cells["ID"].Value;
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
