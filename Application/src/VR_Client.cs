﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace VR_Client
{
    class Client_Connecting
    {
        /*
                static void Main(string[] args)
                {

                    //client object to build client
                    Client client = new Client();
                    //gets session list
                    List<JObject> sessions = client.getSessionList();

                    //print sessions
                    foreach (JObject session in sessions)
                    {
                        Console.WriteLine(session["id"].ToString());
                    }
                    Console.WriteLine("connecting to 15ce6013-9345-48ff-88aa-46ebbbaa4c0f");
                    client.createTunnel(new
                    {
                        id = "tunnel/create",
                        data = new
                        {
                        session = "4845aabc-bcfa-4b3f-8d84-a954f2634257",
                        key = ""
                        }
                    });

                    int[] terrainHeight = new int[65536];
                    for(int i = 0; i < 65536; i++)
                    {
                        terrainHeight[i] = i % 10;
                    }

                    client.sendJson(Commands.Scene.terrain.add(256, 256, terrainHeight));

                    client.sendJson(Commands.Scene.get());

                    //close all connections
                    client.close()
                        ;
                    //wait for input
                    Console.Read();
                }
            }
            */
    }
    namespace VR_Client
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
                Console.WriteLine($"client connected? = { client.Connected}");
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
                    ReceivedJsonObject = JObject.Parse(receivedJsonString);
                }
                catch
                {
                    goto retry;
                }
                JArray data = (JArray)ReceivedJsonObject["data"];
                List<JObject> sessionList = data.ToObject<List<JObject>>();
                //close all connections
                return sessionList;
            }
            public void createTunnel(dynamic pin)
            {
                send(pin);
                string data = receive();
                JObject Jdata = JObject.Parse(data);
                string SessionID = Jdata["data"]["id"].ToObject<string>();
                Console.WriteLine(Jdata["data"]["status"]);
            }

            public void send(dynamic msg)
            {
                //you need to send package length then package, this is stated in docs
                string json = JsonConvert.SerializeObject(msg);
                sendJson(json);
            }

            public void sendJson(String json)
            {
                byte[] packet = Encoding.UTF8.GetBytes(json);
                byte[] length = BitConverter.GetBytes(packet.Length);
                dStream.Write(length, 0, length.Length);
                dStream.Write(packet, 0, packet.Length);
                Console.WriteLine($"sending : {json}");
                dStream.Flush();
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
}

