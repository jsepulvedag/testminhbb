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
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Presentation.Management.Restaurant.Menu
{
    public partial class Addon : System.Web.UI.UserControl
    {
        //DataTable VirtualTable()
        //{
        //    DataTable virTable = new DataTable();
        //    virTable.Columns.Add("Id");

        //    DataRow virRow = virTable.NewRow();
        //    virRow["Id"] = "1";
        //    virTable.Rows.Add(virRow);

        //    virRow = virTable.NewRow();
        //    virRow["Id"] = "2";
        //    virTable.Rows.Add(virRow);

        //    return virTable;
        //    //dgPage.DataSource = virTable;
        //    //dgPage.DataBind();
        //}
        void BindAddonGroup(int menuCategoryID)
        {
            //rptAddonGroup.DataSource = VirtualTable();
            //rptAddonGroup.DataBind();
            DataTable tbl = MenuAddonGroupBLL.GetByMenuCategory(menuCategoryID, -1);
            rptAddonGroup.DataSource = tbl;
            rptAddonGroup.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            int menuCategoryID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
            BindAddonGroup(menuCategoryID);
            
        }

        protected void rptAddonGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lkbShowHide = (LinkButton)e.Item.FindControl("lkbShowHide");
                HiddenField hdIsActive = (HiddenField)e.Item.FindControl("hdIsActive");
                if (hdIsActive.Value == "True")
                {
                    lkbShowHide.Text = "Hide";
                }
                else
                {
                    lkbShowHide.Text = "Show";
                }
                Repeater rptAddon = (Repeater)e.Item.FindControl("rptAddon");
                HiddenField hdfAddonGroup = (HiddenField)e.Item.FindControl("hdfAddonGroupID");

                //rptAddon.DataSource = VirtualTable();
                //rptAddon.DataBind();
                int addonGroupID = Convert.ToInt32(hdfAddonGroup.Value);
                DataTable tbl = MenuAddonBLL.GetByMenuAddonGroup(addonGroupID, -1);
                rptAddon.DataSource = tbl;
                rptAddon.DataBind();
            }
        }

        protected void rptAddon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lbShowHide = (LinkButton)e.Item.FindControl("lkbAddonShowHide");
            HiddenField hdfIsActive = (HiddenField)e.Item.FindControl("hdfIsActive");
            if (hdfIsActive.Value =="True")
            {
                lbShowHide.Text = "Hide";
            }
            else
            {
                lbShowHide.Text = "Show";
            }
        }
        protected void rptAddonGroup_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int menuCategoryID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
            if (e.CommandName == "AddAddon")
            {
                string addonName = (e.Item.FindControl("txtAddonName") as TextBox).Text;
                int menuAddonGroupID = Convert.ToInt32(e.CommandArgument);
                MenuAddonInfo menuAddonInfo = new MenuAddonInfo();
                menuAddonInfo.MenuAddonGroupID = menuAddonGroupID;
                menuAddonInfo.Name = addonName;
                menuAddonInfo.IsActive = 1;
                menuAddonInfo.Price = (e.Item.FindControl("txtAddonPrice") as TextBox).Text;
                MenuAddonBLL.Insert(menuAddonInfo);
                (e.Item.FindControl("txtAddonName") as TextBox).Text = "";
                (e.Item.FindControl("txtAddonPrice") as TextBox).Text = "";
                Repeater rptAddon = (Repeater)e.Item.FindControl("rptAddon");
                DataTable tbl = MenuAddonBLL.GetByMenuAddonGroup(menuAddonGroupID, -1);
                rptAddon.DataSource = tbl;
                rptAddon.DataBind();
            }
            if (e.CommandName == "Update")
            {
                int addonGroupId = Convert.ToInt32(e.CommandArgument);
                string addonGroupName = (e.Item.FindControl("txtAddonGroupName") as TextBox).Text;
                MenuAddonGroupBLL.Update(addonGroupId, addonGroupName);
               
                int ID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
                BindAddonGroup(ID);
            }
            if (e.CommandName == "Delete")
            {
                int ID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
                int addonGroupId = Convert.ToInt32(e.CommandArgument);
                MenuAddonGroupBLL.Delete(addonGroupId,ID);
                BindAddonGroup(ID);
            }
            if (e.CommandName == "Up")
            {
                int ID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
                try
                {
                    int addonGroupId = Convert.ToInt32(e.CommandArgument);
                    MenuAddonGroupBLL.Up(addonGroupId);

                }
                catch
                {
                    BindAddonGroup(ID);
                }
                BindAddonGroup(ID);
            }
            if (e.CommandName == "Down")
            {
                int ID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
                try
                {
                    int addonGroupId = Convert.ToInt32(e.CommandArgument);
                    MenuAddonGroupBLL.Down(addonGroupId);
                }
                catch
                {
                    BindAddonGroup(ID);
                }
                BindAddonGroup(ID);
            }
            if (e.CommandName == "ShowHide")
            {
                LinkButton lkbShowHide = (LinkButton)e.Item.FindControl("lkbShowHide");
                int addonGroupId = Convert.ToInt32(e.CommandArgument);
                if (lkbShowHide.Text == "Show")
                {
                    MenuAddonGroupBLL.UpdateIsActive(addonGroupId, 1);

                }
                else
                {
                    MenuAddonGroupBLL.UpdateIsActive(addonGroupId, 0);
                }
                int ID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
                BindAddonGroup(ID);
            }
        }

        protected void rptAddon_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Update")
                {
                    int addonId = Convert.ToInt32(e.CommandArgument);
                    string addonName = (e.Item.FindControl("txtEditAddonName") as TextBox).Text;
                    MenuAddonBLL.Update(addonId, addonName);
                }
                if (e.CommandName == "Delete")
                {
                    int addonId = Convert.ToInt32(e.CommandArgument);
                    HiddenField hdfAddonGroup = (HiddenField)e.Item.FindControl("AddonGroupID");
                    int addonGroupID = Convert.ToInt32(hdfAddonGroup.Value);
                    MenuAddonBLL.Delete(addonId, addonGroupID);

                    
                }
                if (e.CommandName == "Up")
                {
                    try
                    {
                        int addonId = Convert.ToInt32(e.CommandArgument);
                        MenuAddonBLL.Up(addonId);
                    }
                    catch
                    { 
                    
                    }
                }
                if (e.CommandName == "Down")
                {
                    try
                    {
                        int addonId = Convert.ToInt32(e.CommandArgument);
                        MenuAddonBLL.Down(addonId);
                    }
                    catch
                    { 
                    
                    }
                 
                }

                if (e.CommandName == "ShowHide")
                {
                    LinkButton lbShowHide = (LinkButton)e.Item.FindControl("lkbAddonShowHide");
                    HiddenField hdfIsActive = (HiddenField)e.Item.FindControl("hdfIsActive");
                    int addonId = Convert.ToInt32(e.CommandArgument);
                    if (lbShowHide.Text == "Show")
                    {
                        MenuAddonBLL.UpdateIsActive(addonId, 1);

                    }
                    else
                        MenuAddonBLL.UpdateIsActive(addonId, 0);
                }
                int ID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
                BindAddonGroup(ID);
            }
        }
        public MenuAddonGroupInfo menuAddonGroupInfo()
        {
            int menuCategoryID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
            MenuAddonGroupInfo menuAddonGroupInfo = new MenuAddonGroupInfo();
            menuAddonGroupInfo.MenuCategoryID = menuCategoryID;
            menuAddonGroupInfo.Name = txtAddAddonGroupName.Text;
            menuAddonGroupInfo.IsActive = 1;
            return menuAddonGroupInfo;
        }
        protected void bntAddAddonGroup_Click(object sender, EventArgs e)
        {
            MenuAddonGroupBLL.Insert(menuAddonGroupInfo());
            int menuCategoryID = Convert.ToInt32(Request.QueryString["menuCategoryID"]);
            BindAddonGroup(menuCategoryID);
        }
    }
}