using Avans.TI.BLE;
using CRC;
using RHCClient.client.controller.interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RHLib.data;

namespace RHCClient.client.model.bike
{

    class BikeBluetooth : IBike
    {

        public IApplication observer
        { get; }

        private bool isConnected;
        private BLE bleBike;
        private BLE bleHeart;

        // constructer
        public BikeBluetooth(IApplication observer)
        {

            this.isConnected = false;
            this.observer = observer;
        }

        // connection
        public void startConnection()
        {

            new Thread(new ThreadStart(this.buildConnection)).Start();
        }

        public void setResistance(int percentage)
        {
            if (this.isConnected)
            {
                var crc32 = new Crc32(0xedb88320u, 0xffffffffu);
                byte[] output = new byte[13];
                output[0] = 0x4A; // Sync bit;
                output[1] = 0x09; // Message Length
                output[2] = 0x4E; // Message type
                output[3] = 0x05; // Message type
                output[4] = 0x30; // Data Type
                output[11] = (byte)percentage;
                output[12] = (byte)BitConverter.ToInt32(crc32.ComputeHash(output), 0);

                bleBike.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", output);
            }
        }

        private async void buildConnection()
        {

            int errorCode = 0;

            this.prepareConnection();
            this.drawDevices();

            errorCode = await bleBike.OpenDevice("Tacx Flux 01249");

            this.drawServices();

            errorCode = await bleBike.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");

            bleBike.SubscriptionValueChanged += this.sendData;

            errorCode = await bleBike.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");
            errorCode = await bleHeart.OpenDevice("Decathlon Dual HR");

            await bleHeart.SetService("HeartRate");

            bleHeart.SubscriptionValueChanged += this.sendData;

            await bleHeart.SubscribeToCharacteristic("HeartRateMeasurement");

            this.isConnected = true;
        }

        private void prepareConnection()
        {

            this.bleBike = new BLE();
            this.bleHeart = new BLE();

            Thread.Sleep(1000);
        }

        private void drawDevices()
        {

            List<String> bleBikes = this.bleBike.ListDevices();
            Console.WriteLine("Devices found: ");
            foreach (var name in bleBikes)
                Console.WriteLine($"Device: {name}");
        }

        private void drawServices()
        {

            var services = this.bleBike.GetServices;
            foreach (var service in services)
                Console.WriteLine($"Service: {service}");
        }

        private void sendData(object sender, BLESubscriptionValueChangedEventArgs e)
        {

            this.observer.receiveMeasurement(Measurement.newMeasurement(e.ServiceName, e.Data));
        }
    }
}
