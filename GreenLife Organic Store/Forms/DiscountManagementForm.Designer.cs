using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class DiscountManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlToolbar;
        private IconButton btnAdd;
        private IconButton btnRefresh;
        private DataGridView _dgvDiscounts;
        private Panel pnlActions;
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
            pnlHeader = new Panel();
            lblHeader = new Label();
            pnlToolbar = new Panel();
            btnAdd = new IconButton();
            btnRefresh = new IconButton();
            _dgvDiscounts = new DataGridView();
            pnlActions = new Panel();
            btnEdit = new IconButton();
            btnDelete = new IconButton();
            btnClose = new IconButton();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvDiscounts).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(46, 204, 113);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15, 12, 15, 12);
            pnlHeader.Size = new Size(1000, 56);
            pnlHeader.TabIndex = 0;
            // lblHeader
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(15, 14);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(300, 30);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Discount Management";
            // pnlToolbar
            pnlToolbar.BackColor = Color.WhiteSmoke;
            pnlToolbar.Controls.Add(btnAdd);
            pnlToolbar.Controls.Add(btnRefresh);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 56);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(10);
            pnlToolbar.Size = new Size(1000, 50);
            pnlToolbar.TabIndex = 1;
            // btnAdd
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI", 9F);
            btnAdd.ForeColor = Color.White;
            btnAdd.IconChar = IconChar.Plus;
            btnAdd.IconColor = Color.White;
            btnAdd.IconSize = 16;
            btnAdd.Location = new Point(10, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 36);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add New Discount";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // btnRefresh
            btnRefresh.BackColor = Color.FromArgb(46, 204, 113);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.IconChar = IconChar.Sync;
            btnRefresh.IconColor = Color.White;
            btnRefresh.IconSize = 16;
            btnRefresh.Location = new Point(185, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 36);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // _dgvDiscounts
            _dgvDiscounts.AllowUserToAddRows = false;
            _dgvDiscounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvDiscounts.BackColor = Color.White;
            _dgvDiscounts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Padding = new Padding(5)
            };
            _dgvDiscounts.ColumnHeadersHeight = 38;
            _dgvDiscounts.Dock = DockStyle.Fill;
            _dgvDiscounts.EnableHeadersVisualStyles = false;
            _dgvDiscounts.Location = new Point(0, 106);
            _dgvDiscounts.Name = "dgvDiscounts";
            _dgvDiscounts.ReadOnly = true;
            _dgvDiscounts.RowTemplate = new DataGridViewRow { Height = 38 };
            _dgvDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvDiscounts.Size = new Size(1000, 394);
            _dgvDiscounts.TabIndex = 2;
            _dgvDiscounts.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(250, 250, 250) };
            var imgCol = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60
            };
            _dgvDiscounts.Columns.Add(imgCol);
            _dgvDiscounts.Columns.Add("ID", "ID");
            _dgvDiscounts.Columns.Add("DiscountName", "Discount Name");
            _dgvDiscounts.Columns.Add("ProductName", "Product");
            _dgvDiscounts.Columns.Add("Percent", "Discount %");
            _dgvDiscounts.Columns.Add("StartDate", "Start Date");
            _dgvDiscounts.Columns.Add("EndDate", "End Date");
            _dgvDiscounts.Columns.Add("Status", "Status");
            _dgvDiscounts.CellDoubleClick += DgvDiscounts_CellDoubleClick;
            // pnlActions
            pnlActions.BackColor = Color.WhiteSmoke;
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnClose);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 600);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(1000, 50);
            pnlActions.TabIndex = 3;
            // btnEdit
            btnEdit.BackColor = Color.FromArgb(46, 204, 113);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 9F);
            btnEdit.ForeColor = Color.White;
            btnEdit.IconChar = IconChar.Edit;
            btnEdit.IconColor = Color.White;
            btnEdit.IconSize = 18;
            btnEdit.Location = new Point(10, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(140, 36);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit Discount";
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
            btnDelete.Location = new Point(165, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 36);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete Discount";
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
            btnClose.Location = new Point(320, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // DiscountManagementForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Controls.Add(pnlActions);
            Controls.Add(_dgvDiscounts);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DiscountManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Discounts";
            pnlHeader.ResumeLayout(false);
            pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvDiscounts).EndInit();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
