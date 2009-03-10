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
using Restaurant.Library.BLL;

namespace Restaurant.Presentation.Management.Member.FavouriteRestaurant
{
    public partial class YourFavouriteRestaurant : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }
        private void BindRepeater()
        {
            if (FavouriteRestaurantBLL.GetByMember(Authentication.CurrentMemberInfo.ID).Rows.Count > 0)
            {
                rptFavourite.Visible = true;
                lblMess.Visible = false;
                rptFavourite.DataSource = FavouriteRestaurantBLL.GetByMember(Authentication.CurrentMemberInfo.ID);
                rptFavourite.DataBind();
            }
            else
            {
                lblMess.Visible = true;
                lblMess.Text = "Have no Restaurant in your favourite";
                rptFavourite.Visible = false;
            }
        }

        protected void rptFavourite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int id = FavouriteRestaurantBLL.Delete(Convert.ToInt32(e.CommandArgument),Authentication.CurrentMemberInfo.ID);
                if (id >= 0)
                {
                    BindRepeater();
                }
            }
        }
    }
}