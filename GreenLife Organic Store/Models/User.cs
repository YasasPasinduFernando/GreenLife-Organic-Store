namespace GreenLife_Organic_Store.Models
{
    /// <summary>
    /// Enum for user types
    /// </summary>
    public enum UserType
    {
        Admin,
        Customer
    }

    /// <summary>
    /// Enum for gender
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// User model representing a user in the system
    /// </summary>
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
        public string Password { get; set; } = string.Empty; // Should be hashed
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public override string ToString()
        {
            return $"{Name} ({Email})";
        }
    }
}
