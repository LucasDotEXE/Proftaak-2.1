﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace GUI_VR_interfacing
{
    class Client : DataReceived, IDisposable
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
                    if (data.Contains("scene") || data.Contains("route") && sessionID != "") sendDataTunnel(data);
                    else if (data.Contains("scene") || data.Contains("route")) toBeSend.Enqueue(data);
                    else sendData(data);
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
                if (data != "") dataReceived(data);
                Thread.Sleep(1);
            }
        }

        internal void sendData(string p)
        {
            byte[] packet = Encoding.UTF8.GetBytes(p);
            byte[] length = BitConverter.GetBytes(packet.Length);
            dStream.Write(length, 0, length.Length);
            dStream.Write(packet, 0, packet.Length);
        }
        private string convertToMessage(string msg)
        {
            var get = JsonConvert.DeserializeObject(msg);
            var prefix = new { id = "tunnel/send", data = new { dest = sessionID, data = get } };
            string d = JsonConvert.SerializeObject(prefix);
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

        public void close()
        {
            //closes all connections
            client.Close();
            dStream.Close();
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
                            sessions.Add(new { id = o["id"], user = o["clientinfo"]["user"] });
                        }
                        break;
                    case "tunnel/send":
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
