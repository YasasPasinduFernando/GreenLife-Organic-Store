using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class OrderDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private IconPictureBox headerIcon;
        private Label lblOrderHeader;
        private Label lblOrderDateLabel;
        private Label lblOrderDate;
        private Label lblStatusLabel;
        private Label lblStatus;
        private Panel pnlProgress;
        private Label lblItemsHeader;
        private DataGridView dgvItems;
        private Label lblTotalLabel;
        private Label lblTotal;
        private Label lblDeliveryHeader;
        private Label lblNameLabel;
        private Label lblName;
        private Label lblPhoneLabel;
        private Label lblPhone;
        private Label lblEmailLabel;
        private Label lblEmail;
        private Label lblAddressLabel;
        private Label lblAddress;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            headerIcon = new IconPictureBox();
            lblOrderHeader = new Label();
            lblOrderDateLabel = new Label();
            lblOrderDate = new Label();
            lblStatusLabel = new Label();
            lblStatus = new Label();
            pnlProgress = new Panel();
            lblItemsHeader = new Label();
            dgvItems = new DataGridView();
            lblTotalLabel = new Label();
            lblTotal = new Label();
            lblDeliveryHeader = new Label();
            lblNameLabel = new Label();
            lblName = new Label();
            lblPhoneLabel = new Label();
            lblPhone = new Label();
            lblEmailLabel = new Label();
            lblEmail = new Label();
            lblAddressLabel = new Label();
            lblAddress = new Label();
            btnClose = new Button();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headerIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // pnlMain
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.Transparent;
            pnlMain.Controls.Add(headerIcon);
            pnlMain.Controls.Add(lblOrderHeader);
            pnlMain.Controls.Add(lblOrderDateLabel);
            pnlMain.Controls.Add(lblOrderDate);
            pnlMain.Controls.Add(lblStatusLabel);
            pnlMain.Controls.Add(lblStatus);
            pnlMain.Controls.Add(pnlProgress);
            pnlMain.Controls.Add(lblItemsHeader);
            pnlMain.Controls.Add(dgvItems);
            pnlMain.Controls.Add(lblTotalLabel);
            pnlMain.Controls.Add(lblTotal);
            pnlMain.Controls.Add(lblDeliveryHeader);
            pnlMain.Controls.Add(lblNameLabel);
            pnlMain.Controls.Add(lblName);
            pnlMain.Controls.Add(lblPhoneLabel);
            pnlMain.Controls.Add(lblPhone);
            pnlMain.Controls.Add(lblEmailLabel);
            pnlMain.Controls.Add(lblEmail);
            pnlMain.Controls.Add(lblAddressLabel);
            pnlMain.Controls.Add(lblAddress);
            pnlMain.Controls.Add(btnClose);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(700, 650);
            pnlMain.TabIndex = 0;
            // headerIcon
            headerIcon.BackColor = Color.Transparent;
            headerIcon.IconChar = IconChar.ShoppingBag;
            headerIcon.IconColor = Color.FromArgb(34, 139, 34);
            headerIcon.IconSize = 28;
            headerIcon.Location = new Point(10, 8);
            headerIcon.Name = "headerIcon";
            headerIcon.Size = new Size(34, 34);
            headerIcon.TabIndex = 0;
            headerIcon.TabStop = false;
            // lblOrderHeader
            lblOrderHeader.AutoSize = true;
            lblOrderHeader.BackColor = Color.Transparent;
            lblOrderHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOrderHeader.ForeColor = Color.FromArgb(34, 139, 34);
            lblOrderHeader.Location = new Point(54, 10);
            lblOrderHeader.Name = "lblOrderHeader";
            lblOrderHeader.Size = new Size(150, 30);
            lblOrderHeader.TabIndex = 1;
            lblOrderHeader.Text = "Order #00000";
            // lblOrderDateLabel
            lblOrderDateLabel.Location = new Point(10, 45);
            lblOrderDateLabel.Name = "lblOrderDateLabel";
            lblOrderDateLabel.Size = new Size(100, 20);
            lblOrderDateLabel.TabIndex = 2;
            lblOrderDateLabel.Text = "Order Date:";
            // lblOrderDate
            lblOrderDate.Location = new Point(120, 45);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(300, 20);
            lblOrderDate.TabIndex = 3;
            lblOrderDate.Text = "—";
            // lblStatusLabel
            lblStatusLabel.AutoSize = true;
            lblStatusLabel.Location = new Point(10, 75);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(50, 20);
            lblStatusLabel.TabIndex = 4;
            lblStatusLabel.Text = "Status:";
            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(120, 75);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 23);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "—";
            // pnlProgress
            pnlProgress.BackColor = Color.White;
            pnlProgress.BorderStyle = BorderStyle.None;
            pnlProgress.Location = new Point(10, 115);
            pnlProgress.Name = "pnlProgress";
            pnlProgress.Size = new Size(680, 70);
            pnlProgress.TabIndex = 6;
            pnlProgress.Paint += PnlProgress_Paint;
            // lblItemsHeader
            lblItemsHeader.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblItemsHeader.ForeColor = Color.DarkGreen;
            lblItemsHeader.Location = new Point(10, 195);
            lblItemsHeader.Name = "lblItemsHeader";
            lblItemsHeader.Size = new Size(300, 20);
            lblItemsHeader.TabIndex = 7;
            lblItemsHeader.Text = "ITEMS ORDERED";
            // dgvItems
            dgvItems.AllowUserToAddRows = false;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(230, 230, 230), ForeColor = Color.FromArgb(34, 34, 34) };
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.GridColor = Color.LightGray;
            dgvItems.ColumnHeadersHeight = 38;
            dgvItems.Location = new Point(10, 225);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowTemplate.Height = 38;
            dgvItems.Size = new Size(680, 180);
            dgvItems.TabIndex = 8;
            dgvItems.Columns.Add("ProductName", "Product");
            dgvItems.Columns.Add("Quantity", "Qty");
            dgvItems.Columns.Add("UnitPrice", "Unit Price");
            dgvItems.Columns.Add("Subtotal", "Subtotal");
            // lblTotalLabel
            lblTotalLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotalLabel.Location = new Point(10, 415);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(100, 25);
            lblTotalLabel.TabIndex = 9;
            lblTotalLabel.Text = "Total:";
            // lblTotal
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(34, 139, 34);
            lblTotal.Location = new Point(120, 415);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(300, 25);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Rs. 0.00";
            // lblDeliveryHeader
            lblDeliveryHeader.BackColor = Color.Transparent;
            lblDeliveryHeader.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblDeliveryHeader.ForeColor = Color.FromArgb(34, 139, 34);
            lblDeliveryHeader.Location = new Point(10, 455);
            lblDeliveryHeader.Name = "lblDeliveryHeader";
            lblDeliveryHeader.Size = new Size(300, 20);
            lblDeliveryHeader.TabIndex = 11;
            lblDeliveryHeader.Text = "DELIVERY INFORMATION";
            // lblNameLabel
            lblNameLabel.Location = new Point(10, 485);
            lblNameLabel.Name = "lblNameLabel";
            lblNameLabel.Size = new Size(100, 20);
            lblNameLabel.TabIndex = 12;
            lblNameLabel.Text = "Name:";
            // lblName
            lblName.Location = new Point(120, 485);
            lblName.Name = "lblName";
            lblName.Size = new Size(400, 20);
            lblName.TabIndex = 13;
            lblName.Text = "—";
            // lblPhoneLabel
            lblPhoneLabel.Location = new Point(10, 510);
            lblPhoneLabel.Name = "lblPhoneLabel";
            lblPhoneLabel.Size = new Size(100, 20);
            lblPhoneLabel.TabIndex = 14;
            lblPhoneLabel.Text = "Phone:";
            // lblPhone
            lblPhone.Location = new Point(120, 510);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(400, 20);
            lblPhone.TabIndex = 15;
            lblPhone.Text = "—";
            // lblEmailLabel
            lblEmailLabel.Location = new Point(10, 535);
            lblEmailLabel.Name = "lblEmailLabel";
            lblEmailLabel.Size = new Size(100, 20);
            lblEmailLabel.TabIndex = 16;
            lblEmailLabel.Text = "Email:";
            // lblEmail
            lblEmail.Location = new Point(120, 535);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(400, 20);
            lblEmail.TabIndex = 17;
            lblEmail.Text = "—";
            // lblAddressLabel
            lblAddressLabel.Location = new Point(10, 560);
            lblAddressLabel.Name = "lblAddressLabel";
            lblAddressLabel.Size = new Size(100, 20);
            lblAddressLabel.TabIndex = 18;
            lblAddressLabel.Text = "Address:";
            // lblAddress
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.Location = new Point(120, 560);
            lblAddress.MaximumSize = new Size(400, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(50, 20);
            lblAddress.TabIndex = 19;
            lblAddress.Text = "—";
            // btnClose
            btnClose.BackColor = Color.LightGray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(290, 630);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 36);
            btnClose.TabIndex = 20;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // OrderDetailsForm
            AutoScroll = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(700, 650);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "OrderDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order Details";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)headerIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
        }
    }
}
