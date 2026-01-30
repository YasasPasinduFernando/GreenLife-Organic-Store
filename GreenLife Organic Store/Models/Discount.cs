namespace GreenLife_Organic_Store.Models
{
    /// <summary>
    /// Discount model representing a discount that can be applied to products
    /// </summary>
    public class Discount
    {
        public int ID { get; set; }
        public string DiscountName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Helper Methods
        public bool IsValid() => IsActive && DateTime.Now >= StartDate && DateTime.Now <= EndDate;

        public string GetStatusText()
        {
            if (DateTime.Now > EndDate) return "Expired";
            if (DateTime.Now < StartDate) return IsActive ? "Upcoming" : "Inactive";
            if (!IsActive) return "Inactive";
            return "Active";
        }

        public string GetFormattedPercent() => $"{DiscountPercent:F0}%";

        public override string ToString()
        {
            return $"{DiscountName} - {GetFormattedPercent()}";
        }
    }
}
