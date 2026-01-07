using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Database;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class MyOrdersForm : Form
    {
        private User _currentUser;
        private List<Order> _orders = new();
        private DataGridView _dgvOrders = null!;

        public MyOrdersForm()
        {
            this.Text = "My Orders";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Load += MyOrdersForm_Load;
            // Improve theming
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.ForeColor = Color.FromArgb(34, 34, 34);
            this.DoubleBuffered = true;
        }

        public MyOrdersForm(User currentUser) : this()
        {
            _currentUser = currentUser;
        }

        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeUI();
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUI()
        {
            // Filter Panel
            Panel pnlFilter = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(780, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Status Filter
            Label lblFilter = new Label
            {
                Text = "Filter by Status:",
                Location = new Point(15, 15),
                Size = new Size(110, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlFilter.Controls.Add(lblFilter);

            ComboBox cmbStatus = new ComboBox
            {
                Name = "cmbStatus",
                Location = new Point(130, 12),
                Size = new Size(180, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                FlatStyle = FlatStyle.Flat
            };
            cmbStatus.Items.Add("All Orders");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Processing");
            cmbStatus.Items.Add("Shipped");
            cmbStatus.Items.Add("Delivered");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            pnlFilter.Controls.Add(cmbStatus);

            // Refresh button
            IconButton btnRefresh = new IconButton
            {
                Text = "Refresh",
                Location = new Point(330, 10),
                Size = new Size(110, 32),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                IconChar = IconChar.Sync,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => LoadOrders();
            pnlFilter.Controls.Add(btnRefresh);

            this.Controls.Add(pnlFilter);

            // DataGridView for orders
            _dgvOrders = new DataGridView
            {
                Name = "dgvOrders",
                Location = new Point(10, 70),
                Size = new Size(780, 280),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
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
                RowTemplate = new DataGridViewRow { Height = 30 }
            };
            _dgvOrders.Columns.Add("OrderNumber", "Order #");
            _dgvOrders.Columns.Add("OrderDate", "Date");
            _dgvOrders.Columns.Add("Status", "Status");
            _dgvOrders.Columns.Add("TotalAmount", "Amount");
            this.Controls.Add(_dgvOrders);

            // Track Order button (previously 'View Details')
            IconButton btnViewDetails = new IconButton
            {
                Text = "Track Order",
                Location = new Point(180, 365),
                Size = new Size(130, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                IconChar = IconChar.MapMarkerAlt,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Click += BtnViewDetails_Click;
            this.Controls.Add(btnViewDetails);

            // Edit Order button (customers can edit pending orders)
            IconButton btnEdit = new IconButton
            {
                Text = "Edit Order",
                Location = new Point(320, 365),
                Size = new Size(130, 40),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                IconChar = IconChar.Edit,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += BtnEdit_Click;
            this.Controls.Add(btnEdit);

            // Delete Order button (customers can delete pending orders)
            IconButton btnDelete = new IconButton
            {
                Text = "Delete Order",
                Location = new Point(460, 365),
                Size = new Size(130, 40),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                IconChar = IconChar.TrashAlt,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(btnDelete);

            // Close button
            IconButton btnClose = new IconButton
            {
                Text = "Close",
                Location = new Point(600, 365),
                Size = new Size(110, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                IconChar = IconChar.Times,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

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
