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

    public class VRConnection : Connection
    {

        private static VRConnection instance;
        private VRConnection() { }

        public static VRConnection getInstance()
        {

            if (instance == null)
                instance = new VRConnection();

            return instance;
        }

        public override void startClient()
        {

            this.startConnection(false);
        }

        public override void receiveRequest(Request request)
        {

            // it won't receive!
        }        

        public void writeVRStartCycling(bool start)
        {

            Request request = Request.newRequest(Config.VRType);
            request.add("start", start);
        }
    }
}
