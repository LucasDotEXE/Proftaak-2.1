using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocterAplication
{ 
    class DocterClient : RHBase.ClientConnection
    {
        internal bool isConnected;

        public List<ClientData> clientData;

        public DocterClient()
        {
            
        }

        internal void sendLoginRequest(string message)
        {
            base.sendMessage("L" + message);
        }

        public override void receiveMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
