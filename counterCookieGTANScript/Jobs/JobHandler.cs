using System;
using GTANetworkServer;
using GTANetworkShared;
using counterCookieGTANScript.Players;

namespace counterCookieGTANScript.Jobs
{
    class JobHandler : Script
    {

        private PlayerHandler playerHandler;
        private Pilot pilot;

        public JobHandler()
        {
            startJobs();
        }

        public void startJobs()
        {
            pilot = new Pilot();
        }
    }
}
