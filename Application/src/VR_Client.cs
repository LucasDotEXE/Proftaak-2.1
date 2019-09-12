using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace VR_Client
{
    class Client_Connecting
    {
        static void Main(string[] args)
        {
            string a = "";
            JObject o;
            //client object to build client
            Client client = new Client();
            //if decoding fails retry
        retry:
            //sends data
            client.send(new { id = "session/list" });
            // calls receive method to get server response
            a = client.receive();
            //create json object from the message 
            try
            {
                o = JObject.Parse(a);
            }
            catch
            {
                goto retry;
            }
            JArray data = (JArray)o["data"];
            List<JObject> sessionList = data.ToObject<List<JObject>>();
            //close all connections
            client.close();
            //print sessions
            foreach (JObject session in sessionList)
            {
                Console.WriteLine(session["id"].ToString());
            }
            //wait for input
            Console.Read();
        }
    }
}
namespace VR_Client
{
    class Client
    {
        private readonly string host = "145.48.6.10";
        private readonly int port = 6666;

        private TcpListener listen;

        public TcpClient client { get; }
        public NetworkStream dStream { get; }
        //setting up the client
        public Client()
        {
            client = new TcpClient(host, port);
            dStream = client.GetStream();
            Console.WriteLine($"client connected? = { client.Connected}");
        }

        public void send(dynamic msg)
        {
            //you need to send package length then package, this is stated in docs
            string json = JsonConvert.SerializeObject(msg);
            byte[] packet = Encoding.UTF8.GetBytes(json);
            byte[] length = BitConverter.GetBytes(packet.Length);
            dStream.Write(length, 0, length.Length);
            dStream.Write(packet, 0, packet.Length);
            dStream.Flush();
        }

        public string receive()
        {
            //you first receive package length then package, this is stated in docs
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = dStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            string length = Encoding.UTF8.GetString(bytesToRead, 0, bytesRead);
            Console.WriteLine(length);
            bytesToRead = new byte[client.ReceiveBufferSize];
            bytesRead = dStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            string data = Encoding.UTF8.GetString(bytesToRead, 0, bytesRead);

            return data;
        }
        public void close()
        {
            //closes all connections
            client.Close();
            dStream.Close();
            Console.WriteLine("Client closed!");
        }
    }
}


