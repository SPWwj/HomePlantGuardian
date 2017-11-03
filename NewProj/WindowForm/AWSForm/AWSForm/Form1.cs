using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace AWSForm
{
    public partial class Form1 : Form

    {
        bool isConnected = false;
        String[] ports;

        public Form1()
        {
            InitializeComponent();
            disableControls();
            getAvailableComPorts();
            listAvailableComPorts();
        }



        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        void listAvailableComPorts()
        {   /*
            comboSerial.Items.Clear();
            foreach (string port in ports)
            {
                comboSerial.Items.Add(port);
                //Console.WriteLine(port);
            }*/
            comboSerial.DataSource = SerialPort.GetPortNames();
            if (ports != null && ports.Length != 0)
            {
                comboSerial.SelectedItem = ports[0];
                btnSerialCon.Enabled = true;
            }
            else
            {
                btnSerialCon.Enabled = false;
            }

        }

        private void connectToArduino()
        {
            try
            {
                isConnected = true;
                string selectedPort = comboSerial.GetItemText(comboSerial.SelectedItem);
                //port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                serialPort1.PortName = selectedPort;
                serialPort1.Open();
                //port.Open();
                serialPort1.Write("#STAR\n");
                btnSerialCon.Text = "Disconnect";
                enableControls();
            }
            catch
            {
                Console.WriteLine("Error");
                MessageBox.Show("Error connecting to the ports");
            }
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            try
            {
                serialPort1.Write("#STOP\n");
                serialPort1.Close();
                if (!serialPort1.IsOpen)
                {
                    textSerialRead.AppendText("Port Disconnected");
                    textSerialRead.AppendText(Environment.NewLine);
                }
 
            }
            catch
            {
                Console.WriteLine("Error");
                MessageBox.Show("Improper disconnected from port");
            }
                btnSerialCon.Text = "Connect";
                disableControls();
                resetDefaults();
                btnSerialCon.Enabled = true;
        }



        private void enableControls()
        {
            groupCover.Enabled = true;
            groupPump.Enabled = true;
            groupLCD.Enabled = true;
            groupThreshold.Enabled = true;
            btnGetStates.Enabled = true;

        }


        private void disableControls()
        {

            groupCover.Enabled = false;
            groupThreshold.Enabled = false;
            groupLCD.Enabled = false;
            groupPump.Enabled = false;
            btnSerialCon.Enabled = false;
            btnGetStates.Enabled = false;
        }

        private void resetDefaults()
        {

            textLCD.Text = "";
            textPumpThreshold.Text = "";
            textCoverThreshold.Text = "";
            getAvailableComPorts();
            listAvailableComPorts();
            btnTogglePump.Text = "On";
            btnTogglePump.BackColor = Color.White;
            btnCoverToggle.Text = "To Open";
            btnCoverToggle.BackColor = Color.White;

        }


        private void btnLCDWrite_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                 serialPort1.Write("#TEXT" + textLCD.Text + "#\n");
            }
        }

        private void btnTogglePump_Click(object sender, EventArgs e)
        {
            if (btnTogglePump.Text == "On")
            {
                serialPort1.Write("#PUMPON\n");
                btnTogglePump.Text = "Off";
                btnTogglePump.BackColor = Color.LightGreen;
            }
            else
            {
                serialPort1.Write("#PUMPOF\n");
                btnTogglePump.Text = "On";
                btnTogglePump.BackColor = Color.White;
            }
        }


        private void btnSerialCon_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }


        private void btnCoverToggle_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (btnCoverToggle.Text=="To Open")
                {
                    serialPort1.Write("#RECTON\n");
                    btnCoverToggle.Text = "To Close";
                    btnCoverToggle.BackColor = Color.LightGreen;
                }
                else
                {
                    serialPort1.Write("#RECTOF\n");
                    btnCoverToggle.Text = "To Open";
                    btnCoverToggle.BackColor = Color.White;
                }
            }
        }

        private void btnPortRefresh_Click(object sender, EventArgs e)
        {
            getAvailableComPorts();
            listAvailableComPorts();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                lbIndicator.BackColor = Color.Green;
                textSerialRead.AppendText(serialPort1.ReadExisting());
            }
            else lbIndicator.BackColor = Color.Red;
        }


        private void btnClearSerialRead_Click(object sender, EventArgs e)
        {
            textSerialRead.Text = "";
        }

        private void btnGetStates_Click(object sender, EventArgs e)
        {
            serialPort1.Write("#STAT\n");
            textSerialRead.AppendText(serialPort1.ReadExisting());

        }

        private void btnRainThreshold_Click(object sender, EventArgs e)
        {
            try
            {
                int coverThreshold = Convert.ToInt32(textCoverThreshold.Text);
                serialPort1.Write("#THCO" + coverThreshold + "#\n");
            }
            catch
            {
                MessageBox.Show("Error entering the value");
            }
        }

        private void btnSoilThreshold_Click(object sender, EventArgs e)
        {
            try
            {
                int pumpThreshold = Convert.ToInt32(textPumpThreshold.Text);
                serialPort1.Write("#THPU" + pumpThreshold + "#\n");
            }
            catch
            {
                MessageBox.Show("Error entering the value");
            }
        }
    }
}
