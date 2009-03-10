<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Home.ascx.cs" Inherits="Restaurant.Presentation.Home.UserControls.Home" %>
<%@ Register Src="~/Home/UserControls/HomeSearch.ascx" TagPrefix="uc" TagName="HomeSearch" %>
<%@ Register Src="~/Home/UserControls/HomeSideBar.ascx" TagPrefix="uc" TagName="HomeSideBar" %>
<%@ Register Src="~/Home/UserControls/HomeVideo.ascx" TagPrefix="uc" TagName="HomeVideo" %>
<%@ Register Src="~/Home/UserControls/RestaurantByCuisine.ascx" TagPrefix="uc" TagName="RestaurantByCuisine" %>
<div id="banner_contact">
    <uc:HomeSearch ID="HomeSearch1" runat="server" />
</div>
<div id="page_constant">
    <div class="page_constant">
        <div id="content">
            <div class="content_box">
                <div class="blast_top_box_bg">
                    <uc:RestaurantByCuisine ID="RestaurantByCuisine1" runat="server" />
                </div>
            </div>
            <div class="content_box">
                <div class="blast_top_box_bg">
                    <uc:HomeVideo ID="HomeVideo1" runat="server" />
                </div>
            </div>
            <div style="width: 642px">
                <asp:ImageButton ID="imgbtnAds3" runat="server" ImageUrl="~/Media/Images/home_23.gif" />
            </div>
        </div>
        <div id="sidebarRight">
            <uc:HomeSideBar ID="HomeSideBar1" runat="server" />
        </div>
    </div>
</div>
