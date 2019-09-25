using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using RHCClient.helpers;
using System.Threading;

namespace RHCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SocketClient
    {
        private byte[] bytes = new byte[1024];
        private IPHostEntry hostIP;
        private IPAddress ipAddress;
        private IPEndPoint remoteEP;
        private Socket sendsocket;
        private string msg = "";
        private bool running = true;

        public void StartClient()
        {
            try
            {  
                hostIP = Dns.GetHostEntry(Config.host);
                ipAddress = hostIP.AddressList[0];
                remoteEP = new IPEndPoint(ipAddress, Config.port); 
                sendsocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                new Thread(receiveMessage).Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void sendMessage(string message)
        {
            sendsocket.Send(Encoding.ASCII.GetBytes(message));
        }


        public void receiveMessage()
        {
            try
            {
                sendsocket.Connect(remoteEP);

                //Console.WriteLine("Socket connected to {0}", sendsocket.RemoteEndPoint.ToString());
                while (running)
                {
                    int bytesSent = sendsocket.Send(Encoding.ASCII.GetBytes(msg));
                    int bytesRec = sendsocket.Receive(bytes);
                    // Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));   
                }
                sendsocket.Shutdown(SocketShutdown.Both);
                sendsocket.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
    }
}
