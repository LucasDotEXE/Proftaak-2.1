using Newtonsoft.Json;
using RHBase.helper;
using RHServer.server.model.account;
using RHServer.server.model.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RHServer.server.controller
{
    class Server
    {

        public X509Certificate2 certificate;
        private List<Client> clients;

        // constructor
        public void startServer()
        {

            try
            {

                this.certificate = new X509Certificate2(Config.certificatePath, Config.certificateKey);
                this.clients = new List<Client>();

                new Thread(new ThreadStart(catchClients)).Start();
            }
            catch (Exception e)
            {

                Console.WriteLine("Couldn't authenticate: {0}", e.StackTrace);

                if (e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
            }
        }

        // connection
        private void catchClients()
        {

            try
            {

                IPAddress ip;

                if (!IPAddress.TryParse(Config.host, out ip))
                    throw new Exception();

                TcpListener listener = new TcpListener(ip, Config.port);
                listener.Start();

                while (true)
                {

                    this.clients.Add(new Client(this, listener.AcceptTcpClient()));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Client Catcher Crashed: {0}, name: {1}", e.StackTrace, e.GetType().Name);

                if (e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);

                Thread.Sleep(10000);
                this.catchClients();
            }
        }

        // Request
        private void request(Client client, string receivedMessage)
        {

            if (receivedMessage.Length == 0)
                client.sendMessage(Config.requestPreset + AccountManager.getClients());
            else
                this.subscribeClientTo(client, JsonConvert.DeserializeObject<List<int>>(receivedMessage));
        }

        private void subscribeClientTo(ClientObserver ClientObserver, List<int> ids)
        {

            foreach (Client client in this.clients)
                if (ids.Contains(client.data.id))
                    client.subscribe(ClientObserver);
                else
                    client.unsubscribe(ClientObserver);
        }

        // messaging
        public void receiveMessage(Client client, string receivedMessage)
        {

            string preset = receivedMessage.Substring(0, 1);
            string message = receivedMessage.Substring(1);

            switch (preset)
            {

                case Config.loginPreset:    client.login(message);                                  break;
                case Config.messagePreset:  client.sendObservers(Config.messagePreset + message);   break;
                case Config.requestPreset:  client.receiveProtocol(message);                        break;
                case Config.protocolPreset: this.request(client, message);                          break;
            }
        }
    }
}
