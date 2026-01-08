using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Utilities
{
    /// <summary>
    /// Email service for sending emails via Gmail SMTP.
    /// </summary>
    public static class EmailService
    {
        // Hard coded configuration
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "greenlifeorganicstore@gmail.com";
        private const string SENDER_PASSWORD = "nede eilq sypk nhrx"; // Gmail App Password
        private const string SENDER_NAME = "GreenLife Organic Store";
        
        // Set to TRUE for mock mode (testing without Gmail)
        // Set to FALSE for real Gmail SMTP
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

        /// <summary>
        /// Mock email sender - for testing without Gmail
        /// </summary>
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

        /// <summary>
        /// Special method to handle password reset emails in mock mode
        /// Shows the reset code to the user via MessageBox
        /// </summary>
        public static bool SendPasswordResetEmailMock(string toEmail, string userName, string resetCode)
        {
            try
            {
                // In MOCK MODE, show the reset code in a messagebox so user can see it
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

        /// <summary>
        /// Real SMTP email sender - requires valid Gmail app password
        /// </summary>
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
            // Minimal logging - no timestamps or extra formatting
        }

        private static void LogEmailError(string message)
        {
            // Log errors only
            Console.WriteLine($"? {message}");
        }

        public static bool SendOrderConfirmation(string customerEmail, string customerName, string orderNumber, decimal totalAmount, List<OrderItem> items)
        {
            string subject = $"Order Confirmation - {orderNumber}";
            string body = $"<!doctype html><html><body><div style='font-family:Arial,sans-serif'><h2>Order Confirmation</h2><p>Dear {customerName},</p><p>Thank you for your order.</p><p><strong>Order:</strong> {orderNumber}</p><p><strong>Total:</strong> Rs. {totalAmount:N2}</p><hr/>";
            foreach (var i in items)
            {
                body += $"<div>{i.ProductName} x {i.Quantity} = Rs. {i.Subtotal:N2}</div>";
            }
            body += "</div></body></html>";
            return SendEmail(customerEmail, subject, body, true);
        }

        public static bool SendOrderStatusUpdate(string customerEmail, string customerName, string orderNumber, string newStatus)
        {
            string subject = $"Order Update - {orderNumber} is now {newStatus}";
            string body = $"<html><body><div style='font-family:Arial,sans-serif'><h2>Order Status Updated</h2><p>Dear {customerName},</p><p>Your order <strong>{orderNumber}</strong> status is now <strong>{newStatus}</strong>.</p></div></body></html>";
            return SendEmail(customerEmail, subject, body, true);
        }

        public static bool SendPasswordResetEmail(string userEmail, string userName, string resetCode)
        {
            if (USE_MOCK_MODE)
            {
                // In mock mode, show the code to the user
                return SendPasswordResetEmailMock(userEmail, userName, resetCode);
            }
            else
            {
                string subject = "Password Reset Request - GreenLife Organic Store";
                string body = $"<html><body><div style='font-family:Arial,sans-serif'><h2>Password Reset</h2><p>Dear {userName},</p><p>Your password reset code: <strong>{resetCode}</strong></p><p>This code expires in 15 minutes.</p></div></body></html>";
                return SendEmail(userEmail, subject, body, true);
            }
        }

        public static bool SendWelcomeEmail(string userEmail, string userName)
        {
            string subject = "Welcome to GreenLife Organic Store!";
            string body = $"<html><body><div style='font-family:Arial,sans-serif'><h2>Welcome {userName}!</h2><p>Thank you for registering at GreenLife Organic Store.</p></div></body></html>";
            return SendEmail(userEmail, subject, body, true);
        }

        public static bool SendLowStockAlert(string adminEmail, string productName, int currentStock)
        {
            string subject = $"Low Stock Alert: {productName}";
            string body = $"<html><body><div style='font-family:Arial,sans-serif'><h2>Low Stock Alert</h2><p>Product: {productName}</p><p>Current Stock: {currentStock}</p></div></body></html>";
            return SendEmail(adminEmail, subject, body, true);
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
