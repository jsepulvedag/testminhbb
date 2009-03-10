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
using Restaurant.Library.Utilities.DataBinder;


namespace Restaurant.Presentation.Administrator.ParamterManagement
{
    public partial class City : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindState();
                BindCity();
            }
        }
        public void BindCountry()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(true), drdCountry);
        }
        public void BindState()
        {
            int countryID;
            if (Int32.TryParse(drdCountry.SelectedValue.ToString(), out countryID))
            {
                Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID,true), drdState);
            }
        }
        public void BindCity()
        {
            int stateID;
            if (Int32.TryParse(drdState.SelectedValue.ToString(), out stateID))
            {
                dgrCity.DataSource = CityBLL.GetByStateID(stateID);
                dgrCity.DataBind();
                if (dgrCity.Items.Count <= 0)
                {
                    dgrCity.Visible = false;
                }
                else
                {
                    dgrCity.Visible = true;
                }
            }
        }

        protected void dgrCity_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    drdIsActive.DataBind();
                }
            }
        }

        protected void dgrCity_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Item.FindControl("txtEdit");
            LinkButton lbtEdit = (LinkButton)e.Item.FindControl("lbtEdit");
            DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");
            int StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (e.CommandName == "Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CityInfo cityInfo = new CityInfo();
                cityInfo.Name = txtEdit.Text;
                cityInfo.ID = id;
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
                cityInfo.isActive = isactive;
                CityBLL.Update(cityInfo);
                txtEdit.Visible = false;
                lbtEdit.Visible = true;
                BindCity();
            }
            if (e.CommandName == "Delete")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    CityBLL.Delete(id, StateID);
                    lbError.Visible=false;
                }
                catch
                {
                    lbError.Visible=true;
                    lbError.Text = "You can't delete this city! ";
                }
                BindCity();
            }
            if (e.CommandName == "Up")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CityBLL.Up(id, StateID);
                BindCity();
            }
            if (e.CommandName == "Down")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CityBLL.Down(id, StateID);
                BindCity();
            }
            if (e.CommandName == "Edit")
            {
                txtEdit.Visible = true;
                lbtEdit.Visible = false;
            }
        }
        protected void drdCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
            BindCity();
        }
        protected void drdState_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnCity.Visible = true;
            BindCity();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(drdState.SelectedValue);
            CityInfo cityInfo = new CityInfo();
            cityInfo.Name = txtname.Text;
            cityInfo.StateID = id;
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
            cityInfo.isActive = isactive;
            CityBLL.Insert(cityInfo);
            pnAdd.Visible = false;
            lbError.Visible=false;
            BindCity();
        }

        protected void hpAdd_Click(object sender, EventArgs e)
        {
            pnAdd.Visible = true;
        }
    }
}