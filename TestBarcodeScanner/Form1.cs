
using System.Diagnostics;
using System.IO.Ports;

namespace TestBarcodeScanner
{
    public partial class Form1 : Form
    {
        public SerialPort mySerialPort = null ;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            MessageBox.Show("Received");
            textBox1.Text = indata;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = this.comboBox1.SelectedItem.ToString();
            mySerialPort = new SerialPort(value);
            mySerialPort.Open();
            //mySerialPort.BaudRate = 9600;
            //mySerialPort.Parity = Parity.None;
            //mySerialPort.StopBits = StopBits.One;
            //mySerialPort.DataBits = 8;
            //mySerialPort.Handshake = Handshake.None;
            mySerialPort.DataReceived += DataReceivedHandler;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(mySerialPort != null)
                mySerialPort.Close();
        }

        //private void OpenSerialPort()
        //{
        //    try
        //    {
        //        m_serialPort.DataReceived += SerialPortDataReceived;
        //        m_serialPort.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message + ex.StackTrace);
        //    }
        //}

        //private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    var serialPort = (SerialPort)sender;
        //    var data = serialPort.ReadExisting();
        //    ProcessData(data);
        //}
    }
}