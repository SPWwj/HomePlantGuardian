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

        private void button1_Click(object sender, EventArgs e)
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

        void getAvailableComPorts()
        {
            //while (ports == null || ports.Length == 0)
            //{
                ports = SerialPort.GetPortNames();
            //}
        }

        void listAvailableComPorts()
        {
            foreach (string port in ports)
            {
                comboSerial.Items.Clear();
                comboSerial.Items.Add(port);
                Console.WriteLine(port);
            }
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
            isConnected = true;
            string selectedPort = comboSerial.GetItemText(comboSerial.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write("#STAR\n");
            btnSerialCon.Text = "Disconnect";
            enableControls();
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Write("#STOP\n");
            port.Close();
            btnSerialCon.Text = "Connect";
            disableControls();
            resetDefaults();
            btnSerialCon.Enabled = true;
            getAvailableComPorts();
            listAvailableComPorts();
        }



        private void enableControls()
        {

            btnLCDWrite.Enabled = true;
            textLCD.Enabled = true;
            groupCover.Enabled = true;
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

        }

        private void btnToggleCover_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (btnToggleCover.Text == "Open")
                {
                    port.Write("#LED1ON\n");
                }
                else
                {
                    port.Write("#LED1OF\n");
                }
            }
        }

        private void btnLCDWrite_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                port.Write("#TEXT" + textLCD.Text + "#\n");
            }
        }

        private void btnPumpOn_Click(object sender, EventArgs e)
        {
            port.Write("#LED1ON\n");
        }

        private void btnPumpOff_Click(object sender, EventArgs e)
        {
            port.Write("#LED1OF\n");
        }


    }
}
