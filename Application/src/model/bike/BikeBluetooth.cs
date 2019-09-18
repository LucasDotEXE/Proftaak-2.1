using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.src.controller.interfaces;
using Application.src.model.entity;
using Avans.TI.BLE;

namespace Application.src.model.bike
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

        public void setResistance(int persentage)
        {

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

            this.observer.receiveProtocol(new Protocol(e.ServiceName, e.Data));
        }
    }
}
