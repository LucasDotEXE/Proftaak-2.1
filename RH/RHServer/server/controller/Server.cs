using RHBase.helper;
using RHServer.server.model.client;
using RHServer.server.model.json;
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

        public X509Certificate certificate;
        private List<Client> clients;

        // constructor
        public void startServer()
        {

            this.certificate = X509Certificate.CreateFromCertFile(Config.certificate);
            this.clients = new List<Client>();

            new Thread(new ThreadStart(catchClients)).Start();

            Console.Read();
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

                Console.WriteLine(String.Format("Client Catcher chrashed.\n{0}.\nIt will restart in 10 seconds!", e.StackTrace));
                Thread.Sleep(10000);
                this.catchClients();
            }
        }

        // docter
        private void request(Client client, string receivedMessage)
        {

            if (receivedMessage.Length == 0)
                client.sendMessage(Config.requestPreset + AccountManager.getClients());
            else
                this.subscribeClientTo(client, this.parseIds(receivedMessage));
        }

        private void subscribeClientTo(ClientObserver ClientObserver, List<int> ids)
        {

            foreach (Client client in this.clients)
                if (ids.Contains(client.data.id))
                    client.subscribe(ClientObserver);
                else
                    client.unsubscribe(ClientObserver);
        }

        private List<int> parseIds(string receivedIds)
        {

            string[] stringIds = receivedIds.Split(':');
            List<int> ids = new List<int>();

            foreach (string id in stringIds)
                ids.Add(Convert.ToInt32(id));

            return ids;
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
