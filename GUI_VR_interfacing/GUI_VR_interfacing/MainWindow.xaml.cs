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
        Client client = new Client();
        string selected = "";
        public MainWindow()
        {
            InitializeComponent();
            refresh();
        }
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SessionComboBox.SelectedItem != null)
            {
                client.createTunnel(selected);
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
            client.AskSessionList();
            
            SessionComboBox.ItemsSource = client.sessions;
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

