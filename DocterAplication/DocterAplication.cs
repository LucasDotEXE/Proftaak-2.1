using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocterAplication
{ 
    class DocterClient : ClientRecources.ClientServerShared.ClientServerUtil
    {
        internal bool isConnected;

        public List<ClientData> clientData;

        public DocterClient()
        {
            
        }

        internal void sendLoginRequest(string message)
        {
            base.WriteTextMessage("L" + message);
        }
    }
}
