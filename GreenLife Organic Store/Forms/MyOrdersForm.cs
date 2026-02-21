using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class MyOrdersForm : Form
    {
        private User _currentUser = null!;
        private List<Order> _orders = new();

        public MyOrdersForm()
        {
            InitializeComponent();
            this.Text = "My Orders";
            this.ClientSize = new Size(840, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = FormThemeManager.Background;
            this.ForeColor = FormThemeManager.TextColor;
            this.DoubleBuffered = true;
            if (!DesignMode)
                this.Load += MyOrdersForm_Load;
        }

        public MyOrdersForm(User currentUser) : this()
        {
            _currentUser = currentUser;
        }

        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                LoadOrders();
                FormThemeManager.ApplyToForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e) => LoadOrders();
        private void BtnClose_Click(object? sender, EventArgs e) => Close();

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dgvOrders == null || _dgvOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an order to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = _dgvOrders.SelectedRows[0].Index;
                string orderNumber = _dgvOrders.Rows[rowIndex].Cells["OrderNumber"].Value?.ToString();

                var order = _orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
                if (order == null)
                {
                    MessageBox.Show("Selected order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (order.Status != OrderStatus.Pending)
                {
                    MessageBox.Show("Only orders with status 'Pending' can be deleted.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete the selected order? This will restore product stock.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                try
                {
                    bool success = OrderRepository.DeleteOrder(order.ID);
                    if (success)
                    {
                        MessageBox.Show("Order deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                _orders = OrderRepository.GetOrdersByCustomerId(_currentUser.ID);

                _dgvOrders.Rows.Clear();

                foreach (var order in _orders)
                {
                    _dgvOrders.Rows.Add(
                        order.OrderNumber,
                        order.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                        order.GetStatusText(),
                        order.GetFormattedTotal()
                    );

                    // Color code by status
                    int lastRowIndex = _dgvOrders.Rows.Count - 1;
                    switch (order.Status)
                    {
                        case OrderStatus.Pending:
                            _dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case OrderStatus.Processing:
                            _dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case OrderStatus.Shipped:
                            _dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
                            break;
                        case OrderStatus.Delivered:
                            _dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case OrderStatus.Cancelled:
                            _dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dgvOrders == null) return;

                ComboBox cmbStatus = sender as ComboBox;
                if (cmbStatus == null) return;

                _dgvOrders.Rows.Clear();

                string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "All Orders";

                List<Order> filteredOrders;
                if (selectedStatus == "All Orders")
                {
                    filteredOrders = _orders;
                }
                else
                {
                    var status = Enum.Parse<OrderStatus>(selectedStatus);
                    filteredOrders = _orders.Where(o => o.Status == status).ToList();
                }

                foreach (var order in filteredOrders)
                {
                    _dgvOrders.Rows.Add(
                        order.OrderNumber,
                        order.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                        order.GetStatusText(),
                        order.GetFormattedTotal()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dgvOrders == null || _dgvOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an order to view details.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = _dgvOrders.SelectedRows[0].Index;
                string orderNumber = _dgvOrders.Rows[rowIndex].Cells["OrderNumber"].Value?.ToString();

                var selectedOrder = _orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
                if (selectedOrder != null)
                {
                    OrderDetailsForm detailsForm = new OrderDetailsForm(selectedOrder);
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dgvOrders == null || _dgvOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an order to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rowIndex = _dgvOrders.SelectedRows[0].Index;
                string orderNumber = _dgvOrders.Rows[rowIndex].Cells["OrderNumber"].Value?.ToString();

                var order = _orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
                if (order == null)
                {
                    MessageBox.Show("Selected order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (order.Status != OrderStatus.Pending)
                {
                    MessageBox.Show("Only orders with status 'Pending' can be edited.", "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Reload full order (with items) from DB
                var fullOrder = OrderRepository.GetOrderById(order.ID);
                if (fullOrder == null)
                {
                    MessageBox.Show("Unable to load order details for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var editForm = new OrderEditForm(fullOrder, false); // customer edits should not change status
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (OrderRepository.UpdateOrder(editForm.EditedOrder))
                        {
                            MessageBox.Show("Order updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
