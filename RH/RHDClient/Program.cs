using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocterAplication
{
    static class Program
    {

        public static DocterClient docterClient;

        static void Main()
        {

            docterClient = new DocterClient();
            docterClient.startClient();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
