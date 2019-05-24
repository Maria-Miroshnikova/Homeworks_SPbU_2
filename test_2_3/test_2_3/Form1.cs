using System;
using System.Threading;

namespace test2point3
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void buttonStartClick(object sender, EventArgs e)
        {
            buttonExit.Visible = false;
            progressBar1.Value = 0;
            progressBar1.Maximum = 5;
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                progressBar1.Value++;
            }
            Thread.Sleep(1000);
            buttonExit.Visible = true;
        }

        private void buttonExitClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
