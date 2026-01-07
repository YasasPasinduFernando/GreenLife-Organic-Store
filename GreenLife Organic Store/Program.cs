using System.Windows.Forms;
using System.IO;
using GreenLife_Organic_Store.Forms;

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
            // Enable visual styles for Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ensure images directory exists for storing uploaded product/category images
            try
            {
                var imagesDir = Path.Combine(Application.StartupPath, "images");
                Directory.CreateDirectory(imagesDir);
            }
            catch
            {
                // non-fatal - if we cannot create directory, UI will still allow selecting images but saving may fail
            }
            
            // Start the login form
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
