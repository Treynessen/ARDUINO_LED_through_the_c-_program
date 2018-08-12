using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ARDUINO_LED_through_the_c__program
{
    public partial class Form1 : Form
    {
        string[] ports;
        SerialPort port;
        bool CONNECT = false, ON = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            errorMsg.Visible = false;
            ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; ++i) portsList.Items.Add(ports[i]);
            portsList.SelectedItem = ports[0];
            button1.Enabled = true;
        }

        private void portsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CONNECT)
            {
                try
                {
                    port = new SerialPort((string)portsList.SelectedItem, 9600);
                }
                catch
                {
                    errorMsg.Visible = true;
                    return;
                }
                CONNECT = true;
                port.Open();
                errorMsg.Visible = false;
                button2.Enabled = true;
                button1.Text = "Отключиться";
                portsList.Enabled = false;
            }
            else
            {
                port.Close();
                CONNECT = false;
                button2.Enabled = false;
                button1.Text = "Подключиться";
                portsList.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ON)
            {
                port.Write("OFF\n");
                button2.Text = "Включить";
                ON = false;
            }
            else
            {
                port.Write("ON\n");
                button2.Text = "Выключить";
                ON = true;
            }
        }
    }
}
