using System;
using System.Collections.Generic;
using System.Text;
using Client;

namespace RHCClient
{
    class TestMain
    {
        static void Main(string[] args)
        {
            SocketClient client = new SocketClient();
            client.StartClient();
        }
    }
}
