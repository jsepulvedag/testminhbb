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
    public partial class State : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindState(); 
            }            
        }
        public void BindCountry()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(true), drdCountry);
        }
        public void BindState()
        {
            dgrState.DataSource = StateBLL.GetByCountryID(Convert.ToInt32(drdCountry.SelectedValue)); ;
            dgrState.DataBind();
            if (dgrState.Items.Count > 0)
            {
                pnState.Visible = true;
            }
            else
            {
                pnState.Visible = false;
            }
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
                    drdIsActive.DataBind();
                }
            }
        }
        protected void dgrCountry_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox txtEdit = (TextBox)e.Item.FindControl("txtEdit");
            LinkButton lbtEdit = (LinkButton)e.Item.FindControl("lbtEdit");
            DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");
            int CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            if (e.CommandName == "Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                StateInfo stateInfo = new StateInfo();
                stateInfo.Name = txtEdit.Text;
                stateInfo.ID = id;
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
                stateInfo.isActive = isactive;
                StateBLL.Update(stateInfo);
                txtEdit.Visible = false;
                lbtEdit.Visible = true;
                BindState();
            }
            if (e.CommandName == "Delete")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    StateBLL.Delete(id, CountryID);
                    lbError.Visible=false;
                }
                catch
                {
                    lbError.Visible=true;
                    lbError.Text = "You can't delete this state! ";
                }
                BindState();
            }
            if (e.CommandName == "Up")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                StateBLL.Up(id, CountryID);
                BindState();
            }
            if (e.CommandName == "Down")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                StateBLL.Down(id, CountryID);
                BindState();
            }
            if (e.CommandName == "Edit")
            {
                txtEdit.Visible = true;
                lbtEdit.Visible = false;
            }
        }

        protected void drdCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drdCountry.SelectedValue == null)
            {
                return;
            }
            BindState();
        }
        protected void hpAdd_Click1(object sender, EventArgs e)
        {
            pnAdd.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(drdCountry.SelectedValue);
            StateInfo stateInfo = new StateInfo();
            stateInfo.Name = txtname.Text;
            stateInfo.CountryID = id;
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
            stateInfo.isActive = isactive;
            StateBLL.Insert(stateInfo);
            pnAdd.Visible = false;
            lbError.Visible=false;
            BindState();
        }
    }
}