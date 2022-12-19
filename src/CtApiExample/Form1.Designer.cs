namespace CtApiExample
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmdRead = new System.Windows.Forms.Button();
            this.cmdWrite = new System.Windows.Forms.Button();
            this.cmbTag = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblUnknown = new System.Windows.Forms.Label();
            this.lblOffline = new System.Windows.Forms.Label();
            this.lblOnline = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstAlarms = new System.Windows.Forms.ListView();
            this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAlarm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEquipment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAcknowledge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TheTextBox = new System.Windows.Forms.TextBox();
            this.Stoptm = new System.Windows.Forms.Button();
            this.btnTick = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.cmdRead);
            this.groupBox1.Controls.Add(this.cmdWrite);
            this.groupBox1.Controls.Add(this.cmbTag);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(912, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(36, 10);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read/Write Tags";
            this.groupBox1.Visible = false;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(44, 49);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 1;
            // 
            // cmdRead
            // 
            this.cmdRead.Location = new System.Drawing.Point(231, 49);
            this.cmdRead.Name = "cmdRead";
            this.cmdRead.Size = new System.Drawing.Size(75, 23);
            this.cmdRead.TabIndex = 2;
            this.cmdRead.Text = "Read";
            this.cmdRead.UseVisualStyleBackColor = true;
            this.cmdRead.Click += new System.EventHandler(this.cmdRead_Click);
            // 
            // cmdWrite
            // 
            this.cmdWrite.Location = new System.Drawing.Point(150, 49);
            this.cmdWrite.Name = "cmdWrite";
            this.cmdWrite.Size = new System.Drawing.Size(75, 23);
            this.cmdWrite.TabIndex = 3;
            this.cmdWrite.Text = "Write";
            this.cmdWrite.UseVisualStyleBackColor = true;
            this.cmdWrite.Click += new System.EventHandler(this.cmdWrite_Click);
            // 
            // cmbTag
            // 
            this.cmbTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag.FormattingEnabled = true;
            this.cmbTag.Location = new System.Drawing.Point(44, 19);
            this.cmbTag.Name = "cmbTag";
            this.cmbTag.Size = new System.Drawing.Size(163, 21);
            this.cmbTag.TabIndex = 0;
            this.cmbTag.SelectedIndexChanged += new System.EventHandler(this.cmbTag_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tag: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblUnknown);
            this.groupBox2.Controls.Add(this.lblOffline);
            this.groupBox2.Controls.Add(this.lblOnline);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbDevice);
            this.groupBox2.Location = new System.Drawing.Point(912, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(13, 14);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device Status (uses RunCicode())";
            this.groupBox2.Visible = false;
            // 
            // lblUnknown
            // 
            this.lblUnknown.AutoSize = true;
            this.lblUnknown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnknown.ForeColor = System.Drawing.Color.Orange;
            this.lblUnknown.Location = new System.Drawing.Point(134, 50);
            this.lblUnknown.Name = "lblUnknown";
            this.lblUnknown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUnknown.Size = new System.Drawing.Size(72, 13);
            this.lblUnknown.TabIndex = 2;
            this.lblUnknown.Text = "UNKNOWN";
            // 
            // lblOffline
            // 
            this.lblOffline.AutoSize = true;
            this.lblOffline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffline.ForeColor = System.Drawing.Color.Red;
            this.lblOffline.Location = new System.Drawing.Point(73, 50);
            this.lblOffline.Name = "lblOffline";
            this.lblOffline.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblOffline.Size = new System.Drawing.Size(58, 13);
            this.lblOffline.TabIndex = 2;
            this.lblOffline.Text = "OFFLINE";
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnline.ForeColor = System.Drawing.Color.Blue;
            this.lblOnline.Location = new System.Drawing.Point(17, 50);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblOnline.Size = new System.Drawing.Size(53, 13);
            this.lblOnline.TabIndex = 2;
            this.lblOnline.Text = "ONLINE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Device: ";
            // 
            // cmbDevice
            // 
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(53, 23);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(138, 21);
            this.cmbDevice.TabIndex = 4;
            this.cmbDevice.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstAlarms);
            this.groupBox3.Location = new System.Drawing.Point(12, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(913, 212);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alarms";
            // 
            // lstAlarms
            // 
            this.lstAlarms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDate,
            this.clmAlarm,
            this.clmEquipment,
            this.clmState,
            this.clmAcknowledge});
            this.lstAlarms.FullRowSelect = true;
            this.lstAlarms.HideSelection = false;
            this.lstAlarms.Location = new System.Drawing.Point(6, 19);
            this.lstAlarms.MultiSelect = false;
            this.lstAlarms.Name = "lstAlarms";
            this.lstAlarms.Size = new System.Drawing.Size(901, 187);
            this.lstAlarms.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstAlarms.TabIndex = 0;
            this.lstAlarms.UseCompatibleStateImageBehavior = false;
            this.lstAlarms.View = System.Windows.Forms.View.Details;
            // 
            // clmDate
            // 
            this.clmDate.Text = "Date";
            this.clmDate.Width = 150;
            // 
            // clmAlarm
            // 
            this.clmAlarm.Text = "Alarm";
            this.clmAlarm.Width = 149;
            // 
            // clmEquipment
            // 
            this.clmEquipment.Text = "Equipment";
            this.clmEquipment.Width = 119;
            // 
            // clmState
            // 
            this.clmState.Text = "State";
            this.clmState.Width = 64;
            // 
            // clmAcknowledge
            // 
            this.clmAcknowledge.Text = "Ack";
            this.clmAcknowledge.Width = 133;
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Interval = 2000;
            this.tmrAlarm.Tick += new System.EventHandler(this.tmrAlarm_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TheTextBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 316);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(913, 214);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Logs";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // TheTextBox
            // 
            this.TheTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TheTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TheTextBox.Location = new System.Drawing.Point(3, 16);
            this.TheTextBox.Multiline = true;
            this.TheTextBox.Name = "TheTextBox";
            this.TheTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TheTextBox.Size = new System.Drawing.Size(907, 195);
            this.TheTextBox.TabIndex = 0;
            // 
            // Stoptm
            // 
            this.Stoptm.Location = new System.Drawing.Point(809, 29);
            this.Stoptm.Name = "Stoptm";
            this.Stoptm.Size = new System.Drawing.Size(123, 23);
            this.Stoptm.TabIndex = 4;
            this.Stoptm.Text = "Pull Alarm Once";
            this.Stoptm.UseVisualStyleBackColor = true;
            this.Stoptm.Visible = false;
            this.Stoptm.Click += new System.EventHandler(this.Stoptm_Click);
            // 
            // btnTick
            // 
            this.btnTick.Location = new System.Drawing.Point(809, 55);
            this.btnTick.Name = "btnTick";
            this.btnTick.Size = new System.Drawing.Size(123, 23);
            this.btnTick.TabIndex = 5;
            this.btnTick.Text = "Pull Alarm Realtime";
            this.btnTick.UseVisualStyleBackColor = true;
            this.btnTick.Visible = false;
            this.btnTick.Click += new System.EventHandler(this.btnTick_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.btnConn);
            this.groupBox5.Controls.Add(this.txtPwd);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtIp);
            this.groupBox5.Controls.Add(this.txtUser);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(18, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(391, 80);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Connect PO";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(303, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(303, 22);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 6;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(198, 50);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 20);
            this.txtPwd.TabIndex = 5;
            this.txtPwd.Text = "admin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Pwd:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(49, 22);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(249, 20);
            this.txtIp.TabIndex = 3;
            this.txtIp.Text = "10.10.1.225";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(49, 49);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "admin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "User:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ip: ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button6);
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Location = new System.Drawing.Point(415, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(436, 80);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Alarms";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(136, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(123, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Alarms2CSV";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(265, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 21);
            this.button4.TabIndex = 8;
            this.button4.Text = "Alarms2DB";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Timer Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Timer Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(135, 49);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(123, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "GetLashError";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 542);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Stoptm);
            this.Controls.Add(this.btnTick);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Simple ctAPI Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdRead;
        private System.Windows.Forms.Button cmdWrite;
        private System.Windows.Forms.ComboBox cmbTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblUnknown;
        private System.Windows.Forms.Label lblOffline;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstAlarms;
        private System.Windows.Forms.ColumnHeader clmDate;
        private System.Windows.Forms.ColumnHeader clmAlarm;
        private System.Windows.Forms.ColumnHeader clmState;
        private System.Windows.Forms.Timer tmrAlarm;
        private System.Windows.Forms.ColumnHeader clmAcknowledge;
        private System.Windows.Forms.ColumnHeader clmEquipment;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TheTextBox;
        private System.Windows.Forms.Button Stoptm;
        private System.Windows.Forms.Button btnTick;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

