using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class ManageProductsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlToolbar;
        private IconButton btnAdd;
        private TextBox txtSearch;
        private IconButton btnSearch;
        private IconButton btnRefresh;
        private DataGridView _dgvProducts;
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
            pnlToolbar = new Panel();
            btnAdd = new IconButton();
            txtSearch = new TextBox();
            btnSearch = new IconButton();
            btnRefresh = new IconButton();
            _dgvProducts = new DataGridView();
            pnlActions = new Panel();
            btnEdit = new IconButton();
            btnDelete = new IconButton();
            btnClose = new IconButton();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvProducts).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // pnlToolbar
            pnlToolbar.BackColor = Color.LightGray;
            pnlToolbar.Controls.Add(btnAdd);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(btnSearch);
            pnlToolbar.Controls.Add(btnRefresh);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(900, 56);
            pnlToolbar.TabIndex = 0;
            // btnAdd
            btnAdd.BackColor = Color.Green;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.ForeColor = Color.White;
            btnAdd.IconChar = IconChar.Plus;
            btnAdd.IconColor = Color.White;
            btnAdd.Font = new Font("Segoe UI", 9F);
            btnAdd.IconSize = 18;
            btnAdd.Location = new Point(10, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 36);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add New Product";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // txtSearch
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(180, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Search...";
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            // btnSearch
            btnSearch.BackColor = Color.LightBlue;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.IconChar = IconChar.Search;
            btnSearch.Font = new Font("Segoe UI", 9F);
            btnSearch.IconColor = Color.Black;
            btnSearch.IconSize = 18;
            btnSearch.Location = new Point(450, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 36);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // btnRefresh
            btnRefresh.BackColor = Color.LightBlue;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = IconChar.Sync;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconSize = 18;
            btnRefresh.Location = new Point(560, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 36);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // _dgvProducts
            _dgvProducts.AllowUserToAddRows = false;
            _dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvProducts.BackColor = Color.White;
            _dgvProducts.Dock = DockStyle.Top;
            _dgvProducts.ColumnHeadersHeight = 38;
            _dgvProducts.Location = new Point(0, 56);
            _dgvProducts.Name = "dgvProducts";
            _dgvProducts.ReadOnly = true;
            _dgvProducts.RowTemplate.Height = 38;
            _dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvProducts.Size = new Size(900, 394);
            _dgvProducts.TabIndex = 1;
            var imgCol = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60
            };
            _dgvProducts.Columns.Add(imgCol);
            _dgvProducts.Columns.Add("ID", "ID");
            _dgvProducts.Columns.Add("ProductName", "Product Name");
            _dgvProducts.Columns.Add("Category", "Category");
            _dgvProducts.Columns.Add("Price", "Price");
            _dgvProducts.Columns.Add("DiscountPercent", "Discount %");
            _dgvProducts.Columns.Add("Stock", "Stock");
            _dgvProducts.Columns.Add("Status", "Status");
            _dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;
            // pnlActions
            pnlActions.BackColor = Color.WhiteSmoke;
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnClose);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 450);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(900, 56);
            pnlActions.TabIndex = 2;
            // btnEdit
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.IconChar = IconChar.Edit;
            btnEdit.Font = new Font("Segoe UI", 9F);
            btnEdit.IconColor = Color.Black;
            btnEdit.IconSize = 18;
            btnEdit.Location = new Point(10, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(135, 36);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit Product";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // btnDelete
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.IconChar = IconChar.TrashAlt;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.IconColor = Color.Black;
            btnDelete.IconSize = 18;
            btnDelete.Location = new Point(155, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 36);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete Product";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // btnClose
            btnClose.BackColor = Color.LightGray;
            btnClose.Cursor = Cursors.Hand;
            btnClose.IconChar = IconChar.Times;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.IconColor = Color.Black;
            btnClose.IconSize = 18;
            btnClose.Location = new Point(300, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // ManageProductsForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pnlActions);
            Controls.Add(_dgvProducts);
            Controls.Add(pnlToolbar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ManageProductsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Products";
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvProducts).EndInit();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
