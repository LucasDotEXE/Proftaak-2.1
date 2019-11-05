using IPRLib.data;
using IPRLib.helper;
using Newtonsoft.Json;
using RHLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRDocter.docter.controller
{

    class Docter : Connection
    {

        public DocterForm docterForm = new DocterForm();
        public Session subscribed = new Session();

        // startup
        public override void startClient()
        {

            this.startConnection(true);

            this.writeReadSessionRequest();
        }

        // methods
        private void receivedSession(Request request)
        {

            this.subscribed = JsonConvert.DeserializeObject<Session>(request.get("session"));
            this.docterForm.buildHistory();
            this.docterForm.buildChart();
        }

        private void receivedMeasurement(Request request)
        {

            this.subscribed.measurements.Add(JsonConvert.DeserializeObject<Measurement>(request.get("measurement")));
            this.docterForm.buildChart();
        }

        // requests
        public override void receiveRequest(Request request)
        {
            
            switch(request.type)
            {

                case Config.readSessionType: this.docterForm.setSessions(request); break;
                case Config.measurementType: this.receivedMeasurement(request); break;
                case Config.subscribeType:   this.receivedSession(request); break;
            }
        }

        public void writeSubscribeRequest(int id)
        {

            Request request = Request.newRequest(Config.subscribeType);
            request.add("id", id);

            this.writeRequest(request);
        }

        public void writeTestRequest(string idBike)
        {

            Request request = Request.newRequest(Config.testType);
            request.add("idbike", idBike);
            request.add("start", true);

            this.writeRequest(request);
        }

        public void writeReadSessionRequest()
        {

            this.writeRequest(Request.newRequest(Config.readSessionType));
        }
    }
}
