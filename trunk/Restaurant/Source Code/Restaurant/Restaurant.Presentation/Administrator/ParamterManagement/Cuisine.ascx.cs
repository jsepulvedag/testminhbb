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

namespace Restaurant.Presentation.Administrator.ParamterManagement
{
    public partial class Cuisine : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindCuisine();
            }
        }
        public void BindCuisine()
        {
            DataTable tb = CuisineBLL.GetAll();
            dgrCuisine.DataSource = tb;
            dgrCuisine.DataBind();
        }
        protected void dgrCuisine_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdActive = (HiddenField)e.Item.FindControl("hdActive");
                DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");
                if (drdIsActive != null)
                {
                    if (hdActive.Value == "False")
                    {
                        drdIsActive.SelectedValue = "inactive";
                    }
                    else
                        drdIsActive.SelectedValue = "active";
                    string[] option ={ "active", "inactive" };
                    drdIsActive.DataSource = option;
                    drdIsactive.DataSource = option;
                    drdIsactive.DataBind();
                    drdIsActive.DataBind();
                }
            }
        }

        protected void dgrCuisine_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox txtDescription = (TextBox)e.Item.FindControl("txtDescription");
            TextBox txtName = (TextBox)e.Item.FindControl("txtName");
            LinkButton lbtEdit = (LinkButton)e.Item.FindControl("lbtEdit");
            Label lbDescription = (Label)e.Item.FindControl("lbDescription");
            DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");
            int cityID = Convert.ToInt32(Request.QueryString["CityID"]);
            if (e.CommandName == "Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CuisineInfo cuisineInfo = new CuisineInfo();
                cuisineInfo.Name = txtName.Text;
                cuisineInfo.Description = txtDescription.Text;
                cuisineInfo.ID = id;
                string active = drdIsActive.SelectedValue;
                Boolean isactive = false;
                if (active == "active")
                {
                    isactive = true;
                }
                else
                {
                    isactive = false;
                }
                cuisineInfo.IsActive = isactive;
                CuisineBLL.Update(cuisineInfo);
                txtName.Visible = false;
                lbtEdit.Visible = true;
                lbDescription.Visible = true;
                txtDescription.Visible = false;
                BindCuisine();
            }
            if (e.CommandName == "Delete")
            {
                if (CuisineBLL.Delete(Convert.ToInt32(e.CommandArgument)) == true)
                {
                    lbError.Visible = false;
                    BindCuisine();
                }
                else
                {
                    lbError.Visible = true;
                    lbError.Text = "You can't delete this cuisine! ";
                }
                
                //try
                //{
                //    int del = CuisineBLL.Delete(id);
                //    if (del == 0)
                //        lbError.Visible = false;
                //    else
                //        lbError.Visible = true;
                //    lbError.Text = "You can't delete this cuisine! ";
                //}
                //catch {
                //    lbError.Visible = true;
                //    lbError.Text = "You can't delete this cuisine! ";
                //}
                
            }
            if (e.CommandName == "Edit")
            {
                txtName.Visible = true;
                lbtEdit.Visible = false;
                lbDescription.Visible = false;
                txtDescription.Visible = true;

            }
        }

        protected void hpAdd_Click(object sender, EventArgs e)
        {
            pnAdd.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CuisineInfo cuisineInfo = new CuisineInfo();
            cuisineInfo.Name = txtname.Text;
            cuisineInfo.Description = txtDescription.Text;
            string active = drdIsactive.SelectedValue;
            Boolean isactive = false;
            if (active == "active")
            {
                isactive = true;
            }
            else
            {
                isactive = false;
            }
            cuisineInfo.IsActive = isactive;
            CuisineBLL.Insert(cuisineInfo);
            pnAdd.Visible = false;
            lbError.Visible = false;
            BindCuisine();
        }

        protected void dgrCuisine_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgrCuisine.CurrentPageIndex = e.NewPageIndex;
            BindCuisine();
        }
    }
}