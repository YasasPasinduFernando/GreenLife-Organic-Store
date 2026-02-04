using System.Security.Cryptography;
using System.Text;

namespace GreenLife_Organic_Store.Utilities
{
    // SHA256 password hashing
    public static class PasswordHasher
    {
        // Hash password to hex string
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashedBytes).ToLower();
            }
        }

        // Compare password with stored hash
        public static bool VerifyPassword(string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
