using System.Security.Cryptography;
using Serilog;

namespace TestHub.BLL.Services
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            Log.Information("HashPassword() started");
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                byte[] hashBytes = new byte[salt.Length + hash.Length];
                Array.Copy(salt, 0, hashBytes, 0, salt.Length);
                Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);
                Log.Information("HashPassword() ended");
                return Convert.ToBase64String(hashBytes);
            }
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            Log.Information("VerifyPassword() started");
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, salt.Length);
            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hashBytes[i + salt.Length] != hash[i])
                    {
                        Log.Information("HashPassword() return false");
                        return false;
                    }
                }
            }
            Log.Information("HashPassword() return true");
            return true;
        }
    }
}
