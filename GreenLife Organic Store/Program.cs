using System.Windows.Forms;
using System.IO;
using GreenLife_Organic_Store.Forms;
using GreenLife_Organic_Store.Utilities;

namespace GreenLife_Organic_Store
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            Console.WriteLine("\n========================================");
            Console.WriteLine("GreenLife Organic Store - Starting Up");
            Console.WriteLine($"Started at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("========================================\n");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                ImageStore.EnsureImagesDirectoryExists();
            }
            catch
            {
            }

            try
            {
                EmailConfigValidator.LogConfigurationStatus();
                EmailService.TestConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Startup] Warning: Could not log email configuration: {ex.Message}\n");
            }
            
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
