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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Home.Restaurant.GiftCertificates
{
    public partial class InstanceGift : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPanel();
            rdMail.Attributes.Add("onclick", "CheckShippingMail('" + rdMail.ClientID + "','" + rdPrint.ClientID + "','" + txtShippingMail.ClientID + "')");
            rdPrint.Attributes.Add("onclick", "CheckShippingMail('" + rdMail.ClientID + "','" + rdPrint.ClientID + "','" + txtShippingMail.ClientID + "')");
            if (!IsPostBack)
            {
                BindTypeGift();
                BindTypeGiftImage(Convert.ToInt32(listDesign.SelectedValue.ToString()));
                RestaurantGiftCertificateParameterInfo giftPara = RestaurantGiftCertificateParameterBLL.GetInfo_ByRestaurantID(Convert.ToInt32(RestaurantID));
                if (giftPara != null)
                {
                    lblRange.Text = "(Minimum " + giftPara.MinimunGiftCertificate + "$, maximum " + giftPara.MaximunGiftCertificate + "$)";
                }


            }
        }
        private string RestaurantID
        {
            get
            {
                return Request.QueryString["RidUrl"];
            }
        }
        private bool CheckSelectedDesignGift()
        {
            foreach (DataListItem item in listImage.Items)
            {
                RadioButton rad = (RadioButton)item.FindControl("rdoCheck");
                if (rad.Checked == true)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckRangePrice()
        {
            float price;
            if (!float.TryParse(txtAmount.Text.Trim(), out price))
            {
                return false;
            }
            else
            {
                RestaurantGiftCertificateParameterInfo giftPara = RestaurantGiftCertificateParameterBLL.GetInfo_ByRestaurantID(Convert.ToInt32(RestaurantID));
                if ((giftPara != null) && (Convert.ToInt32(txtAmount.Text) >= 5) && (Convert.ToInt32(txtAmount.Text) <= 200))
                {
                    if (price <= giftPara.MaximunGiftCertificate && price >= giftPara.MinimunGiftCertificate)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private void LoadPanel()
        {
            ltrScript.Text = @"<script language=javascript type=text/javascript>";
            ltrScript.Text += @"CheckShippingMail('" + rdMail.ClientID + "','" + rdPrint.ClientID + "','" + txtShippingMail.ClientID + "');";
            ltrScript.Text += @"</script>";
        }
        private void BindTypeGift()
        {
            Utility.BindingDropDowList(GiftCertificateTypeBLL.GetAll(true), listDesign);
        }
        private void BindTypeGiftImage(int giftType)
        {
            listImage.DataSource = GiftCertificateImageBLL.GetGetAllByGiftTypeID(giftType);
            listImage.DataBind();
        }
        private GiftCertificateInfo SetGiftCertificate
        {
            get
            {
                GiftCertificateInfo giftCertificate = new GiftCertificateInfo();
                giftCertificate.CreatedDate = DateTime.Now;
                RestaurantGiftCertificateParameterInfo giftPara = RestaurantGiftCertificateParameterBLL.GetInfo_ByRestaurantID(Convert.ToInt32(Request.QueryString["RidUrl"]));
                giftCertificate.ExpiredDate = DateTime.Now.AddDays(giftPara.ExpiryDate);
                giftCertificate.FromMsg = txtFrom.Text.Trim();
                foreach (DataListItem item in listImage.Items)
                {
                    RadioButton rad = (RadioButton)item.FindControl("rdocheck");
                    Image img = (Image)item.FindControl("image");
                    TextBox hiden = (TextBox)item.FindControl("url");
                    if (rad.Checked == true)
                    {
                        giftCertificate.GiftCertificateImageID = Convert.ToInt32(img.DescriptionUrl);
                        giftCertificate.GiftImageURL = hiden.Text.Trim();
                        break;
                    }
                }
                giftCertificate.Message = txtMessage.Text.Trim();
                if (rdMail.Checked == true)
                {
                    giftCertificate.SendGift = txtShippingMail.Text.Trim();
                }
                else
                {
                    giftCertificate.SendGift = "Print";
                }
                giftCertificate.SignatureMsg = "nhatnv";
                giftCertificate.ToMsg = txtTo.Text.Trim();
                return giftCertificate;
            }
        }
        protected void listDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTypeGiftImage(Convert.ToInt32(listDesign.SelectedValue.ToString()));
        }
        protected void listImage_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            RadioButton rdocheck = (RadioButton)e.Item.FindControl("rdoCheck");
            string grb = listDesign.SelectedValue.ToString();
            string script =
               "SetUniqueRadioButton('" + grb + "',this)";
            rdocheck.Attributes.Add("onclick", script);
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (!CheckSelectedDesignGift())
            {
                MessageBox.Show("Choose one gift image !");
                return;
            }
            ltrScript.Text += @"<script language=javascript type=text/javascript>";
            ltrScript.Text += @"popup('" + SetGiftCertificate.GiftCertificateImageID + "','";
            ltrScript.Text += txtAmount.Text.Trim() + "','";
            ltrScript.Text += txtTo.Text.Trim() + "','";
            ltrScript.Text += txtFrom.Text.Trim() + "','";
            ltrScript.Text += txtMessage.Text.Trim() + "','";
            ltrScript.Text += RestaurantID;
            ltrScript.Text += "');";
            ltrScript.Text += @"</script>";
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (!CheckSelectedDesignGift())
            {
                MessageBox.Show("Choose one gift image !");
                return;
            }
            if (!CheckRangePrice())
            {
                MessageBox.Show("Invalid amount !");
                txtAmount.Focus();
                return;
            }
            Session[PageConstant.SESSION_GIFT_CERTIFICATE] = SetGiftCertificate;
            Session[PageConstant.SESSION_PRICE] = txtAmount.Text.Trim();
            Response.Redirect(PageConstant.HOME_MEMBER_PURCHASE_GIFT_URL + PageConstant.RESTAURANT_ID + RestaurantID);
        }
    }
}