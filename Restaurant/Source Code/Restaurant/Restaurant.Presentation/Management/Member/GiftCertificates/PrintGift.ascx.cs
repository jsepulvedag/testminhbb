using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Library.Entities;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Restaurant.Library.BLL;
using System.IO;

namespace Restaurant.Presentation.Management.Member.GiftCertificates
{
    public partial class PrintGift : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string saveUrl = "~/Media/TempImage/" + DateTime.Now.ToString().Replace(":","").Replace("/","_") + ".jpeg";
                GiftCertificateImageInfo giftImage = GiftCertificateImageBLL.GetInfo(51);
                WriteTextOverImage(giftImage,saveUrl);
                Response.BinaryWrite(File.ReadAllBytes(Server.MapPath(saveUrl)));
                Response.End();
            }
        }
        private void WriteTextOverImage(GiftCertificateImageInfo giftImage,string saveUrl)
        {
            Bitmap bitMapImage = new System.Drawing.Bitmap(Server.MapPath(giftImage.ImageLargeURL));
            Graphics graphicImage = Graphics.FromImage(bitMapImage);
            graphicImage.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush textStyle = new SolidBrush(Color.FromName("red"));

            graphicImage.DrawString("NGUYEN VAN NHAT TESTING", new Font("Arial", 16, FontStyle.Bold), textStyle, new Point(50,50));
            
            Response.ContentType = "image/jpeg";
            bitMapImage.Save(Server.MapPath(saveUrl), ImageFormat.Jpeg);
            graphicImage.Dispose();
            bitMapImage.Dispose();
        }
    }
}