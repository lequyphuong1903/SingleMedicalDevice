using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace SingleDeviceApp
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort = new SerialPort();
        private int BUFFER_SIZE = 2;
        private bool NewFlag = false;
        private bool FlagPort = false;
        private object serialPortLock = new object();
        CalculateMeasurement Measurement = new CalculateMeasurement();
        WaitFormFunc WaitForm = new WaitFormFunc();
        #region init
        public Form1()
        {
            InitializeComponent();
            float scalingFactor = GetScalingFactor();
            int desiredWidth = (int)(1000 * scalingFactor);
            int desiredHeight = (int)(800 * scalingFactor);
            this.MaximumSize = new Size(desiredWidth, desiredHeight);
            this.MinimumSize = new Size(desiredWidth, desiredHeight);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            chart.ChartXAxisLimit(0, 500);
            chart.ChartYAxisLimit(-50000, 50000);
            pulseHeart.Start();
        }
        private void CheckAddress(object sender, EventArgs e)
        {
            byte value = 5;
            serialPort.Write(new byte[] { value }, 0, 1);
        }    
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            portCBox.Items.AddRange(ports);
            StopBtn.Enabled = false;
            
        }
        private float GetScalingFactor()
        {
            using (Graphics graphics = this.CreateGraphics())
            {
                return graphics.DpiX / 96f;
            }
        }
        #endregion
        #region button
        private void ConnectClick(object sender, EventArgs e)
        {
            connectBtn.Enabled = false;
            StopBtn.Enabled = true;
            RecordBtn.Enabled = true;
            serialPort = new SerialPort(portCBox.Text, 115200);
            
            try
            {
                serialPort.Open();
                WaitForm.Show(this);
                serialPort.Close();
                Thread.Sleep(1000);
                WaitForm.Close();
                serialPort.Open();
                FlagPort = true;
                MessageBox.Show("Connect successfully", "Arduino Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Unable to open COM port - check again!", "Arduino Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ReadArduino(object sender, EventArgs e)
        {
            RecordBtn.Enabled = false;
            PauseBtn.Enabled = true;
            StopBtn.Enabled = true;
            if (FlagPort == false)
            {
                FlagPort = true;
            }
            serialPort.DataReceived += SerialPort_DataReceived;
            pulseHeart.Tick += BeatPulse;
            if (NewFlag == false)
            {
                NewFlag = true;
                countDownClock.ResetCount();
                chart.ChartReset();
                Measurement.hrList.Clear();
                Measurement.spo2List.Clear();
                Measurement.pn_spo2 = 0;
                Measurement.pn_heart_rate = 0;
                chart.ChartXAxisLimit(0, 500);
                chart.ChartYAxisLimit(-50000, 50000);
            }
            countDownClock.StartCount();
            
            
        }
        private void StopArduino(object sender, EventArgs e)
        {
            serialPort.DataReceived -= SerialPort_DataReceived;
            pulseHeart.Tick -= BeatPulse;
            pulseHeart.Stop();
            chart.ResetRecord();
            countDownClock.StopCount();
            StopBtn.Enabled = false;
            PauseBtn.Enabled = false;
            RecordBtn.Enabled = true;
            SaveBtn.Enabled = true;
            RecordBtn.Text = "New Record";
            NewFlag = false;
            FlagPort = false;
        }
        private void ReloadPort(object sender, EventArgs e)
        {
            portCBox.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            portCBox.Items.AddRange(ports);
        }
        private void PauseRecord(object sender, EventArgs e)
        {
            serialPort.DataReceived -= SerialPort_DataReceived;
            pulseHeart.Tick -= BeatPulse;
            RecordBtn.Text = "Resume";
            RecordBtn.Enabled = true;
            SaveBtn.Enabled = true;
            countDownClock.StopCount();
        }
        private void SaveData(object sender, EventArgs e)
        {
            if(nameTxt.Text == "" || idTxt.Text == "")
            {
                MessageBox.Show("Please enter your full name and ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                NewFlag = false;
                StopBtn.Enabled = false;
                PauseBtn.Enabled = false;
                RecordBtn.Enabled = true;
                RecordBtn.Text = "New Record";
                SaveBtn.Enabled = false;
                chart.ChooseFolderSaveRecord(nameTxt.Text + "_" + idTxt.Text + ".txt");
                nameTxt.Text = "";
                idTxt.Text = "";
            }
            
        }
        #endregion
        #region tranmission
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (FlagPort == true)
            if (serialPort.BytesToRead >= sizeof(UInt16) * BUFFER_SIZE * 2 + sizeof(byte))
            {
                byte[] data = new byte[sizeof(UInt16) * (BUFFER_SIZE * 2) + sizeof(byte)];
                serialPort.Read(data, 0, sizeof(UInt16) * (BUFFER_SIZE * 2) + sizeof(byte));
                byte value1 = data[0];
                UInt16[] value2 = new UInt16[BUFFER_SIZE];
                UInt16[] value3 = new UInt16[BUFFER_SIZE];
                Buffer.BlockCopy(data, sizeof(byte), value2, 0, sizeof(UInt16) * BUFFER_SIZE);
                Buffer.BlockCopy(data, sizeof(byte) + sizeof(UInt16) * BUFFER_SIZE, value3, 0, sizeof(UInt16) * BUFFER_SIZE);
                if (value1 > 0 & value1 < 128)
                {                         
                    chart.DrawIt(value3);
                    chart.SavingRecord(value2, value3);
                    Measurement.LogBuff(value2, value3);
                    int hr = Measurement.pn_heart_rate;
                    int spo2 = Measurement.pn_spo2;
                    IDValue.Invoke((MethodInvoker)(() => IDValue.Text = value1.ToString()));
                    if (hr != -999)
                    {
                        HRValue.Invoke((MethodInvoker)(() => HRValue.Text = hr.ToString()));
                    }
                    if (spo2 != -999)
                    {
                        SPO2Value.Invoke((MethodInvoker)(() => SPO2Value.Text = spo2.ToString()));
                    }
                }
            }
        }
        #endregion
        #region pulse
        private void BeatPulse(object sender, EventArgs e)
        {
            pulseBar.Invoke((MethodInvoker)(() => pulseBar.Value = 20));
            int bpm = int.Parse(HRValue.Text);
            if (bpm > 0)
            {
                float pulse = (60 / (float)bpm) * 1000;
                pulseHeart.Interval = (int)pulse;
                pulseBar.Invoke((MethodInvoker)(() => pulseBar.Value = 100));
            }         
        }
        #endregion
    }
}