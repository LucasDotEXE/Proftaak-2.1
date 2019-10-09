using Newtonsoft.Json;
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

<<<<<<< HEAD
            this.sendMessage(Config.messagePreset + "Hallo Wereld!");
            this.sendMessage(Config.messagePreset + "Hallo Wereld!Hallo Wereld!Hallo Wereld!");
            this.sendMessage(Config.messagePreset + "Hallo Wereld!");
            this.sendMessage(Config.messagePreset + "Hallo Wereld!");
            this.sendMessage(Config.messagePreset + "Hallo Wereld!");
            this.sendMessage(Config.messagePreset + "Hallo Wereld!");

            string[] credentials = new string[] { "wessel", "00000000", false.ToString()};

            this.sendMessage(Config.loginPreset + JsonConvert.SerializeObject(credentials));

=======


            this.sendMessage(Config.messagePreset + "Hallo Wereld!");
>>>>>>> sslstream
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
