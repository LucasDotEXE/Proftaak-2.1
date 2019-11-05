using Avans.TI.BLE;
using IPRLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPRClient.client.model
{

    public class BlueTooth
    {

        public string idBike = null;

        private BLE bleBike;
        private BLE bleHeart;

        public int error = 0;
        
        public BlueTooth(string idBike)
        {

            this.idBike = idBike;
        }

        public async Task start()
        {

            this.bleBike = new BLE();
            this.bleHeart = new BLE();

            Thread.Sleep(1000); // We need some time to list available devices

            // Connecting
            this.error = this.error = await bleBike.OpenDevice("Tacx Flux " + idBike);

            // Set service
            this.error = await bleBike.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");

            // Subscribe
            bleBike.SubscriptionValueChanged += BleBike_SubscriptionValueChanged;
            this.error = await bleBike.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");

            // Heart rate
            this.error = await bleHeart.OpenDevice("Decathlon Dual HR");

            await bleHeart.SetService("HeartRate");

            bleHeart.SubscriptionValueChanged += BleBike_SubscriptionValueChanged;
            await bleHeart.SubscribeToCharacteristic("HeartRateMeasurement");

            Console.Read();
        }

        public void stop()
        {

            this.bleBike = null;
            this.bleHeart = null;
        }

        public void BleBike_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {

            Measurement measurement = MeasurementBuilder.build(e.Data, this.idBike);

            Program.client.writeMeasurementRequest(measurement);
            Program.client.testForm.setValues(measurement);
        }

        public void setResistance(int amount)
        {

            if (amount >= 0 && amount <= 200)
            {

                byte[] message = new byte[13];

                message[0] = 0xA4;                     // Sync byte
                message[1] = 0x09;                     // Length of message is 8 bytes content + 1 channel byte
                message[2] = 0x4E;                     // Msg id 
                message[3] = 0x05;                     // Channel id
                message[4] = 0x30;                     // We want to change the resistance (0x30)

                for (int i = 5; i < 11; i++)
                    message[i] = 0xFF;

                message[11] = Convert.ToByte(amount);  // Value of the resistance, 1 == 0.5%
                
                //Checksum
                byte checksum = 0;

                for (int i = 1; i < 12; i++)
                    checksum ^= message[i];

                message[12] = checksum;

                this.bleBike.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", message);
            }
        }
    }
}
