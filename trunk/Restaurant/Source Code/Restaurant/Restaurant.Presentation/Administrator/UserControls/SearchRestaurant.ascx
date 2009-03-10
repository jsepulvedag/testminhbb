<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SearchRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.UserControls.SearchRestaurant" %>
<div class="banner_contact" style="width: 302">
    <div style="width: 130px; float: left; margin: 0 auto; height: 25px; color: White"
        align="right">
        Restaurant Name</div>
    <div style="margin: 0 auto; height: 25px; padding-left: 10px;">
        <asp:TextBox ID="txtRestaurantName" runat="server" Width="200px" Height="15px" BorderStyle="Solid"
            BorderWidth="1px"></asp:TextBox>
    </div>
    <div style="width: 130px; float: left; margin: 0 auto; height: 25px; color: White"
        align="right">
        Country</div>
    <div style="margin: 0 auto; height: 25px; padding-left: 10px;">
        <asp:DropDownList ID="drpCountry" runat="server" Width="202px" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged">
        </asp:DropDownList></div>
    <div style="width: 130px; float: left; margin: 0 auto; height: 25px; color: White"
        align="right">
        State</div>
    <div style="margin: 0 auto; height: 25px; padding-left: 10px;">
        <asp:DropDownList ID="drpState" runat="server" Width="202px" OnSelectedIndexChanged="drpState_SelectedIndexChanged">
        </asp:DropDownList></div>
    <div style="width: 130px; float: left; margin: 0 auto; height: 25px; color: White"
        align="right">
        City</div>
    <div style="margin: 0 auto; height: 25px; padding-left: 10px;">
        <asp:DropDownList ID="drpCity" runat="server" Width="202px">
        </asp:DropDownList>
    </div>
    <div style="width: 130px; float: left; margin: 0 auto; height: 25px; color: White"
        align="right">
        Zip</div>
    <div style="margin: 0 auto; height: 25px; padding-left: 10px;">
        <asp:TextBox ID="txtZip" runat="server" Width="200px" Height="15px" BorderStyle="Solid"
            BorderWidth="1px"></asp:TextBox>
    </div>
    <div style="width: 130px; float: left; margin: 0 auto; height: 25px; color: White"
        align="right">
        Cuisine</div>
    <div style="margin: 0 auto; height: 25px; padding-left: 10px;">
        <asp:DropDownList ID="drpCuisine" runat="server" Width="202px">
        </asp:DropDownList>
    </div>
    <div style="width: 130px; float: left; margin: 0 auto; height: 25px;" align="right">
    </div>
    <div style="margin: 0 auto; height: 25px">
        <div class="AddvandeSearch" style="float: left; font-size: 13px; font-weight: bold; color:White;">
            <asp:HyperLink ID="linkAdvanceSearch" runat="server" Text="Advance Search"></asp:HyperLink>
        </div>
        <div style="width: 72px; float: left;" align="right">
            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Media/Images/search.gif"
                OnClick="btnSearch_Click" />
        </div>
    </div>
</div>
