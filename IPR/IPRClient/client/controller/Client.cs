using RHClient.client.model;
using RHClient.client.view;
using RHLib.data;
using RHLib.helper;
using Newtonsoft.Json;
using RHLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPRClient.client.vr;

namespace RHClient.client
{

    class Client : Connection
    {

        public StartForm startForm = new StartForm();
        public ÄstrandForm ästrandForm = new ÄstrandForm();

        public BlueTooth blueTooth;

        // startup
        public override void startClient()
        {
            
            this.startConnection(false);
        }

        // bluetooth
        public void startBluetooth(Request request)
        {

            request.type = Config.validateÄstrandType;

            try
            {

                this.blueTooth = new BlueTooth(request);
                this.blueTooth.start().Wait();
            }
            catch (Exception e)
            {

                Program.client.ästrandForm.stopÄstrand(true);

                request.add("started", false);
                request.add("message", SSLHelper.getMessage("Client", e));

                if (e.InnerException != null && e.InnerException.Message.Length == 1)
                    if (e.InnerException.Message == "1")
                        request.add("message", "The bike is already in use or the bike id is incorrect");

                this.writeRequest(request);
            }
        }

        // requests
        public override void receiveRequest(Request request)
        {

            switch (request.type)
            {

                case Config.messageType: VRClientConnection.getInstance().writeRequest(request); break;
                case Config.stopÄstrandType: this.ästrandForm.stopÄstrand(); break;
                case Config.startÄstrandType: this.ästrandForm.startÄstrand(request); break;
                case Config.createSessionType: this.startForm.createdSession(request); break;
            }
        }

        public void writeCreateSessionRequest(int age, int weigth, string name, string gender)
        {

            Request request = Request.newRequest(Config.createSessionType);
            request.add("age", age);
            request.add("name", name);
            request.add("weight", weigth);
            request.add("gender", gender);

            this.writeRequest(request);
        }

        public void writeMeasurementRequest(Measurement measurement)
        {

            Request request = Request.newRequest(Config.measurementType);
            request.add("measurement", JsonConvert.SerializeObject(measurement));

            this.writeRequest(request);
        }

        public void writeStopÄstrandRequest(bool stop)
        {

            Request request = Request.newRequest(Config.stopÄstrandType);
            request.add("stop", stop);

            this.writeRequest(request);
        }
    }
}
