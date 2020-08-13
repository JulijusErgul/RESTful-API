using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace RESTful_API.Model
{
    public class SecurePasswordHasher
    {
        // Size of salt
        private const int SaltSize = 16;

        // Size of Hash
        private const int HashSize = 20;

        // Creates hash from a password
        public static string Hash(string password, int iterations)
        {
            // Create salt
            using(var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt;
                rng.GetBytes(salt = new byte[SaltSize]);

                using(var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    var hash = pbkdf2.GetBytes(HashSize);

                    //Combine salt and hash
                    var hashBytes = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                    Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                    // Convert to base64
                    var base64Hash = Convert.ToBase64String(hashBytes);

                    // Format hash with extra information
                    return $"$HASH|V1${iterations}${base64Hash}";
                }
            }
        }

        // Creates a hash from a password with 10000 iterations.
        public static string Hash(string password)
        {
            return Hash(password, 10000);
        }

        // Checks if hash is supported
        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains("HASH|V1$");
        }

        // Verify a password against a hash
        public static bool Verify(string password, string hashedPassword)
        {
            // Check hash
            if (!IsHashSupported(hashedPassword))
            {
                return false;
            }

            // Extract iteration and Base64 string
            var splittedHashString = hashedPassword
                                        .Replace("$HASH|V1$", "")
                                        .Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            // Get hash byte
            var hashbytes = Convert.FromBase64String(base64Hash);

            // Get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashbytes, 0, salt, 0, SaltSize);

            // Create a Hash wit given salt
            using(var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                // Get result
                for(var i = 0; i < HashSize; i++)
                {
                    if(hashbytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}