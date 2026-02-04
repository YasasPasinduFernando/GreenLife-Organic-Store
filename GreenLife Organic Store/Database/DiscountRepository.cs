using MySql.Data.MySqlClient;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Database
{
    // DB operations for discounts
    public class DiscountRepository
    {
        public static List<Discount> GetAllDiscounts()
        {
            var discounts = new List<Discount>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     ORDER BY d.CreatedDate DESC";
                    using (var cmd = new MySqlCommand(query, connection))
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
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     WHERE d.ID = @ID";
                    using (var cmd = new MySqlCommand(query, connection))
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
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     WHERE d.ProductID = @ProductID
                                     ORDER BY d.CreatedDate DESC";
                    using (var cmd = new MySqlCommand(query, connection))
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

        // Returns currently active discount (if any)
        public static Discount? GetActiveDiscountForProduct(int productId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT d.*, p.ProductName FROM Discounts d
                                     LEFT JOIN Products p ON d.ProductID = p.ID
                                     WHERE d.ProductID = @ProductID 
                                     AND d.IsActive = TRUE 
                                     AND NOW() >= d.StartDate 
                                     AND NOW() <= d.EndDate
                                     LIMIT 1";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
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
                    string query = @"INSERT INTO Discounts (DiscountName, Description, DiscountPercent, ProductID, StartDate, EndDate, IsActive) 
                                     VALUES (@DiscountName, @Description, @DiscountPercent, @ProductID, @StartDate, @EndDate, @IsActive);
                                     SELECT LAST_INSERT_ID();";

                    using (var cmd = new MySqlCommand(query, connection))
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
                    string query = @"UPDATE Discounts SET 
                                     DiscountName = @DiscountName,
                                     Description = @Description,
                                     DiscountPercent = @DiscountPercent,
                                     ProductID = @ProductID,
                                     StartDate = @StartDate,
                                     EndDate = @EndDate,
                                     IsActive = @IsActive
                                     WHERE ID = @ID";

                    using (var cmd = new MySqlCommand(query, connection))
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
                    string query = "DELETE FROM Discounts WHERE ID = @ID";

                    using (var cmd = new MySqlCommand(query, connection))
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

        // Updates Products.DiscountPrice based on active discount
        public static void SyncActiveDiscountForProduct(int productId)
        {
            try
            {
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

                using (var cmd = new MySqlCommand(query, connection))
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

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Discount MapReaderToDiscount(MySqlDataReader reader)
        {
            return new Discount
            {
                ID = (int)reader["ID"],
                DiscountName = reader["DiscountName"].ToString() ?? string.Empty,
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                DiscountPercent = (decimal)reader["DiscountPercent"],
                ProductID = (int)reader["ProductID"],
                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() ?? string.Empty : string.Empty,
                StartDate = (DateTime)reader["StartDate"],
                EndDate = (DateTime)reader["EndDate"],
                IsActive = (bool)reader["IsActive"],
                CreatedDate = (DateTime)reader["CreatedDate"],
                UpdatedDate = (DateTime)reader["UpdatedDate"]
            };
        }
    }
}
