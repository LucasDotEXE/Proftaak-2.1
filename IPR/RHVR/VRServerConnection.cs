using RHLib.data;
using RHLib.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUI_VR_interfacing
{

    abstract class VRServerConnection
    {

        private X509Certificate2 certificate;

        public void buildVRClientConnectionReceiver()
        {

            try
            {

                this.certificate = new X509Certificate2(Config.certificatePath, Config.certificateKey);

                new Thread(new ThreadStart(this.catchVRClientConnection)).Start();
            }
            catch (Exception e)
            {

                SSLHelper.printException("Server::startServer", e);
            }

            Request request = Request.newRequest("");
            request.get("start");
        }

        private void catchVRClientConnection()
        {

            try
            {

                IPAddress ip;

                if (!IPAddress.TryParse(Config.VRhost, out ip))
                    throw new Exception();

                TcpListener listener = new TcpListener(ip, Config.port);
                listener.Start();

                TcpClient client = listener.AcceptTcpClient();
                SslStream stream = new SslStream(client.GetStream(), false);

                try
                {

                    stream.AuthenticateAsServer(this.certificate, false, SslProtocols.Tls, true);

                    SSLHelper.DisplaySecurityLevel(stream);
                    SSLHelper.DisplaySecurityServices(stream);
                    SSLHelper.DisplayCertificateInformation(stream);
                    SSLHelper.DisplayStreamProperties(stream);

                    stream.ReadTimeout = 3600000;
                    stream.WriteTimeout = 3600000;

                    TCPHelper.read(stream); // for initialising

                    while (true)
                    {

                        this.receiveRequest(TCPHelper.read(stream));

                        Thread.Sleep(10);
                    }
                }
                catch (Exception e)
                {

                    SSLHelper.printException("VRServerConnection::catchVRClientConnection", e);
                }
                finally
                {

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {

                SSLHelper.printException("VRServerConnection::catchVRClientConnection", e);
            }
        }

        protected abstract void receiveRequest(Request request);
    }
}
