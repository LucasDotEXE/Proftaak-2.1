using RHLib.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHDocter
{
    public partial class DocterForm : Form
    {

        // attributes
        private List<string[]> names;

        // startup
        public DocterForm()
        {
            InitializeComponent();
        }

        private void docterForm_Load(object sender, EventArgs e) { }

        // methods
        public void setSessions(Request request)
        {

            List<string[]> online = JsonConvert.DeserializeObject<List<string[]>>(request.get("online"));
            List<string[]> offline = JsonConvert.DeserializeObject<List<string[]>>(request.get("offline"));

            this.names = new List<string[]>();
            this.names.AddRange(online);
            this.names.AddRange(offline);

            this.chat.Text = "";

            this.BeginInvoke(new Action(() =>
            {

                this.onlineNames.Nodes.Clear();
                foreach (string[] name in online)
                    this.onlineNames.Nodes.Add(name[0]);

                this.offlineNames.Nodes.Clear();
                foreach (string[] name in offline)
                    this.offlineNames.Nodes.Add(name[0]);
            }));
        }

        private int getId(string searchName)
        {

            foreach (string[] name in this.names)
                if (name[0] == searchName)
                    return Convert.ToInt32(name[1]);

            return -1;
        }

        public void setValidation(Request request, bool isMessage)
        {

            this.BeginInvoke(new Action(() =>
            {

                if (isMessage)
                    this.error.ForeColor = Color.Gray;
                else
                    this.error.ForeColor = Color.Red;

                this.error.Text = request.get("message");
            }));
        }

        internal void wasSuccessful(bool successful)
        {

            if (successful)
                Program.docter.writeReadSessionRequest();

            this.BeginInvoke(new Action(() => {

                if (successful)
                    coverPanel.Visible = false;
                else
                    this.login_statuslabel.Text = "Wrong Login";
            }));
        }

        // chart
        public void buildChart()
        {

            this.BeginInvoke(new Action(() =>
            {

                this.chart.Series["Acumilated Power"].Points.Clear();
                this.chart.Series["Current Power"].Points.Clear();
                this.chart.Series["Distance"].Points.Clear();
                this.chart.Series["Speed"].Points.Clear();
                this.chart.Series["BPM"].Points.Clear();
                this.chart.Series["VO2"].Points.Clear();

                List<Measurement> measurements = Program.docter.subscribed.measurements;

                for (int i = 0; i < measurements.Count(); i++)
                {

                    if (APower.Checked && measurements[i].acumilatedPower != -1.0)
                        chart.Series["Acumilated Power"].Points.AddXY(i, measurements[i].acumilatedPower);

                    if (CPower.Checked && measurements[i].currentPower != -1.0)
                        chart.Series["Current Power"].Points.AddXY(i, measurements[i].currentPower);

                    if (Distance.Checked && measurements[i].distance != -1.0)
                        chart.Series["Distance"].Points.AddXY(i, measurements[i].distance);

                    if (Speed.Checked && measurements[i].speed != -1.0)
                        chart.Series["Speed"].Points.AddXY(i, measurements[i].speed);

                    if (BPM.Checked && measurements[i].bpm != -1.0)
                        chart.Series["BPM"].Points.AddXY(i, measurements[i].bpm);

                    if (VO2.Checked && measurements[i].vo2 > 0 && measurements[i].vo2 < 25)
                        chart.Series["VO2"].Points.AddXY(i, measurements[i].vo2);
                }
            }));
        }

        // history
        public void buildInformation()
        {

            this.BeginInvoke(new Action(() =>
            {

                this.name.Text   = "Name: " + Program.docter.subscribed.name;
                this.age.Text    = "Age: " + Program.docter.subscribed.age;
                this.weight.Text = "Weight: " + Program.docter.subscribed.weight;
                this.gender.Text = "Gender: " + Program.docter.subscribed.gender;
            }));
        }

        // events
        private void OnlineNames_AfterSelect(object sender, TreeViewEventArgs e)
        {

            Program.docter.writeSubscribeRequest(this.getId(this.onlineNames.SelectedNode.Text));
        }

        private void OfflineNames_AfterSelect(object sender, TreeViewEventArgs e)
        {

            Program.docter.writeSubscribeRequest(this.getId(this.offlineNames.SelectedNode.Text));
        }

        private void Refresh_Click(object sender, EventArgs e)
        {

            Program.docter.writeReadSessionRequest();
        }

        private void Start_Click(object sender, EventArgs e)
        {

            Program.docter.writeTestRequest(this.bikeId.Text);
        }

        private void Stop_Click(object sender, EventArgs e)
        {

            Program.docter.writeStopÄstrandRequest(true);
        }

        private void CheckedChanged(object sender, EventArgs e)
        {

            this.buildChart();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                string message = "To " + Program.docter.subscribed.name + ": " + this.Input.Text;

                if (this.chat.Text != "")
                    message = "\n" + message;

                this.chat.Text += message;

                Program.docter.writeMessageRequest(this.Input.Text);

                this.Input.Text = "";
            }
        }

        private void Login_loginbutton_Click(object sender, EventArgs e)
        {
            String name = login_name.Text;
            String password = login_password.Text;

            Program.docter.writeLoginRequest(name, password);
           
        }
    }
}
