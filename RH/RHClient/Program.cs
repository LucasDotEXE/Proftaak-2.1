using RHClient.client;
using RHClient.client.model;
using RHLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHClient
{
    static class Program
    {

        public static Client client;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            client = new Client();
            client.startClient();

            Application.Run(client.startForm);
        }
    }
}
