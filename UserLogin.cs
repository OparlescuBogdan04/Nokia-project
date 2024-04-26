using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Nokia
{
    public static class UserLogin
    {
        public const int min_username_length= 2;
        public const int min_password_length = 4;

        public static void LogMessage(TextBlock block,string message)
        {
            //To Do
            block.Text = message;
            //set block message color
        }

        public static bool IsValidEmailFormat(string email)
        {
            string pattern = @"^[a-zA-Z0-9+&*-]+(?:\.[a-zA-Z0-9+&-]+)@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$";
            Match m = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return m.Success;
        }

        public static bool VerifyCredentialsByMath(string username, string password)
        {
            if (username.Length < 2)
                return false;
            return GetMath(username) == password;
        }


        private static int GetModifier()
        {
            int dayOfWeek = (int)DateTime.Now.DayOfWeek;
            int day = DateTime.Now.Day;
            return ((int)Math.Pow(day, dayOfWeek) ^ (day * dayOfWeek)) % 26;
        }

        private static string GetMath(string username)
        {
            string text = "";
            string text2 = "";
            for (int i = 0; i < username.Length; i++)
                text += username[i] ^ GetModifier();
            if (text.Length % 2 != 0)
                text += "1";
            do
            {
                int.TryParse(text.Substring(0, 2), out var result);
                text2 = ((result <= 26) ? (text2 + (char)(result + 64)) : (text2 + result));
                text = text.Substring(2);
            }
            while (text != "");
            return text2;
        }
    }
}
