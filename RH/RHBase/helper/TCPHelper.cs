using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RHBase.helper
{

    class TCPHelper
    {

        // attributes
        public static Encoding encoding = Encoding.UTF8;

        // read
        public static string readText(SslStream stream)
        {

            StreamReader reader = new StreamReader(stream, encoding);
            return reader.ReadLine();
        }

        public static string read(SslStream stream)
        {

            try
            {

                byte[] length = new byte[1];
                stream.Read(length, 0, 1);

                byte[] bytes = new byte[(int) length[0]];
                int readBytes = 1;

                while (readBytes < bytes.Length)
                    readBytes += stream.Read(bytes, readBytes, (bytes.Length - readBytes));

                return encoding.GetString(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // send
        public static void writeText(SslStream stream, string message)
        {

            StreamWriter writer = new StreamWriter(stream, encoding);
            writer.WriteLine(message);
            writer.Flush();
        } 

        public static void write(SslStream stream, string message)
        {

            try
            {

                byte[] messageBytes = encoding.GetBytes(message);
                byte[] bytes = new byte[messageBytes.Length + 1];

                bytes[0] = (byte) messageBytes.Length;

                for (int i = 0; i < messageBytes.Length; i++)
                    bytes[i + 1] = messageBytes[i];

                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
