using IPRLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRServer.server.model.client
{
    interface ClientObserver
    {

        void writeRequest(Request request);
    }
}
