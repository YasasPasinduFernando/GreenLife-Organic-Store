using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ManageOrdersForm : Form
    {
        private List<Order> _allOrders = new();

        public ManageOrdersForm()
        {
            this.Text = "Manage Orders";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void ManageOrdersForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadOrders();
        }

        private void InitializeUI()
        {
            // Toolbar
            Panel pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.LightGray
            };

            Label lblStatus = new Label { Text = "Filter by Status:", Location = new Point(10, 10), Size = new Size(100, 20) };
            ComboBox cmbStatus = new ComboBox
            {
                Name = "cmbStatus",
                Location = new Point(120, 10),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.Add("All Orders");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Processing");
            cmbStatus.Items.Add("Shipped");
            cmbStatus.Items.Add("Delivered");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += (s, e) => FilterByStatus();
            pnlToolbar.Controls.Add(lblStatus);
            pnlToolbar.Controls.Add(cmbStatus);

            Label lblDate = new Label { Text = "From Date:", Location = new Point(10, 40), Size = new Size(100, 20) };
            DateTimePicker dtFromDate = new DateTimePicker
            {
                Name = "dtFromDate",
                Location = new Point(120, 40),
                Size = new Size(150, 25),
                Value = DateTime.Now.AddDays(-30)
            };
            pnlToolbar.Controls.Add(lblDate);
            pnlToolbar.Controls.Add(dtFromDate);

            Label lblToDate = new Label { Text = "To Date:", Location = new Point(280, 40), Size = new Size(80, 20) };
            DateTimePicker dtToDate = new DateTimePicker
            {
                Name = "dtToDate",
                Location = new Point(370, 40),
                Size = new Size(150, 25),
                Value = DateTime.Now
            };
            pnlToolbar.Controls.Add(lblToDate);
            pnlToolbar.Controls.Add(dtToDate);

            Button btnFilter = new Button
            {
                Text = "Filter",
                Location = new Point(530, 40),
                Size = new Size(100, 25),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnFilter.Click += (s, e) => FilterByDateRange();
            pnlToolbar.Controls.Add(btnFilter);

            Button btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(640, 40),
                Size = new Size(100, 25),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnRefresh.Click += (s, e) => LoadOrders();
            pnlToolbar.Controls.Add(btnRefresh);

            this.Controls.Add(pnlToolbar);

            // DataGridView
            DataGridView dgvOrders = new DataGridView
            {
                Name = "dgvOrders",
                Dock = DockStyle.Top,
                Height = 300,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White
            };
            dgvOrders.Columns.Add("OrderNumber", "Order #");
            dgvOrders.Columns.Add("CustomerName", "Customer");
            dgvOrders.Columns.Add("Status", "Status");
            dgvOrders.Columns.Add("Amount", "Amount");
            dgvOrders.Columns.Add("Date", "Date");
            dgvOrders.RowHeadersVisible = false;
            this.Controls.Add(dgvOrders);

            // Action Panel
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            Label lblChangeStatus = new Label { Text = "Change Status To:", Location = new Point(10, 15), Size = new Size(100, 20) };
            ComboBox cmbNewStatus = new ComboBox
            {
                Name = "cmbNewStatus",
                Location = new Point(120, 15),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbNewStatus.Items.Add("Pending");
            cmbNewStatus.Items.Add("Processing");
            cmbNewStatus.Items.Add("Shipped");
            cmbNewStatus.Items.Add("Delivered");
            cmbNewStatus.Items.Add("Cancelled");
            cmbNewStatus.SelectedIndex = 0;
            pnlActions.Controls.Add(lblChangeStatus);
            pnlActions.Controls.Add(cmbNewStatus);

            Button btnUpdate = new Button
            {
                Text = "Update Status",
                Location = new Point(280, 15),
                Size = new Size(150, 25),
                BackColor = Color.Orange,
                Cursor = Cursors.Hand
            };
            btnUpdate.Click += (s, e) => UpdateOrderStatus();
            pnlActions.Controls.Add(btnUpdate);

            Button btnViewDetails = new Button
            {
                Text = "View Details",
                Location = new Point(440, 15),
                Size = new Size(120, 25),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnViewDetails.Click += (s, e) => ViewOrderDetails();
            pnlActions.Controls.Add(btnViewDetails);

            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(570, 15),
                Size = new Size(100, 25),
                BackColor = Color.LightGray,
                Cursor = Cursors.Hand
            };
            btnClose.Click += (s, e) => this.Close();
            pnlActions.Controls.Add(btnClose);

            this.Controls.Add(pnlActions);
        }

        private void LoadOrders()
        {
            try
            {
                _allOrders = OrderRepository.GetAllOrders();
                DataGridView dgvOrders = (DataGridView)this.Controls[1];
                dgvOrders.Rows.Clear();

                foreach (var order in _allOrders)
                {
                    dgvOrders.Rows.Add(
                        order.OrderNumber,
                        order.CustomerName,
                        order.GetStatusText(),
                        order.GetFormattedTotal(),
                        order.OrderDate.ToString("dd/MM/yyyy HH:mm")
                    );

                    // Color code by status
                    int lastRowIndex = dgvOrders.Rows.Count - 1;
                    switch (order.Status)
                    {
                        case OrderStatus.Pending:
                            dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case OrderStatus.Processing:
                            dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case OrderStatus.Shipped:
                            dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
                            break;
                        case OrderStatus.Delivered:
                            dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
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
            ComboBox cmbStatus = (ComboBox)this.Controls[0].Controls["cmbStatus"];
            DataGridView dgvOrders = (DataGridView)this.Controls[1];
            dgvOrders.Rows.Clear();

            string selectedStatus = cmbStatus.SelectedItem.ToString();
            List<Order> filtered;

            if (selectedStatus == "All Orders")
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
                dgvOrders.Rows.Add(
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
            Panel pnlToolbar = this.Controls[0] as Panel;
            DateTimePicker dtFromDate = (DateTimePicker)pnlToolbar.Controls["dtFromDate"];
            DateTimePicker dtToDate = (DateTimePicker)pnlToolbar.Controls["dtToDate"];

            var filtered = OrderRepository.GetOrdersByDateRange(dtFromDate.Value, dtToDate.Value);
            DataGridView dgvOrders = (DataGridView)this.Controls[1];
            dgvOrders.Rows.Clear();

            foreach (var order in filtered)
            {
                dgvOrders.Rows.Add(
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
            DataGridView dgvOrders = (DataGridView)this.Controls[1];
            ComboBox cmbNewStatus = (ComboBox)this.Controls[2].Controls["cmbNewStatus"];

            if (dgvOrders.SelectedRows.Count > 0)
            {
                string orderNumber = dgvOrders.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
                var order = _allOrders.FirstOrDefault(o => o.OrderNumber == orderNumber);

                if (order != null)
                {
                    try
                    {
                        var newStatus = Enum.Parse<OrderStatus>(cmbNewStatus.SelectedItem.ToString());
                        if (OrderRepository.UpdateOrderStatus(order.ID, newStatus))
                        {
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
            DataGridView dgvOrders = (DataGridView)this.Controls[1];
            if (dgvOrders.SelectedRows.Count > 0)
            {
                string orderNumber = dgvOrders.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
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
