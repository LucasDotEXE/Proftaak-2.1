using Newtonsoft.Json;
using RHServer.server.model.account;
using RHServer.server.model.client;
using RHLib.data;
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
using RHLib.helper;

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
        private void getNames(Client client, Request request)
        {

            request.add("names", AccountManager.getClientNames());

            client.sendRequest(request);
        }

        private void subscribe(Client docter, Request request)
        {

            Client client = null;
            int id = request.get("id");

            foreach (Client c in this.clients)
            {

                docter.unsubscribe(c);
                c.unsubscribe(docter);

                if (id == c.data.id)
                    client = c;
            }

            docter.subscribe(client);
            client.subscribe(docter);

            request.add("measurements", JsonConvert.SerializeObject(client.data.measurements));
            docter.sendRequest(request);
        }

        // messaging
        public void receiveMessage(Client client, Request request)
        {

            Console.WriteLine(request);

            switch (request.type)
            {

                case Config.loginType:       client.login(request);              break;
                case Config.messageType:     client.sendObservers(request);      break;
                case Config.measurementType: client.receiveMeasurement(request); break;
                case Config.subscribeType:   this.subscribe(client, request);    break;
                case Config.nameType:        this.getNames(client, request);     break;
            }
        }
    }
}
