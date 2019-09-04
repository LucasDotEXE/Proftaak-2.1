using Application.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.src
{
    class Application : IApplication
    {

        static void Main(string[] args)
        {

            BikeBluetooth bike = new BikeBluetooth(new Application());
            bike.startConnection();
        }

        public void receiveProtocol(Protocol protocol)
        {

            Console.WriteLine(protocol.serviceName);
        }
    }
}
