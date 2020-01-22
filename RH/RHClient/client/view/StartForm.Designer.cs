namespace RHClient
{
    partial class StartForm
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
            this.createSession = new System.Windows.Forms.Button();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.weight = new System.Windows.Forms.TextBox();
            this.gender = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // createSession
            // 
            this.createSession.Location = new System.Drawing.Point(12, 212);
            this.createSession.Name = "createSession";
            this.createSession.Size = new System.Drawing.Size(246, 23);
            this.createSession.TabIndex = 0;
            this.createSession.Text = "createSession";
            this.createSession.UseVisualStyleBackColor = true;
            this.createSession.Click += new System.EventHandler(this.createSession_Click);
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(12, 169);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(42, 13);
            this.labelGender.TabIndex = 3;
            this.labelGender.Text = "Gender";
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(12, 130);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(41, 13);
            this.labelWeight.TabIndex = 4;
            this.labelWeight.Text = "Weight";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(12, 91);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(26, 13);
            this.labelAge.TabIndex = 6;
            this.labelAge.Text = "Age";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 52);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name";
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(12, 15);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(0, 13);
            this.error.TabIndex = 9;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(15, 68);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(243, 20);
            this.name.TabIndex = 10;
            // 
            // age
            // 
            this.age.Location = new System.Drawing.Point(15, 108);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(243, 20);
            this.age.TabIndex = 11;
            // 
            // weight
            // 
            this.weight.Location = new System.Drawing.Point(15, 147);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(241, 20);
            this.weight.TabIndex = 12;
            // 
            // gender
            // 
            this.gender.FormattingEnabled = true;
            this.gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.gender.Location = new System.Drawing.Point(15, 185);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(241, 21);
            this.gender.TabIndex = 13;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 247);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.weight);
            this.Controls.Add(this.age);
            this.Controls.Add(this.name);
            this.Controls.Add(this.error);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.createSession);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.startForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createSession;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.TextBox weight;
        private System.Windows.Forms.ComboBox gender;
    }
}

