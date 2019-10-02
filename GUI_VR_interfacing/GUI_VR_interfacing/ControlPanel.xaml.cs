using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            ObjList.ItemsSource = _client.nodeInfo;
        }

        private void ObjList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            dynamic selectedItem = ObjList.SelectedItem;
            JToken node = JToken.Parse(JsonConvert.SerializeObject(selectedItem));
            string uuid = node["uuid"].ToString();
            _client.selectedItemUUID = uuid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string val = "";
            _client.nodes.TryGetValue("GroundPlane", out val);
            VREnviorment.addLayer(_client,
                id: val,

                diffuseTexture: "data/NetworkEngine/textures/grass/grass_green_d.jpg",
                normalTexture: "data/NetworkEngine/textures/grass/grass_green_d.jpg",
                minHeight: 0,
                maxHeight: 10,
                fadeDist: 1);
        }
    }
}
