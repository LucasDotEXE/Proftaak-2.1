using RHLib;
using RHLib.data;
using RHLib.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPRClient.client.vr
{ 

    public class VRClientConnection : Connection
    {

        private static VRClientConnection instance;
        private VRClientConnection() { }

        public static VRClientConnection getInstance()
        {

            if (instance == null)
                instance = new VRClientConnection();

            return instance;
        }

        public override void startClient()
        {

            this.startConnection(false, Config.VRhost, Config.VRport, Config.serverName);
        }

        public override void receiveRequest(Request request)
        {

            // it won't receive!
        }        

        public void writeVRStartCycling(bool start)
        {

            Request request = Request.newRequest(Config.VRType);
            request.add("start", start);

            this.writeRequest(request);
        }
    }
}
