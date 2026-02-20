using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class OrderEditForm
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
            this.lblCustName = new Label();
            this.txtCustomerName = new TextBox();
            this.lblPhone = new Label();
            this.txtCustomerPhone = new TextBox();
            this.lblEmail = new Label();
            this.txtCustomerEmail = new TextBox();
            this.lblStatus = new Label();
            this.cmbStatus = new ComboBox();
            this.lblAddress = new Label();
            this.txtShippingAddress = new TextBox();
            this.lblNotes = new Label();
            this.txtNotes = new TextBox();
            this.btnSave = new IconButton();
            this.btnCancel = new IconButton();
            this.SuspendLayout();
            //
            // lblCustName
            //
            this.lblCustName.Location = new Point(10, 10);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new Size(120, 22);
            this.lblCustName.TabIndex = 0;
            this.lblCustName.Text = "Customer Name:";
            //
            // txtCustomerName
            //
            this.txtCustomerName.Location = new Point(140, 10);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new Size(400, 23);
            this.txtCustomerName.TabIndex = 1;
            //
            // lblPhone
            //
            this.lblPhone.Location = new Point(10, 45);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(120, 22);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone:";
            //
            // txtCustomerPhone
            //
            this.txtCustomerPhone.Location = new Point(140, 45);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new Size(400, 23);
            this.txtCustomerPhone.TabIndex = 3;
            //
            // lblEmail
            //
            this.lblEmail.Location = new Point(10, 80);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(120, 22);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            //
            // txtCustomerEmail
            //
            this.txtCustomerEmail.Location = new Point(140, 80);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new Size(400, 23);
            this.txtCustomerEmail.TabIndex = 5;
            //
            // lblStatus
            //
            this.lblStatus.Location = new Point(10, 115);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(120, 22);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            //
            // cmbStatus
            //
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new Point(140, 115);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(200, 23);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "Processing", "Shipped", "Delivered", "Cancelled" });
            //
            // lblAddress
            //
            this.lblAddress.Location = new Point(10, 150);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new Size(120, 22);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Shipping Address:";
            //
            // txtShippingAddress
            //
            this.txtShippingAddress.Location = new Point(140, 150);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new Size(400, 60);
            this.txtShippingAddress.TabIndex = 9;
            //
            // lblNotes
            //
            this.lblNotes.Location = new Point(10, 220);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(120, 22);
            this.lblNotes.TabIndex = 10;
            this.lblNotes.Text = "Notes:";
            //
            // txtNotes
            //
            this.txtNotes.Location = new Point(140, 220);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new Size(400, 120);
            this.txtNotes.TabIndex = 11;
            //
            // btnSave
            //
            this.btnSave.BackColor = Color.FromArgb(34, 139, 34);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.IconChar = IconChar.Save;
            this.btnSave.IconColor = Color.White;
            this.btnSave.IconSize = 20;
            this.btnSave.Location = new Point(140, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += this.BtnSave_Click;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.IconChar = IconChar.Times;
            this.btnCancel.IconColor = Color.Black;
            this.btnCancel.IconSize = 20;
            this.btnCancel.Location = new Point(260, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += this.BtnCancel_Click;
            //
            // OrderEditForm
            //
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(584, 461);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtCustomerPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtCustomerEmail);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtShippingAddress);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "OrderEditForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit Order";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblCustName;
        private TextBox txtCustomerName;
        private Label lblPhone;
        private TextBox txtCustomerPhone;
        private Label lblEmail;
        private TextBox txtCustomerEmail;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblAddress;
        private TextBox txtShippingAddress;
        private Label lblNotes;
        private TextBox txtNotes;
        private IconButton btnSave;
        private IconButton btnCancel;
    }
}
