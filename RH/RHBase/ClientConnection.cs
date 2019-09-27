using RHBase.helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace RHBase
{
    abstract class ClientConnection
    {

        private Hashtable certificateErrors = new Hashtable();

        protected void startConnection()
        {


        }

        private bool validateCertificate(SslPolicyErrors errors)
        {

            return (errors == SslPolicyErrors.None);
        }

        // messaging
        protected void sendMessage(string message)
        {

            //this.socket.Send(Encoding.ASCII.GetBytes(message));
        }

        private void getMessage()
        {

            try
            {

                while (true)
                {

                    this.receiveMessage(Encoding.ASCII.GetString(bytes, 0, this.socket.Receive(bytes)));

                    Thread.Sleep(10);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Message Receiver crasched : {0}", e.ToString());
            }
        }

        // overrides
        public abstract void receiveMessage(string message);
    }
}
