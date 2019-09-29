using System.Collections.Generic;

namespace DocterAplication
{
    public class ClientData
    {
        public string name;
        private List<HeartRateMeasurement> heartRateMeasurements;
        private List<BikeSpeedMeasurement> bikeSpeedMeasurements;
        private List<BikePowerMeasurement> bikePowerMeasurements;

        public ClientData(string name)
        {
            this.name = name;
            heartRateMeasurements = new List<HeartRateMeasurement>();
            bikePowerMeasurements = new List<BikePowerMeasurement>();
            bikeSpeedMeasurements = new List<BikeSpeedMeasurement>();
        }

        public void addHeartRateMeasurement(HeartRateMeasurement measurement)
        {
            heartRateMeasurements.Add(measurement);
        }

        public void addBikePowerMeasurement(BikePowerMeasurement measurement)
        {
            bikePowerMeasurements.Add(measurement);
        }

        public void addBikeSpeedMeasurement(BikeSpeedMeasurement measurement)
        {
            bikeSpeedMeasurements.Add(measurement);
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