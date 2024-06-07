using System.Windows.Markup;

namespace Nokia
{
    public static class UserDB
    {
        private static DB_CONNECTION User_database = DB_MANAGER.GetConnection("UserDB");

        public static void InsertUser(string username,string email,string password)
        {
            string Team = "default";
            string Admin = "false";
            string query=$"INSERT INTO \"LoginTB\" (username, email, team, admin, password) VALUES ('{username}', '{email}', '{Team}', '{Admin}', '{password}')";
            User_database.QueryCommandGeneral(query);
        }

        public static bool ExistsInDB(string username)
        {
            string query = $"SELECT EXISTS(SELECT 1 FROM \"LoginTB\" WHERE username = '{username}');";

            return User_database.SafeNonNullQuery(query, 2);

        }

        public static bool ExistsInDB(User user)
        {
            return ExistsInDB(user.name);
        }

        public static bool DatabaseVerified(string username,string password)
        {
            string query = $"SELECT EXISTS(SELECT 1 FROM \"LoginTB\" WHERE username =  '{username}' AND password = '{password}')";

            return User_database.SafeNonNullQuery(query, 4);
        }
    }
}
