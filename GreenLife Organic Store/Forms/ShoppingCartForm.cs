using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Utilities;
using System.IO;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ShoppingCartForm : Form
    {
        private List<CartItem> _cartItems = new();
        private User? _currentUser;
        private DataGridView _dgvCart = null!;

        public ShoppingCartForm()
        {
            this.Text = "Shopping Cart";
            this.Size = new Size(820, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Load += ShoppingCartForm_Load;
        }

        // Allow creating the cart form with an optional logged-in user so we can continue checkout as that user
        public ShoppingCartForm(User? currentUser) : this()
        {
            _currentUser = currentUser;
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeUI();
                LoadCartItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shopping cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            Label lblHeader = new Label
            {
                Text = "Shopping Cart",
                Location = new Point(20, 18),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(lblHeader);
            this.Controls.Add(pnlHeader);

            // Create DataGridView for cart items
            _dgvCart = new DataGridView
            {
                Name = "dgvCart",
                Location = new Point(20, 80),
                Size = new Size(760, 280),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                GridColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(52, 73, 94),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Padding = new Padding(5)
                },
                ColumnHeadersHeight = 35,
                RowTemplate = new DataGridViewRow { Height = 50 }
            };

            // Add text columns
            var imgCol = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            _dgvCart.Columns.Add(imgCol);
            _dgvCart.Columns.Add("ProductName", "Product");
            _dgvCart.Columns.Add("Quantity", "Quantity");
            _dgvCart.Columns.Add("UnitPrice", "Price");
            _dgvCart.Columns.Add("Subtotal", "Subtotal");

            // Add button column for Remove
            DataGridViewButtonColumn btnRemoveColumn = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "Action",
                Text = "Remove",
                UseColumnTextForButtonValue = true,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            _dgvCart.Columns.Add(btnRemoveColumn);

            // Handle button click
            _dgvCart.CellClick += DgvCart_CellClick;

            this.Controls.Add(_dgvCart);

            // Quantity adjustment panel
            Panel pnlQuantity = new Panel
            {
                Location = new Point(20, 370),
                Size = new Size(760, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblQuantityInfo = new Label
            {
                Text = "Adjust Quantity:",
                Location = new Point(15, 15),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlQuantity.Controls.Add(lblQuantityInfo);

            IconButton btnDecrement = new IconButton
            {
                Text = "",
                Location = new Point(180, 10),
                Size = new Size(45, 32),
                BackColor = Color.FromArgb(230, 126, 34),
                ForeColor = Color.White,
                IconChar = IconChar.Minus,
                IconColor = Color.White,
                IconSize = 20,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };
            btnDecrement.FlatAppearance.BorderSize = 0;
            btnDecrement.Click += (s, e) => AdjustQuantity(-1);
            pnlQuantity.Controls.Add(btnDecrement);

            IconButton btnIncrement = new IconButton
            {
                Text = "",
                Location = new Point(235, 10),
                Size = new Size(45, 32),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                IconChar = IconChar.Plus,
                IconColor = Color.White,
                IconSize = 20,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };
            btnIncrement.FlatAppearance.BorderSize = 0;
            btnIncrement.Click += (s, e) => AdjustQuantity(1);
            pnlQuantity.Controls.Add(btnIncrement);

            IconButton btnClearCart = new IconButton
            {
                Text = "Clear Cart",
                Location = new Point(620, 10),
                Size = new Size(130, 32),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                IconChar = IconChar.TrashAlt,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.Click += BtnClearCart_Click;
            pnlQuantity.Controls.Add(btnClearCart);

            this.Controls.Add(pnlQuantity);

            // Summary Panel
            Panel pnlSummary = new Panel
            {
                Location = new Point(20, 430),
                Size = new Size(760, 50),
                BackColor = Color.FromArgb(240, 255, 240),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTotal = new Label
            {
                Name = "lblTotal",
                Text = "Total: Rs. 0.00",
                Location = new Point(15, 12),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 139, 34)
            };
            pnlSummary.Controls.Add(lblTotal);

            Label lblItemCount = new Label
            {
                Name = "lblItemCount",
                Text = "Items: 0",
                Location = new Point(320, 15),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            pnlSummary.Controls.Add(lblItemCount);

            this.Controls.Add(pnlSummary);

            // Action buttons
            IconButton btnContinue = new IconButton
            {
                Text = "Continue Shopping",
                Location = new Point(360, 500),
                Size = new Size(190, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                IconChar = IconChar.ArrowLeft,
                IconColor = Color.White,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.Click += (s, e) => this.Close();
            this.Controls.Add(btnContinue);

            IconButton btnCheckout = new IconButton
            {
                Text = "Proceed to Checkout",
                Location = new Point(560, 500),
                Size = new Size(220, 45),
                BackColor = Color.FromArgb(34, 139, 34),
                ForeColor = Color.White,
                IconChar = IconChar.CreditCard,
                IconColor = Color.White,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.Click += BtnCheckout_Click;
            this.Controls.Add(btnCheckout);
        }

        private void DgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the Remove button column was clicked
                if (e.RowIndex >= 0 && e.ColumnIndex == _dgvCart.Columns["Remove"].Index)
                {
                    var cartItem = _cartItems[e.RowIndex];
                    
                    if (MessageBox.Show($"Remove {cartItem.Product.ProductName} from cart?", 
                        "Confirm Remove", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ShoppingCart.RemoveItem(cartItem.Product.ID);
                        if (_currentUser != null && _currentUser.ID > 0)
                        {
                            CartRepository.RemoveCartItem(_currentUser.ID, cartItem.Product.ID);
                        }
                        LoadCartItems();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCartItems()
        {
            try
            {
                _dgvCart.Rows.Clear();
                _cartItems = ShoppingCart.Items;

                foreach (var item in _cartItems)
                {
                    Image? thumb = null;
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(item.Product.ImagePath))
                        {
                            var fullPath = ImageStore.GetFullPath(item.Product.ImagePath);
                            if (File.Exists(fullPath))
                            {
                                using var img = Image.FromFile(fullPath);
                                thumb = new Bitmap(img, new Size(50, 50));
                            }
                        }
                    }
                    catch { }

                    _dgvCart.Rows.Add(
                        thumb,
                        item.Product.ProductName,
                        item.Quantity,
                        item.Product.GetFormattedPrice(),
                        $"Rs. {item.Subtotal:N2}"
                    );
                }

                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotals()
        {
            try
            {
                Label lblTotal = this.Controls.Cast<Control>()
                    .SelectMany(c => c is Panel p ? p.Controls.Cast<Control>() : Enumerable.Empty<Control>())
                    .FirstOrDefault(c => c.Name == "lblTotal") as Label;
                    
                Label lblItemCount = this.Controls.Cast<Control>()
                    .SelectMany(c => c is Panel p ? p.Controls.Cast<Control>() : Enumerable.Empty<Control>())
                    .FirstOrDefault(c => c.Name == "lblItemCount") as Label;

                if (lblTotal != null)
                    lblTotal.Text = $"Total: Rs. {ShoppingCart.Items.Sum(x => x.Product.GetFinalPrice() * x.Quantity):N2}";
                
                if (lblItemCount != null)
                    lblItemCount.Text = $"Items: {ShoppingCart.GetItemCount()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating totals: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustQuantity(int adjustment)
        {
            try
            {
                if (_dgvCart.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to adjust quantity.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = _dgvCart.SelectedRows[0].Index;
                var cartItem = _cartItems[rowIndex];
                int newQuantity = cartItem.Quantity + adjustment;

                if (newQuantity <= 0)
                {
                    if (MessageBox.Show($"Remove {cartItem.Product.ProductName} from cart?", 
                        "Remove Item", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ShoppingCart.RemoveItem(cartItem.Product.ID);
                        if (_currentUser != null && _currentUser.ID > 0)
                        {
                            CartRepository.RemoveCartItem(_currentUser.ID, cartItem.Product.ID);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    // Only enforce stock limit when increasing quantity
                    bool isIncrease = newQuantity > cartItem.Quantity;
                    if (isIncrease && newQuantity > cartItem.Product.Stock)
                    {
                        MessageBox.Show("Cannot exceed available stock!", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ShoppingCart.UpdateQuantity(cartItem.Product.ID, newQuantity);
                    if (_currentUser != null && _currentUser.ID > 0)
                    {
                        CartRepository.SetCartItemQuantity(_currentUser.ID, cartItem.Product.ID, newQuantity);
                    }
                }

                LoadCartItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adjusting quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ShoppingCart.HasItems())
                {
                    MessageBox.Show("Cart is already empty.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to clear all items from cart?", 
                    "Clear Cart", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ShoppingCart.Clear();
                    if (_currentUser != null && _currentUser.ID > 0)
                    {
                        CartRepository.ClearCart(_currentUser.ID);
                    }
                    LoadCartItems();
                    MessageBox.Show("Cart cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (!ShoppingCart.HasItems())
            {
                MessageBox.Show("Your cart is empty!", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CheckoutForm checkoutForm = new CheckoutForm(_currentUser);
            if (checkoutForm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
