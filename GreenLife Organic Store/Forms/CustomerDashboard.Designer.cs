using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class CustomerDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel _flpProducts;
        private Panel pnlProductsHeader;
        private Label lblProductsTitle;
        private Panel _pnlCategoriesSection;
        private FlowLayoutPanel _flpCategories;
        private Panel pnlCategoriesHeader;
        private IconButton btnPinCategories;
        private Label lblCategoriesTitle;
        private Panel _pnlFilter;
        private IconButton btnPinFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private IconButton btnSearch;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblPrice;
        private NumericUpDown numMinPrice;
        private Label lblPriceTo;
        private NumericUpDown numMaxPrice;
        private IconButton btnFilter;
        private Panel pnlHeader;
        private IconPictureBox iconLogo;
        private Label lblTitle;
        private Label lblWelcome;
        private Panel pnlHeaderRight;
        private IconButton btnCart;
        private Panel pnlCartInfo;
        private Label _lblCartCount;
        private Label lblCartText;
        private IconButton btnProfile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            _flpProducts = new FlowLayoutPanel();
            pnlProductsHeader = new Panel();
            lblProductsTitle = new Label();
            _pnlCategoriesSection = new Panel();
            _flpCategories = new FlowLayoutPanel();
            pnlCategoriesHeader = new Panel();
            btnPinCategories = new IconButton();
            lblCategoriesTitle = new Label();
            _pnlFilter = new Panel();
            btnPinFilter = new IconButton();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new IconButton();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblPrice = new Label();
            numMinPrice = new NumericUpDown();
            lblPriceTo = new Label();
            numMaxPrice = new NumericUpDown();
            btnFilter = new IconButton();
            pnlHeader = new Panel();
            iconLogo = new IconPictureBox();
            lblTitle = new Label();
            lblWelcome = new Label();
            pnlHeaderRight = new Panel();
            btnCart = new IconButton();
            pnlCartInfo = new Panel();
            _lblCartCount = new Label();
            lblCartText = new Label();
            btnProfile = new IconButton();
            pnlProductsHeader.SuspendLayout();
            _pnlCategoriesSection.SuspendLayout();
            pnlCategoriesHeader.SuspendLayout();
            _pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMinPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPrice).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconLogo).BeginInit();
            pnlHeaderRight.SuspendLayout();
            pnlCartInfo.SuspendLayout();
            SuspendLayout();
            // _flpProducts
            _flpProducts.AutoScroll = true;
            _flpProducts.BackColor = Color.White;
            _flpProducts.Dock = DockStyle.Fill;
            _flpProducts.FlowDirection = FlowDirection.LeftToRight;
            _flpProducts.Location = new Point(0, 280);
            _flpProducts.Name = "flpProducts";
            _flpProducts.Padding = new Padding(15);
            _flpProducts.Size = new Size(1000, 420);
            _flpProducts.TabIndex = 0;
            _flpProducts.WrapContents = true;
            // pnlProductsHeader
            pnlProductsHeader.BackColor = Color.FromArgb(240, 240, 240);
            pnlProductsHeader.Controls.Add(lblProductsTitle);
            pnlProductsHeader.Dock = DockStyle.Top;
            pnlProductsHeader.Location = new Point(0, 240);
            pnlProductsHeader.Name = "pnlProductsHeader";
            pnlProductsHeader.Padding = new Padding(20, 0, 20, 0);
            pnlProductsHeader.Size = new Size(1000, 40);
            pnlProductsHeader.TabIndex = 1;
            // lblProductsTitle
            lblProductsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProductsTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblProductsTitle.Location = new Point(20, 8);
            lblProductsTitle.Name = "lblProductsTitle";
            lblProductsTitle.Size = new Size(200, 25);
            lblProductsTitle.TabIndex = 0;
            lblProductsTitle.Text = "Our Products";
            // _pnlCategoriesSection
            _pnlCategoriesSection.BackColor = Color.White;
            _pnlCategoriesSection.Controls.Add(_flpCategories);
            _pnlCategoriesSection.Controls.Add(pnlCategoriesHeader);
            _pnlCategoriesSection.Dock = DockStyle.Top;
            _pnlCategoriesSection.Location = new Point(0, 80);
            _pnlCategoriesSection.Name = "pnlCategoriesSection";
            _pnlCategoriesSection.Size = new Size(1000, 160);
            _pnlCategoriesSection.TabIndex = 2;
            // _flpCategories
            _flpCategories.AutoScroll = true;
            _flpCategories.BackColor = Color.White;
            _flpCategories.Dock = DockStyle.Fill;
            _flpCategories.FlowDirection = FlowDirection.LeftToRight;
            _flpCategories.Location = new Point(0, 40);
            _flpCategories.Name = "flpCategories";
            _flpCategories.Padding = new Padding(15, 10, 15, 10);
            _flpCategories.Size = new Size(1000, 120);
            _flpCategories.TabIndex = 0;
            _flpCategories.WrapContents = false;
            // pnlCategoriesHeader
            pnlCategoriesHeader.BackColor = Color.White;
            pnlCategoriesHeader.Controls.Add(btnPinCategories);
            pnlCategoriesHeader.Controls.Add(lblCategoriesTitle);
            pnlCategoriesHeader.Dock = DockStyle.Top;
            pnlCategoriesHeader.Location = new Point(0, 0);
            pnlCategoriesHeader.Name = "pnlCategoriesHeader";
            pnlCategoriesHeader.Padding = new Padding(20, 0, 20, 0);
            pnlCategoriesHeader.Size = new Size(1000, 40);
            pnlCategoriesHeader.TabIndex = 1;
            // btnPinCategories
            btnPinCategories.BackColor = Color.FromArgb(52, 152, 219);
            btnPinCategories.Cursor = Cursors.Hand;
            btnPinCategories.FlatStyle = FlatStyle.Flat;
            btnPinCategories.FlatAppearance.BorderSize = 0;
            btnPinCategories.IconChar = IconChar.AngleDown;
            btnPinCategories.IconColor = Color.White;
            btnPinCategories.IconSize = 20;
            btnPinCategories.Location = new Point(15, 5);
            btnPinCategories.Name = "btnPinCategories";
            btnPinCategories.Size = new Size(35, 30);
            btnPinCategories.TabIndex = 0;
            btnPinCategories.Text = "";
            btnPinCategories.UseVisualStyleBackColor = false;
            btnPinCategories.Click += BtnPinCategories_Click;
            // lblCategoriesTitle
            lblCategoriesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCategoriesTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblCategoriesTitle.Location = new Point(60, 8);
            lblCategoriesTitle.Name = "lblCategoriesTitle";
            lblCategoriesTitle.Size = new Size(200, 25);
            lblCategoriesTitle.TabIndex = 1;
            lblCategoriesTitle.Text = "Shop by Category";
            // _pnlFilter
            _pnlFilter.BackColor = Color.White;
            _pnlFilter.Controls.Add(btnPinFilter);
            _pnlFilter.Controls.Add(lblSearch);
            _pnlFilter.Controls.Add(txtSearch);
            _pnlFilter.Controls.Add(btnSearch);
            _pnlFilter.Controls.Add(lblCategory);
            _pnlFilter.Controls.Add(cmbCategory);
            _pnlFilter.Controls.Add(lblPrice);
            _pnlFilter.Controls.Add(numMinPrice);
            _pnlFilter.Controls.Add(lblPriceTo);
            _pnlFilter.Controls.Add(numMaxPrice);
            _pnlFilter.Controls.Add(btnFilter);
            _pnlFilter.Dock = DockStyle.Top;
            _pnlFilter.Location = new Point(0, 0);
            _pnlFilter.Name = "pnlFilter";
            _pnlFilter.Padding = new Padding(20, 15, 20, 15);
            _pnlFilter.Size = new Size(1000, 80);
            _pnlFilter.TabIndex = 3;
            // btnPinFilter
            btnPinFilter.BackColor = Color.FromArgb(52, 152, 219);
            btnPinFilter.Cursor = Cursors.Hand;
            btnPinFilter.FlatStyle = FlatStyle.Flat;
            btnPinFilter.FlatAppearance.BorderSize = 0;
            btnPinFilter.IconChar = IconChar.AngleDown;
            btnPinFilter.IconColor = Color.White;
            btnPinFilter.IconSize = 20;
            btnPinFilter.Location = new Point(15, 15);
            btnPinFilter.Name = "btnPinFilter";
            btnPinFilter.Size = new Size(35, 35);
            btnPinFilter.TabIndex = 0;
            btnPinFilter.Text = "";
            btnPinFilter.UseVisualStyleBackColor = false;
            btnPinFilter.Click += BtnPinFilter_Click;
            // lblSearch
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);
            lblSearch.Location = new Point(60, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(80, 25);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // txtSearch
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(145, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 27);
            txtSearch.TabIndex = 2;
            // btnSearch
            btnSearch.BackColor = Color.FromArgb(46, 204, 113);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.IconChar = IconChar.Search;
            btnSearch.IconColor = Color.White;
            btnSearch.IconSize = 18;
            btnSearch.Location = new Point(405, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 35);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // lblCategory
            lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(52, 73, 94);
            lblCategory.Location = new Point(530, 18);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(80, 25);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category:";
            // cmbCategory
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.Location = new Point(615, 15);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(180, 25);
            cmbCategory.TabIndex = 5;
            cmbCategory.Items.Add("All Products");
            cmbCategory.SelectedIndex = 0;
            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
            // lblPrice
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(52, 73, 94);
            lblPrice.Location = new Point(810, 18);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(50, 25);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price:";
            // numMinPrice
            numMinPrice.Font = new Font("Segoe UI", 10F);
            numMinPrice.Location = new Point(865, 15);
            numMinPrice.Maximum = 10000;
            numMinPrice.Name = "numMinPrice";
            numMinPrice.Size = new Size(90, 25);
            numMinPrice.TabIndex = 7;
            // lblPriceTo
            lblPriceTo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPriceTo.Location = new Point(960, 18);
            lblPriceTo.Name = "lblPriceTo";
            lblPriceTo.Size = new Size(20, 25);
            lblPriceTo.TabIndex = 8;
            lblPriceTo.Text = "-";
            // numMaxPrice
            numMaxPrice.Font = new Font("Segoe UI", 10F);
            numMaxPrice.Location = new Point(985, 15);
            numMaxPrice.Maximum = 10000;
            numMaxPrice.Name = "numMaxPrice";
            numMaxPrice.Size = new Size(90, 25);
            numMaxPrice.TabIndex = 9;
            numMaxPrice.Value = 10000;
            // btnFilter
            btnFilter.BackColor = Color.FromArgb(52, 152, 219);
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.IconChar = IconChar.Filter;
            btnFilter.IconColor = Color.White;
            btnFilter.IconSize = 18;
            btnFilter.Location = new Point(1085, 13);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(95, 35);
            btnFilter.TabIndex = 10;
            btnFilter.Text = "Filter";
            btnFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += BtnFilter_Click;
            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(34, 139, 34);
            pnlHeader.Controls.Add(iconLogo);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(pnlHeaderRight);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 88);
            pnlHeader.TabIndex = 4;
            // iconLogo
            iconLogo.BackColor = Color.Transparent;
            iconLogo.IconChar = IconChar.Leaf;
            iconLogo.IconColor = Color.White;
            iconLogo.IconSize = 50;
            iconLogo.Location = new Point(20, 15);
            iconLogo.Name = "iconLogo";
            iconLogo.Size = new Size(50, 50);
            iconLogo.TabIndex = 0;
            iconLogo.TabStop = false;
            // lblTitle
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(82, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(480, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "GreenLife Organic Store";
            lblTitle.UseCompatibleTextRendering = false;
            // lblWelcome
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.FromArgb(220, 255, 220);
            lblWelcome.Location = new Point(80, 54);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(380, 22);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome!";
            // pnlHeaderRight
            pnlHeaderRight.BackColor = Color.Transparent;
            pnlHeaderRight.Controls.Add(btnCart);
            pnlHeaderRight.Controls.Add(pnlCartInfo);
            pnlHeaderRight.Controls.Add(btnProfile);
            pnlHeaderRight.Dock = DockStyle.Right;
            pnlHeaderRight.Location = new Point(700, 0);
            pnlHeaderRight.Name = "pnlHeaderRight";
            pnlHeaderRight.Size = new Size(300, 88);
            pnlHeaderRight.TabIndex = 3;
            // btnCart
            btnCart.BackColor = Color.FromArgb(46, 204, 113);
            btnCart.Cursor = Cursors.Hand;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.ForeColor = Color.White;
            btnCart.IconChar = IconChar.ShoppingCart;
            btnCart.IconColor = Color.White;
            btnCart.IconSize = 22;
            btnCart.Location = new Point(10, 15);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(44, 44);
            btnCart.TabIndex = 0;
            btnCart.Text = "";
            btnCart.UseVisualStyleBackColor = false;
            btnCart.Click += BtnCart_Click;
            // pnlCartInfo
            pnlCartInfo.BackColor = Color.Transparent;
            pnlCartInfo.Controls.Add(_lblCartCount);
            pnlCartInfo.Controls.Add(lblCartText);
            pnlCartInfo.Location = new Point(64, 12);
            pnlCartInfo.Name = "pnlCartInfo";
            pnlCartInfo.Size = new Size(60, 44);
            pnlCartInfo.TabIndex = 1;
            // _lblCartCount
            _lblCartCount.Dock = DockStyle.Top;
            _lblCartCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _lblCartCount.ForeColor = Color.White;
            _lblCartCount.Location = new Point(0, 0);
            _lblCartCount.Name = "lblCartCount";
            _lblCartCount.Size = new Size(60, 26);
            _lblCartCount.TabIndex = 0;
            _lblCartCount.Text = "0";
            _lblCartCount.TextAlign = ContentAlignment.MiddleCenter;
            _lblCartCount.Click += LblCartCount_Click;
            // lblCartText
            lblCartText.Dock = DockStyle.Bottom;
            lblCartText.Font = new Font("Segoe UI", 8.5F);
            lblCartText.ForeColor = Color.FromArgb(220, 255, 220);
            lblCartText.Location = new Point(0, 26);
            lblCartText.Name = "lblCartText";
            lblCartText.Size = new Size(60, 18);
            lblCartText.TabIndex = 1;
            lblCartText.Text = "Items";
            lblCartText.TextAlign = ContentAlignment.MiddleCenter;
            lblCartText.Click += LblCartText_Click;
            // btnProfile
            btnProfile.BackColor = Color.FromArgb(52, 152, 219);
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.IconChar = IconChar.UserCircle;
            btnProfile.IconColor = Color.White;
            btnProfile.IconSize = 20;
            btnProfile.Location = new Point(160, 12);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(120, 44);
            btnProfile.TabIndex = 2;
            btnProfile.Text = "Profile";
            btnProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += BtnProfile_Click;
            // CustomerDashboard
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1000, 700);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(_flpProducts);
            Controls.Add(pnlProductsHeader);
            Controls.Add(_pnlCategoriesSection);
            Controls.Add(_pnlFilter);
            Controls.Add(pnlHeader);
            Name = "CustomerDashboard";
            Text = "GreenLife Organic Store - Customer Shopping";
            Load += CustomerDashboard_Load;
            pnlProductsHeader.ResumeLayout(false);
            _pnlCategoriesSection.ResumeLayout(false);
            pnlCategoriesHeader.ResumeLayout(false);
            _pnlFilter.ResumeLayout(false);
            _pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMinPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPrice).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconLogo).EndInit();
            pnlHeaderRight.ResumeLayout(false);
            pnlCartInfo.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
