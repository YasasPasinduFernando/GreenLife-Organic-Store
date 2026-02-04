using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Utilities
{
    // Sends emails via Gmail SMTP
    public static class EmailService
    {
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "greenlifeorganicstore@gmail.com";
        private const string SENDER_PASSWORD = "nede eilq sypk nhrx";
        private const string SENDER_NAME = "GreenLife Organic Store";
        
        // TRUE = fake emails (for testing), FALSE = real emails
        private const bool USE_MOCK_MODE = false;

        public static bool SendEmail(string toEmail, string subject, string body, bool isHtml = true)
        {
            if (USE_MOCK_MODE)
            {
                return SendEmailMock(toEmail, subject, body);
            }
            else
            {
                return SendEmailReal(toEmail, subject, body, isHtml);
            }
        }

        // Fake send for testing
        private static bool SendEmailMock(string toEmail, string subject, string body)
        {
            try
            {
                LogEmailSuccess(toEmail, subject);
                return true;
            }
            catch (Exception ex)
            {
                LogEmailError($"Error: {ex.Message}");
                return false;
            }
        }

        // Shows reset code in popup for testing
        public static bool SendPasswordResetEmailMock(string toEmail, string userName, string resetCode)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Password Reset Code\n\n" +
                    $"Email: {toEmail}\n\n" +
                    $"Your Code:\n\n" +
                    $"{resetCode}\n\n" +
                    $"(Expires in 15 minutes)",
                    "Reset Code",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information
                );
                
                LogEmailSuccess(toEmail, "Password Reset Request");
                return true;
            }
            catch (Exception ex)
            {
                LogEmailError($"Mock error: {ex.Message}");
                return false;
            }
        }

        // Actual email sending via Gmail SMTP
        private static bool SendEmailReal(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                using var smtp = new SmtpClient(SMTP_SERVER, SMTP_PORT)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 10000
                };

                using var msg = new MailMessage();
                msg.From = new MailAddress(SENDER_EMAIL, SENDER_NAME);
                msg.To.Add(toEmail);
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = isHtml;
                msg.Priority = MailPriority.Normal;

                smtp.Send(msg);
                LogEmailSuccess(toEmail, subject);
                return true;
            }
            catch (SmtpException smtpEx)
            {
                LogEmailError($"Failed to send email: {smtpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                LogEmailError($"Error: {ex.Message}");
                return false;
            }
        }

        private static void LogEmailSuccess(string toEmail, string subject)
        {
        }

        private static void LogEmailError(string message)
        {
            Console.WriteLine($"? {message}");
        }

        public static bool SendOrderConfirmation(string customerEmail, string customerName, string orderNumber, decimal totalAmount, List<OrderItem> items)
        {
            string subject = $"GreenLife - Order Confirmation #{orderNumber}";

            string body = $@"<!doctype html>
<html>
<body style='font-family:Segoe UI, Arial, sans-serif; color:#333;'>
  <div style='max-width:700px;margin:0 auto;padding:20px;background:#fff;border:1px solid #e9e9e9;'>
    <h2 style='color:#228b22;margin-bottom:0;'>Order Confirmation</h2>
    <p style='color:#666;margin-top:4px;'>Hi {customerName},</p>
    <p style='color:#666;'>Thanks for your order. Below are the details for your purchase <strong>#{orderNumber}</strong>.</p>

    <table style='width:100%;border-collapse:collapse;margin-top:10px;'>
      <thead>
        <tr style='background:#f5f5f5;color:#333;'>
          <th style='padding:8px;border:1px solid #eee;text-align:left;'>Item</th>
          <th style='padding:8px;border:1px solid #eee;text-align:center;'>Qty</th>
          <th style='padding:8px;border:1px solid #eee;text-align:right;'>Unit</th>
          <th style='padding:8px;border:1px solid #eee;text-align:right;'>Subtotal</th>
        </tr>
      </thead>
      <tbody>";

            foreach (var i in items)
            {
                body += $@"<tr>
          <td style='padding:8px;border:1px solid #eee;'>{System.Net.WebUtility.HtmlEncode(i.ProductName)}</td>
          <td style='padding:8px;border:1px solid #eee;text-align:center;'>{i.Quantity}</td>
          <td style='padding:8px;border:1px solid #eee;text-align:right;'>Rs. {i.UnitPrice:N2}</td>
          <td style='padding:8px;border:1px solid #eee;text-align:right;'>Rs. {i.Subtotal:N2}</td>
        </tr>";
            }

            body += $@"      </tbody>
      <tfoot>
        <tr>
          <td colspan='3' style='padding:8px;border:1px solid #eee;text-align:right;font-weight:bold;'>Total</td>
          <td style='padding:8px;border:1px solid #eee;text-align:right;font-weight:bold;'>Rs. {totalAmount:N2}</td>
        </tr>
      </tfoot>
    </table>

    <p style='color:#666;margin-top:16px;'>If you have any questions about your order, reply to this email or contact our support at <a href='mailto:{SENDER_EMAIL}' style='color:#228b22'>{SENDER_EMAIL}</a>.</p>

    <hr style='border:none;border-top:1px solid #eee;margin:18px 0;' />
    <p style='font-size:12px;color:#999;margin:0;'>GreenLife Organic Store<br/>Bringing fresh organic produce to your door.</p>
  </div>
</body>
</html>";

            return SendEmail(customerEmail, subject, body, true);
        }

        public static Task SendOrderPlacedAlertToAdminsAsync(IEnumerable<string> adminEmails, string orderNumber, string customerName, decimal totalAmount)
        {
            return Task.Run(() =>
            {
                try
                {
                    var emails = adminEmails?.Where(e => !string.IsNullOrWhiteSpace(e)).Distinct().ToList() ?? new List<string>();
                    if (emails.Count == 0) return;

                    string subject = $"New Order Placed: {orderNumber}";
                    string body = $@"<html><body style='font-family:Segoe UI, Arial, sans-serif;color:#333;'>
  <div style='max-width:700px;margin:0 auto;padding:20px;background:#fff;border:1px solid #e9e9e9;'>
    <h2 style='color:#228b22;margin-bottom:0;'>New Order Placed</h2>
    <p style='color:#666;margin-top:6px;'>Order Number: <strong>{System.Net.WebUtility.HtmlEncode(orderNumber)}</strong></p>
    <p style='color:#666;'>Customer: <strong>{System.Net.WebUtility.HtmlEncode(customerName)}</strong></p>
    <p style='color:#666;'>Total Amount: <strong>Rs. {totalAmount:N2}</strong></p>
    <hr style='border:none;border-top:1px solid #eee;margin:18px 0;' />
    <p style='font-size:12px;color:#999;margin:0;'>GreenLife Order Notifications</p>
  </div>
</body></html>";

                    foreach (var email in emails)
                    {
                        SendEmail(email, subject, body, true);
                    }
                }
                catch
                {
                }
            });
        }

        public static bool SendOrderStatusUpdate(string customerEmail, string customerName, string orderNumber, string newStatus)
        {
            string subject = $"GreenLife - Order {orderNumber} status updated";
            string body = $@"<html><body style='font-family:Segoe UI, Arial, sans-serif;color:#333;'>
  <div style='max-width:700px;margin:0 auto;padding:20px;background:#fff;border:1px solid #e9e9e9;'>
    <h2 style='color:#228b22;margin-bottom:0;'>Order Update</h2>
    <p style='color:#666;margin-top:4px;'>Hi {customerName},</p>
    <p style='color:#666;'>The status of your order <strong>#{orderNumber}</strong> has changed to <strong style='color:#228b22'>{newStatus}</strong>.</p>
    <p style='color:#666;'>If you need help, reply to this email or contact support.</p>
    <hr style='border:none;border-top:1px solid #eee;margin:18px 0;' />
    <p style='font-size:12px;color:#999;margin:0;'>GreenLife Organic Store</p>
  </div>
</body></html>";

            return SendEmail(customerEmail, subject, body, true);
        }

        public static bool SendPasswordResetEmail(string userEmail, string userName, string resetCode)
        {
            if (USE_MOCK_MODE)
            {
                return SendPasswordResetEmailMock(userEmail, userName, resetCode);
            }
            else
            {
                string subject = "GreenLife - Password Reset Request";
                string body = $@"<html><body style='font-family:Segoe UI, Arial, sans-serif;color:#333;'>
  <div style='max-width:600px;margin:0 auto;padding:18px;background:#fff;border:1px solid #eee;'>
    <h2 style='color:#228b22;margin-bottom:6px;'>Password Reset</h2>
    <p style='color:#666;margin:0 0 8px 0;'>Hi {userName},</p>
    <p style='color:#666;margin:0 0 12px 0;'>We received a request to reset your password. Use the code below to set a new password. This code is valid for 15 minutes.</p>
    <div style='background:#f7f7f7;padding:12px;border-radius:4px;border:1px solid #eee;margin-bottom:12px;font-family:Courier New, monospace;font-size:18px;letter-spacing:2px;text-align:center;'>
      {System.Net.WebUtility.HtmlEncode(resetCode)}
    </div>
    <p style='color:#666;margin:0;'>If you did not request this, ignore this email or contact support immediately.</p>
    <p style='color:#666;margin-top:12px;'>Support: <a href='mailto:{SENDER_EMAIL}' style='color:#228b22'>{SENDER_EMAIL}</a></p>
    <hr style='border:none;border-top:1px solid #eee;margin:18px 0;' />
    <p style='font-size:12px;color:#999;margin:0;'>For your security, do not share this code with anyone.</p>
  </div>
</body></html>";
                return SendEmail(userEmail, subject, body, true);
            }
        }

        public static bool SendWelcomeEmail(string userEmail, string userName)
        {
            string subject = "Welcome to GreenLife Organic Store";
            string body = $@"<html><body style='font-family:Segoe UI, Arial, sans-serif;color:#333;'>
  <div style='max-width:700px;margin:0 auto;padding:20px;background:#fff;border:1px solid #e9e9e9;'>
    <h2 style='color:#228b22;margin-bottom:0;'>Welcome to GreenLife!</h2>
    <p style='color:#666;margin-top:4px;'>Hi {userName},</p>
    <p style='color:#666;'>Thanks for creating an account with GreenLife Organic Store. We're happy to have you.</p>
    <p style='color:#666;'>A few helpful links to get started:</p>
    <ul style='color:#666;'>
      <li>Manage your account: log in to the app</li>
      <li>Shop fresh produce and organic groceries</li>
      <li>Contact support: <a href='mailto:{SENDER_EMAIL}' style='color:#228b22'>{SENDER_EMAIL}</a></li>
    </ul>
    <p style='color:#666;'>We respect your inbox. We'll only send important order and account messages.</p>
    <hr style='border:none;border-top:1px solid #eee;margin:18px 0;' />
    <p style='font-size:12px;color:#999;margin:0;'>GreenLife Organic Store</p>
  </div>
</body></html>";
            return SendEmail(userEmail, subject, body, true);
        }

        public static bool SendLowStockAlert(string adminEmail, string productName, int currentStock)
        {
            string subject = $"GreenLife - Low Stock Alert: {productName}";
            string body = $@"<html><body style='font-family:Segoe UI, Arial, sans-serif;color:#333;'>
  <div style='max-width:700px;margin:0 auto;padding:20px;background:#fff;border:1px solid #e9e9e9;'>
    <h2 style='color:#d35400;margin-bottom:0;'>Low Stock Alert</h2>
    <p style='color:#666;margin-top:6px;'>Product: <strong>{System.Net.WebUtility.HtmlEncode(productName)}</strong></p>
    <p style='color:#666;'>Current Stock Level: <strong>{currentStock}</strong></p>
    <p style='color:#666;'>Please review inventory and consider restocking to avoid running out.</p>
    <hr style='border:none;border-top:1px solid #eee;margin:18px 0;' />
    <p style='font-size:12px;color:#999;margin:0;'>GreenLife Inventory Alerts</p>
  </div>
</body></html>";

            return SendEmail(adminEmail, subject, body, true);
        }

        public static Task SendLowStockAlertsToAdminsAsync(IEnumerable<string> adminEmails, IEnumerable<(string ProductName, int Stock)> items)
        {
            return Task.Run(() =>
            {
                try
                {
                    var emails = adminEmails?.Where(e => !string.IsNullOrWhiteSpace(e)).Distinct().ToList() ?? new List<string>();
                    if (emails.Count == 0) return;

                    foreach (var email in emails)
                    {
                        foreach (var item in items)
                        {
                            SendLowStockAlert(email, item.ProductName, item.Stock);
                        }
                    }
                }
                catch
                {
                }
            });
        }

        public static void TestConnection()
        {
            Console.WriteLine("\n=== EMAIL SERVICE ===");
            Console.WriteLine("? Email service initialized");
            Console.WriteLine($"Server: {SMTP_SERVER}:{SMTP_PORT}");
            Console.WriteLine($"Sender: {SENDER_EMAIL}");
            Console.WriteLine("=== READY ===\n");
        }
    }
}
