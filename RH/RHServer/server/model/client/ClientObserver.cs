using RHLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHServer.server.model.client
{
    interface ClientObserver
    {

        void sendRequest(Request request);
    }
}
