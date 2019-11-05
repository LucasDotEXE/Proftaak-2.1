using IPRClient.client.model;
using IPRLib.data;
using IPRLib.helper;
using Newtonsoft.Json;
using RHLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPRClient.client
{

    class Client : Connection
    {

        public StartForm startForm = new StartForm();
        public TestForm testForm = new TestForm();

        // remove after test
        private Test test = new Test();

        public object AsyncContext { get; private set; }

        // startup
        public override void startClient()
        {
            
            this.startConnection(false);
        }

        // test
        public void startTest(Request request)
        {

            try
            {


                BlueTooth blueTooth = new BlueTooth(request.get("idbike"));
                blueTooth.start().Wait();
                //new Thread(new ThreadStart(test.startTest)).Start();

                request.add("hasBike", true);
            }
            catch (Exception e)
            {

                request.add("hasBike", false);
                SSLHelper.printException("Client::startTest", e);
            }

            this.writeRequest(request);
        }

        public void stopTest()
        {

            //Program.blueTooth.stop();
            this.test.running = false;
        }

        // requests
        public override void receiveRequest(Request request)
        {

            switch (request.type)
            {

                case Config.createSessionType: this.startForm.createdSession(request); break;
                case Config.testType:          this.testForm.receiveTest(request);     break;
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
    }
}
