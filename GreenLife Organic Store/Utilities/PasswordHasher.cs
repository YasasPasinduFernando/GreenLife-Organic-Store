using System.Security.Cryptography;
using System.Text;

namespace GreenLife_Organic_Store.Utilities
{
    /// <summary>
    /// Utility class for password hashing and validation
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Hashes a password using SHA256
        /// </summary>
        /// <param name="password">The plain text password</param>
        /// <returns>The hashed password as a hexadecimal string</returns>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashedBytes).ToLower();
            }
        }

        /// <summary>
        /// Verifies a password against a hash
        /// </summary>
        /// <param name="password">The plain text password</param>
        /// <param name="hash">The hashed password</param>
        /// <returns>True if the password matches the hash, false otherwise</returns>
        public static bool VerifyPassword(string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
