namespace RHDocter
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.history = new System.Windows.Forms.TabPage();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.Input = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.graph = new System.Windows.Forms.TabPage();
            this.error = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.gender = new System.Windows.Forms.Label();
            this.weight = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.VO2 = new System.Windows.Forms.CheckBox();
            this.bikeId = new System.Windows.Forms.TextBox();
            this.labelBikeId = new System.Windows.Forms.Label();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.coverPanel = new System.Windows.Forms.Panel();
            this.login_name = new System.Windows.Forms.TextBox();
            this.login_password = new System.Windows.Forms.TextBox();
            this.login_loginbutton = new System.Windows.Forms.Button();
            this.login_namelabel = new System.Windows.Forms.Label();
            this.login_passwordlanel = new System.Windows.Forms.Label();
            this.login_statuslabel = new System.Windows.Forms.Label();
            this.history.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.coverPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // history
            // 
            this.history.Controls.Add(this.chat);
            this.history.Controls.Add(this.Input);
            this.history.Location = new System.Drawing.Point(4, 22);
            this.history.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.history.Name = "history";
            this.history.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.history.Size = new System.Drawing.Size(1235, 498);
            this.history.TabIndex = 1;
            this.history.Text = "Chat";
            this.history.UseVisualStyleBackColor = true;
            // 
            // chat
            // 
            this.chat.Location = new System.Drawing.Point(9, 7);
            this.chat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(1213, 445);
            this.chat.TabIndex = 1;
            this.chat.Text = "";
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(9, 460);
            this.Input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(1213, 22);
            this.Input.TabIndex = 0;
            this.Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.graph);
            this.tabControl.Controls.Add(this.history);
            this.tabControl.ItemSize = new System.Drawing.Size(100, 18);
            this.tabControl.Location = new System.Drawing.Point(16, 16);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1243, 524);
            this.tabControl.TabIndex = 0;
            // 
            // graph
            // 
            this.graph.Controls.Add(this.error);
            this.graph.Controls.Add(this.button2);
            this.graph.Controls.Add(this.gender);
            this.graph.Controls.Add(this.weight);
            this.graph.Controls.Add(this.age);
            this.graph.Controls.Add(this.name);
            this.graph.Controls.Add(this.VO2);
            this.graph.Controls.Add(this.bikeId);
            this.graph.Controls.Add(this.labelBikeId);
            this.graph.Controls.Add(this.APower);
            this.graph.Controls.Add(this.CPower);
            this.graph.Controls.Add(this.Distance);
            this.graph.Controls.Add(this.Speed);
            this.graph.Controls.Add(this.BPM);
            this.graph.Controls.Add(this.start);
            this.graph.Controls.Add(this.chart);
            this.graph.Location = new System.Drawing.Point(4, 22);
            this.graph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graph.Name = "graph";
            this.graph.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graph.Size = new System.Drawing.Size(1235, 498);
            this.graph.TabIndex = 0;
            this.graph.Text = "Graph";
            this.graph.UseVisualStyleBackColor = true;
            // 
            // error
            // 
            this.error.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(969, 231);
            this.error.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.error.Name = "error";
            this.error.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.error.Size = new System.Drawing.Size(233, 62);
            this.error.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(973, 396);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 36);
            this.button2.TabIndex = 20;
            this.button2.Text = "STOP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Stop_Click);
            // 
            // gender
            // 
            this.gender.AutoSize = true;
            this.gender.Location = new System.Drawing.Point(969, 201);
            this.gender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(60, 17);
            this.gender.TabIndex = 18;
            this.gender.Text = "Gender:";
            // 
            // weight
            // 
            this.weight.AutoSize = true;
            this.weight.Location = new System.Drawing.Point(969, 180);
            this.weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(60, 17);
            this.weight.TabIndex = 17;
            this.weight.Text = "Weight: ";
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Location = new System.Drawing.Point(969, 159);
            this.age.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(41, 17);
            this.age.TabIndex = 16;
            this.age.Text = "Age: ";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(969, 139);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(49, 17);
            this.name.TabIndex = 15;
            this.name.Text = "Name:";
            // 
            // VO2
            // 
            this.VO2.AutoSize = true;
            this.VO2.Checked = true;
            this.VO2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VO2.Location = new System.Drawing.Point(988, 113);
            this.VO2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VO2.Name = "VO2";
            this.VO2.Size = new System.Drawing.Size(18, 17);
            this.VO2.TabIndex = 14;
            this.VO2.UseVisualStyleBackColor = true;
            this.VO2.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // bikeId
            // 
            this.bikeId.Location = new System.Drawing.Point(973, 329);
            this.bikeId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bikeId.Name = "bikeId";
            this.bikeId.Size = new System.Drawing.Size(227, 22);
            this.bikeId.TabIndex = 13;
            // 
            // labelBikeId
            // 
            this.labelBikeId.AutoSize = true;
            this.labelBikeId.Location = new System.Drawing.Point(969, 309);
            this.labelBikeId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBikeId.Name = "labelBikeId";
            this.labelBikeId.Size = new System.Drawing.Size(50, 17);
            this.labelBikeId.TabIndex = 12;
            this.labelBikeId.Text = "Bike Id";
            // 
            // APower
            // 
            this.APower.AutoSize = true;
            this.APower.Checked = true;
            this.APower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.APower.Location = new System.Drawing.Point(988, 96);
            this.APower.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.APower.Name = "APower";
            this.APower.Size = new System.Drawing.Size(18, 17);
            this.APower.TabIndex = 11;
            this.APower.UseVisualStyleBackColor = true;
            this.APower.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // CPower
            // 
            this.CPower.AutoSize = true;
            this.CPower.Checked = true;
            this.CPower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CPower.Location = new System.Drawing.Point(988, 79);
            this.CPower.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CPower.Name = "CPower";
            this.CPower.Size = new System.Drawing.Size(18, 17);
            this.CPower.TabIndex = 10;
            this.CPower.UseVisualStyleBackColor = true;
            this.CPower.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Distance
            // 
            this.Distance.AutoSize = true;
            this.Distance.Checked = true;
            this.Distance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Distance.Location = new System.Drawing.Point(988, 62);
            this.Distance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(18, 17);
            this.Distance.TabIndex = 9;
            this.Distance.UseVisualStyleBackColor = true;
            this.Distance.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Checked = true;
            this.Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Speed.Location = new System.Drawing.Point(988, 44);
            this.Speed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(18, 17);
            this.Speed.TabIndex = 8;
            this.Speed.UseVisualStyleBackColor = true;
            this.Speed.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // BPM
            // 
            this.BPM.AutoSize = true;
            this.BPM.Checked = true;
            this.BPM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BPM.Location = new System.Drawing.Point(988, 27);
            this.BPM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BPM.Name = "BPM";
            this.BPM.Size = new System.Drawing.Size(18, 17);
            this.BPM.TabIndex = 7;
            this.BPM.UseVisualStyleBackColor = true;
            this.BPM.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(973, 361);
            this.start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(228, 28);
            this.start.TabIndex = 6;
            this.start.Text = "Start Ästrand Test";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(8, 7);
            this.chart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.chart.Size = new System.Drawing.Size(1216, 478);
            this.chart.TabIndex = 4;
            this.chart.Text = "Session Chart";
            // 
            // onlineNames
            // 
            this.onlineNames.Location = new System.Drawing.Point(1267, 79);
            this.onlineNames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.onlineNames.Name = "onlineNames";
            this.onlineNames.Size = new System.Drawing.Size(227, 118);
            this.onlineNames.TabIndex = 1;
            this.onlineNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnlineNames_AfterSelect);
            // 
            // labelOnline
            // 
            this.labelOnline.AutoSize = true;
            this.labelOnline.Location = new System.Drawing.Point(1267, 59);
            this.labelOnline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOnline.Name = "labelOnline";
            this.labelOnline.Size = new System.Drawing.Size(49, 17);
            this.labelOnline.TabIndex = 2;
            this.labelOnline.Text = "Online";
            // 
            // labelOffline
            // 
            this.labelOffline.AutoSize = true;
            this.labelOffline.Location = new System.Drawing.Point(1267, 202);
            this.labelOffline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOffline.Name = "labelOffline";
            this.labelOffline.Size = new System.Drawing.Size(23, 17);
            this.labelOffline.TabIndex = 3;
            this.labelOffline.Text = "All";
            // 
            // offlineNames
            // 
            this.offlineNames.Location = new System.Drawing.Point(1267, 223);
            this.offlineNames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.offlineNames.Name = "offlineNames";
            this.offlineNames.Size = new System.Drawing.Size(227, 312);
            this.offlineNames.TabIndex = 4;
            this.offlineNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OfflineNames_AfterSelect);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(1268, 27);
            this.Refresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(227, 28);
            this.Refresh.TabIndex = 5;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // coverPanel
            // 
            this.coverPanel.Controls.Add(this.login_statuslabel);
            this.coverPanel.Controls.Add(this.login_passwordlanel);
            this.coverPanel.Controls.Add(this.login_namelabel);
            this.coverPanel.Controls.Add(this.login_loginbutton);
            this.coverPanel.Controls.Add(this.login_password);
            this.coverPanel.Controls.Add(this.login_name);
            this.coverPanel.Location = new System.Drawing.Point(16, -69);
            this.coverPanel.Name = "coverPanel";
            this.coverPanel.Size = new System.Drawing.Size(1511, 611);
            this.coverPanel.TabIndex = 6;
            // 
            // login_name
            // 
            this.login_name.Location = new System.Drawing.Point(513, 233);
            this.login_name.Name = "login_name";
            this.login_name.Size = new System.Drawing.Size(100, 22);
            this.login_name.TabIndex = 0;
            // 
            // login_password
            // 
            this.login_password.Location = new System.Drawing.Point(513, 261);
            this.login_password.Name = "login_password";
            this.login_password.PasswordChar = '*';
            this.login_password.Size = new System.Drawing.Size(100, 22);
            this.login_password.TabIndex = 1;
            // 
            // login_loginbutton
            // 
            this.login_loginbutton.Location = new System.Drawing.Point(513, 292);
            this.login_loginbutton.Name = "login_loginbutton";
            this.login_loginbutton.Size = new System.Drawing.Size(100, 25);
            this.login_loginbutton.TabIndex = 2;
            this.login_loginbutton.Text = "Login";
            this.login_loginbutton.UseVisualStyleBackColor = true;
            this.login_loginbutton.Click += new System.EventHandler(this.Login_loginbutton_Click);
            // 
            // login_namelabel
            // 
            this.login_namelabel.AutoSize = true;
            this.login_namelabel.Location = new System.Drawing.Point(454, 236);
            this.login_namelabel.Name = "login_namelabel";
            this.login_namelabel.Size = new System.Drawing.Size(53, 17);
            this.login_namelabel.TabIndex = 3;
            this.login_namelabel.Text = "Name: ";
            // 
            // login_passwordlanel
            // 
            this.login_passwordlanel.AutoSize = true;
            this.login_passwordlanel.Location = new System.Drawing.Point(430, 264);
            this.login_passwordlanel.Name = "login_passwordlanel";
            this.login_passwordlanel.Size = new System.Drawing.Size(77, 17);
            this.login_passwordlanel.TabIndex = 4;
            this.login_passwordlanel.Text = "Password: ";
            // 
            // login_statuslabel
            // 
            this.login_statuslabel.AutoSize = true;
            this.login_statuslabel.Location = new System.Drawing.Point(430, 296);
            this.login_statuslabel.Name = "login_statuslabel";
            this.login_statuslabel.Size = new System.Drawing.Size(0, 17);
            this.login_statuslabel.TabIndex = 5;
            // 
            // DocterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 554);
            this.Controls.Add(this.coverPanel);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.offlineNames);
            this.Controls.Add(this.labelOffline);
            this.Controls.Add(this.labelOnline);
            this.Controls.Add(this.onlineNames);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DocterForm";
            this.Text = "DocterForm";
            this.Load += new System.EventHandler(this.docterForm_Load);
            this.history.ResumeLayout(false);
            this.history.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.graph.ResumeLayout(false);
            this.graph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.coverPanel.ResumeLayout(false);
            this.coverPanel.PerformLayout();
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
        private System.Windows.Forms.TextBox bikeId;
        private System.Windows.Forms.Label labelBikeId;
        private System.Windows.Forms.CheckBox VO2;
        private System.Windows.Forms.Label gender;
        private System.Windows.Forms.Label weight;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox chat;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Panel coverPanel;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.TextBox login_name;
        private System.Windows.Forms.Label login_passwordlanel;
        private System.Windows.Forms.Label login_namelabel;
        private System.Windows.Forms.Button login_loginbutton;
        private System.Windows.Forms.Label login_statuslabel;
    }
}

