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
    public partial class Special : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSpecial();
            }
        }
        public void BindSpecial()
        {
            DataTable tb = SpecialBLL.GetByAdmin();
            dgrSpecial.DataSource = tb;
            dgrSpecial.DataBind();
        }
        protected void dgrSpecial_ItemDataBound(object sender, DataGridItemEventArgs e)
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

        protected void dgrSpecial_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox txtDescription = (TextBox)e.Item.FindControl("txtDescription");
            TextBox txtName = (TextBox)e.Item.FindControl("txtName");
            LinkButton lbtEdit = (LinkButton)e.Item.FindControl("lbtEdit");
            Label lbDescription = (Label)e.Item.FindControl("lbDescription");
            DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");
            if (e.CommandName == "Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                SpecialInfo specialInfo = new SpecialInfo();
                specialInfo.Name = txtName.Text;
                specialInfo.Description = txtDescription.Text;
                specialInfo.ID = id;
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
                specialInfo.IsActive = isactive;
                SpecialBLL.Update(specialInfo);
                txtName.Visible = false;
                lbtEdit.Visible = true;
                lbDescription.Visible = true;
                txtDescription.Visible = false;
                BindSpecial();
            }
            if (e.CommandName == "Delete")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    SpecialBLL.Delete(id);
                    lbError.Visible=false;
                }
                catch
                {
                    lbError.Visible=true;
                    lbError.Text = "You can't delete this special! ";
                }
                BindSpecial();
            }
            if (e.CommandName == "Edit")
            {
                txtName.Visible = true;
                lbtEdit.Visible = false;
                lbDescription.Visible = false;
                txtDescription.Visible = true;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SpecialInfo specialInfo = new SpecialInfo();
            specialInfo.Name = txtname.Text;
            specialInfo.Description = txtDescription.Text;
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
            specialInfo.IsActive = isactive;
            SpecialBLL.Insert(specialInfo);
            pnAdd.Visible = false;
            lbError.Visible=false;
            BindSpecial();
        }

        protected void hpAdd_Click(object sender, EventArgs e)
        {
            pnAdd.Visible = true;
        }
    }
}