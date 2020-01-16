using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRClient.client.vr
{
    class VRManager
    {

        public void startVR()
        {

        }

        public void startCycling()
        {

        }

        public void recieveMessage(String message)
        {

        }

        public void stopCycling()
        {

        }






        private static VRManager instance;
        private VRManager() { }

        public static VRManager getInstance()
        {

            if (instance == null)
                instance = new VRManager();

            return instance;
        }
    }
}
