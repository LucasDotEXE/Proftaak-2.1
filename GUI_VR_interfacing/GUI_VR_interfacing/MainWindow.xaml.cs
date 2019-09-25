using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace GUI_VR_interfacing
{
   
    public partial class MainWindow : Window
    {
        string selected = "";
        private static Client client = new Client();

        internal static Client Client { get => client; }

        public MainWindow()
        {
            InitializeComponent();
            refresh();
        }
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SessionComboBox.SelectedItem != null)
            {
                Data d = (Data)SessionComboBox.SelectedItem;
                client.createTunnel(d.id);
                Console.WriteLine("Connected!");
            }
            TextBlock.Text = "Please select a Session first!";
        }

        private void SelectSessionHandler(object sender, SelectionChangedEventArgs e)
        {
            selected = JToken.Parse(JsonConvert.SerializeObject(SessionComboBox.SelectedItem))["id"].ToString();
            TextBlock.Text = JToken.Parse(JsonConvert.SerializeObject(SessionComboBox.SelectedItem))["user"].ToString();
        }

        private void refresh()
        {
            List<JObject> l = client.getSessionList();
            List<Data> sessions = new List<Data>();
            foreach (JObject o in l)
            {
                sessions.Add(new Data(o["id"].ToString(), o["clientinfo"]["user"].ToString()));
            }
            SessionComboBox.ItemsSource = sessions;
            SessionComboBox.DisplayMemberPath = "id";
            DG_sessions.ItemsSource = client.sessions;
            DG_sessions.DisplayMemberPath = "id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}

