using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class SalesReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblReportType;
        private ComboBox cmbReportType;
        private Label lblFromDate;
        private DateTimePicker dtFromDate;
        private Label lblToDate;
        private DateTimePicker dtToDate;
        private IconButton btnGenerate;
        private IconButton btnExport;
        private IconButton btnExportPdf;
        private Panel pnlSummary;
        private Label lblTotalSales;
        private Label lblTotalOrders;
        private Label lblAvgOrder;
        private Label lblCompletedOrders;
        private Label lblPendingOrders;
        private Label lblTopProduct;
        private Label lblDailySales;
        private DataGridView dgvDaily;
        private Label lblTopProducts;
        private DataGridView dgvTopProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblReportType = new Label();
            cmbReportType = new ComboBox();
            lblFromDate = new Label();
            dtFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtToDate = new DateTimePicker();
            btnGenerate = new IconButton();
            btnExport = new IconButton();
            btnExportPdf = new IconButton();
            pnlSummary = new Panel();
            lblTotalSales = new Label();
            lblTotalOrders = new Label();
            lblAvgOrder = new Label();
            lblCompletedOrders = new Label();
            lblPendingOrders = new Label();
            lblTopProduct = new Label();
            lblDailySales = new Label();
            dgvDaily = new DataGridView();
            lblTopProducts = new Label();
            dgvTopProducts = new DataGridView();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDaily).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            SuspendLayout();
            
            // lblReportType
            lblReportType.AutoSize = true;
            lblReportType.Location = new Point(15, 12);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(95, 20);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Report Type:";
            lblReportType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            // cmbReportType
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.Location = new Point(120, 10);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(150, 28);
            cmbReportType.TabIndex = 1;
            cmbReportType.Items.Add("Daily Sales");
            cmbReportType.Items.Add("Weekly Sales");
            cmbReportType.Items.Add("Monthly Sales");
            cmbReportType.Items.Add("Custom Range");
            cmbReportType.SelectedIndex = 0;
            cmbReportType.SelectedIndexChanged += CmbReportType_SelectedIndexChanged;
            
            // lblFromDate
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(285, 12);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(80, 20);
            lblFromDate.TabIndex = 2;
            lblFromDate.Text = "From Date:";
            lblFromDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            // dtFromDate
            dtFromDate.Location = new Point(365, 10);
            dtFromDate.Name = "dtFromDate";
            dtFromDate.Size = new Size(130, 27);
            dtFromDate.TabIndex = 3;
            dtFromDate.Value = DateTime.Now.AddMonths(-1);
            
            // lblToDate
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(510, 12);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(65, 20);
            lblToDate.TabIndex = 4;
            lblToDate.Text = "To Date:";
            lblToDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            // dtToDate
            dtToDate.Location = new Point(580, 10);
            dtToDate.Name = "dtToDate";
            dtToDate.Size = new Size(130, 27);
            dtToDate.TabIndex = 5;
            dtToDate.Value = DateTime.Now;
            
            // btnGenerate
            btnGenerate.BackColor = Color.FromArgb(45, 134, 89);
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.ForeColor = Color.White;
            btnGenerate.IconChar = IconChar.ChartBar;
            btnGenerate.IconColor = Color.White;
            btnGenerate.IconSize = 18;
            btnGenerate.Location = new Point(725, 8);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(130, 32);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.Click += BtnGenerate_Click;
            
            // btnExport
            btnExport.BackColor = Color.FromArgb(33, 150, 243);
            btnExport.Cursor = Cursors.Hand;
            btnExport.ForeColor = Color.White;
            btnExport.IconChar = IconChar.FileExcel;
            btnExport.IconColor = Color.White;
            btnExport.IconSize = 18;
            btnExport.Location = new Point(860, 8);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(100, 32);
            btnExport.TabIndex = 7;
            btnExport.Text = "CSV";
            btnExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Click += BtnExport_Click;
            
            // btnExportPdf
            btnExportPdf.BackColor = Color.FromArgb(244, 67, 54);
            btnExportPdf.Cursor = Cursors.Hand;
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.IconChar = IconChar.FilePdf;
            btnExportPdf.IconColor = Color.White;
            btnExportPdf.IconSize = 18;
            btnExportPdf.Location = new Point(965, 8);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(100, 32);
            btnExportPdf.TabIndex = 8;
            btnExportPdf.Text = "PDF";
            btnExportPdf.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExportPdf.UseVisualStyleBackColor = false;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.Click += BtnExportPdf_Click;
            
            // pnlSummary
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.BackColor = Color.White;
            pnlSummary.Controls.Add(lblTotalSales);
            pnlSummary.Controls.Add(lblTotalOrders);
            pnlSummary.Controls.Add(lblAvgOrder);
            pnlSummary.Controls.Add(lblCompletedOrders);
            pnlSummary.Controls.Add(lblPendingOrders);
            pnlSummary.Controls.Add(lblTopProduct);
            pnlSummary.Location = new Point(15, 50);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Padding = new Padding(10);
            pnlSummary.Size = new Size(1050, 95);
            pnlSummary.TabIndex = 9;
            
            // lblTotalSales
            lblTotalSales.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalSales.ForeColor = Color.FromArgb(45, 134, 89);
            lblTotalSales.Location = new Point(10, 10);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(210, 25);
            lblTotalSales.TabIndex = 0;
            lblTotalSales.Text = "Total Sales: Rs. 0.00";
            
            // lblTotalOrders
            lblTotalOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalOrders.Location = new Point(230, 10);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(180, 25);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "Total Orders: 0";
            
            // lblAvgOrder
            lblAvgOrder.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAvgOrder.Location = new Point(420, 10);
            lblAvgOrder.Name = "lblAvgOrder";
            lblAvgOrder.Size = new Size(210, 25);
            lblAvgOrder.TabIndex = 2;
            lblAvgOrder.Text = "Average Order: Rs. 0.00";
            
            // lblCompletedOrders
            lblCompletedOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCompletedOrders.ForeColor = Color.FromArgb(76, 175, 80);
            lblCompletedOrders.Location = new Point(640, 10);
            lblCompletedOrders.Name = "lblCompletedOrders";
            lblCompletedOrders.Size = new Size(200, 25);
            lblCompletedOrders.TabIndex = 3;
            lblCompletedOrders.Text = "Completed: 0";
            
            // lblPendingOrders
            lblPendingOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPendingOrders.ForeColor = Color.FromArgb(255, 152, 0);
            lblPendingOrders.Location = new Point(850, 10);
            lblPendingOrders.Name = "lblPendingOrders";
            lblPendingOrders.Size = new Size(180, 25);
            lblPendingOrders.TabIndex = 4;
            lblPendingOrders.Text = "Pending: 0";
            
            // lblTopProduct
            lblTopProduct.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTopProduct.Location = new Point(10, 50);
            lblTopProduct.Name = "lblTopProduct";
            lblTopProduct.Size = new Size(1020, 25);
            lblTopProduct.TabIndex = 5;
            lblTopProduct.Text = "Top Product: -";
            
            // lblDailySales
            lblDailySales.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDailySales.ForeColor = Color.FromArgb(45, 134, 89);
            lblDailySales.Location = new Point(15, 160);
            lblDailySales.Name = "lblDailySales";
            lblDailySales.Size = new Size(200, 25);
            lblDailySales.TabIndex = 10;
            lblDailySales.Text = "Sales by Date";
            
            // dgvDaily
            dgvDaily.AllowUserToAddRows = false;
            dgvDaily.BackColor = Color.White;
            dgvDaily.ColumnHeadersHeight = 35;
            dgvDaily.Location = new Point(15, 190);
            dgvDaily.Name = "dgvDaily";
            dgvDaily.ReadOnly = true;
            dgvDaily.RowTemplate.Height = 30;
            dgvDaily.Size = new Size(500, 250);
            dgvDaily.TabIndex = 11;
            dgvDaily.BorderStyle = BorderStyle.FixedSingle;
            dgvDaily.Columns.Add("Date", "Date");
            dgvDaily.Columns.Add("Orders", "Orders");
            dgvDaily.Columns.Add("Amount", "Amount");
            
            // lblTopProducts
            lblTopProducts.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTopProducts.ForeColor = Color.FromArgb(45, 134, 89);
            lblTopProducts.Location = new Point(530, 160);
            lblTopProducts.Name = "lblTopProducts";
            lblTopProducts.Size = new Size(200, 25);
            lblTopProducts.TabIndex = 12;
            lblTopProducts.Text = "Top Selling Products";
            
            // dgvTopProducts
            dgvTopProducts.AllowUserToAddRows = false;
            dgvTopProducts.BackColor = Color.White;
            dgvTopProducts.ColumnHeadersHeight = 35;
            dgvTopProducts.Location = new Point(530, 190);
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.ReadOnly = true;
            dgvTopProducts.RowTemplate.Height = 30;
            dgvTopProducts.Size = new Size(535, 250);
            dgvTopProducts.TabIndex = 13;
            dgvTopProducts.BorderStyle = BorderStyle.FixedSingle;
            dgvTopProducts.Columns.Add("ProductName", "Product");
            dgvTopProducts.Columns.Add("Quantity", "Qty Sold");
            dgvTopProducts.Columns.Add("Revenue", "Revenue");
            
            // SalesReportForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1080, 470);
            Font = new Font("Segoe UI", 9F);
            Padding = new Padding(10);
            Controls.Add(lblReportType);
            Controls.Add(cmbReportType);
            Controls.Add(lblFromDate);
            Controls.Add(dtFromDate);
            Controls.Add(lblToDate);
            Controls.Add(dtToDate);
            Controls.Add(btnGenerate);
            Controls.Add(btnExport);
            Controls.Add(btnExportPdf);
            Controls.Add(pnlSummary);
            Controls.Add(lblDailySales);
            Controls.Add(dgvDaily);
            Controls.Add(lblTopProducts);
            Controls.Add(dgvTopProducts);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(1080, 470);
            Name = "SalesReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Reports - GreenLife";
            pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDaily).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
