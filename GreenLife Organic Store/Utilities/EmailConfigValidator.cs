using System;

namespace GreenLife_Organic_Store.Utilities
{
    /// <summary>
    /// Utility class for validating email configuration
    /// Hard coded configuration for testing
    /// </summary>
    public static class EmailConfigValidator
    {
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "greenlifeorganicstore@gmail.com";
        private const string SENDER_PASSWORD = "7wuxomt563@xkxkud.com";
        private const string SENDER_NAME = "GreenLife Organic Store";

        /// <summary>
        /// Checks if email is properly configured
        /// </summary>
        /// <returns>True if email is configured, false otherwise</returns>
        public static bool IsEmailConfigured()
        {
            // Hard coded values are always configured
            bool hasSmtpServer = !string.IsNullOrWhiteSpace(SMTP_SERVER);
            bool hasValidEmail = !string.IsNullOrWhiteSpace(SENDER_EMAIL) && SENDER_EMAIL.Contains("@");
            bool hasValidPassword = !string.IsNullOrWhiteSpace(SENDER_PASSWORD);

            return hasSmtpServer && hasValidEmail && hasValidPassword;
        }

        /// <summary>
        /// Gets the configured sender email
        /// </summary>
        public static string GetConfiguredEmail()
        {
            return SENDER_EMAIL;
        }

        /// <summary>
        /// Gets configuration status message
        /// </summary>
        public static string GetConfigurationStatus()
        {
            if (IsEmailConfigured())
            {
                return $"? Email is configured: {SENDER_EMAIL}";
            }

            return "? Email Configuration Issues - Check hardcoded values";
        }

        /// <summary>
        /// Logs current email configuration status to console
        /// </summary>
        public static void LogConfigurationStatus()
        {
            Console.WriteLine("=== Email Configuration Status ===");
            Console.WriteLine($"Email Service: ? CONFIGURED");
            Console.WriteLine($"Mode: MOCK MODE (Simulated - No Gmail needed)");
            Console.WriteLine($"SMTP Server: smtp.gmail.com:587");
            Console.WriteLine($"Sender Email: greenlifeorganicstore@gmail.com");
            Console.WriteLine($"Status: ? READY FOR TESTING");
            Console.WriteLine($"Note: Emails are simulated. See EMAIL_SETUP_SIMPLE.md to enable real Gmail.");
            Console.WriteLine("==================================\n");
        }
    }
}
