namespace SingleDeviceApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel7 = new System.Windows.Forms.Panel();
            this.countDownClock1 = new SingleDeviceApp.CountDownClock();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pulseBar = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.IDValue = new System.Windows.Forms.Label();
            this.HRValue = new System.Windows.Forms.Label();
            this.SPO2Value = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart = new SingleDeviceApp.SignalChart();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RFPortBtn = new System.Windows.Forms.Button();
            this.portCBox = new System.Windows.Forms.ComboBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.RecordBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.idTxt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.countDownClock = new SingleDeviceApp.CountDownClock();
            this.label9 = new System.Windows.Forms.Label();
            this.pulseHeart = new System.Windows.Forms.Timer(this.components);
            this.panel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.countDownClock1);
            this.panel7.Location = new System.Drawing.Point(2571, 32271);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(357, 158);
            this.panel7.TabIndex = 27;
            // 
            // countDownClock1
            // 
            this.countDownClock1.Dock = System.Windows.Forms.DockStyle.Left;
            this.countDownClock1.Location = new System.Drawing.Point(0, 0);
            this.countDownClock1.Margin = new System.Windows.Forms.Padding(0);
            this.countDownClock1.Name = "countDownClock1";
            this.countDownClock1.Size = new System.Drawing.Size(369, 158);
            this.countDownClock1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.pulseBar);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.IDValue);
            this.groupBox2.Controls.Add(this.HRValue);
            this.groupBox2.Controls.Add(this.SPO2Value);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(670, 130);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox2.Size = new System.Drawing.Size(283, 238);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // pulseBar
            // 
            this.pulseBar.Location = new System.Drawing.Point(139, 192);
            this.pulseBar.Name = "pulseBar";
            this.pulseBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pulseBar.Size = new System.Drawing.Size(100, 23);
            this.pulseBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pulseBar.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 15F);
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(9, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 58;
            this.label8.Text = "Pulse:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(56, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 23);
            this.label7.TabIndex = 56;
            this.label7.Text = "Measurement Index";
            // 
            // IDValue
            // 
            this.IDValue.AutoSize = true;
            this.IDValue.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDValue.ForeColor = System.Drawing.Color.Red;
            this.IDValue.Location = new System.Drawing.Point(166, 63);
            this.IDValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IDValue.Name = "IDValue";
            this.IDValue.Size = new System.Drawing.Size(24, 25);
            this.IDValue.TabIndex = 9;
            this.IDValue.Text = "0";
            // 
            // HRValue
            // 
            this.HRValue.AutoSize = true;
            this.HRValue.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HRValue.ForeColor = System.Drawing.Color.Red;
            this.HRValue.Location = new System.Drawing.Point(166, 107);
            this.HRValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HRValue.Name = "HRValue";
            this.HRValue.Size = new System.Drawing.Size(24, 25);
            this.HRValue.TabIndex = 9;
            this.HRValue.Text = "0";
            // 
            // SPO2Value
            // 
            this.SPO2Value.AutoSize = true;
            this.SPO2Value.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SPO2Value.ForeColor = System.Drawing.Color.Red;
            this.SPO2Value.Location = new System.Drawing.Point(166, 148);
            this.SPO2Value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SPO2Value.Name = "SPO2Value";
            this.SPO2Value.Size = new System.Drawing.Size(24, 25);
            this.SPO2Value.TabIndex = 9;
            this.SPO2Value.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15F);
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(9, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Device Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(9, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Heart Rate:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 15F);
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(9, 149);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 23);
            this.label12.TabIndex = 8;
            this.label12.Text = "SPO2:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart);
            this.panel1.Location = new System.Drawing.Point(-10, 453);
            this.panel1.Margin = new System.Windows.Forms.Padding(7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 302);
            this.panel1.TabIndex = 47;
            // 
            // chart
            // 
            this.chart.AutoSize = true;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(19, 16, 19, 16);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(996, 302);
            this.chart.TabIndex = 0;
            // 
            // PauseBtn
            // 
            this.PauseBtn.Enabled = false;
            this.PauseBtn.Font = new System.Drawing.Font("Arial", 13F);
            this.PauseBtn.Location = new System.Drawing.Point(501, 116);
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(7);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(140, 40);
            this.PauseBtn.TabIndex = 46;
            this.PauseBtn.Text = "Pause Record";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseRecord);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(80, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 45;
            this.label2.Text = "Device:";
            // 
            // RFPortBtn
            // 
            this.RFPortBtn.Font = new System.Drawing.Font("Arial", 13F);
            this.RFPortBtn.Location = new System.Drawing.Point(501, 42);
            this.RFPortBtn.Margin = new System.Windows.Forms.Padding(7);
            this.RFPortBtn.Name = "RFPortBtn";
            this.RFPortBtn.Size = new System.Drawing.Size(140, 40);
            this.RFPortBtn.TabIndex = 44;
            this.RFPortBtn.Text = "Reload Port";
            this.RFPortBtn.UseVisualStyleBackColor = true;
            this.RFPortBtn.Click += new System.EventHandler(this.ReloadPort);
            // 
            // portCBox
            // 
            this.portCBox.Font = new System.Drawing.Font("Arial", 15F);
            this.portCBox.FormattingEnabled = true;
            this.portCBox.Location = new System.Drawing.Point(169, 46);
            this.portCBox.Margin = new System.Windows.Forms.Padding(7);
            this.portCBox.Name = "portCBox";
            this.portCBox.Size = new System.Drawing.Size(127, 31);
            this.portCBox.TabIndex = 43;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Arial", 15F);
            this.PortLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.PortLabel.Location = new System.Drawing.Point(80, 46);
            this.PortLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(53, 23);
            this.PortLabel.TabIndex = 42;
            this.PortLabel.Text = "Port:";
            // 
            // StopBtn
            // 
            this.StopBtn.Font = new System.Drawing.Font("Arial", 13F);
            this.StopBtn.Location = new System.Drawing.Point(332, 116);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(7);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(120, 40);
            this.StopBtn.TabIndex = 41;
            this.StopBtn.Text = "Stop Record";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopArduino);
            // 
            // RecordBtn
            // 
            this.RecordBtn.Enabled = false;
            this.RecordBtn.Font = new System.Drawing.Font("Arial", 13F);
            this.RecordBtn.Location = new System.Drawing.Point(169, 117);
            this.RecordBtn.Margin = new System.Windows.Forms.Padding(7);
            this.RecordBtn.Name = "RecordBtn";
            this.RecordBtn.Size = new System.Drawing.Size(120, 40);
            this.RecordBtn.TabIndex = 40;
            this.RecordBtn.Text = "New Record";
            this.RecordBtn.UseVisualStyleBackColor = true;
            this.RecordBtn.Click += new System.EventHandler(this.ReadArduino);
            // 
            // connectBtn
            // 
            this.connectBtn.Font = new System.Drawing.Font("Arial", 13F);
            this.connectBtn.Location = new System.Drawing.Point(332, 42);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(7);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(120, 40);
            this.connectBtn.TabIndex = 39;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F);
            this.label3.Location = new System.Drawing.Point(80, 320);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 50;
            this.label3.Text = "Time:";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Font = new System.Drawing.Font("Arial", 13F);
            this.SaveBtn.Location = new System.Drawing.Point(512, 206);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(7);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(120, 68);
            this.SaveBtn.TabIndex = 51;
            this.SaveBtn.Text = "Save Record";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveData);
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(169, 195);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(283, 30);
            this.nameTxt.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(80, 196);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 53;
            this.label5.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(80, 257);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 23);
            this.label6.TabIndex = 55;
            this.label6.Text = "ID:";
            // 
            // idTxt
            // 
            this.idTxt.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTxt.Location = new System.Drawing.Point(169, 256);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(283, 30);
            this.idTxt.TabIndex = 54;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SingleMedicalDevice.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(760, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // countDownClock
            // 
            this.countDownClock.Location = new System.Drawing.Point(147, 307);
            this.countDownClock.Margin = new System.Windows.Forms.Padding(2);
            this.countDownClock.Name = "countDownClock";
            this.countDownClock.Size = new System.Drawing.Size(286, 70);
            this.countDownClock.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 25F);
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(409, 407);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 39);
            this.label9.TabIndex = 57;
            this.label9.Text = "PPG PLOT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.countDownClock);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RFPortBtn);
            this.Controls.Add(this.portCBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.RecordBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " IUD Pulse Oximeter Sampling";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel7;
        private CountDownClock countDownClock1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label SPO2Value;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private SignalChart chart;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RFPortBtn;
        private System.Windows.Forms.ComboBox portCBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button RecordBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label IDValue;
        private System.Windows.Forms.Label HRValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private CountDownClock countDownClock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox idTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar pulseBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer pulseHeart;
    }
}

