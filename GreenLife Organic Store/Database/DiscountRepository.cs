using Microsoft.Data.Sqlite;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Database
{
    // DB operations for discounts
    public class DiscountRepository
    {
        private static void EnsureSchema(SqliteConnection connection)
        {
            // Create Discounts table if missing
            const string createDiscountsSql = @"CREATE TABLE IF NOT EXISTS Discounts (
                                                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    DiscountName TEXT NOT NULL,
                                                    Description TEXT,
                                                    DiscountPercent REAL NOT NULL,
                                                    ProductID INTEGER NOT NULL,
                                                    StartDate TEXT DEFAULT CURRENT_TIMESTAMP,
                                                    EndDate TEXT NOT NULL,
                                                    IsActive INTEGER DEFAULT 1,
                                                    CreatedDate TEXT DEFAULT CURRENT_TIMESTAMP,
                                                    UpdatedDate TEXT DEFAULT CURRENT_TIMESTAMP,
                                                    FOREIGN KEY (ProductID) REFERENCES Products(ID) ON DELETE CASCADE
                                                );";
            using (var cmd = new SqliteCommand(createDiscountsSql, connection))
            {
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SqliteCommand("CREATE INDEX IF NOT EXISTS idx_discounts_product_id ON Discounts(ProductID);", connection))
            {
                cmd.ExecuteNonQuery();
            }
            using (var cmd = new SqliteCommand("CREATE INDEX IF NOT EXISTS idx_discounts_active ON Discounts(IsActive);", connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Add DiscountPrice column if missing
            bool hasDiscountPrice = false;
            using (var cmd = new SqliteCommand("PRAGMA table_info(Products);", connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader["name"]?.ToString();
                    if (string.Equals(name, "DiscountPrice", StringComparison.OrdinalIgnoreCase))
                    {
                        hasDiscountPrice = true;
                        break;
                    }
                }
            }
            if (!hasDiscountPrice)
            {
                using (var cmd = new SqliteCommand("ALTER TABLE Products ADD COLUMN DiscountPrice REAL;", connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Discount> GetAllDiscounts()
        {
            var discounts = new List<Discount>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     ORDER BY d.CreatedDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                discounts.Add(MapReaderToDiscount(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all discounts: {ex.Message}", ex);
            }

            return discounts;
        }

        public static Discount? GetDiscountById(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     WHERE d.ID = @ID";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToDiscount(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving discount by ID: {ex.Message}", ex);
            }

            return null;
        }

        public static List<Discount> GetDiscountsByProductId(int productId)
        {
            var discounts = new List<Discount>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     WHERE d.ProductID = @ProductID
                                     ORDER BY d.CreatedDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                discounts.Add(MapReaderToDiscount(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving discounts by product: {ex.Message}", ex);
            }

            return discounts;
        }

        // Check date range to see if discount is currently active
        public static Discount? GetActiveDiscountForProduct(int productId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     WHERE d.ProductID = @ProductID 
                                     AND d.IsActive = 1
                                     ORDER BY d.StartDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var now = DateTime.Now;
                            while (reader.Read())
                            {
                                var discount = MapReaderToDiscount(reader);
                                if (now >= discount.StartDate && now <= discount.EndDate)
                                {
                                    return discount;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving active discount: {ex.Message}", ex);
            }

            return null;
        }

        public static int CreateDiscount(Discount discount)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                    string query = @"INSERT INTO Discounts (DiscountName, Description, DiscountPercent, ProductID, StartDate, EndDate, IsActive) 
                                     VALUES (@DiscountName, @Description, @DiscountPercent, @ProductID, @StartDate, @EndDate, @IsActive);
                                     SELECT last_insert_rowid();";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DiscountName", discount.DiscountName);
                        cmd.Parameters.AddWithValue("@Description", (object?)discount.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DiscountPercent", discount.DiscountPercent);
                        cmd.Parameters.AddWithValue("@ProductID", discount.ProductID);
                        cmd.Parameters.AddWithValue("@StartDate", discount.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", discount.EndDate);
                        cmd.Parameters.AddWithValue("@IsActive", discount.IsActive);

                        var result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            return id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating discount: {ex.Message}", ex);
            }

            return 0;
        }

        public static bool UpdateDiscount(Discount discount)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                    string query = @"UPDATE Discounts SET 
                                     DiscountName = @DiscountName,
                                     Description = @Description,
                                     DiscountPercent = @DiscountPercent,
                                     ProductID = @ProductID,
                                     StartDate = @StartDate,
                                     EndDate = @EndDate,
                                     IsActive = @IsActive
                                     WHERE ID = @ID";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", discount.ID);
                        cmd.Parameters.AddWithValue("@DiscountName", discount.DiscountName);
                        cmd.Parameters.AddWithValue("@Description", (object?)discount.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DiscountPercent", discount.DiscountPercent);
                        cmd.Parameters.AddWithValue("@ProductID", discount.ProductID);
                        cmd.Parameters.AddWithValue("@StartDate", discount.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", discount.EndDate);
                        cmd.Parameters.AddWithValue("@IsActive", discount.IsActive);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating discount: {ex.Message}", ex);
            }
        }

        public static bool DeleteDiscount(int discountId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                    string query = "DELETE FROM Discounts WHERE ID = @ID";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", discountId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting discount: {ex.Message}", ex);
            }
        }

        // Update product's discount price based on active discount
        public static void SyncActiveDiscountForProduct(int productId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    EnsureSchema(connection);
                }
                var activeDiscount = GetActiveDiscountForProduct(productId);
                if (activeDiscount != null)
                {
                    ApplyDiscountPercentToProduct(productId, activeDiscount.DiscountPercent);
                }
                else
                {
                    ClearProductDiscountPrice(productId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error syncing product discount price: {ex.Message}", ex);
            }
        }

        private static void ApplyDiscountPercentToProduct(int productId, decimal discountPercent)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Products 
                                 SET DiscountPrice = ROUND(Price - (Price * (@DiscountPercent / 100)), 2)
                                 WHERE ID = @ID";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", productId);
                    cmd.Parameters.AddWithValue("@DiscountPercent", discountPercent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void ClearProductDiscountPrice(int productId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Products SET DiscountPrice = NULL WHERE ID = @ID";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Map DB row to Discount object
        private static Discount MapReaderToDiscount(SqliteDataReader reader)
        {
            return new Discount
            {
                ID = Convert.ToInt32(reader["ID"]),
                DiscountName = reader["DiscountName"].ToString() ?? string.Empty,
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"]),
                ProductID = Convert.ToInt32(reader["ProductID"]),
                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() ?? string.Empty : string.Empty,
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = Convert.ToDateTime(reader["EndDate"]),
                IsActive = Convert.ToInt32(reader["IsActive"]) == 1,
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"])
            };
        }
    }
}
