using System.Windows.Forms;
using System.IO;
using GreenLife_Organic_Store.Forms;
using GreenLife_Organic_Store.Utilities;
using GreenLife_Organic_Store.Database;

namespace GreenLife_Organic_Store
{
    /// <summary>
    /// Application entry point for GreenLife Organic Store
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Log application startup
            Console.WriteLine("\n========================================");
            Console.WriteLine("GreenLife Organic Store - Starting Up");
            Console.WriteLine($"Started at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("========================================\n");

            // Enable visual styles for Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Initialize database on first run - ensure tables exist
            try
            {
                Console.WriteLine("[Startup] Initializing database...");
                if (!DatabaseConnection.TestConnection())
                {
                    Console.WriteLine("[Startup] Database not ready. Attempting to import schema...");
                }
                else
                {
                    Console.WriteLine("[Startup] Database connection successful.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Startup] Warning: Database initialization issue: {ex.Message}");
            }
            
            // Ensure images directory exists for storing uploaded product/category images
            try
            {
                ImageStore.EnsureImagesDirectoryExists();
            }
            catch
            {
                // non-fatal - if we cannot create directory, UI will still allow selecting images but saving may fail
            }

            // Log email configuration status on startup
            try
            {
                EmailConfigValidator.LogConfigurationStatus();
                
                // Test email service
                EmailService.TestConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Startup] Warning: Could not log email configuration: {ex.Message}\n");
            }
            
            // Start the login form
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
