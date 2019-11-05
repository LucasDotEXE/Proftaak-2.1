﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IPRLib.helper
{

    public static class Config
    {

        // types
        public const string testType = "testType";
        public const string subscribeType = "subscribe";
        public const string measurementType = "measurement";
        public const string readSessionType = "readSession";
        public const string createSessionType = "createSession";

        // connection
        public const string serverName          = "IPRServer";
        public const string host                = "127.0.0.1";
        public const bool isBike                = false;
        public const int port                   = 6969;

        // paths
        public static string certificatePath    = getBasePath() + @"\IPRServer\server\controller\certificate\cert.crt";
        public static string certificateKey     = getBasePath() + @"\IPRServer\server\controller\certificate\cert.key";
        public static string serverAccountPath  = getBasePath() + @"\IPRServer\server\model\session\Sessions.txt";

        private static string getBasePath()
        {

            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
