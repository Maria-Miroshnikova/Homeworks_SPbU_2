using System;
using System.Windows.Forms;

namespace _7_2_ex
{
    public partial class Watch : Form
    {
        public Watch()
        {
            InitializeComponent();
            SetCurrentTime();
            WatchTimer.Start();
        }

        private void SetCurrentTime()
        {
            LabelHours2.Text = Convert.ToString(DateTime.Now.Hour / 10);
            LabelHours1.Text = Convert.ToString(DateTime.Now.Hour % 10);

            LabelMinutes2.Text = Convert.ToString(DateTime.Now.Minute / 10);
            LabelMinutes1.Text = Convert.ToString(DateTime.Now.Minute % 10);

            LabelSeconds2.Text = Convert.ToString(DateTime.Now.Second / 10);
            LabelSeconds1.Text = Convert.ToString(DateTime.Now.Second % 10);
        }
        
        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            SetCurrentTime();
        }
    }
}
