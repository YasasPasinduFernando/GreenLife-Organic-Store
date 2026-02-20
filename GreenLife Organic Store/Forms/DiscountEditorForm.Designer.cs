using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class DiscountEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlContent;
        private Label lblProductInfo;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private TextBox txtCategory;
        private Label lblPricing;
        private Label lblOriginalPrice;
        private TextBox txtOriginalPrice;
        private Label lblDiscountPrice;
        private NumericUpDown _numDiscountPrice;
        private Label lblDiscountPercent;
        private Label _lblPercentValue;
        private Label lblSavings;
        private Label _lblSavingsValue;
        private Panel pnlButtons;
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlContent = new Panel();
            lblProductInfo = new Label();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
            lblPricing = new Label();
            lblOriginalPrice = new Label();
            txtOriginalPrice = new TextBox();
            lblDiscountPrice = new Label();
            _numDiscountPrice = new NumericUpDown();
            lblDiscountPercent = new Label();
            _lblPercentValue = new Label();
            lblSavings = new Label();
            _lblSavingsValue = new Label();
            pnlButtons = new Panel();
            btnSave = new IconButton();
            btnCancel = new IconButton();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_numDiscountPrice).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(13, 11, 13, 11);
            pnlHeader.Size = new Size(438, 38);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(13, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(394, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Discount - Product";
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(lblProductInfo);
            pnlContent.Controls.Add(lblProductName);
            pnlContent.Controls.Add(txtProductName);
            pnlContent.Controls.Add(lblCategory);
            pnlContent.Controls.Add(txtCategory);
            pnlContent.Controls.Add(lblPricing);
            pnlContent.Controls.Add(lblOriginalPrice);
            pnlContent.Controls.Add(txtOriginalPrice);
            pnlContent.Controls.Add(lblDiscountPrice);
            pnlContent.Controls.Add(_numDiscountPrice);
            pnlContent.Controls.Add(lblDiscountPercent);
            pnlContent.Controls.Add(_lblPercentValue);
            pnlContent.Controls.Add(lblSavings);
            pnlContent.Controls.Add(_lblSavingsValue);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 38);
            pnlContent.Margin = new Padding(3, 2, 3, 2);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(18, 15, 18, 15);
            pnlContent.Size = new Size(438, 224);
            pnlContent.TabIndex = 1;
            // 
            // lblProductInfo
            // 
            lblProductInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProductInfo.ForeColor = Color.FromArgb(52, 73, 94);
            lblProductInfo.Location = new Point(18, 15);
            lblProductInfo.Name = "lblProductInfo";
            lblProductInfo.Size = new Size(350, 19);
            lblProductInfo.TabIndex = 0;
            lblProductInfo.Text = "Product Information";
            // 
            // lblProductName
            // 
            lblProductName.Font = new Font("Segoe UI", 10F);
            lblProductName.ForeColor = Color.FromArgb(52, 73, 94);
            lblProductName.Location = new Point(18, 41);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(105, 15);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name:";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 10F);
            txtProductName.Location = new Point(131, 39);
            txtProductName.Margin = new Padding(3, 2, 3, 2);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(263, 25);
            txtProductName.TabIndex = 2;
            txtProductName.Text = "Product";
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Segoe UI", 10F);
            lblCategory.ForeColor = Color.FromArgb(52, 73, 94);
            lblCategory.Location = new Point(18, 64);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(105, 15);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category:";
            // 
            // txtCategory
            // 
            txtCategory.Font = new Font("Segoe UI", 10F);
            txtCategory.Location = new Point(131, 62);
            txtCategory.Margin = new Padding(3, 2, 3, 2);
            txtCategory.Name = "txtCategory";
            txtCategory.ReadOnly = true;
            txtCategory.Size = new Size(263, 25);
            txtCategory.TabIndex = 4;
            txtCategory.Text = "Category";
            // 
            // lblPricing
            // 
            lblPricing.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPricing.ForeColor = Color.FromArgb(52, 73, 94);
            lblPricing.Location = new Point(18, 94);
            lblPricing.Name = "lblPricing";
            lblPricing.Size = new Size(350, 19);
            lblPricing.TabIndex = 5;
            lblPricing.Text = "Pricing";
            // 
            // lblOriginalPrice
            // 
            lblOriginalPrice.Font = new Font("Segoe UI", 10F);
            lblOriginalPrice.ForeColor = Color.FromArgb(52, 73, 94);
            lblOriginalPrice.Location = new Point(18, 120);
            lblOriginalPrice.Name = "lblOriginalPrice";
            lblOriginalPrice.Size = new Size(105, 15);
            lblOriginalPrice.TabIndex = 6;
            lblOriginalPrice.Text = "Original Price (Rs.):";
            // 
            // txtOriginalPrice
            // 
            txtOriginalPrice.Font = new Font("Segoe UI", 10F);
            txtOriginalPrice.Location = new Point(131, 118);
            txtOriginalPrice.Margin = new Padding(3, 2, 3, 2);
            txtOriginalPrice.Name = "txtOriginalPrice";
            txtOriginalPrice.ReadOnly = true;
            txtOriginalPrice.Size = new Size(263, 25);
            txtOriginalPrice.TabIndex = 7;
            txtOriginalPrice.Text = "0.00";
            // 
            // lblDiscountPrice
            // 
            lblDiscountPrice.Font = new Font("Segoe UI", 10F);
            lblDiscountPrice.ForeColor = Color.FromArgb(52, 73, 94);
            lblDiscountPrice.Location = new Point(18, 142);
            lblDiscountPrice.Name = "lblDiscountPrice";
            lblDiscountPrice.Size = new Size(105, 15);
            lblDiscountPrice.TabIndex = 8;
            lblDiscountPrice.Text = "Discount Price (Rs.):";
            // 
            // _numDiscountPrice
            // 
            _numDiscountPrice.DecimalPlaces = 2;
            _numDiscountPrice.Font = new Font("Segoe UI", 10F);
            _numDiscountPrice.Location = new Point(131, 140);
            _numDiscountPrice.Margin = new Padding(3, 2, 3, 2);
            _numDiscountPrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            _numDiscountPrice.Name = "_numDiscountPrice";
            _numDiscountPrice.Size = new Size(262, 25);
            _numDiscountPrice.TabIndex = 9;
            _numDiscountPrice.ValueChanged += NumDiscountPrice_ValueChanged;
            // 
            // lblDiscountPercent
            // 
            lblDiscountPercent.Font = new Font("Segoe UI", 10F);
            lblDiscountPercent.ForeColor = Color.FromArgb(52, 73, 94);
            lblDiscountPercent.Location = new Point(18, 165);
            lblDiscountPercent.Name = "lblDiscountPercent";
            lblDiscountPercent.Size = new Size(105, 15);
            lblDiscountPercent.TabIndex = 10;
            lblDiscountPercent.Text = "Discount Percentage:";
            // 
            // _lblPercentValue
            // 
            _lblPercentValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _lblPercentValue.ForeColor = Color.FromArgb(46, 204, 113);
            _lblPercentValue.Location = new Point(131, 165);
            _lblPercentValue.Name = "_lblPercentValue";
            _lblPercentValue.Size = new Size(262, 15);
            _lblPercentValue.TabIndex = 11;
            _lblPercentValue.Text = "0%";
            // 
            // lblSavings
            // 
            lblSavings.Font = new Font("Segoe UI", 10F);
            lblSavings.ForeColor = Color.FromArgb(52, 73, 94);
            lblSavings.Location = new Point(18, 188);
            lblSavings.Name = "lblSavings";
            lblSavings.Size = new Size(105, 15);
            lblSavings.TabIndex = 12;
            lblSavings.Text = "You Save:";
            // 
            // _lblSavingsValue
            // 
            _lblSavingsValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _lblSavingsValue.ForeColor = Color.FromArgb(52, 152, 219);
            _lblSavingsValue.Location = new Point(131, 188);
            _lblSavingsValue.Name = "_lblSavingsValue";
            _lblSavingsValue.Size = new Size(262, 15);
            _lblSavingsValue.TabIndex = 13;
            _lblSavingsValue.Text = "Rs. 0.00";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.White;
            pnlButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 262);
            pnlButtons.Margin = new Padding(3, 2, 3, 2);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(9, 8, 9, 8);
            pnlButtons.Size = new Size(438, 38);
            pnlButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.IconChar = IconChar.Save;
            btnSave.IconColor = Color.White;
            btnSave.IconFont = IconFont.Auto;
            btnSave.IconSize = 18;
            btnSave.Location = new Point(131, 8);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 22);
            btnSave.TabIndex = 0;
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
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = IconChar.Close;
            btnCancel.IconColor = Color.White;
            btnCancel.IconFont = IconFont.Auto;
            btnCancel.IconSize = 18;
            btnCancel.Location = new Point(262, 8);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 22);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // DiscountEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(438, 300);
            Controls.Add(pnlContent);
            Controls.Add(pnlButtons);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DiscountEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Discount";
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_numDiscountPrice).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
