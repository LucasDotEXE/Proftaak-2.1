using IPRLib.data;
using IPRLib.helper;
using IPRServer.server.model.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPRServer.server.model.client
{

    class Ästrand
    {

        private Client client;

        public void start(Client client)
        {

            this.client = client;

            new Thread(new ThreadStart(this.test)).Start();
        }

        private void test()
        {

            this.writeTestRequest(120, 10, "WARMING UP", "warmup");

            Thread.Sleep(120000);

            this.writeTestRequest(240, 10, "ÄSTRAND TEST", "ästrand");
            this.buildUpResistance();

            Thread.Sleep(180000);

            this.writeTestRequest(60, 10, "COOLDOWN", "cooldown");

            Thread.Sleep(60000);

            this.writeTestRequest(0, 10, "STOP, THE TEST IS OVER", "stop", true);

            SessionManager.addVO2ToSession(this.client.session);
            SessionManager.save();
        }

        private void buildUpResistance()
        {

            for (int i = 2; i < 9; i++)
            {

                Thread.Sleep(10000);
                this.writeTestRequest(-1, i * 10, "ÄSTRAND TEST", "ästrand");
            }
        }

        private void writeTestRequest(int seconds, int resistance, string message, string stage, bool stop = false)
        {

            Request request = Request.newRequest(Config.testType);
            request.add("seconds", seconds);
            request.add("resistance", resistance);
            request.add("message", message);
            request.add("stage", stage);

            if (stop)
                request.add("start", false);

            this.client.writeRequest(request);
        }
    }
}
