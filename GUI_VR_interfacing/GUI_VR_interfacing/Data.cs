using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_VR_interfacing
{
    class Data
    {
        public string id { get; }
        public string user { get; }

        public Data(string id, string machine)
        {
            this.id = id;
            this.user = machine;
        }

    }
}
