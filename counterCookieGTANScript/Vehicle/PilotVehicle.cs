using System;
using GTANetworkServer;
using GTANetworkShared;
using counterCookieGTANScript.Vehicle;

namespace counterCookieGTANScript.Vehicle
{
    class PilotVehicle : Vehicle
    {
        public PilotVehicle()
        {
        }

        public PilotVehicle(int id, String name, VehicleHash hash, float x, float y, float z, float rotationX, float rotationY, float rotationZ, int color1, int color2, int dimension) : base(id, name, hash, x, y, z, rotationX, rotationY, rotationY, color1, color2, dimension)
        {
        }

        public void OnPlayerEnterVehicleHandler(Client player, NetHandle vehicle)
        {
            /*if (vehicle == this.getProp())
            {
                API.consoleOutput(player + " entered a Pilot vehicle");
            }
            if (vehicle.Equals(this))
            {
                API.consoleOutput("Test if 'this' also works");
            }*/
        }
    }
}
