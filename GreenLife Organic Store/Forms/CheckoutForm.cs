using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class CheckoutForm : Form
    {
        private User? _currentUser;
        private List<CartItem> _cartItems = new();
        private decimal _totalAmount;

        public CheckoutForm()
        {
            this.Text = "Checkout & Place Order";
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Load += CheckoutForm_Load;
        }

        public CheckoutForm(User currentUser) : this()
        {
            _currentUser = currentUser;
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeUI();
                LoadCustomerInfo();
                LoadOrderSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading checkout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUI()
        {
            int yPosition = 10;

            // Delivery Information Section
            Label lblDeliveryInfo = new Label
            {
                Text = "DELIVERY INFORMATION",
                Location = new Point(10, yPosition),
                Size = new Size(300, 20),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            this.Controls.Add(lblDeliveryInfo);
            yPosition += 30;

            // Full Name
            Label lblName = new Label { Text = "Full Name:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtName = new TextBox { Name = "txtName", Location = new Point(120, yPosition), Size = new Size(300, 25) };
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            yPosition += 30;

            // Phone
            Label lblPhone = new Label { Text = "Phone:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtPhone = new TextBox { Name = "txtPhone", Location = new Point(120, yPosition), Size = new Size(300, 25) };
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            yPosition += 30;

            // Email
            Label lblEmail = new Label { Text = "Email:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtEmail = new TextBox { Name = "txtEmail", Location = new Point(120, yPosition), Size = new Size(300, 25) };
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            yPosition += 30;

            // Address
            Label lblAddress = new Label { Text = "Address:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtAddress = new TextBox
            {
                Name = "txtAddress",
                Location = new Point(120, yPosition),
                Size = new Size(300, 80),
                Multiline = true
            };
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            yPosition += 100;

            // Order Summary Section
            Label lblOrderSummary = new Label
            {
                Text = "ORDER SUMMARY",
                Location = new Point(10, yPosition),
                Size = new Size(300, 20),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            this.Controls.Add(lblOrderSummary);
            yPosition += 30;

            // DataGridView for order items
            DataGridView dgvItems = new DataGridView
            {
                Name = "dgvItems",
                Location = new Point(10, yPosition),
                Size = new Size(660, 120),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackColor = Color.White
            };
            dgvItems.Columns.Add("ProductName", "Product");
            dgvItems.Columns.Add("Quantity", "Qty");
            dgvItems.Columns.Add("UnitPrice", "Unit Price");
            dgvItems.Columns.Add("Subtotal", "Subtotal");
            this.Controls.Add(dgvItems);
            yPosition += 130;

            // Total Amount
            Label lblTotal = new Label
            {
                Name = "lblTotal",
                Text = "Total Amount: Rs. 0.00",
                Location = new Point(10, yPosition),
                Size = new Size(400, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            this.Controls.Add(lblTotal);
            yPosition += 40;

            // Notes
            Label lblNotes = new Label { Text = "Notes (Optional):", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtNotes = new TextBox
            {
                Name = "txtNotes",
                Location = new Point(10, yPosition + 25),
                Size = new Size(660, 60),
                Multiline = true
            };
            this.Controls.Add(lblNotes);
            this.Controls.Add(txtNotes);

            // Cancel button
            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(200, 510),
                Size = new Size(120, 40),
                BackColor = Color.LightGray
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);

            // Place Order button
            Button btnPlaceOrder = new Button
            {
                Text = "Place Order",
                Location = new Point(380, 510),
                Size = new Size(120, 40),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnPlaceOrder.Click += BtnPlaceOrder_Click;
            this.Controls.Add(btnPlaceOrder);
        }

        private void LoadCustomerInfo()
        {
            try
            {
                if (_currentUser != null)
                {
                    TextBox txtName = this.Controls.Cast<Control>().FirstOrDefault(c => c is TextBox && ((TextBox)c).Name == "txtName") as TextBox;
                    TextBox txtPhone = this.Controls.Cast<Control>().FirstOrDefault(c => c is TextBox && ((TextBox)c).Name == "txtPhone") as TextBox;
                    TextBox txtEmail = this.Controls.Cast<Control>().FirstOrDefault(c => c is TextBox && ((TextBox)c).Name == "txtEmail") as TextBox;
                    TextBox txtAddress = this.Controls.Cast<Control>().FirstOrDefault(c => c is TextBox && ((TextBox)c).Name == "txtAddress") as TextBox;

                    if (txtName != null) txtName.Text = _currentUser.Name;
                    if (txtPhone != null) txtPhone.Text = _currentUser.Phone ?? "";
                    if (txtEmail != null) txtEmail.Text = _currentUser.Email;
                    if (txtAddress != null) txtAddress.Text = _currentUser.Address ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderSummary()
        {
            try
            {
                DataGridView dgvItems = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dgvItems") as DataGridView;
                Label lblTotal = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "lblTotal") as Label;

                if (dgvItems != null)
                {
                    dgvItems.Rows.Clear();

                    _cartItems = ShoppingCart.Items;
                    _totalAmount = 0;

                    foreach (var item in _cartItems)
                    {
                        dgvItems.Rows.Add(
                            item.Product.ProductName,
                            item.Quantity,
                            item.Product.GetFormattedPrice(),
                            $"Rs. {item.Subtotal:N2}"
                        );
                        _totalAmount += item.Subtotal;
                    }
                }

                if (lblTotal != null)
                    lblTotal.Text = $"Total Amount: Rs. {_totalAmount:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Validation
            TextBox txtName = (TextBox)this.Controls["txtName"];
            TextBox txtPhone = (TextBox)this.Controls["txtPhone"];
            TextBox txtEmail = (TextBox)this.Controls["txtEmail"];
            TextBox txtAddress = (TextBox)this.Controls["txtAddress"];
            TextBox txtNotes = (TextBox)this.Controls["txtNotes"];

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter your full name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter your phone number.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter your delivery address.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create order
                Order order = new Order
                {
                    OrderNumber = new Order().GenerateOrderNumber(),
                    CustomerID = _currentUser?.ID ?? 0,
                    CustomerName = txtName.Text,
                    CustomerPhone = txtPhone.Text,
                    CustomerEmail = txtEmail.Text,
                    OrderDate = DateTime.Now,
                    TotalAmount = _totalAmount,
                    Status = OrderStatus.Pending,
                    ShippingAddress = txtAddress.Text,
                    Notes = txtNotes.Text
                };

                // Add items to order
                foreach (var item in ShoppingCart.Items)
                {
                    var orderItem = new OrderItem
                    {
                        ProductID = item.Product.ID,
                        ProductName = item.Product.ProductName,
                        Quantity = item.Quantity,
                        UnitPrice = item.Product.GetFinalPrice(),
                        Subtotal = item.Subtotal
                    };
                    order.Items.Add(orderItem);
                }

                // Save to database
                int orderId = OrderRepository.CreateOrder(order);

                if (orderId > 0)
                {
                    ShoppingCart.Clear();
                    MessageBox.Show(
                        $"Order placed successfully!\nOrder Number: {order.OrderNumber}\n\nTotal: Rs. {_totalAmount:N2}",
                        "Order Confirmed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error placing order. Please try again.", "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
