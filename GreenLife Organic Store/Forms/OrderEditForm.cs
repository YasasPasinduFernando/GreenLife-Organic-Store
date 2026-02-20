using System;
using System.Windows.Forms;
using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;

namespace GreenLife_Organic_Store.Forms
{
    public partial class OrderEditForm : Form
    {
        private Order _order;
        public Order EditedOrder { get; private set; }
        private bool _allowStatusEdit = true;

        public OrderEditForm(Order order) : this(order, true) { }

        public OrderEditForm(Order order, bool allowStatusEdit)
        {
            _order = order;
            EditedOrder = order;
            _allowStatusEdit = allowStatusEdit;
            InitializeComponent();
            LoadOrderData();
            cmbStatus.Enabled = _allowStatusEdit;
            this.Text = $"Edit Order - {order.OrderNumber}";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            try
            {
                FormThemeManager.ApplyToForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
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
                _order.Status = Enum.Parse<OrderStatus>(cmbStatus.SelectedItem?.ToString() ?? "Pending");
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
