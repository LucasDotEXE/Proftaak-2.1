using Newtonsoft.Json;
using RHBase;
using RHBase.helper;
using RHServer.server.controller;
using RHServer.server.model.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RHServer.server.model.client
{
    class Client : ClientObserver
    {

        // attributes
        private Server server;
        public ClientData data = null;
        private List<ClientObserver> observers = new List<ClientObserver>();

        private Thread thread;
        private SslStream stream;

        // constructor
        public Client(Server server, SslStream stream)
        {

            this.server = server;
            this.stream = stream;

            this.thread = new Thread(handleClientConnection);
            this.thread.Start();
        }

        // connection
        private void handleClientConnection()
        {

            this.stream.AuthenticateAsServer(this.server.certificate, false, true);

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

        public void receiveProtocol(string json)
        {

            Protocol protocol = JsonConvert.DeserializeObject<Protocol>(json);

            if (this.data != null)
                this.data.protocols.Add(protocol);

            this.sendObservers(Config.protocolPreset + json);
        }

        // observers
        public void sendObservers(string message)
        {

            this.sendMessage(message);

            foreach (ClientObserver observer in this.observers)
                observer.sendMessage(message);
        }

        public void subscribe(ClientObserver observer)
        {

            this.observers.Add(observer);
        }

        public void unsubscribe(ClientObserver observer)
        {

            this.observers.Remove(observer);
        }

        // account
        public void login(string credentialString)
        {

            string[] credentials = credentialString.Split(':');

            if (credentials.Length == 3)
                this.data = AccountManager.login(credentials[0], credentials[1], Convert.ToBoolean(credentials[2]));

            this.sendMessage(Config.loginPreset + (this.data != null));
        }
    }
}
