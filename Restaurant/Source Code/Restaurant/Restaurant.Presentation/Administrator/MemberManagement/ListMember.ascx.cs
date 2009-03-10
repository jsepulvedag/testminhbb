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


namespace Restaurant.Presentation.Administrator.MemberManagement
{
    public partial class ListMember : AuthenticateControl// System.Web.UI.UserControl
    {
        int pageSize =15;
        int pageIndex = 0;
        int pageCount = 0;
        int total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMemberSearch("","", pageIndex, pageSize, ref total);
                pageCount = GetPageCount(pageSize, total);
            }
        }
        public void BindCountry()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drdCountry);
        }

        public void BindState()
        {
            int countryID = Convert.ToInt32(drdCountry.SelectedValue);
            if (StateBLL.GetByCountryID(countryID).Rows.Count <= 0)
            {
                countryID = Convert.ToInt32(CountryBLL.GetByPriority().Rows[0]["ID"].ToString());
                drdCountry.SelectedValue= countryID.ToString();
            }
            Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID), drdState);
        }
        public void BindCity()
        {
            int StateID = Convert.ToInt32(drdState.SelectedValue);
            if (CityBLL.GetByStateID(StateID).Rows.Count <= 0)
            {
                Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drdCountry.SelectedValue)), drdState);
                StateID= Convert.ToInt32(drdState.SelectedValue);
            }
            Utility.BindingDropDowList(CityBLL.GetByStateID(StateID), drdCity);
        }
        private void BindMonth()
        {
            string[] members = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] values = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            Utility.BindingDropDowList(Utility.CreateTable(values, members), drdMonth);
        }
        private void BindDay()
        {
            string[] members = new string[31];
            string[] values = new string[31];
            for (int i = 0; i <= 30; i++)
            {
                members[i] = Convert.ToString(i + 1);
                values[i] = Convert.ToString(i + 1);
            }
            Utility.BindingDropDowList(Utility.CreateTable(members, values), drdDate);
        }
        private void BindYear()
        {
            string[] years = new string[120];
            for (int i = 0; i < 120; i++)
            {
                years[i] = Convert.ToString(DateTime.Now.Year - i);
            }
            Utility.BindingDropDowList(Utility.CreateTable(years, years), drdYear);
        }
        public MemberInfo GetMember(int MemberID)
        {
            MemberInfo reval = new MemberInfo();
            reval = MemberBLL.GetByMemberID(MemberID);
            return reval;
        }
        public void BindMemberInfo(int MemberID)
        {
            lbmemberID.Text = Convert.ToString(GetMember(MemberID).ID);
            txtEmail.Text = GetMember(MemberID).Email;
            txtFirstName.Text = GetMember(MemberID).FirstName;
            txtLastName.Text = GetMember(MemberID).LastName;
            txtAddress.Text = GetMember(MemberID).Address;
            txtPhone.Text = GetMember(MemberID).Phone;
            drdGender.SelectedValue = GetMember(MemberID).Gender;
            txtZipcode.Text = GetMember(MemberID).ZipCode;
            txtFax.Text = GetMember(MemberID).Fax;
            cbReciveMail.Checked = GetMember(MemberID).IsWantReciveMail;
            drdMonth.SelectedValue = Convert.ToString(GetMember(MemberID).Birthday.Month);
            drdDate.SelectedValue = Convert.ToString(GetMember(MemberID).Birthday.Day);
            drdYear.SelectedValue = Convert.ToString(GetMember(MemberID).Birthday.Year);
            drdActive.SelectedValue = Convert.ToString(GetMember(MemberID).IsActive);
            drdCountry.SelectedValue = Convert.ToString( GetMember(MemberID).CountryID);
            BindState();
            drdState.SelectedValue = Convert.ToString( GetMember(MemberID).StateID);
            BindCity();
            drdCity.SelectedValue =  Convert.ToString(GetMember(MemberID).CityID);
        }
        private MemberInfo SetMemberInfo()
        {
            string birthday;
            birthday = drdMonth.SelectedValue.ToString() + "/" + drdDate.SelectedValue.ToString() + "/" + drdYear.SelectedValue.ToString();
            MemberInfo userInfo = new MemberInfo();
            userInfo.Email = txtEmail.Text.Trim();
            userInfo.ID = Convert.ToInt32(lbmemberID.Text.Trim());
            userInfo.FirstName = txtFirstName.Text.Trim();
            userInfo.LastName = txtLastName.Text.Trim();
            userInfo.Address = txtAddress.Text.Trim();
            userInfo.Phone = txtPhone.Text.Trim();
            userInfo.Gender = drdGender.Text;
            userInfo.Birthday = DateTime.Parse(birthday);
            userInfo.ZipCode = txtZipcode.Text.Trim();
            userInfo.Fax = txtFax.Text;
            userInfo.IsWantReciveMail = cbReciveMail.Checked;
            userInfo.IsActive = Convert.ToBoolean(drdActive.SelectedValue);
            userInfo.CountryID = Convert.ToInt32(drdCountry.SelectedValue.ToString());
            userInfo.StateID = Convert.ToInt32(drdState.SelectedValue.ToString());
            userInfo.CityID = Convert.ToInt32(drdCity.SelectedValue.ToString());

            return userInfo;

        }
        protected void dgrListMember_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                pnSearch.Visible = false;
                pnEdit.Visible = true;
                int memberID = Convert.ToInt32(e.CommandArgument);
                BindCountry();
                BindState();
                BindCity();
                BindMonth();
                BindDay();
                BindYear();
                BindMemberInfo(memberID);
                lbError.Visible = false;
                return;
                
            }
            if (e.CommandName == "Delete")
            {
                //try
                //{
                //    int ID = Convert.ToInt32(e.CommandArgument);
                //    MemberBLL.DeleteMember(ID);
                //    BindMemberSearch("", "", pageIndex, pageSize, ref total);
                //    pageCount = GetPageCount(pageSize, total);
                //    lbError.Visible = false;
                //}
                //catch
                //{
                //    lbError.Visible = true;
                //}
                //return;
            }
            if (e.CommandName == "Update")
            {
                DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");
                Boolean active = false;
                int MemberID = Convert.ToInt32(e.CommandArgument);
                MemberInfo memberInfo = new MemberInfo();
                memberInfo.ID = MemberID;
                if (drdIsActive.SelectedValue == "active")
                {
                    active = true;
                    memberInfo.IsActive = active;
                }
                if (drdIsActive.SelectedValue == "inactive")
                {
                    memberInfo.IsActive = active;
                }
                int i = MemberBLL.UpdateIsActive(memberInfo);
                if (i > 0)
                {
                    BindMemberSearch("", "", pageIndex, pageSize, ref total);
                    pageCount = GetPageCount(pageSize, total);
                }
                lbError.Visible = false;
                return;
               
            }
            if (e.CommandName == "LogAsThisMember")
            {
                Authentication.AdminMemberId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("/Management/Default.aspx?mid=Profile");
            }
        }
        protected void dgrListMember_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdActive = (HiddenField)e.Item.FindControl("hdActive");
                DropDownList drdIsActive = (DropDownList)e.Item.FindControl("drdActive");
                if (drdIsActive != null)
                {
                    drdIsActive.SelectedValue = hdActive.Value;
                    string[] option ={ "active", "inactive" };
                    drdIsActive.DataSource = option;
                    drdIsActive.DataBind();
                    DataTable tbl = MemberBLL.GetAll();
                    int count = tbl.Rows.Count;
                }
            }
        }
        protected void dgrListMember_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgrListMember.CurrentPageIndex = e.NewPageIndex;
            BindMemberSearch("", "", pageIndex, pageSize, ref total);
        }
        public void BindMemberSearch(string keyword, string active, int pageIndex, int pageSize, ref int total)
        {
            DataTable tbl = MemberBLL.SearchMember(keyword, active,pageIndex,pageSize, ref total);
            if (tbl.Rows.Count > 0)
            {
                dgrListMember.DataSource = tbl;
                dgrListMember.DataBind();
                pnListMember.Visible = true;
                lbsearch.Visible = false;
            }
            else
            {
                lbsearch.Visible = true;
                pnListMember.Visible = false;
            }
        }
        private int GetPageCount(int _pageSize, int _totalRecord)
        {
            int t = (_totalRecord / _pageSize);//div operator
            int mod = (_totalRecord % _pageSize);//mod operator
            if (mod == 0)
            {
                pageCount = t;
            }
            else
            {
                if (mod < _pageSize)
                {
                    pageCount = t + 1;
                }
                else
                {
                    pageCount = t + 2;
                }
            }
            string[] strPage = new string[pageCount];
            for (int i = 0; i < pageCount; i++)
            {
                strPage[i] = Convert.ToString(i + 1);
            }
            Utility.BindingDropDowList(dropPage, Utility.CreateTable(strPage, strPage));
            return pageCount;
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            pnEdit.Visible = false;
            BindMemberSearch("", "", pageIndex, pageSize, ref total);
            lbError.Visible = false;
            pnSearch.Visible = true;
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            int i = MemberBLL.UpdateMember(SetMemberInfo());
            if (i == -1)
            {
                lbEmail.Text = AppEnv.EMAIL_EXIST;
            }
            else
            {
                BindMemberSearch("", "", pageIndex, pageSize, ref total);
                pageCount = GetPageCount(pageSize, total);
                pnEdit.Visible = false;
                pnSearch.Visible = true;
            }
            lbError.Visible = false;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtkeyword.Text.ToString();
            string active = drdStatus.SelectedValue;
            BindMemberSearch(keyword, active, pageIndex, pageSize, ref total);
            pageCount = GetPageCount(pageSize, total);
            lbError.Visible = false;
        }
        protected void dropPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtkeyword.Text.ToString();
            string active = drdStatus.SelectedValue;
            dropPage.Text = dropPage.SelectedValue;
            BindMemberSearch(keyword, active, Convert.ToInt32(dropPage.SelectedValue) - 1, pageSize, ref total);
        }

        protected void drdCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
            BindCity();
        }

        protected void drdState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }
       
    }
}