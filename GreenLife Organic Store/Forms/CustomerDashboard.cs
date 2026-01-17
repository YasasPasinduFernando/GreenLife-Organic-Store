using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
// No Timer alias - animations use async Task.Delay to avoid Timer ambiguity

namespace GreenLife_Organic_Store.Forms
{
    public partial class CustomerDashboard : Form
    {
        private User _currentCustomer;
        private List<Product> _allProducts = new();
        private List<Category> _categories = new();
        private FlowLayoutPanel _flpProducts = null!;
        private FlowLayoutPanel _flpCategories = null!;
        private Label _lblCartCount = null!;
        private Panel _pnlFilter = null!;
        private Panel _pnlCategoriesSection = null!;
        private bool _isFilterPinned = true;
        private bool _isCategoriesPinned = true;

        public CustomerDashboard(User customer)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            _currentCustomer = customer;
        }

        private T? FindControlRecursive<T>(Control parent, string name) where T : Control
        {
            if (parent == null) return null;
            foreach (Control child in parent.Controls)
            {
                if (child is T t && child.Name == name)
                    return t;
                var found = FindControlRecursive<T>(child, name);
                if (found != null) return found;
            }
            return null;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "GreenLife Organic Store - Shopping";
            // Fixed size window centered on screen
            this.Size = new Size(1280, 860);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable; // allow resize up to full screen
            this.MaximizeBox = true; // allow maximize
            this.MinimizeBox = true;
            // Prevent user from resizing by locking min/max to the same size
            this.MinimumSize = this.Size;
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
            // Products Flow Panel - ADD FIRST (will be at bottom with DockStyle.Fill)
            _flpProducts = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(15)
            };
            _flpProducts.FlowDirection = FlowDirection.LeftToRight;
            _flpProducts.WrapContents = true;
            this.Controls.Add(_flpProducts);

