using Newtonsoft.Json;
using RHLib.data;
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

        public static Encoding encoding = Encoding.UTF8;

        // write
        public static string readText(SslStream stream)
        {

            StreamReader reader = new StreamReader(stream, encoding);
            return reader.ReadLine();
        }

        public static Request read(SslStream stream)
        {

            try
            {

                byte[] size = new byte[1];
                stream.Read(size, 0, 1);

                byte[] length = new byte[size[0]];
                stream.Read(length, 0, size[0]);

                byte[] bytes = new byte[Convert.ToInt32(length)];
                int readBytes = 1;

                while (readBytes < bytes.Length)
                    readBytes += stream.Read(bytes, readBytes, (bytes.Length - readBytes));

                return JsonConvert.DeserializeObject<Request>(encoding.GetString(bytes, 0, bytes.Length));
            }
            catch (Exception e)
            {

                ExceptionHelper.print("TCPHelper::read", e);
                stream.Close();
            }

            return null;
        }

        // write
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
                byte[] length = BitConverter.GetBytes(messageBytes.Length);
                byte[] bytes = new byte[messageBytes.Length + length.Length + 1];

                bytes[0] = (byte)length.Length;

                for (int i = 0; i < length.Length; i++)
                    bytes[i + 1] = length[i];

                for (int i = 0; i < messageBytes.Length; i++)
                    bytes[i + (1 + length.Length)] = messageBytes[i];

                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }
            catch (IOException e)
            {

                ExceptionHelper.print("TCPHelper::write", e);
                stream.Close();
            }
        }
    }
}
