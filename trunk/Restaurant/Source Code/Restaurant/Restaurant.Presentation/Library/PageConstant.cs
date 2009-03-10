using System;

namespace Restaurant.Presentation.Library
{
    public class PageConstant
    {
        #region SystemConstant
        public const string USERNAME_LOGINED = @"212Cuisine_UserName";
        public const string PASSWORD_LOGINED = @"212Cuisine_Password_ISD";
        public const string MEMBER_ACCOUNT = @"Member_Account";
        public const string MEMBER_INFO = @"Member_Information";
        public const string MEMBER_RESTAURANT = @"Member_Restaurant";
        public const int ADMIN = 0;
        public const int RESTAURANT = 1;
        public const int MEMBER = 2;
        public const string ADMIN_MEMBERID = "Admin_MemberId";
        public const string NEXT_URL = @"&NextURL=";
        public const string PACKAGE_ID = @"&PackageID=";
        public const string RESTAURANT_ID = @"&RidUrl=";
        public const string GIFT_ID = @"&GidUrl=";
        public const int TRANSACTION_PURCHASE_PACKAGE = 1;
        public const int TRANSACTION_PURCHASE_GIFT = 2;
        public const int TRANSACTION_PURCHASE_ORDER = 3;
        public const int TRANSACTION_PURCHASE_RESERVATION = 4;
        public const string SUPPLIER_PAYPAL = "Paypal";
        public const string SUPPLIER_AUTHORIZE = "Authorize";
        #endregion

        #region AdminUrlRewrite
        public const string ADMIN_URL = @"~/Administrator/Default.aspx";
        public const string ADMIN_PROFILE_URL = @"~/Administrator/Default.aspx?ctrl=Profile";
        public const string ADMIN_CHANGEPASSWORD_URL = @"~/Administrator/Default.aspx?ctrl=ChangePassword";
        public const string ADMIN_LOGIN_URL = @"~/Administrator/Login.aspx";
        public const string ADMIN_LIST_GIFT_PURCHASE = @"/Administrator/GiftCertificates/Default.aspx?ctrl=ListGiftPurchase";
        public const string ADMIN_REVIEWMANAGEMENT_URL = @"~/Administrator/Default.aspx?ctrl=ReviewManagement";
        public const string ADMIN_RESTAURANT_MANAGEMENT_URL = @"~/Administrator/Default.aspx?ctrl=RestaurantManagement";
        public const string ADMIN_ADD_RESTAURANT_MANAGEMENT_URL = @"~/Administrator/Default.aspx?ctrl=AddRestaurant";
        public const string ADMIN_CHOOSE_PACKAGE_URL = @"~/Administrator/Default.aspx?ctrl=ChoosePackage";
        public const string ADMIN_CREATE_MEMBER_URL = @"~/Administrator/Default.aspx?ctrl=CreateMember";
        public const string ADMIN_DEFINE_GIFT_TYPE = @"~/Administrator/Default.aspx?ctrl=GiftType";
        public const string ADMIN_DEFINE_GIFT_DESIGN = @"~/Administrator/Default.aspx?ctrl=GiftDesign";
        public const string ADMIN_DEFINE_GIFT_COMMISSION = @"~/Administrator/Default.aspx?ctrl=GiftCommission";
        public const string ADMINI_DEFINE_RESERVATION_COMMISSION = @"~/Administrator/Default.aspx?ctrl=ReservationCommission";
        public const string ADMIN_SETTING_MAIL_SERVER = @"~/Administrator/Default.aspx?ctrl=MailServer";
        public const string ADMIN_SETTING_ACCOUNT_PAYPAL = "~/Administrator/Default.aspx?ctrl=BusinessAccountPaypal";
        public const string ADMIN_RESERVETION_GIFT = @"/Administrator/Default.aspx?ctrl=ReservationGift";
        #endregion

