using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BarclaysPayments.Shared
{
    public class BarclaysFunctions
    {
        public static string GetHash(string text, string key, string algorithm)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            if (algorithm == "SHA1")
            {
                using (HMACSHA1 hash = new HMACSHA1(keyBytes))
                    hashBytes = hash.ComputeHash(textBytes);
            }
            else if (algorithm == "SHA256")
            {

                using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                    hashBytes = hash.ComputeHash(textBytes);
            }
            else if (algorithm == "SHA512")
            {
                using (HMACSHA512 hash = new HMACSHA512(keyBytes))
                    hashBytes = hash.ComputeHash(textBytes);
            }
            else
            {
                using (HMACSHA512 hash = new HMACSHA512(keyBytes))
                    hashBytes = hash.ComputeHash(textBytes);
            }

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
