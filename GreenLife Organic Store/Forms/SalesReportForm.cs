using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using System.Globalization;

namespace GreenLife_Organic_Store.Forms
{
    public partial class SalesReportForm : Form
    {
        public SalesReportForm()
        {
            this.Text = "Sales Reports";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Load += SalesReportForm_Load;
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            int yPosition = 10;

            // Report Type
            Label lblReportType = new Label { Text = "Report Type:", Location = new Point(10, yPosition), Size = new Size(80, 20) };
            ComboBox cmbReportType = new ComboBox
            {
                Name = "cmbReportType",
                Location = new Point(100, yPosition),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbReportType.Items.Add("Daily Sales");
            cmbReportType.Items.Add("Weekly Sales");
            cmbReportType.Items.Add("Monthly Sales");
            cmbReportType.Items.Add("Custom Range");
            cmbReportType.SelectedIndex = 0;
            cmbReportType.SelectedIndexChanged += (s, e) => UpdateDateControls();
            this.Controls.Add(lblReportType);
            this.Controls.Add(cmbReportType);
            yPosition += 35;

            // Date Range
            Label lblFromDate = new Label { Text = "From Date:", Location = new Point(10, yPosition), Size = new Size(80, 20) };
            DateTimePicker dtFromDate = new DateTimePicker
            {
                Name = "dtFromDate",
                Location = new Point(100, yPosition),
                Size = new Size(150, 25),
                Value = DateTime.Now.AddMonths(-1)
            };
            this.Controls.Add(lblFromDate);
            this.Controls.Add(dtFromDate);

            Label lblToDate = new Label { Text = "To Date:", Location = new Point(270, yPosition), Size = new Size(60, 20) };
            DateTimePicker dtToDate = new DateTimePicker
            {
                Name = "dtToDate",
                Location = new Point(340, yPosition),
                Size = new Size(150, 25),
                Value = DateTime.Now
            };
            this.Controls.Add(lblToDate);
            this.Controls.Add(dtToDate);

            Button btnGenerate = new Button
            {
                Text = "Generate Report",
                Location = new Point(510, yPosition - 5),
                Size = new Size(150, 30),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnGenerate.Click += (s, e) => GenerateReport();
            this.Controls.Add(btnGenerate);

            Button btnExport = new Button
            {
                Text = "Export to CSV",
                Location = new Point(670, yPosition - 5),
                Size = new Size(120, 30),
                BackColor = Color.LightBlue,
                Cursor = Cursors.Hand
            };
            btnExport.Click += (s, e) => ExportToCSV();
            this.Controls.Add(btnExport);

            yPosition += 40;

            // Summary Panel
            Panel pnlSummary = new Panel
            {
                Location = new Point(10, yPosition),
                Size = new Size(870, 100),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Label lblTotalSales = new Label
            {
                Name = "lblTotalSales",
                Text = "Total Sales: Rs. 0.00",
                Location = new Point(10, 10),
                Size = new Size(200, 25),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            pnlSummary.Controls.Add(lblTotalSales);

            Label lblTotalOrders = new Label
            {
                Name = "lblTotalOrders",
                Text = "Total Orders: 0",
                Location = new Point(220, 10),
                Size = new Size(200, 25),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            pnlSummary.Controls.Add(lblTotalOrders);

            Label lblAvgOrder = new Label
            {
                Name = "lblAvgOrder",
                Text = "Average Order: Rs. 0.00",
                Location = new Point(430, 10),
                Size = new Size(200, 25),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            pnlSummary.Controls.Add(lblAvgOrder);

            Label lblCompletedOrders = new Label
            {
                Name = "lblCompletedOrders",
                Text = "Completed Orders: 0",
                Location = new Point(640, 10),
                Size = new Size(220, 25),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.Green
            };
            pnlSummary.Controls.Add(lblCompletedOrders);

            Label lblPendingOrders = new Label
            {
                Name = "lblPendingOrders",
                Text = "Pending Orders: 0",
                Location = new Point(10, 45),
                Size = new Size(200, 25),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.Orange
            };
            pnlSummary.Controls.Add(lblPendingOrders);

            Label lblTopProduct = new Label
            {
                Name = "lblTopProduct",
                Text = "Top Product: -",
                Location = new Point(220, 45),
                Size = new Size(400, 25),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            pnlSummary.Controls.Add(lblTopProduct);

            this.Controls.Add(pnlSummary);
            yPosition += 110;

            // Daily Sales DataGridView
            Label lblDailySales = new Label
            {
                Text = "Sales by Date",
                Location = new Point(10, yPosition),
                Size = new Size(300, 20),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            this.Controls.Add(lblDailySales);
            yPosition += 25;

            DataGridView dgvDaily = new DataGridView
            {
                Name = "dgvDaily",
                Location = new Point(10, yPosition),
                Size = new Size(430, 150),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackColor = Color.White
            };
            dgvDaily.Columns.Add("Date", "Date");
            dgvDaily.Columns.Add("Orders", "Orders");
            dgvDaily.Columns.Add("Amount", "Amount");
            this.Controls.Add(dgvDaily);

            // Top Products DataGridView
            Label lblTopProducts = new Label
            {
                Text = "Top Selling Products",
                Location = new Point(450, yPosition),
                Size = new Size(300, 20),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            this.Controls.Add(lblTopProducts);

            DataGridView dgvTopProducts = new DataGridView
            {
                Name = "dgvTopProducts",
                Location = new Point(450, yPosition + 25),
                Size = new Size(430, 150),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackColor = Color.White
            };
            dgvTopProducts.Columns.Add("ProductName", "Product");
            dgvTopProducts.Columns.Add("Quantity", "Qty Sold");
            dgvTopProducts.Columns.Add("Revenue", "Revenue");
            this.Controls.Add(dgvTopProducts);
        }

        private void UpdateDateControls()
        {
            ComboBox? cmbReportType = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "cmbReportType") as ComboBox;
            DateTimePicker? dtFromDate = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dtFromDate") as DateTimePicker;
            DateTimePicker? dtToDate = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dtToDate") as DateTimePicker;

            if (cmbReportType == null || dtFromDate == null || dtToDate == null)
                return; // controls not ready

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
                DateTimePicker? dtFromDate = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dtFromDate") as DateTimePicker;
                DateTimePicker? dtToDate = this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dtToDate") as DateTimePicker;

                if (dtFromDate == null || dtToDate == null)
                {
                    MessageBox.Show("Date controls are not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var orders = OrderRepository.GetOrdersByDateRange(dtFromDate.Value.Date, dtToDate.Value.Date.AddDays(1));
                var allItems = new List<(string name, int qty, decimal revenue)>();

                // Calculate summary
                // For sales/totals we consider only completed (Delivered) orders
                var completedOrderList = orders.Where(o => o.Status == OrderStatus.Delivered).ToList();
                decimal totalSales = completedOrderList.Sum(o => o.TotalAmount);
                int totalOrdersCount = completedOrderList.Count;
                decimal avgOrder = totalOrdersCount > 0 ? totalSales / totalOrdersCount : 0;
                int completedOrders = completedOrderList.Count;
                int pendingOrders = orders.Count(o => o.Status == OrderStatus.Pending);

                // Update summary labels
                Panel pnlSummary = null;
                foreach (var control in this.Controls)
                {
                    if (control is Panel p && p.BorderStyle == BorderStyle.FixedSingle)
                    {
                        pnlSummary = p;
                        break;
                    }
                }

                if (pnlSummary != null)
                {
                    ((Label)pnlSummary.Controls["lblTotalSales"]).Text = $"Total Sales: Rs. {totalSales:N2}";
                    ((Label)pnlSummary.Controls["lblTotalOrders"]).Text = $"Total Orders: {totalOrdersCount}";
                    ((Label)pnlSummary.Controls["lblAvgOrder"]).Text = $"Average Order: Rs. {avgOrder:N2}";
                    ((Label)pnlSummary.Controls["lblCompletedOrders"]).Text = $"Completed Orders: {completedOrders}";
                    ((Label)pnlSummary.Controls["lblPendingOrders"]).Text = $"Pending Orders: {pendingOrders}";

                    // Top product - build allItems from completed orders only
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
                    ((Label)pnlSummary.Controls["lblTopProduct"]).Text = topProduct.name != null ? 
                        $"Top Product: {topProduct.name} ({topProduct.qty} units)" : "Top Product: -";
                }

                // Load daily sales
                DataGridView dgvDaily = (DataGridView)this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dgvDaily") as DataGridView;
                if (dgvDaily != null)
                {
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
                }

                // Load top products
                DataGridView dgvTopProducts = (DataGridView)this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dgvTopProducts") as DataGridView;
                if (dgvTopProducts != null)
                {
                    dgvTopProducts.Rows.Clear();
                    var topProducts = allItems.OrderByDescending(x => x.qty).Take(10);

                    foreach (var product in topProducts)
                    {
                        dgvTopProducts.Rows.Add(product.name, product.qty, $"Rs. {product.revenue:N2}");
                    }
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
                        // Write headers
                        writer.WriteLine("GreenLife Organic Store - Sales Report");
                        writer.WriteLine($"Generated: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        writer.WriteLine();

                        // Write summary
                        Panel pnlSummary = null;
                        foreach (var control in this.Controls)
                        {
                            if (control is Panel p && p.BorderStyle == BorderStyle.FixedSingle)
                            {
                                pnlSummary = p;
                                break;
                            }
                        }

                        if (pnlSummary != null)
                        {
                            writer.WriteLine(((Label)pnlSummary.Controls["lblTotalSales"]).Text);
                            writer.WriteLine(((Label)pnlSummary.Controls["lblTotalOrders"]).Text);
                            writer.WriteLine(((Label)pnlSummary.Controls["lblAvgOrder"]).Text);
                            writer.WriteLine();
                        }

                        // Write daily sales
                        DataGridView dgvDaily = (DataGridView)this.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "dgvDaily") as DataGridView;
                        if (dgvDaily != null)
                        {
                            writer.WriteLine("Daily Sales");
                            writer.WriteLine("Date,Orders,Amount");
                            foreach (DataGridViewRow row in dgvDaily.Rows)
                            {
                                writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value}");
                            }
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
