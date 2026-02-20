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
            //
            // pnlToolbar
            //
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
            //
            // lblStatus
            //
            lblStatus.Location = new Point(10, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Filter by Status:";
            //
            // cmbStatus
            //
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(120, 10);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 28);
            cmbStatus.TabIndex = 1;
            cmbStatus.Items.Add("All Orders");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Processing");
            cmbStatus.Items.Add("Shipped");
            cmbStatus.Items.Add("Delivered");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            //
            // lblDate
            //
            lblDate.Location = new Point(10, 40);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "From Date:";
            //
            // dtFromDate
            //
            dtFromDate.Location = new Point(120, 40);
            dtFromDate.Name = "dtFromDate";
            dtFromDate.Size = new Size(150, 27);
            dtFromDate.TabIndex = 3;
            dtFromDate.Value = DateTime.Now.AddDays(-30);
            //
            // lblToDate
            //
            lblToDate.Location = new Point(280, 40);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(80, 20);
            lblToDate.TabIndex = 4;
            lblToDate.Text = "To Date:";
            //
            // dtToDate
            //
            dtToDate.Location = new Point(370, 40);
            dtToDate.Name = "dtToDate";
            dtToDate.Size = new Size(150, 27);
            dtToDate.TabIndex = 5;
            dtToDate.Value = DateTime.Now;
            //
            // btnFilter
            //
            btnFilter.BackColor = Color.LightBlue;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.IconChar = IconChar.Filter;
            btnFilter.IconColor = Color.Black;
            btnFilter.IconSize = 16;
            btnFilter.Location = new Point(530, 40);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(100, 25);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Filter";
            btnFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += BtnFilter_Click;
            //
            // btnRefresh
            //
            btnRefresh.BackColor = Color.LightBlue;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = IconChar.Sync;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconSize = 16;
            btnRefresh.Location = new Point(640, 40);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 25);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            //
            // _dgvOrders
            //
            _dgvOrders.AllowUserToAddRows = false;
            _dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvOrders.BackgroundColor = Color.White;
            _dgvOrders.Dock = DockStyle.Fill;
            _dgvOrders.Location = new Point(0, 70);
            _dgvOrders.Name = "dgvOrders";
            _dgvOrders.ReadOnly = true;
            _dgvOrders.RowHeadersVisible = false;
            _dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvOrders.Size = new Size(900, 350);
            _dgvOrders.TabIndex = 1;
            _dgvOrders.Columns.Add("OrderNumber", "Order #");
            _dgvOrders.Columns.Add("CustomerName", "Customer");
            _dgvOrders.Columns.Add("Status", "Status");
            _dgvOrders.Columns.Add("Amount", "Amount");
            _dgvOrders.Columns.Add("Date", "Date");
            _dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;
            //
            // pnlActions
            //
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(lblChangeStatus);
            pnlActions.Controls.Add(cmbNewStatus);
            pnlActions.Controls.Add(btnUpdate);
            pnlActions.Controls.Add(btnViewDetails);
            pnlActions.Controls.Add(btnEditOrder);
            pnlActions.Controls.Add(btnClose);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Height = 90;
            pnlActions.Location = new Point(0, 510);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(900, 90);
            pnlActions.TabIndex = 2;
            //
            // lblChangeStatus
            //
            lblChangeStatus.Location = new Point(10, 15);
            lblChangeStatus.Name = "lblChangeStatus";
            lblChangeStatus.Size = new Size(120, 20);
            lblChangeStatus.TabIndex = 0;
            lblChangeStatus.Text = "Change Status To:";
            //
            // cmbNewStatus
            //
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.Location = new Point(120, 15);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(150, 28);
            cmbNewStatus.TabIndex = 1;
            cmbNewStatus.Items.Add("Pending");
            cmbNewStatus.Items.Add("Processing");
            cmbNewStatus.Items.Add("Shipped");
            cmbNewStatus.Items.Add("Delivered");
            cmbNewStatus.Items.Add("Cancelled");
            cmbNewStatus.SelectedIndex = 0;
            //
            // btnUpdate
            //
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.IconChar = IconChar.Edit;
            btnUpdate.IconColor = Color.Black;
            btnUpdate.IconSize = 16;
            btnUpdate.Location = new Point(280, 15);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 25);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update Status";
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            //
            // btnViewDetails
            //
            btnViewDetails.BackColor = Color.LightBlue;
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.IconChar = IconChar.Eye;
            btnViewDetails.IconColor = Color.Black;
            btnViewDetails.IconSize = 16;
            btnViewDetails.Location = new Point(440, 15);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(120, 25);
            btnViewDetails.TabIndex = 3;
            btnViewDetails.Text = "View Details";
            btnViewDetails.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += BtnViewDetails_Click;
            //
            // btnEditOrder
            //
            btnEditOrder.BackColor = Color.LightGreen;
            btnEditOrder.Cursor = Cursors.Hand;
            btnEditOrder.IconChar = IconChar.Edit;
            btnEditOrder.IconColor = Color.Black;
            btnEditOrder.IconSize = 16;
            btnEditOrder.Location = new Point(440, 45);
            btnEditOrder.Name = "btnEditOrder";
            btnEditOrder.Size = new Size(120, 25);
            btnEditOrder.TabIndex = 4;
            btnEditOrder.Text = "Edit Order";
            btnEditOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditOrder.UseVisualStyleBackColor = false;
            btnEditOrder.Click += BtnEditOrder_Click;
            //
            // btnClose
            //
            btnClose.BackColor = Color.LightGray;
            btnClose.Cursor = Cursors.Hand;
            btnClose.IconChar = IconChar.Times;
            btnClose.IconColor = Color.Black;
            btnClose.IconSize = 16;
            btnClose.Location = new Point(570, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 25);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            //
            // ManageOrdersForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
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
