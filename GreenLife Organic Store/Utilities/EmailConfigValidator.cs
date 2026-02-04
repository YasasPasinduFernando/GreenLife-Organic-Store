using System;

namespace GreenLife_Organic_Store.Utilities
{
    // Checks email config
    public static class EmailConfigValidator
    {
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "greenlifeorganicstore@gmail.com";
        private const string SENDER_PASSWORD = "7wuxomt563@xkxkud.com";
        private const string SENDER_NAME = "GreenLife Organic Store";

        public static bool IsEmailConfigured()
        {
            bool hasSmtpServer = !string.IsNullOrWhiteSpace(SMTP_SERVER);
            bool hasValidEmail = !string.IsNullOrWhiteSpace(SENDER_EMAIL) && SENDER_EMAIL.Contains("@");
            bool hasValidPassword = !string.IsNullOrWhiteSpace(SENDER_PASSWORD);

            return hasSmtpServer && hasValidEmail && hasValidPassword;
        }

        public static string GetConfiguredEmail()
        {
            return SENDER_EMAIL;
        }

        public static string GetConfigurationStatus()
        {
            if (IsEmailConfigured())
            {
                return $"? Email is configured: {SENDER_EMAIL}";
            }

            return "? Email Configuration Issues - Check hardcoded values";
        }

        public static void LogConfigurationStatus()
        {
            Console.WriteLine("=== Email Configuration ===");
            Console.WriteLine($"Email Service: ? Active");
            Console.WriteLine($"Sender: greenlifeorganicstore@gmail.com");
            Console.WriteLine("==================================\n");
        }
    }
}
