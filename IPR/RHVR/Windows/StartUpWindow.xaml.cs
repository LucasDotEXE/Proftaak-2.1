using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RHLib;
using RHLib.data;
using RHLib.helper;

namespace GUI_VR_interfacing
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class StartUpWindow : Window
    {
        internal static StartUpWindow suw;
        public ServerConnectionManager scm;
        public StartUpWindow()
        {
            suw = this;
            scm = new ServerConnectionManager();
            scm.startClient();
            InitializeComponent();
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            Request request = Request.newRequest(Config.loginType);
            request.add("name", tb_login.Text);
            request.add("password", Pb.Password);
            request.add("register", NewUserRadioButton.IsChecked);

            scm.writeRequest(request);
        }

       

        public void LogInB()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate
            {
                MainWindow mainw = new MainWindow();
                mainw.Show();
                this.Close();
            }); 
        }
    }
}
