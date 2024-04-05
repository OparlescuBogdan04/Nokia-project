namespace Nokia
{
    public class User
    {
        public string name;
        public int id { get; }

        public User(string name)
        {
            this.name = name;
            id = UserDB.NewUserId();
        }
    }
}
