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
            this.comboSerial = new System.Windows.Forms.ComboBox();
            this.btnSerialCon = new System.Windows.Forms.Button();
            this.groupCover = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupPump = new System.Windows.Forms.GroupBox();
            this.btnPumpOff = new System.Windows.Forms.Button();
            this.btnPumpOn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupLCD.SuspendLayout();
            this.groupSerial.SuspendLayout();
            this.groupCover.SuspendLayout();
            this.groupPump.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLCD
            // 
            this.groupLCD.Controls.Add(this.textLCD);
            this.groupLCD.Controls.Add(this.btnLCDWrite);
            this.groupLCD.Location = new System.Drawing.Point(98, 43);
            this.groupLCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLCD.Name = "groupLCD";
            this.groupLCD.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLCD.Size = new System.Drawing.Size(178, 134);
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
            this.btnLCDWrite.Location = new System.Drawing.Point(21, 88);
            this.btnLCDWrite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLCDWrite.Name = "btnLCDWrite";
            this.btnLCDWrite.Size = new System.Drawing.Size(135, 29);
            this.btnLCDWrite.TabIndex = 4;
            this.btnLCDWrite.Text = "Write";
            this.btnLCDWrite.UseVisualStyleBackColor = true;
            this.btnLCDWrite.Click += new System.EventHandler(this.btnLCDWrite_Click);
            // 
            // groupSerial
            // 
            this.groupSerial.Controls.Add(this.comboSerial);
            this.groupSerial.Controls.Add(this.btnSerialCon);
            this.groupSerial.Location = new System.Drawing.Point(98, 226);
            this.groupSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupSerial.Name = "groupSerial";
            this.groupSerial.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupSerial.Size = new System.Drawing.Size(528, 89);
            this.groupSerial.TabIndex = 12;
            this.groupSerial.TabStop = false;
            this.groupSerial.Text = "Serial Connection";
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
            this.groupCover.Controls.Add(this.checkBox1);
            this.groupCover.Location = new System.Drawing.Point(282, 55);
            this.groupCover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCover.Name = "groupCover";
            this.groupCover.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCover.Size = new System.Drawing.Size(149, 122);
            this.groupCover.TabIndex = 11;
            this.groupCover.TabStop = false;
            this.groupCover.Text = "Cover Control";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 91);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 24);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupPump
            // 
            this.groupPump.Controls.Add(this.btnPumpOff);
            this.groupPump.Controls.Add(this.btnPumpOn);
            this.groupPump.Location = new System.Drawing.Point(437, 55);
            this.groupPump.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPump.Name = "groupPump";
            this.groupPump.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPump.Size = new System.Drawing.Size(334, 122);
            this.groupPump.TabIndex = 14;
            this.groupPump.TabStop = false;
            this.groupPump.Text = "Pump Control";
            // 
            // btnPumpOff
            // 
            this.btnPumpOff.Location = new System.Drawing.Point(136, 44);
            this.btnPumpOff.Name = "btnPumpOff";
            this.btnPumpOff.Size = new System.Drawing.Size(84, 42);
            this.btnPumpOff.TabIndex = 1;
            this.btnPumpOff.Text = "Off";
            this.btnPumpOff.UseVisualStyleBackColor = true;
            this.btnPumpOff.Click += new System.EventHandler(this.btnPumpOff_Click);
            // 
            // btnPumpOn
            // 
            this.btnPumpOn.Location = new System.Drawing.Point(16, 44);
            this.btnPumpOn.Name = "btnPumpOn";
            this.btnPumpOn.Size = new System.Drawing.Size(92, 42);
            this.btnPumpOn.TabIndex = 0;
            this.btnPumpOn.Text = "On";
            this.btnPumpOn.UseVisualStyleBackColor = true;
            this.btnPumpOn.Click += new System.EventHandler(this.btnPumpOn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1016, 462);
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
            this.groupCover.PerformLayout();
            this.groupPump.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnPumpOn;
        private System.Windows.Forms.Button btnPumpOff;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

