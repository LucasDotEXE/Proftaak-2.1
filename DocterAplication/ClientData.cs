using System.Collections.Generic;

namespace DocterAplication
{
    public class ClientData
    {
        private string name;
        private List<HeartRateMeasurement> heartRateMeasurement;
        private List<BikeSpeedMeasurement> bikeSpeedMeasurement;
        private List<BikePowerMeasurement> bikePowerMeasurement;

        public ClientData(string name)
        {
            this.name = name;
            heartRateMeasurement = new List<HeartRateMeasurement>();
            bikePowerMeasurement = new List<BikePowerMeasurement>();
            bikeSpeedMeasurement = new List<BikeSpeedMeasurement>();
        }
    }

    public class HeartRateMeasurement
    {
        private int bpm;
        private int expandedEnergy;
    }

    public class BikePowerMeasurement
    {
        private int acumulatedPower;
        private int currentPower;

    }

    public class BikeSpeedMeasurement
    {
        private int speed;
        private int distance;
    }

}