using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace HomeBackProject.library
{
    public class HashPassword
    {
        public static string getHashPassword(string pw)
        {
            byte[] hashValue;
            string result = "";

            System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();

            byte[] pwBytes = ue.GetBytes(pw);

            SHA256 shHash = SHA256.Create();

            hashValue = shHash.ComputeHash(pwBytes);

            foreach (byte b in hashValue)
            {
                result += b.ToString();
            }

            return result;
        }
    }
}