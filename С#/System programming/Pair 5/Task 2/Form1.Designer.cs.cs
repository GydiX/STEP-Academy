namespace HorseRacing
{
    partial class Form1
    {
        private FlowLayoutPanel flowLayoutPanelHorses;
        private Button buttonAddHorses;
        private Button buttonStartRace;
        private ListBox listBoxResults;

        private void InitializeComponent()
        {
            flowLayoutPanelHorses = new FlowLayoutPanel();
            buttonAddHorses = new Button();
            buttonStartRace = new Button();
            listBoxResults = new ListBox();

            SuspendLayout();

            // FlowLayoutPanel
            flowLayoutPanelHorses.Location = new Point(12, 12);
            flowLayoutPanelHorses.Size = new Size(450, 200);

            // Button Add Horses
            buttonAddHorses.Location = new Point(12, 220);
            buttonAddHorses.Text = "Add Horses";
            buttonAddHorses.Click += buttonAddHorses_Click;

            // Button Start Race
            buttonStartRace.Location = new Point(120, 220);
            buttonStartRace.Text = "Start Race";
            buttonStartRace.Click += buttonStartRace_Click;

            // ListBox Results
            listBoxResults.Location = new Point(12, 260);
            listBoxResults.Size = new Size(450, 150);

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 430);
            Controls.Add(flowLayoutPanelHorses);
            Controls.Add(buttonAddHorses);
            Controls.Add(buttonStartRace);
            Controls.Add(listBoxResults);
            Text = "Horse Racing";

            ResumeLayout(false);
        }
    }
}
