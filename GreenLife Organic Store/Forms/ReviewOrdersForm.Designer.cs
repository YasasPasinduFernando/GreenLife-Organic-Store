namespace GreenLife_Organic_Store.Forms
{
    partial class ReviewOrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvOrders;
        private Label lblReviewStatus;
        private NumericUpDown numRating;
        private TextBox txtComment;
        private Button btnSaveReview;
        private Button btnClose;
        private Label lblRating;
        private Label lblComment;

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
            dgvOrders = new DataGridView();
            lblReviewStatus = new Label();
            numRating = new NumericUpDown();
            txtComment = new TextBox();
            btnSaveReview = new Button();
            btnClose = new Button();
            lblRating = new Label();
            lblComment = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 12);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(760, 260);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // Columns
            // 
            var colOrderId = new DataGridViewTextBoxColumn();
            colOrderId.Name = "colOrderId";
            colOrderId.HeaderText = "Order ID";
            colOrderId.Visible = false;
            dgvOrders.Columns.Add(colOrderId);

            var colOrderNumber = new DataGridViewTextBoxColumn();
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.HeaderText = "Order #";
            dgvOrders.Columns.Add(colOrderNumber);

            var colOrderDate = new DataGridViewTextBoxColumn();
            colOrderDate.Name = "colOrderDate";
            colOrderDate.HeaderText = "Order Date";
            dgvOrders.Columns.Add(colOrderDate);

            var colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "colTotal";
            colTotal.HeaderText = "Total";
            dgvOrders.Columns.Add(colTotal);

            var colRating = new DataGridViewTextBoxColumn();
            colRating.Name = "colRating";
            colRating.HeaderText = "Rating";
            dgvOrders.Columns.Add(colRating);

            var colComment = new DataGridViewTextBoxColumn();
            colComment.Name = "colComment";
            colComment.HeaderText = "Comment";
            dgvOrders.Columns.Add(colComment);

            var colReviewDate = new DataGridViewTextBoxColumn();
            colReviewDate.Name = "colReviewDate";
            colReviewDate.HeaderText = "Review Date";
            dgvOrders.Columns.Add(colReviewDate);

            // 
            // lblReviewStatus
            // 
            lblReviewStatus.AutoSize = true;
            lblReviewStatus.Location = new Point(12, 285);
            lblReviewStatus.Name = "lblReviewStatus";
            lblReviewStatus.Size = new Size(84, 15);
            lblReviewStatus.TabIndex = 1;
            lblReviewStatus.Text = "Not reviewed";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Location = new Point(12, 315);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(43, 15);
            lblRating.TabIndex = 2;
            lblRating.Text = "Rating";
            // 
            // numRating
            // 
            numRating.Location = new Point(70, 312);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(60, 23);
            numRating.TabIndex = 3;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new Point(12, 350);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(62, 15);
            lblComment.TabIndex = 4;
            lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.Location = new Point(12, 370);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(760, 80);
            txtComment.TabIndex = 5;
            // 
            // btnSaveReview
            // 
            btnSaveReview.Location = new Point(12, 460);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(120, 30);
            btnSaveReview.TabIndex = 6;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.UseVisualStyleBackColor = true;
            btnSaveReview.Click += btnSaveReview_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(652, 460);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 30);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ReviewOrdersForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(784, 511);
            Controls.Add(btnClose);
            Controls.Add(btnSaveReview);
            Controls.Add(txtComment);
            Controls.Add(lblComment);
            Controls.Add(numRating);
            Controls.Add(lblRating);
            Controls.Add(lblReviewStatus);
            Controls.Add(dgvOrders);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReviewOrdersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Review Orders";
            Load += ReviewOrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
