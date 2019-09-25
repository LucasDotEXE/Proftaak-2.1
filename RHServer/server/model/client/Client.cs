using RHServer.server.controller;
using RHServer.server.model.helpers;
using RHServer.server.model.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RHServer.server.model.client
{
    class Client
    {

        // attributes
        private List<Client> clients;
        private ClientData data = null;

        private Server server;

        private Thread thread;
        private TcpClient client;
        private NetworkStream stream;

        // constructor
        public Client(Server server, TcpClient client)
        {
            this.server = server;

            this.clients = new List<Client>();

            this.thread = new Thread(handleClientConnection);
            this.thread.Start(client);
        }

        // connection
        private void handleClientConnection(object obj)
        {

            this.client = obj as TcpClient;
            this.stream = client.GetStream();

            while (true)
            {

                this.server.receiveMessage(this, TCPHelper.readText(this.stream));

                Thread.Sleep(10);
            }
        }

        public void sendMessage(string message)
        {

            TCPHelper.sendText(this.stream, message);
        }

        // account
        public void login(string credentialString)
        {

            string[] credentials = credentialString.Split(':');

            if (credentials.Length == 3)
                this.data = AccountManager.login(credentials[0], credentials[1], Convert.ToBoolean(credentials[2]));

            this.sendMessage(Config.loginPreset + (this.data != null));
        }

        public void save()
        {

            if (this.data != null)
                AccountManager.save();
        }
    }
}
