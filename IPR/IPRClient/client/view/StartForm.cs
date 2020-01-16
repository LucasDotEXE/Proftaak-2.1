using IPRClient.client.vr;
using RHClient.client.model;
using RHClient.client.view;
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

namespace RHClient
{
    public partial class StartForm : Form
    {

        // startup
        public StartForm()
        {
            InitializeComponent();
        }

        // methods
        public void createdSession(Request request)
        {

            if (request.get("successful"))
            {

                this.BeginInvoke(new Action(() =>
                {

                    Program.client.ästrandForm.Show();
                    Program.client.ästrandForm.setInfoText();
                    Program.client.startForm.Hide();
                }));

                VRManager.getInstance().startVR();
            }
            else
                this.BeginInvoke(new Action(() => this.error.Text = "Failed Creating Session!"));
        }

        // events
        private void startForm_Load(object sender, EventArgs e) { }

        private void createSession_Click(object sender, EventArgs e)
        {

            // this order is for correct error messages
            string gender   = InputChecker.checkGender(this.gender.Text);
            int weight      = InputChecker.checkWeight(this.weight.Text);
            int age         = InputChecker.checkAge(this.age.Text);
            string name     = InputChecker.checkName(this.name.Text);

            Program.client.ästrandForm.maxBpm = (210 - (age / 2));

            if (InputChecker.checkSessionInput(age, weight, name, gender))
                Program.client.writeCreateSessionRequest(age, weight, name, gender);
            else
                this.error.Text = InputChecker.error;
        }
    }
}
