using System.Threading;

namespace HorseRacing
{
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();
        private List<ProgressBar> horses = new();
        private bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStartRace_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                return;
            }

            isRunning = true;
            listBoxResults.Items.Clear();

            for (int i = 0; i < horses.Count; i++)
            {
                int horseIndex = i;
                Task.Run(() => RunRaceAsync(horseIndex));
            }
        }

        private void RunRaceAsync(int horseIndex)
        {
            ProgressBar horse = horses[horseIndex];
            while (horse.Value < horse.Maximum)
            {
                Invoke(() => horse.Value += random.Next(1, 5));
                Thread.Sleep(random.Next(50, 150));
            }

            Invoke(() =>
            {
                listBoxResults.Items.Add($"Horse {horseIndex + 1} finished!");
                if (listBoxResults.Items.Count == horses.Count)
                {
                    isRunning = false;
                }
            });
        }

        private void buttonAddHorses_Click(object sender, EventArgs e)
        {
            horses.Clear();
            flowLayoutPanelHorses.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                var horse = new ProgressBar
                {
                    Width = 400,
                    Height = 25,
                    Value = 0,
                    Maximum = 100
                };
                horses.Add(horse);
                flowLayoutPanelHorses.Controls.Add(horse);
            }
        }
    }
}
