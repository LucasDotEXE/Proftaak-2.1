using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.src.model
{
    class Protocol
    {

        // ToDo - add all the correct fields contained in the bytes!
        private string serviceName;

        public double speed;
        public double heartrate;

        public Protocol(string serviceName, string bytes, string encoding)
        {

            this.serviceName = serviceName;
        }
    }
}
