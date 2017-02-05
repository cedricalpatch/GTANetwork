using System;
using GTANetworkServer;
using GTANetworkShared;
using System.Collections.Generic;

namespace counterCookieGTANScript.Players
{
    public class PlayerHandler : Script
    {
        public PlayerHandler()
        {
            API.onPlayerBeginConnect += OnPlayerBeginConnectHandler;
            API.onPlayerConnected += OnPlayerConnectedHandler;
            API.onPlayerDisconnected += OnPlayerDisconnectedHandler;
            API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;
            API.onEntityDataChange += OnEntityDataChange;
        }

        public void OnPlayerBeginConnectHandler(Client player, CancelEventArgs e)
        {
            Vector3 position = new Vector3(-1018.431, -2986.058, 14.94985);
            player.position = position;
        }

        private void OnPlayerConnectedHandler(Client player)
        {
        }

        private void OnPlayerFinishedDownloadHandler(Client player)
        {
            if (Database.Database.playerExists(player))
            {
                API.consoleOutput("Player " + player.name.ToString() + " is back!");
                String[] data = Database.Database.getPlayerData(player);
                setPlayerMoney(player, data[1]);
                API.setEntityData(player.handle, "JOB", data[2]);
            }
            else
                API.consoleOutput("New player " + player.name.ToString() + " joined!");

            API.setEntitySyncedData(player.handle, "ID", API.getAllPlayers().Count + 1);
        }

        private void OnPlayerDisconnectedHandler(Client player, string reason)
        {
        }

        private void OnEntityDataChange(NetHandle entity, string key, object oldValue)
        {
            if(key == "MONEY")
            {
                int newValue = API.getEntitySyncedData(entity, key);

                int playerMoney = API.getEntityData(entity, "LOCAL_MONEY");

                if (newValue != playerMoney)
                    API.setEntitySyncedData(entity, "MONEY", playerMoney);
            }
        }

        // Entity Data Handlers
        public void setPlayerID(Client player)
        {
            API.setEntityData(player.handle, "LOCAL_ID", API.getAllPlayers().Count + 1);
            API.setEntitySyncedData(player.handle, "ID", API.getAllPlayers().Count + 1);
        }

        public int getPlayerID(Client player)
        {
            if (API.hasEntityData(player.handle, "ID"))
                return API.getEntityData(player.handle, "ID");

            return 0;
        }

        public void setPlayerMoney(Client player, string money)
        {
            int userMoney = Int16.Parse(money);
            API.setEntityData(player.handle, "LOCAL_MONEY", userMoney);
            API.setEntitySyncedData(player.handle, "MONEY", userMoney);
        }

        public void addPlayerMoney(Client player, string money)
        {
            Database.Database.addPlayerMoney(player, Int16.Parse(money));
            int newMoney = Database.Database.getMoney(player);
            setPlayerMoney(player, newMoney.ToString());
        }

        public int getPlayerMoney(Client player)
        {
            if(API.hasEntityData(player.handle, "LOCAL_MONEY"))
                return API.getEntityData(player.handle, "MONEY");

            return 0;
        }
    }
}
