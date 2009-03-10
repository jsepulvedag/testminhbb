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
    public partial class Attire : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAttire();
            }
        }
        public void BindAttire()
        {
            DataTable tb = AttireBLL.GetAll();
            dgrAttire.DataSource = tb;
            dgrAttire.DataBind();
        }
        protected void dgrAttire_ItemDataBound(object sender, DataGridItemEventArgs e)
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

        protected void dgrAttire_ItemCommand(object source, DataGridCommandEventArgs e)
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
                AttireInfo attireInfo = new AttireInfo();
                attireInfo.Name = txtName.Text;
                attireInfo.Description = txtDescription.Text;
                attireInfo.ID = id;
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
                attireInfo.IsActive = isactive;
                AttireBLL.Update(attireInfo);
                txtName.Visible = false;
                lbtEdit.Visible = true;
                lbDescription.Visible = true;
                txtDescription.Visible = false;
                BindAttire();
            }
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (AttireBLL.Delete(Convert.ToInt32(e.CommandArgument)) == true)
                {
                    lbError.Visible = false;
                    BindAttire();
                }
                else
                {
                    lbError.Visible = true;
                    lbError.Text = "You can't delete this Attire! ";
                }
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
            AttireInfo attireInfo = new AttireInfo();
            attireInfo.Name = txtname.Text;
            attireInfo.Description = txtDescription.Text;
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
            attireInfo.IsActive = isactive;
            AttireBLL.Insert(attireInfo);
            pnAdd.Visible = false;
            lbError.Visible = false;
            BindAttire();
        }
    }
}