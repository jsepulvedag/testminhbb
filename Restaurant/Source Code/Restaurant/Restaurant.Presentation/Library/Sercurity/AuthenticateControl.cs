using System;
using System.Web.UI;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library.Sercurity.Base;

namespace Restaurant.Presentation.Library.Sercurity
{
    public class AuthenticateControl : UserControl
    {
        public BasePage Authentication
        {
            get { return (BasePage)this.Page; }
        }
    }
}
