using Newtonsoft.Json;
using RHLib.data;
using RHLib.helper;
using RHServer.server.controller;
using RHServer.server.model.account;
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
        public ClientData data = null;

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

                this.stream.ReadTimeout = 60000;
                this.stream.WriteTimeout = 60000;

                this.isDocter = TCPHelper.read(this.stream).get("isDocter");

                while (true)
                {

                    this.server.receiveMessage(this, TCPHelper.read(this.stream));

                    Thread.Sleep(10);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: {0}\n name: {1}", e.Message, e.GetType().Name);

                if (e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
            }
            finally
            {

                this.stream.Close();
                client.Close();
            }
        }

        public void sendRequest(Request request)
        {

            try
            {

                TCPHelper.write(this.stream, request);
            }
            catch (Exception e)
            {

                Console.WriteLine("Couldn't send request: {0}\n{1}", request, e.StackTrace);
            }
        }

        public void receiveProtocol(Request request)
        {

            Measurement measurement = request.get("measurement");

            if (this.data != null)
                this.data.protocols.Add(measurement);

            this.sendObservers(request);
        }

        // observers
        public void sendObservers(Request request)
        {

            foreach (ClientObserver observer in this.observers)
                observer.sendRequest(request);
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
        public void login(Request request)
        {

            this.data = AccountManager.login(
                request.get("name"), 
                request.get("password"), 
                request.get("register")
            );

            request.clearParams();
            request.add("loginStatus", (this.data != null));

            this.sendRequest(request);
        }
    }
}
