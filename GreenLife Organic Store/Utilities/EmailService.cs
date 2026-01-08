using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Utilities
{
    /// <summary>
    /// Email service for sending emails.
    /// Currently runs in MOCK MODE for testing (doesn't require Gmail).
    /// Set USE_MOCK_MODE = false and add real password when ready to send real emails.
    /// </summary>
    public static class EmailService
    {
        // Hard coded configuration
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "greenlifeorganicstore@gmail.com";
        private const string SENDER_PASSWORD = "your-16-char-gmail-app-password-here"; // TODO: Replace with real Gmail app password
        private const string SENDER_NAME = "GreenLife Organic Store";
        
        // ? MOCK MODE: Set to TRUE for testing WITHOUT Gmail (Recommended for now)
        //    Set to FALSE when you have a valid 16-character Gmail app password
        private const bool USE_MOCK_MODE = true;

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
                Console.WriteLine($"[EmailService-MOCK] ? Email simulated to: {toEmail}");
                Console.WriteLine($"[EmailService-MOCK] Subject: {subject}");
                LogEmailSuccess(toEmail, subject);
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
                Console.WriteLine($"[EmailService] Sending via Gmail SMTP to {toEmail}...");

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
                LogEmailError($"SMTP Error ({smtpEx.StatusCode}): {smtpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                LogEmailError($"Error: {ex.GetType().Name} - {ex.Message}");
                return false;
            }
        }

        private static void LogEmailSuccess(string toEmail, string subject)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ? Email to {toEmail} - {subject}");
        }

        private static void LogEmailError(string message)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ? Email Error: {message}");
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
            string subject = "Password Reset Request - GreenLife Organic Store";
            string body = $"<html><body><div style='font-family:Arial,sans-serif'><h2>Password Reset</h2><p>Dear {userName},</p><p>Your password reset code: <strong>{resetCode}</strong></p><p>This code expires in 15 minutes.</p></div></body></html>";
            return SendEmail(userEmail, subject, body, true);
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
            Console.WriteLine("\n=== EMAIL SERVICE TEST ===");
            if (USE_MOCK_MODE)
            {
                Console.WriteLine("? MOCK MODE ENABLED - Emails are simulated");
                Console.WriteLine("? All email functions will appear to work");
                Console.WriteLine("? No real emails will be sent");
                Console.WriteLine("\nTo enable real Gmail emails:");
                Console.WriteLine("1. Set USE_MOCK_MODE = false");
                Console.WriteLine("2. Replace SENDER_PASSWORD with valid 16-char Gmail app password");
                Console.WriteLine("3. Get app password from: https://myaccount.google.com/apppasswords");
            }
            else
            {
                Console.WriteLine("REAL MODE - Using Gmail SMTP");
                Console.WriteLine($"Server: {SMTP_SERVER}:{SMTP_PORT}");
                Console.WriteLine($"Email: {SENDER_EMAIL}");
            }
            Console.WriteLine("=== TEST COMPLETE ===\n");
        }
    }
}
