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
        private DataGridViewTextBoxColumn colOrderId;
        private DataGridViewTextBoxColumn colOrderNumber;
        private DataGridViewTextBoxColumn colOrderDate;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colRating;
        private DataGridViewTextBoxColumn colComment;
        private DataGridViewTextBoxColumn colReviewDate;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 134, 89);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrders.ColumnHeadersHeight = 35;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colOrderId, colOrderNumber, colOrderDate, colTotal, colRating, colComment, colReviewDate });
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(10, 10);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowTemplate.Height = 32;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(760, 270);
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
            pnlReview.Location = new Point(10, 280);
            pnlReview.Name = "pnlReview";
            pnlReview.Size = new Size(760, 330);
            pnlReview.TabIndex = 1;
            // 
            // lblReviewStatus
            // 
            lblReviewStatus.AutoSize = true;
            lblReviewStatus.Font = new Font("Segoe UI", 9F);
            lblReviewStatus.ForeColor = Color.FromArgb(117, 117, 117);
            lblReviewStatus.Location = new Point(10, 8);
            lblReviewStatus.Name = "lblReviewStatus";
            lblReviewStatus.Size = new Size(84, 15);
            lblReviewStatus.TabIndex = 0;
            lblReviewStatus.Text = "Not reviewed";
            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblItems.ForeColor = Color.FromArgb(45, 134, 89);
            lblItems.Location = new Point(10, 30);
            lblItems.Name = "lblItems";
            lblItems.Size = new Size(89, 19);
            lblItems.TabIndex = 1;
            lblItems.Text = "Order Items";
            // 
            // flpItems
            // 
            flpItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpItems.AutoScroll = true;
            flpItems.BackColor = Color.White;
            flpItems.BorderStyle = BorderStyle.FixedSingle;
            flpItems.Location = new Point(10, 52);
            flpItems.Name = "flpItems";
            flpItems.Padding = new Padding(5);
            flpItems.Size = new Size(740, 95);
            flpItems.TabIndex = 2;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRating.Location = new Point(10, 158);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(52, 19);
            lblRating.TabIndex = 3;
            lblRating.Text = "Rating";
            // 
            // numRating
            // 
            numRating.Font = new Font("Segoe UI", 9F);
            numRating.Location = new Point(80, 155);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(70, 23);
            numRating.TabIndex = 4;
            numRating.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblComment.Location = new Point(10, 186);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(74, 19);
            lblComment.TabIndex = 5;
            lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Font = new Font("Segoe UI", 9F);
            txtComment.Location = new Point(10, 208);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(740, 70);
            txtComment.TabIndex = 6;
            // 
            // btnSaveReview
            // 
            btnSaveReview.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            btnSaveReview.BackColor = Color.FromArgb(45, 134, 89);
            btnSaveReview.FlatAppearance.BorderSize = 0;
            btnSaveReview.FlatStyle = FlatStyle.Flat;
            btnSaveReview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveReview.ForeColor = Color.White;
            btnSaveReview.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveReview.IconColor = Color.White;
            btnSaveReview.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveReview.IconSize = 18;
            btnSaveReview.Location = new Point(10, 286);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(120, 36);
            btnSaveReview.TabIndex = 7;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveReview.UseVisualStyleBackColor = false;
            btnSaveReview.Click += btnSaveReview_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            btnClose.IconColor = Color.White;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 18;
            btnClose.Location = new Point(630, 286);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 36);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ReviewOrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(780, 620);
            Controls.Add(dgvOrders);
            Controls.Add(pnlReview);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimumSize = new Size(780, 620);
            Name = "ReviewOrdersForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Review Orders - GreenLife";
            Load += ReviewOrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
        }
    }
}