        #region ManagementUrlRewrite
        public const string MANAGEMENT_URL = @"~/Management/Default.aspx";
        public const string MANAGEMENT_MEMBER_VIEW_PROFILE = @"~/Management/Default.aspx?mid=Profile";
        public const string MANAGEMENT_MEMBER_CHANGE_PASSWORD = @"~/Management/Default.aspx?mid=ChangePassword";
        public const string MANAGEMENT_MEMBER_WELCOME = @"~/Management/Default.aspx?mid=welcome";
        public const string MANAGEMENT_MEMBER_REVIEW = @"~/Management/Default.aspx?mid=MemberReview";
        public const string MANAGEMENT_MEMBER_MY_GIFT = @"~/Management/Default.aspx?mid=MyGift";
        public const string MANAGEMENT_MEMBER_RESTAURANT = @"~/Management/Default.aspx?mid=MemberRestaurant";
        public const string MANAGEMENT_MEMBER_MY_RESERVATION = @"~/Management/Default.aspx?mid=MyReservation";
        public const string MANAGEMENT_MEMBER_HISTORY_TRANSACTION = @"~/Management/Default.aspx?mid=TransactionHistory";
        public const string MANAGEMENT_MEMBER_UNDERCONSTRUCTION = @"~/Management/Default.aspx?mid=VideoManagement";

        public const string MANAGEMENT_RESTAURANT_BLOCK = @"~/Management/Default.aspx?mid=BlockRestaurant";
        public const string MANAGEMENT_RESTAURANT_SETTING_SERVICE = @"~/Management/Default.aspx?mid=SettingService";
        public const string MANAGEMENT_RESTAURANT_GIFT_PURCHASE = @"~/Management/Default.aspx?mid=GiftPurchaseManagement";
        public const string MANAGEMENT_RESTAURANT_GIFT_PARAMETER = @"~/Management/Default.aspx?mid=GiftParameter";
        public const string MANAGEMENT_RESTAURAN_MENUITEM = @"~/Management/Default.aspx?mid=MenuItem";
        public const string MANAGEMENT_RESTAURAN_MENUCATEGORY = @"~/Management/Default.aspx?mid=MenuCategory";
        public const string MANAGEMENT_RESTAURANT_PROFILE = "~/Management/Default.aspx?mid=RestaurantProfile";
        public const string MANAGEMENT_RESTAURANT_PHOTO = @"~/Management/Default.aspx?mid=PhotoManagement";
        public const string MANAGEMENT_RESTAURANT_RENEW = @"~/Management/Default.aspx?mid=Renew";
        public const string MANAGEMENT_RESTAURANT_YOUR_RESTAURANT = @"~/Management/Default.aspx?mid=YourRestaurant";
        public const string MANAGEMENT_RESTAURANT_CHOOSE_PACKAGE = @"~/Management/Default.aspx?mid=ChoosePackage";
        public const string MANAGEMENT_RESTAURANT_PURCHASE_PACKAGE = @"~/Management/Default.aspx?mid=PurchasePackage";
        public const string MANAGEMENT_RESTAURANT_THANKS_FOR_RENEW = @"~/Management/Default.aspx?mid=ThankForRenew";
        public const string MANAGEMENT_RESTAURANT_ORDER_PARAMETER = @"~/Management/Default.aspx?mid=OrderParam";
        public const string MANAGEMENT_RESTAURANT_RESERVATION = @"~/Management/Default.aspx?mid=ReservationManagement";
        public const string MANAGEMENT_FAVORITES_RESTAURANT = @"~/Management/Default.aspx?mid=FavouriteRestaurant";
        public const string MANAGEMENT_RESTAURANT_BUSINESS_ACCOUNT = @"/Management/Default.aspx?mid=BusinessAccount";
        
        #endregion

