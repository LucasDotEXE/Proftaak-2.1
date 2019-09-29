using RHBase;
using RHBase.helper;
using RHCClient.client.controller.interfaces;
using RHCClient.client.model.bike;
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

            this.startConnection();

            //IBike bike = new BikeBluetooth(this);
            //IBike bike = new BikeSimulation(this);
            //IBike bike = new BikeSimulatorLucas(this);
            //bike.startConnection();

            Console.Read();

            this.sendMessage(Config.messagePreset + "Hallo Wereld!");
        }

        // receivers
        public override void receiveMessage(string message)
        {

            Console.WriteLine(message);
        }

        public void receiveProtocol(Protocol protocol)
        {

            Console.WriteLine(protocol);
        }
    }
}
