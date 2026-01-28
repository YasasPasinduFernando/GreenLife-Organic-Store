using MySql.Data.MySqlClient;

namespace GreenLife_Organic_Store.Database
{
    /// <summary>
    /// Manages MySQL database connections for the GreenLife application
    /// </summary>
    public class DatabaseConnection
    {
        // Connection string for local development
        // Server: localhost
        // Port: 3307 (default MySQL port)
        // Username: yasas
        // Password: yasas
        private static readonly string ConnectionString = "Server=localhost;Port=3306;Database=greenlife;Uid=yasas;Pwd=yasas;";

        /// <summary>
        /// Gets a new database connection
        /// </summary>
        /// <returns>A new MySqlConnection object</returns>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
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
