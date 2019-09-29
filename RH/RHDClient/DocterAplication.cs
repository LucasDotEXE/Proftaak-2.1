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
            clientData = new List<ClientData>();
        }

        internal void sendLoginRequest(string userName, string password, bool newAcount)
        {
            base.sendMessage($"L{userName}|{password}|{newAcount.ToString()}");
        }

        internal void sendClientListRequest()
        {
            base.sendMessage($"RClientList");
        }

        internal void sendFollowRequest(String client, bool doFollow) 
        {
            base.sendMessage($"F{client}|{doFollow.ToString()}");
        }

        public override void receiveMessage(string message)
        {
            throw new NotImplementedException();
        }

        //temp message reciever has to be overridden
        public T receiveMessage<T>(string message)
        {
            throw new NotImplementedException();
        }

        internal bool connect(string userName, string password, bool newAcount)
        {
            base.startConnection();
            sendLoginRequest(userName, password, newAcount);
            //bool loginSucces = Boolean.Parse(recieveMessage("loginResponce"));
            isConnected = true; //moet naar loginSucces
            //return loginSicces;
            return true;
        }

        internal void disconnect()
        {
            base.stopConnection();
            isConnected = false;
        }

        internal void updateClientData()
        {
            sendClientListRequest();
            foreach (String client in receiveMessage<List<String>>("loginResponce"))
            {
                if (!clientDataContainsName(client))
                {
                    clientData.Add(new ClientData(client));
                }
            }
        }

        internal bool clientDataContainsName(string name)
        {
            foreach (ClientData data in clientData)
            {
                if (data.name.Equals(name)) return true;
            }
            return false;
        }

        internal void subscribe(string client)
        {
            sendFollowRequest(client, true);
        }

        internal void unSubscribe(string client)
        {
            sendFollowRequest(client, false);
        }
    }
}
