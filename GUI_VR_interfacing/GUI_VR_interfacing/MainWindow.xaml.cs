using Newtonsoft.Json;
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
            SessionComboBox.ItemsSource = client.sessions;
            SessionComboBox.DisplayMemberPath = "user";
            DG_sessions.ItemsSource = client.sessions;
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
                control.DataContext = this;
                control.start(client);
                control.Show();
                Close();
            }
            TextBlock.Text = "Please select a Session first!";
        }

        private void SelectSessionHandler(object sender, SelectionChangedEventArgs e)
        {
            string d = JToken.Parse(JsonConvert.SerializeObject(SessionComboBox.SelectedItem))["id"].ToString();
            TextBlock.Text = "ID : " + d;
        }

        private void refresh()
        {
            SessionComboBox.SelectedValue = null;
            client.askForSessionList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}
