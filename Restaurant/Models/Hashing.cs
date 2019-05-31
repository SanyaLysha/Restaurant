using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Restaurant.Models
{
    public class Hashing
    {
        public static byte[] GetHashString(string str)
        {
            //byte[] salt;
            //new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //var pbkdf2 = new Rfc2898DeriveBytes(str, salt, 10000);
            //byte[] hash = pbkdf2.GetBytes(20);
            //byte[] hashBytes = new byte[36];
            //Array.Copy(salt, 0, hashBytes, 0, 16);
            //Array.Copy(hash, 0, hashBytes, 16, 20);
            //return Convert.ToBase64String(hashBytes);
            return new SHA256CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(str));
        }
    }
}