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
            pnlReview = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            
            // dgvOrders
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeight = 35;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 134, 89);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvOrders.Location = new Point(10, 10);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(760, 240);
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

            // pnlReview
            pnlReview.BackColor = Color.FromArgb(245, 245, 245);
            pnlReview.Dock = DockStyle.Bottom;
            pnlReview.Location = new Point(10, 230);
            pnlReview.Name = "pnlReview";
            pnlReview.Size = new Size(760, 340);
            pnlReview.TabIndex = 1;

            // lblReviewStatus
            lblReviewStatus.AutoSize = true;
            lblReviewStatus.Location = new Point(10, 8);
            lblReviewStatus.Name = "lblReviewStatus";
            lblReviewStatus.Font = new Font("Segoe UI", 9F);
            lblReviewStatus.ForeColor = Color.FromArgb(117, 117, 117);
            lblReviewStatus.Size = new Size(84, 15);
            lblReviewStatus.TabIndex = 0;
            lblReviewStatus.Text = "Not reviewed";
            
            // lblItems
            lblItems.AutoSize = true;
            lblItems.Location = new Point(10, 30);
            lblItems.Name = "lblItems";
            lblItems.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblItems.ForeColor = Color.FromArgb(45, 134, 89);
            lblItems.Size = new Size(70, 15);
            lblItems.TabIndex = 1;
            lblItems.Text = "Order Items";
            
            // flpItems
            flpItems.AutoScroll = true;
            flpItems.BackColor = Color.White;
            flpItems.BorderStyle = BorderStyle.FixedSingle;
            flpItems.Location = new Point(10, 52);
            flpItems.Name = "flpItems";
            flpItems.Padding = new Padding(5);
            flpItems.Size = new Size(740, 95);
            flpItems.TabIndex = 2;
            flpItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            // lblRating
            lblRating.AutoSize = true;
            lblRating.Location = new Point(10, 150);
            lblRating.Name = "lblRating";
            lblRating.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRating.Size = new Size(43, 15);
            lblRating.TabIndex = 3;
            lblRating.Text = "Rating";
            
            // numRating
            numRating.Location = new Point(80, 145);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(70, 25);
            numRating.TabIndex = 4;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Font = new Font("Segoe UI", 9F);
            
            // lblComment
            lblComment.AutoSize = true;
            lblComment.Location = new Point(10, 180);
            lblComment.Name = "lblComment";
            lblComment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblComment.Size = new Size(62, 15);
            lblComment.TabIndex = 5;
            lblComment.Text = "Comment";
            
            // txtComment
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.Location = new Point(10, 200);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Font = new Font("Segoe UI", 9F);
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Size = new Size(740, 70);
            txtComment.TabIndex = 6;
            
            // btnSaveReview
            btnSaveReview.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveReview.IconColor = Color.White;
            btnSaveReview.ForeColor = Color.White;
            btnSaveReview.BackColor = Color.FromArgb(45, 134, 89);
            btnSaveReview.IconSize = 18;
            btnSaveReview.Location = new Point(10, 294);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(120, 36);
            btnSaveReview.TabIndex = 7;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveReview.UseVisualStyleBackColor = false;
            btnSaveReview.FlatStyle = FlatStyle.Flat;
            btnSaveReview.FlatAppearance.BorderSize = 0;
            btnSaveReview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveReview.Click += btnSaveReview_Click;
            btnSaveReview.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            
            // btnClose
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            btnClose.IconColor = Color.White;
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.IconSize = 18;
            btnClose.Location = new Point(630, 294);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 36);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.Click += btnClose_Click;
            btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            
            pnlReview.Controls.Add(lblReviewStatus);
            pnlReview.Controls.Add(lblItems);
            pnlReview.Controls.Add(flpItems);
            pnlReview.Controls.Add(lblRating);
            pnlReview.Controls.Add(numRating);
            pnlReview.Controls.Add(lblComment);
            pnlReview.Controls.Add(txtComment);
            pnlReview.Controls.Add(btnSaveReview);
            pnlReview.Controls.Add(btnClose);

            // ReviewOrdersForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(780, 620);
            Font = new Font("Segoe UI", 9F);
            Padding = new Padding(10);
            Controls.Add(dgvOrders);
            Controls.Add(pnlReview);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimumSize = new Size(780, 620);
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
