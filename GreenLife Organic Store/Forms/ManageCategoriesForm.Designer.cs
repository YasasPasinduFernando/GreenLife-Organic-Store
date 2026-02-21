using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class ManageCategoriesForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlToolbar;
        private IconButton btnAdd;
        private IconButton btnRefresh;
        private DataGridView _dgvCategories;
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
            btnRefresh = new IconButton();
            _dgvCategories = new DataGridView();
            pnlActions = new Panel();
            btnEdit = new IconButton();
            btnDelete = new IconButton();
            btnClose = new IconButton();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvCategories).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // pnlToolbar
            pnlToolbar.BackColor = Color.LightGray;
            pnlToolbar.Controls.Add(btnAdd);
            pnlToolbar.Controls.Add(btnRefresh);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(700, 50);
            pnlToolbar.TabIndex = 0;
            // btnAdd
            btnAdd.BackColor = Color.Green;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.ForeColor = Color.White;
            btnAdd.IconChar = IconChar.Plus;
            btnAdd.IconColor = Color.White;
            btnAdd.IconSize = 20;
            btnAdd.Location = new Point(10, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 36);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Category";
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // btnRefresh
            btnRefresh.BackColor = Color.LightBlue;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = IconChar.Sync;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconSize = 20;
            btnRefresh.Location = new Point(170, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 36);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // _dgvCategories
            _dgvCategories.AllowUserToAddRows = false;
            _dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvCategories.BackColor = Color.White;
            _dgvCategories.Dock = DockStyle.Fill;
            _dgvCategories.ColumnHeadersHeight = 38;
            _dgvCategories.Location = new Point(0, 50);
            _dgvCategories.Name = "dgvCategories";
            _dgvCategories.ReadOnly = true;
            _dgvCategories.RowTemplate.Height = 38;
            _dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvCategories.Size = new Size(700, 300);
            _dgvCategories.TabIndex = 1;
            var imgCol = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60
            };
            _dgvCategories.Columns.Add(imgCol);
            _dgvCategories.Columns.Add("ID", "ID");
            _dgvCategories.Columns.Add("CategoryName", "Category Name");
            _dgvCategories.Columns.Add("Description", "Description");
            _dgvCategories.Columns.Add("Status", "Status");
            // pnlActions
            pnlActions.BackColor = Color.WhiteSmoke;
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnClose);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 450);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(700, 50);
            pnlActions.TabIndex = 2;
            // btnEdit
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.IconChar = IconChar.Edit;
            btnEdit.IconColor = Color.Black;
            btnEdit.IconSize = 20;
            btnEdit.Location = new Point(10, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 36);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // btnDelete
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.IconChar = IconChar.TrashAlt;
            btnDelete.IconColor = Color.Black;
            btnDelete.IconSize = 20;
            btnDelete.Location = new Point(120, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 36);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // btnClose
            btnClose.BackColor = Color.LightGray;
            btnClose.Cursor = Cursors.Hand;
            btnClose.IconChar = IconChar.Times;
            btnClose.IconColor = Color.Black;
            btnClose.IconSize = 20;
            btnClose.Location = new Point(230, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // ManageCategoriesForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 500);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlActions);
            Controls.Add(_dgvCategories);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ManageCategoriesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Categories";
            pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvCategories).EndInit();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
