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
    public partial class frm_math : Form
    {

        bool moveleft, moveright, jump, hasKey;

        int jumpspeed = 5;
        int force = 8;
        int score = 0;

        int playerspeed = 5;
        int bgspd = 6;
        


        public frm_math()
        {
            InitializeComponent();


        }

        private void MainGame_Time(object sender, EventArgs e)
        {
            lbl_score.Text = "Score:" + score;
            player.Top += jumpspeed;

            if (moveleft == true && player.Left > 50)
            {
                player.Left -= playerspeed;
            }
            if (moveright == true && player.Left + (player.Width + 60) < this.ClientSize.Width)
            {
                player.Left += playerspeed;
            }


            if (moveleft == true & background.Left < 0)
            {
                background.Left += bgspd;

                MoveGameBG("forward");

            }

            if (moveright == true && background.Left > -1209)
            {

                background.Left -= bgspd;

                MoveGameBG("back");
            }

            if (jump == true)
            {
                jumpspeed = -17;
                force -= 1;
            }
            else
            {
                jumpspeed = 10;
            }

            if (jump == true && force < 0)
            {
                jump = false;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && jump == false)
                    {
                        force = 3;
                        player.Top = x.Top - player.Height;
                        jumpspeed = 1;

                    }
                    x.BringToFront();
                }
            }




        }

        private void KeyNotTouched(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {

                moveleft = false;

            }

            if (e.KeyCode == Keys.Right)
            {

                moveright = false;

            }

            if (jump == true)
            {

                jump = false;

            }
        }

        private void KeyIsTouched(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {

                moveleft = true;

            }

            if (e.KeyCode == Keys.Right)
            {

                moveright = true;

            }

            if (e.KeyCode == Keys.Space && !jump)
            {
                jump = true;
            }

        }

        private void GameClose(object sender, FormClosedEventArgs e)
        {

        }

        private void RstrtGame()
        {

        }

        private void MoveGameBG(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "ground")
                {
                    if (direction == "back")
                    {
                        x.Left -= bgspd;
                    }
                    if (direction == "forward")
                    {
                        x.Left += bgspd;
                    }
                }
            }

        }
    }
}