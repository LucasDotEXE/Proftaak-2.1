using Application.src.model;
using System;

namespace Application.src
{
    class Application : IApplication
    {

        static void Main(string[] args)
        {

            IBike bike = new BikeSimulation(new Application());
            bike.startConnection();
            
            Console.Read();
        }

        public void receiveProtocol(Protocol protocol)
        {

            Console.WriteLine(protocol);
        }
    }
}
