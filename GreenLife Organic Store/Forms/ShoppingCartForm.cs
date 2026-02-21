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
        private const int LayoutMargin = 20;
        private const int SectionGap = 10;
        private const int ButtonGap = 12;
        private const int BottomMargin = 20;

        public ShoppingCartForm()
        {
            InitializeComponent();
            this.Text = "Shopping Cart";
            this.ClientSize = new Size(820, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);
            ApplyCartLayout();
            this.ClientSizeChanged += (_, __) => ApplyCartLayout();
            if (!DesignMode)
                this.Load += ShoppingCartForm_Load;
        }

        public ShoppingCartForm(User? currentUser) : this()
        {
            _currentUser = currentUser;
        }

        private void ShoppingCartForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                ApplyCartLayout();
                LoadCartItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shopping cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyCartLayout()
        {
            if (_dgvCart == null || pnlHeader == null || pnlQuantity == null || pnlSummary == null || btnContinue == null || btnCheckout == null || btnClearCart == null)
            {
                return;
            }

            int contentWidth = ClientSize.Width - (LayoutMargin * 2);
            if (contentWidth <= 0)
            {
                return;
            }

            _dgvCart.Width = contentWidth;
            pnlQuantity.Width = contentWidth;
            pnlSummary.Width = contentWidth;
            btnClearCart.Location = new Point(pnlQuantity.Width - btnClearCart.Width - 10, btnClearCart.Location.Y);

            int buttonsTop = ClientSize.Height - BottomMargin - btnCheckout.Height;
            int checkoutLeft = LayoutMargin + contentWidth - btnCheckout.Width;
            btnCheckout.Location = new Point(checkoutLeft, buttonsTop);
            btnContinue.Location = new Point(checkoutLeft - ButtonGap - btnContinue.Width, buttonsTop);

            pnlSummary.Location = new Point(LayoutMargin, buttonsTop - SectionGap - pnlSummary.Height);
            pnlQuantity.Location = new Point(LayoutMargin, pnlSummary.Top - SectionGap - pnlQuantity.Height);

            int gridTop = pnlHeader.Bottom + SectionGap;
            int gridHeight = pnlQuantity.Top - SectionGap - gridTop;
            if (gridHeight < 140)
            {
                gridHeight = 140;
            }
            _dgvCart.Location = new Point(LayoutMargin, gridTop);
            _dgvCart.Height = gridHeight;
        }

        private void BtnDecrement_Click(object? sender, EventArgs e) => AdjustQuantity(-1);
        private void BtnIncrement_Click(object? sender, EventArgs e) => AdjustQuantity(1);
        private void BtnContinue_Click(object? sender, EventArgs e) => Close();

        private void DgvCart_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
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
