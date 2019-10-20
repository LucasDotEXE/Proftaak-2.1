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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 123D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 70D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Login = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LoggedInStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClientSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PaswordBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserList = new System.Windows.Forms.TreeView();
            this.Refresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registerCheck = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ActiveData = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AcumPowerCheck = new System.Windows.Forms.CheckBox();
            this.DistanceCheck = new System.Windows.Forms.CheckBox();
            this.EnergyCheck = new System.Windows.Forms.CheckBox();
            this.CurrentPowerCheck = new System.Windows.Forms.CheckBox();
            this.ResistanceLabel = new System.Windows.Forms.Label();
            this.SpeedCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BPMCheck = new System.Windows.Forms.CheckBox();
            this.resistance = new System.Windows.Forms.TrackBar();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.HistoricData = new System.Windows.Forms.TabPage();
            this.ChatWindow = new System.Windows.Forms.TabPage();
            this.chatBox = new System.Windows.Forms.ListBox();
            this.sendAllButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ActiveData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resistance)).BeginInit();
            this.tabControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.HistoricData.SuspendLayout();
            this.ChatWindow.SuspendLayout();
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
            this.StatusStrip.Size = new System.Drawing.Size(958, 26);
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(8, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(616, 658);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "BPM";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 75;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column2.HeaderText = "Energy";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.HeaderText = "Speed";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 85;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.HeaderText = "Distance";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 105;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column5.HeaderText = "Current Pow";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column6.HeaderText = "Acummulated Pow";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 162;
            // 
            // UserList
            // 
            this.UserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserList.Location = new System.Drawing.Point(6, 115);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(303, 555);
            this.UserList.TabIndex = 0;
            this.UserList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.UserList_AfterSelect);
            this.UserList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodeClicked);
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
            this.groupBox1.Controls.Add(this.UserList);
            this.groupBox1.Controls.Add(this.registerCheck);
            this.groupBox1.Controls.Add(this.Refresh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PaswordBox);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Location = new System.Drawing.Point(643, -8);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ActiveData);
            this.tabControl1.Controls.Add(this.HistoricData);
            this.tabControl1.Controls.Add(this.ChatWindow);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(81, 50);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 732);
            this.tabControl1.TabIndex = 11;
            // 
            // ActiveData
            // 
            this.ActiveData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ActiveData.Controls.Add(this.label7);
            this.ActiveData.Controls.Add(this.label8);
            this.ActiveData.Controls.Add(this.label6);
            this.ActiveData.Controls.Add(this.label5);
            this.ActiveData.Controls.Add(this.label3);
            this.ActiveData.Controls.Add(this.label4);
            this.ActiveData.Controls.Add(this.AcumPowerCheck);
            this.ActiveData.Controls.Add(this.DistanceCheck);
            this.ActiveData.Controls.Add(this.EnergyCheck);
            this.ActiveData.Controls.Add(this.CurrentPowerCheck);
            this.ActiveData.Controls.Add(this.ResistanceLabel);
            this.ActiveData.Controls.Add(this.SpeedCheck);
            this.ActiveData.Controls.Add(this.button1);
            this.ActiveData.Controls.Add(this.BPMCheck);
            this.ActiveData.Controls.Add(this.resistance);
            this.ActiveData.Controls.Add(this.tabControl2);
            this.ActiveData.Controls.Add(this.mainChart);
            this.ActiveData.Location = new System.Drawing.Point(4, 54);
            this.ActiveData.Name = "ActiveData";
            this.ActiveData.Padding = new System.Windows.Forms.Padding(3);
            this.ActiveData.Size = new System.Drawing.Size(629, 674);
            this.ActiveData.TabIndex = 0;
            this.ActiveData.Text = "Active Data";
            this.ActiveData.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total Power";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Energie KJ";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "CurrentPower";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "BPM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Distance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Speed";
            // 
            // AcumPowerCheck
            // 
            this.AcumPowerCheck.AutoSize = true;
            this.AcumPowerCheck.Location = new System.Drawing.Point(436, 272);
            this.AcumPowerCheck.Name = "AcumPowerCheck";
            this.AcumPowerCheck.Size = new System.Drawing.Size(18, 17);
            this.AcumPowerCheck.TabIndex = 13;
            this.AcumPowerCheck.UseVisualStyleBackColor = true;
            this.AcumPowerCheck.CheckedChanged += new System.EventHandler(this.AcumPowerCheck_CheckedChanged);
            // 
            // DistanceCheck
            // 
            this.DistanceCheck.AutoSize = true;
            this.DistanceCheck.Location = new System.Drawing.Point(436, 212);
            this.DistanceCheck.Name = "DistanceCheck";
            this.DistanceCheck.Size = new System.Drawing.Size(18, 17);
            this.DistanceCheck.TabIndex = 12;
            this.DistanceCheck.UseVisualStyleBackColor = true;
            this.DistanceCheck.CheckedChanged += new System.EventHandler(this.DistanceCheck_CheckedChanged);
            // 
            // EnergyCheck
            // 
            this.EnergyCheck.AutoSize = true;
            this.EnergyCheck.Location = new System.Drawing.Point(436, 158);
            this.EnergyCheck.Name = "EnergyCheck";
            this.EnergyCheck.Size = new System.Drawing.Size(18, 17);
            this.EnergyCheck.TabIndex = 11;
            this.EnergyCheck.UseVisualStyleBackColor = true;
            this.EnergyCheck.CheckedChanged += new System.EventHandler(this.EnergyCheck_CheckedChanged);
            // 
            // CurrentPowerCheck
            // 
            this.CurrentPowerCheck.AutoSize = true;
            this.CurrentPowerCheck.Location = new System.Drawing.Point(436, 242);
            this.CurrentPowerCheck.Name = "CurrentPowerCheck";
            this.CurrentPowerCheck.Size = new System.Drawing.Size(18, 17);
            this.CurrentPowerCheck.TabIndex = 8;
            this.CurrentPowerCheck.UseVisualStyleBackColor = true;
            this.CurrentPowerCheck.CheckedChanged += new System.EventHandler(this.BPowerchartCheck_CheckedChanged);
            // 
            // ResistanceLabel
            // 
            this.ResistanceLabel.AutoSize = true;
            this.ResistanceLabel.Location = new System.Drawing.Point(332, 637);
            this.ResistanceLabel.Name = "ResistanceLabel";
            this.ResistanceLabel.Size = new System.Drawing.Size(103, 20);
            this.ResistanceLabel.TabIndex = 10;
            this.ResistanceLabel.Text = "Resistance: ";
            // 
            // SpeedCheck
            // 
            this.SpeedCheck.AutoSize = true;
            this.SpeedCheck.Location = new System.Drawing.Point(436, 182);
            this.SpeedCheck.Name = "SpeedCheck";
            this.SpeedCheck.Size = new System.Drawing.Size(18, 17);
            this.SpeedCheck.TabIndex = 7;
            this.SpeedCheck.UseVisualStyleBackColor = true;
            this.SpeedCheck.CheckedChanged += new System.EventHandler(this.BSpeedchartCheck_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(7, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 70);
            this.button1.TabIndex = 9;
            this.button1.Text = "Force Stop Session";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BPMCheck
            // 
            this.BPMCheck.AutoSize = true;
            this.BPMCheck.Location = new System.Drawing.Point(436, 129);
            this.BPMCheck.Name = "BPMCheck";
            this.BPMCheck.Size = new System.Drawing.Size(18, 17);
            this.BPMCheck.TabIndex = 6;
            this.BPMCheck.UseVisualStyleBackColor = true;
            this.BPMCheck.CheckedChanged += new System.EventHandler(this.BPMchartCheck_CheckedChanged);
            // 
            // resistance
            // 
            this.resistance.Location = new System.Drawing.Point(174, 592);
            this.resistance.Name = "resistance";
            this.resistance.Size = new System.Drawing.Size(447, 56);
            this.resistance.TabIndex = 9;
            this.resistance.Tag = "";
            this.resistance.Scroll += new System.EventHandler(this.Resistance_Scroll);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(480, 578);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(8, 8);
            this.tabControl2.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(0, 0);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(0, 0);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // mainChart
            // 
            chartArea1.AxisX.IsReversed = true;
            chartArea1.AxisX.Title = "Measurements ago";
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(5, 2);
            this.mainChart.Name = "mainChart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Red;
            series1.MarkerBorderWidth = 3;
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.Name = "BPM";
            dataPoint1.MarkerImageTransparentColor = System.Drawing.Color.Red;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "Energy";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series3.Color = System.Drawing.Color.Gold;
            series3.Legend = "Legend1";
            series3.Name = "Speed";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series4.Color = System.Drawing.Color.Fuchsia;
            series4.Legend = "Legend1";
            series4.Name = "Distance";
            series5.BorderColor = System.Drawing.Color.Aqua;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series5.Legend = "Legend1";
            series5.Name = "Current Power";
            series5.ShadowColor = System.Drawing.Color.White;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series6.Legend = "Legend1";
            series6.Name = "Acumulated Power";
            this.mainChart.Series.Add(series1);
            this.mainChart.Series.Add(series2);
            this.mainChart.Series.Add(series3);
            this.mainChart.Series.Add(series4);
            this.mainChart.Series.Add(series5);
            this.mainChart.Series.Add(series6);
            this.mainChart.Size = new System.Drawing.Size(616, 366);
            this.mainChart.TabIndex = 4;
            this.mainChart.Text = "chart1";
            // 
            // HistoricData
            // 
            this.HistoricData.Controls.Add(this.dataGridView1);
            this.HistoricData.Location = new System.Drawing.Point(4, 54);
            this.HistoricData.Name = "HistoricData";
            this.HistoricData.Padding = new System.Windows.Forms.Padding(3);
            this.HistoricData.Size = new System.Drawing.Size(629, 674);
            this.HistoricData.TabIndex = 1;
            this.HistoricData.Text = "Historic Data";
            this.HistoricData.UseVisualStyleBackColor = true;
            // 
            // ChatWindow
            // 
            this.ChatWindow.Controls.Add(this.chatBox);
            this.ChatWindow.Controls.Add(this.sendAllButton);
            this.ChatWindow.Controls.Add(this.messageBox);
            this.ChatWindow.Controls.Add(this.sendButton);
            this.ChatWindow.Location = new System.Drawing.Point(4, 54);
            this.ChatWindow.Name = "ChatWindow";
            this.ChatWindow.Size = new System.Drawing.Size(629, 674);
            this.ChatWindow.TabIndex = 2;
            this.ChatWindow.Text = "Chat Window";
            this.ChatWindow.UseVisualStyleBackColor = true;
            // 
            // chatBox
            // 
            this.chatBox.FormattingEnabled = true;
            this.chatBox.ItemHeight = 20;
            this.chatBox.Location = new System.Drawing.Point(8, 3);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(606, 604);
            this.chatBox.TabIndex = 3;
            // 
            // sendAllButton
            // 
            this.sendAllButton.Location = new System.Drawing.Point(519, 613);
            this.sendAllButton.Name = "sendAllButton";
            this.sendAllButton.Size = new System.Drawing.Size(95, 39);
            this.sendAllButton.TabIndex = 2;
            this.sendAllButton.Text = "Send All";
            this.sendAllButton.UseVisualStyleBackColor = true;
            this.sendAllButton.Click += new System.EventHandler(this.SendAllButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(8, 620);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(416, 26);
            this.messageBox.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(430, 614);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(83, 39);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 744);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "RH Docktor App";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ActiveData.ResumeLayout(false);
            this.ActiveData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resistance)).EndInit();
            this.tabControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.HistoricData.ResumeLayout(false);
            this.ChatWindow.ResumeLayout(false);
            this.ChatWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PaswordBox;
        private System.Windows.Forms.ToolStripStatusLabel LoggedInStatus;
        private System.Windows.Forms.ToolStripStatusLabel ClientSelected;
        private new System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.TreeView UserList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox registerCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ActiveData;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ResistanceLabel;
        private System.Windows.Forms.TrackBar resistance;
        private System.Windows.Forms.CheckBox CurrentPowerCheck;
        private System.Windows.Forms.CheckBox SpeedCheck;
        private System.Windows.Forms.CheckBox BPMCheck;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage HistoricData;
        private System.Windows.Forms.TabPage ChatWindow;
        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.Button sendAllButton;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.CheckBox AcumPowerCheck;
        private System.Windows.Forms.CheckBox DistanceCheck;
        private System.Windows.Forms.CheckBox EnergyCheck;
    }
}

