using System;
using System.Collections.Generic;
using GTANetworkServer;
using GTANetworkShared;
using counterCookieGTANScript.Jobs;
using counterCookieGTANScript.Players;
using counterCookieGTANScript.Vehicle;

namespace counterCookieGTANScript
{
    public class HeadScript : Script
    {
        private PlayerHandler playerHandler;
        private JobHandler jobHandler;
        private VehicleHandler vehicleHandler;

        public HeadScript()
        {
            API.onResourceStart += myResourceStart;
        }

        public void myResourceStart()
        {
            playerHandler = new PlayerHandler();
            jobHandler = new JobHandler();
            //vehicleHandler = new VehicleHandler();
        }
    }
}
