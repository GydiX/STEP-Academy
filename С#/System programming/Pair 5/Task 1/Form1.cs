using System.Threading;

namespace DancingProgressBars
{
    public partial class Form1 : Form
    {
        private bool isRunning = false;
        private readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddBars_Click(object sender, EventArgs e)
        {
            int count = (int)numericUpDownBarsCount.Value;
            flowLayoutPanelBars.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                var progressBar = new ProgressBar
                {
                    Width = 300,
                    Height = 25,
                    Value = 0,
                    Maximum = 100
                };
                flowLayoutPanelBars.Controls.Add(progressBar);
            }
        }

        private void buttonStartBars_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                buttonStartBars.Text = "Start";
                return;
            }

            isRunning = true;
            buttonStartBars.Text = "Stop";

            foreach (ProgressBar bar in flowLayoutPanelBars.Controls)
            {
                Task.Run(() => FillProgressBarAsync(bar));
            }
        }

        private void FillProgressBarAsync(ProgressBar bar)
        {
            while (isRunning && bar.Value < bar.Maximum)
            {
                Invoke(() => bar.Value = Math.Min(bar.Value + random.Next(1, 5), bar.Maximum));
                Thread.Sleep(random.Next(50, 150));
            }
        }
    }
}