        #region HomeUrlRewrite
        public const string HOME_URL = @"~/Default.aspx";
        public const string HOME_MEMBER_TERM_OF_USE_URL = @"~/Default.aspx?pid=TermOfUse";
        public const string HOME_MEMBER_REGISTER_URL = @"~/Default.aspx?pid=MemberRegistration";
        public const string HOME_MEMBER_SUCCESSFULL_URL = @"~/Default.aspx?pid=MemberRegistrationSuccessfull";
        public const string HOME_MEMBER_CREATE_REVIEW_URL = @"~/Default.aspx?pid=MemberCreateReview";
        public const string HOME_MEMBER_EDIT_REVIEW_URL = @"~/Default.aspx?pid=MemberEditReview";
        public const string HOME_MEMBER_RECEIVE_URL = @"~/Default.aspx?pid=MemberReceiveReview";
        public const string HOME_MEMBER_INSTANCE_GIFT_URL = @"~/Default.aspx?pid=InstanceGift";
        public const string HOME_MEMBER_PURCHASE_GIFT_URL = @"~/Default.aspx?pid=PurchaseGift";
        public const string HOME_MEMBER_THANK_FOR_USE_GIFT = @"~/Default.aspx?pid=ThankyouForUseGift";
        public const string HOME_MEMBER_LOGIN_FOR_PURCHASE_URL = @"~/Default.aspx?pid=LoginForPurchase";
        
        public const string HOME_LIST_PHOTO_URL = @"~/Default.aspx?pid=ListPhoto";
        public const string HOME_PHOTO_DETAIL_URL = @"~/Default.aspx?pid=PhotoDetail";
        public const string HOME_LOGIN_URL = @"~/Default.aspx?pid=Login";
        public const string HOME_LOGOUT_URL = @"~/Default.aspx?pid=Logout";
        public const string HOME_PUBLIC_LIST_REVIEW_URL = @"~/Default.aspx?pid=ListReview";
        public const string HOME_PUBLIC_REVIEW_DETAIL_URL = @"~/Default.aspx?pid=ReviewDetail";

        public const string HOME_RESTAURANT_CHOOSE_PACKAGE_URL = @"~/Default.aspx?pid=RestaurantChoosePackage";
        public const string HOME_RESTAURANT_INFORMATION_URL = @"~/Default.aspx?pid=RestaurantInformation";
        public const string HOME_RESTAURANT_CONTACT = @"~/Default.aspx?pid=RestaurantContact";
        public const string HOME_RESTAURANT_PURCHASE_PACKAGE_URL = @"~/Default.aspx?pid=RestaurantPurchasePackage";
        public const string HOME_RESTAURANT_THANK_FOR_REGISTRY_URL = @"~/Default.aspx?pid=ThankyouForRegistry";

        public const string HOME_RESTAURANT_LISTING_URL = @"~/Default.aspx?pid=ListRestaurant";
        public const string HOME_RESTAURANT_MENU = @"~/Default.aspx?pid=Menu";
        public const string HOME_RESTAURANT_MENUITEM = @"~/Default.aspx?pid=MenuItem";
        public const string HOME_MEMBER_CONTACT_RESTAURANT = @"~/Default.aspx?pid=ContactRestaurant";
        public const string HOME_MEMBER_RECOMMEND_FRIEND = @"~/Default.aspx?pid=RecommendFriend";

        public const string HOME_MEMBER_INSTANCE_RESERVATION_URL = @"~/Default.aspx?pid=InstanceReservation";
        public const string HOME_MEMBER_PROCESS_RESERVATION = @"~/Default.aspx?pid=ProcessReservation";
        public const string HOME_MEMBER_THANKS_FOR_RESERVATION = @"~/Default.aspx?pid=ThankyouForUseReservation";
        public const string HOME_MEMBER_VIDEO = @"~/Default.aspx?pid=Video";
        #endregion

        #region XMLFileConfig
        public const string ADMIN_XML_FILE_CONFIG = @"~/App_Data/AdminConfig.xml";
        public const string MEMBER_XML_FILE_CONFIG = @"~/App_Data/MemberConfig.xml";
        public const string PAGE_XML_FILE_CONFIG = @"~/App_Data/PageConfig.xml";
        public const string DELIVERY_XML_FILE_CONFIG = @"~/App_Data/DeliveryConfig.xml";
        public const string RESTAURANT_XML_FILE_CONFIG = @"~/App_Data/RestaurantConfig.xml";
        #endregion

