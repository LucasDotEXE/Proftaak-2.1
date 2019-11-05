using IPRClient.client;
using IPRClient.client.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPRClient
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
