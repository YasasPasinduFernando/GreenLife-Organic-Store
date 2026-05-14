using System.Security.Cryptography;
using System.Text;

namespace GreenLife_Organic_Store.Utilities
{
    // Password hashing using BCrypt, with SHA256 verification kept for existing older rows.
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
            {
                return false;
            }

            if (hash.StartsWith("$2", StringComparison.Ordinal))
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }

            var hashOfInput = HashSha256(password);
            return hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }

        private static string HashSha256(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashedBytes).ToLower();
            }
        }
    }
}
