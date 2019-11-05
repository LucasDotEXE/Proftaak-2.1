using IPRLib.data;
using IPRLib.helper;
using IPRServer.server.model.account;
using IPRServer.server.model.client;
using Newtonsoft.Json;
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

namespace IPRServer.server.controller
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

                SSLHelper.printException("Server::startServer", e);
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

                SSLHelper.printException("Server::catchClients", e);
            }
        }

        // Request
        private void getSessionNames(Client client, Request request)
        {

            List<string[]> offline = SessionManager.getSessionNames();
            List<string[]> online = this.getOnlineNames();

            request.add("offline", JsonConvert.SerializeObject(offline));
            request.add("online", JsonConvert.SerializeObject(online));

            client.writeRequest(request);
        }

        private List<string[]> getOnlineNames()
        {

            List<string[]> online = new List<string[]>();

            foreach (Client client in this.clients)
                if (client.session != null)
                    online.Add(new string[2] { client.session.name, client.session.id.ToString() });
                    
            return online;
        }

        private void subscribe(Client docter, Request request)
        {

            Client foundClient = null;
            int id = (int) request.get("id");

            foreach (Client client in this.clients)
            {

                docter.unsubscribe(client);
                client.unsubscribe(docter);

                if (client.session != null && id == client.session.id)
                    foundClient = client;
            }

            if (foundClient == null)
                request.add("session", JsonConvert.SerializeObject(SessionManager.getById(id)));
            else
            {

                docter.subscribe(foundClient);
                foundClient.subscribe(docter);

                request.add("session", JsonConvert.SerializeObject(foundClient.session));
            }

            docter.writeRequest(request);
        }

        // messaging
        public void receiveRequest(Client client, Request request)
        {

            switch (request.type)
            {

                case Config.testType: client.startÄstrandAsClient(request); break;
                case Config.measurementType: client.receiveMeasurement(request); break;
                case Config.createSessionType: client.createSession(request); break;
            }

            if (client.isDocter)
            {

                switch (request.type)
                {

                    case Config.testType: client.startÄstrandAsDocter(request); break;
                    case Config.subscribeType: this.subscribe(client, request); break;
                    case Config.readSessionType: this.getSessionNames(client, request); break;
                }
            }
        }
    }   
}
