using IPRClient.client.vr;
using RHClient.client.model;
using RHLib.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHClient.client.view
{
    public partial class ÄstrandForm : Form
    {

        private Thread ästrandBluetoothThread;
        public Ästrand ästrand;

        public int maxBpm;

        // start
        public ÄstrandForm()
        {

            InitializeComponent();
        }

        // methods
        public void startÄstrand(Request request)
        {

            if (request.get("start"))
            {

                this.ästrandBluetoothThread = new Thread(() => Program.client.startBluetooth(request));
                this.ästrandBluetoothThread.Start();

                this.ästrand = new Ästrand();
                this.ästrand.startÄstrand();

                VRClientConnection.getInstance().writeVRStartCycling(true);

                this.BeginInvoke(new Action(() => {

                    this.timer.Start();
                    this.bike.Text = "Bike Id: " + request.get("bikeId");
                }));
            }
        }

        public void stopÄstrand(bool bikeError = false)
        {

            this.ästrand = null;
            this.ästrandBluetoothThread = null;

            this.timer.Stop();
            this.setTimerText(0);

            Program.client.blueTooth.stop();
            Program.client.blueTooth = null;

            VRClientConnection.getInstance().writeVRStartCycling(false);

            if (!bikeError)
                Program.client.writeStopÄstrandRequest(true);
        }

        public void setInfoText()
        {

            this.info.Text = "During the test, keep your heart rate around 130. Below 110 and above " + this.maxBpm + " the test will stop";
        }

        // invokes
        public void setTimerText(int seconds)
        {

            this.BeginInvoke(new Action(() =>
                this.timerText.Text = (seconds / 60) + ":" + (seconds % 60).ToString("D2")
            ));
        }

        public void setResistanceText(int resistance)
        {

            this.BeginInvoke(new Action(() =>
                this.resistance.Text = "Resistance: " + resistance
            ));
        }

        public void setHRText(double HR)
        {

            this.BeginInvoke(new Action(() =>
                this.hr.Text = "Heart Rate: " + HR
            ));
        }

        public void setFaseText(string fase)
        {

            this.BeginInvoke(new Action(() =>
                this.fase.Text = fase
            ));
        }

        public void setTipText(string tip)
        {

            this.BeginInvoke(new Action(() =>
                this.tip.Text = tip
            ));
        }

        // events
        private void ÄstrandForm_Load(object sender, EventArgs e) {}

        private void Timer_Tick(object sender, EventArgs e)
        {

            this.ästrand.nextSecond();
        }
    }
}
