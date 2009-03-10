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
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing;
using Restaurant.Library.Entities;
using System.Drawing.Imaging;
using Restaurant.Library.BLL;
using Restaurant.Library.Utilities.ColorPicker;

namespace Restaurant.Presentation.Home.Restaurant.GiftCertificates
{
    public partial class PreviewGift : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string saveUrl = "~/Media/TempImage/TempGiftImage/" + DateTime.Now.ToString().Replace(":", "").Replace("/", "_") + ".jpeg";
                GiftCertificateImageInfo giftImage = GiftCertificateImageBLL.GetInfo(GiftID);
                RestaurantInfo restaurant = RestaurantBLL.GetInfo(RestaurantID);
                RestaurantGiftCertificateParameterInfo param = RestaurantGiftCertificateParameterBLL.GetInfo_ByRestaurantID(RestaurantID);

                WriteTextOverImage(giftImage, param, restaurant, saveUrl);
                image.ImageUrl = saveUrl;
            }
        }
        private int GiftID
        {
            get { return Convert.ToInt32(Request.QueryString["GidUrl"]); }
        }
        private int RestaurantID
        {
            get { return Convert.ToInt32(Request.QueryString["RidUrl"]); }
        }
        private string Amount
        {
            get { return Request.QueryString["amount"]; }
        }
        private string To
        {
            get { return Request.QueryString["to"]; }
        }
        private string From
        {
            get { return Request.QueryString["from"]; }
        }
        private string Message
        {
            get { return Request.QueryString["message"]; }
        }
        private void WriteTextOverImage(GiftCertificateImageInfo giftImage,RestaurantGiftCertificateParameterInfo param,RestaurantInfo restaurant, string saveUrl)
        {
            Bitmap bitMapImage = new System.Drawing.Bitmap(Server.MapPath(giftImage.ImageLargeURL));
            Graphics graphicImage = Graphics.FromImage(bitMapImage);
            graphicImage.SmoothingMode = SmoothingMode.HighQuality;

            int red = HexaConverter.ConvertToRed(giftImage.ColorText);
            int green = HexaConverter.ConvertToGreen(giftImage.ColorText);
            int blue = HexaConverter.ConvertToBlue(giftImage.ColorText);
            SolidBrush textStyle = new SolidBrush(Color.FromArgb(red, green, blue));
            Font font = new Font("Times New Roman", 20, FontStyle.Bold);
            if (Amount != "" && Amount != null)
            {
                graphicImage.DrawString("Price: " + Amount, font, textStyle, new Point(giftImage.PriceX, giftImage.PriceY));
            }
            if (To != "" && To != null)
            {
                graphicImage.DrawString("To: " + To, font, textStyle, new Point(giftImage.ToX, giftImage.ToY));
            }
            if (From != "" && From != null)
            {
                graphicImage.DrawString("From: " + From, font, textStyle, new Point(giftImage.FromX, giftImage.FromY));
            }
            if (Message != "" && Message != null)
            {
                graphicImage.DrawString("Message: " + Message, font, textStyle, new Point(giftImage.MsgX, giftImage.MsgY));
            }
            graphicImage.DrawString(restaurant.Name + "'s Restaurant", font, textStyle, new Point(giftImage.RestaurantX, giftImage.RestaurantY));
            graphicImage.DrawString("Address: " + restaurant.Address, font, textStyle, new Point(giftImage.AddressX, giftImage.AddressY));
            graphicImage.DrawString("Expiry date: " + DateTime.Now.AddDays(param.ExpiryDate).ToShortDateString(), font, textStyle, new Point(giftImage.ExpiredDateX, giftImage.ExpiredDateY));
            
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
