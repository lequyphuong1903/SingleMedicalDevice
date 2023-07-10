using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.IO;

namespace SingleDeviceApp
{
    public partial class SignalChart : UserControl
    {
        private static SignalChart _instance;
        private int index = 0;

        #region ok
        public static SignalChart Instance
        {
            get { return _instance ?? (_instance = new SignalChart()); }
        }
        public SignalChart()
        {
            InitializeComponent();
            chart.Series[0].ChartType = SeriesChartType.FastLine;
            chart.Series[1].ChartType = SeriesChartType.Column;
            chart.Series[1].Points.AddY(0);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.Series[0].BorderWidth = 3;
            chart.Series[1].BorderWidth = 5;
        }

        public UInt16 GetData(UInt16 value)
        {
            if (InvokeRequired)
            {
                Func<UInt16, UInt16> getDataDelegate = new Func<UInt16, UInt16>(GetData);
                return (UInt16)Invoke(getDataDelegate, value);
            }
            else
            {
                if (chart.Series[0].Points.Count >= 500)
                {
                    chart.Series[0].Points[index].YValues[0] = (-1) * value;
                    chart.Series[1].Points[0].XValue = index;
                    chart.Series[1].Points[0].YValues[0] = 100000;
                    chart.Refresh();
                    index++;
                    if (index >= 500)
                    {
                        index = 0;
                        ChartYAxisLimit(ChartUpdate() - 300, ChartUpdate() + 300);
                    }
                }
                else
                {
                    chart.Series[0].Points.AddY((-1) * value);
                    index++;
                    if (index >= 500)
                    {
                        index = 0;
                        ChartYAxisLimit(ChartUpdate() - 300, ChartUpdate() + 300);
                    }
                }
                return value;
            } 
        }

        public void ChartXAxisLimit(double min, double max)
        {
            chart.ChartAreas[0].AxisX.Maximum = max;
            chart.ChartAreas[0].AxisX.Minimum = min;
        }
        public void ChartYAxisLimit(double min, double max)
        {
            chart.ChartAreas[0].AxisY.Maximum = max;
            chart.ChartAreas[0].AxisY.Minimum = min;
        }
        private double ChartUpdate()
        {
            double sum = 0;
            int count = 0;

            foreach (DataPoint point in chart.Series[0].Points)
            {
                sum += point.YValues[0];
                count++;
            }
            double average = sum / count;
            return average;
        }
        public void ChartReset()
        {
            chart.Series[0].Points.Clear();
            index = 0;
        }    
        public void SavingRecord(UInt16[] redvalue, UInt16[] irvalue)
        {
            string filePath = "temp.txt";
            SaveDataToTXT(filePath, redvalue, irvalue);
        }
        public void ResetRecord()
        {
            using (FileStream fs = File.Open("temp.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
            }
        }
        public void ChooseFolderSaveRecord(string dummyFileName)
        {
            string originalFilename = "temp.txt";
            string newFileName = "Record/" + dummyFileName;
            if (!Directory.Exists("Record"))
            {
                Directory.CreateDirectory("Record");
                File.Copy(originalFilename, newFileName);
            }
            else
            {
                File.Copy(originalFilename, newFileName);
            }
            MessageBox.Show("Save successfully", "Arduino Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }    
        private void SaveDataToTXT(string filePath, UInt16[] redvalue, UInt16[] irvalue)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (writer.BaseStream.Length == 0)
                {
                    writer.WriteLine("Red Value, IR Value");
                }
                for (int i = 0; i < irvalue.Length; i++)
                {
                    int ir = (-1) * irvalue[i];
                    int red = (-1) * redvalue[i];
                    var line = string.Format("{0},{1}", red, ir);
                    writer.WriteLine(line);
                }
            }
        }
        
        public void DrawIt(UInt16[] value)
        {
            for (int i = 0; i < value.Length; i++)
                GetData(value[i]);
        }
        #endregion
    }
}