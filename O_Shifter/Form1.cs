using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
            CheckRotate.SelectedIndex = 0;
        }

        private void CreateImage(string puth)
        {
            try
            {
                _image = new Bitmap(puth);
                if (_image.Width > _image.Height)
                    _image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                //_image = ResizeImage(_image, pictureBox1.Width, pictureBox1.Height);
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
            OFD.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG;)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG;|All files (*.*)|*.*";
            OFD.Title = "Открыть....";
            OFD.ShowHelp = true;
            OFD.RestoreDirectory = true;
            OFD.InitialDirectory = @"D:\Загрузки";
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
                SFD.InitialDirectory = @"D:\Загрузки";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Bitmap imageSave = ResizeImage(_image, 3507, 2481); // при DPI = 300
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
                FragmentsMaker maker = new FragmentsMaker(_sizeFragment, _countFragments, _fragments, (float)_image.Height / (float)pictureBox1.Height);
                maker.MakeFragments(_image, (CheckRotate.SelectedIndex == 1));
                Numeric_Count.Value = maker.CountFragments;
                _image = maker.DrawFragments(pictureBox1, _image);
                pictureBox1.Image = _image;
                pictureBox1.Refresh();
                maker.DrawRectangles(pictureBox1);

                _fragments.Clear();
            }
        }
        private void ToolStrip_File_OpenExistMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG;)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG;|All files (*.*)|*.*";
            OFD.Title = "Открыть....";
            OFD.ShowHelp = true;
            OFD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Карты";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                _puth = OFD.FileName;
                CreateImage(_puth);
            }
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
