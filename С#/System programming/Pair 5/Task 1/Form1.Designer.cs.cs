namespace DancingProgressBars
{
    partial class Form1
    {
        private FlowLayoutPanel flowLayoutPanelBars;
        private Button buttonAddBars;
        private Button buttonStartBars;
        private NumericUpDown numericUpDownBarsCount;

        private void InitializeComponent()
        {
            flowLayoutPanelBars = new FlowLayoutPanel();
            buttonAddBars = new Button();
            buttonStartBars = new Button();
            numericUpDownBarsCount = new NumericUpDown();

            SuspendLayout();

            // FlowLayoutPanel
            flowLayoutPanelBars.Location = new Point(12, 12);
            flowLayoutPanelBars.Size = new Size(400, 300);
            flowLayoutPanelBars.AutoScroll = true;

            // NumericUpDown
            numericUpDownBarsCount.Location = new Point(12, 320);
            numericUpDownBarsCount.Minimum = 1;
            numericUpDownBarsCount.Maximum = 20;

            // Button Add
            buttonAddBars.Location = new Point(150, 320);
            buttonAddBars.Text = "Add Bars";
            buttonAddBars.Click += buttonAddBars_Click;

            // Button Start
            buttonStartBars.Location = new Point(250, 320);
            buttonStartBars.Text = "Start";
            buttonStartBars.Click += buttonStartBars_Click;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 360);
            Controls.Add(flowLayoutPanelBars);
            Controls.Add(buttonAddBars);
            Controls.Add(buttonStartBars);
            Controls.Add(numericUpDownBarsCount);
            Text = "Dancing Progress Bars";

            ResumeLayout(false);
        }
    }
}
