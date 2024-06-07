using Npgsql;

namespace Nokia
{
    public class DB_CONNECTION
    {
		public string Name { get; set; }
        private NpgsqlConnection Connection { get; set; }
        private string Server { get; set; }
		private string Port { get; set; }
        private string Database { get; set; }
        private string Uid { get; set; }
        private string Password { get; set; }

        public DB_CONNECTION(string name, string server,string port, string database, string uid, string password)
        {
            Name = name;
            Server = server;
            Port = port;
            Database = database;
            Uid = uid;
            Password = password;
			InitializeConnection();
        }

        private void InitializeConnection()
        {
            string connectionString = $"Server={Server};Port={Port};User Id={Uid};Password={Password};Database={Database};";
            Connection = new NpgsqlConnection(connectionString);
        }


        public bool OpenConnection()
		{ 
            try
            {
                Connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool CloseConnection()
        {
            try
            {
                Connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void InsertUser(string username, string email, string password)
        {
            string Team = "default";

            string Admin = "false";

            string query = $"INSERT INTO \"LoginTB\" (username, email, team, admin, password) VALUES ('{username}', '{email}', '{Team}', '{Admin}', '{password}')";

            QueryCommandGeneral(query);
        }

        public bool NonNullQuery(string query)
        {
			if (OpenConnection() == true)
			{
				NpgsqlCommand cmd = new NpgsqlCommand(query, Connection);

				bool output = (bool)cmd.ExecuteScalar();

				CloseConnection();

				return output;
			}
			else
			{
				return false;
			}
		}


		public NpgsqlConnection getConnection()
		{
			return Connection;
		}

        public bool SafeNonNullQuery(string query,int quotes_count)
        {
			return Security.SafeNonNullQuery(query, quotes_count, NonNullQuery);
        }


        public void QueryCommandGeneral(string query)
		{	
			if (OpenConnection() == true)
			{
				NpgsqlCommand cmd = new NpgsqlCommand(query, Connection);

				cmd.ExecuteNonQuery();

				CloseConnection();
			}
		}
	}
}