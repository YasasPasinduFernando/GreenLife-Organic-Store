namespace GreenLife_Organic_Store.Models
{
    /// <summary>
    /// Category model representing a product category
    /// </summary>
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
