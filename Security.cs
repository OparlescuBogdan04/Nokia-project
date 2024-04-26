using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Nokia
{
    public static class Security
    {
        private static readonly string cipher = "Nokia_2024";
        public static string Encrypt(this string str)
        {
            char[] s = EncMethod(str);
            for (int i = 0; i < s.Length; i++)
                s[i] = (char)(s[i]+1);
            return new string(s);
        }

        public static string Decrypt(this string str)
        {
            char[] s=str.ToCharArray();
            for (int i = 0; i < s.Length; i++)
                s[i] = (char)(s[i] - 1);
            return new string(EncMethod(new string(s)));
        }

        private static char[] EncMethod(string str)
        {
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
                c[i] = (char)(c[i] ^ cipher[i % cipher.Length]);
            return c;
        }
    }
}
