using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Game
{
    public partial class frm_color : Form
    {
        public string[] colorNames = { "Red", "Green", "Blue", "Yellow", "Orange", "Purple" };
        public Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple };

        public Random random = new Random();
        public int score = 0;
        public int mistakes = 0;
        public frm_color()
        {
            InitializeComponent();
            RestartGame();
        }
        private void RestartGame()
        {
            mistakes = 0;
            score = 0;
            UpdateScoreLabel();

            ShowRandomColor();
            ShowRandomChoices();
        }

        private void ShowRandomColor()
        {
            int index = random.Next(colorNames.Length);
            string colorName = colorNames[index];

            colorLabel.Text = colorName;
            colorLabel.ForeColor = colors[index];
        }

        private void ShowRandomChoices()
        {
            choicesListBox.Items.Clear();

            for (int i = 0; i < 3; i++)
            {
                int index = random.Next(colorNames.Length);
                choicesListBox.Items.Add(colorNames[index]);
            }

            int correctIndex = random.Next(choicesListBox.Items.Count);
            choicesListBox.Items[correctIndex] = colorLabel.Text;
        }

        private void CheckAnswer(string selectedColor)
        {
            if (selectedColor == colorLabel.Text)
            {
                score++;
            }
            else
            {
                mistakes++;

                if (mistakes == 3)
                {
                    MessageBox.Show($"Game Over! Your final score is {score}.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestartGame();
                    return;
                }
            }

            UpdateScoreLabel();
            ShowRandomColor();
            ShowRandomChoices();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {score} | Mistakes: {mistakes}";
        }
        private void choicesListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (choicesListBox.SelectedItem != null)
            {
                CheckAnswer(choicesListBox.SelectedItem.ToString());
            }
        }
    }
}