using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class ManageOrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlToolbar;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblDate;
        private DateTimePicker dtFromDate;
        private Label lblToDate;
        private DateTimePicker dtToDate;
        private IconButton btnFilter;
        private IconButton btnRefresh;
        private DataGridView _dgvOrders;
        private Panel pnlActions;
        private Label lblChangeStatus;
        private ComboBox cmbNewStatus;
        private IconButton btnUpdate;
        private IconButton btnViewDetails;
        private IconButton btnEditOrder;
        private IconButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlToolbar = new Panel();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblDate = new Label();
            dtFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtToDate = new DateTimePicker();
            btnFilter = new IconButton();
            btnRefresh = new IconButton();
            _dgvOrders = new DataGridView();
            pnlActions = new Panel();
            lblChangeStatus = new Label();
            cmbNewStatus = new ComboBox();
            btnUpdate = new IconButton();
            btnViewDetails = new IconButton();
            btnEditOrder = new IconButton();
            btnClose = new IconButton();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvOrders).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // pnlToolbar
            pnlToolbar.BackColor = Color.LightGray;
            pnlToolbar.Controls.Add(lblStatus);
            pnlToolbar.Controls.Add(cmbStatus);
            pnlToolbar.Controls.Add(lblDate);
            pnlToolbar.Controls.Add(dtFromDate);
            pnlToolbar.Controls.Add(lblToDate);
            pnlToolbar.Controls.Add(dtToDate);
            pnlToolbar.Controls.Add(btnFilter);
            pnlToolbar.Controls.Add(btnRefresh);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(900, 70);
            pnlToolbar.TabIndex = 0;
            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(10, 14);
            lblStatus.Name = "lblStatus";
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Filter by Status:";
            // cmbStatus
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.Location = new Point(120, 10);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(165, 28);
            cmbStatus.TabIndex = 1;
            cmbStatus.Items.Add("All Orders");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Processing");
            cmbStatus.Items.Add("Shipped");
            cmbStatus.Items.Add("Delivered");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            // lblDate
            lblDate.Font = new Font("Segoe UI", 9F);
            lblDate.Location = new Point(10, 42);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "From Date:";
            // dtFromDate
            dtFromDate.Font = new Font("Segoe UI", 9F);
            dtFromDate.Format = DateTimePickerFormat.Short;
            dtFromDate.Location = new Point(120, 40);
            dtFromDate.Name = "dtFromDate";
            dtFromDate.Size = new Size(140, 27);
            dtFromDate.TabIndex = 3;
            dtFromDate.Value = DateTime.Now.AddDays(-30);
            // lblToDate
            lblToDate.Font = new Font("Segoe UI", 9F);
            lblToDate.Location = new Point(268, 42);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(60, 20);
            lblToDate.TabIndex = 4;
            lblToDate.Text = "To Date:";
            // dtToDate
            dtToDate.Font = new Font("Segoe UI", 9F);
            dtToDate.Format = DateTimePickerFormat.Short;
            dtToDate.Location = new Point(330, 40);
            dtToDate.Name = "dtToDate";
            dtToDate.Size = new Size(140, 27);
            dtToDate.TabIndex = 5;
            dtToDate.Value = DateTime.Now;
            // btnFilter
            btnFilter.BackColor = Color.LightBlue;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.IconChar = IconChar.Filter;
            btnFilter.IconColor = Color.Black;
            btnFilter.IconSize = 16;
            btnFilter.Location = new Point(480, 38);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(100, 36);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Filter";
            btnFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += BtnFilter_Click;
            // btnRefresh
            btnRefresh.BackColor = Color.LightBlue;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = IconChar.Sync;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconSize = 16;
            btnRefresh.Location = new Point(590, 38);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 36);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // _dgvOrders
            _dgvOrders.AllowUserToAddRows = false;
            _dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvOrders.BackgroundColor = Color.White;
            _dgvOrders.Dock = DockStyle.Fill;
            _dgvOrders.Location = new Point(0, 70);
            _dgvOrders.Name = "dgvOrders";
            _dgvOrders.ColumnHeadersHeight = 38;
            _dgvOrders.ReadOnly = true;
            _dgvOrders.RowHeadersVisible = false;
            _dgvOrders.RowTemplate.Height = 38;
            _dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvOrders.Size = new Size(900, 350);
            _dgvOrders.TabIndex = 1;
            _dgvOrders.Columns.Add("OrderNumber", "Order #");
            _dgvOrders.Columns.Add("CustomerName", "Customer");
            _dgvOrders.Columns.Add("Status", "Status");
            _dgvOrders.Columns.Add("Amount", "Amount");
            _dgvOrders.Columns.Add("Date", "Date");
            _dgvOrders.Columns["Date"].MinimumWidth = 115;
            _dgvOrders.Columns["Amount"].MinimumWidth = 95;
            _dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;
            // pnlActions
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(lblChangeStatus);
            pnlActions.Controls.Add(cmbNewStatus);
            pnlActions.Controls.Add(btnUpdate);
            pnlActions.Controls.Add(btnViewDetails);
            pnlActions.Controls.Add(btnEditOrder);
            pnlActions.Controls.Add(btnClose);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Height = 62;
            pnlActions.Location = new Point(0, 538);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10, 8, 10, 8);
            pnlActions.Size = new Size(900, 62);
            pnlActions.TabIndex = 2;
            // lblChangeStatus
            lblChangeStatus.Font = new Font("Segoe UI", 9F);
            lblChangeStatus.Location = new Point(10, 14);
            lblChangeStatus.Name = "lblChangeStatus";
            lblChangeStatus.Size = new Size(115, 20);
            lblChangeStatus.TabIndex = 0;
            lblChangeStatus.Text = "Change Status To:";
            // cmbNewStatus
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.Font = new Font("Segoe UI", 9F);
            cmbNewStatus.Location = new Point(130, 11);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(165, 28);
            cmbNewStatus.TabIndex = 1;
            cmbNewStatus.Items.Add("Pending");
            cmbNewStatus.Items.Add("Processing");
            cmbNewStatus.Items.Add("Shipped");
            cmbNewStatus.Items.Add("Delivered");
            cmbNewStatus.Items.Add("Cancelled");
            cmbNewStatus.SelectedIndex = 0;
            // btnUpdate
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.IconChar = IconChar.Edit;
            btnUpdate.IconColor = Color.Black;
            btnUpdate.IconFont = IconFont.Solid;
            btnUpdate.IconSize = 16;
            btnUpdate.Location = new Point(310, 11);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Padding = new Padding(6, 2, 6, 2);
            btnUpdate.Size = new Size(150, 38);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update Status";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // btnViewDetails
            btnViewDetails.BackColor = Color.LightBlue;
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.Font = new Font("Segoe UI", 9F);
            btnViewDetails.IconChar = IconChar.Eye;
            btnViewDetails.IconColor = Color.Black;
            btnViewDetails.IconFont = IconFont.Solid;
            btnViewDetails.IconSize = 16;
            btnViewDetails.Location = new Point(468, 11);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Padding = new Padding(6, 2, 6, 2);
            btnViewDetails.Size = new Size(140, 38);
            btnViewDetails.TabIndex = 3;
            btnViewDetails.Text = "View Details";
            btnViewDetails.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += BtnViewDetails_Click;
            // btnEditOrder
            btnEditOrder.BackColor = Color.LightGreen;
            btnEditOrder.Cursor = Cursors.Hand;
            btnEditOrder.Font = new Font("Segoe UI", 9F);
            btnEditOrder.IconChar = IconChar.Edit;
            btnEditOrder.IconColor = Color.Black;
            btnEditOrder.IconSize = 16;
            btnEditOrder.Location = new Point(616, 11);
            btnEditOrder.Name = "btnEditOrder";
            btnEditOrder.Padding = new Padding(6, 2, 6, 2);
            btnEditOrder.Size = new Size(130, 38);
            btnEditOrder.TabIndex = 4;
            btnEditOrder.Text = "Edit Order";
            btnEditOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditOrder.UseVisualStyleBackColor = false;
            btnEditOrder.Click += BtnEditOrder_Click;
            // btnClose
            btnClose.BackColor = Color.LightGray;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.IconChar = IconChar.Times;
            btnClose.IconColor = Color.Black;
            btnClose.IconSize = 16;
            btnClose.Location = new Point(754, 11);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(6, 2, 6, 2);
            btnClose.Size = new Size(100, 38);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // ManageOrdersForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pnlActions);
            Controls.Add(_dgvOrders);
            Controls.Add(pnlToolbar);
            Name = "ManageOrdersForm";
            Text = "Manage Orders";
            pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvOrders).EndInit();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
