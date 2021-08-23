using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using beerOfThings.Entities;
using System.Text;

namespace beerOfThings.Helpers
{
    public static class HashingHelper
    {

        private static int InterationNumber = 10000;
        private static int HashNumber = 64;

        public static string GenerateSalt()
        {
            var saltBytes = new byte[HashNumber];

            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, saltBytes, InterationNumber))
            {
                return Convert.ToBase64String(rfc.GetBytes(HashNumber));
            }
        }

        public static bool Match(string password1,string password2, string salt)
        {
            return password1.Equals(HashPassword(password2, salt));
        }
    }
}
