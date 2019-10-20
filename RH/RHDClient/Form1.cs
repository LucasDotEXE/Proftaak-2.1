using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace DocterAplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PaswordBox.PasswordChar = '*';

        }



        private void Login_Click(object sender, EventArgs e)
        {
            if (Program.docterClient.isConnected)
            {
                Program.docterClient.disconnect();
                LoggedInStatus.Text = "Not Logged In";
                Login.Text = "Login";


            }
            else
            {
                String userName = nameBox.Text;
                String pasword = PaswordBox.Text;
                bool register = registerCheck.Checked;

                if (Program.docterClient.connect(userName, pasword, register)) //the true has to be the responce from the server
                {
                    LoggedInStatus.Text = $"Logged in as: {userName}";
                    Login.Text = "Logout";
                }
                else
                {
                    StatusStrip.Text = "Not Logged In";
                }
            }



        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshPage();
            FillTest();
        }

        private void FillTest()
        {
            for (int i = 0; i < 100; i++)
            {
                ClientData data = new ClientData($"Client {i + 1}");
                data.addBikePowerMeasurement(new BikePowerMeasurement(100, 20));
                for (int y = 0; y < 100; y++)
                {
                    data.addHeartRateMeasurement(new HeartRateMeasurement(95, 34));
                    data.addHeartRateMeasurement(new HeartRateMeasurement(105, 47));
                    data.addHeartRateMeasurement(new HeartRateMeasurement(80, 36));
                    data.addHeartRateMeasurement(new HeartRateMeasurement(84, 28));
                    data.addHeartRateMeasurement(new HeartRateMeasurement(91, 37));
                    data.addHeartRateMeasurement(new HeartRateMeasurement(150, 47));
                    data.addBikePowerMeasurement(new BikePowerMeasurement(30, 30));
                    data.addBikePowerMeasurement(new BikePowerMeasurement(26, 56));
                    data.addBikePowerMeasurement(new BikePowerMeasurement(42, 98));
                    data.addBikePowerMeasurement(new BikePowerMeasurement(63, 161));
                    data.addBikePowerMeasurement(new BikePowerMeasurement(52, 213));
                    data.addBikePowerMeasurement(new BikePowerMeasurement(43, 256));
                    data.addBikeSpeedMeasurement(new BikeSpeedMeasurement(10, 1));
                    data.addBikeSpeedMeasurement(new BikeSpeedMeasurement(20, 3));
                    data.addBikeSpeedMeasurement(new BikeSpeedMeasurement(25, 5));
                    data.addBikeSpeedMeasurement(new BikeSpeedMeasurement(35, 8));
                    data.addBikeSpeedMeasurement(new BikeSpeedMeasurement(40, 12));
                    data.addBikeSpeedMeasurement(new BikeSpeedMeasurement(100, 22));
                }
                Program.docterClient.clientData.Add(data);
                UserList.Nodes.Add($"Client {i + 1}");
            }
        }

        private void RefreshPage()
        {
            Program.docterClient.updateClientData();
            UserList.Nodes.Clear();
            foreach (ClientData data in Program.docterClient.clientData)
            {
                UserList.Nodes.Add(data.name);
            }

        }


        private void UserList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String updatedClient = UserList.Nodes[e.Index].ToString();
            if (e.NewValue.ToString().Equals("Checked"))
            {
                Program.docterClient.subscribe(updatedClient);
            }
            else
            {
                Program.docterClient.unSubscribe(updatedClient);
            }
        }

        private void NodeClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    ClientSelected.Text = $"Selected Client: {UserList.SelectedNode.Text}";
                }
                catch (Exception)
                {
                    return;
                }

                rebuildCharts();
                rebuildChatBox();
                rebuildHistory();
                rebuildResistance();
            }));
        }

        private void rebuildResistance()
        {
            ClientData data = Program.docterClient.getClientData(UserList.SelectedNode.Text);
            resistance.Value = data.resistance;
            ResistanceLabel.Text = $"Resistance: {resistance.Value}";

        }

        private void rebuildHistory()
        {
            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    _ = UserList.SelectedNode.Text;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return;
                }
                String selectedClientName = UserList.SelectedNode.Text;
                ClientData data = Program.docterClient.getClientData(selectedClientName);

                for (int i = 0; i < data.HeartRateMeasurements.Count; i++)
                {
                    BikePowerMeasurement bikePowMes = data.BikePowerMeasurements[i];
                    BikeSpeedMeasurement bikeSpedMes = data.BikeSpeedMeasurements[i];
                    HeartRateMeasurement heartMes = data.HeartRateMeasurements[i];

                    this.dataGridView1.Rows.Insert(i, heartMes.Bpm, heartMes.ExpandedEnergy, bikeSpedMes.Speed, bikeSpedMes.Distance, bikePowMes.CurrentPower, bikePowMes.AcumulatedPower);
                }


            }));
        }

        public void rebuildCharts()
        {
            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    _ = UserList.SelectedNode.Text;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return;
                }

                String selectedClientName = UserList.SelectedNode.Text;
                ClientData data = Program.docterClient.getClientData(selectedClientName);
                mainChart.Series["BPM"].Points.Clear();
                mainChart.Series["Energy"].Points.Clear();
                mainChart.Series["Speed"].Points.Clear();
                mainChart.Series["Distance"].Points.Clear();
                mainChart.Series["Current Power"].Points.Clear();
                mainChart.Series["Acumulated Power"].Points.Clear();



                HeartRateMeasurement[] heartRateMeasurements = data.HeartRateMeasurements.ToArray();
                BikeSpeedMeasurement[] bikeSpeedMeasurements = data.BikeSpeedMeasurements.ToArray();
                BikePowerMeasurement[] bikePowerMeasurements = data.BikePowerMeasurements.ToArray();
                int amountToDisplay = 60;
                for (int i = 0; i < amountToDisplay; i++)
                {
                    if (AcumPowerCheck.Checked && i + bikePowerMeasurements.Length - amountToDisplay >= 0)
                    {
                        int index = i + bikePowerMeasurements.Length - amountToDisplay;
                        mainChart.Series["Acumulated Power"].Points.AddXY(amountToDisplay - i, bikePowerMeasurements[index].AcumulatedPower);
                    }
                    if (CurrentPowerCheck.Checked && i + bikePowerMeasurements.Length - amountToDisplay >= 0)
                    {
                        int index = i + bikePowerMeasurements.Length - amountToDisplay;
                        mainChart.Series["Current Power"].Points.AddXY(amountToDisplay - i, bikePowerMeasurements[index].CurrentPower);
                    }
                    if (DistanceCheck.Checked && i + bikeSpeedMeasurements.Length - amountToDisplay >= 0)
                    {
                        int index = i + bikeSpeedMeasurements.Length - amountToDisplay;
                        mainChart.Series["Distance"].Points.AddXY(amountToDisplay - i, bikeSpeedMeasurements[index].Distance);
                    }
                    if (SpeedCheck.Checked && i + bikeSpeedMeasurements.Length - amountToDisplay >= 0)
                    {
                        int index = i + bikeSpeedMeasurements.Length - amountToDisplay;
                        mainChart.Series["Speed"].Points.AddXY(amountToDisplay - i, bikeSpeedMeasurements[index].Speed);
                    }
                    if (EnergyCheck.Checked && i + heartRateMeasurements.Length - amountToDisplay >= 0)
                    {
                        int index = i + heartRateMeasurements.Length - amountToDisplay;
                        mainChart.Series["Energy"].Points.AddXY(amountToDisplay - i, heartRateMeasurements[index].ExpandedEnergy);
                    }
                    if (BPMCheck.Checked && i + heartRateMeasurements.Length - amountToDisplay >= 0)
                    {
                        int index = i + heartRateMeasurements.Length - amountToDisplay;
                        mainChart.Series["BPM"].Points.AddXY(amountToDisplay - i, heartRateMeasurements[index].Bpm);

                    }
                }
            }));

        }

        private void BPMchartCheck_CheckedChanged(object sender, EventArgs e)
        {
            rebuildCharts();
        }

        private void BSpeedchartCheck_CheckedChanged(object sender, EventArgs e)
        {
            rebuildCharts();
        }

        private void BPowerchartCheck_CheckedChanged(object sender, EventArgs e)
        {
            rebuildCharts();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            String msg = messageBox.Text;
            Program.docterClient.sendMessage(UserList.SelectedNode.Text, msg);
            rebuildChatBox();
        }

        private void rebuildChatBox()
        {
            chatBox.Items.Clear();
            foreach (String message in Program.docterClient.getClientData(UserList.SelectedNode.Text).messages)
            {
                chatBox.Items.Add(message);
            }
        }

        private void SendAllButton_Click(object sender, EventArgs e)
        {
            String msg = $"SENDALL:{messageBox.Text}";
            foreach (ClientData data in Program.docterClient.clientData)
            {
                Program.docterClient.sendMessage(data.name, msg);
            }
            rebuildChatBox();
        }

        private void Resistance_Scroll(object sender, EventArgs e)
        {
            ClientData data = Program.docterClient.getClientData(UserList.SelectedNode.Text);
            data.resistance = resistance.Value;
            rebuildResistance();
        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void AcumPowerCheck_CheckedChanged(object sender, EventArgs e)
        {
            rebuildCharts();
        }

        private void DistanceCheck_CheckedChanged(object sender, EventArgs e)
        {
            rebuildCharts();
        }

        private void EnergyCheck_CheckedChanged(object sender, EventArgs e)
        {
            rebuildCharts();
        }

        private void UserList_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
