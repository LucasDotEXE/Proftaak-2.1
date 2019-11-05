using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRLib.data
{

    public class Measurement
    {

        public string serviceName { get; set; }
        public double bpm { get; set; }
        public double speed { get; set; }
        public double distance { get; set; }
        public double currentPower { get; set; }
        public double acumilatedPower { get; set; }
        public double vo2 { get; set; }

        public static Measurement newMeasurement(string serviceName)
        {

            Measurement measurement = new Measurement();

            measurement.serviceName = serviceName;
            measurement.bpm = -1;
            measurement.speed = -1;
            measurement.distance = -1;
            measurement.currentPower = -1;
            measurement.acumilatedPower = -1;
            measurement.vo2 = -1;

            return measurement;
        }

        public override string ToString()
        {

            return JsonConvert.SerializeObject(this);
        }
    }

    public static class MeasurementBuilder
    {

        private static int previousTotalDistance = 0;
        private static int totalDistance = 0;

        // builder
        public static Measurement build(byte[] data, string serviceName)
        {

            Measurement measurement = Measurement.newMeasurement(serviceName);

            if (!Checksum(data) && !(data[0] == 0x16))
                return null;

            // Speed
            if (data[4] == 0x10)
            {

                int totalDistance = data[7];
                int SpeedLSB = data[8];
                int SpeedMSB = data[9];

                measurement.distance = TotalDistance(totalDistance);
                measurement.speed = ConverBits(SpeedLSB, SpeedMSB);
            }

            // Bike data: power
            if (data[4] == 0x19)
            {

                int accumulatedPowerLSB = data[7];
                int accumulatedPowerMSB = data[8];
                measurement.acumilatedPower = ConverBits(accumulatedPowerLSB, accumulatedPowerMSB);
                int currentPowerLSB = data[9];
                int currentPowerRSB = data[10];
                measurement.currentPower = ConverBits(currentPowerLSB, currentPowerRSB);
            }

            //Heartrate
            if (data[0] == 0x16)
                measurement.bpm = data[1];

            return measurement;
        }

        // methods
        private static bool Checksum(byte[] data)
        {

            int result = data[0];

            for (int i = 1; i < data.Length - 1; i++)
                result ^= data[i];

            return result == data[data.Length - 1];
        }

        private static int TotalDistance(int distance)
        {

            if (distance < previousTotalDistance)
                totalDistance += distance;
            else
                totalDistance += (distance - previousTotalDistance);

            previousTotalDistance = distance;

            return totalDistance;
        }

        private static double ConverBits(int LSB, int MSB)
        {

            int combined = (MSB << 8) | LSB;
            return (double)combined / 1000.0;
        }
    }
}
