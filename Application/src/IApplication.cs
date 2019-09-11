using Application.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.src
{
    interface IApplication
    {

        void receiveProtocol(Protocol protocol);
    }
}
