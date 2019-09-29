namespace ClientRecources
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;

    namespace ClientServerShared
    {
        public class ClientServerUtil
        {

            public TcpClient client { get; }
            public NetworkStream dStream { get; }

            public ClientServerUtil()
            {
                //client = new TcpClient();
                //dStream = client.GetStream();
            }

            public string ReadTextMessage()
            {

                StreamReader stream = new StreamReader(dStream, Encoding.ASCII);
                string line = stream.ReadLine();
                return line;
            }

            public void WriteTextMessage(string message)
            {
                var stream = new StreamWriter(dStream, Encoding.ASCII);
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}
