using RHLib.data;
using RHLib.helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RHLib
{

    public abstract class Connection
    {

        private SslStream stream;
        private Thread thread;

        // connection
        protected void startConnection(bool isDocter)
        {

            TcpClient client = new TcpClient(Config.host, Config.port);
            this.stream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(validateCertificate), null);

            try
            {

                this.stream.AuthenticateAsClient(Config.serverName);

                Request request = Request.newRequest();
                request.add("isDocter", isDocter);

                this.writeRequest(request);
            }
            catch (Exception e)
            {

                SSLHelper.printException("ClientConnection::startConnection", e);

                this.stream.Close();
                client.Close();

                return;
            }

            this.thread = new Thread(new ThreadStart(getRequest));
            this.thread.Start();
        }

        private bool validateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate errors: {0}", sslPolicyErrors);

            return false;
        }

        // messaging
        public void writeRequest(Request request)
        {

            TCPHelper.write(this.stream, request);
        }

        private void getRequest()
        {

            try
            {

                while (true)
                {

                    this.receiveRequest(TCPHelper.read(this.stream));

                    Thread.Sleep(10);
                }
            }
            catch (Exception e)
            {

                SSLHelper.printException("ClientConnection::getRequest", e);
                this.thread = null;
            }
        }

        // overrides
        public abstract void startClient();
        public abstract void receiveRequest(Request request);
    }
}
