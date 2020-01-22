using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RHLib.helper
{

    public static class Config
    {

        // types
        public const string VRType              = "VR";

        public const string loginType           = "login";
        public const string messageType         = "message";
        public const string subscribeType       = "subscribe";
        public const string measurementType     = "measurement";
        public const string readSessionType     = "readSession";
        public const string createSessionType   = "createSession";

        public const string stopÄstrandType     = "stopÄstrand";
        public const string startÄstrandType    = "startÄstrand";
        public const string validateÄstrandType = "validateÄstrand"; 

        // connection
        public const string serverName          = "IPRServer";
        public const string host                = "127.0.0.1";
        public const int port                   = 6969;

        public const string VRServerName        = serverName;
        public const string VRhost              = "127.0.0.1";
        public const int VRport                 = 420;

        // login
        public const string name                = "admin";
        public const string pass                = "admin";

        // paths
        public static string certificatePath    = getBasePath() + @"\RHServer\server\controller\certificate\cert.crt";
        public static string certificateKey     = getBasePath() + @"\RHServer\server\controller\certificate\cert.key";
        public static string serverAccountPath  = getBasePath() + @"\RHServer\server\model\session\Sessions.txt";

        private static string getBasePath()
        {

            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
