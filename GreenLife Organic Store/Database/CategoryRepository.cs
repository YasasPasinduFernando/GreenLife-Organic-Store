using MySql.Data.MySqlClient;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Database
{
    // DB operations for categories
    public class CategoryRepository
    {
        public static List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories WHERE IsActive = TRUE ORDER BY CategoryName";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(MapReaderToCategory(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all categories: {ex.Message}", ex);
            }

            return categories;
        }

        public static Category? GetCategoryById(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories WHERE ID = @ID";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToCategory(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving category by ID: {ex.Message}", ex);
            }

            return null;
        }

        public static Category? GetCategoryByName(string categoryName)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories WHERE CategoryName = @CategoryName";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToCategory(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving category by name: {ex.Message}", ex);
            }

            return null;
        }

        public static int CreateCategory(Category category)
        {
            try
            {
                // Name must be unique
                if (GetCategoryByName(category.CategoryName) != null)
                {
                    throw new Exception("Category name already exists");
                }

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Categories (CategoryName, Description, ImagePath) 
                                     VALUES (@CategoryName, @Description, @ImagePath);
                                     SELECT LAST_INSERT_ID();";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                        cmd.Parameters.AddWithValue("@Description", (object?)category.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImagePath", (object?)category.ImagePath ?? DBNull.Value);

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
                throw new Exception($"Error creating category: {ex.Message}", ex);
            }

            return 0;
        }

        public static bool UpdateCategory(Category category)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Categories SET 
                                     CategoryName = @CategoryName,
                                     Description = @Description,
                                     ImagePath = @ImagePath,
                                     IsActive = @IsActive
                                     WHERE ID = @ID";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", category.ID);
                        cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                        cmd.Parameters.AddWithValue("@Description", (object?)category.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImagePath", (object?)category.ImagePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsActive", category.IsActive);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating category: {ex.Message}", ex);
            }
        }

        public static bool DeleteCategory(int categoryId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Categories WHERE ID = @ID";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", categoryId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting category: {ex.Message}", ex);
            }
        }

        private static Category MapReaderToCategory(MySqlDataReader reader)
        {
            return new Category
            {
                ID = (int)reader["ID"],
                CategoryName = reader["CategoryName"].ToString() ?? string.Empty,
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : null,
                CreatedDate = (DateTime)reader["CreatedDate"],
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
