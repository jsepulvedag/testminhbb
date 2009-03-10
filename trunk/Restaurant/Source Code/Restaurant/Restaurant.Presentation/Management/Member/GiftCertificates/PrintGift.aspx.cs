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
using Restaurant.Library.Utilities.ColorPicker;

namespace Restaurant.Presentation.Management.Member.GiftCertificates
{
    public partial class PrintGift : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string saveUrl = "~/Media/TempImage/TempGiftImage/" + DateTime.Now.ToString().Replace(":", "").Replace("/", "_") + ".jpeg";
                GiftCertificateImageInfo giftImage = GiftCertificateImageBLL.GetInfo_ByGiftID(GiftID);
                RestaurantInfo restaurant = RestaurantBLL.GetInfo_ByGiftID(GiftID);
                GiftCertificateInfo giftCertificate = GiftCertificatesBLL.GetInfo(GiftID);
                TransactionInfo transaction = TransactionBLL.GetInfo_ByGiftID(GiftID);
                WriteTextOverImage(giftImage, giftCertificate, restaurant, transaction, saveUrl);
                image.ImageUrl = saveUrl;
            }
        }
        private int GiftID
        {
            get { return Convert.ToInt32(Request.QueryString["GidUrl"]); }
        }
        private void WriteTextOverImage(GiftCertificateImageInfo giftImage,GiftCertificateInfo giftCertificate,RestaurantInfo restaurant,TransactionInfo transaction,string saveUrl)
        {
            Bitmap bitMapImage = new System.Drawing.Bitmap(Server.MapPath(giftImage.ImageLargeURL));
            Graphics graphicImage = Graphics.FromImage(bitMapImage);
            graphicImage.SmoothingMode = SmoothingMode.HighQuality;

            int red = HexaConverter.ConvertToRed(giftImage.ColorText);
            int green = HexaConverter.ConvertToGreen(giftImage.ColorText);
            int blue = HexaConverter.ConvertToBlue(giftImage.ColorText);
            SolidBrush textStyle = new SolidBrush(Color.FromArgb(red, green, blue));
            Font font = new Font("Times New Roman", 20, FontStyle.Bold);
            graphicImage.DrawString("Price: " + transaction.TotalPrice.ToString(), font, textStyle, new Point(giftImage.PriceX, giftImage.PriceY));
            if (giftCertificate.ToMsg != "" && giftCertificate.ToMsg != null)
            {
                graphicImage.DrawString("To: " + giftCertificate.ToMsg, font, textStyle, new Point(giftImage.ToX, giftImage.ToY));
            }
            if (giftCertificate.FromMsg != "" && giftCertificate.FromMsg != null)
            {
                graphicImage.DrawString("From: " + giftCertificate.FromMsg, font, textStyle, new Point(giftImage.FromX, giftImage.FromY));
            }
            if (giftCertificate.Message != "" && giftCertificate.Message != null)
            {
                graphicImage.DrawString("Message: " + giftCertificate.Message, font, textStyle, new Point(giftImage.MsgX, giftImage.MsgY));
            }
            graphicImage.DrawString(restaurant.Name + "'s Restaurant", font, textStyle, new Point(giftImage.RestaurantX, giftImage.RestaurantY));
            graphicImage.DrawString("Address: " + restaurant.Address, font, textStyle, new Point(giftImage.AddressX, giftImage.AddressY));
            graphicImage.DrawString("Expiry date: " + giftCertificate.ExpiredDate.ToShortDateString(), font, textStyle, new Point(giftImage.ExpiredDateX, giftImage.ExpiredDateY));

            DirectoryInfo direct = new DirectoryInfo(Server.MapPath("~/Media/TempImage/TempGiftImage/"));
            foreach (FileInfo fi in direct.GetFiles())
            {
                fi.Delete();
            }
            bitMapImage.Save(Server.MapPath(saveUrl), ImageFormat.Jpeg);
            graphicImage.Dispose();
            bitMapImage.Dispose();
        }
    }
}