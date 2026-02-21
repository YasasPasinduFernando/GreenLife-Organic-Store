using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class CheckoutForm
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
            this.lblDeliveryInfo = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.lblOrderSummary = new Label();
            this.dgvItems = new DataGridView();
            this.lblTotal = new Label();
            this.lblNotes = new Label();
            this.txtNotes = new TextBox();
            this.btnCancel = new IconButton();
            this.btnPlaceOrder = new IconButton();
            this.progressBarEmail = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)this.dgvItems).BeginInit();
            this.SuspendLayout();
            // lblDeliveryInfo
            this.lblDeliveryInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblDeliveryInfo.ForeColor = Color.FromArgb(0x2D, 0x86, 0x59);
            this.lblDeliveryInfo.Location = new Point(10, 10);
            this.lblDeliveryInfo.Name = "lblDeliveryInfo";
            this.lblDeliveryInfo.Size = new Size(300, 20);
            this.lblDeliveryInfo.TabIndex = 0;
            this.lblDeliveryInfo.Text = "DELIVERY INFORMATION";
            // lblName
            this.lblName.Location = new Point(10, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(100, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Full Name:";
            // txtName
            this.txtName.Location = new Point(120, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(540, 23);
            this.txtName.TabIndex = 2;
            // lblPhone
            this.lblPhone.Location = new Point(10, 70);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(100, 20);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone:";
            // txtPhone
            this.txtPhone.Location = new Point(120, 70);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new Size(540, 23);
            this.txtPhone.TabIndex = 4;
            // lblEmail
            this.lblEmail.Location = new Point(10, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(100, 20);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // txtEmail
            this.txtEmail.Location = new Point(120, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(540, 23);
            this.txtEmail.TabIndex = 6;
            // lblAddress
            this.lblAddress.Location = new Point(10, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new Size(100, 20);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Address:";
            // txtAddress
            this.txtAddress.Location = new Point(120, 130);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new Size(540, 80);
            this.txtAddress.TabIndex = 8;
            // lblOrderSummary
            this.lblOrderSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblOrderSummary.ForeColor = Color.FromArgb(0x2D, 0x86, 0x59);
            this.lblOrderSummary.Location = new Point(10, 220);
            this.lblOrderSummary.Name = "lblOrderSummary";
            this.lblOrderSummary.Size = new Size(300, 20);
            this.lblOrderSummary.TabIndex = 9;
            this.lblOrderSummary.Text = "ORDER SUMMARY";
            // dgvItems
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackColor = Color.White;
            this.dgvItems.ColumnHeadersHeight = 38;
            this.dgvItems.Location = new Point(10, 250);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowTemplate.Height = 38;
            this.dgvItems.Size = new Size(660, 120);
            this.dgvItems.TabIndex = 10;
            this.dgvItems.Columns.Add("ProductName", "Product");
            this.dgvItems.Columns.Add("Quantity", "Qty");
            this.dgvItems.Columns.Add("UnitPrice", "Unit Price");
            this.dgvItems.Columns.Add("Subtotal", "Subtotal");
            // lblTotal
            this.lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(0x2D, 0x86, 0x59);
            this.lblTotal.Location = new Point(10, 380);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(400, 25);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total Amount: Rs. 0.00";
            // lblNotes
            this.lblNotes.Location = new Point(10, 415);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(100, 20);
            this.lblNotes.TabIndex = 12;
            this.lblNotes.Text = "Notes (Optional):";
            // txtNotes
            this.txtNotes.Location = new Point(10, 440);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new Size(660, 60);
            this.txtNotes.TabIndex = 13;
            // btnCancel
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = Color.Black;
            this.btnCancel.IconChar = IconChar.Times;
            this.btnCancel.IconColor = Color.Black;
            this.btnCancel.IconSize = 18;
            this.btnCancel.Location = new Point(200, 560);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(120, 36);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += this.BtnCancel_Click;
            // btnPlaceOrder
            this.btnPlaceOrder.BackColor = Color.Green;
            this.btnPlaceOrder.Cursor = Cursors.Hand;
            this.btnPlaceOrder.FlatAppearance.BorderSize = 0;
            this.btnPlaceOrder.FlatStyle = FlatStyle.Flat;
            this.btnPlaceOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnPlaceOrder.ForeColor = Color.White;
            this.btnPlaceOrder.IconChar = IconChar.ShoppingCart;
            this.btnPlaceOrder.IconColor = Color.White;
            this.btnPlaceOrder.IconSize = 18;
            this.btnPlaceOrder.Location = new Point(380, 560);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new Size(140, 36);
            this.btnPlaceOrder.TabIndex = 15;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += this.BtnPlaceOrder_Click;
            // progressBarEmail
            this.progressBarEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.progressBarEmail.Location = new Point(20, 612);
            this.progressBarEmail.MarqueeAnimationSpeed = 25;
            this.progressBarEmail.Name = "progressBarEmail";
            this.progressBarEmail.Size = new Size(660, 18);
            this.progressBarEmail.Style = ProgressBarStyle.Marquee;
            this.progressBarEmail.TabIndex = 16;
            this.progressBarEmail.Visible = false;
            // CheckoutForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(684, 701);
            this.Font = new Font("Segoe UI", 9F);
            this.Controls.Add(this.lblDeliveryInfo);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblOrderSummary);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.progressBarEmail);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CheckoutForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Checkout & Place Order";
            ((System.ComponentModel.ISupportInitialize)this.dgvItems).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblDeliveryInfo;
        private Label lblName;
        private TextBox txtName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblOrderSummary;
        private DataGridView dgvItems;
        private Label lblTotal;
        private Label lblNotes;
        private TextBox txtNotes;
        private IconButton btnCancel;
        private IconButton btnPlaceOrder;
        private ProgressBar progressBarEmail;
    }
}
