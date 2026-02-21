using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class ManageCustomersForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlToolbar;
        private TextBox txtSearch;
        private IconButton btnSearch;
        private IconButton btnRefresh;
        private IconButton btnExport;
        private DataGridView _dgvCustomers;
        private Panel pnlActions;
        private IconButton btnViewDetails;
        private IconButton _btnEditCustomer;
        private IconButton _btnChangePassword;
        private IconButton btnDeleteAccount;
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
            txtSearch = new TextBox();
            btnSearch = new IconButton();
            btnRefresh = new IconButton();
            btnExport = new IconButton();
            _dgvCustomers = new DataGridView();
            pnlActions = new Panel();
            btnViewDetails = new IconButton();
            btnDeleteAccount = new IconButton();
            btnClose = new IconButton();
            _btnEditCustomer = new IconButton();
            _btnChangePassword = new IconButton();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvCustomers).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // pnlToolbar
            pnlToolbar.BackColor = Color.LightGray;
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(btnSearch);
            pnlToolbar.Controls.Add(btnRefresh);
            pnlToolbar.Controls.Add(btnExport);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(900, 50);
            pnlToolbar.TabIndex = 0;
            // txtSearch
            txtSearch.Location = new Point(10, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search...";
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            // btnSearch
            btnSearch.BackColor = Color.LightBlue;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.IconChar = IconChar.Search;
            btnSearch.IconColor = Color.Black;
            btnSearch.IconSize = 20;
            btnSearch.Location = new Point(220, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 36);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // btnRefresh
            btnRefresh.BackColor = Color.LightBlue;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.IconChar = IconChar.Sync;
            btnRefresh.IconColor = Color.Black;
            btnRefresh.IconSize = 20;
            btnRefresh.Location = new Point(330, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 36);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // btnExport
            btnExport.BackColor = Color.LightGreen;
            btnExport.Cursor = Cursors.Hand;
            btnExport.IconChar = IconChar.Download;
            btnExport.IconColor = Color.Black;
            btnExport.IconSize = 20;
            btnExport.Location = new Point(440, 10);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(160, 36);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export CSV";
            btnExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // _dgvCustomers
            _dgvCustomers.AllowUserToAddRows = false;
            _dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvCustomers.BackColor = Color.White;
            _dgvCustomers.Dock = DockStyle.Top;
            _dgvCustomers.ColumnHeadersHeight = 38;
            _dgvCustomers.Location = new Point(0, 50);
            _dgvCustomers.Name = "dgvCustomers";
            _dgvCustomers.ReadOnly = true;
            _dgvCustomers.RowTemplate.Height = 38;
            _dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvCustomers.Size = new Size(900, 350);
            _dgvCustomers.TabIndex = 1;
            _dgvCustomers.Columns.Add("ID", "ID");
            _dgvCustomers.Columns.Add("Name", "Customer Name");
            _dgvCustomers.Columns.Add("Email", "Email");
            _dgvCustomers.Columns.Add("Phone", "Phone");
            _dgvCustomers.Columns.Add("Address", "Address");
            _dgvCustomers.Columns.Add("RegistrationDate", "Registered Date");
            _dgvCustomers.CellDoubleClick += DgvCustomers_CellDoubleClick;
            // pnlActions
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(btnViewDetails);
            pnlActions.Controls.Add(btnDeleteAccount);
            pnlActions.Controls.Add(btnClose);
            pnlActions.Controls.Add(_btnEditCustomer);
            pnlActions.Controls.Add(_btnChangePassword);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 400);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(900, 110);
            pnlActions.TabIndex = 2;
            // btnViewDetails
            btnViewDetails.BackColor = Color.LightBlue;
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.IconChar = IconChar.Eye;
            btnViewDetails.IconColor = Color.Black;
            btnViewDetails.IconSize = 20;
            btnViewDetails.Location = new Point(10, 10);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(150, 36);
            btnViewDetails.TabIndex = 0;
            btnViewDetails.Text = "View Details";
            btnViewDetails.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += BtnViewDetails_Click;
            // btnDeleteAccount
            btnDeleteAccount.BackColor = Color.LightCoral;
            btnDeleteAccount.Cursor = Cursors.Hand;
            btnDeleteAccount.IconChar = IconChar.TrashAlt;
            btnDeleteAccount.IconColor = Color.Black;
            btnDeleteAccount.IconSize = 20;
            btnDeleteAccount.Location = new Point(170, 10);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(150, 36);
            btnDeleteAccount.TabIndex = 1;
            btnDeleteAccount.Text = "Delete Account";
            btnDeleteAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteAccount.UseVisualStyleBackColor = false;
            btnDeleteAccount.Click += BtnDeleteAccount_Click;
            // btnClose
            btnClose.BackColor = Color.LightGray;
            btnClose.Cursor = Cursors.Hand;
            btnClose.IconChar = IconChar.Times;
            btnClose.IconColor = Color.Black;
            btnClose.IconSize = 20;
            btnClose.Location = new Point(330, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // _btnEditCustomer
            _btnEditCustomer.BackColor = Color.LightGreen;
            _btnEditCustomer.Cursor = Cursors.Hand;
            _btnEditCustomer.IconChar = IconChar.Edit;
            _btnEditCustomer.IconColor = Color.Black;
            _btnEditCustomer.IconSize = 20;
            _btnEditCustomer.Location = new Point(10, 55);
            _btnEditCustomer.Name = "_btnEditCustomer";
            _btnEditCustomer.Size = new Size(150, 36);
            _btnEditCustomer.TabIndex = 3;
            _btnEditCustomer.Text = "Edit";
            _btnEditCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnEditCustomer.UseVisualStyleBackColor = false;
            _btnEditCustomer.Click += BtnEditCustomer_Click;
            // _btnChangePassword
            _btnChangePassword.BackColor = Color.LightSkyBlue;
            _btnChangePassword.Cursor = Cursors.Hand;
            _btnChangePassword.IconChar = IconChar.Key;
            _btnChangePassword.IconColor = Color.Black;
            _btnChangePassword.IconSize = 20;
            _btnChangePassword.Location = new Point(170, 55);
            _btnChangePassword.Name = "_btnChangePassword";
            _btnChangePassword.Size = new Size(200, 36);
            _btnChangePassword.TabIndex = 4;
            _btnChangePassword.Text = "Change Password";
            _btnChangePassword.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnChangePassword.UseVisualStyleBackColor = false;
            _btnChangePassword.Click += BtnChangePassword_Click;
            // ManageCustomersForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pnlActions);
            Controls.Add(_dgvCustomers);
            Controls.Add(pnlToolbar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ManageCustomersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Customers";
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvCustomers).EndInit();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
