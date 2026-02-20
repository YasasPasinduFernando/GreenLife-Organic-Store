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
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblPrice = new Label();
            this.numPrice = new NumericUpDown();
            this.lblDiscount = new Label();
            this.lblDiscountValue = new Label();
            this.lblDiscountHint = new Label();
            this.btnManageDiscounts = new Button();
            this.lblStock = new Label();
            this.numStock = new NumericUpDown();
            this.lblSupplier = new Label();
            this.txtSupplier = new TextBox();
            this.chkFeatured = new CheckBox();
            this.chkActive = new CheckBox();
            this.lblImage = new Label();
            this.picPreview = new PictureBox();
            this.btnChooseImage = new Button();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)this.numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picPreview).BeginInit();
            this.SuspendLayout();
            //
            // lblName
            //
            this.lblName.Location = new Point(10, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(100, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product Name:";
            //
            // txtName
            //
            this.txtName.Location = new Point(120, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(400, 23);
            this.txtName.TabIndex = 1;
            //
            // lblCategory
            //
            this.lblCategory.Location = new Point(10, 45);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(100, 20);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";
            //
            // cmbCategory
            //
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new Point(120, 45);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new Size(400, 23);
            this.cmbCategory.TabIndex = 3;
            //
            // lblDescription
            //
            this.lblDescription.Location = new Point(10, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(100, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            //
            // txtDescription
            //
            this.txtDescription.Location = new Point(120, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(400, 60);
            this.txtDescription.TabIndex = 5;
            //
            // lblPrice
            //
            this.lblPrice.Location = new Point(10, 150);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(100, 20);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price (Rs.):";
            //
            // numPrice
            //
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new Point(120, 150);
            this.numPrice.Maximum = 1000000m;
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new Size(150, 23);
            this.numPrice.TabIndex = 7;
            //
            // lblDiscount
            //
            this.lblDiscount.Location = new Point(10, 185);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new Size(100, 20);
            this.lblDiscount.TabIndex = 8;
            this.lblDiscount.Text = "Discount Price:";
            //
            // lblDiscountValue
            //
            this.lblDiscountValue.Location = new Point(120, 185);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new Size(120, 20);
            this.lblDiscountValue.TabIndex = 9;
            this.lblDiscountValue.Text = "-";
            //
            // lblDiscountHint
            //
            this.lblDiscountHint.ForeColor = Color.DimGray;
            this.lblDiscountHint.Location = new Point(120, 207);
            this.lblDiscountHint.Name = "lblDiscountHint";
            this.lblDiscountHint.Size = new Size(300, 18);
            this.lblDiscountHint.TabIndex = 10;
            this.lblDiscountHint.Text = "Click Manage Discounts to add discounts";
            //
            // btnManageDiscounts
            //
            this.btnManageDiscounts.BackColor = Color.FromArgb(46, 204, 113);
            this.btnManageDiscounts.ForeColor = Color.White;
            this.btnManageDiscounts.Location = new Point(120, 230);
            this.btnManageDiscounts.Name = "btnManageDiscounts";
            this.btnManageDiscounts.Size = new Size(150, 26);
            this.btnManageDiscounts.TabIndex = 11;
            this.btnManageDiscounts.Text = "Manage Discounts";
            this.btnManageDiscounts.UseVisualStyleBackColor = false;
            this.btnManageDiscounts.Click += this.BtnManageDiscounts_Click;
            //
            // lblStock
            //
            this.lblStock.Location = new Point(10, 265);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new Size(100, 20);
            this.lblStock.TabIndex = 12;
            this.lblStock.Text = "Stock Quantity:";
            //
            // numStock
            //
            this.numStock.Location = new Point(120, 265);
            this.numStock.Maximum = 10000m;
            this.numStock.Name = "numStock";
            this.numStock.Size = new Size(150, 23);
            this.numStock.TabIndex = 13;
            //
            // lblSupplier
            //
            this.lblSupplier.Location = new Point(10, 300);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new Size(100, 20);
            this.lblSupplier.TabIndex = 14;
            this.lblSupplier.Text = "Supplier:";
            //
            // txtSupplier
            //
            this.txtSupplier.Location = new Point(120, 300);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new Size(400, 23);
            this.txtSupplier.TabIndex = 15;
            //
            // chkFeatured
            //
            this.chkFeatured.Location = new Point(120, 335);
            this.chkFeatured.Name = "chkFeatured";
            this.chkFeatured.Size = new Size(150, 25);
            this.chkFeatured.TabIndex = 16;
            this.chkFeatured.Text = "Mark as Featured";
            //
            // chkActive
            //
            this.chkActive.Checked = true;
            this.chkActive.CheckState = CheckState.Checked;
            this.chkActive.Location = new Point(120, 365);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new Size(150, 25);
            this.chkActive.TabIndex = 17;
            this.chkActive.Text = "Active";
            //
            // lblImage
            //
            this.lblImage.Location = new Point(10, 410);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new Size(100, 20);
            this.lblImage.TabIndex = 18;
            this.lblImage.Text = "Image:";
            //
            // picPreview
            //
            this.picPreview.BorderStyle = BorderStyle.FixedSingle;
            this.picPreview.Location = new Point(120, 410);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(120, 120);
            this.picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 19;
            this.picPreview.TabStop = false;
            //
            // btnChooseImage
            //
            this.btnChooseImage.Location = new Point(250, 455);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new Size(140, 30);
            this.btnChooseImage.TabIndex = 20;
            this.btnChooseImage.Text = "Choose Image...";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += this.BtnChooseImage_Click;
            //
            // btnSave
            //
            this.btnSave.BackColor = Color.Green;
            this.btnSave.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(150, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(150, 40);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save Product";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += this.BtnSave_Click;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.Location = new Point(310, 550);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(150, 40);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += this.BtnCancel_Click;
            //
            // AddEditProductForm
            //
            this.AutoScroll = true;
            this.ClientSize = new Size(584, 661);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblDiscountValue);
            this.Controls.Add(this.lblDiscountHint);
            this.Controls.Add(this.btnManageDiscounts);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.chkFeatured);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddEditProductForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Add New Product";
            ((System.ComponentModel.ISupportInitialize)this.numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picPreview).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
