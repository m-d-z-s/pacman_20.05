using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace pacman_3
{
    public class Pacman
    {
        PictureBox pictureBox1 = new PictureBox();
        public int speed;
        public bool goup;
        public bool godown;
        public bool goleft;
        public bool goright;
        public Image image;


        public Pacman(Image image)
        {
            this.speed = 5;
            this.goup = false;
            this.godown = false;
            this.goleft = false;
            this.goright = false;
            this.image = image;


        }

        public void MoveLeft()
        {
            pictureBox1.Image = Properties.Resources.left;


        }

        public void MoveRight()
        {
            pictureBox1.Image = Properties.Resources.right;


        }

        public void MoveDown()
        {
            pictureBox1.Image = Properties.Resources.down;


        }
        public void MoveUp()
        {
            pictureBox1.Image = Properties.Resources.Up;


        }

        public void Clear(Graphics g)
        {
            g.Clear(Color.Silver);
            //g.DrawImage(image, x, y, w, h);
        }
    }
}
