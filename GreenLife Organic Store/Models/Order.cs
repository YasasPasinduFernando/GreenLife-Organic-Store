namespace GreenLife_Organic_Store.Models
{
    /// <summary>
    /// Enum for order status
    /// </summary>
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    /// <summary>
    /// Order model representing an order in the e-commerce system
    /// </summary>
    public class Order
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Helper Methods
        public string GenerateOrderNumber()
        {
            return "ORD-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public int GetTotalItems()
        {
            return Items.Sum(i => i.Quantity);
        }

        public string GetStatusText()
        {
            return Status.ToString();
        }

        public string GetFormattedTotal()
        {
            return $"Rs. {TotalAmount:N2}";
        }

        public override string ToString()
        {
            return $"{OrderNumber} - {CustomerName} - {TotalAmount:N2}";
        }
    }

    /// <summary>
    /// OrderItem model representing a single item in an order
    /// </summary>
    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime CreatedDate { get; set; }

        public void CalculateSubtotal()
        {
            Subtotal = Quantity * UnitPrice;
        }

        public override string ToString()
        {
            return $"{ProductName} x {Quantity} = Rs. {Subtotal:N2}";
        }
    }
}
