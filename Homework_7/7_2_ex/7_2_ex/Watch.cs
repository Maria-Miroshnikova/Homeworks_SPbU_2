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

        enum LabelTime { HOUR1, HOUR2, MIN1, MIN2, SEC1, SEC2 };

        private void CheckIsNumberCorrect(int number, int supremum)
        {
            if (number < 0 || number >= supremum)
            {
                throw new DataMisalignedException();
            }
        }

        private void IncreaseTime(LabelTime labelTime = LabelTime.SEC1)
        {
            int number;
            switch (labelTime)
            {
                case LabelTime.SEC1:
                    number = Convert.ToInt32(LabelSeconds1.Text);
                    CheckIsNumberCorrect(number, 10);

                    ++number;
                    LabelSeconds1.Text = Convert.ToString(number % 10);

                    if (number >= 10)
                    {
                        IncreaseTime(LabelTime.SEC2);
                    }
                    break;

                case LabelTime.SEC2:
                    number = Convert.ToInt32(LabelSeconds2.Text);
                    CheckIsNumberCorrect(number, 6);

                    ++number;
                    LabelSeconds2.Text = Convert.ToString(number % 6);

                    if (number >= 6)
                    {
                        IncreaseTime(LabelTime.MIN1);
                    }
                    break;

                case LabelTime.MIN1:
                    number = Convert.ToInt32(LabelMinutes1.Text);
                    CheckIsNumberCorrect(number, 10);

                    ++number;
                    LabelMinutes1.Text = Convert.ToString(number % 10);

                    if (number >= 10)
                    {
                        IncreaseTime(LabelTime.MIN2);
                    }
                    break;

                case LabelTime.MIN2:
                    number = Convert.ToInt32(LabelMinutes2.Text);
                    CheckIsNumberCorrect(number, 6);

                    ++number;
                    LabelMinutes2.Text = Convert.ToString(number % 6);

                    if (number >= 6)
                    {
                        IncreaseTime(LabelTime.HOUR1);
                    }
                    break;

                case LabelTime.HOUR1:
                    number = Convert.ToInt32(LabelHours1.Text);
                    CheckIsNumberCorrect(number, 10);

                    ++number;
                    LabelHours1.Text = Convert.ToString(number % 10);

                    if ((number == 4) && (Convert.ToInt32(LabelHours2.Text) == 2))
                    {
                        LabelHours1.Text = "0";
                        LabelHours2.Text = "0";
                        break;
                    }

                    if (number >= 10)
                    {
                        IncreaseTime(LabelTime.HOUR2);
                    }
                    break;

                case LabelTime.HOUR2:
                    number = Convert.ToInt32(LabelHours2.Text);
                    CheckIsNumberCorrect(number, 3);

                    ++number;
                    LabelHours2.Text = Convert.ToString(number % 3);

                    if (number >= 3)
                    {
                        LabelHours1.Text = "0";
                        LabelHours2.Text = "0";
                    }
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            IncreaseTime();
        }
    }
}
