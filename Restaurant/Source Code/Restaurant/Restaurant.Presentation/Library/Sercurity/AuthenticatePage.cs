using System;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library.Sercurity.Base;

namespace Restaurant.Presentation.Library.Sercurity
{
    public class AuthenticatePage : BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (CurrentAccountLogin == null && IsLogined)
            {
                CurrentAccountLogin = AccountLoginBLL.GetInfo(UserNameLogined, PasswordLogined, false);
                if (CurrentAccountLogin != null)
                {
                    if (CurrentAccountLogin.Type == PageConstant.ADMIN)
                    {
                        CurrentAdminInfo = AdminBLL.GetInfo(UserNameLogined, PasswordLogined);
                        if (AdminMemberId != 0)
                        {
                            CurrentMemberInfo = MemberBLL.GetInfo(AdminMemberId);
                            CurrentRestaurantInfo = RestaurantBLL.GetInfo(MemberBLL.GetLatestRestaurantId(CurrentMemberInfo.ID));
                        }
                    }
                    else
                    {
                        CurrentMemberInfo = MemberBLL.GetInfo(UserNameLogined, PasswordLogined, false);
                        if (CurrentRestaurantInfo == null)
                            CurrentRestaurantInfo = RestaurantBLL.GetInfo(MemberBLL.GetLatestRestaurantId(CurrentMemberInfo.ID));
                    }
                }
            }
            else if(!IsLogined)
            {
                CurrentAccountLogin = null;
            }            
        }
    }
}
