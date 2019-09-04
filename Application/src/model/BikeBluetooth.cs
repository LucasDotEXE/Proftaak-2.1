using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avans.TI.BLE;

namespace Application.src.model
{

    class BikeBluetooth : IBike
    {

        public IObserver observer
        { get; }

        private BLE bleBike;
        private BLE bleHeart;

        // constructer
        public BikeBluetooth(IObserver observer)
        {

            this.observer = observer;
        }

        // connection
        public async Task startConnection()
        {

            int errorCode = 0;

            this.buildConnection();
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
        }

        private void buildConnection()
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

        // interface implementations
        public void sendData(object sender, BLESubscriptionValueChangedEventArgs e)
        {

            this.observer.receiveProtocol(new Protocol(
                e.ServiceName,
                BitConverter.ToString(e.Data).Replace("-", " "),
                Encoding.UTF8.GetString(e.Data)
            ));
        }
    }
}
