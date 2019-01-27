using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz02
{
   
    public partial class Form1 : Form
    {
        // Adding Random object called randomizer.
        Random randomizer = new Random();
        // Creating computer-generated addends for addition problem.
        int addend1;
        int addend2;
        int timeLeft;

        /// <summary>
        /// Start the quiz - create problems, start timer.
        /// </summary>
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Try again!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }
    }
}
