using Microsoft.Data.Sqlite;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;

namespace GreenLife_Organic_Store.Database
{
    /// <summary>
    /// Repository class for Order database operations with transaction support
    /// </summary>
    public class OrderRepository
    {
        /// <summary>
        /// Gets all orders
        /// </summary>
        /// <returns>List of all orders</returns>
        public static List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders ORDER BY OrderDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(MapReaderToOrder(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all orders: {ex.Message}", ex);
            }

            return orders;
        }

        /// <summary>
        /// Deletes an order and its items, restoring product stock quantities.
        /// </summary>
        /// <param name="orderId">Order ID to delete</param>
        /// <returns>True if delete succeeded</returns>
        public static bool DeleteOrder(int orderId)
        {
            SqliteConnection? connection = null;
            SqliteTransaction? transaction = null;

            try
            {
                connection = DatabaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                // Read items so we can restore stock
                var items = new List<(int ProductID, int Quantity)>();
                string selectItems = "SELECT ProductID, Quantity FROM OrderItems WHERE OrderID = @OrderID";
                using (var cmd = new SqliteCommand(selectItems, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add((Convert.ToInt32(reader["ProductID"]), Convert.ToInt32(reader["Quantity"])));
                        }
                    }
                }

                // Restore product stock
                string stockUpdate = "UPDATE Products SET Stock = Stock + @Quantity WHERE ID = @ProductID";
                foreach (var it in items)
                {
                    using (var cmd = new SqliteCommand(stockUpdate, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", it.Quantity);
                        cmd.Parameters.AddWithValue("@ProductID", it.ProductID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Delete order items
                string deleteItems = "DELETE FROM OrderItems WHERE OrderID = @OrderID";
                using (var cmd = new SqliteCommand(deleteItems, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.ExecuteNonQuery();
                }

                // Delete order
                string deleteOrder = "DELETE FROM Orders WHERE ID = @ID";
                using (var cmd = new SqliteCommand(deleteOrder, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@ID", orderId);
                    int affected = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return affected > 0;
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception($"Error deleting order: {ex.Message}", ex);
            }
            finally
            {
                connection?.Close();
                connection?.Dispose();
            }
        }

        /// <summary>
        /// Gets an order by ID with all order items
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns>Order object if found, null otherwise</returns>
        public static Order? GetOrderById(int id)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders WHERE ID = @ID";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        Order? order = null;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = MapReaderToOrder(reader);
                            }
                        }

                        if (order != null)
                        {
                            // Get order items after reader is closed
                            order.Items = GetOrderItems(id, connection);
                            return order;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving order by ID: {ex.Message}", ex);
            }

            return null;
        }

        /// <summary>
        /// Gets orders by customer ID
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>List of orders for the customer</returns>
        public static List<Order> GetOrdersByCustomerId(int customerId)
        {
            var orders = new List<Order>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders WHERE CustomerID = @CustomerID ORDER BY OrderDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = MapReaderToOrder(reader);
                                orders.Add(order);
                            }
                        }
                    }

                    // Get items for each order
                    foreach (var order in orders)
                    {
                        order.Items = GetOrderItems(order.ID, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving orders by customer ID: {ex.Message}", ex);
            }

            return orders;
        }

        /// <summary>
        /// Gets orders by status
        /// </summary>
        /// <param name="status">Order status</param>
        /// <returns>List of orders with the specified status</returns>
        public static List<Order> GetOrdersByStatus(OrderStatus status)
        {
            var orders = new List<Order>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders WHERE Status = @Status ORDER BY OrderDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Status", status.ToString());
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = MapReaderToOrder(reader);
                                orders.Add(order);
                            }
                        }
                    }

                    // Get items for each order
                    foreach (var order in orders)
                    {
                        order.Items = GetOrderItems(order.ID, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving orders by status: {ex.Message}", ex);
            }

            return orders;
        }

