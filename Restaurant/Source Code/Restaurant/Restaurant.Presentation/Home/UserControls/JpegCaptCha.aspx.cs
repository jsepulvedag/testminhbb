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
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.CaptChaImage;
using System.Drawing.Imaging;

namespace Restaurant.Presentation.Home.UserControls
{
    public partial class JpegCaptCha : Page
    {
        private Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[PageConstant.CAPT_CHA_IMAGE] = GenerateRandomCode();
            GenerateCaptCha img = new GenerateCaptCha(Session[PageConstant.CAPT_CHA_IMAGE].ToString(), 200, 40);
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";
            img.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            img.Dispose();
        }
        private string GenerateRandomCode()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, this.random.Next(10).ToString());
            return s;
        }
    }
}
