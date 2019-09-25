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
                client.createTunnel(selected);
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
            client.AskSessionList();
            
            SessionComboBox.ItemsSource = client.sessions;
            SessionComboBox.DisplayMemberPath = "id";
            DG_sessions.ItemsSource = sessions;
        }

    }
}
}
