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

namespace Restaurant.Presentation.Administrator
    {
    public partial class Default : AuthenticatePage
        {
        private Restaurant.Presentation.Library.PageEnvironment env;
        protected void Page_Load(object sender, EventArgs e)
            {
            if (Request.QueryString["ctrl"] != null)
                {
                if (env.Controls.ContainsKey(Request.QueryString["ctrl"].ToLower()))
                    {
                    aphMain.Controls.Add(LoadControl(env.Controls[Request.QueryString["ctrl"].ToLower()].ToString()));
                    BindTitle();
                    }
                }

            }
        protected override void OnInit(EventArgs e)
            {
            base.OnInit(e);
            if (!IsLogined || CurrentAccountLogin.Type != PageConstant.ADMIN)
                {
                if (Request.QueryString["ctrl"] == null)
                    {
                    Response.Redirect(PageConstant.ADMIN_LOGIN_URL);
                    }
                else
                    {
                    Response.Redirect(PageConstant.ADMIN_LOGIN_URL + PageConstant.NEXT_URL.Replace("&", "?") + Server.UrlEncode(RawUrl));
                    }
                }
            env = new Restaurant.Presentation.Library.PageEnvironment(Server.MapPath(PageConstant.ADMIN_XML_FILE_CONFIG));
            }
        private void BindTitle()
            {
            string strUrl = Request.QueryString["ctrl"].ToString();
            switch (strUrl.ToLower())
                {
                case "city":
                    lblTitle.Visible = true;
                    lblTitle.Text = "CITY INFORMATION";
                    break;
                case "country":
                    lblTitle.Visible = true;
                    lblTitle.Text = "COUNTRY INFORMATION";
                    break;
                case "state":
                    lblTitle.Visible = true;
                    lblTitle.Text = "STATE INFORMATION";
                    break;
                case "attire":
                    lblTitle.Visible = true;
                    lblTitle.Text = "ATTIRE INFORMATION";
                    break;
                case "special":
                    lblTitle.Visible = true;
                    lblTitle.Text = "SPECIAL INFORMATION";
                    break;
                case "neighbourhood":
                    lblTitle.Visible = true;
                    lblTitle.Text = "NEIGHBOURHOOD INFORMATION";
                    break;
                case "cuisine":
                    lblTitle.Visible = true;
                    lblTitle.Text = "CUISINE INFORMATION";
                    break;
                case "reviewmanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "REVIEW MANAGEMENT";
                    break;
                case "photomanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "PHOTOS MANAGEMENT";
                    break;
                case "restaurantmanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "RESTAURANT MANAGEMENT";
                    break;
                case "addrestaurant":
                    lblTitle.Visible = true;
                    lblTitle.Text = "CREATE RESTAURANT";
                    break;
                case "addmember":
                    lblTitle.Visible = true;
                    lblTitle.Text = "CREATE MEMBER";
                    break;
                case "listmember":
                    lblTitle.Visible = true;
                    lblTitle.Text = "MEMBER MANAGEMENT";
                    break;
                case "listgiftpurchase":
                    lblTitle.Visible = true;
                    lblTitle.Text = "LIST GIFT PURCHASE";
                    break;
                case "changepassword":
                    lblTitle.Visible = true;
                    lblTitle.Text = "CHANGE YOUR PASSWORD";
                    break;
                case "pakagesmanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "PACKAGE MANAGEMENT";
                    break;
                case "subplanmanagement":
                    lblTitle.Visible = true;
                    lblTitle.Text = "SUBSCRIPTION PLAN";
                    break;
                case "gifttype":
                    lblTitle.Visible = true;
                    lblTitle.Text = "DEFINE GIFT TYPE";
                    break;
                case "giftdesign":
                    lblTitle.Visible = true;
                    lblTitle.Text = "DEFINE GIFT DESIGN";
                    break;
                case "giftcommission":
                    lblTitle.Visible = true;
                    lblTitle.Text = "DEFINE GIFT COMMISSION";
                    break;
                case "reservationcommission":
                    lblTitle.Visible = true;
                    lblTitle.Text = "DEFINE RESERVATION COMMISSION";
                    break;
                case "createmember":
                    lblTitle.Visible = true;
                    lblTitle.Text = "CHOOSE MEMBER";
                    break;
                case "choosepackage":
                    lblTitle.Visible = true;
                    lblTitle.Text = "CHOOSE PACKAGE";
                    break;
                }

            }
        }
    }
