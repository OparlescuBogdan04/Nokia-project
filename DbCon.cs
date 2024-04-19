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

public void InsertUser()
{
	string query = "INSERT INTO Resources (Name, UserName, Mail, Team, Admin) VALUES('" + Login.name + "', '" + Login.user 
		+ "', '" + Login.mail + "', '" + Login.team + "', '" + Login.admin + "');";


	//open connection

	if (this.OpenConnection() == true)
	{

		//create command and assign the query and connection from the constructor

		MySqlCommand cmd = new MySqlCommand(query, connection);

		//Execute command

		cmd.ExecuteNonQuery();

		//close connection

		this.CloseConnection();

	}
	else
	{

		MessageBox.Show("Connection ERROR: Cannot open RESOURCES Table from db_CBON Database for inserting new user! :(");

		return;

	}

}

public void SelectResources()
{
	string query = "SELECT UserName, Admin FROM Resources;";

	count = 0;

	//Open connection

	if (this.OpenConnection() == true)
	{
		//Create Command

		MySqlCommand cmd = new MySqlCommand(query, connection);

		//Create a data reader and Execute the command

		MySqlDataReader dataReader = cmd.ExecuteReader();

		//Read the data and store them in the list

		while (dataReader.Read())
		{

			string usr = dataReader[0].ToString();

			string adm = dataReader[1].ToString();


			if (usr == Main.usern)
			{

				count = 1;


				if (adm.Contains("A")
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

		//close Data Reader

		dataReader.Close();


		//close Connection

		this.CloseConnection();

		//return list to be displayed
	}
	else
	{
		MessageBox.Show("Connection ERROR: Cannot open RESOURCES Table from db_CBON Database for selecting users! :(");

		return;
	}
}

