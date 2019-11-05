using IPRClient.client.model;
using IPRLib.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPRClient
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
                this.BeginInvoke(new Action(() =>
                {

                    TestForm testForm = new TestForm();
                    testForm.Show();

                    Program.client.startForm.Hide();
                    Program.client.testForm = testForm;
                }));
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

            if (InputChecker.checkSessionInput(age, weight, name, gender))
                Program.client.writeCreateSessionRequest(age, weight, name, gender);
            else
                this.error.Text = InputChecker.error;
        }
    }
}
