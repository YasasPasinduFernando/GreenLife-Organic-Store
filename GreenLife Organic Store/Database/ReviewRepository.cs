using GreenLife_Organic_Store.Models;
using Microsoft.Data.Sqlite;

namespace GreenLife_Organic_Store.Database
{
    public static class ReviewRepository
    {
        public static Dictionary<int, OrderReview> GetReviewsByCustomer(int customerId)
        {
            var reviews = new Dictionary<int, OrderReview>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM OrderReviews WHERE CustomerID = @CustomerID";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var review = MapReaderToReview(reader);
                                reviews[review.OrderID] = review;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving reviews: {ex.Message}", ex);
            }

            return reviews;
        }

        public static OrderReview? GetReviewByOrder(int orderId, int customerId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM OrderReviews WHERE OrderID = @OrderID AND CustomerID = @CustomerID";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReaderToReview(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving review: {ex.Message}", ex);
            }

            return null;
        }

        public static void SaveReview(OrderReview review)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string existsQuery = "SELECT ID FROM OrderReviews WHERE OrderID = @OrderID AND CustomerID = @CustomerID";
                    int? existingId = null;
                    using (var cmd = new SqliteCommand(existsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", review.OrderID);
                        cmd.Parameters.AddWithValue("@CustomerID", review.CustomerID);
                        var result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            existingId = id;
                        }
                    }

                    if (existingId.HasValue)
                    {
                        string updateQuery = @"UPDATE OrderReviews 
                                               SET Rating = @Rating, Comment = @Comment, UpdatedDate = CURRENT_TIMESTAMP
                                               WHERE ID = @ID";
                        using (var cmd = new SqliteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", existingId.Value);
                            cmd.Parameters.AddWithValue("@Rating", review.Rating);
                            cmd.Parameters.AddWithValue("@Comment", review.Comment);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = @"INSERT INTO OrderReviews (OrderID, CustomerID, Rating, Comment, CreatedDate) 
                                               VALUES (@OrderID, @CustomerID, @Rating, @Comment, CURRENT_TIMESTAMP)";
                        using (var cmd = new SqliteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", review.OrderID);
                            cmd.Parameters.AddWithValue("@CustomerID", review.CustomerID);
                            cmd.Parameters.AddWithValue("@Rating", review.Rating);
                            cmd.Parameters.AddWithValue("@Comment", review.Comment);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving review: {ex.Message}", ex);
            }
        }

        public static List<OrderReviewSummary> GetAllReviewSummaries()
        {
            var results = new List<OrderReviewSummary>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT r.ID AS ReviewId,
                                            r.OrderID AS OrderId,
                                            o.OrderNumber,
                                            r.CustomerID AS CustomerId,
                                            o.CustomerName,
                                            r.Rating,
                                            r.Comment,
                                            r.CreatedDate,
                                            r.UpdatedDate
                                     FROM OrderReviews r
                                     INNER JOIN Orders o ON o.ID = r.OrderID
                                     ORDER BY r.UpdatedDate DESC;";

                    using (var cmd = new SqliteCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new OrderReviewSummary
                            {
                                ReviewId = Convert.ToInt32(reader["ReviewId"]),
                                OrderId = Convert.ToInt32(reader["OrderId"]),
                                OrderNumber = reader["OrderNumber"]?.ToString() ?? string.Empty,
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                CustomerName = reader["CustomerName"]?.ToString() ?? string.Empty,
                                Rating = Convert.ToInt32(reader["Rating"]),
                                Comment = reader["Comment"]?.ToString() ?? string.Empty,
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving review summaries: {ex.Message}", ex);
            }

            return results;
        }

        private static OrderReview MapReaderToReview(SqliteDataReader reader)
        {
            return new OrderReview
            {
                ID = Convert.ToInt32(reader["ID"]),
                OrderID = Convert.ToInt32(reader["OrderID"]),
                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                Rating = Convert.ToInt32(reader["Rating"]),
                Comment = reader["Comment"]?.ToString() ?? string.Empty,
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"])
            };
        }
    }
}
