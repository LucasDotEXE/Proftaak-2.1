using IPRLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPRClient.client.model
{

    class Test
    {

        public bool running = true;

        public void startTest()
        {

            do
            {

                Measurement measurement = MeasurementBuilder.build(
                    new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x19, 0x03, 0x3A, 0x58, 0x0E, 0x85, 0x60, 0x33, 0x46 },
                    "test"
                );

                Program.client.writeMeasurementRequest(measurement);
                Program.client.testForm.setValues(measurement);

                Thread.Sleep(1000);
            } while (this.running);
        }
    }
}
