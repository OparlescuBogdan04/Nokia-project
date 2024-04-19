using Npgsql; // Add this namespace for PostgreSQL

private NpgsqlConnection connection;
private string server;
private string database;
private string uid;
private string password;

public DBConnect()
{
	Initialize();
}

//Initialize values
private void Initialize()
{
	server = "127.0.0.1";

	database = "db_DBNAME";
	
	uid = "TEST";
	
	password = "TEST";

	string connectionString;
	
	connectionString = "Server=" + server + ";Port=5432;" + "Database=" +
					   database + ";" + "User Id=" + uid + ";" + "Password=" + password + ";";

	connection = new NpgsqlConnection(connectionString);
}

//open connection to database
private bool OpenConnection()
{
	try
	{
		connection.Open();

		return true;
	}
	catch (NpgsqlException ex)
	{
		//When handling errors, you can your application's response based
		//on the error code.
		switch (ex.Code)
		{
			case "28P01": // Invalid password
				{
					MessageBox.Show("Invalid username/password, please try again");
					break;
				}
			default:
				{
					MessageBox.Show("Cannot connect to server. Contact administrator");
					break;
				}
		}
		return false;
	}
}

//Close connection
private bool CloseConnection()
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
