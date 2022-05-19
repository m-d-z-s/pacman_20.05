using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman_3
{
    public partial class Form1 : Form
    {
        Graphics g;
        PictureBox[] pb = new PictureBox[25];
        Pacman pacman = new Pacman(Properties.Resources.right);
        Coins coins = new Coins(Properties.Resources.coin);


        int score = 0;

        public Form1()
        {
            InitializeComponent();
            pictureBox3.Hide();
            pictureBox2.Hide();
            //g = this.CreateGraphics();
            g = pictureBox2.CreateGraphics();
            DrawCoins(g);

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pacman.goleft = false;
                    break;
                case Keys.Right:
                    pacman.goright = false;
                    break;
                case Keys.Up:
                    pacman.goup = false;
                    break;
                case Keys.Down:
                    pacman.godown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pacman.goleft = true;
                    pacman.image = Properties.Resources.left;
                    pictureBox1.Image = pacman.image;
                    break;
                case Keys.Right:
                    pacman.goright = true;
                    pacman.image = Properties.Resources.right;
                    pictureBox1.Image = pacman.image;
                    break;
                case Keys.Up:
                    pacman.goup = true;
                    pacman.image = Properties.Resources.Up;
                    pictureBox1.Image = pacman.image;
                    break;
                case Keys.Down:
                    pacman.godown = true;
                    pacman.image = Properties.Resources.down;
                    pictureBox1.Image = pacman.image;
                    break;
            }
        }


        //public PictureBox CheckInters()
        //{
        //    foreach (var item in pb)
        //    {
        //        if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
        //        {
        //            return item;
        //        }
        //        /*if (pictureBox1. == item.Right)
        //        {
        //            return item;
        //        }
        //        */
        //    }
        //    return null;
            
        //}
        

        public void EatCoin(PictureBox theCoin)
        {
            //pictureBox3.Hide();
            //theCoin.Hide();
            score += 10;
        }

        public void DrawCoins(Graphics g)
        {
            int changeX = 0;
            int changeY = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    pb[i] = new PictureBox
                    {
                        Image = pictureBox3.Image,
                        SizeMode = PictureBoxSizeMode.StretchImage,

                        Width = pictureBox3.Width,
                        Height = pictureBox3.Height,
                        //MessageBox.Show(Convert.ToString(pictureBox3.Size) + " " + Convert.ToString(pb[i].Size));

                        Location = new Point(coins.x + changeX, coins.y + changeY)
                    };
                    this.Controls.Add(pb[i]);
                    changeX += 120;
                }
                changeX = 0;
                changeY += 200;

            }
        }
        public bool Intersection()
        {
            for(int i = 0;i < pb.Length;i++)
            {
                if (pictureBox1.Bounds.IntersectsWith(pb[i].Bounds))
                {
                    MessageBox.Show("yes");
                    return true;
                }
            }
            return false;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score;

            if (Intersection())
            {
                pictureBox1.Left += pacman.speed;
            }
            if (pacman.goleft && pictureBox1.Left > 0)
            {
                pictureBox1.Left -= pacman.speed;

                pacman.MoveLeft();
                pacman.Clear(g);
                
            }
            if (pacman.goright && pictureBox1.Right < 500)
            {
                pictureBox1.Left += pacman.speed;
                pacman.MoveRight();
                pacman.Clear(g);
            }
            if (pacman.goup && pictureBox1.Top > 0)
            {
                pictureBox1.Top -= pacman.speed;
                pacman.MoveUp();
                pacman.Clear(g);
            }

            if (pacman.godown && pictureBox1.Top < 250)
            {
                pictureBox1.Top += pacman.speed;
                pacman.MoveDown();
                pacman.Clear(g);
            }
            

            //if (!(CheckInters() is null))
            //{
            //    EatCoin(CheckInters());
            //}
            else
            {
                pacman.Clear(g);
            }
        }

    }
}