            // Products Section Header
            Panel pnlProductsHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(240, 240, 240),
                Padding = new Padding(20, 0, 20, 0)
            };

            Label lblProductsTitle = new Label
            {
                Text = "Our Products",
                Location = new Point(20, 8),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlProductsHeader.Controls.Add(lblProductsTitle);
            this.Controls.Add(pnlProductsHeader);

            // Categories Section with Pin Button
            _pnlCategoriesSection = new Panel
            {
                Name = "pnlCategoriesSection",
                Dock = DockStyle.Top,
                Height = 160,
                BackColor = Color.White
            };

            // Categories horizontal panel (add first so it appears at bottom of categories section)
            _flpCategories = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Height = 120,
                AutoSize = false,
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };
            _flpCategories.FlowDirection = FlowDirection.LeftToRight;
            // keep categories in a single horizontal row and allow horizontal scrolling
            _flpCategories.WrapContents = false;
            _pnlCategoriesSection.Controls.Add(_flpCategories);

            Panel pnlCategoriesHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.White,
                Padding = new Padding(20, 0, 20, 0)
            };

            // Pin button for categories - same style as search
            IconButton btnPinCategories = new IconButton
            {
                Name = "btnPinCategories",
                Text = "",
                Location = new Point(15, 5),
                Size = new Size(35, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                IconChar = IconChar.AngleDown,
                IconColor = Color.White,
                IconSize = 20,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPinCategories.FlatAppearance.BorderSize = 0;
            btnPinCategories.Click += (s, e) => ToggleCategoriesPin();
            pnlCategoriesHeader.Controls.Add(btnPinCategories);

            Label lblCategoriesTitle = new Label
            {
                Text = "Shop by Category",
                Location = new Point(60, 8),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlCategoriesHeader.Controls.Add(lblCategoriesTitle);
            _pnlCategoriesSection.Controls.Add(pnlCategoriesHeader);

            this.Controls.Add(_pnlCategoriesSection);

            // Filter Panel with Pin Button
            _pnlFilter = new Panel
            {
                Name = "pnlFilter",
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            // Pin button for filter
            IconButton btnPinFilter = new IconButton
            {
                Name = "btnPinFilter",
                Text = "",
                Location = new Point(15, 15),
                Size = new Size(35, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                IconChar = IconChar.AngleDown,
                IconColor = Color.White,
                IconSize = 20,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPinFilter.FlatAppearance.BorderSize = 0;
            btnPinFilter.Click += (s, e) => ToggleFilterPin();
            _pnlFilter.Controls.Add(btnPinFilter);

            Label lblSearch = new Label 
            { 
                Text = "Search:", 
                Location = new Point(60, 18), 
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            _pnlFilter.Controls.Add(lblSearch);

            TextBox txtSearch = new TextBox 
            { 
                Name = "txtSearch", 
                Location = new Point(145, 15), 
                Size = new Size(250, 30),
                Font = new Font("Segoe UI", 11F)
            };
            _pnlFilter.Controls.Add(txtSearch);

            IconButton btnSearch = new IconButton
            {
                Text = "Search",
                Location = new Point(405, 13),
                Size = new Size(110, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                IconChar = IconChar.Search,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += (s, e) => SearchProducts(txtSearch.Text);
            _pnlFilter.Controls.Add(btnSearch);

            Label lblCategory = new Label 
            { 
                Text = "Category:", 
                Location = new Point(530, 18), 
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            _pnlFilter.Controls.Add(lblCategory);

            ComboBox cmbCategory = new ComboBox
            {
                Name = "cmbCategory",
                Location = new Point(615, 15),
                Size = new Size(180, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            cmbCategory.Items.Add("All Products");
            cmbCategory.SelectedIndex = 0;
            cmbCategory.SelectedIndexChanged += (s, e) => FilterByCategory(cmbCategory);
            _pnlFilter.Controls.Add(cmbCategory);

            Label lblPrice = new Label 
            { 
                Text = "Price:", 
                Location = new Point(810, 18), 
                Size = new Size(50, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            _pnlFilter.Controls.Add(lblPrice);

            NumericUpDown numMinPrice = new NumericUpDown
            {
                Name = "numMinPrice",
                Location = new Point(865, 15),
                Size = new Size(90, 30),
                Minimum = 0,
                Maximum = 10000,
                Font = new Font("Segoe UI", 10F)
            };
            _pnlFilter.Controls.Add(numMinPrice);

            Label lblPriceTo = new Label { Text = "-", Location = new Point(960, 18), Size = new Size(20, 25), Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            _pnlFilter.Controls.Add(lblPriceTo);

            NumericUpDown numMaxPrice = new NumericUpDown
            {
                Name = "numMaxPrice",
                Location = new Point(985, 15),
                Size = new Size(90, 30),
                Minimum = 0,
                Maximum = 10000,
                Value = 10000,
                Font = new Font("Segoe UI", 10F)
            };
            _pnlFilter.Controls.Add(numMaxPrice);

            IconButton btnFilter = new IconButton
            {
                Text = "Filter",
                Location = new Point(1085, 13),
                Size = new Size(95, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                IconChar = IconChar.Filter,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Click += (s, e) => FilterByPrice((decimal)numMinPrice.Value, (decimal)numMaxPrice.Value);
            _pnlFilter.Controls.Add(btnFilter);

            this.Controls.Add(_pnlFilter);

            // Header Panel - ADD LAST SO IT APPEARS AT TOP
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(34, 139, 34)
            };

            // Logo
            IconPictureBox iconLogo = new IconPictureBox
            {
                IconChar = IconChar.Leaf,
                IconColor = Color.White,
                IconSize = 50,
                Location = new Point(20, 15),
                Size = new Size(50, 50),
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(iconLogo);

            Label lblTitle = new Label
            {
                Text = "GreenLife Organic Store",
                Location = new Point(80, 18),
                Size = new Size(400, 35),
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(lblTitle);

            Label lblWelcome = new Label
            {
                Text = $"Welcome, {_currentCustomer.Name}!",
                Location = new Point(80, 52),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(220, 255, 220),
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(lblWelcome);

            // Cart Section
            // Right-side panel for cart and profile (keeps them anchored to the right)
            Panel pnlHeaderRight = new Panel
            {
                Dock = DockStyle.Right,
                Width = 300,
                BackColor = Color.Transparent
            };

            IconButton btnCart = new IconButton()
            {
                Text = "",
                Location = new Point(10, 15),
                Size = new Size(44, 44),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                IconChar = IconChar.ShoppingCart,
                IconColor = Color.White,
                IconSize = 22,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.Click += (s, e) => ShowCart();
            pnlHeaderRight.Controls.Add(btnCart);

            // Cart info panel (stacked count above the label) to avoid overlap
            Panel pnlCartInfo = new Panel
            {
                Location = new Point(64, 12),
                Size = new Size(60, 44),
                BackColor = Color.Transparent
            };

            _lblCartCount = new Label
            {
                Text = "0",
                Dock = DockStyle.Top,
                Height = 26,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent
            };
            _lblCartCount.Click += (s, e) => ShowCart();
            pnlCartInfo.Controls.Add(_lblCartCount);

            Label lblCartText = new Label
            {
                Text = "Items",
                Dock = DockStyle.Bottom,
                Height = 18,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(220, 255, 220),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent
            };
            lblCartText.Click += (s, e) => ShowCart();
            pnlCartInfo.Controls.Add(lblCartText);

            pnlHeaderRight.Controls.Add(pnlCartInfo);

            IconButton btnProfile = new IconButton();
            btnProfile.Text = "Profile";
            btnProfile.Location = new Point(160, 12);
            btnProfile.Size = new Size(120, 44);
            btnProfile.BackColor = Color.FromArgb(52, 152, 219);
            btnProfile.ForeColor = Color.White;
            btnProfile.IconChar = IconChar.UserCircle;
            btnProfile.IconColor = Color.White;
            btnProfile.IconSize = 20;
            btnProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.Click += (s, e) => ShowProfile();
            pnlHeaderRight.Controls.Add(btnProfile);

            pnlHeader.Controls.Add(pnlHeaderRight);

            // ADD HEADER LAST - IT WILL APPEAR AT TOP
            this.Controls.Add(pnlHeader);
        }

        private async void ToggleFilterPin()
        {
            _isFilterPinned = !_isFilterPinned;
            // Animate collapse/expand using Task.Delay
            int targetHeight = _isFilterPinned ? 80 : 45; // Collapsed shows just pin button
            int step = _isFilterPinned ? 5 : -5;
            while ((_isFilterPinned && _pnlFilter.Height < targetHeight) || (!_isFilterPinned && _pnlFilter.Height > targetHeight))
            {
                _pnlFilter.Height = Math.Max(45, Math.Min(80, _pnlFilter.Height + step));
                await Task.Delay(10);
            }
            _pnlFilter.Height = targetHeight;
            
            // Hide/show controls except pin button
            foreach (Control ctrl in _pnlFilter.Controls)
            {
                if (ctrl.Name != "btnPinFilter")
                {
                    ctrl.Visible = _isFilterPinned;
                }
            }
            
            // Update pin button - AngleDown when expanded (can collapse), AngleUp when collapsed (can expand)
            var btnPin = _pnlFilter.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "btnPinFilter") as IconButton;
            if (btnPin != null)
            {
                btnPin.IconChar = _isFilterPinned ? IconChar.AngleDown : IconChar.AngleUp;
                btnPin.BackColor = _isFilterPinned ? Color.FromArgb(52, 152, 219) : Color.FromArgb(149, 165, 166);
            }
        }

        private async void ToggleCategoriesPin()
        {
            _isCategoriesPinned = !_isCategoriesPinned;
            // Animate collapse/expand using Task.Delay
            int targetHeight = _isCategoriesPinned ? 160 : 45; // Collapsed shows just header
            int step = _isCategoriesPinned ? 10 : -10;
            while ((_isCategoriesPinned && _pnlCategoriesSection.Height < targetHeight) || (!_isCategoriesPinned && _pnlCategoriesSection.Height > targetHeight))
            {
                _pnlCategoriesSection.Height = Math.Max(45, Math.Min(160, _pnlCategoriesSection.Height + step));
                await Task.Delay(10);
            }
            _pnlCategoriesSection.Height = targetHeight;
            
            // Hide/show categories flow panel
            if (_flpCategories != null)
            {
                _flpCategories.Visible = _isCategoriesPinned;
            }
            
            // Update pin button - find it by recursively searching all controls
            IconButton? btnPin = null;
            foreach (Control ctrl in _pnlCategoriesSection.Controls)
            {
                if (ctrl is Panel panel)
                {
                    foreach (Control innerCtrl in panel.Controls)
                    {
                        if (innerCtrl.Name == "btnPinCategories" && innerCtrl is IconButton btn)
                        {
                            btnPin = btn;
                            break;
                        }
                    }
                }
                if (btnPin != null) break;
            }
            
            if (btnPin != null)
            {
                btnPin.IconChar = _isCategoriesPinned ? IconChar.AngleDown : IconChar.AngleUp;
                btnPin.BackColor = _isCategoriesPinned ? Color.FromArgb(52, 152, 219) : Color.FromArgb(149, 165, 166);
            }
        }

        private void LoadData()
        {
            try
            {
                _categories = CategoryRepository.GetAllCategories();
                _allProducts = ProductRepository.GetAllProducts();

                // Locate the category combobox anywhere in the form (recursively) and populate it
                ComboBox? cmbCategory = FindControlRecursive<ComboBox>(this, "cmbCategory");

                if (cmbCategory != null)
                {
                    // keep the initial "All Products" entry, remove any other previous entries
                    for (int i = cmbCategory.Items.Count - 1; i >= 0; i--)
                    {
                        var item = cmbCategory.Items[i];
                        if (item == null) continue;
                        if (item.ToString() != "All Products")
                            cmbCategory.Items.RemoveAt(i);
                    }

                    foreach (var category in _categories)
                    {
                        cmbCategory.Items.Add(category.CategoryName);
                    }
                }

                DisplayCategories(_categories);
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

        private void DisplayCategories(List<Category> categories)
        {
            if (_flpCategories == null) return;
            _flpCategories.Controls.Clear();

            // Add "All" card
            var allCard = CreateCategoryCard(null, "All Products");
            _flpCategories.Controls.Add(allCard);

            foreach (var cat in categories)
            {
                var card = CreateCategoryCard(cat, cat.CategoryName);
                _flpCategories.Controls.Add(card);
            }
        }

        private Control CreateCategoryCard(Category? category, string title)
        {
            Panel pnl = new Panel
            {
                Size = new Size(160, 95),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            // Shadow panel
            Panel shadowPanel = new Panel
            {
                Size = new Size(160, 95),
                BackColor = Color.FromArgb(200, 200, 200),
                Location = new Point(3, 3)
            };

            // Image area (either product/category image or a default icon)
            PictureBox pic = new PictureBox
            {
                Size = new Size(70, 70),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(240, 240, 240),
                Cursor = Cursors.Hand
            };

            Control? imageControl = null;

            if (category != null && !string.IsNullOrWhiteSpace(category.ImagePath))
            {
                try 
                { 
                    var fullPath = ImageStore.GetFullPath(category.ImagePath);
                    if (File.Exists(fullPath)) 
                        pic.ImageLocation = fullPath; 
                } 
                catch { }
                imageControl = pic;
            }
            else
            {
                // Default icon
                IconPictureBox defaultIcon = new IconPictureBox
                {
                    IconChar = IconChar.Tag,
                    IconColor = Color.FromArgb(52, 152, 219),
                    IconSize = 40,
                    Size = new Size(70, 70),
                    Location = new Point(10, 10),
                    BackColor = Color.FromArgb(240, 240, 240),
                    Cursor = Cursors.Hand
                };
                imageControl = defaultIcon;
            }

            if (imageControl != null)
            {
                pnl.Controls.Add(imageControl);
            }

            Label lbl = new Label
            {
                Text = title,
                Location = new Point(88, 25),
                Size = new Size(65, 50),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            if (category != null)
                pnl.Controls.Add(pic);
            pnl.Controls.Add(lbl);

            EventHandler clickHandler = (s, e) =>
            {
                if (category == null)
                    DisplayProducts(_allProducts);
                else
                {
                    var filtered = _allProducts.Where(p => p.CategoryID == category.ID).ToList();
                    DisplayProducts(filtered);
                }
            };

            // Make panel, image and label clickable
            pnl.Click += clickHandler;
            if (imageControl != null)
                imageControl.Click += clickHandler;
            lbl.Click += clickHandler;

            // Visual cue for clickability
            lbl.Cursor = Cursors.Hand;

            // Hover effect
            pnl.MouseEnter += (s, e) => pnl.BackColor = Color.FromArgb(240, 255, 240);
            pnl.MouseLeave += (s, e) => pnl.BackColor = Color.White;

            return pnl;
        }

        private Panel CreateProductCard(Product product)
        {
            Panel pnlCard = new Panel();
            // Reduced width/height so more product cards fit per row
            pnlCard.Size = new Size(160, 250);
            pnlCard.BorderStyle = BorderStyle.None;
            pnlCard.BackColor = Color.White;
            pnlCard.Margin = new Padding(6);

            // Shadow effect
            Panel shadowPanel = new Panel();
            shadowPanel.Size = new Size(160, 250);
            shadowPanel.BackColor = Color.FromArgb(220, 220, 220);
            shadowPanel.Location = new Point(3, 3);

            // Product image
            Panel pnlImage = new Panel();
            pnlImage.Size = new Size(160, 100);
            pnlImage.BackColor = Color.FromArgb(250, 250, 250);
            pnlImage.Dock = DockStyle.Top;
            
            var pic = new PictureBox();
            pic.Size = new Size(160, 100);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Dock = DockStyle.Fill;
            pic.BackColor = Color.FromArgb(250, 250, 250);
            
            if (!string.IsNullOrWhiteSpace(product.ImagePath))
            {
                try
                {
                    var fullPath = ImageStore.GetFullPath(product.ImagePath);
                    if (File.Exists(fullPath))
                        pic.ImageLocation = fullPath;
                }
                catch { }
            }
            pnlImage.Controls.Add(pic);
            pnlCard.Controls.Add(pnlImage);

            // Product name
            Label lblName = new Label
            {
                Text = product.ProductName,
                Location = new Point(8, 120),
                Size = new Size(144, 36),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = false,
                BackColor = Color.Transparent
            };
            pnlCard.Controls.Add(lblName);

            // Stock status
            Label lblStock = new Label();
            // Trim any leading ellipsis/dots that may come from source
            var stockText = product.GetStockStatus() ?? string.Empty;
            stockText = stockText.TrimStart('.', ' ', '\u2026');

            // Reserve space for an optional status icon (exclamation or X)
            int stockY = lblName.Bottom + 4;
            IconPictureBox stockIcon = new IconPictureBox
            {
                Size = new Size(16, 16),
                Location = new Point(8, stockY + 2),
                BackColor = Color.Transparent,
                IconSize = 16,
                Visible = false
            };

            // Default label placement; may be moved to the right of the icon when the icon is shown
            lblStock.Text = stockText;
            lblStock.Location = new Point(8, stockY);
            lblStock.Size = new Size(144, 16);
            lblStock.Font = new Font("Segoe UI", 8.5F);
            lblStock.TextAlign = ContentAlignment.MiddleLeft;
            lblStock.BackColor = Color.Transparent;
            lblStock.AutoSize = false;

            // Determine visual treatment based on numeric stock when available
            try
            {
                if (product.Stock <= 0)
                {
                    // Out of stock - bright red with a red X icon
                    lblStock.Text = "Out of stock";
                    lblStock.ForeColor = Color.FromArgb(192, 57, 43); // red
                    stockIcon.IconChar = IconChar.TimesCircle;
                    stockIcon.IconColor = lblStock.ForeColor;
                    stockIcon.Visible = true;
                }
                else if (product.Stock <= 5)
                {
                    // Low stock - less intense warning color with text
                    lblStock.Text = $"Low stock: {product.Stock}";
                    lblStock.ForeColor = Color.FromArgb(211, 84, 0); // orange-ish
                    stockIcon.IconChar = IconChar.ExclamationTriangle;
                    stockIcon.IconColor = lblStock.ForeColor;
                    stockIcon.Visible = true;
                }
                else
                {
                    // Normal stock
                    lblStock.ForeColor = Color.FromArgb(80, 80, 80);
                }
            }
            catch
            {
                // If product.Stock isn't set or any error, fall back to existing text color
                lblStock.ForeColor = Color.FromArgb(80, 80, 80);
            }

            // If icon is visible add it and move the label to the right of the icon
            if (stockIcon.Visible)
            {
                pnlCard.Controls.Add(stockIcon);
                lblStock.Location = new Point(stockIcon.Right + 6, stockIcon.Top - 2);
            }

            pnlCard.Controls.Add(lblStock);

            // Price
            Label lblPrice = new Label();
            lblPrice.Text = product.GetFormattedPrice();
            // Place price below stock to avoid overlap
            lblPrice.Location = new Point(8, lblStock.Bottom + 4);
            lblPrice.Size = new Size(144, 22);
            lblPrice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(34, 139, 34);
            lblPrice.BackColor = Color.Transparent;
            lblPrice.AutoSize = false;
            pnlCard.Controls.Add(lblPrice);

            // Add to cart button
            IconButton btnAdd = new IconButton();
            btnAdd.Text = "Add to Cart";
            // Place button below price with a small gap
            btnAdd.Location = new Point(8, lblPrice.Bottom + 8);
            btnAdd.Size = new Size(144, 36);
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            bool inStock = product.IsInStock();
            btnAdd.Enabled = inStock;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.IconChar = IconChar.CartPlus;
            btnAdd.IconColor = Color.White;
            btnAdd.IconSize = 16;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.FlatStyle = FlatStyle.Flat;
            // Base font (bold)
            var baseBtnFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            // If out of stock, show strike-through on the text to indicate unavailable
            if (!inStock)
            {
                btnAdd.Font = new Font(baseBtnFont.FontFamily, baseBtnFont.Size, baseBtnFont.Style | FontStyle.Strikeout);
                // Gray out the button to indicate disabled state
                btnAdd.BackColor = Color.FromArgb(189, 195, 199);
                btnAdd.ForeColor = Color.FromArgb(99, 110, 114);
                btnAdd.IconColor = Color.FromArgb(99, 110, 114);
            }
            else
            {
                btnAdd.Font = baseBtnFont;
            }
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += (s, e) => AddToCart(product);
            pnlCard.Controls.Add(btnAdd);

            // Hover effect
            pnlCard.MouseEnter += (s, e) => pnlCard.BackColor = Color.FromArgb(248, 255, 248);
            pnlCard.MouseLeave += (s, e) => pnlCard.BackColor = Color.White;

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
                    _lblCartCount.Text = dbCount.ToString();
                    return;
                }
                catch
                {
                    // fallback to in-memory count on error
                }
            }

            _lblCartCount.Text = ShoppingCart.GetItemCount().ToString();
        }

        private void ShowCart()
        {
            ShoppingCartForm cartForm = new ShoppingCartForm(_currentCustomer);
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
            var menuForm = new ProfileMenuForm(_currentCustomer);
            menuForm.LogoutRequested += Logout;
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
