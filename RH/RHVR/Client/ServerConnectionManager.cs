using RHLib;
using RHLib.data;
using RHLib.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_VR_interfacing
{
    public class ServerConnectionManager : ClientConnection
    {
        List<string> messages = new List<string>();
        public ServerConnectionManager()
        {

        }



        public override void receiveRequest(Request request)
        {
            switch (request.type)
            {
                case Config.loginType: this.login(request.get("successful")); break;
                case Config.messageType: this.messages.Add(request.get("message")); break;                           
            }
        }

        public void login(bool loggedIn)
        {
            if (loggedIn)
            {
                StartUpWindow.suw.LogInB();
              
            }
            
        }



        public void writeRequest(Request request)
        {
            base.writeRequest(request);
        }


        public override void startClient()
        {
            this.startConnection(false);
        }
    }
}
