using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace GUI_VR_interfacing
{
    class Client : DataReceived
    {
        private readonly string host = "145.48.6.10";
        private readonly int port = 6666;
        public ObservableCollection<dynamic> sessions { get; set; } = new ObservableCollection<dynamic>();
        public string sessionID = "";
        private string lastMessage;
        private Queue<string> toBeSend = new Queue<string>();
        public Dictionary<string, string> nodeDict = new Dictionary<string, string>();

        public TcpClient client { get; }

        public NetworkStream dStream { get; }
        public ObservableCollection<dynamic> nodes = new ObservableCollection<dynamic>();
        public bool finished = false;

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
                    Console.WriteLine(data);
                    if (data.Contains("scene") || data.Contains("route") && sessionID != "") SendDataTunnel(data);
                    else if (data.Contains("scene") || data.Contains("route")) toBeSend.Enqueue(data);
                    else SendData(data);
                    dStream.Flush();
                }
            }
        }

        private void ServerReader()
        {
            while (true)
            {
                string data = "";
                int messageLength = 4;
                do
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
                } while (Encoding.UTF8.GetBytes(data).Length < messageLength);
                dStream.Flush();
                if (data != "") HandlePacket(data);
                Thread.Sleep(1);
            }
        }

        internal void SendData(string p)
        {
            byte[] packet = Encoding.UTF8.GetBytes(p);
            byte[] length = BitConverter.GetBytes(packet.Length);
            dStream.Write(length, 0, length.Length);
            dStream.Write(packet, 0, packet.Length);
        }
        private string ConvertToMessage(string msg)
        {
            var get = JsonConvert.DeserializeObject(msg);
            var prefix = new { id = "tunnel/send", data = new { dest = sessionID, data = get } };
            string d = JsonConvert.SerializeObject(prefix);
            return d;
        }

        internal void SendDataTunnel(string p)
        {
            string d = ConvertToMessage(p);
            Console.WriteLine(d);
            if (lastMessage != d)
            {
                lastMessage = d;
                byte[] packet = Encoding.UTF8.GetBytes(d);
                byte[] length = BitConverter.GetBytes(packet.Length);
                dStream.Write(length, 0, length.Length);
                dStream.Write(packet, 0, packet.Length);
            }

        }
        public void AddToQueue(string toBeAdded)
        {
            toBeSend.Enqueue(toBeAdded);
        }

        public void AskForSessionList()
        {
            sessions.Clear();
            toBeSend.Enqueue(JsonConvert.SerializeObject(new { id = "session/list" }));
        }

        public void CreateTunnel(string pin)
        {
            string tun = JsonConvert.SerializeObject(new { id = "tunnel/create", data = new { session = pin, key = "" } });
            toBeSend.Enqueue(tun);
        }

        public void Close()
        {
            //closes all connections
            client.Close();
            dStream.Close();
        }

        public void HandlePacket(string rData)
        {
            JToken dat = null;
            try
            {
                dat = JToken.Parse(rData);
            }
            catch { Console.WriteLine("message was  incorrect Json"); }
            Console.WriteLine("Got data "  + dat);
            if (dat != null)
                switch (dat["id"].ToString())
                {
                    case "session/list":
                        foreach (JToken o in dat["data"])
                        {
                            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                            {
                                sessions.Add(new { id = o["id"], user = o["clientinfo"]["user"] });
                            });
                        }
                        break;
                    case "tunnel/send":
                      //  Console.WriteLine(dat);
                        if (dat["data"]["data"]["id"].ToString() == "scene/get")
                            foreach (JToken o in dat["data"]["data"]["data"]["children"])
                            {
                                App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                                {
                                    if (!nodeDict.ContainsKey(o["name"].ToString()))
                                    {
                                        nodes.Add(new { name = o["name"], uuid = o["uuid"] });
                                        nodeDict.Add(o["name"].ToString(), o["uuid"].ToString());
                                    }
                                });
                            }
                        if (dat["data"]["data"]["id"].ToString() == "scene/find")
                        {
                            Console.WriteLine(dat);
                        }
                        if (dat["data"]["data"]["id"].ToString() == "route/add")
                        {
                            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                            {
                                nodes.Add(new { name = "Route", uuid = dat["data"]["data"]["data"]["uuid"].ToString() });
                                nodeDict.Add("Route", dat["data"]["data"]["data"]["uuid"].ToString());

                                finished = true;

                                // Console.WriteLine(dat);
                            });
                        }
                            break;
                    case "tunnel/create":
                        if (dat["data"]["status"].ToString() == "ok")
                            sessionID = dat["data"]["id"].ToString();
                        break;
                    default:
                        Console.WriteLine("Whoopa alles is kapot!");
                        break;
                }
        }

    }
}
