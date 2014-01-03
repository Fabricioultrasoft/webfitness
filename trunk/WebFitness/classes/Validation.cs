using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace WebFitness.Classes
{
    public class Validation
    {

        public static string GetMD5Hash(string value)
        {
            MD5CryptoServiceProvider md5ServiceProdivder = new MD5CryptoServiceProvider();

            value = value == null ? "" : value;

            byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
            data = md5ServiceProdivder.ComputeHash(data);

            StringBuilder hashedValue = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                hashedValue.Append(data[i].ToString("x2"));

            return hashedValue.ToString();
        }

        public static string SyntaxName(string value)
        {
            if (value == null)
            {
                return null;
            }

            value = value.ToLower();
            StringBuilder valueTmp = new StringBuilder();
            string returnValue;
            string[] split = value.Split(new Char[] { ' ', ',', '.', ':', '\t' });

            foreach (string s in split)
            {
                string firstWord = s.Substring(0, 1).ToUpper();
                valueTmp.Append(firstWord);
                valueTmp.Append(s.Substring(1));
                valueTmp.Append(" ");
            }
            returnValue = valueTmp.ToString().Substring(0, valueTmp.ToString().Length - 1);

            return returnValue;
        }

    }
}