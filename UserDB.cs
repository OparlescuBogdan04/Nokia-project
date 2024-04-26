namespace Nokia
{

    public static class UserDB
    {
        public static int NewUserId()
        {
            //To Do
            //should create a new unique user id
            //the method of generating the user id is yet to be chosen
            return 0;
        }

        public static bool ExistsInDB(string username)
        {
            //To Do
            return false;
        }

        public static bool ExistsInDB(int user_id)
        {
            //To Do
            return false;
        }

        public static bool ExistsInDB(User user)
        {
            //To Do
            //should return true if user exists in the DB, and false if it doesn't
            return false;
        }

        public static bool DatabaseVerified(string username,string password)
        {
            //To Do
            return false;
        }
    }
}
