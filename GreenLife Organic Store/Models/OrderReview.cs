namespace GreenLife_Organic_Store.Models
{
    public class OrderReview
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
