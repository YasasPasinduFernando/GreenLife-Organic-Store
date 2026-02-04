using Microsoft.Data.Sqlite;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;

namespace GreenLife_Organic_Store.Database
{
    // DB operations for products
    public class ProductRepository
    {
        public static List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT p.*, c.CategoryName FROM Products p
                                     LEFT JOIN Categories c ON p.CategoryID = c.ID
                                     WHERE p.IsActive = 1
                                     ORDER BY p.CreatedDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(MapReaderToProduct(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all products: {ex.Message}", ex);
            }

            return products;
        }

        public static Product? GetProductById(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT p.*, c.CategoryName FROM Products p
                                     LEFT JOIN Categories c ON p.CategoryID = c.ID
                                     WHERE p.ID = @ID";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToProduct(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving product by ID: {ex.Message}", ex);
            }

            return null;
        }

        // Filter by category (DB-level WHERE)
        public static List<Product> GetProductsByCategory(int categoryId)
        {
            var products = new List<Product>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT p.*, c.CategoryName FROM Products p
                                     LEFT JOIN Categories c ON p.CategoryID = c.ID
                                     WHERE p.CategoryID = @CategoryID AND p.IsActive = 1
                                     ORDER BY p.ProductName";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(MapReaderToProduct(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving products by category: {ex.Message}", ex);
            }

            return products;
        }

        // Linear search - coursework requires in-memory search
        public static List<Product> SearchProducts(string searchTerm)
        {
            var allProducts = GetAllProducts();
            
            var results = new List<Product>();
            foreach (var product in allProducts)
            {
                if (product.ProductName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (product.Description != null && 
                     product.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    results.Add(product);
                }
            }

            return results;
        }

        public static List<Product> GetFeaturedProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT p.*, c.CategoryName FROM Products p
                                     LEFT JOIN Categories c ON p.CategoryID = c.ID
                                     WHERE p.IsFeatured = 1 AND p.IsActive = 1
                                     ORDER BY p.CreatedDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(MapReaderToProduct(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving featured products: {ex.Message}", ex);
            }

            return products;
        }

        // Stock <= 10 means low stock
        public static List<Product> GetLowStockProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT p.*, c.CategoryName FROM Products p
                                     LEFT JOIN Categories c ON p.CategoryID = c.ID
                                     WHERE p.Stock <= 10 AND p.IsActive = 1
                                     ORDER BY p.Stock ASC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(MapReaderToProduct(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving low stock products: {ex.Message}", ex);
            }

            return products;
        }

        public static int CreateProduct(Product product)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Products (ProductName, CategoryID, Description, Price, DiscountPrice, Stock, Supplier, ImagePath, IsFeatured) 
                                     VALUES (@ProductName, @CategoryID, @Description, @Price, @DiscountPrice, @Stock, @Supplier, @ImagePath, @IsFeatured);
                                     SELECT LAST_INSERT_ID();";

                    using (var cmd = new SqliteCommand(@"INSERT INTO Products (ProductName, CategoryID, Description, Price, DiscountPrice, Stock, Supplier, ImagePath, IsFeatured, CreatedDate, UpdatedDate, IsActive)
                                     VALUES (@ProductName, @CategoryID, @Description, @Price, @DiscountPrice, @Stock, @Supplier, @ImagePath, @IsFeatured, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1);", connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                        cmd.Parameters.AddWithValue("@Description", (object?)product.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@DiscountPrice", (object?)product.DiscountPrice ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Stock", product.Stock);
                        cmd.Parameters.AddWithValue("@Supplier", (object?)product.Supplier ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImagePath", (object?)product.ImagePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsFeatured", product.IsFeatured ? 1 : 0);

                        cmd.ExecuteNonQuery();
                        using var idCmd = new SqliteCommand("SELECT last_insert_rowid();", connection);
                        var result = idCmd.ExecuteScalar();
                        if (result != null && long.TryParse(result.ToString(), out long lid))
                        {
                            if (product.Stock <= 10)
                            {
                                var admins = UserRepository.GetAdminEmails();
                                _ = EmailService.SendLowStockAlertsToAdminsAsync(admins, new[] { ((product.ProductName ?? string.Empty), product.Stock) });
                            }
                            return (int)lid;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating product: {ex.Message}", ex);
            }

            return 0;
        }

        public static bool UpdateProduct(Product product)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Products SET 
                                     ProductName = @ProductName,
                                     CategoryID = @CategoryID,
                                     Description = @Description,
                                     Price = @Price,
                                     DiscountPrice = @DiscountPrice,
                                     Stock = @Stock,
                                     Supplier = @Supplier,
                                     ImagePath = COALESCE(NULLIF(@ImagePath, ''), ImagePath),
                                     IsFeatured = @IsFeatured,
                                     IsActive = @IsActive
                                     WHERE ID = @ID";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", product.ID);
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                        cmd.Parameters.AddWithValue("@Description", (object?)product.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@DiscountPrice", (object?)product.DiscountPrice ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Stock", product.Stock);
                        cmd.Parameters.AddWithValue("@Supplier", (object?)product.Supplier ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImagePath", (object?)product.ImagePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsFeatured", product.IsFeatured ? 1 : 0);
                        cmd.Parameters.AddWithValue("@IsActive", product.IsActive);

                        var updated = cmd.ExecuteNonQuery() > 0;
                        if (updated && product.Stock <= 10)
                        {
                            var admins = UserRepository.GetAdminEmails();
                            _ = EmailService.SendLowStockAlertsToAdminsAsync(admins, new[] { ((product.ProductName ?? string.Empty), product.Stock) });
                        }
                        return updated;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}", ex);
            }
        }

        public static bool DeleteProduct(int productId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Products WHERE ID = @ID";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", productId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}", ex);
            }
        }

        public static bool ReduceStock(int productId, int quantity)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Products SET Stock = Stock - @Quantity WHERE ID = @ID AND Stock >= @Quantity";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reducing product stock: {ex.Message}", ex);
            }
        }

        // Map DB row to Product object
        private static Product MapReaderToProduct(SqliteDataReader reader)
        {
            return new Product
            {
                ID = Convert.ToInt32(reader["ID"]),
                ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                CategoryID = reader["CategoryID"] != DBNull.Value ? Convert.ToInt32(reader["CategoryID"]) : 0,
                CategoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"]?.ToString() ?? string.Empty : string.Empty,
                Description = reader["Description"] != DBNull.Value ? reader["Description"]?.ToString() : null,
                Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0m,
                DiscountPrice = reader["DiscountPrice"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["DiscountPrice"]) : null,
                Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0,
                Supplier = reader["Supplier"] != DBNull.Value ? reader["Supplier"]?.ToString() : null,
                ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"]?.ToString() : null,
                IsFeatured = reader["IsFeatured"] != DBNull.Value ? Convert.ToInt32(reader["IsFeatured"]) == 1 : false,
                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.MinValue,
                UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedDate"]) : DateTime.MinValue,
                IsActive = reader["IsActive"] != DBNull.Value ? Convert.ToInt32(reader["IsActive"]) == 1 : true
            };
        }
    }
}
