using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHCClient.helpers
{
    class Config
    {

        // connection
        public const string host = "127.0.0.1";
        public const int port = 6969;

        // paths
        public const string jsonPath = "Accounts.txt";

        // message presets
        public const string loginPreset = "L";   // server: L[name]:[password]:[true/false]    client: L[true/false]
        public const string messagePreset = "M";   // server: M[message]                         client: M[message]
        public const string requestPreset = "R";   // server: R[json_id_list]                    client: R[json_data_list]
    }
}
