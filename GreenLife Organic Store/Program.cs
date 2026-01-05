using System.Windows.Forms;
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
            
            // Start the login form
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
