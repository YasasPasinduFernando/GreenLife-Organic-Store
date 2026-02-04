using System.Security.Cryptography;
using System.Text;

namespace GreenLife_Organic_Store.Utilities
{
    // Password hashing using SHA256
    public static class PasswordHasher
    {
        // Creates hash from plain text password
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashedBytes).ToLower();
            }
        }

        // Checks if password matches the stored hash
        public static bool VerifyPassword(string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