        #region CaptChaImage
        public const string CAPT_CHA_IMAGE = "CaptChaImage";
        #endregion

        #region SessionName
        public const string SESSION_MEMBER_INFO = @"MemberInfo";
        public const string SESSION_RESTAURANT_INFO = @"Restaurant";
        public const string SESSION_PACKAGE_DETAIL = @"PackageDetailID";
        public const string SESSION_RESTAURANT_GOODFOR = @"RestaurantGoodFor";
        public const string SESSION_RESTAURANT_NEIGHBOURHOOD = @"RestaurantNeighbourhood";
        public const string SESSION_RESTAURANT_CUISINE = @"RestaurantCuisine";
        public const string SESSION_RESTAURANT_SPECIAL = @"RestaurantSpecial";
        public const string SESSION_RESTAURANT_MUSIC = @"RestaurantMusic";
        public const string SESSION_RESTAURANT_ATTIRE = @"RestaurantAttire";
        public const string SESSION_RESTAURANT_ATMOSPHERE = @"RestaurantAtmosphere";
        public const string SESSION_GIFT_CERTIFICATE = @"GiftCertificate";
        public const string SESSION_RESERVATION = @"Reservation";
        public const string SESSION_TRANSACTION = @"Transaction";
        public const string SESSION_PRICE = @"Price";
        #endregion

        #region StateEntities
        public const int STATUS_TRANSACTION_PENDING = 1;
        public const int STATUS_TRANSACTION_CONFIRMED = 2;
        public const int STATUS_TRANSACTION_REJECTED = 3;
        public const int STATUS_REALIZED = 1;
        public const int STATUS_NOT_REALIZED = 0;
        //public const int STATUS_WAITING_FROM_MEMBER = 3;
        //public const int STATUS_DEFAULT = 0;
        #endregion

        #region GroupParameter
        public const string GROUP_EMAIL_SERVER_PARAMETER = "SystemEmailServer";
        public const string GROUP_GIFT_PARAMETER = "SystemGiftParameter";
        public const string GROUP_ORDER_PARAMETER = "SystemDeliveryParameter";
        public const string GROUP_RESERVATION_PARAMETER = "SystemReservationParameter";
        public const string GROUP_PAYPAL_PARAMETER = "SystemPaypalParameter";
        public const string GROUP_AUTHORIZE_PARAMETER = "SystemAuthorizeParameter";
        #endregion

        #region ParameterName
        public const string PARAMETER_GIFT_COMMISSION = "SystemGiftCommission";
        public const string PARAMETER_DELIVERY_COMMISSION = "SystemDeliveryCommission";
        public const string PARAMETER_RESERVATION_COMMISSION = "SystemReservationCommission";

        public const string PARAMETER_MAIL_SERVER_HOST = "MailServerHost";
        public const string PARAMETER_MAIL_SERVER_PORT = "MailServerPort";
        public const string PARAMETER_MAIL_SERVER_USERNAME = "MailServerUserName";
        public const string PARAMETER_MAIL_SERVER_PASSWORD = "MailServerPassword";

        public const string PARAMETER_PAYPAL_USERNAME = "PaypalUserName";
        public const string PARAMETER_PAYPAL_PASSWORD = "PaypalPassword";
        public const string PARAMETER_PAYPAL_SIGNATURE = "PaypalSignature";
        #endregion

        #region Delivery Url Rewrite
        public const string HOME_DELIVERY_URL = @"~/Delivery/Default.aspx?did=Delivery";
        public const string HOME_DELIVERY_SEARCH_URL = @"~/Delivery/Default.aspx?did=DeliverySearch";
        public const string HOME_DELIVERY_RESTAURANT_DETAIL = @"~/Delivery/Default.aspx?did=RestaurantDetail";
        public const string HOME_DELIVERY_CITY =@"~/Delivery/Default.aspx?did=ChooseCity";
        #endregion
    }
}
