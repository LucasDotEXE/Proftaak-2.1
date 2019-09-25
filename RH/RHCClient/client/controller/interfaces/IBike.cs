using Avans.TI.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHCClient.client.controller.interfaces
{
    interface IBike
    {

        IApplication observer { get; }

        void startConnection();
        void setResistance(int percentage);
    }
}
