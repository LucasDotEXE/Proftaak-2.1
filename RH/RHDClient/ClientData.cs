using Newtonsoft.Json;
using RHLib.data;
using System;
using System.Collections.Generic;

namespace DocterAplication
{

    public class ClientData
    {

        public int id;
        public int resistance;

        public string name;
        public List<string> messages;

        public List<HeartRateMeasurement> heartRateMeasurements { get; }
        public List<BikeSpeedMeasurement> bikeSpeedMeasurements { get; }
        public List<BikePowerMeasurement> bikePowerMeasurements { get; }

        public ClientData(int id, string name)
        {

            this.id = id;
            this.name = name;
            this.messages = new List<string>();

            this.heartRateMeasurements = new List<HeartRateMeasurement>();
            this.bikePowerMeasurements = new List<BikePowerMeasurement>();
            this.bikeSpeedMeasurements = new List<BikeSpeedMeasurement>();
        }

        public void addMeasurement(Measurement measurement)
        {

            this.addHeartRateMeasurement(new HeartRateMeasurement(measurement.heartrate, 0));
            this.addBikePowerMeasurement(new BikePowerMeasurement(measurement.acumilatedPower, measurement.currentPower));
            this.addBikeSpeedMeasurement(new BikeSpeedMeasurement(measurement.speed, measurement.distance));
        }

        public void setMeasurements(Request request)
        {

            foreach (Measurement measurement in JsonConvert.DeserializeObject<List<Measurement>>(request.get("measurements")))
                this.addMeasurement(measurement);
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

        public HeartRateMeasurement(double bpm, int expandedEnergy)
        {

            this.bpm = Convert.ToInt32(bpm.ToString());
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

        private double speed;
        private double distance;

        public BikeSpeedMeasurement(double speed, double distance)
        {

            this.speed = speed;
            this.distance = distance;
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }
        }

        public double Distance
        {
            get
            {
                return this.distance;
            }
        }
    }
}