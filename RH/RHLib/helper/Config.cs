using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RHLib.helper
{

    public static class Config
    {

        // connection
        public const string serverName          = "RHServer";
        public const string host                = "127.0.0.1";
        public const int port                   = 6969;

        // message presets
        public const string loginType           = "login";       
        public const string messageType         = "message";     
        public const string nameType            = "name";        
        public const string subscribeType       = "subscribe";   
        public const string measurementType     = "measurement"; 

        // paths
        public static string certificatePath    = getBasePath() + @"\RHServer\server\controller\certificate\cert.crt";
        public static string certificateKey     = getBasePath() + @"\RHServer\server\controller\certificate\cert.key";
        public static string serverAccountPath  = getBasePath() + @"\RHServer\server\model\account\Account.txt";

        private static string getBasePath()
        {

            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
