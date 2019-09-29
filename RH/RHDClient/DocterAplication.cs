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

        public ClientData clientData;

        public DocterClient()
        {
            
        }

        internal void sendLoginRequest(string userName, string password, bool newAcount)
        {
            base.sendMessage($"L|{userName}|{password}|{newAcount.ToString()}");
        }

        public override void receiveMessage(string message)
        {
            
        }

        internal bool connect(string userName, string password, bool newAcount)
        {
            base.startConnection();
            base.sendMessage($"L{userName}|{password}|{newAcount}");
            //bool loginSucces = Boolean.Parse(/*gooi hier de responce*/);
            isConnected = true; //moet naar loginSucces
            //return loginSicces;
            return true;
        }

        internal void disconnect()
        {
            base.stopConnection();
            isConnected = false;
        }
    }
}