        /// <summary>
        /// Creates a new order with order items (with transaction support)
        /// </summary>
        /// <param name="order">Order object to create</param>
        /// <returns>The ID of the created order</returns>
        public static int CreateOrder(Order order)
        {
            SqliteConnection? connection = null;
            SqliteTransaction? transaction = null;

            try
            {
                // Ensure referenced customer exists to avoid foreign key violations
                var customer = UserRepository.GetUserById(order.CustomerID);
                if (customer == null)
                {
                    throw new Exception($"Cannot create order: customer with ID {order.CustomerID} does not exist.");
                }

                connection = DatabaseConnection.GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                // Insert order
                string orderQuery = @"INSERT INTO Orders (OrderNumber, CustomerID, CustomerName, CustomerPhone, CustomerEmail, OrderDate, TotalAmount, Status, ShippingAddress, Notes, CreatedDate, UpdatedDate) 
                                      VALUES (@OrderNumber, @CustomerID, @CustomerName, @CustomerPhone, @CustomerEmail, @OrderDate, @TotalAmount, @Status, @ShippingAddress, @Notes, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);";

                int orderId = 0;
                using (var cmd = new SqliteCommand(orderQuery, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerPhone", order.CustomerPhone);
                    cmd.Parameters.AddWithValue("@CustomerEmail", order.CustomerEmail);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                    cmd.Parameters.AddWithValue("@Status", order.Status.ToString());
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                    cmd.Parameters.AddWithValue("@Notes", (object?)order.Notes ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                using (var idCmd = new SqliteCommand("SELECT last_insert_rowid();", connection, transaction))
                {
                    var result = idCmd.ExecuteScalar();
                    if (result != null && long.TryParse(result.ToString(), out long lid))
                    {
                        orderId = (int)lid;
                    }
                }

                // Insert order items
                string itemQuery = @"INSERT INTO OrderItems (OrderID, ProductID, ProductName, Quantity, UnitPrice, Subtotal, CreatedDate) 
                                     VALUES (@OrderID, @ProductID, @ProductName, @Quantity, @UnitPrice, @Subtotal, CURRENT_TIMESTAMP);";

                var lowStockItems = new List<(string ProductName, int Stock)>();

                foreach (var item in order.Items)
                {
                    using (var cmd = new SqliteCommand(itemQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                        cmd.Parameters.AddWithValue("@ProductName", item.ProductName);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        cmd.Parameters.AddWithValue("@Subtotal", item.Subtotal);
                        cmd.ExecuteNonQuery();
                    }

                    // Reduce product stock
                    string stockQuery = "UPDATE Products SET Stock = Stock - @Quantity WHERE ID = @ProductID";
                    using (var cmd = new SqliteCommand(stockQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                        cmd.ExecuteNonQuery();
                    }

                    // Check new stock level for low stock alert
                    string stockCheck = "SELECT ProductName, Stock FROM Products WHERE ID = @ProductID";
                    using (var cmd = new MySqlCommand(stockCheck, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var name = reader["ProductName"]?.ToString() ?? string.Empty;
                                int stock = Convert.ToInt32(reader["Stock"]);
                                if (stock <= 10)
                                {
                                    lowStockItems.Add((name, stock));
                                }
                            }
                        }
                    }
                }

                transaction.Commit();

                if (lowStockItems.Count > 0)
                {
                    var adminEmails = UserRepository.GetAdminEmails();
                    _ = EmailService.SendLowStockAlertsToAdminsAsync(adminEmails, lowStockItems);
                }
                return orderId;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception($"Error creating order: {ex.Message}", ex);
            }
            finally
            {
                connection?.Close();
                connection?.Dispose();
            }
        }

        /// <summary>
        /// Updates an order status
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="newStatus">New order status</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public static bool UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Orders SET Status = @Status, UpdatedDate = CURRENT_TIMESTAMP WHERE ID = @ID";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", orderId);
                        cmd.Parameters.AddWithValue("@Status", newStatus.ToString());
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order status: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an order
        /// </summary>
        /// <param name="order">Order object with updated information</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public static bool UpdateOrder(Order order)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Orders SET 
                                     CustomerName = @CustomerName,
                                     CustomerPhone = @CustomerPhone,
                                     CustomerEmail = @CustomerEmail,
                                     Status = @Status,
                                     ShippingAddress = @ShippingAddress,
                                     Notes = @Notes
                                     WHERE ID = @ID";

                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", order.ID);
                        cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                        cmd.Parameters.AddWithValue("@CustomerPhone", order.CustomerPhone);
                        cmd.Parameters.AddWithValue("@CustomerEmail", order.CustomerEmail);
                        cmd.Parameters.AddWithValue("@Status", order.Status.ToString());
                        cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                        cmd.Parameters.AddWithValue("@Notes", (object?)order.Notes ?? DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets orders by date range
        /// </summary>
        /// <param name="fromDate">Start date</param>
        /// <param name="toDate">End date</param>
        /// <returns>List of orders within the date range</returns>
        public static List<Order> GetOrdersByDateRange(DateTime fromDate, DateTime toDate)
        {
            var orders = new List<Order>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders WHERE OrderDate BETWEEN @FromDate AND @ToDate ORDER BY OrderDate DESC";
                    using (var cmd = new SqliteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = MapReaderToOrder(reader);
                                orders.Add(order);
                            }
                        }
                    }

                    // Get items for each order
                    foreach (var order in orders)
                    {
                        order.Items = GetOrderItems(order.ID, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving orders by date range: {ex.Message}", ex);
            }

            return orders;
        }

        /// <summary>
        /// Gets order items for a specific order
        /// </summary>
        private static List<OrderItem> GetOrderItems(int orderId, SqliteConnection connection)
        {
            var items = new List<OrderItem>();
            string query = "SELECT * FROM OrderItems WHERE OrderID = @OrderID";
            using (var cmd = new SqliteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new OrderItem
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                            CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.MinValue
                        });
                    }
                }
            }
            return items;
        }

        /// <summary>
        /// Maps a database reader to an Order object
        /// </summary>
        private static Order MapReaderToOrder(SqliteDataReader reader)
        {
            return new Order
            {
                ID = Convert.ToInt32(reader["ID"]),
                OrderNumber = reader["OrderNumber"]?.ToString() ?? string.Empty,
                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                CustomerName = reader["CustomerName"]?.ToString() ?? string.Empty,
                CustomerPhone = reader["CustomerPhone"]?.ToString() ?? string.Empty,
                CustomerEmail = reader["CustomerEmail"]?.ToString() ?? string.Empty,
                OrderDate = reader["OrderDate"] != DBNull.Value ? Convert.ToDateTime(reader["OrderDate"]) : DateTime.MinValue,
                TotalAmount = reader["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmount"]) : 0m,
                Status = Enum.Parse<OrderStatus>(reader["Status"]?.ToString() ?? "Pending"),
                ShippingAddress = reader["ShippingAddress"]?.ToString() ?? string.Empty,
                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"]?.ToString() : null,
                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.MinValue,
                UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedDate"]) : DateTime.MinValue
            };
        }
    }
}
