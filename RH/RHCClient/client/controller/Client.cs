using RHBase;
using RHBase.helper;
using System;

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



            this.sendMessage(Config.messagePreset + "Hallo Wereld!");
            Console.Read();
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
