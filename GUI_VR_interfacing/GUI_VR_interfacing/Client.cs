using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GUI_VR_interfacing
{
    class Client : DataReceived
    {
        private readonly string host = "145.48.6.10";
        private readonly int port = 6666;
        public List<dynamic> sessions { get; set; } = new List<dynamic>();
        public string sessionID = "";

        public TcpClient client { get; }

        public NetworkStream dStream { get; }

        //setting up the client
        public Client()
        {
            client = new TcpClient(host, port);
            dStream = client.GetStream();
            Console.WriteLine($"client connected? = {client.Connected}");
            new Thread(new ThreadStart(ServerReader)).Start();
        }

        private void ServerReader()
        {
            bool running = true;
            while (running)
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
                dataReceived(data);
            }
        }

        public void askForSessionList()
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
            byte[] packet = Encoding.UTF8.GetBytes(json);
            byte[] length = BitConverter.GetBytes(packet.Length);
            dStream.Write(length, 0, length.Length);
            dStream.Write(packet, 0, packet.Length);
            Console.WriteLine($"sending : {json}");
        }

        public string receive()
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
        }
        public void close()
        {
            //closes all connections
            client.Close();
            dStream.Close();
            Console.WriteLine("Client closed!");
        }

        public void dataReceived(string rData)
        {
            JToken dat = JToken.Parse(rData);

            switch (dat["id"].ToString())
            {
                case "session/list":
                    foreach (JToken o in dat["data"])
                    {
                        Console.WriteLine(o.ToString());
                        sessions.Add(new { id = o["id"], user = o["clientinfo"]["user"] });
                    }
                    break;
                case "tunnel/send":
                    //do stuff
                    break;
                case "tunnel/create":
                    if (dat["data"]["status"].ToString() == "ok")
                        sessionID = dat["data"]["id"].ToString();
                    else Console.WriteLine("Error, Tunnel can't be created!");
                    break;
                default:
                    Console.WriteLine("Whoopa alles is kapot!");
                    break;
            }
        }
    }
}
