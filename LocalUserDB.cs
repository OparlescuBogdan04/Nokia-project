using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Nokia
{
    public static class LocalUserDB
    {
        private static readonly string local_db_path ="LocalUsers.csv" ;
        private struct LocalUser
        {
            public string name;
            public string password;
            public User.UserType type;

            public LocalUser(string name, string password, User.UserType type)
            {
                this.name = name;
                this.password = password;
                this.type = type;
            }

            public User toUser()
            {
                return new User(name,password, type);
            }
        }

        private static List<LocalUser> local_users = null;
        public static void LoadUsers()
        {
            if (!File.Exists(local_db_path))
                throw new Exception("Local User Db File was not found!");

            local_users = new List<LocalUser>();
            var lines = File.ReadAllLines(local_db_path);
            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');
                if (values.Length == 3)
                {
                    string name = values[0];
                    string password = values[1];
                    User.UserType type = (User.UserType)Enum.Parse(typeof(User.UserType), values[2]);

                    var user = new LocalUser(name, password, type);
                    local_users.Add(user);
                }
            }
        }

        public static void Kill()
        {
            local_users = null;
        }

        public static bool VerifyCredentials(string name, string password)
        {
            foreach (LocalUser user in local_users)
                if (user.name == name && user.password == password)
                    return true;
            return false;
        }

        public static User retreiveUser(string name, string password)
        {
            foreach (LocalUser user in local_users)
                if (user.name == name && user.password == password)
                    return user.toUser();
            throw new Exception("User not found");
        }
    }
}
