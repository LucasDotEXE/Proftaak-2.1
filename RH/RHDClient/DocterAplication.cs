using RHLib;
using RHLib.data;
using RHLib.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocterAplication
{ 
    class DocterClient : ClientConnection
    {

        public Form1 form;
        public bool isLoggedIn;

        public List<ClientData> clientDatas;
        public ClientData subscribed;
        public string name;

        public override void startClient()
        {

            this.clientDatas = new List<ClientData>();
            base.startConnection(true);
        }

        internal void sendLoginRequest(string userName, string password, bool newAcount)
        {

            Request request = Request.newRequest(Config.loginType);
            request.add("name", userName);
            request.add("password", password);
            request.add("register", newAcount);

            base.writeRequest(request);
        }

        internal void sendClientListRequest()
        {

            base.writeRequest(Request.newRequest(Config.nameType));
        }

        internal void sendFollowRequest(String clientName) 
        {

            this.subscribed = this.getClientData(clientName);

            Request request = Request.newRequest(Config.subscribeType);
            request.add("id", this.subscribed.id);

            base.writeRequest(request);
        }

        public override void receiveRequest(Request request)
        {

            switch(request.type)
            {

                case Config.nameType:        this.createClients(request);                                  break;
                case Config.loginType:       this.login(request);                                          break;
                case Config.messageType:     this.subscribed.messages.Add(request.get("message"));         break;
                case Config.subscribeType:   this.subscribed.setMeasurements(request);                     break;
                case Config.measurementType: this.subscribed.measurements.Add(request.get("measurement")); break;
            }
        }

        private void login(Request request)
        {

            this.isLoggedIn = request.get("successful");
            this.form.loggedIn(request.get("successful"));
        }

        private void createClients(Request request)
        {

            this.clientDatas = new List<ClientData>();

            foreach (string[] client in request.get("names"))
                this.clientDatas.Add(new ClientData(Convert.ToInt32(client[0]), client[1]));

            this.form.RefreshPage();
        }

        public ClientData getClientData(string selectedClientName)
        {

            foreach (ClientData data in this.clientDatas)
                if (data.name.Equals(selectedClientName))
                    return data;

            return null;
        }

        internal void sendMessage(string msg)
        {

            Request request = Request.newRequest(Config.messageType);
            request.add("message", msg);

            base.writeRequest(request);
        }
    }
}
