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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvOrders = new DataGridView();
            colOrderId = new DataGridViewTextBoxColumn();
            colOrderNumber = new DataGridViewTextBoxColumn();
            colOrderDate = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colRating = new DataGridViewTextBoxColumn();
            colComment = new DataGridViewTextBoxColumn();
            colReviewDate = new DataGridViewTextBoxColumn();
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
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 134, 89);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvOrders.ColumnHeadersHeight = 35;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colOrderId, colOrderNumber, colOrderDate, colTotal, colRating, colComment, colReviewDate });
            dgvOrders.Location = new Point(13, 11);
            dgvOrders.Margin = new Padding(3, 2, 3, 2);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(656, 172);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // colOrderId
            // 
            colOrderId.HeaderText = "Order ID";
            colOrderId.Name = "colOrderId";
            colOrderId.ReadOnly = true;
            colOrderId.Visible = false;
            // 
            // colOrderNumber
            // 
            colOrderNumber.HeaderText = "Order #";
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.ReadOnly = true;
            // 
            // colOrderDate
            // 
            colOrderDate.HeaderText = "Order Date";
            colOrderDate.Name = "colOrderDate";
            colOrderDate.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colRating
            // 
            colRating.HeaderText = "Rating";
            colRating.Name = "colRating";
            colRating.ReadOnly = true;
            // 
            // colComment
            // 
            colComment.HeaderText = "Comment";
            colComment.Name = "colComment";
            colComment.ReadOnly = true;
            // 
            // colReviewDate
            // 
            colReviewDate.HeaderText = "Review Date";
            colReviewDate.Name = "colReviewDate";
            colReviewDate.ReadOnly = true;
            // 
            // lblReviewStatus
            // 
            lblReviewStatus.AutoSize = true;
            lblReviewStatus.Font = new Font("Segoe UI", 9F);
            lblReviewStatus.ForeColor = Color.FromArgb(117, 117, 117);
            lblReviewStatus.Location = new Point(13, 191);
            lblReviewStatus.Name = "lblReviewStatus";
            lblReviewStatus.Size = new Size(77, 15);
            lblReviewStatus.TabIndex = 1;
            lblReviewStatus.Text = "Not reviewed";
            // 
            // numRating
            // 
            numRating.Font = new Font("Segoe UI", 9F);
            numRating.Location = new Point(70, 436);
            numRating.Margin = new Padding(3, 2, 3, 2);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(61, 23);
            numRating.TabIndex = 5;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // txtComment
            // 
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Font = new Font("Segoe UI", 9F);
            txtComment.Location = new Point(14, 498);
            txtComment.Margin = new Padding(3, 2, 3, 2);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(656, 81);
            txtComment.TabIndex = 7;
            // 
            // btnSaveReview
            // 
            btnSaveReview.BackColor = Color.FromArgb(45, 134, 89);
            btnSaveReview.FlatAppearance.BorderSize = 0;
            btnSaveReview.FlatStyle = FlatStyle.Flat;
            btnSaveReview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveReview.ForeColor = Color.White;
            btnSaveReview.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveReview.IconColor = Color.White;
            btnSaveReview.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveReview.IconSize = 18;
            btnSaveReview.Location = new Point(14, 597);
            btnSaveReview.Margin = new Padding(3, 2, 3, 2);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(145, 27);
            btnSaveReview.TabIndex = 8;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveReview.UseVisualStyleBackColor = false;
            btnSaveReview.Click += btnSaveReview_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.White;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 18;
            btnClose.Location = new Point(537, 597);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(133, 27);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRating.Location = new Point(13, 440);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(52, 19);
            lblRating.TabIndex = 4;
            lblRating.Text = "Rating";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblComment.Location = new Point(13, 463);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(74, 19);
            lblComment.TabIndex = 6;
            lblComment.Text = "Comment";
            // 
            // flpItems
            // 
            flpItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpItems.AutoScroll = true;
            flpItems.BackColor = Color.White;
            flpItems.BorderStyle = BorderStyle.FixedSingle;
            flpItems.Location = new Point(13, 231);
            flpItems.Margin = new Padding(3, 2, 3, 2);
            flpItems.Name = "flpItems";
            flpItems.Padding = new Padding(4, 4, 4, 4);
            flpItems.Size = new Size(656, 201);
            flpItems.TabIndex = 3;
            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblItems.ForeColor = Color.FromArgb(45, 134, 89);
            lblItems.Location = new Point(13, 210);
            lblItems.Name = "lblItems";
            lblItems.Size = new Size(89, 19);
            lblItems.TabIndex = 2;
            lblItems.Text = "Order Items";
            // 
            // ReviewOrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(682, 631);
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
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimumSize = new Size(684, 445);
            Name = "ReviewOrdersForm";
            Padding = new Padding(9, 8, 9, 8);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Review Orders - GreenLife";
            Load += ReviewOrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridViewTextBoxColumn colOrderId;
        private DataGridViewTextBoxColumn colOrderNumber;
        private DataGridViewTextBoxColumn colOrderDate;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colRating;
        private DataGridViewTextBoxColumn colComment;
        private DataGridViewTextBoxColumn colReviewDate;
    }
}
