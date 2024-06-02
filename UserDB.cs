namespace Nokia
{
    public static class UserDB
    {

        public static bool ExistsInDB(string username)
        {
            string query = $"SELECT EXISTS(SELECT 1 FROM \"LoginTB\" WHERE username = '{username}');";

            return DbCon.SafeNonNullQuery(query, 2);

        }

        public static bool ExistsInDB(User user)
        {
            return ExistsInDB(user.name);
        }

        public static bool DatabaseVerified(string username,string password)
        {
            string query = $"SELECT EXISTS(SELECT 1 FROM \"LoginTB\" WHERE username =  '{username}' AND password = '{password}')";

            return DbCon.SafeNonNullQuery(query, 4);
        }
    }
}
