namespace DocterAplication
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 123D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 70D);
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Login = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LoggedInStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClientSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.UserList = new System.Windows.Forms.CheckedListBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PaswordBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.NameSelectionList = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BPowerchartCheck = new System.Windows.Forms.CheckBox();
            this.BSpeedchartCheck = new System.Windows.Forms.CheckBox();
            this.BPMchartCheck = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.ListBox();
            this.sendAllButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.Refresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registerCheck = new System.Windows.Forms.CheckBox();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(182, 20);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 89);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoggedInStatus,
            this.ClientSelected});
            this.StatusStrip.Location = new System.Drawing.Point(0, 718);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1266, 26);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // LoggedInStatus
            // 
            this.LoggedInStatus.Name = "LoggedInStatus";
            this.LoggedInStatus.Size = new System.Drawing.Size(105, 20);
            this.LoggedInStatus.Text = "Not Logged In";
            // 
            // ClientSelected
            // 
            this.ClientSelected.Name = "ClientSelected";
            this.ClientSelected.Size = new System.Drawing.Size(139, 20);
            this.ClientSelected.Text = "Client Selected: ----";
            // 
            // UserList
            // 
            this.UserList.CheckOnClick = true;
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(6, 115);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(299, 633);
            this.UserList.TabIndex = 2;
            this.UserList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.UserList_ItemCheck);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(71, 31);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 22);
            this.nameBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pasword";
            // 
            // PaswordBox
            // 
            this.PaswordBox.Location = new System.Drawing.Point(71, 59);
            this.PaswordBox.Name = "PaswordBox";
            this.PaswordBox.Size = new System.Drawing.Size(100, 22);
            this.PaswordBox.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NameSelectionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(938, 703);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 8;
            // 
            // NameSelectionList
            // 
            this.NameSelectionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameSelectionList.Location = new System.Drawing.Point(3, 3);
            this.NameSelectionList.Name = "NameSelectionList";
            this.NameSelectionList.Size = new System.Drawing.Size(303, 697);
            this.NameSelectionList.TabIndex = 0;
            this.NameSelectionList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodeClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainChart);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 697);
            this.panel2.TabIndex = 0;
            // 
            // mainChart
            // 
            chartArea3.AxisX.IsReversed = true;
            chartArea3.AxisX.Title = "Measurements ago";
            chartArea3.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.mainChart.Legends.Add(legend3);
            this.mainChart.Location = new System.Drawing.Point(3, 408);
            this.mainChart.Name = "mainChart";
            series13.BorderWidth = 3;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series13.Color = System.Drawing.Color.Red;
            series13.Legend = "Legend1";
            series13.MarkerBorderColor = System.Drawing.Color.Red;
            series13.MarkerBorderWidth = 3;
            series13.MarkerColor = System.Drawing.Color.Red;
            series13.Name = "BPM";
            dataPoint7.MarkerImageTransparentColor = System.Drawing.Color.Red;
            series13.Points.Add(dataPoint7);
            series13.Points.Add(dataPoint8);
            series13.Points.Add(dataPoint9);
            series14.BorderWidth = 3;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series14.Color = System.Drawing.Color.Blue;
            series14.Legend = "Legend1";
            series14.Name = "Energy";
            series15.BorderWidth = 3;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series15.Color = System.Drawing.Color.Gold;
            series15.Legend = "Legend1";
            series15.Name = "Speed";
            series16.BorderWidth = 3;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series16.Color = System.Drawing.Color.Fuchsia;
            series16.Legend = "Legend1";
            series16.Name = "Distance";
            series17.BorderColor = System.Drawing.Color.Aqua;
            series17.BorderWidth = 3;
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series17.Legend = "Legend1";
            series17.Name = "Current Power";
            series17.ShadowColor = System.Drawing.Color.White;
            series18.BorderWidth = 3;
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series18.Legend = "Legend1";
            series18.Name = "Acumulated Power";
            this.mainChart.Series.Add(series13);
            this.mainChart.Series.Add(series14);
            this.mainChart.Series.Add(series15);
            this.mainChart.Series.Add(series16);
            this.mainChart.Series.Add(series17);
            this.mainChart.Series.Add(series18);
            this.mainChart.Size = new System.Drawing.Size(616, 286);
            this.mainChart.TabIndex = 4;
            this.mainChart.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BPowerchartCheck);
            this.panel1.Controls.Add(this.BSpeedchartCheck);
            this.panel1.Controls.Add(this.BPMchartCheck);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(448, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 286);
            this.panel1.TabIndex = 2;
            // 
            // BPowerchartCheck
            // 
            this.BPowerchartCheck.AutoSize = true;
            this.BPowerchartCheck.Location = new System.Drawing.Point(3, 259);
            this.BPowerchartCheck.Name = "BPowerchartCheck";
            this.BPowerchartCheck.Size = new System.Drawing.Size(138, 21);
            this.BPowerchartCheck.TabIndex = 8;
            this.BPowerchartCheck.Text = "Bike Power Chart";
            this.BPowerchartCheck.UseVisualStyleBackColor = true;
            this.BPowerchartCheck.CheckedChanged += new System.EventHandler(this.BPowerchartCheck_CheckedChanged);
            // 
            // BSpeedchartCheck
            // 
            this.BSpeedchartCheck.AutoSize = true;
            this.BSpeedchartCheck.Location = new System.Drawing.Point(3, 232);
            this.BSpeedchartCheck.Name = "BSpeedchartCheck";
            this.BSpeedchartCheck.Size = new System.Drawing.Size(140, 21);
            this.BSpeedchartCheck.TabIndex = 7;
            this.BSpeedchartCheck.Text = "Bike Speed Chart";
            this.BSpeedchartCheck.UseVisualStyleBackColor = true;
            this.BSpeedchartCheck.CheckedChanged += new System.EventHandler(this.BSpeedchartCheck_CheckedChanged);
            // 
            // BPMchartCheck
            // 
            this.BPMchartCheck.AutoSize = true;
            this.BPMchartCheck.Location = new System.Drawing.Point(3, 205);
            this.BPMchartCheck.Name = "BPMchartCheck";
            this.BPMchartCheck.Size = new System.Drawing.Size(97, 21);
            this.BPMchartCheck.TabIndex = 6;
            this.BPMchartCheck.Text = "BPM Chart";
            this.BPMchartCheck.UseVisualStyleBackColor = true;
            this.BPMchartCheck.CheckedChanged += new System.EventHandler(this.BPMchartCheck_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Energie KJ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total Power";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "CurrentPower";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "BPM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Distance";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.chatBox);
            this.panel3.Controls.Add(this.sendAllButton);
            this.panel3.Controls.Add(this.sendButton);
            this.panel3.Controls.Add(this.messageBox);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 399);
            this.panel3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(445, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 70);
            this.button1.TabIndex = 9;
            this.button1.Text = "Force Stop Session";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // chatBox
            // 
            this.chatBox.FormattingEnabled = true;
            this.chatBox.ItemHeight = 16;
            this.chatBox.Location = new System.Drawing.Point(3, 6);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(436, 356);
            this.chatBox.TabIndex = 3;
            // 
            // sendAllButton
            // 
            this.sendAllButton.Location = new System.Drawing.Point(534, 373);
            this.sendAllButton.Name = "sendAllButton";
            this.sendAllButton.Size = new System.Drawing.Size(75, 23);
            this.sendAllButton.TabIndex = 2;
            this.sendAllButton.Text = "Send All";
            this.sendAllButton.UseVisualStyleBackColor = true;
            this.sendAllButton.Click += new System.EventHandler(this.SendAllButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(445, 373);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(83, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(3, 374);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(436, 22);
            this.messageBox.TabIndex = 0;
            // 
            // Refresh
            // 
            this.Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh.Location = new System.Drawing.Point(263, 20);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(45, 89);
            this.Refresh.TabIndex = 9;
            this.Refresh.Text = "⟳";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.registerCheck);
            this.groupBox1.Controls.Add(this.UserList);
            this.groupBox1.Controls.Add(this.Refresh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PaswordBox);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Location = new System.Drawing.Point(956, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 752);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // registerCheck
            // 
            this.registerCheck.Location = new System.Drawing.Point(26, 87);
            this.registerCheck.Name = "registerCheck";
            this.registerCheck.Size = new System.Drawing.Size(136, 22);
            this.registerCheck.TabIndex = 0;
            this.registerCheck.Text = "New Acount";
            this.registerCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 744);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "RH Docktor App";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.CheckedListBox UserList;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PaswordBox;
        private System.Windows.Forms.ToolStripStatusLabel LoggedInStatus;
        private System.Windows.Forms.ToolStripStatusLabel ClientSelected;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private new System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.TreeView NameSelectionList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.CheckBox registerCheck;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox BPowerchartCheck;
        private System.Windows.Forms.CheckBox BSpeedchartCheck;
        private System.Windows.Forms.CheckBox BPMchartCheck;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button sendAllButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox chatBox;
    }
}

