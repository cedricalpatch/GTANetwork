using System;
using MySql.Data.MySqlClient;
using GTANetworkServer;

namespace counterCookieGTANScript.Database
{
    class Database
    {
        private static String SERVERIP = "localhost";
        private static String DATABASE = "gtanetwork";
        private static String USERNAME = "root";
        private static String PASSWORD = "";

        public static String myConnectionString = String.Format(@"server={0};uid={1};password={2};database={3};port=3306;", SERVERIP, USERNAME, PASSWORD, DATABASE);
        public static MySqlConnection connection;
        public static MySqlCommand command;
        public static MySqlDataReader Reader;


        public static Boolean playerExists(Client player)
        {
            connection = new MySqlConnection(myConnectionString);

            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM user";

            connection.Open();

            Reader = command.ExecuteReader();

            while(Reader.Read())
            {
                string name = Reader.GetString("name");
                
                if(name == player.name.ToString())
                {
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            return false;
        }

        public static String[] getPlayerData(Client player)
        {
            String[] data = new String[3]; 
            connection = new MySqlConnection(myConnectionString);

            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM user WHERE name ='" + player.name.ToString() + "'";

            connection.Open();

            Reader = command.ExecuteReader();

            Reader.Read();

            data[0] = Reader.GetInt16("id").ToString();
            data[1] = Reader.GetInt16("money").ToString();
            data[2] = Reader.GetString("job");

            connection.Close();

            return data;
        }
        
        public static void updateMoney(Client player, int money)
        {
            connection = new MySqlConnection(myConnectionString);
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE user SET money=" + money + " WHERE name= '" + player.name.ToString() + "'";
            command.ExecuteReader();

            connection.Close();
        }

        public static int getMoney(Client player)
        {
            connection = new MySqlConnection(myConnectionString);

            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM user WHERE name = '" + player.name.ToString() + "'";

            connection.Open();

            Reader = command.ExecuteReader();

            Reader.Read();
            int playerMoney = Reader.GetInt16("money");

            connection.Close();
            return playerMoney;
        }

        public static void addPlayerMoney(Client player, int money)
        {
            int currentMoney = getMoney(player);
            int newMoney = currentMoney + money;
            updateMoney(player, newMoney);
        }


    }
}
