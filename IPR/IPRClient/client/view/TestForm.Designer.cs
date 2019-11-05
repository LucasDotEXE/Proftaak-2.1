namespace IPRClient
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.message = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Label();
            this.HF = new System.Windows.Forms.Label();
            this.CPM = new System.Windows.Forms.Label();
            this.resistance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(12, 9);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(215, 13);
            this.message.TabIndex = 0;
            this.message.Text = "WAITING FOR DOCTER TO START TEST";
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Location = new System.Drawing.Point(193, 51);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(54, 13);
            this.timer.TabIndex = 1;
            this.timer.Text = "Time Left:";
            // 
            // HF
            // 
            this.HF.AutoSize = true;
            this.HF.Location = new System.Drawing.Point(11, 35);
            this.HF.Name = "HF";
            this.HF.Size = new System.Drawing.Size(112, 13);
            this.HF.TabIndex = 2;
            this.HF.Text = "Keep HF around 130: ";
            this.HF.Click += new System.EventHandler(this.Label1_Click);
            // 
            // CPM
            // 
            this.CPM.AutoSize = true;
            this.CPM.Location = new System.Drawing.Point(11, 48);
            this.CPM.Name = "CPM";
            this.CPM.Size = new System.Drawing.Size(162, 13);
            this.CPM.TabIndex = 3;
            this.CPM.Text = "Keep Cicles per minute 50 / 60:  ";
            // 
            // resistance
            // 
            this.resistance.AutoSize = true;
            this.resistance.Location = new System.Drawing.Point(193, 35);
            this.resistance.Name = "resistance";
            this.resistance.Size = new System.Drawing.Size(66, 13);
            this.resistance.TabIndex = 4;
            this.resistance.Text = "Resistance: ";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 75);
            this.Controls.Add(this.resistance);
            this.Controls.Add(this.CPM);
            this.Controls.Add(this.HF);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.message);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Label HF;
        private System.Windows.Forms.Label CPM;
        private System.Windows.Forms.Label resistance;
    }
}