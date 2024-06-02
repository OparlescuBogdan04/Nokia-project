namespace Nokia
{
    [System.Serializable]
    public class User
    {
        public string name;
        public string email;
        public string password;
        public enum UserType { Normal,Admin,Programmer};  
        public UserType user_type { get; }

        public User(string name)
        {
            this.name = name; 
            user_type = UserType.Normal;
        }

        public User(string name, string password) : this(name)
        {
            this.password = password;
        }

        public User(string name,UserType user_type):this(name)
        {
            this.user_type = user_type;
        }

        public User(string name, string password, UserType user_type) : this(name,user_type)
        {
            this.password = password;
        }

        public User(string name, string email, string password, UserType user_type) : this(name,password,user_type)
        {
            this.email = email;
        }
    }
}
