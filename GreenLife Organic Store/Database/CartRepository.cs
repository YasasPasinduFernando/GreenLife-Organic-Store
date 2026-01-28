using MySql.Data.MySqlClient;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Database
{
    /// <summary>
    /// Repository for persisting shopping cart items in the database
    /// </summary>
    public static class CartRepository
    {
        public static void AddOrUpdateCartItem(int userId, int productId, int quantity)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Try update existing (increment quantity)
                    const string updateSql = "UPDATE CartItems SET Quantity = Quantity + @Quantity, UpdatedDate = NOW() WHERE UserID = @UserID AND ProductID = @ProductID";
                    using (var cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        var affected = cmd.ExecuteNonQuery();
                        if (affected > 0) return; // updated
                    }

                    // Insert new
                    const string insertSql = "INSERT INTO CartItems (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, @Quantity)";
                    using (var cmd = new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding/updating cart item: {ex.Message}", ex);
            }
        }

        public static int GetCartItemCount(int userId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT IFNULL(SUM(Quantity),0) FROM CartItems WHERE UserID = @UserID";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        var result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int count))
                            return count;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting cart count: {ex.Message}", ex);
            }

            return 0;
        }

        /// <summary>
        /// Gets all cart items for a user as a mapping of ProductID => Quantity
        /// </summary>
        public static Dictionary<int, int> GetCartItems(int userId)
        {
            var result = new Dictionary<int, int>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT ProductID, Quantity FROM CartItems WHERE UserID = @UserID";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int pid = Convert.ToInt32(reader["ProductID"]);
                                int qty = Convert.ToInt32(reader["Quantity"]);
                                result[pid] = qty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting cart items: {ex.Message}", ex);
            }

            return result;
        }

        public static void ClearCart(int userId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "DELETE FROM CartItems WHERE UserID = @UserID";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error clearing cart: {ex.Message}", ex);
            }
        }

        public static void SetCartItemQuantity(int userId, int productId, int quantity)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    if (quantity <= 0)
                    {
                        RemoveCartItem(userId, productId);
                        return;
                    }

                    const string sql = "UPDATE CartItems SET Quantity = @Quantity, UpdatedDate = NOW() WHERE UserID = @UserID AND ProductID = @ProductID";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        var affected = cmd.ExecuteNonQuery();
                        if (affected > 0) return;
                    }

                    // If no existing row, insert a new one
                    const string insertSql = "INSERT INTO CartItems (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, @Quantity)";
                    using (var cmd = new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error setting cart item quantity: {ex.Message}", ex);
            }
        }

        public static void RemoveCartItem(int userId, int productId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "DELETE FROM CartItems WHERE UserID = @UserID AND ProductID = @ProductID";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing cart item: {ex.Message}", ex);
            }
        }
    }
}
