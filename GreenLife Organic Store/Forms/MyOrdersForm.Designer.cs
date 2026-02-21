using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class MyOrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlFilter;
        private Label lblFilter;
        private ComboBox cmbStatus;
        private IconButton btnRefresh;
        private DataGridView _dgvOrders;
        private IconButton btnViewDetails;
        private IconButton btnEdit;
        private IconButton btnDelete;
        private IconButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlFilter = new Panel();
            lblFilter = new Label();
            cmbStatus = new ComboBox();
            btnRefresh = new IconButton();
            _dgvOrders = new DataGridView();
            btnViewDetails = new IconButton();
            btnEdit = new IconButton();
            btnDelete = new IconButton();
            btnClose = new IconButton();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvOrders).BeginInit();
            SuspendLayout();
            // pnlFilter
            pnlFilter.BackColor = Color.White;
            pnlFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(lblFilter);
            pnlFilter.Controls.Add(cmbStatus);
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Location = new Point(10, 10);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(820, 54);
            pnlFilter.TabIndex = 0;
            // lblFilter
            lblFilter.Font = new Font("Segoe UI", 9F);
            lblFilter.ForeColor = Color.FromArgb(52, 73, 94);
            lblFilter.Location = new Point(15, 16);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(110, 25);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Filter by Status:";
            lblFilter.TextAlign = ContentAlignment.MiddleLeft;
            // cmbStatus
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.Location = new Point(130, 10);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(185, 28);
            cmbStatus.TabIndex = 1;
            cmbStatus.Items.Add("All Orders");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Processing");
            cmbStatus.Items.Add("Shipped");
            cmbStatus.Items.Add("Delivered");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            // btnRefresh
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.IconChar = IconChar.Sync;
            btnRefresh.IconColor = Color.White;
            btnRefresh.IconSize = 18;
            btnRefresh.Location = new Point(350, 8);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 36);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // _dgvOrders
            _dgvOrders.AllowUserToAddRows = false;
            _dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvOrders.BackgroundColor = Color.White;
            _dgvOrders.BorderStyle = BorderStyle.FixedSingle;
            _dgvOrders.ColumnHeadersHeight = 38;
            _dgvOrders.EnableHeadersVisualStyles = false;
            _dgvOrders.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Padding = new Padding(5)
            };
            _dgvOrders.Location = new Point(10, 72);
            _dgvOrders.Name = "dgvOrders";
            _dgvOrders.ReadOnly = true;
            _dgvOrders.RowHeadersVisible = false;
            _dgvOrders.RowTemplate.Height = 32;
            _dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvOrders.Size = new Size(820, 190);
            _dgvOrders.TabIndex = 1;
            _dgvOrders.Columns.Add("OrderNumber", "Order #");
            _dgvOrders.Columns.Add("OrderDate", "Date");
            _dgvOrders.Columns.Add("Status", "Status");
            _dgvOrders.Columns.Add("TotalAmount", "Amount");
            _dgvOrders.Columns["TotalAmount"].MinimumWidth = 105;
            // btnViewDetails
            btnViewDetails.BackColor = Color.FromArgb(46, 204, 113);
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Font = new Font("Segoe UI", 9F);
            btnViewDetails.ForeColor = Color.White;
            btnViewDetails.IconChar = IconChar.MapMarkerAlt;
            btnViewDetails.IconColor = Color.White;
            btnViewDetails.IconSize = 16;
            btnViewDetails.Location = new Point(20, 362);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(120, 36);
            btnViewDetails.TabIndex = 2;
            btnViewDetails.Text = "Track";
            btnViewDetails.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += BtnViewDetails_Click;
            // btnEdit
            btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 9F);
            btnEdit.ForeColor = Color.White;
            btnEdit.IconChar = IconChar.Edit;
            btnEdit.IconColor = Color.White;
            btnEdit.IconSize = 16;
            btnEdit.Location = new Point(152, 362);
            btnEdit.Name = "btnEdit";
            btnEdit.Padding = new Padding(6, 0, 8, 0);
            btnEdit.Size = new Size(132, 36);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit Order";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // btnDelete
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.ForeColor = Color.White;
            btnDelete.IconChar = IconChar.TrashAlt;
            btnDelete.IconColor = Color.White;
            btnDelete.IconSize = 16;
            btnDelete.Location = new Point(294, 362);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // btnClose
            btnClose.BackColor = Color.FromArgb(149, 165, 166);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.IconChar = IconChar.Times;
            btnClose.IconColor = Color.White;
            btnClose.IconSize = 16;
            btnClose.Location = new Point(426, 362);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 36);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // MyOrdersForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(840, 320);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Controls.Add(pnlFilter);
            Controls.Add(_dgvOrders);
            Controls.Add(btnViewDetails);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnClose);
            ForeColor = Color.FromArgb(51, 51, 51);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MyOrdersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "My Orders";
            pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvOrders).EndInit();
            ResumeLayout(false);
        }
    }
}
