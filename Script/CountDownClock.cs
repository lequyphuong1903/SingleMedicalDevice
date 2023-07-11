using System;
using System.Drawing;
using System.Windows.Forms;

namespace SingleDeviceApp
{
    public partial class CountDownClock : UserControl
    {
        private System.Timers.Timer t;
        private int h, m, s;
        private static CountDownClock _instance;
        public static CountDownClock Instance
        {
            get { return _instance ?? (_instance = new CountDownClock()); }
        }
        
        public CountDownClock()
        {
            InitializeComponent();
        }
        private void CountDown_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }
        public void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
                {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                ClockTxt.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
        }
        public void StartCount()
        {
            ClockTxt.BackColor = Color.LightGreen;
            t.Start();
        }
        public void StopCount()
        {
            ClockTxt.BackColor = Color.LightPink;
            t.Stop();
        }
        public void ResetCount()
        {
            ClockTxt.BackColor = Color.White;
            ClockTxt.Text = "00:00:00";
            s = 0;
            m = 0;
            h = 0;
        }
    }
}
