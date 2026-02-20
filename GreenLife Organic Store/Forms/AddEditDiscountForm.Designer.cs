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
            // lblName
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.Location = new Point(10, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(120, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Discount Name:";
            // txtName
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(140, 10);
            txtName.Name = "txtName";
            txtName.Size = new Size(330, 25);
            txtName.TabIndex = 1;
            // lblProduct
            lblProduct.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProduct.Location = new Point(10, 45);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(120, 20);
            lblProduct.TabIndex = 2;
            lblProduct.Text = "Select Product:";
            // cmbProduct
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Font = new Font("Segoe UI", 10F);
            cmbProduct.Location = new Point(140, 45);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(330, 25);
            cmbProduct.TabIndex = 3;
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;
            // lblPercent
            lblPercent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPercent.Location = new Point(10, 80);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(120, 20);
            lblPercent.TabIndex = 4;
            lblPercent.Text = "Discount %:";
            // numPercent
            numPercent.DecimalPlaces = 2;
            numPercent.Font = new Font("Segoe UI", 10F);
            numPercent.Location = new Point(140, 80);
            numPercent.Maximum = 100;
            numPercent.Minimum = 1;
            numPercent.Name = "numPercent";
            numPercent.Size = new Size(330, 25);
            numPercent.TabIndex = 5;
            numPercent.Value = 1;
            // lblDescription
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.Location = new Point(10, 115);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(120, 20);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description:";
            // txtDescription
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(140, 115);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(330, 60);
            txtDescription.TabIndex = 7;
            // lblStartDate
            lblStartDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStartDate.Location = new Point(10, 185);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(120, 20);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "Start Date:";
            // dtpStartDate
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(140, 185);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(330, 25);
            dtpStartDate.TabIndex = 9;
            // lblEndDate
            lblEndDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEndDate.Location = new Point(10, 220);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(120, 20);
            lblEndDate.TabIndex = 10;
            lblEndDate.Text = "End Date:";
            // dtpEndDate
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(140, 220);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(330, 25);
            dtpEndDate.TabIndex = 11;
            dtpEndDate.Value = DateTime.Now.AddDays(30);
            // chkActive
            chkActive.Checked = true;
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(140, 255);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(150, 25);
            chkActive.TabIndex = 12;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // lblImage
            lblImage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblImage.Location = new Point(10, 295);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(120, 20);
            lblImage.TabIndex = 13;
            lblImage.Text = "Product Image:";
            // picProduct
            picProduct.BorderStyle = BorderStyle.FixedSingle;
            picProduct.Location = new Point(140, 295);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(120, 120);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 14;
            picProduct.TabStop = false;
            // btnSave
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.IconChar = IconChar.Save;
            btnSave.IconColor = Color.White;
            btnSave.IconSize = 18;
            btnSave.Location = new Point(100, 430);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save Discount";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // btnCancel
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = IconChar.Times;
            btnCancel.IconColor = Color.White;
            btnCancel.IconSize = 18;
            btnCancel.Location = new Point(260, 430);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // AddEditDiscountForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(500, 650);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
