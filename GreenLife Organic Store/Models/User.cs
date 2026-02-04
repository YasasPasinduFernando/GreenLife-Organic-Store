namespace GreenLife_Organic_Store.Models
{
    public enum UserType
    {
        Admin,
        Customer
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public Gender Sex { get; set; }
        public UserType UserType { get; set; }
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public override string ToString()
        {
            return $"{Name} ({Email})";
        }
    }
}
