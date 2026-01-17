namespace GreenLife_Organic_Store.Forms
{
    partial class AdminOrderReviewsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvReviews;
        private Button btnRefresh;
        private Button btnClose;
        private Label lblItems;
        private FlowLayoutPanel flpItems;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvReviews = new DataGridView();
            btnRefresh = new Button();
            btnClose = new Button();
            lblItems = new Label();
            flpItems = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();
            // 
            // dgvReviews
            // 
            dgvReviews.AllowUserToAddRows = false;
            dgvReviews.AllowUserToDeleteRows = false;
            dgvReviews.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.Location = new Point(12, 12);
            dgvReviews.MultiSelect = false;
            dgvReviews.Name = "dgvReviews";
            dgvReviews.ReadOnly = true;
            dgvReviews.RowHeadersVisible = false;
            dgvReviews.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReviews.Size = new Size(760, 260);
            dgvReviews.TabIndex = 0;
            dgvReviews.SelectionChanged += dgvReviews_SelectionChanged;
            // 
            // Columns
            // 
            var colReviewId = new DataGridViewTextBoxColumn();
            colReviewId.Name = "colReviewId";
            colReviewId.HeaderText = "Review ID";
            colReviewId.Visible = false;
            dgvReviews.Columns.Add(colReviewId);

            var colOrderId = new DataGridViewTextBoxColumn();
            colOrderId.Name = "colOrderId";
            colOrderId.HeaderText = "Order ID";
            colOrderId.Visible = false;
            dgvReviews.Columns.Add(colOrderId);

            var colOrderNumber = new DataGridViewTextBoxColumn();
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.HeaderText = "Order #";
            dgvReviews.Columns.Add(colOrderNumber);

            var colCustomerName = new DataGridViewTextBoxColumn();
            colCustomerName.Name = "colCustomerName";
            colCustomerName.HeaderText = "Customer";
            dgvReviews.Columns.Add(colCustomerName);

            var colRating = new DataGridViewTextBoxColumn();
            colRating.Name = "colRating";
            colRating.HeaderText = "Rating";
            dgvReviews.Columns.Add(colRating);

            var colComment = new DataGridViewTextBoxColumn();
            colComment.Name = "colComment";
            colComment.HeaderText = "Comment";
            dgvReviews.Columns.Add(colComment);

            var colUpdated = new DataGridViewTextBoxColumn();
            colUpdated.Name = "colUpdated";
            colUpdated.HeaderText = "Updated";
            dgvReviews.Columns.Add(colUpdated);

            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.Location = new Point(12, 285);
            lblItems.Name = "lblItems";
            lblItems.Size = new Size(69, 15);
            lblItems.TabIndex = 1;
            lblItems.Text = "Order Items";
            // 
            // flpItems
            // 
            flpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpItems.AutoScroll = true;
            flpItems.Location = new Point(12, 305);
            flpItems.Name = "flpItems";
            flpItems.Size = new Size(760, 170);
            flpItems.TabIndex = 2;
            flpItems.WrapContents = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(12, 485);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(662, 485);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 30);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // AdminOrderReviewsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(784, 531);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(flpItems);
            Controls.Add(lblItems);
            Controls.Add(dgvReviews);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminOrderReviewsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Reviews";
            Load += AdminOrderReviewsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
