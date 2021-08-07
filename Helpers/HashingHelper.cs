using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using beerOfThings.Entities;
using System.Text;

namespace beerOfThings.Helpers
{
    public static class HashingHelper
    {
        public static HashedPassword hashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            HashedPassword hashed = new HashedPassword();
            hashed.Salt = Convert.ToBase64String(salt);
            hashed.Hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt:salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount:10000,
                numBytesRequested : 256 / 8
                ));
            
            return hashed;
        }

        public static bool Match(string password1,string password2, string salt)
        {
          byte[] bytes = Encoding.ASCII.GetBytes(salt);
            
            string hashed1 = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password1,
                salt: bytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                ));

            string hashed2 = Convert.ToBase64String(KeyDerivation.Pbkdf2(
              password: password1,
              salt: bytes,
              prf: KeyDerivationPrf.HMACSHA256,
              iterationCount: 10000,
              numBytesRequested: 256 / 8
              ));

            return hashed1.Equals(hashed2);
        }
    }
}
