using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ManageOrdersForm : Form
    {
        private List<Order> _allOrders = new();

        public ManageOrdersForm()
        {
            InitializeComponent();
            this.Text = "Manage Orders";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            try
            {
                LoadOrders();
                FormThemeManager.ApplyToForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void EditSelectedOrder()
        {
            if (_dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string orderNumber = _dgvOrders.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
            var order = _allOrders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (order == null)
            {
                MessageBox.Show("Selected order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var editForm = new OrderEditForm(order);
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

        private void CmbStatus_SelectedIndexChanged(object? sender, EventArgs e) => FilterByStatus();
        private void BtnFilter_Click(object? sender, EventArgs e) => FilterByDateRange();
        private void BtnRefresh_Click(object? sender, EventArgs e) => LoadOrders();
        private void DgvOrders_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) ViewOrderDetails(); }
        private void BtnUpdate_Click(object? sender, EventArgs e) => UpdateOrderStatus();
        private void BtnViewDetails_Click(object? sender, EventArgs e) => ViewOrderDetails();
        private void BtnEditOrder_Click(object? sender, EventArgs e) => EditSelectedOrder();
        private void BtnClose_Click(object? sender, EventArgs e) => Close();

        private void LoadOrders()
        {
            try
            {
                _allOrders = OrderRepository.GetAllOrders();
                _dgvOrders.Rows.Clear();

                foreach (var order in _allOrders)
                {
                    _dgvOrders.Rows.Add(
                        order.OrderNumber,
                        order.CustomerName,
                        order.GetStatusText(),
                        order.GetFormattedTotal(),
                        order.OrderDate.ToString("dd/MM/yyyy HH:mm")
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterByStatus()
        {
            _dgvOrders.Rows.Clear();

            string? selectedStatus = cmbStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedStatus)) selectedStatus = "All Orders";
            List<Order> filtered;

            if (selectedStatus == "All Orders" || selectedStatus == null)
            {
                filtered = _allOrders;
            }
            else
            {
                var status = Enum.Parse<OrderStatus>(selectedStatus);
                filtered = _allOrders.Where(o => o.Status == status).ToList();
            }

            foreach (var order in filtered)
            {
                _dgvOrders.Rows.Add(
                    order.OrderNumber,
                    order.CustomerName,
                    order.GetStatusText(),
                    order.GetFormattedTotal(),
                    order.OrderDate.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        private void FilterByDateRange()
        {
            var filtered = OrderRepository.GetOrdersByDateRange(dtFromDate.Value, dtToDate.Value);
            _dgvOrders.Rows.Clear();

            foreach (var order in filtered)
            {
                _dgvOrders.Rows.Add(
                    order.OrderNumber,
                    order.CustomerName,
                    order.GetStatusText(),
                    order.GetFormattedTotal(),
                    order.OrderDate.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        private void UpdateOrderStatus()
        {
            if (_dgvOrders.SelectedRows.Count > 0)
            {
                string orderNumber = _dgvOrders.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
                var order = _allOrders.FirstOrDefault(o => o.OrderNumber == orderNumber);

                if (order != null)
                {
                    try
                    {
                        var newStatus = Enum.Parse<OrderStatus>(cmbNewStatus.SelectedItem?.ToString() ?? "Pending");
                        if (OrderRepository.UpdateOrderStatus(order.ID, newStatus))
                        {
                            // Send status update email (best-effort) on background thread
                            try
                            {
                                _ = Task.Run(() =>
                                {
                                    try
                                    {
                                        GreenLife_Organic_Store.Utilities.EmailService.SendOrderStatusUpdate(
                                            order.CustomerEmail,
                                            order.CustomerName,
                                            order.OrderNumber,
                                            newStatus.ToString()
                                        );
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"[ManageOrders] Status update email failed: {ex.Message}");
                                    }
                                });
                            }
                            catch
                            {
                                // ignore
                            }

                            MessageBox.Show("Order status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrders();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating order status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ViewOrderDetails()
        {
            if (_dgvOrders.SelectedRows.Count > 0)
            {
                string orderNumber = _dgvOrders.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
                var order = _allOrders.FirstOrDefault(o => o.OrderNumber == orderNumber);

                if (order != null)
                {
                    // Reload order items from database
                    order = OrderRepository.GetOrderById(order.ID);
                    OrderDetailsForm detailsForm = new OrderDetailsForm(order);
                    detailsForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select an order to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
