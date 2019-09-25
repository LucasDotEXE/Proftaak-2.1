using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace GUI_VR_interfacing
{
    class Client
    {
        private readonly string host = "145.48.6.10";
        private readonly int port = 6666;

        public TcpClient client { get; }

        public NetworkStream dStream { get; }

        //setting up the client
        public Client()
        {
            client = new TcpClient(host, port);
            dStream = client.GetStream();
            Console.WriteLine($"client connected? = {client.Connected}");
        }

        public List<JObject> getSessionList()
        {
            JObject ReceivedJsonObject;
            String receivedJsonString;
        retry:
            //sends data
            send(new { id = "session/list" });
            // calls receive method to get server response
            receivedJsonString = receive();
            //create json object from the message 
            try
            {
                Console.WriteLine(receivedJsonString);
                ReceivedJsonObject = JObject.Parse(receivedJsonString);
            }
            catch
            {
                goto retry;
            }

            JArray data = (JArray)ReceivedJsonObject["data"];
            List<JObject> sessionList = data.ToObject<List<JObject>>();
            return sessionList;
        }

        public void createTunnel(string pin)
        {
            dynamic a = new { id = "tunnel/create", data = new { session = pin, key = "" } };
            send(a);
            string resp = receive();
            Console.WriteLine(resp);
            JObject Jdata = JObject.Parse(resp);
            string sessionID = Jdata["data"]["id"].ToString();
            Console.WriteLine(Jdata["data"]["status"]);
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
            return data.Trim();
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
