using System;
using GTANetworkServer;
using GTANetworkShared;

namespace counterCookieGTANScript.Vehicle
{
    class VehicleHandler : Script
    {

        private NetHandle[] pilotVehicles;

        public VehicleHandler()
        {
            pilotVehicles = new NetHandle[1];
            API.consoleOutput("Spawn Velum's now!");
            pilotVehicles[0] = API.createVehicle((VehicleHash)(-1673356438), new Vector3(-1011.16f, -3011.951f, 13.94507f), new Vector3(0, 0, 60), 0, 0, 0);
            setVehicleID(pilotVehicles[0], 1);
            setVehicleJob(pilotVehicles[0], "pilot");
            setRespawnable(pilotVehicles[0], true);
            setHashCode(pilotVehicles[0], (VehicleHash)(-1673356438));
            setVehiclePos(pilotVehicles[0], new Vector3(-1011.16f, -3011.951f, 13.94507f));
            setVehicleRot(pilotVehicles[0], new Vector3(0, 0, 60));
            setColor1(pilotVehicles[0], 0);
            setColor2(pilotVehicles[0], 0);
            setVehicleCheckpoint(pilotVehicles[0], 0);
        }

        public void setVehicleCheckpoint(NetHandle vehicle, int checkpoint)
        {
            API.setEntityData(vehicle, "CHECKPOINT", checkpoint);
        }

        public int getVehicleCheckpoint(NetHandle vehicle)
        {
            return API.getEntityData(vehicle, "CHECKPOINT");
        }

        public void setVehicleID(NetHandle vehicle, int id)
        {
            API.setEntityData(vehicle, "ID", id);
        }

        public int getVehicleID(NetHandle vehicle)
        {
            return API.getEntityData(vehicle, "ID");
        }

        public void setHashCode(NetHandle vehicle, VehicleHash hash)
        {
            API.setEntityData(vehicle, "HASH", hash);
        }

        public void getHashCode(NetHandle vehicle)
        {
            API.getEntityData(vehicle, "HASH");
        }

        public void setVehiclePos(NetHandle vehicle, Vector3 positon)
        {
            API.setEntityData(vehicle, "POSITION", positon);
        }

        public Vector3 getVehiclePos(NetHandle vehicle)
        {
            return API.getEntityData(vehicle, "POSITION");
        }

        public void setVehicleRot(NetHandle vehicle, Vector3 positon)
        {
            API.setEntityData(vehicle, "ROTATION", positon);
        }

        public Vector3 getVehicleRot(NetHandle vehicle)
        {
            return API.getEntityData(vehicle, "ROTATION");
        }

        public void setColor1(NetHandle vehicle, int color)
        {
            API.setEntityData(vehicle, "COLOR1", color);
        }

        public void getColor1(NetHandle vehicle)
        {
            API.getEntityData(vehicle, "COLOR1");
        }

        public void setColor2(NetHandle vehicle, int color)
        {
            API.setEntityData(vehicle, "COLOR2", color);
        }

        public void setColor2(NetHandle vehicle)
        {
            API.getEntityData(vehicle, "COLOR2");
        }

        public void setVehicleJob(NetHandle vehicle, string job)
        {
            API.setEntityData(vehicle, "JOB", job);
        }

        public string getVehicleJob(NetHandle vehicle)
        {
            return API.getEntityData(vehicle, "JOB");
        }

        public void setRespawnable(NetHandle vehicle, bool respawnable)
        {
            API.setEntityData(vehicle, "RESPAWNABLE", respawnable);
        }

        public bool getRespawnable(NetHandle vehicle)
        {
            return API.getEntityData(vehicle, "RESPAWNABLE");
        }

        public void setMounted(NetHandle vehicle, bool isMounted)
        {
            API.setEntityData(vehicle, "MOUNTED", isMounted);
        }

        public bool getMounted(NetHandle vehicle)
        {
            return API.getEntityData(vehicle, "MOUNTED");
        }


    }
}
