using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class ShoppingCartForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblHeader;
        private DataGridView _dgvCart;
        private Panel pnlQuantity;
        private Label lblQuantityInfo;
        private IconButton btnDecrement;
        private IconButton btnIncrement;
        private IconButton btnClearCart;
        private Panel pnlSummary;
        private Label lblTotal;
        private Label lblItemCount;
        private IconButton btnContinue;
        private IconButton btnCheckout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeader = new Label();
            _dgvCart = new DataGridView();
            pnlQuantity = new Panel();
            lblQuantityInfo = new Label();
            btnDecrement = new IconButton();
            btnIncrement = new IconButton();
            btnClearCart = new IconButton();
            pnlSummary = new Panel();
            lblTotal = new Label();
            lblItemCount = new Label();
            btnContinue = new IconButton();
            btnCheckout = new IconButton();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvCart).BeginInit();
            pnlQuantity.SuspendLayout();
            pnlSummary.SuspendLayout();
            SuspendLayout();
            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(0x2D, 0x86, 0x59);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(820, 68);
            pnlHeader.TabIndex = 0;
            // lblHeader
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(20, 22);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(320, 24);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Shopping Cart";
            // _dgvCart
            _dgvCart.AllowUserToAddRows = false;
            _dgvCart.AllowUserToDeleteRows = false;
            _dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvCart.BackgroundColor = Color.White;
            _dgvCart.BorderStyle = BorderStyle.FixedSingle;
            _dgvCart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Padding = new Padding(5)
            };
            _dgvCart.ColumnHeadersHeight = 38;
            _dgvCart.EnableHeadersVisualStyles = false;
            _dgvCart.GridColor = Color.LightGray;
            _dgvCart.Location = new Point(20, 76);
            _dgvCart.Name = "dgvCart";
            _dgvCart.ReadOnly = true;
            _dgvCart.RowTemplate.Height = 35;
            _dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvCart.Size = new Size(780, 300);
            _dgvCart.TabIndex = 1;
            _dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            var imgCol = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 64,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            _dgvCart.Columns.Add(imgCol);
            _dgvCart.Columns.Add("ProductName", "Product");
            _dgvCart.Columns.Add("Quantity", "Quantity");
            _dgvCart.Columns.Add("UnitPrice", "Price");
            _dgvCart.Columns.Add("Subtotal", "Subtotal");
            var btnCol = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "Action",
                Text = "Remove",
                UseColumnTextForButtonValue = true,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            _dgvCart.Columns.Add(btnCol);
            _dgvCart.CellClick += DgvCart_CellClick;
            // pnlQuantity
            pnlQuantity.BackColor = Color.White;
            pnlQuantity.BorderStyle = BorderStyle.FixedSingle;
            pnlQuantity.Controls.Add(lblQuantityInfo);
            pnlQuantity.Controls.Add(btnDecrement);
            pnlQuantity.Controls.Add(btnIncrement);
            pnlQuantity.Controls.Add(btnClearCart);
            pnlQuantity.Location = new Point(20, 390);
            pnlQuantity.Name = "pnlQuantity";
            pnlQuantity.Size = new Size(780, 52);
            pnlQuantity.TabIndex = 2;
            pnlQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            // lblQuantityInfo
            lblQuantityInfo.AutoSize = true;
            lblQuantityInfo.Font = new Font("Segoe UI", 9F);
            lblQuantityInfo.ForeColor = Color.FromArgb(52, 73, 94);
            lblQuantityInfo.Location = new Point(10, 14);
            lblQuantityInfo.Name = "lblQuantityInfo";
            lblQuantityInfo.TabIndex = 0;
            lblQuantityInfo.Text = "Adjust quantity for selected row:";
            // btnDecrement
            btnDecrement.BackColor = Color.FromArgb(230, 126, 34);
            btnDecrement.Cursor = Cursors.Hand;
            btnDecrement.FlatStyle = FlatStyle.Flat;
            btnDecrement.FlatAppearance.BorderSize = 0;
            btnDecrement.ForeColor = Color.White;
            btnDecrement.IconChar = IconChar.Minus;
            btnDecrement.IconColor = Color.White;
            btnDecrement.IconSize = 20;
            btnDecrement.Location = new Point(295, 8);
            btnDecrement.Name = "btnDecrement";
            btnDecrement.Size = new Size(44, 36);
            btnDecrement.TabIndex = 1;
            btnDecrement.Text = "";
            btnDecrement.UseVisualStyleBackColor = false;
            btnDecrement.Click += BtnDecrement_Click;
            // btnIncrement
            btnIncrement.BackColor = Color.FromArgb(46, 204, 113);
            btnIncrement.Cursor = Cursors.Hand;
            btnIncrement.FlatStyle = FlatStyle.Flat;
            btnIncrement.FlatAppearance.BorderSize = 0;
            btnIncrement.ForeColor = Color.White;
            btnIncrement.IconChar = IconChar.Plus;
            btnIncrement.IconColor = Color.White;
            btnIncrement.IconSize = 20;
            btnIncrement.Location = new Point(347, 8);
            btnIncrement.Name = "btnIncrement";
            btnIncrement.Size = new Size(44, 36);
            btnIncrement.TabIndex = 2;
            btnIncrement.Text = "";
            btnIncrement.UseVisualStyleBackColor = false;
            btnIncrement.Click += BtnIncrement_Click;
            // btnClearCart
            btnClearCart.BackColor = Color.FromArgb(231, 76, 60);
            btnClearCart.Cursor = Cursors.Hand;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.Font = new Font("Segoe UI", 9F);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.IconChar = IconChar.TrashAlt;
            btnClearCart.IconColor = Color.White;
            btnClearCart.IconSize = 16;
            btnClearCart.Location = new Point(640, 8);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(130, 36);
            btnClearCart.TabIndex = 3;
            btnClearCart.Text = "Clear Cart";
            btnClearCart.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += BtnClearCart_Click;
            // pnlSummary
            pnlSummary.BackColor = Color.FromArgb(240, 255, 240);
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(lblTotal);
            pnlSummary.Controls.Add(lblItemCount);
            pnlSummary.Location = new Point(20, 448);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(780, 52);
            pnlSummary.TabIndex = 3;
            pnlSummary.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            // lblTotal
            lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(34, 139, 34);
            lblTotal.Location = new Point(15, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(340, 32);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: Rs. 0.00";
            lblTotal.UseMnemonic = false;
            // lblItemCount
            lblItemCount.AutoSize = true;
            lblItemCount.Font = new Font("Segoe UI", 11F);
            lblItemCount.ForeColor = Color.FromArgb(52, 73, 94);
            lblItemCount.Location = new Point(370, 14);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.TabIndex = 1;
            lblItemCount.Text = "Items: 0";
            // btnContinue
            btnContinue.BackColor = Color.FromArgb(149, 165, 166);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.Font = new Font("Segoe UI", 9F);
            btnContinue.ForeColor = Color.White;
            btnContinue.IconChar = IconChar.ArrowLeft;
            btnContinue.IconColor = Color.White;
            btnContinue.IconSize = 18;
            btnContinue.Location = new Point(197, 508);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(190, 36);
            btnContinue.TabIndex = 4;
            btnContinue.Text = "Continue Shopping";
            btnContinue.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += BtnContinue_Click;
            btnContinue.Anchor = AnchorStyles.Bottom;
            // btnCheckout
            btnCheckout.BackColor = Color.FromArgb(0x2D, 0x86, 0x59);
            btnCheckout.Cursor = Cursors.Hand;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.Font = new Font("Segoe UI", 9F);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.IconChar = IconChar.CreditCard;
            btnCheckout.IconColor = Color.White;
            btnCheckout.IconSize = 18;
            btnCheckout.Location = new Point(403, 508);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(220, 36);
            btnCheckout.TabIndex = 5;
            btnCheckout.Text = "Proceed to Checkout";
            btnCheckout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += BtnCheckout_Click;
            btnCheckout.Anchor = AnchorStyles.Bottom;
            // ShoppingCartForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(820, 600);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pnlHeader);
            Controls.Add(_dgvCart);
            Controls.Add(pnlQuantity);
            Controls.Add(pnlSummary);
            Controls.Add(btnContinue);
            Controls.Add(btnCheckout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ShoppingCartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shopping Cart";
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvCart).EndInit();
            pnlQuantity.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
