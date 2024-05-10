using Npgsql; // Add this namespace for PostgreSQL
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;

namespace Nokia
{
    public static class DbCon
    {
        private static NpgsqlConnection connection;

        private static  string server;
        
        private static  string database;
        
        private static string uid;
        
        private static string password;

        //Initialize values
        private static void Initialize()
        {
            server = "localhost";

            database = "Resources";

            uid = "postgres";

            password = "4825";

            string connectionString;

            //connectionString = "Server=" + server + ";Port=5432;" + "Database=" + database + ";" + "User Id=" + uid + ";" + "Password=" + password + ";";
            connectionString = $"Server={server};Port=5432;User Id={uid};Password={password};Database={database};";
               
            //var connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=passw0rd;Database=testdb
            
            connection = new NpgsqlConnection(connectionString);
        }

        //open connection to database
        private static bool OpenConnection()
		{ 
            Initialize();
            try
            {
                connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();

                return true;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public static void InsertUser(string username, string email, string password)
        {
			string Team = "default";

			string Admin = "false";

			string query = $"INSERT INTO \"LoginTB\" (username, email, team, admin, password) VALUES ('{username}', '{email}', '{Team}', '{Admin}', '{password}')";

			QueryCommandGeneral(query);
        }

        public static bool NonNullQuery(string query)
        {
			if (OpenConnection() == true)
			{
				NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

				//Execute command

				bool existsUser = (bool)cmd.ExecuteScalar();

				//close connection

				CloseConnection();

				return existsUser;
			}
			else
			{
				return false;
			}
		}

		public static NpgsqlConnection getConnection()
		{
			return connection;
		}

        public static bool SafeNonNullQuery(string query,int quotes_count)
        {
			return Security.SafeNonNullQuery(query, quotes_count, NonNullQuery);
        }

        public static void QueryCommandGeneral(string query)
		{	
			if (OpenConnection() == true)
			{
				NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

				//Execute command

				cmd.ExecuteNonQuery();

				//close connection

				CloseConnection();
			}
		}

		//public static bool checkExistingUser(string username)
		//{
		//	string query = "SELECT EXISTS(SELECT 1 FROM \"LoginTB\" WHERE username =  @UserName);";

		//	//open connection

		//	if (OpenConnection() == true)
		//	{
		//		//create command and assign the query and connection from the constructor

		//		NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

		//		cmd.Parameters.AddWithValue("@username", username);

		//		//Execute command

		//		bool existsUser = (bool)cmd.ExecuteScalar();

		//		//close connection

		//		CloseConnection();

  //              return existsUser;

		//	}
		//	else
		//	{
		//		MessageBox.Show("Connection ERROR: Cannot open LoginTB Table from Resources Database to check this user! :(");

		//		return false;

		//	}

		//}

		//public static void SelectResources()
		//{
		//	string query = "SELECT UserName, Admin FROM Resources;";

		//	int count = 0;

		//          //Open connection
		//          if (OpenConnection() == true)
		//          {
		//              //Create Command
		//              NpgsqlCommand cmd = new NpgsqlCommand(query, connection));

		//              //Create a data reader and Execute the command
		//              NpgsqlDataReader dataReader = cmd.ExecuteReader()) ;

		//              while (dataReader.Read())
		//              {
		//                  string usr = dataReader.GetString(0);

		//                  string adm = dataReader.GetString(1);

		//                  if (usr == Main.usern)
		//                  {
		//                      count = 1;

		//                      if (adm.Contains("A"))
		//                      {
		//                          count = 2;

		//                          break;
		//                      }

		//                      if (adm.Contains("O"))
		//                      {
		//                          count = 3;

		//                          break;
		//                      }

		//                      break;
		//                  }
		//              }
		//              //Close Connection
		//              CloseConnection();
		//          }
		//          else
		//          {
		//              MessageBox.Show("Connection ERROR: Cannot open RESOURCES Table from db_CBON Database for selecting users! :(");
		//              return;
		//          }
		//}
	}
}