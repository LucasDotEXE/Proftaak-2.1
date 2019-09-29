using System.Threading;
using System.Windows;

namespace GUI_VR_interfacing
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        Client _client;



        public ControlPanel()
        {
            InitializeComponent();
            
        }

        private void GenbuttonClicked(object sender, RoutedEventArgs e)
        {
            update();
        }

        internal void start(Client client)
        {
            _client = client;
            Thread.Sleep(1000);
            VREnviorment.init(_client);
            update();
        }

        private void valChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VREnviorment.changeTime(_client,(TimeOfDay.Value));
        }
        private void update()
        {
            VREnviorment.getScene(_client);
        }
    }
}
