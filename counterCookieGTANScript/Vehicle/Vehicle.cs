using System;
using GTANetworkServer;
using GTANetworkShared;

namespace counterCookieGTANScript.Vehicle
{
    class Vehicle : Script
    {
        private GTANetworkServer.Vehicle prop;

        private int id;
        private String name;
        private VehicleHash hash;

        private int color1;
        private int color2;

        private int dimension;

        private float x;
        private float y;
        private float z;

        private float rotationX;
        private float rotationY;
        private float rotationZ;

        public Vehicle()
        {
        }

        public Vehicle(int id, String name, VehicleHash hash, float x, float y, float z, float rotationX, float rotationY, float rotationZ, int color1, int color2, int dimension)
        {
            this.id = id;
            this.name = name;
            this.hash = hash;

            this.color1 = color1;
            this.color2 = color2;

            this.dimension = dimension;

            this.x = x;
            this.y = y;
            this.z = z;

            this.rotationX = rotationX;
            this.rotationY = rotationY;
            this.rotationZ = rotationZ;

            spawnVehicle();
        }

        public void spawnVehicle()
        {
            prop = API.createVehicle(hash, new Vector3(x, y, z), new Vector3(rotationX, rotationY, rotationZ), color1, color2, dimension);
            API.consoleOutput("Vehicle: " + id + " | " + name + " :spawned at pos: " + "x: " + this.x + " | y: " + this.y + " | z: " + this.z);
        }

        public String getName()
        {
            return name;
        }

        public int getId()
        {
            return id;
        }

        public GTANetworkServer.Vehicle getProp()
        {
            return prop;
        }

    }
}
