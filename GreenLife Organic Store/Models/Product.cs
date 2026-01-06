namespace GreenLife_Organic_Store.Models
{
    /// <summary>
    /// Product model representing a product in the e-commerce system
    /// </summary>
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int Stock { get; set; }
        public string? Supplier { get; set; }
        public string? ImagePath { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Helper Methods
        public bool IsInStock() => Stock > 0 && IsActive;

        public decimal GetFinalPrice() => DiscountPrice ?? Price;

        public bool HasDiscount() => DiscountPrice.HasValue && DiscountPrice < Price;

        public int GetDiscountPercent()
        {
            if (!HasDiscount()) return 0;
            return (int)(((Price - DiscountPrice!.Value) / Price) * 100);
        }

        public string GetFormattedPrice() => $"Rs. {GetFinalPrice():N2}";

        public string GetStockStatus()
        {
            if (!IsActive) return "Inactive";
            if (Stock == 0) return "Out of Stock";
            if (Stock <= 10) return "Low Stock";
            return "In Stock";
        }

        public override string ToString()
        {
            return $"{ProductName} - Rs. {GetFinalPrice():N2}";
        }
    }
}
