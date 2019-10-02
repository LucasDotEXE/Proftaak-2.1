using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RHBase.helper
{

    class Config
    {

        // connection
        public const string serverName              = "RHServer";
        public const string host                    = "127.0.0.1";
        public const int port                       = 6969;

        // message presets
        public const string loginPreset             = "L";   // server: L[json(name, password, true/false) client: L[true/false]
        public const string messagePreset           = "M";   // server: M[message]                         client: M[message]
        public const string protocolPreset          = "P";   // server: P[json_protocol]                   client: P[json_protocol]
        public const string requestPreset           = "R";   // server: R[json_id_list]                    client: R[json_clientData_list]

        // paths
        public static string certificatePath        = getBasePath() + @"\RHServer\server\controller\certificate\cert.crt";
        public static string certificateKey         = getBasePath() + @"\RHServer\server\controller\certificate\cert.key";
        public static string serverAccountPath      = getBasePath() + @"\RHServer\server\model\account\Account.txt";

        private static string getBasePath()
        {

            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
