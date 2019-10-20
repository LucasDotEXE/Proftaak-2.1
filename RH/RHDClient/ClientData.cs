using System.Collections.Generic;

namespace DocterAplication
{
    public class ClientData
    {
        public string name;
        public List<string> messages;
        public int resistance;

        private List<HeartRateMeasurement> heartRateMeasurements;
        public List<HeartRateMeasurement> HeartRateMeasurements
        {
            get
            {
                return this.heartRateMeasurements;
            }
        }
        private List<BikeSpeedMeasurement> bikeSpeedMeasurements;
        public List<BikeSpeedMeasurement> BikeSpeedMeasurements
        {
            get
            {
                return this.bikeSpeedMeasurements;
            }
        }
        private List<BikePowerMeasurement> bikePowerMeasurements;
        public List<BikePowerMeasurement> BikePowerMeasurements
        {
            get
            {
                return this.bikePowerMeasurements;
            }
        }

        public ClientData(string name)
        {
            this.name = name;
            this.messages = new List<string>();
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

        public HeartRateMeasurement(int bpm, int expandedEnergy)
        {
            this.bpm = bpm;
            this.expandedEnergy = expandedEnergy;
        }

        public int Bpm
        {
            get
            {
                return this.bpm;
            }
        }
        public int ExpandedEnergy
        {
            get
            {
                return this.expandedEnergy;
            }
        }
    }

    public class BikePowerMeasurement
    {
        private int acumulatedPower;
        private int currentPower;

        public BikePowerMeasurement(int acumulatedPower, int currentPower)
        {
            this.acumulatedPower = acumulatedPower;
            this.currentPower = currentPower;
        }

        public int AcumulatedPower
        {
            get
            {
                return this.acumulatedPower;
            }
        }
        public int CurrentPower
        {
            get
            {
                return this.currentPower;
            }
        }
    }

    public class BikeSpeedMeasurement
    {
        private int speed;
        private int distance;

        public BikeSpeedMeasurement(int speed, int distance)
        {
            this.speed = speed;
            this.distance = distance;
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
        }
        public int Distance
        {
            get
            {
                return this.distance;
            }
        }
    }

}