using IPRClient.client.vr;
using RHClient.client.view;
using RHLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RHClient.client.model
{

    public class Ästrand
    {

        // attributes
        private int seconds;
        private int measures;

        private string fase;
        private ÄstrandForm form;

        // constructor
        public Ästrand()
        {

            this.seconds = 120;
            this.fase = "Warming up";
        }

        // start
        public void startÄstrand()
        {

            this.form = Program.client.ästrandForm;

            this.form.setTimerText(this.seconds);
            this.form.setFaseText(this.fase);
            this.form.setTipText("");
        }

        // methods
        public void nextMeasure(double bpm)
        {

            this.measures++;

            if (!Program.client.blueTooth.hasHeartRate)
            {

                this.form.setTipText("No heart rate monitor connected");
                return;
            }

            if (bpm != -1)
                if ((bpm > Program.client.ästrandForm.maxBpm || bpm < 110) && this.fase == "Ästrand test")
                {

                    this.form.stopÄstrand();
                    this.form.setTipText("Test stopped due to emergancy");
                    this.form.setFaseText("Emergancy stop");
                }
                else if (this.measures % 2 == 0)
                {

                    this.form.setHRText(bpm);
                    this.setResistance(bpm);
                    this.setTip(bpm);
                }
        }

        private void setResistance(double bpm)
        {

            int resistance = -5;

            if (this.fase != "Cooling down")
                resistance = (int)((130 - bpm) / 3);

            Program.client.blueTooth.alterResistance(resistance);
            this.form.setResistanceText(Program.client.blueTooth.resistance);
        }

        private void setTip(double bpm)
        {

            if (bpm < 120)
                this.form.setTipText("Your heart rate is to low. try cycling faster");
            else if (bpm < 128)
                this.form.setTipText("Your heart rate is a bit low. try cycling a bit faster");
            else if (bpm <= 132)
                this.form.setTipText("Your heart rate is good. keep cycling like this");
            else if (bpm < 140)
                this.form.setTipText("Your heart rate is a bit high. try cycling a bit slower");
            else if (bpm < 200)
                this.form.setTipText("Your heart rate is to high. try cycling slower");
        }

        public void nextSecond()
        {

            if (this.seconds != 0)
            {

                this.seconds--;
                this.form.setTimerText(this.seconds);
            }

            if (this.seconds == 0)
                this.switchFase();
        }

        private void switchFase()
        {

            switch (this.fase)
            {

                case "Warming up":
                    this.seconds = 240;
                    this.fase = "Ästrand test";
                    break;

                case "Ästrand test":
                    this.seconds = 60;
                    this.fase = "Cooling down";
                    break;

                case "Cooling down":
                    this.form.stopÄstrand();
                    this.fase = "End of test";
                    break;
            }

            this.form.setFaseText(this.fase);
        }
    }
}
