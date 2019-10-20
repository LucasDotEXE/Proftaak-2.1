using RHServer.server.controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHServer
{
    class Program
    {
        static void Main(string[] args)
        {

            new CreateStartAccount();

            Server server = new Server();
            server.startServer();
        }
    }
}
