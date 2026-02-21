namespace GreenLife_Organic_Store.Forms
{
    partial class AddEditProductForm
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
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblDiscount = new Label();
            lblDiscountValue = new Label();
            lblDiscountHint = new Label();
            btnManageDiscounts = new Button();
            lblStock = new Label();
            numStock = new NumericUpDown();
            lblSupplier = new Label();
            txtSupplier = new TextBox();
            chkFeatured = new CheckBox();
            chkActive = new CheckBox();
            lblImage = new Label();
            picPreview = new PictureBox();
            btnChooseImage = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(9, 8);
            lblName.Name = "lblName";
            lblName.Size = new Size(88, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Product Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(105, 8);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(350, 23);
            txtName.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(9, 34);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(88, 15);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(105, 34);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(350, 23);
            cmbCategory.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(9, 60);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(105, 60);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(350, 46);
            txtDescription.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(9, 112);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(88, 15);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price (Rs.):";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(105, 112);
            numPrice.Margin = new Padding(3, 2, 3, 2);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(131, 23);
            numPrice.TabIndex = 7;
            // 
            // lblDiscount
            // 
            lblDiscount.Location = new Point(9, 139);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(88, 15);
            lblDiscount.TabIndex = 8;
            lblDiscount.Text = "Discount Price:";
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.Location = new Point(105, 139);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(105, 15);
            lblDiscountValue.TabIndex = 9;
            lblDiscountValue.Text = "-";
            // 
            // lblDiscountHint
            // 
            lblDiscountHint.ForeColor = Color.DimGray;
            lblDiscountHint.Location = new Point(105, 155);
            lblDiscountHint.Name = "lblDiscountHint";
            lblDiscountHint.Size = new Size(262, 14);
            lblDiscountHint.TabIndex = 10;
            lblDiscountHint.Text = "Click Manage Discounts to add discounts";
            // 
            // btnManageDiscounts
            // 
            btnManageDiscounts.BackColor = Color.FromArgb(46, 204, 113);
            btnManageDiscounts.ForeColor = Color.White;
            btnManageDiscounts.Location = new Point(105, 172);
            btnManageDiscounts.Margin = new Padding(3, 2, 3, 2);
            btnManageDiscounts.Name = "btnManageDiscounts";
            btnManageDiscounts.Size = new Size(131, 29);
            btnManageDiscounts.TabIndex = 11;
            btnManageDiscounts.Text = "Manage Discounts";
            btnManageDiscounts.UseVisualStyleBackColor = false;
            btnManageDiscounts.Click += BtnManageDiscounts_Click;
            // 
            // lblStock
            // 
            lblStock.Location = new Point(8, 216);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(88, 15);
            lblStock.TabIndex = 12;
            lblStock.Text = "Stock Quantity:";
            // 
            // numStock
            // 
            numStock.Location = new Point(104, 216);
            numStock.Margin = new Padding(3, 2, 3, 2);
            numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(131, 23);
            numStock.TabIndex = 13;
            // 
            // lblSupplier
            // 
            lblSupplier.Location = new Point(8, 242);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(88, 15);
            lblSupplier.TabIndex = 14;
            lblSupplier.Text = "Supplier:";
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(104, 242);
            txtSupplier.Margin = new Padding(3, 2, 3, 2);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(350, 23);
            txtSupplier.TabIndex = 15;
            // 
            // chkFeatured
            // 
            chkFeatured.Location = new Point(104, 268);
            chkFeatured.Margin = new Padding(3, 2, 3, 2);
            chkFeatured.Name = "chkFeatured";
            chkFeatured.Size = new Size(131, 19);
            chkFeatured.TabIndex = 16;
            chkFeatured.Text = "Mark as Featured";
            // 
            // chkActive
            // 
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(104, 291);
            chkActive.Margin = new Padding(3, 2, 3, 2);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(131, 19);
            chkActive.TabIndex = 17;
            chkActive.Text = "Active";
            // 
            // lblImage
            // 
            lblImage.Location = new Point(8, 325);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(88, 15);
            lblImage.TabIndex = 18;
            lblImage.Text = "Image:";
            // 
            // picPreview
            // 
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(104, 325);
            picPreview.Margin = new Padding(3, 2, 3, 2);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(105, 90);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 19;
            picPreview.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(218, 358);
            btnChooseImage.Margin = new Padding(3, 2, 3, 2);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(122, 27);
            btnChooseImage.TabIndex = 20;
            btnChooseImage.Text = "Choose Image...";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += BtnChooseImage_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(79, 448);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 37);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save Product";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Location = new Point(289, 448);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 37);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // AddEditProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(511, 496);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblPrice);
            Controls.Add(numPrice);
            Controls.Add(lblDiscount);
            Controls.Add(lblDiscountValue);
            Controls.Add(lblDiscountHint);
            Controls.Add(btnManageDiscounts);
            Controls.Add(lblStock);
            Controls.Add(numStock);
            Controls.Add(lblSupplier);
            Controls.Add(txtSupplier);
            Controls.Add(chkFeatured);
            Controls.Add(chkActive);
            Controls.Add(lblImage);
            Controls.Add(picPreview);
            Controls.Add(btnChooseImage);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AddEditProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Product";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblDiscount;
        private Label lblDiscountValue;
        private Label lblDiscountHint;
        private Button btnManageDiscounts;
        private Label lblStock;
        private NumericUpDown numStock;
        private Label lblSupplier;
        private TextBox txtSupplier;
        private CheckBox chkFeatured;
        private CheckBox chkActive;
        private Label lblImage;
        private PictureBox picPreview;
        private Button btnChooseImage;
        private Button btnSave;
        private Button btnCancel;
    }
}
