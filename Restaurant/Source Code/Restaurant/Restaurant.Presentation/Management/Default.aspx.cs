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
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Member
{
    public partial class Default : AuthenticatePage
    {
        private Restaurant.Presentation.Library.PageEnvironment env;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!IsLogined)
            {
                Response.Redirect(PageConstant.HOME_LOGIN_URL + PageConstant.NEXT_URL + RawUrl);
            }
            else
            {
                if (CurrentAccountLogin.Type == PageConstant.MEMBER || AdminMemberId != 0)
                {
                    env = new Restaurant.Presentation.Library.PageEnvironment(Server.MapPath(PageConstant.MEMBER_XML_FILE_CONFIG));
                }
                else if (CurrentAccountLogin.Type == PageConstant.RESTAURANT)
                {
                    env = new Restaurant.Presentation.Library.PageEnvironment(Server.MapPath(PageConstant.RESTAURANT_XML_FILE_CONFIG));
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mid"] != null)
            {
                aphMain.Controls.Add(LoadControl(env.Controls[Request.QueryString["mid"].ToLower()].ToString()));
            }
            else
            {
                aphMain.Controls.Add(LoadControl(env.Controls["welcome"].ToString()));
            }
            BindTitle();
        }

        private void BindTitle()
        {
            string strUrl = Request.QueryString["mid"].ToString();
            switch (strUrl.ToLower())
            {
                case "profile":
                    lblTitle.Visible = true;
                    lblTitle.Text = "My Profile";
                    break;
                case "mygift":
                    lblTitle.Visible = true;
                    lblTitle.Text = "My Gift";
                    break;
                case "memberreview":
                    lblTitle.Visible = true;
                    lblTitle.Text = "My Review";
                    break;
                case "giftparameter":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Gift Certificate Param";
                    break;
                case "giftpurchasemanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Gift Certificate";
                    break;
                case "menucategory":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Menu";
                    break;
                case "menuitem":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Menu";
                    break;
                case "restaurantprofile":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Restaurant Info";
                    break;
                case "photomanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Photos Management";
                    break;
                case "addphoto":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Add Photo";
                    break;
                case "editphoto":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Edit Photo";
                    break;
                case "renew":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Restaurant Info";
                    break;
                case "blockrestaurant":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Restaurant Info";
                    break;
                case "myreservation":
                    lblTitle.Visible = true;
                    lblTitle.Text = "My Reservation";
                    break;
                case "changepassword":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Change Your Password";
                    break;
                case "yourrestaurant":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Restaurant Info";
                    break;
                case "choosepackage":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Choose Package For Renew Your Restaurant";
                    break;
                case "settingservice":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Setting your service";
                    break;
                case "reservationmanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Reservation In Your Restaurant";
                    break;
                case "favouriterestaurant":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Your Favourite Restaurants";
                    break;
                case "orderparam":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Ordering Online Param";
                    break;
                case "transactionhistory":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Transaction History";
                    break;
                case "businessaccount":
                    lblTitle.Visible = true;
                    lblTitle.Text = "Your Business Account Paypal";
                    break;
            }

        }
    }
}
