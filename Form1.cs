/* GUI for serial communication to SainSmart 6 DOF robotic arm using arduino.
 * upload arduino sketch _6axisTEST downloaded from this website. 
 * http://wiki.sainsmart.com/index.php/DIY_6-Axis_Servos_Control_Palletizing_Robot_Arm_Model_for_Arduino_UNO_MEGA2560
*/
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

namespace SainSmart_Control_Application
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

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
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
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            //port.Write("#STAR\n");
            button1.Text = "Disconnect";
            enableControls();
            
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            //port.Write("#STOP\n");
            port.Close();
            button1.Text = "Connect";
            disableControls();
            
        }

        private void enableControls()
        {
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            trackBar3.Enabled = true;
            trackBar4.Enabled = true;
            trackBar5.Enabled = true;
            trackBar6.Enabled = true;
            trackBar7.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void disableControls()
        {
            trackBar1.Enabled = false;
            trackBar2.Enabled = false;
            trackBar3.Enabled = false;
            trackBar4.Enabled = false;
            trackBar5.Enabled = false;
            trackBar6.Enabled = false;
            trackBar7.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            
        }

        private void trackbar1_scroll(object sender, EventArgs e)           // Controls servo g
        {                                                                   //
            if (isConnected)                                                //
            {                                                               //
                port.WriteLine(trackBar1.Value.ToString() + "g");           //
                label8.Text = "Degree = " + trackBar1.Value.ToString();     //
            }
        }

        private void trackbar2_scroll(object sender, EventArgs e) // Controls servo f
        {
            if (isConnected)
            {
                port.WriteLine(trackBar2.Value.ToString() + "f");
                label9.Text = "Degree = " + trackBar2.Value.ToString();
            }
        }

        private void trackbar3_scroll(object sender, EventArgs e) // Controls servo e
        {
            if (isConnected)
            {
                port.WriteLine(trackBar3.Value.ToString() + "e");
                label10.Text = "Degree = " + trackBar3.Value.ToString();
            }
        }

        private void trackbar4_scroll(object sender, EventArgs e) // Controls servo d
        {
            if (isConnected)
            {
                port.WriteLine(trackBar4.Value.ToString() + "d");
                label11.Text = "Degree = " + trackBar4.Value.ToString();
            }
        }

        private void trackbar5_scroll(object sender, EventArgs e) // Controls servo c
        {
            if (isConnected)
            {
                port.WriteLine(trackBar5.Value.ToString() + "c");
                label12.Text = "Degree = " + trackBar5.Value.ToString();
            }
        }

        private void trackbar6_scroll(object sender, EventArgs e) // Controls servo b
        {
            if (isConnected)
            {
                port.WriteLine(trackBar6.Value.ToString() + "b");
                label13.Text = "Degree = " + trackBar6.Value.ToString();
            }
        }

        private void trackbar7_scroll(object sender, EventArgs e) // Controls servo a
        {
            if (isConnected)
            {
                port.WriteLine(trackBar7.Value.ToString() + "a");
                label14.Text = "Degree = " + trackBar7.Value.ToString();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void aBoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port.Write("#auto");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            port.Write("#stop");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            port.Write("#com");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            port.Write("#auto2");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            port.Write("#auto3");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            port.Write("#auto4");
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/ArduinoProjects101/");
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCzk_SWD_SASF8UE2FPk9LOA");
        }

        private void instructablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instructables.com/member/vandenbrande/instructables/");
        }

        private void ourWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.arduinosensors.nl/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCzk_SWD_SASF8UE2FPk9LOA");
        }

        

       


        
    }
}
