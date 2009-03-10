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
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;
using Restaurant.Presentation.Management.Restaurant.UserControls;
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Management.Restaurant.Renew
{
    public partial class ChoosePackage : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_dlPackage();
                CurrentPackage();
            }
        }
        private void Bind_dlPackage()
        {
            dlPackage.DataSource = PackageBLL.GetNotFree(true);
            dlPackage.DataBind();
            if (dlPackage.Items.Count <= 0)
            {
                MessageBox.Show("Can not find any package for restaurant !");
            }
        }
        private void CurrentPackage()
        {
            RestaurantPackageDetailInfo rpd = RestaurantPackageDetailBLL.GetInfo_ByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
            if (rpd != null)
            {
                foreach (DataListItem item in dlPackage.Items)
                {
                    Repeater rpt = (Repeater)item.FindControl("rptPackageDetail");
                    if (rpt != null)
                    {
                        foreach (RepeaterItem itm in rpt.Items)
                        {
                            RadioButton rdo = (RadioButton)itm.FindControl("rdSelected");
                            if (rdo != null)
                            {
                                Label lbl = (Label)itm.FindControl("lblPackageDetailID");
                                if (lbl != null && lbl.Text.Trim() == rpd.ID.ToString())
                                {
                                    rdo.Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private int PackageDetailID_Selected()
        {
            foreach (DataListItem item in dlPackage.Items)
            {
                Repeater rpt = (Repeater)item.FindControl("rptPackageDetail");
                if (rpt != null)
                {
                    foreach (RepeaterItem itm in rpt.Items)
                    {
                        RadioButton rdo = (RadioButton)itm.FindControl("rdSelected");
                        if (rdo != null && rdo.Checked == true)
                        {
                            Label lbl = (Label)itm.FindControl("lblPackageDetailID");
                            if (lbl != null)
                            {
                                return Convert.ToInt32(lbl.Text.Trim());
                            }
                        }
                    }
                }
            }
            return 0;
        }
        protected void dlPackage_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lblPackageID");
            if (lbl != null)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Repeater rpt = (Repeater)e.Item.FindControl("rptPackageDetail");
                    if (rpt != null)
                    {
                        rpt.DataSource = PackageDetailBLL.GetByPackageID(Convert.ToInt32(lbl.Text.Trim()));
                        rpt.ItemDataBound += new RepeaterItemEventHandler(rpt_ItemDataBound);
                        rpt.DataBind();
                    }
                }
            }
        }
        void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                RadioButton rdo = (RadioButton)e.Item.FindControl("rdSelected");
                if (rdo != null)
                {
                    rdo.Attributes.Add("onclick", "SetUniqueRadioButton('rdSelected',this)");
                }
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            string packageDetailID = Convert.ToString(PackageDetailID_Selected());
            if (packageDetailID.Equals("0"))
            {
                MessageBox.Show("Select one of package");
                return;
            }
            else
            {
                Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_PURCHASE_PACKAGE + PageConstant.PACKAGE_ID + packageDetailID);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.MANAGEMENT_MEMBER_VIEW_PROFILE);
        }
    }
}