using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class CustomerDashboard : Form
    {
        private User _currentCustomer;
        private List<Product> _allProducts = new();
        private List<Category> _categories = new();
        private FlowLayoutPanel _flpProducts = null!;
        private Label _lblCartCount = null!;

        public CustomerDashboard(User customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "?? GreenLife Organic Store - Shopping";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);

            InitializeUI();
            LoadData();
            // If logged in user, load DB cart into in-memory cart so shopping cart UI reflects DB
            try
            {
                if (_currentCustomer != null && _currentCustomer.ID > 0)
                {
                    var dbItems = GreenLife_Organic_Store.Database.CartRepository.GetCartItems(_currentCustomer.ID);
                    foreach (var kv in dbItems)
                    {
                        var product = ProductRepository.GetProductById(kv.Key);
                        if (product != null)
                        {
                            // ensure in-memory quantity matches DB
                            int existing = ShoppingCart.GetProductQuantity(product.ID);
                            int toAdd = kv.Value - existing;
                            if (toAdd > 0)
                                ShoppingCart.AddItem(product, toAdd);
                        }
                    }
                }
            }
            catch
            {
                // non-fatal
            }
            UpdateCartCount();
        }

        private void InitializeUI()
        {
            // Header Panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(34, 139, 34)
            };

            Label lblTitle = new Label
            {
                Text = "?? GreenLife Organic Store",
                Location = new Point(10, 15),
                Size = new Size(400, 30),
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White
            };
            pnlHeader.Controls.Add(lblTitle);

            _lblCartCount = new Label
            {
                Text = "?? Cart: 0",
                Location = new Point(600, 15),
                Size = new Size(150, 30),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            _lblCartCount.Click += (s, e) => ShowCart();
            pnlHeader.Controls.Add(_lblCartCount);

            Button btnProfile = new Button
            {
                Text = "?? Profile",
                Location = new Point(780, 15),
                Size = new Size(100, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnProfile.Click += (s, e) => ShowProfile();
            pnlHeader.Controls.Add(btnProfile);

            Button btnLogout = new Button
            {
                Text = "Logout",
                Location = new Point(890, 15),
                Size = new Size(100, 30),
                BackColor = Color.LightCoral,
                Cursor = Cursors.Hand
            };
            btnLogout.Click += (s, e) => Logout();
            pnlHeader.Controls.Add(btnLogout);

            this.Controls.Add(pnlHeader);

            // Filter Panel
            Panel pnlFilter = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblSearch = new Label { Text = "Search:", Location = new Point(10, 10), Size = new Size(60, 20) };
            TextBox txtSearch = new TextBox { Name = "txtSearch", Location = new Point(80, 10), Size = new Size(200, 25) };
            Button btnSearch = new Button { Text = "??", Location = new Point(290, 10), Size = new Size(50, 25), BackColor = Color.LightGreen };
            btnSearch.Click += (s, e) => SearchProducts(txtSearch.Text);
            pnlFilter.Controls.Add(lblSearch);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(btnSearch);

            Label lblCategory = new Label { Text = "Category:", Location = new Point(360, 10), Size = new Size(70, 20) };
            ComboBox cmbCategory = new ComboBox
            {
                Name = "cmbCategory",
                Location = new Point(440, 10),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.Items.Add("All Products");
            cmbCategory.SelectedIndex = 0;
            cmbCategory.SelectedIndexChanged += (s, e) => FilterByCategory(cmbCategory);
            pnlFilter.Controls.Add(lblCategory);
            pnlFilter.Controls.Add(cmbCategory);

            Label lblPrice = new Label { Text = "Price Range:", Location = new Point(620, 10), Size = new Size(80, 20) };
            NumericUpDown numMinPrice = new NumericUpDown
            {
                Name = "numMinPrice",
                Location = new Point(710, 10),
                Size = new Size(80, 25),
                Minimum = 0,
                Maximum = 10000
            };
            Label lblPriceTo = new Label { Text = "to", Location = new Point(800, 10), Size = new Size(20, 20) };
            NumericUpDown numMaxPrice = new NumericUpDown
            {
                Name = "numMaxPrice",
                Location = new Point(830, 10),
                Size = new Size(80, 25),
                Minimum = 0,
                Maximum = 10000,
                Value = 10000
            };
            pnlFilter.Controls.Add(lblPrice);
            pnlFilter.Controls.Add(numMinPrice);
            pnlFilter.Controls.Add(lblPriceTo);
            pnlFilter.Controls.Add(numMaxPrice);

            Button btnFilter = new Button { Text = "Filter", Location = new Point(920, 10), Size = new Size(70, 25), BackColor = Color.LightBlue };
            btnFilter.Click += (s, e) => FilterByPrice((decimal)numMinPrice.Value, (decimal)numMaxPrice.Value);
            pnlFilter.Controls.Add(btnFilter);

            this.Controls.Add(pnlFilter);

            // Products Flow Panel
            _flpProducts = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };
            this.Controls.Add(_flpProducts);
        }

        private void LoadData()
        {
            try
            {
                _categories = CategoryRepository.GetAllCategories();
                _allProducts = ProductRepository.GetAllProducts();

                ComboBox cmbCategory = (ComboBox)this.Controls[1].Controls["cmbCategory"];
                foreach (var category in _categories)
                {
                    cmbCategory.Items.Add(category.CategoryName);
                }

                DisplayProducts(_allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayProducts(List<Product> products)
        {
            _flpProducts.Controls.Clear();

            foreach (var product in products)
            {
                Panel pnlProduct = CreateProductCard(product);
                _flpProducts.Controls.Add(pnlProduct);
            }
        }

        private Panel CreateProductCard(Product product)
        {
            Panel pnlCard = new Panel
            {
                Size = new Size(200, 280),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(5)
            };

            // Product image placeholder
            Panel pnlImage = new Panel
            {
                Size = new Size(200, 120),
                BackColor = Color.LightGray,
                Dock = DockStyle.Top
            };
            Label lblImage = new Label { Text = "??", Location = new Point(80, 45), Size = new Size(40, 40), Font = new Font("Arial", 24) };
            pnlImage.Controls.Add(lblImage);
            pnlCard.Controls.Add(pnlImage);

            // Product name
            Label lblName = new Label
            {
                Text = product.ProductName,
                Location = new Point(5, 125),
                Size = new Size(190, 40),
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = false
            };
            pnlCard.Controls.Add(lblName);

            // Stock status
            Label lblStock = new Label
            {
                Text = product.GetStockStatus(),
                Location = new Point(5, 165),
                Size = new Size(190, 20),
                Font = new Font("Arial", 9),
                ForeColor = product.IsInStock() ? Color.Green : Color.Red
            };
            pnlCard.Controls.Add(lblStock);

            // Price
            Label lblPrice = new Label
            {
                Text = product.GetFormattedPrice(),
                Location = new Point(5, 185),
                Size = new Size(190, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            pnlCard.Controls.Add(lblPrice);

            // Add to cart button
            Button btnAdd = new Button
            {
                Text = "Add to Cart",
                Location = new Point(5, 215),
                Size = new Size(190, 35),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Enabled = product.IsInStock(),
                Cursor = Cursors.Hand
            };
            btnAdd.Click += (s, e) => AddToCart(product);
            pnlCard.Controls.Add(btnAdd);

            return pnlCard;
        }

        private void AddToCart(Product product)
        {
            ShoppingCart.AddItem(product, 1);
            // Persist to DB if user is logged in
            if (_currentCustomer != null && _currentCustomer.ID > 0)
                    {
                        try
                        {
                            GreenLife_Organic_Store.Database.CartRepository.AddOrUpdateCartItem(_currentCustomer.ID, product.ID, 1);
                        }
                        catch (Exception ex)
                        {
                            // Log or show non-blocking error
                            MessageBox.Show($"Warning: failed saving cart to database: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
            UpdateCartCount();
            MessageBox.Show($"{product.ProductName} added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateCartCount()
        {
            if (_currentCustomer != null && _currentCustomer.ID > 0)
            {
                try
                {
                    int dbCount = GreenLife_Organic_Store.Database.CartRepository.GetCartItemCount(_currentCustomer.ID);
                    _lblCartCount.Text = $"?? Cart: {dbCount}";
                    return;
                }
                catch
                {
                    // fallback to in-memory count on error
                }
            }

            _lblCartCount.Text = $"?? Cart: {ShoppingCart.GetItemCount()}";
        }

        private void ShowCart()
        {
            ShoppingCartForm cartForm = new ShoppingCartForm();
            cartForm.ShowDialog();
            UpdateCartCount();
        }

        private void SearchProducts(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                DisplayProducts(_allProducts);
            }
            else
            {
                var results = ProductRepository.SearchProducts(searchTerm);
                DisplayProducts(results);
            }
        }

        private void FilterByCategory(ComboBox cmbCategory)
        {
            if (cmbCategory.SelectedIndex == 0)
            {
                DisplayProducts(_allProducts);
            }
            else
            {
                var category = _categories.FirstOrDefault(c => c.CategoryName == cmbCategory.SelectedItem.ToString());
                if (category != null)
                {
                    var filtered = _allProducts.Where(p => p.CategoryID == category.ID).ToList();
                    DisplayProducts(filtered);
                }
            }
        }

        private void FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            var filtered = _allProducts.Where(p => p.GetFinalPrice() >= minPrice && p.GetFinalPrice() <= maxPrice).ToList();
            DisplayProducts(filtered);
        }

        private void ShowProfile()
        {
            var menuForm = new Form { Text = "Profile Menu", Size = new Size(250, 200), StartPosition = FormStartPosition.CenterParent };
            var btnEdit = new Button { Text = "Edit Profile", Location = new Point(20, 30), Size = new Size(200, 40), BackColor = Color.LightGreen };
            btnEdit.Click += (s, e) =>
            {
                CustomerProfileEditForm editForm = new CustomerProfileEditForm(_currentCustomer);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _currentCustomer = editForm.UpdatedUser;
                }
                menuForm.Close();
            };
            var btnOrders = new Button { Text = "My Orders", Location = new Point(20, 80), Size = new Size(200, 40), BackColor = Color.LightBlue };
            btnOrders.Click += (s, e) =>
            {
                MyOrdersForm ordersForm = new MyOrdersForm(_currentCustomer);
                ordersForm.ShowDialog();
                menuForm.Close();
            };
            var btnPassword = new Button { Text = "Change Password", Location = new Point(20, 130), Size = new Size(200, 40), BackColor = Color.LightYellow };
            btnPassword.Click += (s, e) =>
            {
                ChangePasswordForm changePassForm = new ChangePasswordForm(_currentCustomer.ID);
                changePassForm.ShowDialog();
                menuForm.Close();
            };

            menuForm.Controls.Add(btnEdit);
            menuForm.Controls.Add(btnOrders);
            menuForm.Controls.Add(btnPassword);
            menuForm.ShowDialog();
        }

        private void Logout()
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ShoppingCart.Clear();
                this.Close();
            }
        }
    }
}
