using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using System.Globalization;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    public partial class SalesReportForm : Form
    {
        public SalesReportForm()
        {
            InitializeComponent();
            this.Text = "Sales Reports";
            this.Size = new Size(1000, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = FormThemeManager.Background;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            try
            {
                FormThemeManager.ApplyToForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ExportToPDF()
        {
            try
            {
                if (dtFromDate == null || dtToDate == null)
                {
                    MessageBox.Show("Date controls are not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var orders = OrderRepository.GetOrdersByDateRange(dtFromDate.Value.Date, dtToDate.Value.Date.AddDays(1));
                var completedOrderList = orders.Where(o => o.Status == OrderStatus.Delivered).ToList();

                decimal totalSales = completedOrderList.Sum(o => o.TotalAmount);
                int totalOrdersCount = completedOrderList.Count;
                decimal avgOrder = totalOrdersCount > 0 ? totalSales / totalOrdersCount : 0;
                int completedOrders = completedOrderList.Count;
                int pendingOrders = orders.Count(o => o.Status == OrderStatus.Pending);

                var daily = orders.GroupBy(o => o.OrderDate.Date)
                    .OrderBy(g => g.Key)
                    .Select(g => (date: g.Key, orders: g.Count(), amount: g.Sum(o => o.TotalAmount)))
                    .ToList();

                var allItems = new List<(string name, int qty, decimal revenue)>();
                foreach (var order in completedOrderList)
                {
                    if (order.Items == null) continue;
                    foreach (var item in order.Items)
                    {
                        var existing = allItems.FirstOrDefault(x => x.name == item.ProductName);
                        if (!string.IsNullOrEmpty(existing.name))
                        {
                            allItems.Remove(existing);
                            allItems.Add((existing.name, existing.qty + item.Quantity, existing.revenue + item.Subtotal));
                        }
                        else
                        {
                            allItems.Add((item.ProductName, item.Quantity, item.Subtotal));
                        }
                    }
                }

                var topProducts = allItems.OrderByDescending(x => x.qty).Take(10).ToList();

                SaveFileDialog save = new SaveFileDialog
                {
                    FileName = $"SalesReport_{DateTime.Now:yyyyMMdd}.pdf",
                    Filter = "PDF Files (*.pdf)|*.pdf"
                };

                if (save.ShowDialog() == DialogResult.OK)
                {
                    GreenLife_Organic_Store.Reports.PdfReportGenerator.GenerateSalesReportPdf(save.FileName,
                        "GreenLife Organic Store",
                        dtFromDate.Value.Date, dtToDate.Value.Date,
                        totalSales, totalOrdersCount, avgOrder, completedOrders, pendingOrders,
                        daily,
                        topProducts);

                    MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbReportType_SelectedIndexChanged(object? sender, EventArgs e) => UpdateDateControls();
        private void BtnGenerate_Click(object? sender, EventArgs e) => GenerateReport();
        private void BtnExport_Click(object? sender, EventArgs e) => ExportToCSV();
        private void BtnExportPdf_Click(object? sender, EventArgs e) => ExportToPDF();

        private void UpdateDateControls()
        {
            if (cmbReportType == null || dtFromDate == null || dtToDate == null)
                return;

            string reportType = cmbReportType.SelectedItem?.ToString() ?? string.Empty;
            DateTime today = DateTime.Now;

            switch (reportType)
            {
                case "Daily Sales":
                    dtFromDate.Value = today;
                    dtToDate.Value = today;
                    break;
                case "Weekly Sales":
                    dtFromDate.Value = today.AddDays(-7);
                    dtToDate.Value = today;
                    break;
                case "Monthly Sales":
                    dtFromDate.Value = today.AddMonths(-1);
                    dtToDate.Value = today;
                    break;
            }
        }

        private void GenerateReport()
        {
            try
            {
                if (dtFromDate == null || dtToDate == null)
                {
                    MessageBox.Show("Date controls are not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var orders = OrderRepository.GetOrdersByDateRange(dtFromDate.Value.Date, dtToDate.Value.Date.AddDays(1));
                var allItems = new List<(string name, int qty, decimal revenue)>();

                var completedOrderList = orders.Where(o => o.Status == OrderStatus.Delivered).ToList();
                decimal totalSales = completedOrderList.Sum(o => o.TotalAmount);
                int totalOrdersCount = completedOrderList.Count;
                decimal avgOrder = totalOrdersCount > 0 ? totalSales / totalOrdersCount : 0;
                int completedOrders = completedOrderList.Count;
                int pendingOrders = orders.Count(o => o.Status == OrderStatus.Pending);

                lblTotalSales.Text = $"Total Sales: Rs. {totalSales:N2}";
                lblTotalOrders.Text = $"Total Orders: {totalOrdersCount}";
                lblAvgOrder.Text = $"Average Order: Rs. {avgOrder:N2}";
                lblCompletedOrders.Text = $"Completed Orders: {completedOrders}";
                lblPendingOrders.Text = $"Pending Orders: {pendingOrders}";

                foreach (var order in completedOrderList)
                {
                    if (order.Items == null) continue;
                    foreach (var item in order.Items)
                    {
                        var existing = allItems.FirstOrDefault(x => x.name == item.ProductName);
                        if (!string.IsNullOrEmpty(existing.name))
                        {
                            allItems.Remove(existing);
                            allItems.Add((existing.name, existing.qty + item.Quantity, existing.revenue + item.Subtotal));
                        }
                        else
                        {
                            allItems.Add((item.ProductName, item.Quantity, item.Subtotal));
                        }
                    }
                }

                var topProduct = allItems.OrderByDescending(x => x.qty).FirstOrDefault();
                lblTopProduct.Text = !string.IsNullOrEmpty(topProduct.name) ?
                    $"Top Product: {topProduct.name} ({topProduct.qty} units)" : "Top Product: -";

                dgvDaily.Rows.Clear();
                var groupedByDate = orders.GroupBy(o => o.OrderDate.Date).OrderBy(g => g.Key);
                foreach (var group in groupedByDate)
                {
                    dgvDaily.Rows.Add(
                        group.Key.ToString("dd/MM/yyyy"),
                        group.Count(),
                        $"Rs. {group.Sum(o => o.TotalAmount):N2}"
                    );
                }

                dgvTopProducts.Rows.Clear();
                foreach (var product in allItems.OrderByDescending(x => x.qty).Take(10))
                {
                    dgvTopProducts.Rows.Add(product.name, product.qty, $"Rs. {product.revenue:N2}");
                }

                MessageBox.Show("Report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    FileName = $"SalesReport_{DateTime.Now:yyyyMMdd}.csv",
                    Filter = "CSV Files (*.csv)|*.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        writer.WriteLine("GreenLife Organic Store - Sales Report");
                        writer.WriteLine($"Generated: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        writer.WriteLine();
                        writer.WriteLine(lblTotalSales.Text);
                        writer.WriteLine(lblTotalOrders.Text);
                        writer.WriteLine(lblAvgOrder.Text);
                        writer.WriteLine();
                        writer.WriteLine("Daily Sales");
                        writer.WriteLine("Date,Orders,Amount");
                        foreach (DataGridViewRow row in dgvDaily.Rows)
                        {
                            if (row.IsNewRow) continue;
                            writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value}");
                        }
                    }
                    MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}