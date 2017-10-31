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
        SerialPort port;

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
                port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("#STAR\n");
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
                port.Write("#STOP\n");
                port.Close();
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

        }


        private void disableControls()
        {

            groupCover.Enabled = false;
            groupLCD.Enabled = false;
            groupPump.Enabled = false;
            btnSerialCon.Enabled = false;
        }

        private void resetDefaults()
        {

            textLCD.Text = "";
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
                 port.Write("#TEXT" + textLCD.Text + "#\n");
            }
        }

        private void btnTogglePump_Click(object sender, EventArgs e)
        {
            if (btnTogglePump.Text == "On")
            {
                port.Write("#PUMPON\n");
                btnTogglePump.Text = "Off";
                btnTogglePump.BackColor = Color.LightGreen;
            }
            else
            {
                port.Write("#PUMPOF\n");
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
                    port.Write("#RECTON\n");
                    btnCoverToggle.Text = "To Close";
                    btnCoverToggle.BackColor = Color.LightGreen;
                }
                else
                {
                    port.Write("#RECTOF\n");
                    btnCoverToggle.Text = "To Open";
                    btnCoverToggle.BackColor = Color.White;
                }
            }
        }
    }
}
