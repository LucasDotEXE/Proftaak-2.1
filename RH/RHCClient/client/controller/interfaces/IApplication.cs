using RHBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHCClient.client.controller.interfaces
{
    interface IApplication
    {

        void receiveProtocol(Protocol protocol);
    }
}
