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
        private Panel pnlReview;

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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
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
            pnlReview = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            pnlReview.SuspendLayout();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(45, 134, 89);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvOrders.ColumnHeadersHeight = 35;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colOrderId, colOrderNumber, colOrderDate, colTotal, colRating, colComment, colReviewDate });
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(9, 8);
            dgvOrders.Margin = new Padding(3, 2, 3, 2);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(664, 347);
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
            lblReviewStatus.Location = new Point(9, 6);
            lblReviewStatus.Name = "lblReviewStatus";
            lblReviewStatus.Size = new Size(77, 15);
            lblReviewStatus.TabIndex = 0;
            lblReviewStatus.Text = "Not reviewed";
            // 
            // numRating
            // 
            numRating.Font = new Font("Segoe UI", 9F);
            numRating.Location = new Point(70, 186);
            numRating.Margin = new Padding(3, 2, 3, 2);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(61, 23);
            numRating.TabIndex = 4;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // txtComment
            // 
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Font = new Font("Segoe UI", 9F);
            txtComment.Location = new Point(8, 252);
            txtComment.Margin = new Padding(3, 2, 3, 2);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(647, 117);
            txtComment.TabIndex = 6;
            txtComment.TextChanged += txtComment_TextChanged;
            // 
            // btnSaveReview
            // 
            btnSaveReview.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveReview.BackColor = Color.FromArgb(45, 134, 89);
            btnSaveReview.FlatAppearance.BorderSize = 0;
            btnSaveReview.FlatStyle = FlatStyle.Flat;
            btnSaveReview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveReview.ForeColor = Color.White;
            btnSaveReview.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveReview.IconColor = Color.White;
            btnSaveReview.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveReview.IconSize = 18;
            btnSaveReview.Location = new Point(9, 383);
            btnSaveReview.Margin = new Padding(3, 2, 3, 2);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(147, 27);
            btnSaveReview.TabIndex = 7;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveReview.UseVisualStyleBackColor = false;
            btnSaveReview.Click += btnSaveReview_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.White;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 18;
            btnClose.Location = new Point(445, 383);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(210, 27);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRating.Location = new Point(9, 189);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(52, 19);
            lblRating.TabIndex = 3;
            lblRating.Text = "Rating";
            lblRating.Click += lblRating_Click;
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblComment.Location = new Point(8, 220);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(74, 19);
            lblComment.TabIndex = 5;
            lblComment.Text = "Comment";
            lblComment.Click += lblComment_Click;
            // 
            // flpItems
            // 
            flpItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpItems.AutoScroll = true;
            flpItems.BackColor = Color.White;
            flpItems.BorderStyle = BorderStyle.FixedSingle;
            flpItems.Location = new Point(9, 39);
            flpItems.Margin = new Padding(3, 2, 3, 2);
            flpItems.Name = "flpItems";
            flpItems.Padding = new Padding(4, 4, 4, 4);
            flpItems.Size = new Size(647, 130);
            flpItems.TabIndex = 2;
            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblItems.ForeColor = Color.FromArgb(45, 134, 89);
            lblItems.Location = new Point(9, 22);
            lblItems.Name = "lblItems";
            lblItems.Size = new Size(89, 19);
            lblItems.TabIndex = 1;
            lblItems.Text = "Order Items";
            // 
            // pnlReview
            // 
            pnlReview.BackColor = Color.FromArgb(245, 245, 245);
            pnlReview.Controls.Add(lblReviewStatus);
            pnlReview.Controls.Add(lblItems);
            pnlReview.Controls.Add(flpItems);
            pnlReview.Controls.Add(lblRating);
            pnlReview.Controls.Add(numRating);
            pnlReview.Controls.Add(lblComment);
            pnlReview.Controls.Add(txtComment);
            pnlReview.Controls.Add(btnSaveReview);
            pnlReview.Controls.Add(btnClose);
            pnlReview.Dock = DockStyle.Bottom;
            pnlReview.Location = new Point(9, 355);
            pnlReview.Margin = new Padding(3, 2, 3, 2);
            pnlReview.Name = "pnlReview";
            pnlReview.Size = new Size(664, 418);
            pnlReview.TabIndex = 1;
            // 
            // ReviewOrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(682, 781);
            Controls.Add(dgvOrders);
            Controls.Add(pnlReview);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimumSize = new Size(684, 475);
            Name = "ReviewOrdersForm";
            Padding = new Padding(9, 8, 9, 8);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Review Orders - GreenLife";
            Load += ReviewOrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            pnlReview.ResumeLayout(false);
            pnlReview.PerformLayout();
            ResumeLayout(false);
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
