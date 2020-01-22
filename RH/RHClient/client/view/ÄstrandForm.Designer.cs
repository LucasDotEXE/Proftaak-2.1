namespace RHClient.client.view
{
    partial class ÄstrandForm
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
            this.components = new System.ComponentModel.Container();
            this.title = new System.Windows.Forms.Label();
            this.resistance = new System.Windows.Forms.Label();
            this.hr = new System.Windows.Forms.Label();
            this.fase = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.Label();
            this.bike = new System.Windows.Forms.Label();
            this.timerText = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Navy;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.title.Location = new System.Drawing.Point(119, 9);
            this.title.Margin = new System.Windows.Forms.Padding(5);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(5);
            this.title.Size = new System.Drawing.Size(300, 100);
            this.title.TabIndex = 0;
            this.title.Text = "Ästrand Test";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resistance
            // 
            this.resistance.BackColor = System.Drawing.Color.Navy;
            this.resistance.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.resistance.Location = new System.Drawing.Point(9, 119);
            this.resistance.Margin = new System.Windows.Forms.Padding(5);
            this.resistance.Name = "resistance";
            this.resistance.Padding = new System.Windows.Forms.Padding(5);
            this.resistance.Size = new System.Drawing.Size(100, 100);
            this.resistance.TabIndex = 1;
            this.resistance.Text = "Resistance: 0";
            this.resistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hr
            // 
            this.hr.BackColor = System.Drawing.Color.Navy;
            this.hr.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hr.Location = new System.Drawing.Point(119, 119);
            this.hr.Margin = new System.Windows.Forms.Padding(5);
            this.hr.Name = "hr";
            this.hr.Padding = new System.Windows.Forms.Padding(5);
            this.hr.Size = new System.Drawing.Size(145, 100);
            this.hr.TabIndex = 3;
            this.hr.Text = "Heart Rate: 0";
            this.hr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fase
            // 
            this.fase.BackColor = System.Drawing.Color.Navy;
            this.fase.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fase.Location = new System.Drawing.Point(429, 9);
            this.fase.Margin = new System.Windows.Forms.Padding(5);
            this.fase.Name = "fase";
            this.fase.Padding = new System.Windows.Forms.Padding(5);
            this.fase.Size = new System.Drawing.Size(100, 45);
            this.fase.TabIndex = 5;
            this.fase.Text = "Waiting for Start";
            this.fase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.Navy;
            this.info.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.info.Location = new System.Drawing.Point(274, 119);
            this.info.Margin = new System.Windows.Forms.Padding(5);
            this.info.Name = "info";
            this.info.Padding = new System.Windows.Forms.Padding(5);
            this.info.Size = new System.Drawing.Size(255, 45);
            this.info.TabIndex = 6;
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tip
            // 
            this.tip.BackColor = System.Drawing.Color.Navy;
            this.tip.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tip.Location = new System.Drawing.Point(274, 174);
            this.tip.Margin = new System.Windows.Forms.Padding(5);
            this.tip.Name = "tip";
            this.tip.Padding = new System.Windows.Forms.Padding(5);
            this.tip.Size = new System.Drawing.Size(255, 45);
            this.tip.TabIndex = 7;
            this.tip.Text = "Tips will display here";
            this.tip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bike
            // 
            this.bike.BackColor = System.Drawing.Color.Navy;
            this.bike.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bike.Location = new System.Drawing.Point(429, 64);
            this.bike.Margin = new System.Windows.Forms.Padding(5);
            this.bike.Name = "bike";
            this.bike.Padding = new System.Windows.Forms.Padding(5);
            this.bike.Size = new System.Drawing.Size(100, 45);
            this.bike.TabIndex = 8;
            this.bike.Text = "Bike Id: 0";
            this.bike.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerText
            // 
            this.timerText.BackColor = System.Drawing.Color.Navy;
            this.timerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.timerText.Location = new System.Drawing.Point(9, 9);
            this.timerText.Margin = new System.Windows.Forms.Padding(5);
            this.timerText.Name = "timerText";
            this.timerText.Padding = new System.Windows.Forms.Padding(5);
            this.timerText.Size = new System.Drawing.Size(100, 100);
            this.timerText.TabIndex = 9;
            this.timerText.Text = "00:00";
            this.timerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // ÄstrandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 228);
            this.Controls.Add(this.timerText);
            this.Controls.Add(this.bike);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.info);
            this.Controls.Add(this.fase);
            this.Controls.Add(this.hr);
            this.Controls.Add(this.resistance);
            this.Controls.Add(this.title);
            this.Name = "ÄstrandForm";
            this.Text = "ÄstrandForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label resistance;
        private System.Windows.Forms.Label hr;
        private System.Windows.Forms.Label fase;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.Label bike;
        private System.Windows.Forms.Label timerText;
        private System.Windows.Forms.Timer timer;
    }
}