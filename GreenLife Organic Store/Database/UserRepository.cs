using MySql.Data.MySqlClient;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using System.Collections.Generic;
using System;

namespace GreenLife_Organic_Store.Database
{
    /// <summary>
    /// Repository class for User database operations
    /// </summary>
    public class UserRepository
    {
        // Password Reset Token storage (in-memory for simplicity)
        private static Dictionary<string, (string Code, DateTime Expiry)> _resetCodes = new();

        /// <summary>
        /// Authenticates a user with email and password
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password (plain text)</param>
        /// <returns>User object if authentication successful, null otherwise</returns>
        public static User? AuthenticateUser(string email, string password)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Email = @Email AND IsActive = TRUE";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["Password"].ToString() ?? string.Empty;
                                if (PasswordHasher.VerifyPassword(password, storedHash))
                                {
                                    return MapReaderToUser(reader);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error authenticating user: {ex.Message}", ex);
            }

            return null;
        }

        /// <summary>
        /// Gets a user by email
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User object if found, null otherwise</returns>
        public static User? GetUserByEmail(string email)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    // Case-insensitive lookup and ignore surrounding whitespace
                    string query = "SELECT * FROM Users WHERE LOWER(Email) = LOWER(@Email)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", (object?)email?.Trim() ?? string.Empty);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToUser(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving user by email: {ex.Message}", ex);
            }

            return null;
        }

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User object if found, null otherwise</returns>
        public static User? GetUserById(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE ID = @ID";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToUser(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving user by ID: {ex.Message}", ex);
            }

            return null;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of all users</returns>
        public static List<User> GetAllUsers()
        {
            var users = new List<User>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Users ORDER BY CreatedDate DESC";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(MapReaderToUser(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all users: {ex.Message}", ex);
            }

            return users;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">User object to create</param>
        /// <returns>The ID of the created user</returns>
        public static int CreateUser(User user)
        {
            try
            {
                // Validate email doesn't exist
                if (GetUserByEmail(user.Email) != null)
                {
                    throw new Exception("Email already exists");
                }

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Users (Email, Name, Phone, Age, Address, Sex, UserType, Password) 
                                     VALUES (@Email, @Name, @Phone, @Age, @Address, @Sex, @UserType, @Password);
                                     SELECT LAST_INSERT_ID();";
                    
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@Phone", (object?)user.Phone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Age", (object?)user.Age ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object?)user.Address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Sex", user.Sex.ToString());
                        cmd.Parameters.AddWithValue("@UserType", user.UserType.ToString());
                        cmd.Parameters.AddWithValue("@Password", PasswordHasher.HashPassword(user.Password));

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
                throw new Exception($"Error creating user: {ex.Message}", ex);
            }

            return 0;
        }

        /// <summary>
        /// Generates and sends password reset code
        /// </summary>
        public static bool RequestPasswordReset(string email)
        {
            try
            {
                var user = GetUserByEmail(email);
                if (user == null) return false;

                // Generate 6-digit code
                string resetCode = new Random().Next(100000, 999999).ToString();

                // Store with 15 minute expiry
                _resetCodes[email] = (resetCode, DateTime.Now.AddMinutes(15));

                // Send email
                return EmailService.SendPasswordResetEmail(user.Email, user.Name, resetCode);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error requesting password reset: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifies reset code and updates password
        /// </summary>
        public static bool ResetPassword(string email, string code, string newPassword)
        {
            try
            {
                // Check if code exists and not expired
                if (!_resetCodes.ContainsKey(email)) return false;
                var (storedCode, expiry) = _resetCodes[email];

                if (DateTime.Now > expiry)
                {
                    _resetCodes.Remove(email);
                    return false; // Expired
                }

                if (storedCode != code)
                    return false; // Wrong code

                // Update password
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Users SET Password = @Password WHERE Email = @Email";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", PasswordHasher.HashPassword(newPassword));

                        bool success = cmd.ExecuteNonQuery() > 0;

                        if (success)
                        {
                            _resetCodes.Remove(email); // Remove used code
                        }

                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error resetting password: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user">User object with updated information</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public static bool UpdateUser(User user)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Users SET 
                                     Name = @Name, 
                                     Phone = @Phone, 
                                     Age = @Age, 
                                     Address = @Address, 
                                     Sex = @Sex
                                     WHERE ID = @ID";
                    
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", user.ID);
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@Phone", (object?)user.Phone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Age", (object?)user.Age ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object?)user.Address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Sex", user.Sex.ToString());

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating user: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Changes a user's password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="newPassword">New password (plain text)</param>
        /// <returns>True if password change was successful, false otherwise</returns>
        public static bool ChangePassword(int userId, string newPassword)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Users SET Password = @Password WHERE ID = @ID";
                    
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", userId);
                        cmd.Parameters.AddWithValue("@Password", PasswordHasher.HashPassword(newPassword));

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error changing password: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public static bool DeleteUser(int userId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE ID = @ID";
                    
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", userId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting user: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Maps a database reader to a User object
        /// </summary>
        private static User MapReaderToUser(MySqlDataReader reader)
        {
            return new User
            {
                ID = (int)reader["ID"],
                Email = reader["Email"].ToString() ?? string.Empty,
                Name = reader["Name"].ToString() ?? string.Empty,
                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null,
                Age = reader["Age"] != DBNull.Value ? (int)reader["Age"] : null,
                Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                Sex = Enum.Parse<Gender>(reader["Sex"].ToString() ?? "Male"),
                UserType = Enum.Parse<UserType>(reader["UserType"].ToString() ?? "Customer"),
                Password = reader["Password"].ToString() ?? string.Empty,
                CreatedDate = (DateTime)reader["CreatedDate"],
                UpdatedDate = (DateTime)reader["UpdatedDate"],
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
