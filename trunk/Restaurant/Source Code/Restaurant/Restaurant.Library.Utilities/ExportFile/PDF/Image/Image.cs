using System;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Restaurant.Library.Utilities.ExportFile.PDF.Image
{
    public class Image : Base
    {
        public void DrawPage(XGraphics gfx,PdfPage page,string jpegPath,PdfDocument document)
        {
            DrawTitle(page, gfx, "design by nhatnv",document);
            DrawImage(gfx, 3,jpegPath);
        }

        public void DrawTitle(PdfPage page, XGraphics gfx, string title, PdfDocument document)
        {
            XRect rect = new XRect(new XPoint(), gfx.PageSize);
            rect.Inflate(-10, -15);
            XFont font = new XFont("Verdana", 14, XFontStyle.Bold);
            gfx.DrawString(title, font, XBrushes.MidnightBlue, rect, XStringFormats.TopCenter);

            rect.Offset(0, 5);
            font = new XFont("Verdana", 8, XFontStyle.Italic);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Far;
            gfx.DrawString("Created with NhatNV", font, XBrushes.DarkOrchid, rect, format);

            font = new XFont("Verdana", 8);
            format.Alignment = XStringAlignment.Center;
            gfx.DrawString(document.PageCount.ToString(), font, XBrushes.DarkOrchid, rect, format);

            document.Outlines.Add(title, page, true);
        }
        public void DrawImage(XGraphics gfx, int number, string jpegSamplePath)
        {
            XImage image = XImage.FromFile(jpegSamplePath);
            double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
            gfx.DrawImage(image, 50, 100);
        }
    }
}
