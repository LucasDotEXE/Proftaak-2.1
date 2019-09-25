using Avans.TI.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.src.model
{
    interface IBike
    {

        observing.Observer<Protocol> observer { get; }

        void startConnection();
    }
}
