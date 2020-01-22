using RHLib.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RHLib.helper
{

    public static class TCPHelper
    {

        // attributes
        public static Encoding encoding = Encoding.UTF8;

        // read
        public static string readText(SslStream stream)
        {

            StreamReader reader = new StreamReader(stream, encoding);
            return reader.ReadLine();
        }

        public static Request read(SslStream stream)
        {

            try
            {

                byte[] length = new byte[4];
                int readBytes = 0;
                
                while(readBytes < 4)
                    readBytes += stream.Read(length, readBytes, 4 - readBytes);

                byte[] bytes = new byte[BitConverter.ToInt32(length, 0)];
                readBytes = 0;

                while (readBytes < BitConverter.ToInt32(length, 0))
                    readBytes += stream.Read(bytes, readBytes, (bytes.Length - readBytes));

                Console.WriteLine("CLIENT: " + encoding.GetString(bytes, 0, readBytes));

                return JsonConvert.DeserializeObject<Request>(encoding.GetString(bytes, 0, readBytes));
            }
            catch (Exception e)
            {

                SSLHelper.printException("TCPHelper::read", e);
                return null;
            }
        }

        // send
        public static void writeText(SslStream stream, string message)
        {

            StreamWriter writer = new StreamWriter(stream, encoding);
            writer.WriteLine(message);
            writer.Flush();
        } 

        public static void write(SslStream stream, Request request)
        {

            try
            {

                byte[] messageBytes = encoding.GetBytes(JsonConvert.SerializeObject(request));
                byte[] lenght = BitConverter.GetBytes(messageBytes.Length);
                byte[] bytes = new byte[messageBytes.Length + 4];

                for (int i = 0; i < lenght.Length; i++)
                    bytes[i] = lenght[i];

                for (int i = 0; i < messageBytes.Length; i++)
                    bytes[i + 4] = messageBytes[i];

                Console.WriteLine("SERVER: " + encoding.GetString(messageBytes));

                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {

                SSLHelper.printException("TCPHelper::write", e);
            }
        }
    }
}
