using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ShoppingCartForm : Form
    {
        private List<CartItem> _cartItems = new();

        public ShoppingCartForm()
        {
            this.Text = "Shopping Cart";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadCartItems();
        }

        private void InitializeUI()
        {
            // Create DataGridView for cart items
            DataGridView dgvCart = new DataGridView
            {
                Name = "dgvCart",
                Location = new Point(10, 10),
                Size = new Size(680, 250),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            dgvCart.Columns.Add("ProductName", "Product");
            dgvCart.Columns.Add("Quantity", "Qty");
            dgvCart.Columns.Add("UnitPrice", "Unit Price");
            dgvCart.Columns.Add("Subtotal", "Subtotal");
            dgvCart.Columns.Add("Remove", "Remove");

            this.Controls.Add(dgvCart);

            // Quantity adjustment buttons
            Button btnIncrement = new Button
            {
                Text = "+",
                Location = new Point(600, 270),
                Size = new Size(40, 30),
                BackColor = Color.Green,
                ForeColor = Color.White
            };
            btnIncrement.Click += (s, e) => AdjustQuantity(1);
            this.Controls.Add(btnIncrement);

            Button btnDecrement = new Button
            {
                Text = "-",
                Location = new Point(550, 270),
                Size = new Size(40, 30),
                BackColor = Color.Orange,
                ForeColor = Color.White
            };
            btnDecrement.Click += (s, e) => AdjustQuantity(-1);
            this.Controls.Add(btnDecrement);

            // Total label
            Label lblTotal = new Label
            {
                Name = "lblTotal",
                Text = "Total: Rs. 0.00",
                Location = new Point(10, 310),
                Size = new Size(300, 30),
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            this.Controls.Add(lblTotal);

            // Item count label
            Label lblItemCount = new Label
            {
                Name = "lblItemCount",
                Text = "Items: 0",
                Location = new Point(10, 350),
                Size = new Size(300, 20),
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(lblItemCount);

            // Continue Shopping button
            Button btnContinue = new Button
            {
                Text = "Continue Shopping",
                Location = new Point(200, 420),
                Size = new Size(150, 40),
                BackColor = Color.LightGray,
                ForeColor = Color.Black
            };
            btnContinue.Click += (s, e) => this.Close();
            this.Controls.Add(btnContinue);

            // Checkout button
            Button btnCheckout = new Button
            {
                Text = "Proceed to Checkout",
                Location = new Point(380, 420),
                Size = new Size(150, 40),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnCheckout.Click += BtnCheckout_Click;
            this.Controls.Add(btnCheckout);
        }

        private void LoadCartItems()
        {
            DataGridView dgvCart = (DataGridView)this.Controls["dgvCart"];
            dgvCart.Rows.Clear();
            _cartItems = ShoppingCart.Items;

            foreach (var item in _cartItems)
            {
                dgvCart.Rows.Add(
                    item.Product.ProductName,
                    item.Quantity,
                    item.Product.GetFormattedPrice(),
                    $"Rs. {item.Subtotal:N2}",
                    "Remove"
                );
            }

            UpdateTotals();
        }

        private void UpdateTotals()
        {
            Label lblTotal = (Label)this.Controls["lblTotal"];
            Label lblItemCount = (Label)this.Controls["lblItemCount"];

            lblTotal.Text = $"Total: {ShoppingCart.Items.Sum(x => x.Product.GetFinalPrice() * x.Quantity):C}";
            lblItemCount.Text = $"Items: {ShoppingCart.GetItemCount()}";
        }

        private void AdjustQuantity(int adjustment)
        {
            DataGridView dgvCart = (DataGridView)this.Controls["dgvCart"];
            if (dgvCart.SelectedRows.Count > 0)
            {
                int rowIndex = dgvCart.SelectedRows[0].Index;
                var cartItem = _cartItems[rowIndex];
                int newQuantity = cartItem.Quantity + adjustment;

                if (newQuantity <= 0)
                {
                    ShoppingCart.RemoveItem(cartItem.Product.ID);
                }
                else if (newQuantity <= cartItem.Product.Stock)
                {
                    ShoppingCart.UpdateQuantity(cartItem.Product.ID, newQuantity);
                }
                else
                {
                    MessageBox.Show("Cannot exceed available stock!", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadCartItems();
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (!ShoppingCart.HasItems())
            {
                MessageBox.Show("Your cart is empty!", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CheckoutForm checkoutForm = new CheckoutForm();
            if (checkoutForm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
