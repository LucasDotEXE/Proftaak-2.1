using Avans.TI.BLE;
using RHLib.data;
using RHLib.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RHClient.client.model
{

    public class BlueTooth
    {

        public Request request = null;

        private BLE bleBike;
        private BLE bleHeart;

        public int error = 0;
        public int resistance = 0;

        public bool hasHeartRate = false;
        public bool running = true;
        
        public BlueTooth(Request request)
        {

            this.request = request;
        }

        public async Task start()
        {

            this.bleBike = new BLE();
            this.bleHeart = new BLE();

            Thread.Sleep(1000); // We need some time to list available devices

            // Connecting
            this.error = this.error = await bleBike.OpenDevice("Tacx Flux " + this.request.get("bikeId"));

            // Set service
            this.error = await bleBike.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");

            // Subscribe
            bleBike.SubscriptionValueChanged += BleBike_SubscriptionValueChanged;
            this.error = await bleBike.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");

            if (this.error != 0)
                throw new Exception("1");

            await this.connectWithHeartRateAsync();

            while (this.running)
            {

                await Task.Delay(1000);
            }
        }

        public async Task connectWithHeartRateAsync()
        {

            // Heart rate
            try
            {

                this.error = await bleHeart.OpenDevice("Decathlon Dual HR");

                await bleHeart.SetService("HeartRate");

                bleHeart.SubscriptionValueChanged += BleBike_SubscriptionValueChanged;
                await bleHeart.SubscribeToCharacteristic("HeartRateMeasurement");
            } catch (Exception e)
            {

                SSLHelper.printException("BlueTooth:connectWithHeartRateAcync", e);
            }
            

            if (this.error == 0)
            {

                this.hasHeartRate = true;

                this.request.add("message", "Successfully started test");
            }
            else
            {

                this.request.add("message", "No heart rate monitor connected");
            }

            this.request.add("started", true);
            Program.client.writeRequest(request);

            if (!this.hasHeartRate)
            {

                Thread.Sleep(3000);
                await this.connectWithHeartRateAsync();
            }
        }

        public void stop()
        {

            this.running = false;

            this.bleBike = null;
            this.bleHeart = null;
        }

        public void BleBike_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {

            Measurement measurement = MeasurementBuilder.build(e.Data, this.request.get("bikeId"));

            if (Program.client.ästrandForm.ästrand != null && measurement != null)
            {

                Program.client.writeMeasurementRequest(measurement);
                Program.client.ästrandForm.ästrand.nextMeasure(measurement.bpm);
            }
        }

        private void setResistance()
        {

            if (this.resistance >= 0 && this.resistance <= 200 && this.hasHeartRate)
            {

                byte[] message = new byte[13];

                message[0] = 0xA4;                     // Sync byte
                message[1] = 0x09;                     // Length of message is 8 bytes content + 1 channel byte
                message[2] = 0x4E;                     // Msg id 
                message[3] = 0x05;                     // Channel id
                message[4] = 0x30;                     // We want to change the resistance (0x30)

                for (int i = 5; i < 11; i++)
                    message[i] = 0xFF;

                message[11] = Convert.ToByte(this.resistance);  // Value of the resistance, 1 == 0.5%
                
                //Checksum
                byte checksum = 0;

                for (int i = 1; i < 12; i++)
                    checksum ^= message[i];

                message[12] = checksum;

                this.bleBike.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", message);
            }
        }

        public void alterResistance(int alter)
        {

            if (this.resistance + alter >= 0 && this.resistance + alter <= 200)
            {

                this.resistance += alter;
                this.setResistance();
            }
            else if (this.resistance != 200 && this.resistance != 0)
            {

                if (alter > 0)
                    this.resistance = 200;
                else
                    this.resistance = 0;

                this.setResistance();
            }
        }

        public int getResistance()
        {

            return this.resistance;
        }
    }
}
