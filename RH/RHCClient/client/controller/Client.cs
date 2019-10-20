using Newtonsoft.Json;
using RHCClient.client.controller.interfaces;
using RHCClient.client.model.bike;
using RHLib;
using RHLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHCClient.client.controller
{
    class Client : ClientConnection
    {

        public override void startClient()
        {

            this.startConnection(false);

            //IBike bike = new BikeBluetooth(this);
            //IBike bike = new BikeSimulation(this);
            //IBike bike = new BikeSimulatorLucas(this);
            //bike.startConnection();

            //this.sendMessage(Config.messagePreset + "Hallo Wereld!");

            string[] credentials = new string[] { "wessel", "00000000", false.ToString()};

            //this.sendMessage(Config.loginPreset + JsonConvert.SerializeObject(credentials));

            Console.Read();
        }

        // receivers
        public override void receiveRequest(Request request)
        {

            Console.WriteLine(request);
        }

        public void receiveMeasurement(Measurement measurement)
        {

            Console.WriteLine(measurement);
        }
    }
}
