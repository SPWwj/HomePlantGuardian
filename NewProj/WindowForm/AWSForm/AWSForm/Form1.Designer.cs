namespace AWSForm
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
            this.groupLCD = new System.Windows.Forms.GroupBox();
            this.textLCD = new System.Windows.Forms.TextBox();
            this.btnLCDWrite = new System.Windows.Forms.Button();
            this.groupSerial = new System.Windows.Forms.GroupBox();
            this.lbIndicator = new System.Windows.Forms.Label();
            this.btnPortRefresh = new System.Windows.Forms.Button();
            this.comboSerial = new System.Windows.Forms.ComboBox();
            this.btnSerialCon = new System.Windows.Forms.Button();
            this.groupCover = new System.Windows.Forms.GroupBox();
            this.btnCoverToggle = new System.Windows.Forms.Button();
            this.groupPump = new System.Windows.Forms.GroupBox();
            this.btnTogglePump = new System.Windows.Forms.Button();
            this.groupThreshold = new System.Windows.Forms.GroupBox();
            this.textPumpThreshold = new System.Windows.Forms.TextBox();
            this.btnSoilThreshold = new System.Windows.Forms.Button();
            this.textCoverThreshold = new System.Windows.Forms.TextBox();
            this.btnRainThreshold = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textSerialRead = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnClearSerialRead = new System.Windows.Forms.Button();
            this.btnGetStates = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.textSend = new System.Windows.Forms.TextBox();
            this.groupLCD.SuspendLayout();
            this.groupSerial.SuspendLayout();
            this.groupCover.SuspendLayout();
            this.groupPump.SuspendLayout();
            this.groupThreshold.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLCD
            // 
            this.groupLCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupLCD.Controls.Add(this.textLCD);
            this.groupLCD.Controls.Add(this.btnLCDWrite);
            this.groupLCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupLCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupLCD.Location = new System.Drawing.Point(98, 47);
            this.groupLCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLCD.Name = "groupLCD";
            this.groupLCD.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLCD.Size = new System.Drawing.Size(178, 141);
            this.groupLCD.TabIndex = 13;
            this.groupLCD.TabStop = false;
            this.groupLCD.Text = "LCD 16x2 Control";
            // 
            // textLCD
            // 
            this.textLCD.Location = new System.Drawing.Point(21, 31);
            this.textLCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textLCD.Multiline = true;
            this.textLCD.Name = "textLCD";
            this.textLCD.Size = new System.Drawing.Size(134, 48);
            this.textLCD.TabIndex = 2;
            // 
            // btnLCDWrite
            // 
            this.btnLCDWrite.BackColor = System.Drawing.SystemColors.Control;
            this.btnLCDWrite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLCDWrite.Location = new System.Drawing.Point(21, 88);
            this.btnLCDWrite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLCDWrite.Name = "btnLCDWrite";
            this.btnLCDWrite.Size = new System.Drawing.Size(135, 42);
            this.btnLCDWrite.TabIndex = 4;
            this.btnLCDWrite.Text = "Write";
            this.btnLCDWrite.UseVisualStyleBackColor = false;
            this.btnLCDWrite.Click += new System.EventHandler(this.btnLCDWrite_Click);
            // 
            // groupSerial
            // 
            this.groupSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupSerial.Controls.Add(this.lbIndicator);
            this.groupSerial.Controls.Add(this.btnPortRefresh);
            this.groupSerial.Controls.Add(this.comboSerial);
            this.groupSerial.Controls.Add(this.btnSerialCon);
            this.groupSerial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupSerial.Location = new System.Drawing.Point(98, 217);
            this.groupSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupSerial.Name = "groupSerial";
            this.groupSerial.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupSerial.Size = new System.Drawing.Size(473, 130);
            this.groupSerial.TabIndex = 12;
            this.groupSerial.TabStop = false;
            this.groupSerial.Text = "Serial Connection";
            // 
            // lbIndicator
            // 
            this.lbIndicator.BackColor = System.Drawing.Color.Red;
            this.lbIndicator.Location = new System.Drawing.Point(417, 39);
            this.lbIndicator.Name = "lbIndicator";
            this.lbIndicator.Size = new System.Drawing.Size(30, 42);
            this.lbIndicator.TabIndex = 3;
            // 
            // btnPortRefresh
            // 
            this.btnPortRefresh.Location = new System.Drawing.Point(279, 39);
            this.btnPortRefresh.Name = "btnPortRefresh";
            this.btnPortRefresh.Size = new System.Drawing.Size(136, 42);
            this.btnPortRefresh.TabIndex = 2;
            this.btnPortRefresh.Text = "Refresh Ports";
            this.btnPortRefresh.UseVisualStyleBackColor = true;
            this.btnPortRefresh.Click += new System.EventHandler(this.btnPortRefresh_Click);
            // 
            // comboSerial
            // 
            this.comboSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSerial.FormattingEnabled = true;
            this.comboSerial.Location = new System.Drawing.Point(169, 46);
            this.comboSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboSerial.Name = "comboSerial";
            this.comboSerial.Size = new System.Drawing.Size(104, 28);
            this.comboSerial.TabIndex = 1;
            // 
            // btnSerialCon
            // 
            this.btnSerialCon.Location = new System.Drawing.Point(9, 39);
            this.btnSerialCon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSerialCon.Name = "btnSerialCon";
            this.btnSerialCon.Size = new System.Drawing.Size(153, 42);
            this.btnSerialCon.TabIndex = 0;
            this.btnSerialCon.Text = "Connect";
            this.btnSerialCon.UseVisualStyleBackColor = true;
            this.btnSerialCon.Click += new System.EventHandler(this.btnSerialCon_Click);
            // 
            // groupCover
            // 
            this.groupCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupCover.Controls.Add(this.btnCoverToggle);
            this.groupCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupCover.Location = new System.Drawing.Point(282, 59);
            this.groupCover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCover.Name = "groupCover";
            this.groupCover.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCover.Size = new System.Drawing.Size(149, 129);
            this.groupCover.TabIndex = 11;
            this.groupCover.TabStop = false;
            this.groupCover.Text = "Cover Control";
            // 
            // btnCoverToggle
            // 
            this.btnCoverToggle.BackColor = System.Drawing.SystemColors.Control;
            this.btnCoverToggle.Location = new System.Drawing.Point(26, 44);
            this.btnCoverToggle.Name = "btnCoverToggle";
            this.btnCoverToggle.Size = new System.Drawing.Size(92, 52);
            this.btnCoverToggle.TabIndex = 15;
            this.btnCoverToggle.Text = "To Open";
            this.btnCoverToggle.UseVisualStyleBackColor = false;
            this.btnCoverToggle.Click += new System.EventHandler(this.btnCoverToggle_Click);
            // 
            // groupPump
            // 
            this.groupPump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupPump.Controls.Add(this.btnTogglePump);
            this.groupPump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupPump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupPump.Location = new System.Drawing.Point(437, 59);
            this.groupPump.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPump.Name = "groupPump";
            this.groupPump.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPump.Size = new System.Drawing.Size(134, 129);
            this.groupPump.TabIndex = 14;
            this.groupPump.TabStop = false;
            this.groupPump.Text = "Pump Control";
            // 
            // btnTogglePump
            // 
            this.btnTogglePump.BackColor = System.Drawing.SystemColors.Control;
            this.btnTogglePump.Location = new System.Drawing.Point(16, 44);
            this.btnTogglePump.Name = "btnTogglePump";
            this.btnTogglePump.Size = new System.Drawing.Size(92, 52);
            this.btnTogglePump.TabIndex = 0;
            this.btnTogglePump.Text = "On";
            this.btnTogglePump.UseVisualStyleBackColor = false;
            this.btnTogglePump.Click += new System.EventHandler(this.btnTogglePump_Click);
            // 
            // groupThreshold
            // 
            this.groupThreshold.Controls.Add(this.textPumpThreshold);
            this.groupThreshold.Controls.Add(this.btnSoilThreshold);
            this.groupThreshold.Controls.Add(this.textCoverThreshold);
            this.groupThreshold.Controls.Add(this.btnRainThreshold);
            this.groupThreshold.Location = new System.Drawing.Point(587, 28);
            this.groupThreshold.Name = "groupThreshold";
            this.groupThreshold.Size = new System.Drawing.Size(242, 160);
            this.groupThreshold.TabIndex = 15;
            this.groupThreshold.TabStop = false;
            this.groupThreshold.Text = "Threshold Setting";
            // 
            // textPumpThreshold
            // 
            this.textPumpThreshold.Location = new System.Drawing.Point(121, 98);
            this.textPumpThreshold.Name = "textPumpThreshold";
            this.textPumpThreshold.Size = new System.Drawing.Size(100, 26);
            this.textPumpThreshold.TabIndex = 3;
            // 
            // btnSoilThreshold
            // 
            this.btnSoilThreshold.Location = new System.Drawing.Point(27, 93);
            this.btnSoilThreshold.Name = "btnSoilThreshold";
            this.btnSoilThreshold.Size = new System.Drawing.Size(88, 31);
            this.btnSoilThreshold.TabIndex = 2;
            this.btnSoilThreshold.Text = "Soil";
            this.btnSoilThreshold.UseVisualStyleBackColor = true;
            this.btnSoilThreshold.Click += new System.EventHandler(this.btnSoilThreshold_Click);
            // 
            // textCoverThreshold
            // 
            this.textCoverThreshold.Location = new System.Drawing.Point(121, 51);
            this.textCoverThreshold.Name = "textCoverThreshold";
            this.textCoverThreshold.Size = new System.Drawing.Size(100, 26);
            this.textCoverThreshold.TabIndex = 1;
            // 
            // btnRainThreshold
            // 
            this.btnRainThreshold.Location = new System.Drawing.Point(27, 46);
            this.btnRainThreshold.Name = "btnRainThreshold";
            this.btnRainThreshold.Size = new System.Drawing.Size(88, 31);
            this.btnRainThreshold.TabIndex = 0;
            this.btnRainThreshold.Text = "Rain";
            this.btnRainThreshold.UseVisualStyleBackColor = true;
            this.btnRainThreshold.Click += new System.EventHandler(this.btnRainThreshold_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textSerialRead
            // 
            this.textSerialRead.CausesValidation = false;
            this.textSerialRead.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSerialRead.Location = new System.Drawing.Point(587, 194);
            this.textSerialRead.Multiline = true;
            this.textSerialRead.Name = "textSerialRead";
            this.textSerialRead.ReadOnly = true;
            this.textSerialRead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSerialRead.Size = new System.Drawing.Size(374, 153);
            this.textSerialRead.TabIndex = 16;
            // 
            // btnClearSerialRead
            // 
            this.btnClearSerialRead.Location = new System.Drawing.Point(825, 353);
            this.btnClearSerialRead.Name = "btnClearSerialRead";
            this.btnClearSerialRead.Size = new System.Drawing.Size(136, 36);
            this.btnClearSerialRead.TabIndex = 4;
            this.btnClearSerialRead.Text = "Clear Display";
            this.btnClearSerialRead.UseVisualStyleBackColor = true;
            this.btnClearSerialRead.Click += new System.EventHandler(this.btnClearSerialRead_Click);
            // 
            // btnGetStates
            // 
            this.btnGetStates.Location = new System.Drawing.Point(587, 353);
            this.btnGetStates.Name = "btnGetStates";
            this.btnGetStates.Size = new System.Drawing.Size(115, 35);
            this.btnGetStates.TabIndex = 17;
            this.btnGetStates.Text = "Get States";
            this.btnGetStates.UseVisualStyleBackColor = true;
            this.btnGetStates.Click += new System.EventHandler(this.btnGetStates_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(107, 353);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 35);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "button1";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textSend
            // 
            this.textSend.Location = new System.Drawing.Point(200, 357);
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(100, 26);
            this.textSend.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1016, 462);
            this.Controls.Add(this.textSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnGetStates);
            this.Controls.Add(this.btnClearSerialRead);
            this.Controls.Add(this.textSerialRead);
            this.Controls.Add(this.groupThreshold);
            this.Controls.Add(this.groupPump);
            this.Controls.Add(this.groupLCD);
            this.Controls.Add(this.groupSerial);
            this.Controls.Add(this.groupCover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupLCD.ResumeLayout(false);
            this.groupLCD.PerformLayout();
            this.groupSerial.ResumeLayout(false);
            this.groupCover.ResumeLayout(false);
            this.groupPump.ResumeLayout(false);
            this.groupThreshold.ResumeLayout(false);
            this.groupThreshold.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLCD;
        private System.Windows.Forms.TextBox textLCD;
        private System.Windows.Forms.Button btnLCDWrite;
        private System.Windows.Forms.GroupBox groupSerial;
        private System.Windows.Forms.ComboBox comboSerial;
        private System.Windows.Forms.Button btnSerialCon;
        private System.Windows.Forms.GroupBox groupCover;
        private System.Windows.Forms.GroupBox groupPump;
        private System.Windows.Forms.Button btnTogglePump;
        private System.Windows.Forms.Button btnCoverToggle;
        private System.Windows.Forms.Button btnPortRefresh;
        private System.Windows.Forms.GroupBox groupThreshold;
        private System.Windows.Forms.TextBox textCoverThreshold;
        private System.Windows.Forms.Button btnRainThreshold;
        private System.Windows.Forms.TextBox textPumpThreshold;
        private System.Windows.Forms.Button btnSoilThreshold;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textSerialRead;
        private System.Windows.Forms.Label lbIndicator;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnClearSerialRead;
        private System.Windows.Forms.Button btnGetStates;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textSend;
    }
}

