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

        public List<Measurement> measurements { get; }

        public List<HeartRateMeasurement> heartRateMeasurements { get; }
        public List<BikeSpeedMeasurement> bikeSpeedMeasurements { get; }
        public List<BikePowerMeasurement> bikePowerMeasurements { get; }

        public ClientData(int id, string name)
        {

            this.id = id;
            this.name = name;
            this.messages = new List<string>();

            this.measurements = new List<Measurement>();

            this.heartRateMeasurements = new List<HeartRateMeasurement>();
            this.bikePowerMeasurements = new List<BikePowerMeasurement>();
            this.bikeSpeedMeasurements = new List<BikeSpeedMeasurement>();
        }

        public void setMeasurements(Request request)
        {

            foreach (Measurement measurement in request.get("measurements"))
                this.measurements.Add(measurement);
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