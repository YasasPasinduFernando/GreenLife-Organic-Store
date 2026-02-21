using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class AddEditDiscountForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtName;
        private Label lblProduct;
        private ComboBox cmbProduct;
        private Label lblPercent;
        private NumericUpDown numPercent;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;
        private CheckBox chkActive;
        private Label lblImage;
        private PictureBox picProduct;
        private IconButton btnSave;
        private IconButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblProduct = new Label();
            cmbProduct = new ComboBox();
            lblPercent = new Label();
            numPercent = new NumericUpDown();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            chkActive = new CheckBox();
            lblImage = new Label();
            picProduct = new PictureBox();
            btnSave = new IconButton();
            btnCancel = new IconButton();
            ((System.ComponentModel.ISupportInitialize)numPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.Location = new Point(9, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(105, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Discount Name:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9F);
            txtName.Location = new Point(122, 8);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(289, 23);
            txtName.TabIndex = 1;
            // 
            // lblProduct
            // 
            lblProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProduct.Location = new Point(9, 35);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(105, 15);
            lblProduct.TabIndex = 2;
            lblProduct.Text = "Select Product:";
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Font = new Font("Segoe UI", 9F);
            cmbProduct.Location = new Point(122, 34);
            cmbProduct.Margin = new Padding(3, 2, 3, 2);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(289, 23);
            cmbProduct.TabIndex = 3;
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;
            // 
            // lblPercent
            // 
            lblPercent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPercent.Location = new Point(9, 62);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(105, 15);
            lblPercent.TabIndex = 4;
            lblPercent.Text = "Discount %:";
            // 
            // numPercent
            // 
            numPercent.DecimalPlaces = 2;
            numPercent.Font = new Font("Segoe UI", 9F);
            numPercent.Location = new Point(122, 60);
            numPercent.Margin = new Padding(3, 2, 3, 2);
            numPercent.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPercent.Name = "numPercent";
            numPercent.Size = new Size(289, 23);
            numPercent.TabIndex = 5;
            numPercent.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.Location = new Point(9, 88);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(105, 15);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9F);
            txtDescription.Location = new Point(122, 86);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(289, 46);
            txtDescription.TabIndex = 7;
            // 
            // lblStartDate
            // 
            lblStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStartDate.Location = new Point(9, 158);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(105, 15);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 9F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(122, 157);
            dtpStartDate.Margin = new Padding(3, 2, 3, 2);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(289, 23);
            dtpStartDate.TabIndex = 9;
            // 
            // lblEndDate
            // 
            lblEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEndDate.Location = new Point(9, 184);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(105, 15);
            lblEndDate.TabIndex = 10;
            lblEndDate.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 9F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(122, 183);
            dtpEndDate.Margin = new Padding(3, 2, 3, 2);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(289, 23);
            dtpEndDate.TabIndex = 11;
            dtpEndDate.Value = new DateTime(2026, 3, 23, 22, 3, 43, 297);
            // 
            // chkActive
            // 
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Font = new Font("Segoe UI", 9F);
            chkActive.Location = new Point(122, 231);
            chkActive.Margin = new Padding(3, 2, 3, 2);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(131, 19);
            chkActive.TabIndex = 12;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // lblImage
            // 
            lblImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImage.Location = new Point(9, 282);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(105, 15);
            lblImage.TabIndex = 13;
            lblImage.Text = "Product Image:";
            // 
            // picProduct
            // 
            picProduct.BorderStyle = BorderStyle.FixedSingle;
            picProduct.Location = new Point(122, 279);
            picProduct.Margin = new Padding(3, 2, 3, 2);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(105, 90);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 14;
            picProduct.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.IconChar = IconChar.Save;
            btnSave.IconColor = Color.White;
            btnSave.IconFont = IconFont.Auto;
            btnSave.IconSize = 16;
            btnSave.Location = new Point(34, 398);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 27);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save Discount";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = IconChar.Close;
            btnCancel.IconColor = Color.White;
            btnCancel.IconFont = IconFont.Auto;
            btnCancel.IconSize = 16;
            btnCancel.Location = new Point(266, 398);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 27);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // AddEditDiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(438, 488);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblProduct);
            Controls.Add(cmbProduct);
            Controls.Add(lblPercent);
            Controls.Add(numPercent);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblStartDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpEndDate);
            Controls.Add(chkActive);
            Controls.Add(lblImage);
            Controls.Add(picProduct);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AddEditDiscountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Discount";
            ((System.ComponentModel.ISupportInitialize)numPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
