using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store.Forms
{
    public partial class MyOrdersForm : Form
    {
        private User _currentUser;
        private List<Order> _orders = new();

        public MyOrdersForm()
        {
            this.Text = "My Orders";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public MyOrdersForm(User currentUser) : this()
        {
            _currentUser = currentUser;
        }

        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadOrders();
        }

        private void InitializeUI()
        {
            // Status Filter
            Label lblFilter = new Label
            {
                Text = "Filter by Status:",
                Location = new Point(10, 10),
                Size = new Size(100, 20)
            };
            this.Controls.Add(lblFilter);

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
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            this.Controls.Add(cmbStatus);

            // Refresh button
            Button btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(290, 10),
                Size = new Size(100, 25),
                BackColor = Color.LightBlue
            };
            btnRefresh.Click += (s, e) => LoadOrders();
            this.Controls.Add(btnRefresh);

            // DataGridView for orders
            DataGridView dgvOrders = new DataGridView
            {
                Name = "dgvOrders",
                Location = new Point(10, 50),
                Size = new Size(780, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White
            };

            dgvOrders.Columns.Add("OrderNumber", "Order #");
            dgvOrders.Columns.Add("OrderDate", "Date");
            dgvOrders.Columns.Add("Status", "Status");
            dgvOrders.Columns.Add("TotalAmount", "Amount");
            this.Controls.Add(dgvOrders);

            // View Details button
            Button btnViewDetails = new Button
            {
                Text = "View Details",
                Location = new Point(200, 370),
                Size = new Size(120, 35),
                BackColor = Color.LightGreen
            };
            btnViewDetails.Click += BtnViewDetails_Click;
            this.Controls.Add(btnViewDetails);

            // Track Order button
            Button btnTrack = new Button
            {
                Text = "Track Order",
                Location = new Point(340, 370),
                Size = new Size(120, 35),
                BackColor = Color.LightBlue
            };
            btnTrack.Click += BtnTrack_Click;
            this.Controls.Add(btnTrack);

            // Close button
            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(480, 370),
                Size = new Size(120, 35),
                BackColor = Color.LightGray
            };
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadOrders()
        {
            try
            {
                _orders = OrderRepository.GetOrdersByCustomerId(_currentUser.ID);

                DataGridView dgvOrders = (DataGridView)this.Controls["dgvOrders"];
                dgvOrders.Rows.Clear();

                foreach (var order in _orders)
                {
                    dgvOrders.Rows.Add(
                        order.OrderNumber,
                        order.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                        order.GetStatusText(),
                        order.GetFormattedTotal()
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
                        case OrderStatus.Cancelled:
                            dgvOrders.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
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
            DataGridView dgvOrders = (DataGridView)this.Controls["dgvOrders"];
            ComboBox cmbStatus = (ComboBox)this.Controls["cmbStatus"];
            dgvOrders.Rows.Clear();

            string selectedStatus = cmbStatus.SelectedItem.ToString();

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
                dgvOrders.Rows.Add(
                    order.OrderNumber,
                    order.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                    order.GetStatusText(),
                    order.GetFormattedTotal()
                );
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            DataGridView dgvOrders = (DataGridView)this.Controls["dgvOrders"];
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int rowIndex = dgvOrders.SelectedRows[0].Index;
                string orderNumber = dgvOrders.Rows[rowIndex].Cells["OrderNumber"].Value.ToString();

                var selectedOrder = _orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
                if (selectedOrder != null)
                {
                    OrderDetailsForm detailsForm = new OrderDetailsForm(selectedOrder);
                    detailsForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select an order to view details.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnTrack_Click(object sender, EventArgs e)
        {
            BtnViewDetails_Click(sender, e);
        }
    }
}
