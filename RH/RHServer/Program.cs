using RHServer.server.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Server server = new Server();
            server.startServer(args[0]);
        }
    }
}
