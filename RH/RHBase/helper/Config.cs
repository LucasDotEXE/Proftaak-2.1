using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RHBase.helper
{

    class Config
    {

        // connection
        public const string host                    = "127.0.0.1";
        public const int port                       = 6969;

        // message presets
        public const string loginPreset             = "L";   // server: L[name]|[password]|[true/false]    client: L[true/false]
        public const string messagePreset           = "M";   // server: M[message]                         client: M[message]
        public const string protocolPreset          = "P";   // server: P[json_protocol]                   client: P[json_protocol]
        public const string requestPreset           = "R";   // server: R[json_id_list]                    client: R[json_clientData_list]

        // paths
        public static string basePath               = getBasePath();
        public static string serverCertificatePath  = basePath + @"\RHServer\server\controller\RHCertificate.cer";
        public static string serverAccountPath      = basePath + @"\RHServer\server\model\json\Account.txt";

        private static string getBasePath()
        {

            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
