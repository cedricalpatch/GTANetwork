using System;
using System.Collections.Generic;
using GTANetworkServer;
using GTANetworkShared;
using counterCookieGTANScript.Vehicle;
using counterCookieGTANScript.Players;

namespace counterCookieGTANScript.Jobs
{
    public class Pilot : Script
    {
        private PlayerHandler playerHandler;

        private VehicleHash velumHash = (VehicleHash)(-1673356438);
        private Vehicle.Vehicle[] velum;

        private Marker markerLosSantosAirPort;
        private ColShape colShapeLosSantosAirPort;

        private Marker markerTrevorAirField;
        private ColShape colShapeTrevorAirField;

        private Marker markerVagosAirField;
        private ColShape colShapeVagosAirField;

        public Pilot()
        {
            API.onResourceStart += onResourceStart;
        }

        public void onResourceStart()
        {
            API.onPlayerEnterVehicle += OnPlayerEnterVehicleHandler;

            markerLosSantosAirPort = API.createMarker(1, new Vector3(-1251.526, -3340.647, 12), new Vector3(), new Vector3(), new Vector3(3, 3, 3), 20, 255, 201, 0, 0);
            colShapeLosSantosAirPort = API.createCylinderColShape(new Vector3(-1251.526, -3340.647, 12), 3, 3);
            setColShapeOnEntityEnter(colShapeLosSantosAirPort, "ls");

            markerTrevorAirField = API.createMarker(1, new Vector3(1715.949, 3256.686, 40), new Vector3(), new Vector3(), new Vector3(3, 3, 3), 20, 255, 201, 0, 0);
            colShapeTrevorAirField = API.createCylinderColShape(new Vector3(1715.949, 3256.686, 40), 3, 3);

            markerVagosAirField = API.createMarker(1, new Vector3(2130.785, 4807.092, 40), new Vector3(), new Vector3(), new Vector3(3, 3, 3), 20, 255, 201, 0, 0);
            colShapeVagosAirField = API.createCylinderColShape(new Vector3(2130.785, 4807.092, 40), 3, 3);
        }

        private void setColShapeOnEntityEnter(ColShape shape, String location)
        {
            shape.onEntityEnterColShape += (s, ent) =>
            {
                NetHandle player = ent;
                foreach (Client localPlayer in API.getAllPlayers())
                {
                    if(localPlayer.vehicle != null && API.getEntityData(localPlayer.handle, "JOB") == "pilot" && API.getEntityData(localPlayer.vehicle.handle, "JOB") == "pilot")
                    {
                        sendMessage("ls", 'r', localPlayer);
                        jobFinished(localPlayer);
                    }
                }
            };
        }

        public void jobFinished(Client player)
        {
            NetHandle vehicle = player.vehicle.handle;
            VehicleHash hash = API.getEntityData(vehicle, "HASH");
            Vector3 pos = API.getEntityData(vehicle, "POSITION");
            Vector3 rot = API.getEntityData(vehicle, "ROTATION");
            int color1 = API.getEntityData(vehicle, "COLOR1");
            int color2 = API.getEntityData(vehicle, "COLOR2");
            player.vehicle.rotation = rot;
            player.vehicle.position = pos;
            player.vehicle.repair();

            player.position = new Vector3(-1018.431, -2986.058, 14.94985);

        }

        public void sendMessage(String location, char right, Client player)
        {
            switch (location)
            {
                case "ls":
                    if (right.Equals('r') && )
                    {
                        API.sendNotificationToPlayer(player, "Du hast deinen Flug erfolgreich beendet!", true);
                        API.sendNotificationToPlayer(player, "Du hast ~g~000$ verdient...", true);
                    } else if (right.Equals('w'))
                    {
                        API.sendNotificationToPlayer(player, "Du hast deine Ware noch nicht abgeliefert!", true);
                    }
                    break;
                case "trevor":
                    API.sendNotificationToPlayer(player, "Fliege nun nach Los Santos zurueck!", true);
                    break;
                case "vagos":
                    API.sendNotificationToPlayer(player, "Fliege nun nach Los Santos zurueck!", true);
                    break;

            }
        }

        public void OnPlayerEnterVehicleHandler(Client player, NetHandle vehicle)
        {
            if(API.getEntityData(vehicle, "JOB") == "pilot" && API.getEntityData(player, "JOB") == "pilot")
            {

            } else
            {
                player.position = player.vehicle.position + new Vector3(0, 0, 2);
            }
        }
    }
}
