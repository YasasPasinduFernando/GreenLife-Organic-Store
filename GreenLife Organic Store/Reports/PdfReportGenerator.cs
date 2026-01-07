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

                var fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
                var fontHeader = new XFont("Arial", 12, XFontStyle.Bold);
                var fontText = new XFont("Arial", 10, XFontStyle.Regular);

                double x = 40;
                double y = 40;

                gfx.DrawString(storeName, fontTitle, XBrushes.DarkGreen, new XRect(x, y, page.Width - 80, 20), XStringFormats.TopLeft);
                y += 30;
                gfx.DrawString($"Sales Report: {fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy}", fontHeader, XBrushes.Black, new XRect(x, y, page.Width - 80, 20), XStringFormats.TopLeft);
                y += 30;

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
                gfx.DrawString("Daily Sales", fontHeader, XBrushes.Black, new XRect(x, y, 200, 20), XStringFormats.TopLeft);
                y += 20;
                foreach (var ds in dailySales)
                {
                    gfx.DrawString($"{ds.date:dd/MM/yyyy} - Orders: {ds.orders} - Amount: Rs. {ds.amount:N2}", fontText, XBrushes.Black, new XRect(x, y, page.Width - 80, 16), XStringFormats.TopLeft);
                    y += 14;
                    if (y > page.Height - 60)
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

                foreach (var tp in topProducts)
                {
                    gfx.DrawString($"{tp.name} - Qty: {tp.qty} - Revenue: Rs. {tp.revenue:N2}", fontText, XBrushes.Black, new XRect(x, y, page.Width - 80, 16), XStringFormats.TopLeft);
                    y += 14;
                    if (y > page.Height - 60)
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
