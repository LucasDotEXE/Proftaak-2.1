using RHBase.helper;
using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace RHBase
{
    abstract class ClientConnection
    {

        private SslStream stream;
        private Thread thread;

        // connection
        protected void startConnection()
        {

            TcpClient client = new TcpClient(Config.host, Config.port);
            this.stream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(validateCertificate), null);

            try
            {

<<<<<<< HEAD
                this.stream.AuthenticateAsClient(Config.serverName);

                TCPHelper.write(this.stream, "ok");
=======
                this.stream.AuthenticateAsClient(Config.serverName, null, false);
>>>>>>> sslstream
            }
            catch (Exception e)
            {

                Console.WriteLine("Couldn't authenticate: {0}", e.StackTrace);

                if (e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);

                client.Close();
                return;
            }

            this.thread = new Thread(new ThreadStart(getMessage));
            this.thread.Start();
        }

        private bool validateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate errors: {0}", sslPolicyErrors);

            return true;
        }

        // messaging
        protected void sendMessage(string message)
        {

            TCPHelper.write(this.stream, message);
        }

        private void getMessage()
        {

            try
            {

                while (true)
                {

                    this.receiveMessage(TCPHelper.read(this.stream));

                    Thread.Sleep(10);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Message Receiver crasched : {0}", e.ToString());
                this.thread = null;
            }
        }

        // overrides
        public abstract void startClient();
        public abstract void receiveMessage(string message);
    }
}
