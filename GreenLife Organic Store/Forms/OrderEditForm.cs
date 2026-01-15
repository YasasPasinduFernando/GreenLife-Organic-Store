using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public class OrderEditForm : Form
    {
        private Order _order;
        public Order EditedOrder { get; private set; }

        private TextBox txtCustomerName;
        private TextBox txtCustomerPhone;
        private TextBox txtCustomerEmail;
        private ComboBox cmbStatus;
        private TextBox txtShippingAddress;
        private TextBox txtNotes;
        private bool _allowStatusEdit = true;

        public OrderEditForm(Order order)
            : this(order, true)
        {
        }

        // allowStatusEdit: set to false for customer edits so status cannot be changed
        public OrderEditForm(Order order, bool allowStatusEdit)
        {
            _order = order;
            EditedOrder = order;
            _allowStatusEdit = allowStatusEdit;

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.Text = $"Edit Order - {order.OrderNumber}";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(245, 245, 245);

            InitializeComponents();
            LoadOrderData();
        }

        private void InitializeComponents()
        {
            Label lblCustName = new Label { Text = "Customer Name:", Location = new Point(10, 10), Size = new Size(120, 22) };
            txtCustomerName = new TextBox { Location = new Point(140, 10), Size = new Size(400, 25) };

            Label lblPhone = new Label { Text = "Phone:", Location = new Point(10, 45), Size = new Size(120, 22) };
            txtCustomerPhone = new TextBox { Location = new Point(140, 45), Size = new Size(400, 25) };

            Label lblEmail = new Label { Text = "Email:", Location = new Point(10, 80), Size = new Size(120, 22) };
            txtCustomerEmail = new TextBox { Location = new Point(140, 80), Size = new Size(400, 25) };

            Label lblStatus = new Label { Text = "Status:", Location = new Point(10, 115), Size = new Size(120, 22) };
            cmbStatus = new ComboBox { Location = new Point(140, 115), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new[] { "Pending", "Processing", "Shipped", "Delivered", "Cancelled" });

            Label lblAddress = new Label { Text = "Shipping Address:", Location = new Point(10, 150), Size = new Size(120, 22) };
            txtShippingAddress = new TextBox { Location = new Point(140, 150), Size = new Size(400, 60), Multiline = true };

            Label lblNotes = new Label { Text = "Notes:", Location = new Point(10, 220), Size = new Size(120, 22) };
            txtNotes = new TextBox { Location = new Point(140, 220), Size = new Size(400, 120), Multiline = true };

            IconButton btnSave = new IconButton
            {
                Text = "Save",
                Location = new Point(140, 360),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(34, 139, 34),
                ForeColor = Color.White,
                IconChar = IconChar.Save,
                IconColor = Color.White,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnSave.Click += (s, e) => SaveAndClose();

            IconButton btnCancel = new IconButton
            {
                Text = "Cancel",
                Location = new Point(260, 360),
                Size = new Size(100, 30),
                BackColor = Color.LightGray,
                IconChar = IconChar.Times,
                IconColor = Color.Black,
                IconSize = 20,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblCustName);
            this.Controls.Add(txtCustomerName);
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtCustomerPhone);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtCustomerEmail);
            this.Controls.Add(lblStatus);
            this.Controls.Add(cmbStatus);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtShippingAddress);
            this.Controls.Add(lblNotes);
            this.Controls.Add(txtNotes);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            // Disable status editing if not allowed
            cmbStatus.Enabled = _allowStatusEdit;
        }

        private void LoadOrderData()
        {
            txtCustomerName.Text = _order.CustomerName;
            txtCustomerPhone.Text = _order.CustomerPhone;
            txtCustomerEmail.Text = _order.CustomerEmail;
            cmbStatus.SelectedItem = _order.Status.ToString();
            txtShippingAddress.Text = _order.ShippingAddress;
            txtNotes.Text = _order.Notes ?? string.Empty;
        }

        private void SaveAndClose()
        {
            try
            {
                _order.CustomerName = txtCustomerName.Text.Trim();
                _order.CustomerPhone = txtCustomerPhone.Text.Trim();
                _order.CustomerEmail = txtCustomerEmail.Text.Trim();
                _order.Status = Enum.Parse<OrderStatus>(cmbStatus.SelectedItem.ToString());
                _order.ShippingAddress = txtShippingAddress.Text.Trim();
                _order.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();

                EditedOrder = _order;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
