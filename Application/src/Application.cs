using Application.src.model;
using System;

namespace Application.src
{
    class Application : IApplication
    {

        /*static void Main(string[] args)
        {

            BikeBluetooth bike = new BikeBluetooth(new Application());
            bike.startConnection();
        }*/

        public void receiveProtocol(Protocol protocol)
        {

            Console.WriteLine(protocol.serviceName);
        }
    }
}
