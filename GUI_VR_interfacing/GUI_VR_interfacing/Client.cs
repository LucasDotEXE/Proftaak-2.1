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
        private string lastMessage;
        private Queue<string> toBeSend = new Queue<string>();

        public TcpClient client { get; }

        public NetworkStream dStream { get; }
        private string temp = "";

        //setting up the client
        public Client()
        {
            client = new TcpClient(host, port);
            dStream = client.GetStream();
            Console.WriteLine($"client connected? = {client.Connected}");
            new Thread(new ThreadStart(ServerReader)).Start();
            new Thread(new ThreadStart(DataSender)).Start();
        }

        private void DataSender()
        {
            while (true)
            {
                if (toBeSend.Count > 0)
                {
                    string data = toBeSend.Dequeue();
                    Console.WriteLine("toBeSend: " + data);
                    if (data.Contains("scene") || data.Contains("route") && sessionID != "") sendDataTunnel(data);
                    else if(data.Contains("scene") || data.Contains("route")) toBeSend.Enqueue(data);
                    else sendData(data);
                }
            }
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
                    try
                    {
                        byte[] bytesToRead = new byte[messageLength];
                        int bytesRead = dStream.Read(bytesToRead, 0, messageLength);
                        if (bytesRead > 4)
                            data += Encoding.UTF8.GetString(bytesToRead, 0, bytesRead);
                        else
                        {
                            int l = BitConverter.ToInt32(bytesToRead, 0);
                            messageLength = l;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("disconnected!");
                    }
                } while (Encoding.UTF8.GetBytes(data).Length < messageLength);
                //Console.WriteLine(data);
                if (data != "") dataReceived(data);
            }
        }

        internal void sendData(string p)
        {
                byte[] packet = Encoding.UTF8.GetBytes(p);
                byte[] length = BitConverter.GetBytes(packet.Length);
                dStream.Write(length, 0, length.Length);
                dStream.Write(packet, 0, packet.Length);
                Console.WriteLine($"sending : {p}");
            
        }
        private string convertToMessage(string msg)
        {
            var get = JsonConvert.DeserializeObject(msg);
            var prefix = new { id = "tunnel/send", data = new { dest = sessionID, data = get } };
            string d = JsonConvert.SerializeObject(prefix);
            Console.WriteLine(d);
            return d;
        }

        internal void sendDataTunnel(string p)
        {

            string d = convertToMessage(p);
            if (lastMessage != d)
            {
                lastMessage = d;
                byte[] packet = Encoding.UTF8.GetBytes(d);
                byte[] length = BitConverter.GetBytes(packet.Length);
                dStream.Write(length, 0, length.Length);
                dStream.Write(packet, 0, packet.Length);
            }
        }
        public void addToQueue(string toBeAdded)
        {
            toBeSend.Enqueue(toBeAdded);
        }

        public void askForSessionList()
        {
            sessions = new List<dynamic>();
            toBeSend.Enqueue(JsonConvert.SerializeObject(new { id = "session/list" }));
        }

        public void createTunnel(string pin)
        {
            temp = pin;
            string tun = JsonConvert.SerializeObject(new { id = "tunnel/create", data = new { session = pin, key = "" } });
            toBeSend.Enqueue(tun);
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
            JToken dat = null;
            try
            {
                dat = JToken.Parse(rData);
            }
            catch { Console.WriteLine("message was  incorrect Json"); }


            if (dat != null)
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
                        Console.WriteLine(dat);
                        break;
                    case "tunnel/create":
                        if (dat["data"]["status"].ToString() == "ok")
                            sessionID = dat["data"]["id"].ToString();
                        else
                        {
                            Console.WriteLine("retrying in 5 seconds!");
                            Thread.Sleep(5000);
                            createTunnel(temp);
                        }
                        break;
                    default:
                        Console.WriteLine("Whoopa alles is kapot!");
                        break;
                }
        }
    }
}
