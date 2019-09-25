using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RHBase
{
    abstract class ClientBase
    {

        private byte[] bytes = new byte[1024];

        private Socket socket;

        private bool running = true;

        protected void startConnection()
        {

            try
            {

                IPHostEntry hostIP = Dns.GetHostEntry(Config.host);
                IPAddress ipAddress = hostIP.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, Config.port);

                this.socket.Connect(remoteEP);

                socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                new Thread(getMessage).Start();
            }
            catch (Exception e)
            {

                Console.WriteLine("Message Connection Builder crashed: {0}" + e.ToString());
            }
        }

        protected void sendMessage(string message)
        {

            this.socket.Send(Encoding.ASCII.GetBytes(message));
        }

        protected void getMessage()
        {

            try
            {

                while (running)
                {

                    this.receiveMessage(Encoding.ASCII.GetString(bytes, 0, this.socket.Receive(bytes)));

                    Thread.Sleep(10);
                }

                this.socket.Shutdown(SocketShutdown.Both);
                this.socket.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Message Receiver crasched : {0}", e.ToString());
            }
        }

        public abstract void receiveMessage(string message);
    }
}
