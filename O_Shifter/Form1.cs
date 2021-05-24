using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Shifter
{
    public partial class Form1 : Form
    {
        private Bitmap _image;
        private int _countFragments = 0;
        private int _sizeFragment = 0;
        private List<Fragment> _fragments = new List<Fragment>();
        private string _puth = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateImage(string puth)
        {
            try
            {
                _image = new Bitmap(puth);
                _image = ResizeImage(_image, pictureBox1.Width, pictureBox1.Height);
                if (_image.Width > pictureBox1.Height)
                {
                    int d = _image.Width - pictureBox1.Height;
                    _image = _image.Clone(new Rectangle((int)(d / 2), 0, (int)(pictureBox1.Height), _image.Height), System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                }
                pictureBox1.Image = _image;
            }
            catch
            {
                Console.WriteLine("Невозможно открыть файл");
            }
        }
        private void ToolStrip_File_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;)|*.BMP;*.JPG;*.GIF;*.PNG;|All files (*.*)|*.*";
            OFD.Title = "Открыть....";
            OFD.ShowHelp = true;
            OFD.RestoreDirectory = true;
            if (OFD.ShowDialog() == DialogResult.OK)
            {

                _puth = OFD.FileName;
                CreateImage(_puth);
            }
        }

        private void ToolStrip_FIle_Save_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Title = "Сохранить картинку как...";
                SFD.OverwritePrompt = true;
                SFD.CheckPathExists = true;
                SFD.Filter = "BMP|*.BMP|JPG|*.JPG|GIF|*.GIF|PNG|*.PNG";
                SFD.ShowHelp = true;
                SFD.FilterIndex = 2;
                SFD.RestoreDirectory = true;
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _image.Save(SFD.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        Console.WriteLine("Невозможно сохранить изображение");
                    }
                }
            }
        }

        private void ToolStrip_Ok_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                CreateImage(_puth);
                try
                {
                    _countFragments = (int)Numeric_Count.Value;
                    _sizeFragment = (int)Numeric_Size.Value;

                }
                catch
                {
                    Console.WriteLine("Введена не цифра");
                }
                MakeFragments();
                DrawFragments();
                DrawRectangles();

                _fragments.Clear();
            }
        }
        private void MakeFragments()
        {
            Size fragmentSize = new Size(_sizeFragment, _sizeFragment);
            Random random = new Random();
            Bitmap imageFragment;
            Rectangle rectangle;
            for (int i = 0; i < _countFragments;)
            {
                int randomX = random.Next(0, _image.Width - _sizeFragment);
                int randomY = random.Next(0, _image.Height - _sizeFragment);
                Point newPoint = new Point(randomX, randomY);
                if (!IsExist(newPoint))
                {
                    rectangle = new Rectangle(newPoint, fragmentSize);
                    imageFragment = _image.Clone(rectangle, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                    _fragments.Add(new Fragment(newPoint, imageFragment, fragmentSize));
                    i++;
                }
            }
        }
        private void DrawFragments()
        {
            Bitmap newImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var g = Graphics.FromImage(newImage))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.Clear(Color.White);
                g.DrawImage(_image, 0, 0, _image.Width, _image.Height);
                for (int i = 0, j = 0, k = 0; i < _fragments.Count; i++)
                {
                    g.DrawImage(_fragments[i].Image, _image.Width + 30 + (_sizeFragment + 10) * j, 10 + (_sizeFragment + 10) * k, _sizeFragment, _sizeFragment);
                    if (k == pictureBox1.Height / (_sizeFragment + 10) - 1)
                    {
                        k = 0;
                        j++;
                    }
                    else
                        k++;
                }
                g.Dispose();
            }
            _image = newImage;
            pictureBox1.Image = _image;
            pictureBox1.Refresh();
        }
        private void DrawRectangles()
        {
            Graphics gr = pictureBox1.CreateGraphics();
            foreach (var fragment in _fragments)
            {
                gr.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(fragment.Coordinate, fragment.Size));
            }
            gr.Dispose();
        }
        private bool IsExist(Point newPoint)
        {
            Size bigSize = new Size(_sizeFragment * 2, _sizeFragment * 2);
            foreach (var fragment in _fragments)
            {
                Rectangle rectangle = new Rectangle(new Point(fragment.Coordinate.X - _sizeFragment, fragment.Coordinate.Y - _sizeFragment), bigSize);
                if (rectangle.Contains(newPoint))
                {
                    return true;
                }
            }
            return false;
        }
        private Bitmap ResizeImage(Image image, int nWidth, int nHeight)
        {
            int newWidth, newHeight;

            var coefH = (double)nHeight / (double)image.Height;
            var coefW = (double)nWidth / (double)image.Width;
            if (coefW >= coefH)
            {
                newHeight = (int)(image.Height * coefH);
                newWidth = (int)(image.Width * coefH);
            }
            else
            {
                newHeight = (int)(image.Height * coefW);
                newWidth = (int)(image.Width * coefW);
            }

            Bitmap result = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(result))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(image, 0, 0, newWidth, newHeight);
                g.Dispose();
            }
            return result;
        }
    }
}
