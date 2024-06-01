namespace Nokia
{
    public class User
    {
        public string name;
        public string email;
        public int id { get; }
        public enum UserType { Normal,Admin,Programmer};  
        public UserType user_type { get; }

        public User(string name)
        {
            this.name = name;

            id = UserDB.NewUserId();
            
            user_type = UserType.Normal; //this could be set by the UserDB
        }

        public User(string name,UserType user_type):this(name)
        {
            this.user_type = user_type;
        }
    }
}
