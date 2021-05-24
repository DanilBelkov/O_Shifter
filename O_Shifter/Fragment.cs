using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_Shifter
{
    class Fragment
    {
        public Bitmap Image;
        public Point Coordinate { get; private set; }
        public Size Size { get; private set; }

        public Fragment(Point cordinate, Bitmap image, Size size)
        {
            Coordinate = cordinate;
            Size = size;
            Image = image;
            Graphics g = Graphics.FromImage(Image);
            g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(0, 0, Size.Width, Size.Height));
            g.Dispose();
        }
    }
}
