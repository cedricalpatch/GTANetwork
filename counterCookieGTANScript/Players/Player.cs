using System;
using GTANetworkServer;
using GTANetworkShared;

namespace counterCookieGTANScript.Players
{
    public class Player : Script
    {
        private int id;
        private int databaseId;

        private String name;
        private int money;
        private String job;

        private Client player;

        public Player()
        {
        }

        public Player(int id, Client player)
        {
            this.id = id;
            this.name = player.name;
            this.player = player;
        }

        public void setSqlData(String[] data)
        {
            this.databaseId = Int16.Parse(data[0]);
            this.money = Int16.Parse(data[1]);
            this.job = data[2];
        }

        public Client getPlayer()
        {
            return player;
        }

        public int getMoney()
        {
            return money;
        }

        public String getJob()
        {
            return job;
        }
    }
}
