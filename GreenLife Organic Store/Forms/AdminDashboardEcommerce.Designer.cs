using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class AdminDashboardEcommerce
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private IconPictureBox iconLogo;
        private Label lblHeader;
        private IconButton btnLogout;
        private Panel pnlMenu;
        private IconButton btnManageProducts;
        private IconButton btnManageOrders;
        private IconButton btnManageCategories;
        private IconButton btnManageCustomers;
        private IconButton btnSalesReports;
        private IconButton btnAdminRegistrations;
        private IconButton btnOrderReviews;
        private IconButton btnManageDiscounts;
        private Panel pnlContent;
        private Label lblContentTitle;
        private Label lblContentNote;
        private Panel pnlStats;
        private Panel pnlStatCard1;
        private Label lblStatTitle1;
        private Label lblTotalProducts;
        private Panel pnlStatCard2;
        private Label lblStatTitle2;
        private Label lblPendingOrders;
        private Panel pnlStatCard3;
        private Label lblStatTitle3;
        private Label lblTotalCustomers;
        private Panel pnlStatCard4;
        private Label lblStatTitle4;
        private Label lblLowStock;
        private Panel pnlRecent;
        private Label lblRecent;
        private DataGridView dgvRecent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            iconLogo = new IconPictureBox();
            lblHeader = new Label();
            btnLogout = new IconButton();
            pnlMenu = new Panel();
            btnManageProducts = new IconButton();
            btnManageOrders = new IconButton();
            btnManageCategories = new IconButton();
            btnManageCustomers = new IconButton();
            btnSalesReports = new IconButton();
            btnAdminRegistrations = new IconButton();
            btnOrderReviews = new IconButton();
            btnManageDiscounts = new IconButton();
            pnlContent = new Panel();
            lblContentTitle = new Label();
            lblContentNote = new Label();
            pnlStats = new Panel();
            pnlStatCard1 = new Panel();
            lblStatTitle1 = new Label();
            lblTotalProducts = new Label();
            pnlStatCard2 = new Panel();
            lblStatTitle2 = new Label();
            lblPendingOrders = new Label();
            pnlStatCard3 = new Panel();
            lblStatTitle3 = new Label();
            lblTotalCustomers = new Label();
            pnlStatCard4 = new Panel();
            lblStatTitle4 = new Label();
            lblLowStock = new Label();
            pnlRecent = new Panel();
            lblRecent = new Label();
            dgvRecent = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconLogo).BeginInit();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlStats.SuspendLayout();
            pnlStatCard1.SuspendLayout();
            pnlStatCard2.SuspendLayout();
            pnlStatCard3.SuspendLayout();
            pnlStatCard4.SuspendLayout();
            pnlRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(34, 139, 34);
            pnlHeader.Controls.Add(iconLogo);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(875, 52);
            pnlHeader.TabIndex = 0;
            // 
            // iconLogo
            // 
            iconLogo.BackColor = Color.Transparent;
            iconLogo.IconChar = IconChar.Leaf;
            iconLogo.IconColor = Color.White;
            iconLogo.IconFont = IconFont.Auto;
            iconLogo.IconSize = 34;
            iconLogo.Location = new Point(13, 9);
            iconLogo.Margin = new Padding(3, 2, 3, 2);
            iconLogo.Name = "iconLogo";
            iconLogo.Size = new Size(39, 34);
            iconLogo.TabIndex = 0;
            iconLogo.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(61, 16);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(316, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Admin Dashboard - Welcome";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.IconChar = IconChar.SignOutAlt;
            btnLogout.IconColor = Color.White;
            btnLogout.IconFont = IconFont.Auto;
            btnLogout.IconSize = 22;
            btnLogout.Location = new Point(761, 13);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(96, 28);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.White;
            pnlMenu.Controls.Add(btnManageProducts);
            pnlMenu.Controls.Add(btnManageOrders);
            pnlMenu.Controls.Add(btnManageCategories);
            pnlMenu.Controls.Add(btnManageCustomers);
            pnlMenu.Controls.Add(btnSalesReports);
            pnlMenu.Controls.Add(btnAdminRegistrations);
            pnlMenu.Controls.Add(btnOrderReviews);
            pnlMenu.Controls.Add(btnManageDiscounts);
            pnlMenu.Dock = DockStyle.Top;
            pnlMenu.Location = new Point(0, 52);
            pnlMenu.Margin = new Padding(3, 2, 3, 2);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(13, 11, 13, 8);
            pnlMenu.Size = new Size(875, 120);
            pnlMenu.TabIndex = 1;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.FromArgb(46, 204, 113);
            btnManageProducts.Cursor = Cursors.Hand;
            btnManageProducts.FlatAppearance.BorderSize = 0;
            btnManageProducts.FlatStyle = FlatStyle.Flat;
            btnManageProducts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnManageProducts.ForeColor = Color.White;
            btnManageProducts.IconChar = IconChar.BoxOpen;
            btnManageProducts.IconColor = Color.White;
            btnManageProducts.IconFont = IconFont.Auto;
            btnManageProducts.IconSize = 28;
            btnManageProducts.Location = new Point(13, 11);
            btnManageProducts.Margin = new Padding(3, 2, 3, 2);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(184, 41);
            btnManageProducts.TabIndex = 0;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += BtnManageProducts_Click;
            // 
            // btnManageOrders
            // 
            btnManageOrders.BackColor = Color.FromArgb(52, 152, 219);
            btnManageOrders.Cursor = Cursors.Hand;
            btnManageOrders.FlatAppearance.BorderSize = 0;
            btnManageOrders.FlatStyle = FlatStyle.Flat;
            btnManageOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnManageOrders.ForeColor = Color.White;
            btnManageOrders.IconChar = IconChar.CartShopping;
            btnManageOrders.IconColor = Color.White;
            btnManageOrders.IconFont = IconFont.Auto;
            btnManageOrders.IconSize = 28;
            btnManageOrders.Location = new Point(201, 11);
            btnManageOrders.Margin = new Padding(3, 2, 3, 2);
            btnManageOrders.Name = "btnManageOrders";
            btnManageOrders.Size = new Size(184, 41);
            btnManageOrders.TabIndex = 1;
            btnManageOrders.Text = "Manage Orders";
            btnManageOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageOrders.UseVisualStyleBackColor = false;
            btnManageOrders.Click += BtnManageOrders_Click;
            // 
            // btnManageCategories
            // 
            btnManageCategories.BackColor = Color.FromArgb(155, 89, 182);
            btnManageCategories.Cursor = Cursors.Hand;
            btnManageCategories.FlatAppearance.BorderSize = 0;
            btnManageCategories.FlatStyle = FlatStyle.Flat;
            btnManageCategories.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnManageCategories.ForeColor = Color.White;
            btnManageCategories.IconChar = IconChar.Tags;
            btnManageCategories.IconColor = Color.White;
            btnManageCategories.IconFont = IconFont.Auto;
            btnManageCategories.IconSize = 28;
            btnManageCategories.Location = new Point(389, 11);
            btnManageCategories.Margin = new Padding(3, 2, 3, 2);
            btnManageCategories.Name = "btnManageCategories";
            btnManageCategories.Size = new Size(184, 41);
            btnManageCategories.TabIndex = 2;
            btnManageCategories.Text = "Manage Categories";
            btnManageCategories.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageCategories.UseVisualStyleBackColor = false;
            btnManageCategories.Click += BtnManageCategories_Click;
            // 
            // btnManageCustomers
            // 
            btnManageCustomers.BackColor = Color.FromArgb(26, 188, 156);
            btnManageCustomers.Cursor = Cursors.Hand;
            btnManageCustomers.FlatAppearance.BorderSize = 0;
            btnManageCustomers.FlatStyle = FlatStyle.Flat;
            btnManageCustomers.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnManageCustomers.ForeColor = Color.White;
            btnManageCustomers.IconChar = IconChar.UserFriends;
            btnManageCustomers.IconColor = Color.White;
            btnManageCustomers.IconFont = IconFont.Auto;
            btnManageCustomers.IconSize = 28;
            btnManageCustomers.Location = new Point(578, 11);
            btnManageCustomers.Margin = new Padding(3, 2, 3, 2);
            btnManageCustomers.Name = "btnManageCustomers";
            btnManageCustomers.Size = new Size(184, 41);
            btnManageCustomers.TabIndex = 3;
            btnManageCustomers.Text = "Manage Customers";
            btnManageCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageCustomers.UseVisualStyleBackColor = false;
            btnManageCustomers.Click += BtnManageCustomers_Click;
            // 
            // btnSalesReports
            // 
            btnSalesReports.BackColor = Color.FromArgb(52, 73, 94);
            btnSalesReports.Cursor = Cursors.Hand;
            btnSalesReports.FlatAppearance.BorderSize = 0;
            btnSalesReports.FlatStyle = FlatStyle.Flat;
            btnSalesReports.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalesReports.ForeColor = Color.White;
            btnSalesReports.IconChar = IconChar.ChartLine;
            btnSalesReports.IconColor = Color.White;
            btnSalesReports.IconFont = IconFont.Auto;
            btnSalesReports.IconSize = 28;
            btnSalesReports.Location = new Point(13, 60);
            btnSalesReports.Margin = new Padding(3, 2, 3, 2);
            btnSalesReports.Name = "btnSalesReports";
            btnSalesReports.Size = new Size(184, 41);
            btnSalesReports.TabIndex = 4;
            btnSalesReports.Text = "Sales Reports";
            btnSalesReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalesReports.UseVisualStyleBackColor = false;
            btnSalesReports.Click += BtnSalesReports_Click;
            // 
            // btnAdminRegistrations
            // 
            btnAdminRegistrations.BackColor = Color.FromArgb(230, 126, 34);
            btnAdminRegistrations.Cursor = Cursors.Hand;
            btnAdminRegistrations.FlatAppearance.BorderSize = 0;
            btnAdminRegistrations.FlatStyle = FlatStyle.Flat;
            btnAdminRegistrations.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdminRegistrations.ForeColor = Color.White;
            btnAdminRegistrations.IconChar = IconChar.UserShield;
            btnAdminRegistrations.IconColor = Color.White;
            btnAdminRegistrations.IconFont = IconFont.Auto;
            btnAdminRegistrations.IconSize = 28;
            btnAdminRegistrations.Location = new Point(201, 60);
            btnAdminRegistrations.Margin = new Padding(3, 2, 3, 2);
            btnAdminRegistrations.Name = "btnAdminRegistrations";
            btnAdminRegistrations.Size = new Size(184, 41);
            btnAdminRegistrations.TabIndex = 5;
            btnAdminRegistrations.Text = "Admin Registrations";
            btnAdminRegistrations.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdminRegistrations.UseVisualStyleBackColor = false;
            btnAdminRegistrations.Click += BtnAdminRegistrations_Click;
            // 
            // btnOrderReviews
            // 
            btnOrderReviews.BackColor = Color.FromArgb(39, 174, 96);
            btnOrderReviews.Cursor = Cursors.Hand;
            btnOrderReviews.FlatAppearance.BorderSize = 0;
            btnOrderReviews.FlatStyle = FlatStyle.Flat;
            btnOrderReviews.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOrderReviews.ForeColor = Color.White;
            btnOrderReviews.IconChar = IconChar.Star;
            btnOrderReviews.IconColor = Color.White;
            btnOrderReviews.IconFont = IconFont.Auto;
            btnOrderReviews.IconSize = 28;
            btnOrderReviews.Location = new Point(389, 60);
            btnOrderReviews.Margin = new Padding(3, 2, 3, 2);
            btnOrderReviews.Name = "btnOrderReviews";
            btnOrderReviews.Size = new Size(184, 41);
            btnOrderReviews.TabIndex = 6;
            btnOrderReviews.Text = "Order Reviews";
            btnOrderReviews.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrderReviews.UseVisualStyleBackColor = false;
            btnOrderReviews.Click += BtnOrderReviews_Click;
            // 
            // btnManageDiscounts
            // 
            btnManageDiscounts.BackColor = Color.FromArgb(211, 84, 0);
            btnManageDiscounts.Cursor = Cursors.Hand;
            btnManageDiscounts.FlatAppearance.BorderSize = 0;
            btnManageDiscounts.FlatStyle = FlatStyle.Flat;
            btnManageDiscounts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnManageDiscounts.ForeColor = Color.White;
            btnManageDiscounts.IconChar = IconChar.Tag;
            btnManageDiscounts.IconColor = Color.White;
            btnManageDiscounts.IconFont = IconFont.Auto;
            btnManageDiscounts.IconSize = 28;
            btnManageDiscounts.Location = new Point(578, 60);
            btnManageDiscounts.Margin = new Padding(3, 2, 3, 2);
            btnManageDiscounts.Name = "btnManageDiscounts";
            btnManageDiscounts.Size = new Size(184, 41);
            btnManageDiscounts.TabIndex = 7;
            btnManageDiscounts.Text = "Manage Discounts";
            btnManageDiscounts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageDiscounts.UseVisualStyleBackColor = false;
            btnManageDiscounts.Click += BtnManageDiscounts_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(lblContentTitle);
            pnlContent.Controls.Add(lblContentNote);
            pnlContent.Dock = DockStyle.Top;
            pnlContent.Location = new Point(0, 172);
            pnlContent.Margin = new Padding(3, 2, 3, 2);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(13, 8, 13, 8);
            pnlContent.Size = new Size(875, 60);
            pnlContent.TabIndex = 2;
            // 
            // lblContentTitle
            // 
            lblContentTitle.AutoSize = true;
            lblContentTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblContentTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblContentTitle.Location = new Point(9, 8);
            lblContentTitle.Name = "lblContentTitle";
            lblContentTitle.Size = new Size(115, 21);
            lblContentTitle.TabIndex = 0;
            lblContentTitle.Text = "Quick Actions";
            // 
            // lblContentNote
            // 
            lblContentNote.AutoSize = true;
            lblContentNote.Font = new Font("Segoe UI", 9F);
            lblContentNote.ForeColor = Color.FromArgb(127, 140, 141);
            lblContentNote.Location = new Point(9, 28);
            lblContentNote.Name = "lblContentNote";
            lblContentNote.Size = new Size(352, 15);
            lblContentNote.TabIndex = 1;
            lblContentNote.Text = "Use the menu below to access management sections and reports.";
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.FromArgb(245, 245, 245);
            pnlStats.Controls.Add(pnlStatCard1);
            pnlStats.Controls.Add(pnlStatCard2);
            pnlStats.Controls.Add(pnlStatCard3);
            pnlStats.Controls.Add(pnlStatCard4);
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(0, 232);
            pnlStats.Margin = new Padding(3, 2, 3, 2);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(13, 8, 13, 8);
            pnlStats.Size = new Size(875, 105);
            pnlStats.TabIndex = 3;
            // 
            // pnlStatCard1
            // 
            pnlStatCard1.BackColor = Color.White;
            pnlStatCard1.Controls.Add(lblStatTitle1);
            pnlStatCard1.Controls.Add(lblTotalProducts);
            pnlStatCard1.Location = new Point(13, 8);
            pnlStatCard1.Margin = new Padding(3, 2, 3, 2);
            pnlStatCard1.Name = "pnlStatCard1";
            pnlStatCard1.Size = new Size(201, 90);
            pnlStatCard1.TabIndex = 0;
            // 
            // lblStatTitle1
            // 
            lblStatTitle1.Font = new Font("Segoe UI", 10F);
            lblStatTitle1.ForeColor = Color.FromArgb(127, 140, 141);
            lblStatTitle1.Location = new Point(61, 19);
            lblStatTitle1.Name = "lblStatTitle1";
            lblStatTitle1.Size = new Size(131, 19);
            lblStatTitle1.TabIndex = 1;
            lblStatTitle1.Text = "Total Products";
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalProducts.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotalProducts.Location = new Point(61, 41);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(131, 38);
            lblTotalProducts.TabIndex = 0;
            lblTotalProducts.Text = "0";
            lblTotalProducts.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStatCard2
            // 
            pnlStatCard2.BackColor = Color.White;
            pnlStatCard2.Controls.Add(lblStatTitle2);
            pnlStatCard2.Controls.Add(lblPendingOrders);
            pnlStatCard2.Location = new Point(228, 8);
            pnlStatCard2.Margin = new Padding(3, 2, 3, 2);
            pnlStatCard2.Name = "pnlStatCard2";
            pnlStatCard2.Size = new Size(201, 90);
            pnlStatCard2.TabIndex = 1;
            // 
            // lblStatTitle2
            // 
            lblStatTitle2.Font = new Font("Segoe UI", 10F);
            lblStatTitle2.ForeColor = Color.FromArgb(127, 140, 141);
            lblStatTitle2.Location = new Point(61, 19);
            lblStatTitle2.Name = "lblStatTitle2";
            lblStatTitle2.Size = new Size(131, 19);
            lblStatTitle2.TabIndex = 1;
            lblStatTitle2.Text = "Pending Orders";
            // 
            // lblPendingOrders
            // 
            lblPendingOrders.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblPendingOrders.ForeColor = Color.FromArgb(52, 73, 94);
            lblPendingOrders.Location = new Point(61, 41);
            lblPendingOrders.Name = "lblPendingOrders";
            lblPendingOrders.Size = new Size(131, 38);
            lblPendingOrders.TabIndex = 0;
            lblPendingOrders.Text = "0";
            lblPendingOrders.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStatCard3
            // 
            pnlStatCard3.BackColor = Color.White;
            pnlStatCard3.Controls.Add(lblStatTitle3);
            pnlStatCard3.Controls.Add(lblTotalCustomers);
            pnlStatCard3.Location = new Point(442, 8);
            pnlStatCard3.Margin = new Padding(3, 2, 3, 2);
            pnlStatCard3.Name = "pnlStatCard3";
            pnlStatCard3.Size = new Size(201, 90);
            pnlStatCard3.TabIndex = 2;
            // 
            // lblStatTitle3
            // 
            lblStatTitle3.Font = new Font("Segoe UI", 10F);
            lblStatTitle3.ForeColor = Color.FromArgb(127, 140, 141);
            lblStatTitle3.Location = new Point(61, 19);
            lblStatTitle3.Name = "lblStatTitle3";
            lblStatTitle3.Size = new Size(131, 19);
            lblStatTitle3.TabIndex = 1;
            lblStatTitle3.Text = "Total Customers";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalCustomers.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotalCustomers.Location = new Point(61, 41);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(131, 38);
            lblTotalCustomers.TabIndex = 0;
            lblTotalCustomers.Text = "0";
            lblTotalCustomers.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStatCard4
            // 
            pnlStatCard4.BackColor = Color.White;
            pnlStatCard4.Controls.Add(lblStatTitle4);
            pnlStatCard4.Controls.Add(lblLowStock);
            pnlStatCard4.Location = new Point(656, 8);
            pnlStatCard4.Margin = new Padding(3, 2, 3, 2);
            pnlStatCard4.Name = "pnlStatCard4";
            pnlStatCard4.Size = new Size(201, 90);
            pnlStatCard4.TabIndex = 3;
            // 
            // lblStatTitle4
            // 
            lblStatTitle4.Font = new Font("Segoe UI", 10F);
            lblStatTitle4.ForeColor = Color.FromArgb(127, 140, 141);
            lblStatTitle4.Location = new Point(61, 19);
            lblStatTitle4.Name = "lblStatTitle4";
            lblStatTitle4.Size = new Size(131, 19);
            lblStatTitle4.TabIndex = 1;
            lblStatTitle4.Text = "Low Stock Items";
            // 
            // lblLowStock
            // 
            lblLowStock.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblLowStock.ForeColor = Color.FromArgb(52, 73, 94);
            lblLowStock.Location = new Point(61, 41);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(131, 38);
            lblLowStock.TabIndex = 0;
            lblLowStock.Text = "0";
            lblLowStock.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRecent
            // 
            pnlRecent.AutoScroll = true;
            pnlRecent.BackColor = Color.White;
            pnlRecent.Controls.Add(lblRecent);
            pnlRecent.Controls.Add(dgvRecent);
            pnlRecent.Dock = DockStyle.Fill;
            pnlRecent.Location = new Point(0, 337);
            pnlRecent.Margin = new Padding(3, 2, 3, 2);
            pnlRecent.Name = "pnlRecent";
            pnlRecent.Padding = new Padding(13, 11, 13, 11);
            pnlRecent.Size = new Size(875, 188);
            pnlRecent.TabIndex = 4;
            // 
            // lblRecent
            // 
            lblRecent.AutoSize = true;
            lblRecent.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRecent.ForeColor = Color.FromArgb(52, 73, 94);
            lblRecent.Location = new Point(13, 11);
            lblRecent.Name = "lblRecent";
            lblRecent.Size = new Size(137, 25);
            lblRecent.TabIndex = 0;
            lblRecent.Text = "Recent Orders";
            // 
            // dgvRecent
            // 
            dgvRecent.AllowUserToAddRows = false;
            dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecent.BackgroundColor = Color.White;
            dgvRecent.BorderStyle = BorderStyle.None;
            dgvRecent.ColumnHeadersHeight = 40;
            dgvRecent.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvRecent.Location = new Point(17, -3);
            dgvRecent.Margin = new Padding(3, 2, 3, 2);
            dgvRecent.Name = "dgvRecent";
            dgvRecent.ReadOnly = true;
            dgvRecent.RowHeadersVisible = false;
            dgvRecent.RowTemplate.Height = 35;
            dgvRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecent.Size = new Size(831, 188);
            dgvRecent.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Order #";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Customer";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Status";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Amount";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Date";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // AdminDashboardEcommerce
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(875, 525);
            Controls.Add(pnlRecent);
            Controls.Add(pnlStats);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminDashboardEcommerce";
            Text = "Admin Dashboard - GreenLife Organic Store";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconLogo).EndInit();
            pnlMenu.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlStats.ResumeLayout(false);
            pnlStatCard1.ResumeLayout(false);
            pnlStatCard2.ResumeLayout(false);
            pnlStatCard3.ResumeLayout(false);
            pnlStatCard4.ResumeLayout(false);
            pnlRecent.ResumeLayout(false);
            pnlRecent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
