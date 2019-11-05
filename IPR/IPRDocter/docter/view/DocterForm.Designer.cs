namespace IPRDocter
{
    partial class DocterForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.history = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.graph = new System.Windows.Forms.TabPage();
            this.gender = new System.Windows.Forms.Label();
            this.weight = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.VO2 = new System.Windows.Forms.CheckBox();
            this.idBike = new System.Windows.Forms.TextBox();
            this.labelIdBike = new System.Windows.Forms.Label();
            this.APower = new System.Windows.Forms.CheckBox();
            this.CPower = new System.Windows.Forms.CheckBox();
            this.Distance = new System.Windows.Forms.CheckBox();
            this.Speed = new System.Windows.Forms.CheckBox();
            this.BPM = new System.Windows.Forms.CheckBox();
            this.start = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.onlineNames = new System.Windows.Forms.TreeView();
            this.labelOnline = new System.Windows.Forms.Label();
            this.labelOffline = new System.Windows.Forms.Label();
            this.offlineNames = new System.Windows.Forms.TreeView();
            this.Refresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(4, 22);
            this.history.Name = "history";
            this.history.Padding = new System.Windows.Forms.Padding(3);
            this.history.Size = new System.Drawing.Size(924, 400);
            this.history.TabIndex = 1;
            this.history.Text = "History";
            this.history.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.graph);
            this.tabControl.Controls.Add(this.history);
            this.tabControl.ItemSize = new System.Drawing.Size(100, 18);
            this.tabControl.Location = new System.Drawing.Point(12, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(932, 426);
            this.tabControl.TabIndex = 0;
            // 
            // graph
            // 
            this.graph.Controls.Add(this.button2);
            this.graph.Controls.Add(this.button1);
            this.graph.Controls.Add(this.gender);
            this.graph.Controls.Add(this.weight);
            this.graph.Controls.Add(this.age);
            this.graph.Controls.Add(this.name);
            this.graph.Controls.Add(this.VO2);
            this.graph.Controls.Add(this.idBike);
            this.graph.Controls.Add(this.labelIdBike);
            this.graph.Controls.Add(this.APower);
            this.graph.Controls.Add(this.CPower);
            this.graph.Controls.Add(this.Distance);
            this.graph.Controls.Add(this.Speed);
            this.graph.Controls.Add(this.BPM);
            this.graph.Controls.Add(this.start);
            this.graph.Controls.Add(this.chart);
            this.graph.Location = new System.Drawing.Point(4, 22);
            this.graph.Name = "graph";
            this.graph.Padding = new System.Windows.Forms.Padding(3);
            this.graph.Size = new System.Drawing.Size(924, 400);
            this.graph.TabIndex = 0;
            this.graph.Text = "Graph";
            this.graph.UseVisualStyleBackColor = true;
            // 
            // gender
            // 
            this.gender.AutoSize = true;
            this.gender.Location = new System.Drawing.Point(727, 162);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(45, 13);
            this.gender.TabIndex = 18;
            this.gender.Text = "Gender:";
            // 
            // weight
            // 
            this.weight.AutoSize = true;
            this.weight.Location = new System.Drawing.Point(727, 146);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(47, 13);
            this.weight.TabIndex = 17;
            this.weight.Text = "Weight: ";
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Location = new System.Drawing.Point(727, 129);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(32, 13);
            this.age.TabIndex = 16;
            this.age.Text = "Age: ";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(727, 113);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 13);
            this.name.TabIndex = 15;
            this.name.Text = "Name:";
            // 
            // VO2
            // 
            this.VO2.AutoSize = true;
            this.VO2.Checked = true;
            this.VO2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VO2.Location = new System.Drawing.Point(741, 92);
            this.VO2.Name = "VO2";
            this.VO2.Size = new System.Drawing.Size(15, 14);
            this.VO2.TabIndex = 14;
            this.VO2.UseVisualStyleBackColor = true;
            this.VO2.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // idBike
            // 
            this.idBike.Location = new System.Drawing.Point(730, 237);
            this.idBike.Name = "idBike";
            this.idBike.Size = new System.Drawing.Size(171, 20);
            this.idBike.TabIndex = 13;
            // 
            // labelIdBike
            // 
            this.labelIdBike.AutoSize = true;
            this.labelIdBike.Location = new System.Drawing.Point(727, 221);
            this.labelIdBike.Name = "labelIdBike";
            this.labelIdBike.Size = new System.Drawing.Size(40, 13);
            this.labelIdBike.TabIndex = 12;
            this.labelIdBike.Text = "Bike Id";
            // 
            // APower
            // 
            this.APower.AutoSize = true;
            this.APower.Checked = true;
            this.APower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.APower.Location = new System.Drawing.Point(741, 78);
            this.APower.Name = "APower";
            this.APower.Size = new System.Drawing.Size(15, 14);
            this.APower.TabIndex = 11;
            this.APower.UseVisualStyleBackColor = true;
            this.APower.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // CPower
            // 
            this.CPower.AutoSize = true;
            this.CPower.Checked = true;
            this.CPower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CPower.Location = new System.Drawing.Point(741, 64);
            this.CPower.Name = "CPower";
            this.CPower.Size = new System.Drawing.Size(15, 14);
            this.CPower.TabIndex = 10;
            this.CPower.UseVisualStyleBackColor = true;
            this.CPower.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Distance
            // 
            this.Distance.AutoSize = true;
            this.Distance.Checked = true;
            this.Distance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Distance.Location = new System.Drawing.Point(741, 50);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(15, 14);
            this.Distance.TabIndex = 9;
            this.Distance.UseVisualStyleBackColor = true;
            this.Distance.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Checked = true;
            this.Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Speed.Location = new System.Drawing.Point(741, 36);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(15, 14);
            this.Speed.TabIndex = 8;
            this.Speed.UseVisualStyleBackColor = true;
            this.Speed.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // BPM
            // 
            this.BPM.AutoSize = true;
            this.BPM.Checked = true;
            this.BPM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BPM.Location = new System.Drawing.Point(741, 22);
            this.BPM.Name = "BPM";
            this.BPM.Size = new System.Drawing.Size(15, 14);
            this.BPM.TabIndex = 7;
            this.BPM.UseVisualStyleBackColor = true;
            this.BPM.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(730, 263);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(171, 23);
            this.start.TabIndex = 6;
            this.start.Text = "Start Bike";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(6, 6);
            this.chart.Name = "chart";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "BPM";
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "Speed";
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "Distance";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "Current Power";
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Legend = "Legend1";
            series11.Name = "Acumilated Power";
            series12.BorderWidth = 3;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "VO2";
            this.chart.Series.Add(series7);
            this.chart.Series.Add(series8);
            this.chart.Series.Add(series9);
            this.chart.Series.Add(series10);
            this.chart.Series.Add(series11);
            this.chart.Series.Add(series12);
            this.chart.Size = new System.Drawing.Size(912, 388);
            this.chart.TabIndex = 4;
            this.chart.Text = "Session Chart";
            // 
            // onlineNames
            // 
            this.onlineNames.Location = new System.Drawing.Point(950, 64);
            this.onlineNames.Name = "onlineNames";
            this.onlineNames.Size = new System.Drawing.Size(171, 97);
            this.onlineNames.TabIndex = 1;
            this.onlineNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnlineNames_AfterSelect);
            // 
            // labelOnline
            // 
            this.labelOnline.AutoSize = true;
            this.labelOnline.Location = new System.Drawing.Point(950, 48);
            this.labelOnline.Name = "labelOnline";
            this.labelOnline.Size = new System.Drawing.Size(37, 13);
            this.labelOnline.TabIndex = 2;
            this.labelOnline.Text = "Online";
            // 
            // labelOffline
            // 
            this.labelOffline.AutoSize = true;
            this.labelOffline.Location = new System.Drawing.Point(950, 164);
            this.labelOffline.Name = "labelOffline";
            this.labelOffline.Size = new System.Drawing.Size(18, 13);
            this.labelOffline.TabIndex = 3;
            this.labelOffline.Text = "All";
            // 
            // offlineNames
            // 
            this.offlineNames.Location = new System.Drawing.Point(950, 181);
            this.offlineNames.Name = "offlineNames";
            this.offlineNames.Size = new System.Drawing.Size(171, 254);
            this.offlineNames.TabIndex = 4;
            this.offlineNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OfflineNames_AfterSelect);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(951, 22);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(170, 23);
            this.Refresh.TabIndex = 5;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(730, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Start Simulation";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(730, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 29);
            this.button2.TabIndex = 20;
            this.button2.Text = "STOP";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DocterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 450);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.offlineNames);
            this.Controls.Add(this.labelOffline);
            this.Controls.Add(this.labelOnline);
            this.Controls.Add(this.onlineNames);
            this.Controls.Add(this.tabControl);
            this.Name = "DocterForm";
            this.Text = "DocterForm";
            this.Load += new System.EventHandler(this.docterForm_Load);
            this.tabControl.ResumeLayout(false);
            this.graph.ResumeLayout(false);
            this.graph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage history;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage graph;
        private System.Windows.Forms.TreeView onlineNames;
        private System.Windows.Forms.Label labelOnline;
        private System.Windows.Forms.Label labelOffline;
        private System.Windows.Forms.TreeView offlineNames;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.CheckBox APower;
        private System.Windows.Forms.CheckBox CPower;
        private System.Windows.Forms.CheckBox Distance;
        private System.Windows.Forms.CheckBox Speed;
        private System.Windows.Forms.CheckBox BPM;
        private System.Windows.Forms.TextBox idBike;
        private System.Windows.Forms.Label labelIdBike;
        private System.Windows.Forms.CheckBox VO2;
        private System.Windows.Forms.Label gender;
        private System.Windows.Forms.Label weight;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

