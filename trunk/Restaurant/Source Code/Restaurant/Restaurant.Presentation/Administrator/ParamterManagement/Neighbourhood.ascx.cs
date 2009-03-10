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
    public partial class Neighbourhood : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindState();
                BindCity();
                BindNeighbourhood();
                string[] option ={ "active", "inactive" };
                drdIsactive.DataSource = option;
                drdIsactive.DataBind();
              
            }
        }
        public void BindCountry()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drdCountry);
        }
        public void BindState()
        {
            int countryID = Convert.ToInt32(drdCountry.SelectedValue);
            Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID), drdState);
        }
        public void BindCity()
        {
            int stateID;
            if (Int32.TryParse(drdState.SelectedValue.ToString(), out stateID))
            {
                Utility.BindingDropDowList(CityBLL.GetByStateID(stateID), drdCity);
                if (drdCity.Items.Count <= 0)
                {
                    neighbourhood.Visible = false;
                }
                else
                {
                    neighbourhood.Visible = true;
                }
            }
        }
        public void BindNeighbourhood()
        {
            int cityID;
            if(Int32.TryParse(drdCity.SelectedValue.ToString(),out cityID))
            {
                dgrNeighbourhood.DataSource = NeighbourhoodBLL.GetByCityID(cityID);
                dgrNeighbourhood.DataBind();
                if (dgrNeighbourhood.Items.Count > 0)
                {
                    neighbourhood.Visible = true;
                }
                else
                {
                    neighbourhood.Visible = false;
                }
            }
        }
        protected void dgrNeighbourhood_ItemDataBound(object sender, DataGridItemEventArgs e)
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

        protected void dgrNeighbourhood_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox txtDescription = (TextBox)e.Item.FindControl("txtDescription");
            TextBox txtName = (TextBox)e.Item.FindControl("txtName");
            LinkButton lbtEdit = (LinkButton)e.Item.FindControl("lbtEdit");
            Label lbDescription = (Label)e.Item.FindControl("lbDescription");
            DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");

            if (e.CommandName == "Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                NeighbourhoodInfo neighbourhoodInfo = new NeighbourhoodInfo();
                neighbourhoodInfo.Name = txtName.Text;
                neighbourhoodInfo.Description = txtDescription.Text;
                neighbourhoodInfo.ID = id;
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
                neighbourhoodInfo.IsActive = isactive;
                NeighbourhoodBLL.Update(neighbourhoodInfo);
                txtName.Visible = false;
                lbtEdit.Visible = true;
                lbDescription.Visible = true;
                txtDescription.Visible = false;
                BindNeighbourhood();
            }
            if (e.CommandName == "Delete")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    NeighbourhoodBLL.Delete(id);
                    lbError.Visible=false;
                }
                catch
                {
                    lbError.Visible=true;
                    lbError.Text = "You can't delete this neighbourhood! ";
                }
                BindNeighbourhood();
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
            NeighbourhoodInfo neighbourhoodInfo = new NeighbourhoodInfo();
            int cityID = Convert.ToInt32(drdCity.SelectedValue);
            neighbourhoodInfo.Name = txtname.Text;
            neighbourhoodInfo.Description = txtDescription.Text;
            neighbourhoodInfo.CityID = cityID;
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
            neighbourhoodInfo.IsActive = isactive;
            NeighbourhoodBLL.Insert(neighbourhoodInfo);
            pnAdd.Visible = false;
            lbError.Visible=false;
            BindNeighbourhood();
        }

        protected void hpAdd_Click(object sender, EventArgs e)
        {
            pnAdd.Visible = true;
        }

        protected void drdCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drdCity.SelectedValue != null)
            {
                BindNeighbourhood();
            }
        }

        protected void drdState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drdState.SelectedValue != null)
            {
                BindCity();
                BindNeighbourhood();
            }
        }

        protected void drdCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drdCountry.SelectedValue != null)
            {
                BindState();
                BindCity();
                BindNeighbourhood();
            }
        }
    }
}