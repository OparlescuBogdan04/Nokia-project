using System.Collections.Generic;

namespace Nokia
{
    public static class DB_MANAGER
    {
        private static List<DB_CONNECTION> connections = new List<DB_CONNECTION>()
        { 
            new DB_CONNECTION("UserDB","34.118.101.186","5432","Resources","postgres","4825") 
        };

        public static void AddConnection(DB_CONNECTION connection)
        {
            connections.Add(connection);
        }

        public static DB_CONNECTION GetConnection(string name) 
        {
            for(int i=0;i<connections.Count; i++)
                if (connections[i].Name==name)
                    return connections[i];
            throw new System.Exception($"Connection with {name} was not found!");
        }
    }
}
