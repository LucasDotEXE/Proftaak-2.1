using IPRLib.data;
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

namespace IPRClient
{
    public partial class TestForm : Form
    {

        private TestTimer testTimer;

        public TestForm()
        {

            InitializeComponent();

            this.testTimer = new TestTimer(this);
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

            this.testTimer.start(120);
        }

        public void setTime(string time)
        {

            this.BeginInvoke(new Action(() => this.timer.Text = "Time left: " +  time));
        }

        public void receiveTest(Request request)
        {

            if (request.get("start") == true)
                Program.client.startTest(request);
            else if (request.get("start") == false)
                Program.client.stopTest();

            if (request.get("resistance") != null)
            {

                Program.blueTooth.setResistance((int)request.get("resistance"));
                this.BeginInvoke(new Action(() => this.resistance.Text = "Resistance: " + request.get("resistance")));
            }

            if (request.get("seconds") != -1 && request.get("seconds") != null)
                this.testTimer.start((int) request.get("seconds"));

            if (request.get("message") != null)
                this.BeginInvoke(new Action(() => this.message.Text = request.get("message")));
        }

        public void setValues(Measurement measurement)
        {

            this.BeginInvoke(new Action(() =>
            {

                if (measurement.bpm != -1);
                    this.HF.Text = "Keep HF around 130: " + measurement.bpm;

                if (measurement.distance != -1)
                    this.CPM.Text = "Keep Cicles per minute 50 / 60: " + measurement.distance;
            }));
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class TestTimer
    {

        private TestForm form;
        private int seconds;

        public TestTimer(TestForm form)
        {

            this.form = form;
        }

        public void start(int seconds)
        {

            this.seconds = seconds;

            new Thread(new ThreadStart(run)).Start();
        }

        private void run()
        {

            while (this.seconds >= 0)
            {

                this.form.setTime(this.getTime());
                this.seconds -= 1;
            }
        }

        private string getTime()
        {

            return String.Format(
                "{0}:{1}", 
                (this.seconds / 60).ToString("D1"), 
                (this.seconds % 60).ToString("D2")
            );
        }
    }
}
