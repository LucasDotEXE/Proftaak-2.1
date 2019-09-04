using Application.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.src
{
    class Program : IProgram
    {

        public static void Main(string[] args)
        {

            // must be new Program due to the absense of this in a static function
            BikeBluetooth bike = new BikeBluetooth(new Program());

            // don't require await due to it being the last line
            bike.startConnection();
        }

        public void receiveProtocol(Protocol protocol)
        {

            Console.WriteLine(protocol.serviceName);
        }
    }
}
