using Npgsql; // Add this namespace for PostgreSQL
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
            server = "127.0.0.1";

            database = "Resources";

            uid = "postgres";

            password = "4825";

            string connectionString;

            connectionString = "Server=" + server + ";Port=5432;" + "Database=" +
                               database + ";" + "User Id=" + uid + ";" + "Password=" + password + ";";

            connection = new NpgsqlConnection(connectionString);
        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();

                return true;
            }
            catch (NpgsqlException ex)
            {
                //To refactor!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                ////When handling errors, you can your application's response based
                ////on the error code.
                //switch (ex.Code)
                //{
                //    case "28P01": // Invalid password
                //        {
                //            MessageBox.Show("Invalid username/password, please try again");
                //            break;
                //        }
                //    default:
                //        {
                //            MessageBox.Show("Cannot connect to server. Contact administrator");
                //            break;
                //        }
                //}
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

        public static void InsertUser(string username, string email,string password)
        {
			string query = "INSERT INTO Resources(Name, UserName, Mail, Team, Admin) VALUES(@Name, @UserName, @Mail, @Team, @Admin)";

			//open connection

			if (OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
					cmd.Parameters.AddWithValue("@Name", username);
					
                    cmd.Parameters.AddWithValue("@UserName", username);
					
                    cmd.Parameters.AddWithValue("@Mail", email);

					cmd.Parameters.AddWithValue("@Team", "Default"); 
					
                    cmd.Parameters.AddWithValue("@Admin", false);
				}

                //Execute command

                cmd.ExecuteNonQuery();

                //close connection

                CloseConnection();

            }
            else
            {
                MessageBox.Show("Connection ERROR: Cannot open RESOURCES Table from db_CBON Database for inserting new user! :(");

                return;

            }

        }

		public static void SelectResources()
		{
			string query = "SELECT UserName, Admin FROM Resources;";

			count = 0;

			//Open connection
			if (OpenConnection() == true)
			{
				//Create Command
				using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
				{
					//Create a data reader and Execute the command
					using (NpgsqlDataReader dataReader = cmd.ExecuteReader())
					{
						while (dataReader.Read())
						{
							string usr = dataReader.GetString(0); 
							string adm = dataReader.GetString(1);

							if (usr == Main.usern)
							{
								count = 1;

								if (adm.Contains("A"))
								{
									count = 2;
									break;
								}

								if (adm.Contains("O"))
								{
									count = 3;
									break;
								}

								break;
							}
						}
					}
				}
				//Close Connection
				CloseConnection();
			}
			else
			{
				MessageBox.Show("Connection ERROR: Cannot open RESOURCES Table from db_CBON Database for selecting users! :(");
				return;
			}
		}
	}
}