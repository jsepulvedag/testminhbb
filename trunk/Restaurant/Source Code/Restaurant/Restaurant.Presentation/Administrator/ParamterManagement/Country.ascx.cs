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
    public partial class Country : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
            }
        }
        public void BindCountry()
        {
            DataTable tbl = CountryBLL.GetAll();
            dgrCountry.DataSource = tbl;
            dgrCountry.DataBind();

        }
        protected void dgrCountry_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    drdIsActive.DataBind();
                    drdIsactive.DataBind();
                }
            }
        }

        protected void dgrCountry_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Item.FindControl("txtEdit");
            LinkButton lbtEdit = (LinkButton)e.Item.FindControl("lbtEdit");
            DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");

            if (e.CommandName == "Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CountryInfo countryInfo = new CountryInfo();
                countryInfo.ID = id;
                countryInfo.Name = txtEdit.Text;
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
                countryInfo.isActive = isactive;
                CountryBLL.Update(countryInfo);
                txtEdit.Visible = false;
                lbtEdit.Visible = true;
                BindCountry();
            }
            if (e.CommandName == "Delete")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    CountryBLL.Delete(id);
                    lbError.Visible=false;
                }
                catch
                {
                    lbError.Visible=true;
                    lbError.Text = "You can't delete this country! ";
                }
                BindCountry();
            }
            if (e.CommandName == "Up")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CountryBLL.Up(id);
                BindCountry();
            }
            if (e.CommandName == "Down")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CountryBLL.Down(id);
                BindCountry();
            }
            if (e.CommandName == "Edit")
            {
                txtEdit.Visible = true;
                lbtEdit.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CountryInfo countryInfo = new CountryInfo();
            countryInfo.Name = txtname.Text;
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
            countryInfo.isActive = isactive;
            CountryBLL.Insert(countryInfo);
            pnAdd.Visible = false;
            lbError.Visible = false;
            BindCountry();
        }

        protected void hpAdd_Click(object sender, EventArgs e)
        {
            pnAdd.Visible = true;

        }
    }
}