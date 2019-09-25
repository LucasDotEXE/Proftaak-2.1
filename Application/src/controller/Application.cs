using Application.src.controller.interfaces;
using Application.src.model.bike;
using Application.src.model.entity;
using System;

namespace Application.src.controller
{
    class Application : IApplication
    {

        static void Main(string[] args)
        {

            IBike bike = new BikeBluetooth(new Application());
            bike.startConnection();
            
            Console.Read();
        }

        public void receiveProtocol(Protocol protocol)
        {

            Console.WriteLine(protocol);
        }
    }
}
