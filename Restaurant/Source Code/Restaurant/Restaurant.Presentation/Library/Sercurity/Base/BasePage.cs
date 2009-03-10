using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using Restaurant.Library.Entities;

namespace Restaurant.Presentation.Library.Sercurity.Base
{
    public class BasePage : Page
    {
        /// <summary>
        /// RawUrl : /Default.aspx?pid=nhatnv&abc=def
        /// </summary>
        protected string RawUrl
        {
            get { return HttpUtility.UrlEncode(Request.RawUrl); }
        }
        /// <summary>
        /// UrlAbsolutePath : /Default.aspx
        /// </summary>
        protected string UrlAbsolutePath
        {
            get { return HttpUtility.UrlEncode(Request.Url.AbsolutePath); }
        }
        /// <summary>
        /// UrlAbsoluteUri : http://localhost:51060/Default.aspx?pid=nhatnv&abc=def
        /// </summary>
        protected string UrlAbsoluteUri
        {
            get { return HttpUtility.UrlEncode(Request.Url.AbsoluteUri); }
        }
        public MemberInfo CurrentMemberInfo
        {
            get
            {
                if (Context.Items[PageConstant.MEMBER_INFO] != null)
                {
                    return (MemberInfo)Context.Items[PageConstant.MEMBER_INFO];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Context.Items[PageConstant.MEMBER_INFO] = value;
            }
        }
        private AdminInfo _currentAdminInfo;
        public AdminInfo CurrentAdminInfo
        {
            get { return _currentAdminInfo; }
            set { _currentAdminInfo = value; }
        }
        public RestaurantInfo CurrentRestaurantInfo
        {
            get
            {
                if (Context.Items[PageConstant.MEMBER_RESTAURANT] != null)
                {
                    return (RestaurantInfo)Context.Items[PageConstant.MEMBER_RESTAURANT];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Context.Items[PageConstant.MEMBER_RESTAURANT] = value;
            }
        }
        public AccountLoginInfo CurrentAccountLogin
        {
            get
            {
                if (Context.Items[PageConstant.MEMBER_ACCOUNT] != null)
                {
                    return (AccountLoginInfo)Context.Items[PageConstant.MEMBER_ACCOUNT];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Context.Items[PageConstant.MEMBER_ACCOUNT] = value;
            }
        }

        public int AdminMemberId
        {
            get
            {
                if (Session[PageConstant.ADMIN_MEMBERID] != null)
                    return Convert.ToInt32(Session[PageConstant.ADMIN_MEMBERID]);
                return 0;
            }
            set
            {
                Session[PageConstant.ADMIN_MEMBERID] = value;
            }
        }

        public void Login(string username, string password, bool remember)
        {
            Logout();
            FormsAuthentication.Initialize();
            FormsAuthenticationTicket ticket;
            ticket = new FormsAuthenticationTicket(1, PageConstant.USERNAME_LOGINED + username + ";" + PageConstant.PASSWORD_LOGINED + password, DateTime.Now, DateTime.Now.AddMinutes(45), remember, "", FormsAuthentication.FormsCookiePath);
            System.Diagnostics.Trace.Write(FormsAuthentication.FormsCookiePath + FormsAuthentication.FormsCookieName);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            HttpContext.Current.Response.SetCookie(cookie);            
        }
        public void Logout()
        {
            HttpContext.Current.Items.Remove(PageConstant.MEMBER_ACCOUNT);
            HttpContext.Current.Items.Remove(PageConstant.MEMBER_RESTAURANT);
            HttpContext.Current.Items.Remove(PageConstant.MEMBER_INFO);
        //    HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            _currentAdminInfo = null;
        }
        public string UserNameLogined
        {
            get
            {
                if (IsLogined)
                {
                    string retVal = HttpContext.Current.User.Identity.Name;
                    return retVal.Substring(0, retVal.IndexOf(";")).Replace(PageConstant.USERNAME_LOGINED, string.Empty);
                }
                return null;
            }
        }
        public string PasswordLogined
        {
            get
            {
                if (IsLogined)
                {
                    string retVal = HttpContext.Current.User.Identity.Name;
                    return retVal.Substring(retVal.IndexOf(";") + 1, retVal.Length - 1 - retVal.IndexOf(";")).Replace(PageConstant.PASSWORD_LOGINED, string.Empty);
                }
                return null;
            }
        }
        public bool IsLogined
        {
            get
            {
                HttpContext context = HttpContext.Current;
                return context.User.Identity.IsAuthenticated && (context.User.Identity.Name.IndexOf(PageConstant.USERNAME_LOGINED) != -1) && (context.User.Identity.Name.IndexOf(PageConstant.USERNAME_LOGINED) != -1);
            }
        }
    }
}
