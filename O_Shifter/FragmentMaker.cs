using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Shifter
{
    class FragmentsMaker
    {
        public int SizeFragment { get; private set; }
        public int CountFragments { get; private set; }

        private List<Fragment> _fragments;
        private float _sizeCoeff; // коэффициент изменения масштаба картинки

        public FragmentsMaker(int sizeFragment, int countFragments, List<Fragment> fragments, float sizeCoeff)
        {
            SizeFragment = (int)(sizeFragment * sizeCoeff);
            _fragments = fragments;
            CountFragments = countFragments;
            _sizeCoeff = sizeCoeff;
        }

        public void MakeFragments(Bitmap globalImage, bool WithRotate)
        {
            Size fragmentSize = new Size(SizeFragment, SizeFragment);
            Bitmap imageFragment;
            Rectangle rectangle;
            Random random = new Random();
            RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;
            while((int)((globalImage.Height * 1.41429 - globalImage.Width) / (SizeFragment + 10 * _sizeCoeff)) < (float)CountFragments / (int)(globalImage.Height / (SizeFragment + 10*_sizeCoeff)))
            {
                CountFragments--;
            }
            for (int i = 0; i < CountFragments;)
            {
                int randomX = random.Next(0, globalImage.Width - SizeFragment);
                int randomY = random.Next(0, globalImage.Height - SizeFragment);
                Point newPoint = new Point(randomX, randomY);
                if (!IsExist(newPoint))
                {
                    rectangle = new Rectangle(newPoint, fragmentSize);
                    imageFragment = globalImage.Clone(rectangle, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                    if (WithRotate)
                        rotateFlipType = GetRotateType(random.Next(0, 4));
                    _fragments.Add(new Fragment(newPoint, imageFragment, fragmentSize, rotateFlipType));
                    i++;
                }
            }
        }
        public Bitmap DrawFragments(PictureBox pictureBox, Bitmap globalImage)
        {
            Bitmap newImage = new Bitmap((int)(globalImage.Height * 1.41429) , globalImage.Height);
            using (var g = Graphics.FromImage(newImage))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.Clear(Color.White);

                g.DrawImage(globalImage, 0, 0, globalImage.Width, globalImage.Height);
                for (int i = 0, j = 0, k = 0; i < _fragments.Count; i++)
                {
                    g.DrawImage(_fragments[i].Image, globalImage.Width + 30*_sizeCoeff + (SizeFragment + 10*_sizeCoeff) * j,
                        10*_sizeCoeff + (SizeFragment + 10*_sizeCoeff) * k, SizeFragment, SizeFragment);
                    if (k == (int)(globalImage.Height / (SizeFragment + 10*_sizeCoeff) - 1))
                    {
                        k = 0;
                        j++;
                    }
                    else
                        k++;
                }
                g.Dispose();
            }
            return newImage;
        }
        public void DrawRectangles(PictureBox pictureBox)
        {
            Graphics gr = pictureBox.CreateGraphics();
            foreach (var fragment in _fragments)
            {
                gr.DrawRectangle(new Pen(Color.Red, 2),
                    new Rectangle(new Point((int)(fragment.Coordinate.X / _sizeCoeff), (int)(fragment.Coordinate.Y / _sizeCoeff)),
                        new Size((int)(fragment.Size.Width/_sizeCoeff), (int)(fragment.Size.Height / _sizeCoeff))));
            }
            gr.Dispose();
        }
        private RotateFlipType GetRotateType(int randomValue)
        {
            RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;
            switch (randomValue)
            {
                case 1:
                    rotateFlipType = RotateFlipType.Rotate90FlipNone;
                    break;
                case 2:
                    rotateFlipType = RotateFlipType.Rotate180FlipNone;
                    break;
                case 3:
                    rotateFlipType = RotateFlipType.Rotate270FlipNone;
                    break;
                default: break;
            }
            return rotateFlipType;
        }
        private bool IsExist(Point newPoint)
        {
            Size bigSize = new Size((int)(SizeFragment * 1.5), (int)(SizeFragment * 1.5));
            foreach (var fragment in _fragments)
            {
                Rectangle rectangle = new Rectangle(new Point(fragment.Coordinate.X - SizeFragment/2, fragment.Coordinate.Y - SizeFragment/2), bigSize);
                if (rectangle.Contains(newPoint))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
