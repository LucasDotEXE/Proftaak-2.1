using RHLib.data;
using RHLib.helper;
using RHServer.server.controller;
using RHServer.server.model.account;
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

namespace RHServer.server.model.client
{

    class Client : ClientObserver
    {

        // attributes
        public bool isDocter;
        public Session session = null;

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
            }

            this.sendObservers(request);
        }

        // observers
        public void sendObservers(Request request)
        {

            foreach (ClientObserver observer in this.observers)
                observer.writeRequest(request);
        }

        public void subscribe(ClientObserver observer)
        {

            this.observers.Add(observer);
        }

        public void unsubscribe(ClientObserver observer)
        {

            this.observers.Remove(observer);
        }

        // ästrand
        public void startÄstrand(Request request)
        {

            if (this.observers.Count() == 1)
                this.observers[0].writeRequest(request);
        }

        public void stopÄstrandAsClient(Request request)
        {

            if (request.get("stop") && !this.isDocter)
            {

                SessionManager sessionManager = SessionManager.getInstance();
                sessionManager.addVO2ToSession(this.session);
                sessionManager.save();

                request.type = Config.subscribeType;
                request.add("message", "Test successfully stopped");
                request.add("session", JsonConvert.SerializeObject(this.session));

                this.sendObservers(request);
            }
        }

        public void stopÄstrandAsDoctor(Request request)
        {

            if (request.get("stop"))
                this.observers[0].writeRequest(request);
        }

        // account
        public void createSession(Request request)
        {

            this.session = SessionManager.getInstance().createSession(
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
