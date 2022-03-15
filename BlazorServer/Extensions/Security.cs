﻿using System.Security.Cryptography;
using System.Text;

namespace BlazorServer.Extensions
{
    public static class Security
    {

        public static string Encriptar(this string texto)
        {
            MD5 md = MD5.Create();

            return GetMd5Hash(md, texto);
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
