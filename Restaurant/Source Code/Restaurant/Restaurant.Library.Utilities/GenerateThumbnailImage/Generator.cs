using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Restaurant.Library.Utilities.GenerateThumbnailImage
{
    public class Generator
    {
        private int _width = 124;
        private int _heigh = 91;
        private string _urlSourceImage;
        private string _urlSaveImage;
        public Generator(int width, int height, string urlSourceImage, string urlSaveImage)
        {
            _width = width;
            _heigh = height;
            _urlSourceImage = urlSourceImage;
            _urlSaveImage = urlSaveImage;
        }
        public void SaveThumbnail()
        {
            Image imThumbnailImage;
            Image _InputImage = Image.FromFile(_urlSourceImage);
            imThumbnailImage = _InputImage.GetThumbnailImage(_width, _heigh,
                         new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            imThumbnailImage.Save(_urlSaveImage,ImageFormat.Jpeg);
            imThumbnailImage.Dispose();
            _InputImage.Dispose();
        }
        public bool ThumbnailCallback() { return false; }
    }
}
