using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace WebFitness.classes
{
    public class Validation
    {

        public static string GetMD5Hash(string value)
        {
            MD5CryptoServiceProvider md5ServiceProdivder = new MD5CryptoServiceProvider();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
            data = md5ServiceProdivder.ComputeHash(data);

            StringBuilder hashedValue = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                hashedValue.Append(data[i].ToString("x2"));

            return hashedValue.ToString();
        }

    }
}