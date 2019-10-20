using RHLib.data;
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

            Program.docterClient.form = this;

            InitializeComponent();
            this.PaswordBox.PasswordChar = '*';
        }

        private void Login_Click(object sender, EventArgs e)
        {

            if (Program.docterClient.isLoggedIn)
            {

                Program.docterClient.isLoggedIn = false;
                LoggedInStatus.Text = "Not Logged In";
                Login.Text = "Login";
            }
            else
            {

                String userName = nameBox.Text;
                String pasword = PaswordBox.Text;
                bool register = registerCheck.Checked;

                Program.docterClient.sendLoginRequest(userName, pasword, register);

                this.LoggedInStatus.Text = $"Logged in as: {userName}";
                this.Login.Text = "Logout";
            }
        }

        public void loggedIn(bool successful)
        {

            if (successful)
            {

                Program.docterClient.sendClientListRequest();
            }
            else
            {

                this.StatusStrip.Text = "Not Logged In";
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {

            Program.docterClient.sendClientListRequest();
        }

        public void RefreshPage()
        {

            this.BeginInvoke(new Action(() =>
            {

                this.UserList.Nodes.Clear();
                foreach (ClientData data in Program.docterClient.clientDatas)
                    this.UserList.Nodes.Add(data.name);
            }));
        }

        public void displayClient(Request request)
        {

            Program.docterClient.subscribed.setMeasurements(request);

            this.BeginInvoke(new Action(() =>
            {

                try
                {

                    this.ClientSelected.Text = $"Selected Client: {this.UserList.SelectedNode.Text}";
                }
                catch (Exception)
                {

                    return;
                }

                this.rebuildCharts();
                this.rebuildChatBox();
                this.rebuildHistory();
                this.rebuildResistance();
            }));
        }

        private void NodeClicked(object sender, TreeNodeMouseClickEventArgs e)
        {

            this.BeginInvoke(new Action(() =>
            {

                Program.docterClient.sendFollowRequest(this.UserList.SelectedNode.Text);
            }));
        }

        private void rebuildResistance()
        {

            ClientData data = Program.docterClient.getClientData(this.UserList.SelectedNode.Text);
            this.resistance.Value = data.resistance;
            this.ResistanceLabel.Text = $"Resistance: {this.resistance.Value}";
        }

        private void rebuildHistory()
        {

            this.BeginInvoke(new Action(() =>
            {

                try
                {

                    _ = this.UserList.SelectedNode.Text;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.StackTrace);
                    return;
                }

                String selectedClientName = this.UserList.SelectedNode.Text;
                ClientData data = Program.docterClient.getClientData(selectedClientName);

                for (int i = 0; i < data.heartRateMeasurements.Count; i++)
                {

                    BikePowerMeasurement bikePowMes = data.bikePowerMeasurements[i];
                    BikeSpeedMeasurement bikeSpedMes = data.bikeSpeedMeasurements[i];
                    HeartRateMeasurement heartMes = data.heartRateMeasurements[i];

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

                    _ = this.UserList.SelectedNode.Text;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.StackTrace);
                    return;
                }

                String selectedClientName = this.UserList.SelectedNode.Text;
                ClientData data = Program.docterClient.getClientData(selectedClientName);
                this.mainChart.Series["BPM"].Points.Clear();
                this.mainChart.Series["Energy"].Points.Clear();
                this.mainChart.Series["Speed"].Points.Clear();
                this.mainChart.Series["Distance"].Points.Clear();
                this.mainChart.Series["Current Power"].Points.Clear();
                this.mainChart.Series["Acumulated Power"].Points.Clear();

                HeartRateMeasurement[] heartRateMeasurements = data.heartRateMeasurements.ToArray();
                BikeSpeedMeasurement[] bikeSpeedMeasurements = data.bikeSpeedMeasurements.ToArray();
                BikePowerMeasurement[] bikePowerMeasurements = data.bikePowerMeasurements.ToArray();

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

            this.rebuildCharts();
        }

        private void BSpeedchartCheck_CheckedChanged(object sender, EventArgs e)
        {

            this.rebuildCharts();
        }

        private void BPowerchartCheck_CheckedChanged(object sender, EventArgs e)
        {

            this.rebuildCharts();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {

            String msg = messageBox.Text;

            Program.docterClient.subscribed.messages.Add(msg);
            Program.docterClient.sendMessage(msg);

            this.rebuildChatBox();
        }

        private void rebuildChatBox()
        {

            this.chatBox.Items.Clear();

            foreach (String message in Program.docterClient.getClientData(UserList.SelectedNode.Text).messages)
                this.chatBox.Items.Add(message);
        }

        private void SendAllButton_Click(object sender, EventArgs e)
        {

            foreach (ClientData data in Program.docterClient.clientDatas)
                data.messages.Add(this.messageBox.Text);

            Program.docterClient.sendMessage(this.messageBox.Text);

            this.rebuildChatBox();
        }

        private void Resistance_Scroll(object sender, EventArgs e)
        {

            if (Program.docterClient.getClientData(this.UserList.SelectedNode.Text) != null)
            {

                ClientData data = Program.docterClient.getClientData(this.UserList.SelectedNode.Text);
                data.resistance = this.resistance.Value;
                this.rebuildResistance();
            }
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
