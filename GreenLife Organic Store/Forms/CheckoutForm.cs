using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Database;
using FontAwesome.Sharp;
using System.Text.RegularExpressions;

namespace GreenLife_Organic_Store.Forms
{
    public partial class CheckoutForm : Form
    {
        private User? _currentUser;
        private List<CartItem> _cartItems = new();
        private decimal _totalAmount;
        private ProgressBar progressBarEmail;

        public CheckoutForm()
        {
            this.Text = "Checkout & Place Order";
            // Slightly taller than original to fit progress bar comfortably
            this.Size = new Size(700, 740);
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
            TextBox txtName = new TextBox { Name = "txtName", Location = new Point(120, yPosition), Size = new Size(540, 25) };
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            yPosition += 30;

            // Phone
            Label lblPhone = new Label { Text = "Phone:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtPhone = new TextBox { Name = "txtPhone", Location = new Point(120, yPosition), Size = new Size(540, 25) };
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            yPosition += 30;

            // Email
            Label lblEmail = new Label { Text = "Email:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtEmail = new TextBox { Name = "txtEmail", Location = new Point(120, yPosition), Size = new Size(540, 25) };
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            yPosition += 30;

            // Address
            Label lblAddress = new Label { Text = "Address:", Location = new Point(10, yPosition), Size = new Size(100, 20) };
            TextBox txtAddress = new TextBox
            {
                Name = "txtAddress",
                Location = new Point(120, yPosition),
                Size = new Size(540, 80),
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
                BackColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
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
            IconButton btnCancel = new IconButton
            {
                Name = "btnCancel",
                Text = "Cancel",
                Location = new Point(200, 560),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                IconChar = IconChar.Times,
                IconColor = Color.Black,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);

            // Place Order button
            IconButton btnPlaceOrder = new IconButton
            {
                Name = "btnPlaceOrder",
                Text = "Place Order",
                Location = new Point(380, 560),
                Size = new Size(140, 40),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                IconChar = IconChar.ShoppingCart,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPlaceOrder.FlatAppearance.BorderSize = 0;
            btnPlaceOrder.Click += BtnPlaceOrder_Click;
            this.Controls.Add(btnPlaceOrder);

            // Progress bar for email sending � full width with margins
            progressBarEmail = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 25,
                Visible = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            int pbWidth = Math.Max(200, this.ClientSize.Width - 40); // 20px margin each side
            progressBarEmail.Size = new Size(pbWidth, 18);
            progressBarEmail.Location = new Point(20, btnPlaceOrder.Bottom + 12);
            this.Controls.Add(progressBarEmail);
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

        private async void BtnPlaceOrder_Click(object sender, EventArgs e)
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
                txtPhone.Focus();
                return;
            }

            // Basic phone validation: allow common separators but require 7-15 digits total
            var digitsOnly = Regex.Replace(txtPhone.Text ?? string.Empty, "\\D", "");
            if (digitsOnly.Length < 7 || digitsOnly.Length > 15)
            {
                MessageBox.Show("Please enter a valid phone number (7-15 digits). You can include spaces, dashes or parentheses.", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
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
                // Ensure customer exists in DB. If no logged-in user, attempt to find by email or create a new customer user.
                if (_currentUser == null || _currentUser.ID == 0)
                {
                    // Try to find an existing user by email
                    var existing = UserRepository.GetUserByEmail(order.CustomerEmail);
                    if (existing != null)
                    {
                        order.CustomerID = existing.ID;
                    }
                    else
                    {
                        // Create a new customer user with a random password placeholder
                        var newUser = new User
                        {
                            Email = order.CustomerEmail,
                            Name = order.CustomerName,
                            Phone = order.CustomerPhone,
                            Address = order.ShippingAddress,
                            UserType = UserType.Customer,
                            Password = Guid.NewGuid().ToString()
                        };

                        int newUserId = UserRepository.CreateUser(newUser);
                        if (newUserId <= 0)
                            throw new Exception("Failed to create customer account for guest checkout.");

                        order.CustomerID = newUserId;
                    }
                }

                int orderId = OrderRepository.CreateOrder(order);

                if (orderId > 0)
                {
                    ShoppingCart.Clear();
                    // Clear DB cart for the customer associated with this order if available.
                    // Use order.CustomerID (may be a newly created user or an existing user found by email)
                    try
                    {
                        if (order.CustomerID > 0)
                        {
                            GreenLife_Organic_Store.Database.CartRepository.ClearCart(order.CustomerID);
                        }
                    }
                    catch
                    {
                        // non-fatal
                    }
                    // Send confirmation email (best-effort) but show progress to user
                    try
                    {
                        progressBarEmail.Visible = true;
                        // run send on background and await completion briefly so user sees progress
                        bool emailSent = await Task.Run(() =>
                        {
                            try
                            {
                                return GreenLife_Organic_Store.Utilities.EmailService.SendOrderConfirmation(
                                    order.CustomerEmail,
                                    order.CustomerName,
                                    order.OrderNumber,
                                    order.TotalAmount,
                                    order.Items
                                );
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[Checkout] Order confirmation email failed: {ex.Message}");
                                return false;
                            }
                        });
                        // keep progress visible briefly
                        await Task.Delay(300);
                        progressBarEmail.Visible = false;
                        // ignore emailSent result (best-effort)
                    }
                    catch
                    {
                        try { progressBarEmail.Visible = false; } catch { }
                    }
                    // Notify all admins (best-effort, async)
                    try
                    {
                        var adminEmails = UserRepository.GetAdminEmails();
                        _ = GreenLife_Organic_Store.Utilities.EmailService.SendOrderPlacedAlertToAdminsAsync(
                            adminEmails,
                            order.OrderNumber,
                            order.CustomerName,
                            order.TotalAmount
                        );
                    }
                    catch
                    {
                        // ignore admin email failures
                    }

                    // Low stock alerts after checkout (best-effort)
                    try
                    {
                        var lowStockProducts = ProductRepository.GetLowStockProducts();
                        if (lowStockProducts.Count > 0)
                        {
                            var adminEmails = UserRepository.GetAdminEmails();
                            var items = lowStockProducts.Select(p => (p.ProductName ?? string.Empty, p.Stock));
                            _ = GreenLife_Organic_Store.Utilities.EmailService.SendLowStockAlertsToAdminsAsync(adminEmails, items);
                        }
                    }
                    catch
                    {
                        // ignore low stock email failures
                    }

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
