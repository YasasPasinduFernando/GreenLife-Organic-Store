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
            lblReportType.Location = new Point(10, 10);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(80, 20);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Report Type:";
            // cmbReportType
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.Location = new Point(100, 10);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(200, 28);
            cmbReportType.TabIndex = 1;
            cmbReportType.Items.Add("Daily Sales");
            cmbReportType.Items.Add("Weekly Sales");
            cmbReportType.Items.Add("Monthly Sales");
            cmbReportType.Items.Add("Custom Range");
            cmbReportType.SelectedIndex = 0;
            cmbReportType.SelectedIndexChanged += CmbReportType_SelectedIndexChanged;
            // lblFromDate
            lblFromDate.Location = new Point(10, 45);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(80, 20);
            lblFromDate.TabIndex = 2;
            lblFromDate.Text = "From Date:";
            // dtFromDate
            dtFromDate.Location = new Point(100, 45);
            dtFromDate.Name = "dtFromDate";
            dtFromDate.Size = new Size(150, 27);
            dtFromDate.TabIndex = 3;
            dtFromDate.Value = DateTime.Now.AddMonths(-1);
            // lblToDate
            lblToDate.Location = new Point(270, 45);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(60, 20);
            lblToDate.TabIndex = 4;
            lblToDate.Text = "To Date:";
            // dtToDate
            dtToDate.Location = new Point(340, 45);
            dtToDate.Name = "dtToDate";
            dtToDate.Size = new Size(150, 27);
            dtToDate.TabIndex = 5;
            dtToDate.Value = DateTime.Now;
            // btnGenerate
            btnGenerate.BackColor = Color.Green;
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.ForeColor = Color.White;
            btnGenerate.IconChar = IconChar.ChartBar;
            btnGenerate.IconColor = Color.White;
            btnGenerate.IconSize = 20;
            btnGenerate.Location = new Point(510, 40);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(150, 30);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate Report";
            btnGenerate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += BtnGenerate_Click;
            // btnExport
            btnExport.BackColor = Color.LightBlue;
            btnExport.Cursor = Cursors.Hand;
            btnExport.IconChar = IconChar.FileExport;
            btnExport.IconColor = Color.Black;
            btnExport.IconSize = 20;
            btnExport.Location = new Point(670, 40);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 30);
            btnExport.TabIndex = 7;
            btnExport.Text = "Export to CSV";
            btnExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // btnExportPdf
            btnExportPdf.BackColor = Color.LightCoral;
            btnExportPdf.Cursor = Cursors.Hand;
            btnExportPdf.IconChar = IconChar.FilePdf;
            btnExportPdf.IconColor = Color.White;
            btnExportPdf.IconSize = 20;
            btnExportPdf.Location = new Point(800, 40);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(120, 30);
            btnExportPdf.TabIndex = 8;
            btnExportPdf.Text = "Export to PDF";
            btnExportPdf.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExportPdf.UseVisualStyleBackColor = false;
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
            pnlSummary.Location = new Point(10, 85);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(870, 100);
            pnlSummary.TabIndex = 9;
            // lblTotalSales
            lblTotalSales.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblTotalSales.ForeColor = Color.DarkGreen;
            lblTotalSales.Location = new Point(10, 10);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(200, 25);
            lblTotalSales.TabIndex = 0;
            lblTotalSales.Text = "Total Sales: Rs. 0.00";
            // lblTotalOrders
            lblTotalOrders.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblTotalOrders.Location = new Point(220, 10);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(200, 25);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "Total Orders: 0";
            // lblAvgOrder
            lblAvgOrder.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblAvgOrder.Location = new Point(430, 10);
            lblAvgOrder.Name = "lblAvgOrder";
            lblAvgOrder.Size = new Size(200, 25);
            lblAvgOrder.TabIndex = 2;
            lblAvgOrder.Text = "Average Order: Rs. 0.00";
            // lblCompletedOrders
            lblCompletedOrders.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblCompletedOrders.ForeColor = Color.Green;
            lblCompletedOrders.Location = new Point(640, 10);
            lblCompletedOrders.Name = "lblCompletedOrders";
            lblCompletedOrders.Size = new Size(220, 25);
            lblCompletedOrders.TabIndex = 3;
            lblCompletedOrders.Text = "Completed Orders: 0";
            // lblPendingOrders
            lblPendingOrders.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblPendingOrders.ForeColor = Color.Orange;
            lblPendingOrders.Location = new Point(10, 45);
            lblPendingOrders.Name = "lblPendingOrders";
            lblPendingOrders.Size = new Size(200, 25);
            lblPendingOrders.TabIndex = 4;
            lblPendingOrders.Text = "Pending Orders: 0";
            // lblTopProduct
            lblTopProduct.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblTopProduct.Location = new Point(220, 45);
            lblTopProduct.Name = "lblTopProduct";
            lblTopProduct.Size = new Size(400, 25);
            lblTopProduct.TabIndex = 5;
            lblTopProduct.Text = "Top Product: -";
            // lblDailySales
            lblDailySales.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblDailySales.Location = new Point(10, 195);
            lblDailySales.Name = "lblDailySales";
            lblDailySales.Size = new Size(300, 20);
            lblDailySales.TabIndex = 10;
            lblDailySales.Text = "Sales by Date";
            // dgvDaily
            dgvDaily.AllowUserToAddRows = false;
            dgvDaily.BackColor = Color.White;
            dgvDaily.Location = new Point(10, 220);
            dgvDaily.Name = "dgvDaily";
            dgvDaily.ReadOnly = true;
            dgvDaily.Size = new Size(430, 150);
            dgvDaily.TabIndex = 11;
            dgvDaily.Columns.Add("Date", "Date");
            dgvDaily.Columns.Add("Orders", "Orders");
            dgvDaily.Columns.Add("Amount", "Amount");
            // lblTopProducts
            lblTopProducts.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblTopProducts.Location = new Point(450, 195);
            lblTopProducts.Name = "lblTopProducts";
            lblTopProducts.Size = new Size(300, 20);
            lblTopProducts.TabIndex = 12;
            lblTopProducts.Text = "Top Selling Products";
            // dgvTopProducts
            dgvTopProducts.AllowUserToAddRows = false;
            dgvTopProducts.BackColor = Color.White;
            dgvTopProducts.Location = new Point(450, 220);
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.ReadOnly = true;
            dgvTopProducts.Size = new Size(430, 150);
            dgvTopProducts.TabIndex = 13;
            dgvTopProducts.Columns.Add("ProductName", "Product");
            dgvTopProducts.Columns.Add("Quantity", "Qty Sold");
            dgvTopProducts.Columns.Add("Revenue", "Revenue");
            // SalesReportForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1000, 800);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SalesReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Reports";
            pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDaily).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            ResumeLayout(false);
        }
    }
}
