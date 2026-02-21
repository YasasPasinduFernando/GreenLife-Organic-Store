using MySql.Data.MySqlClient;

namespace GreenLife_Organic_Store.Database
{
    // MySQL connection helper
    public class DatabaseConnection
    {
        // Local dev settings - change for production
        private static readonly string ConnectionString = "Server=localhost;Port=3307;Database=greenlife;Uid=root;Pwd=yasas;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

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
