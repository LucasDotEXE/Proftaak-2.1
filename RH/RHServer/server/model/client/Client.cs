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
using System.Security.Authentication;
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
        public Client(Server server, TcpClient client)
        {

            this.server = server;

            this.thread = new Thread(handleClientConnection);
            this.thread.Start(client);
        }

        // connection
        private void handleClientConnection(object obj)
        {

            TcpClient client = obj as TcpClient;
            this.stream = new SslStream(client.GetStream(), false);

            try
            {

                this.stream.AuthenticateAsServer(this.server.certificate, false, true);

                this.stream.ReadTimeout = 10;
                this.stream.WriteTimeout = 10;

                while (true)
                {

                    this.server.receiveMessage(this, TCPHelper.read(this.stream));

                    Thread.Sleep(10);
                }
            }
            catch(Exception e)
            {

                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
            }
            finally
            {

                this.stream.Close();
                client.Close();
            }
        }

        public void sendMessage(string message)
        {

            try
            {

                TCPHelper.send(this.stream, message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Couldn't send message: {0}\n{1}", message, e.StackTrace);
            }
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
