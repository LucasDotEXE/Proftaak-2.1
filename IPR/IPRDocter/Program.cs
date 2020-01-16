using RHDocter.docter.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHDocter
{
    static class Program
    {

        public static Docter docter;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            docter = new Docter();
            docter.startClient();

            Application.Run(docter.docterForm);
        }
    }
}
