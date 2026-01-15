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
            // Ensure proper DPI scaling across resolutions.
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            // Log application startup
            Console.WriteLine("\n========================================");
            Console.WriteLine("GreenLife Organic Store - Starting Up");
            Console.WriteLine($"Started at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("========================================\n");

            // Enable visual styles for Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Create and apply application icon
            try
            {
                ApplyApplicationIcon();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Startup] Warning: Could not apply application icon: {ex.Message}");
            }
            
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

        /// <summary>
        /// Creates and applies a green leaf application icon
        /// </summary>
        private static Icon CreateApplicationIcon()
        {
            int iconSize = 32;
            Bitmap bitmap = new Bitmap(iconSize, iconSize);
            
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                
                // Draw a green leaf shape
                Color leafGreen = Color.FromArgb(34, 139, 34); // Forest Green
                using (Brush leafBrush = new SolidBrush(leafGreen))
                using (Pen leafPen = new Pen(leafGreen, 2))
                {
                    // Main leaf body (ellipse)
                    g.FillEllipse(leafBrush, 6, 4, 20, 24);
                    
                    // Leaf vein (line down the middle)
                    g.DrawLine(leafPen, 16, 4, 16, 28);
                    
                    // Small vein branches
                    g.DrawLine(new Pen(leafGreen, 1), 12, 10, 8, 8);
                    g.DrawLine(new Pen(leafGreen, 1), 20, 10, 24, 8);
                    g.DrawLine(new Pen(leafGreen, 1), 10, 18, 5, 17);
                    g.DrawLine(new Pen(leafGreen, 1), 22, 18, 27, 17);
                }
            }
            
            IntPtr hIcon = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);
            bitmap.Dispose();
            return icon;
        }

        private static void ApplyApplicationIcon()
        {
            Icon appIcon = CreateApplicationIcon();
            // Store it in a static field to keep it alive
            s_applicationIcon = appIcon;
        }

        private static Icon? s_applicationIcon;
    }
}
