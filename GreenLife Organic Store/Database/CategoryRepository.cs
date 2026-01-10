using Microsoft.Data.Sqlite;
using GreenLife_Organic_Store.Models;

namespace GreenLife_Organic_Store.Database
{
    /// <summary>
    /// Repository class for Category database operations
    /// </summary>
    public class CategoryRepository
    {
        /// <summary>
        /// Gets all active categories
        /// </summary>
        /// <returns>List of all active categories</returns>
        public static List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories WHERE IsActive = 1 ORDER BY CategoryName";
                    using (var cmd = new SqliteCommand(query, connection))
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

        /// <summary>
        /// Gets a category by ID
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <returns>Category object if found, null otherwise</returns>
        public static Category? GetCategoryById(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories WHERE ID = @ID";
                    using (var cmd = new SqliteCommand(query, connection))
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

        /// <summary>
        /// Gets a category by name
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// <returns>Category object if found, null otherwise</returns>
        public static Category? GetCategoryByName(string categoryName)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories WHERE CategoryName = @CategoryName";
                    using (var cmd = new SqliteCommand(query, connection))
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

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="category">Category object to create</param>
        /// <returns>The ID of the created category</returns>
        public static int CreateCategory(Category category)
        {
            try
            {
                // Validate category name doesn't exist
                if (GetCategoryByName(category.CategoryName) != null)
                {
                    throw new Exception("Category name already exists");
                }

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Categories (CategoryName, Description, ImagePath, CreatedDate, IsActive) 
                                     VALUES (@CategoryName, @Description, @ImagePath, CURRENT_TIMESTAMP, 1);";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                        cmd.Parameters.AddWithValue("@Description", (object?)category.Description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImagePath", (object?)category.ImagePath ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                        using var idCmd = new SqliteCommand("SELECT last_insert_rowid();", connection);
                        var result = idCmd.ExecuteScalar();
                        if (result != null && long.TryParse(result.ToString(), out long lid))
                        {
                            return (int)lid;
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

        /// <summary>
        /// Updates an existing category
        /// </summary>
        /// <param name="category">Category object with updated information</param>
        /// <returns>True if update was successful, false otherwise</returns>
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

                    using (var cmd = new SqliteCommand(query, connection))
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

        /// <summary>
        /// Deletes a category
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public static bool DeleteCategory(int categoryId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Categories WHERE ID = @ID";

                    using (var cmd = new SqliteCommand(query, connection))
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

        /// <summary>
        /// Maps a database reader to a Category object
        /// </summary>
        private static Category MapReaderToCategory(SqliteDataReader reader)
        {
            return new Category
            {
                ID = Convert.ToInt32(reader["ID"]),
                CategoryName = reader["CategoryName"]?.ToString() ?? string.Empty,
                Description = reader["Description"] != DBNull.Value ? reader["Description"]?.ToString() : null,
                ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"]?.ToString() : null,
                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.MinValue,
                IsActive = reader["IsActive"] != DBNull.Value ? Convert.ToInt32(reader["IsActive"]) == 1 : true
            };
        }
    }
}
