using Microsoft.Data.Sqlite;
using System.IO;

namespace GreenLife_Organic_Store.Database
{
    /// <summary>
    /// Manages SQLite database connections for the GreenLife application
    /// </summary>
    public class DatabaseConnection
    {
        private static readonly string DbFileName = "greenlife.db";

        private static string GetDatabaseFilePath()
        {
            // Database file stored in the application's executable directory under "Database"
            var baseDir = AppContext.BaseDirectory;
            var dbDir = Path.Combine(baseDir, "Database");
            if (!Directory.Exists(dbDir)) Directory.CreateDirectory(dbDir);
            return Path.Combine(dbDir, DbFileName);
        }

        private static string GetConnectionString()
        {
            var dbPath = GetDatabaseFilePath();
            return new SqliteConnectionStringBuilder { DataSource = dbPath }.ToString();
        }

        /// <summary>
        /// Gets a new database connection
        /// </summary>
        /// <returns>A new SqliteConnection object</returns>
        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(GetConnectionString());
        }

        /// <summary>
        /// Tests the database connection
        /// </summary>
        /// <returns>True if connection is successful, false otherwise</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
