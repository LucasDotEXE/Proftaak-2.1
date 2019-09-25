using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GUI_VR_interfacing
{
    class Client : DataRetriever
    {
        private readonly string host = "145.48.6.10";
        private readonly int port = 6666;
        public List<dynamic> sessions = new List<dynamic>();
        public string connectedID { get; set; } = "";

        public TcpClient client { get; }

        public NetworkStream dStream { get; }

        //setting up the client
        public Client()
        {
            client = new TcpClient(host, port);
            dStream = client.GetStream();
            Console.WriteLine($"client connected? = {client.Connected}");
            new Thread(new ThreadStart(readingData)).Start();
        }

        private void readingData()
        {
            while (true)
            {
                string data = "";
                int messageLength = 4;
                do
                {
                    byte[] bytesToRead = new byte[messageLength];
                    int bytesRead = dStream.Read(bytesToRead, 0, messageLength);
                    Console.WriteLine("amount of bytes: " + bytesRead);
                    if (bytesRead > 4)
                        data += Encoding.UTF8.GetString(bytesToRead, 0, bytesRead);
                    else
                    {
                        int l = BitConverter.ToInt32(bytesToRead, 0);
                        Console.WriteLine("length: " + l);
                        messageLength = l;
                    }
                } while (Encoding.UTF8.GetBytes(data).Length < messageLength);
                Console.WriteLine(data);
                if (data != "") dataReceived(data);
            }
        }

        public void AskSessionList()
        {
            sessions = new List<dynamic>();
            send(new { id = "session/list" });
        }

        public void createTunnel(string pin)
        {
            dynamic a = new { id = "tunnel/create", data = new { session = pin, key = "" } };
            send(a);
        }

        public void send(dynamic msg)
        {
            //you need to send package length then package, this is stated in docs
            string json = JsonConvert.SerializeObject(msg);
            send(json);
        }

        public void send(String json)
        {
            byte[] packet = Encoding.UTF8.GetBytes(json);
            byte[] length = BitConverter.GetBytes(packet.Length);
            dStream.Write(length, 0, length.Length);
            dStream.Write(packet, 0, packet.Length);
            Console.WriteLine($"sending : {json}");
        }

        /*public string receive()
        {
            string data = "";
            int messageLength = 4;
            do
            {
                byte[] bytesToRead = new byte[messageLength];
                int bytesRead = dStream.Read(bytesToRead, 0, messageLength);
                Console.WriteLine("amount of bytes: " + bytesRead);
                if (bytesRead > 4)
                    data += Encoding.UTF8.GetString(bytesToRead, 0, bytesRead);
                else
                {
                    int l = BitConverter.ToInt32(bytesToRead, 0);
                    Console.WriteLine("length: " + l);
                    messageLength = l;
                }
            } while (Encoding.UTF8.GetBytes(data).Length < messageLength);
            return data;
        }*/

        public void close()
        {
            //closes all connections
            client.Close();
            dStream.Close();
            Console.WriteLine("Client closed!");
        }

        private void convertToSession(JToken Jsessions)
        {
            foreach (JToken a in Jsessions)
            {
                sessions.Add(new { id = a["id"], user = a["clientinfo"]["user"] });
            }

        }

        public void dataReceived(string data)
        {
            JToken rData = JToken.Parse(data);
            if (rData != null)
                switch (rData["id"].ToString())
                {
                    case "session/list":
                        convertToSession(rData["data"]);
                        break;
                    case "tunnel/create":
                        if (rData["data"]["status"].ToString() != "error")
                            connectedID = rData["data"]["id"].ToString();
                        else
                            Console.WriteLine(rData["data"]["status"].ToString());
                        break;
                    case "tunnel/send":
                        //do something
                        break;
                    default:
                        Console.WriteLine("Something went Wrong");
                        break;
                }
        }
    }
}
