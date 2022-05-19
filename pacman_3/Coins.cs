using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace pacman_3
{
    internal class Coins
    {

        public int x;
        public int y;
        int w;
        int h;
        public Image image;


        public Coins(Image image)
        {
            this.x = 0;
            this.y = 0;
            this.image = image;

        }

    }
}
