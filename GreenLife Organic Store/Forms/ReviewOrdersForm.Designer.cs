namespace GreenLife_Organic_Store.Forms
{
    partial class ReviewOrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvOrders;
        private Label lblReviewStatus;
        private NumericUpDown numRating;
        private TextBox txtComment;
        private FontAwesome.Sharp.IconButton btnSaveReview;
        private FontAwesome.Sharp.IconButton btnClose;
        private Label lblRating;
        private Label lblComment;
        private FlowLayoutPanel flpItems;
        private Label lblItems;

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
            btnSaveReview = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            lblRating = new Label();
            lblComment = new Label();
            flpItems = new FlowLayoutPanel();
            lblItems = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            
            // dgvOrders
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeight = 35;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 134, 89);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvOrders.Location = new Point(15, 15);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(750, 230);
            dgvOrders.TabIndex = 0;
            dgvOrders.BorderStyle = BorderStyle.FixedSingle;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            
            // Columns
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

            // lblReviewStatus
            lblReviewStatus.AutoSize = true;
            lblReviewStatus.Location = new Point(15, 255);
            lblReviewStatus.Name = "lblReviewStatus";
            lblReviewStatus.Font = new Font("Segoe UI", 9F);
            lblReviewStatus.ForeColor = Color.FromArgb(117, 117, 117);
            lblReviewStatus.Size = new Size(84, 15);
            lblReviewStatus.TabIndex = 1;
            lblReviewStatus.Text = "Not reviewed";
            
            // lblItems
            lblItems.AutoSize = true;
            lblItems.Location = new Point(15, 280);
            lblItems.Name = "lblItems";
            lblItems.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblItems.ForeColor = Color.FromArgb(45, 134, 89);
            lblItems.Size = new Size(70, 15);
            lblItems.TabIndex = 2;
            lblItems.Text = "Order Items";
            
            // flpItems
            flpItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpItems.AutoScroll = true;
            flpItems.BackColor = Color.White;
            flpItems.BorderStyle = BorderStyle.FixedSingle;
            flpItems.Location = new Point(15, 300);
            flpItems.Name = "flpItems";
            flpItems.Padding = new Padding(5);
            flpItems.Size = new Size(750, 80);
            flpItems.TabIndex = 3;
            
            // lblRating
            lblRating.AutoSize = true;
            lblRating.Location = new Point(15, 395);
            lblRating.Name = "lblRating";
            lblRating.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRating.Size = new Size(43, 15);
            lblRating.TabIndex = 4;
            lblRating.Text = "Rating";
            
            // numRating
            numRating.Location = new Point(80, 390);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(70, 25);
            numRating.TabIndex = 5;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Font = new Font("Segoe UI", 9F);
            
            // lblComment
            lblComment.AutoSize = true;
            lblComment.Location = new Point(15, 425);
            lblComment.Name = "lblComment";
            lblComment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblComment.Size = new Size(62, 15);
            lblComment.TabIndex = 6;
            lblComment.Text = "Comment";
            
            // txtComment
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.Location = new Point(15, 445);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Font = new Font("Segoe UI", 9F);
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Size = new Size(750, 70);
            txtComment.TabIndex = 7;
            
            // btnSaveReview
            btnSaveReview.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveReview.IconColor = Color.White;
            btnSaveReview.ForeColor = Color.White;
            btnSaveReview.BackColor = Color.FromArgb(45, 134, 89);
            btnSaveReview.IconSize = 18;
            btnSaveReview.Location = new Point(15, 525);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(120, 36);
            btnSaveReview.TabIndex = 8;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveReview.UseVisualStyleBackColor = false;
            btnSaveReview.FlatStyle = FlatStyle.Flat;
            btnSaveReview.FlatAppearance.BorderSize = 0;
            btnSaveReview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveReview.Click += btnSaveReview_Click;
            
            // btnClose
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            btnClose.IconColor = Color.White;
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.IconSize = 18;
            btnClose.Location = new Point(645, 525);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 36);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.Click += btnClose_Click;
            
            // ReviewOrdersForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(780, 580);
            Font = new Font("Segoe UI", 9F);
            Padding = new Padding(10);
            Controls.Add(btnClose);
            Controls.Add(btnSaveReview);
            Controls.Add(txtComment);
            Controls.Add(lblComment);
            Controls.Add(numRating);
            Controls.Add(lblRating);
            Controls.Add(flpItems);
            Controls.Add(lblItems);
            Controls.Add(lblReviewStatus);
            Controls.Add(dgvOrders);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimumSize = new Size(780, 580);
            Name = "ReviewOrdersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Review Orders - GreenLife";
            Load += ReviewOrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
