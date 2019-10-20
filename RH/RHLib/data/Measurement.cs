using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHLib.data
{
    public class Measurement
    {

        public string serviceName { get; set; }
        public double speed { get; set; }
        public double heartrate { get; set; }
        public double distance { get; set; }
        public int acumilatedPower { get; set; }
        public int currentPower { get; set; }

        public static Measurement newMeasurement(string serviceName, byte[] bytes)
        {

            Measurement measurement = new Measurement();

            measurement.serviceName = serviceName;
            measurement.updateMeasurment(bytes);

            return measurement;
        }

        public void updateMeasurment(byte[] bytes)
        {

            switch (bytes[4])
            {
                case 0x10:
                    speed = bytes[9] + bytes[8];
                    distance = bytes[7];
                    break;
                case 0x14: break;
                case 0x19:
                    acumilatedPower = bytes[8] + bytes[7];
                    currentPower = bytes[10] + bytes[9];
                    break;
            }
        }

        public void update(byte[] content)
        {

            updateMeasurment(content);
        }

        public override string ToString()
        {

            return string.Format(
                "ServiceName: {0}\nSpeed: {1}\nHeartrate: {2}\nDistance: {3}\nAcumilatedPower: {4}\nCurrentPower: {5}\n",
                 this.serviceName, this.speed, this.heartrate, this.distance, this.acumilatedPower, this.currentPower
            );
        }
    }
}
