using Npgsql;
using System.Linq;
using System.Runtime.InteropServices;
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
                s[i] = (char)(s[i] + 1);
            return new string(s);
        }

        public static string Decrypt(this string str)
        {
            char[] s = str.ToCharArray();
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


        //counts the number of ' characters in a query to prevent injection
        public delegate bool BoolF();


        public static bool SafeNonNullQuery(string query, int quotes_count, BoolF OpenConnection,BoolF CloseConnection)
        {
            //counts the number of ' chars

            if (query.Count(c => c == '\'') != quotes_count)
				return false;

            if (!OpenConnection())
                return false;

            NpgsqlCommand cmd = new NpgsqlCommand(query, DbCon.getConnection());
            
            //MessageBox.Show(query);

            bool existsUser = (bool)cmd.ExecuteScalar();

            CloseConnection();
  
            return existsUser;
        }

		//private static int count(this char[] str, char c)
		//{
		//	int k = 0;
		//	for (int i = 0; i < str.Length; i++)
		//		if (str[i] == c)
		//			k++;
		//	return k;
		//}
	}
}
