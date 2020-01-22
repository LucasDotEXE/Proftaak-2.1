using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace GUI_VR_interfacing
{
    /// <summary>
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {

        private Client _client;
        private VRServerConnection connection;
        private List<string> messages;

        public ControlPanel()
        {

            InitializeComponent();

            this.connection = new VRServerConnection(this);
            this.connection.buildVRClientConnectionReceiver();

            messages = new List<string>();
            MessageListBo.Items.Add("Welkom bij deze Controlpaneel");
        }

        // TODO: fix this shit
        public void receiveStart(bool start)
        {

            if (start) VREnviorment.startRoute(_client);
            else VREnviorment.setSpeed(_client,0);
        }

        public void receiveMessage(string message)
        {

            // print message in vr.
            messages.Add(message);

            MessageListBo.Items.Add(message);
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
            VREnviorment.changeTime(_client, (float) (TimeOfDay.Value));
        }
        private void update()
        {
            VREnviorment.getScene(_client);
            ObjList.ItemsSource = _client.nodes;
            ComboBox_Models.ItemsSource = VRstandards.GenerateModelPaths();
            ComboBox_Models.DisplayMemberPath = "Key";
            ComboBox_SelectNode.ItemsSource = _client.nodes;
            ComboBox_SelectNode.DisplayMemberPath = "name";
            ComboBox_SelectNodeParent.ItemsSource = _client.nodes;
            ComboBox_SelectNodeParent.DisplayMemberPath = "name";
        }

        private void ObjList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Button_EditClick(object sender, RoutedEventArgs e)
        {
            dynamic dSelect = ComboBox_SelectNode.SelectedItem;
            JToken selected = JToken.Parse(JsonConvert.SerializeObject(dSelect));
            VREnviorment.findNode(_client, selected["name"].ToString());
        }

        private void Button_DeleteClick(object sender, RoutedEventArgs e)
        {
            dynamic dSelect = ComboBox_SelectNode.SelectedItem;
            JToken selected = JToken.Parse(JsonConvert.SerializeObject(dSelect));
            VREnviorment.deleteNode(_client, selected["uuid"].ToString());
            _client.nodes.Remove(dSelect);
            _client.nodeDict.Remove(selected["name"].ToString());
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VREnviorment.startRoute(_client);  
        }

        private void StopRoute(object sender, RoutedEventArgs e)
        {
            VREnviorment.setSpeed(_client, 0);
        }
    }
}
