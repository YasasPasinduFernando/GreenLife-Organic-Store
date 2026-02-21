namespace GreenLife_Organic_Store.Forms
{
    partial class AdminRegistrationsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this._dgvAdmins = new DataGridView();
            this._btnRefresh = new Button();
            this._btnClose = new Button();
            this._btnAdd = new Button();
            this._btnEdit = new Button();
            this._btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)this._dgvAdmins).BeginInit();
            this.SuspendLayout();
            // _dgvAdmins
            this._dgvAdmins.AllowUserToAddRows = false;
            this._dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvAdmins.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.LightGray };
            this._dgvAdmins.Dock = DockStyle.Top;
            this._dgvAdmins.Height = 380;
            this._dgvAdmins.MultiSelect = false;
            this._dgvAdmins.Name = "_dgvAdmins";
            this._dgvAdmins.ReadOnly = true;
            this._dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this._dgvAdmins.CellDoubleClick += this.DgvAdmins_CellDoubleClick;
            this._dgvAdmins.Columns.Add("ID", "ID");
            this._dgvAdmins.Columns.Add("Name", "Name");
            this._dgvAdmins.Columns.Add("Email", "Email");
            this._dgvAdmins.Columns.Add("Phone", "Phone");
            this._dgvAdmins.Columns.Add("Age", "Age");
            this._dgvAdmins.Columns.Add("Address", "Address");
            this._dgvAdmins.Columns.Add("CreatedDate", "Created Date");
            // _btnRefresh
            this._btnRefresh.BackColor = Color.FromArgb(34, 139, 34);
            this._btnRefresh.Cursor = Cursors.Hand;
            this._btnRefresh.ForeColor = Color.White;
            this._btnRefresh.Location = new Point(10, 390);
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.Size = new Size(100, 30);
            this._btnRefresh.TabIndex = 0;
            this._btnRefresh.Text = "Refresh";
            this._btnRefresh.UseVisualStyleBackColor = false;
            this._btnRefresh.Click += this.BtnRefresh_Click;
            // _btnClose
            this._btnClose.BackColor = Color.FromArgb(200, 200, 200);
            this._btnClose.Cursor = Cursors.Hand;
            this._btnClose.ForeColor = Color.Black;
            this._btnClose.Location = new Point(120, 390);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new Size(100, 30);
            this._btnClose.TabIndex = 1;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = false;
            this._btnClose.Click += this.BtnClose_Click;
            // _btnAdd
            this._btnAdd.BackColor = Color.FromArgb(34, 139, 34);
            this._btnAdd.Cursor = Cursors.Hand;
            this._btnAdd.ForeColor = Color.White;
            this._btnAdd.Location = new Point(230, 390);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new Size(100, 30);
            this._btnAdd.TabIndex = 2;
            this._btnAdd.Text = "Add Admin";
            this._btnAdd.UseVisualStyleBackColor = false;
            this._btnAdd.Click += this.BtnAdd_Click;
            // _btnEdit
            this._btnEdit.BackColor = Color.FromArgb(34, 139, 34);
            this._btnEdit.Cursor = Cursors.Hand;
            this._btnEdit.ForeColor = Color.White;
            this._btnEdit.Location = new Point(340, 390);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new Size(100, 30);
            this._btnEdit.TabIndex = 3;
            this._btnEdit.Text = "Edit";
            this._btnEdit.UseVisualStyleBackColor = false;
            this._btnEdit.Click += this.BtnEdit_Click;
            // _btnDelete
            this._btnDelete.BackColor = Color.FromArgb(200, 50, 50);
            this._btnDelete.Cursor = Cursors.Hand;
            this._btnDelete.ForeColor = Color.White;
            this._btnDelete.Location = new Point(450, 390);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new Size(100, 30);
            this._btnDelete.TabIndex = 4;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = false;
            this._btnDelete.Click += this.BtnDelete_Click;
            // AdminRegistrationsForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.ClientSize = new Size(784, 461);
            this.Font = new Font("Segoe UI", 9F);
            this.Controls.Add(this._dgvAdmins);
            this.Controls.Add(this._btnRefresh);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._btnEdit);
            this.Controls.Add(this._btnDelete);
            this.Name = "AdminRegistrationsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Admin Registrations - Logs";
            ((System.ComponentModel.ISupportInitialize)this._dgvAdmins).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DataGridView _dgvAdmins;
        private Button _btnRefresh;
        private Button _btnClose;
        private Button _btnAdd;
        private Button _btnEdit;
        private Button _btnDelete;
    }
}
