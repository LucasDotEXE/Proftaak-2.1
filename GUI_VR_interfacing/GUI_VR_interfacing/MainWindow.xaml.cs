﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
                string d = JToken.Parse(JsonConvert.SerializeObject(SessionComboBox.SelectedItem))["id"].ToString();
                client.createTunnel(d);
                Console.WriteLine("Connected!");
                ControlPanel control = new ControlPanel();
                control.Show();
                this.Close();
            }
            TextBlock.Text = "Please select a Session first!";
        }

        private void SelectSessionHandler(object sender, SelectionChangedEventArgs e)
        {
            string d = JToken.Parse(JsonConvert.SerializeObject(SessionComboBox.SelectedItem))["user"].ToString();
            TextBlock.Text = "User : " + d;
        }

        private void refresh()
        {
            client.askForSessionList();

            SessionComboBox.ItemsSource = client.sessions;
            SessionComboBox.DisplayMemberPath = "id";
            DG_sessions.ItemsSource = client.sessions;
        }


        private void BRefresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}