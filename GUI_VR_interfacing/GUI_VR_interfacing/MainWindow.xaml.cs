using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace GUI_VR_interfacing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Client client = new Client();
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
            Data d = (Data)SessionComboBox.SelectedItem;
            TextBlock.Text = "User : " + d.user;
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
            DG_sessions.ItemsSource = sessions;
        }

    }
}
}
