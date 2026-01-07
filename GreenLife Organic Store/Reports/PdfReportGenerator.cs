using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Reports
{
    public static class PdfReportGenerator
    {
        public static void GenerateSalesReportPdf(string filePath, string storeName, DateTime fromDate, DateTime toDate,
            decimal totalSales, int totalOrders, decimal avgOrder, int completedOrders, int pendingOrders,
            List<(DateTime date, int orders, decimal amount)> dailySales,
            List<(string name, int qty, decimal revenue)> topProducts)
        {
            using (var document = new PdfDocument())
            {
                var page = document.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                var gfx = XGraphics.FromPdfPage(page);

                var fontTitle = new XFont("Arial", 18, XFontStyle.Bold);
                var fontHeader = new XFont("Arial", 12, XFontStyle.Bold);
                var fontText = new XFont("Arial", 10, XFontStyle.Regular);
                var fontSmall = new XFont("Arial", 9, XFontStyle.Regular);

                double x = 40;
                double y = 40;

                // Header block with subtle line
                gfx.DrawString(storeName, fontTitle, XBrushes.DarkGreen, new XRect(x, y, page.Width - 80, 24), XStringFormats.TopLeft);
                y += 26;
                gfx.DrawString($"Sales Report", fontHeader, XBrushes.Black, new XRect(x, y, 200, 20), XStringFormats.TopLeft);
                gfx.DrawString($"{fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy}", fontSmall, XBrushes.Gray, new XRect(x + 200, y + 2, page.Width - 300, 18), XStringFormats.TopLeft);
                y += 24;
                gfx.DrawLine(XPens.LightGray, x, y, page.Width - 40, y);
                y += 12;

                // Summary
                gfx.DrawString("Summary", fontHeader, XBrushes.Black, new XRect(x, y, 200, 20), XStringFormats.TopLeft);
                y += 20;
                gfx.DrawString($"Total Sales: Rs. {totalSales:N2}", fontText, XBrushes.Black, new XRect(x, y, 300, 18), XStringFormats.TopLeft);
                y += 15;
                gfx.DrawString($"Total Orders: {totalOrders}", fontText, XBrushes.Black, new XRect(x, y, 300, 18), XStringFormats.TopLeft);
                y += 15;
                gfx.DrawString($"Average Order: Rs. {avgOrder:N2}", fontText, XBrushes.Black, new XRect(x, y, 300, 18), XStringFormats.TopLeft);
                y += 15;
                gfx.DrawString($"Completed Orders: {completedOrders}", fontText, XBrushes.Black, new XRect(x, y, 300, 18), XStringFormats.TopLeft);
                y += 15;
                gfx.DrawString($"Pending Orders: {pendingOrders}", fontText, XBrushes.Black, new XRect(x, y, 300, 18), XStringFormats.TopLeft);
                y += 25;

                // Daily sales
                // Daily sales - render in two columns if space allows
                gfx.DrawString("Daily Sales", fontHeader, XBrushes.Black, new XRect(x, y, 200, 20), XStringFormats.TopLeft);
                y += 18;
                double colX = x;
                double colWidth = (page.Width - 80) / 2;
                int col = 0;
                foreach (var ds in dailySales)
                {
                    double drawX = x + col * (colWidth + 10);
                    gfx.DrawString($"{ds.date:dd/MM/yyyy}", fontText, XBrushes.Black, new XRect(drawX, y, colWidth, 14), XStringFormats.TopLeft);
                    gfx.DrawString($"Orders: {ds.orders}", fontSmall, XBrushes.Gray, new XRect(drawX + 90, y, colWidth - 90, 14), XStringFormats.TopLeft);
                    gfx.DrawString($"Rs. {ds.amount:N2}", fontSmall, XBrushes.Gray, new XRect(drawX + 160, y, colWidth - 160, 14), XStringFormats.TopLeft);
                    y += 16;
                    col = (col + 1) % 2;
                    if (col == 0) y += 4; // extra spacing after both cols used
                    if (y > page.Height - 80)
                    {
                        page = document.AddPage();
                        page.Size = PdfSharpCore.PageSize.A4;
                        gfx = XGraphics.FromPdfPage(page);
                        y = 40;
                    }
                }

                y += 10;
                gfx.DrawString("Top Products", fontHeader, XBrushes.Black, new XRect(x, y, 200, 20), XStringFormats.TopLeft);
                y += 20;

                // Top products with bold names
                foreach (var tp in topProducts)
                {
                    gfx.DrawString(tp.name, fontText, XBrushes.Black, new XRect(x, y, page.Width - 160, 14), XStringFormats.TopLeft);
                    gfx.DrawString($"Qty: {tp.qty}", fontSmall, XBrushes.Gray, new XRect(x + page.Width - 260, y, 80, 14), XStringFormats.TopLeft);
                    gfx.DrawString($"Rs. {tp.revenue:N2}", fontSmall, XBrushes.Gray, new XRect(x + page.Width - 180, y, 160, 14), XStringFormats.TopLeft);
                    y += 16;
                    if (y > page.Height - 80)
                    {
                        page = document.AddPage();
                        page.Size = PdfSharpCore.PageSize.A4;
                        gfx = XGraphics.FromPdfPage(page);
                        y = 40;
                    }
                }

                document.Save(filePath);
            }
        }
    }
}
