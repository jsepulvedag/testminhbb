<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HomeSearch.ascx.cs"
    Inherits="Restaurant.Presentation.Home.UserControls.HomeSearch" %>
<%@ Register Assembly="RadComboBox.Net2" Namespace="Telerik.WebControls" TagPrefix="radC" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>

    <div class="banner_contact" style="width: 302">
        <div style="width: 100px; float: left; margin: 0 auto; height: 25px; color: Black"
            align="right">
            Restaurant Name</div>
        <div style="margin: 0 auto; height: 25px; padding-left: 4px;">
            <asp:TextBox ID="txtRestaurantName" runat="server" Width="200px" Height="15px" BorderStyle="Solid"
                BorderWidth="1px"></asp:TextBox>
        </div>
      
        <div style="width: 100px; float: left; margin: 0 auto; height: 25px; color: Black"
            align="right">
            Zip</div>
        <div style="margin: 0 auto; height: 25px; padding-left: 4px;">
            <asp:TextBox ID="txtZip" runat="server" Width="200px" Height="15px" BorderStyle="Solid"
                BorderWidth="1px"></asp:TextBox>
        </div>
        <div style="width: 100px; float: left; margin: 0 auto; height: 25px; color: Black"
            align="right">
            Cuisine</div>
        <div style="margin: 0 auto; height: 25px; padding-left: 4px;">
            <asp:DropDownList ID="drpCuisine" runat="server" DataTextField="Name" DataValueField="Id"
                Width="202px">
            </asp:DropDownList>
        </div>
        <div style="width: 100px; float: left; margin: 0 auto; height: 25px;" align="right">
        </div>
        <div style="margin: 0 auto; height: 25px">
            <div class="AddvandeSearch" style="width: 110px; float: left; font-size: 13px; font-weight: bold">
                <asp:HyperLink ID="linkAdvanceSearch" runat="server" Text="Advance Search"></asp:HyperLink>
            </div>
            <div style="width: 92px; float: left" align="right">
                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Media/Images/search.gif"
                    OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>
