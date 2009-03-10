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
using Media_Player_ASP.NET_Control;

namespace Restaurant.Presentation.Home.Member.Video
{
    public partial class Video : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              int videoID= Convert.ToInt32( Request.QueryString["VideoID"] ) ;
               BindVideo(videoID);
              
            }
        }
        public void BindVideo(int videoID)
        {
            dtlVideo.DataSource = VideoBLL.GetByVideoID(videoID);
            dtlVideo.DataBind();
        }
      
        protected void dtlVideo_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lbl");
          
            string strPath = Server.MapPath(lbl.Text);
            prmSrc.Attributes["value"] = strPath;
        }

        protected void dtlVideo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}