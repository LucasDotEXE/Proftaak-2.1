using IPRLib.data;
using IPRLib.helper;
using IPRServer.server.controller;
using IPRServer.server.model.account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPRServer.server.model.client
{

    class Client : ClientObserver
    {

        // attributes
        public bool isDocter;
        public Session session = null;
        public Ästrand ästrand = new Ästrand();

        private Server server;
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

                this.stream.AuthenticateAsServer(this.server.certificate, false, SslProtocols.Tls, true);

                SSLHelper.DisplaySecurityLevel(this.stream);
                SSLHelper.DisplaySecurityServices(this.stream);
                SSLHelper.DisplayCertificateInformation(this.stream);
                SSLHelper.DisplayStreamProperties(this.stream);

                this.stream.ReadTimeout = 3600000;
                this.stream.WriteTimeout = 3600000;

                Request request = TCPHelper.read(this.stream);
                this.isDocter = request.get("isDocter");

                while (true)
                {

                    this.server.receiveRequest(this, TCPHelper.read(this.stream));

                    Thread.Sleep(10);
                }
            }
            catch(Exception e)
            {

                SSLHelper.printException("Client::handleClientConnection", e);
            }
            finally
            {

                this.stream.Close();
                client.Close();
            }
        }

        public void writeRequest(Request request)
        {

            TCPHelper.write(this.stream, request);
        }

        public void receiveMeasurement(Request request)
        {

            Measurement measurement = JsonConvert.DeserializeObject<Measurement>(request.get("measurement"));

            if (this.session != null)
            {

                this.session.measurements.Add(measurement);
                SessionManager.save();
            }

            this.sendObservers(request);
        }

        // observers
        public void sendObservers(Request request)
        {

            foreach (ClientObserver observer in this.observers)
                observer.writeRequest(request);
        }

        public void startÄstrandAsDocter(Request request)
        {

            if (this.observers.Count() == 1)
                this.observers[0].writeRequest(request);
        }

        public void startÄstrandAsClient(Request request)
        {

            if (!this.isDocter && request.get("hasBike"))
                this.ästrand.start(this);
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
        public void createSession(Request request)
        {

            this.session = SessionManager.createSession(
                (int) request.get("age"),
                (int) request.get("weight"),
                request.get("name"), 
                request.get("gender")
            );

            request.clearParams();
            request.add("successful", (this.session != null));

            this.writeRequest(request);
        }
    }
}
