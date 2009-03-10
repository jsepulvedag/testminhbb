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
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Home.Member.Video
{
    public partial class ListVideo :AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               int restaurantID = Authentication.CurrentRestaurantInfo.ID;
               BindListVideo(restaurantID);
            }
        }
        public void BindListVideo(int restaurantID)
        {
            DataTable tbl = VideoBLL.GetTopVideo(restaurantID);
            dtlListVideo.DataSource = tbl;
            dtlListVideo.DataBind();
        }

        protected void dtlListVideo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "picture")
            {
                Response.Redirect("~/Default.aspx?pid=Video&VideoID="+ Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void dtlListVideo_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblDescription = (Label)e.Item.FindControl("lblDescription");
                Label lblDes = (Label)e.Item.FindControl("lblDes");
                int len = lblDes.Text.Length;
                if(lblDes.Text.Length>50)
                 len=50;
                lblDescription.Text = lblDes.Text.Substring(0,len);
                
            }
          
        }
    }
}