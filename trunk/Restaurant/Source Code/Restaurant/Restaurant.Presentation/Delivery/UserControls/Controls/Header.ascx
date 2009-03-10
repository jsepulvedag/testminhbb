<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Header.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Controls.Header" %>
<%@ Register Src="../Restaurant/RestaurantDetail .ascx" TagName="RestaurantDetail "
    TagPrefix="uc1" %>
<%@ Register Src="../Restaurant/WokingHour .ascx" TagName="WokingHour " TagPrefix="uc2" %>
<center>
    <div id="212deliveryheader" style="background:url(../../../Media/Delivery/Headerimg.jpg)repeat-y ; background-position:right bottom; background-color:White; padding:5px;border:solid 1px gray;">
        <div id="TopMenu" style="Float:right; width:600px;text-align:right;">
            <asp:Label ID="lblHi" runat="server" Width="120px"></asp:Label>
            <asp:HyperLink ID="lnkBtnHome" runat="server">Home</asp:HyperLink> | 
            <asp:HyperLink ID="lnkBtnSignIN" runat="server">Login</asp:HyperLink> | 
            <asp:HyperLink ID="lnkBtnCreateAccount" runat="server">Create Account</asp:HyperLink> | 
            <asp:HyperLink ID="lnkBtnHelp" runat="server">Help</asp:HyperLink>
         </div>         
        <div id="LogoArea" style="Float:left">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Media/Delivery/logo212delivery.gif" />
        </div>        
        <div id="NavigationBar" style="border:solid 1px black; font-size:12pt;background:url(../../../Media/Delivery/navbarbg.gif);width:100%; height:30px;padding-top:4px;color:White;font-weight:bold;">            
            <div id="SearchArea" style="width:300px;float:right">
                <span style="color:yellow;font-style:italic; font-weight:bold;">Search:</span><asp:TextBox ID="txtKeyword" runat="server" Text="Keyword"/>
                <asp:Button id="btnSearch" runat="server" Text="Search" />
            </div>            
            <div id="LocationArea">
                <span style="color:yellow;font-style:italic; font-weight:bold;">Your Location:</span>
                City: 
                <asp:DropDownList runat="server" ID="ddCity" Width="100px" Visible="false">
                    <asp:ListItem>Houston</asp:ListItem>
                    <asp:ListItem>Newyork</asp:ListItem>
                    <asp:ListItem>Manhattan</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbCity" runat="server" Width="100px" BackColor="white" ForeColor="black" BorderColor="black"  />
                Zip Code: 
                <asp:TextBox ID="txtZipCode" runat="server" Visible="false" Width="100px"/>
                <asp:Label ID="lbZipCode" runat="server" Width="100px" BackColor="white" ForeColor="black" BorderColor="black" />
                <asp:Button ID="btnSubmitLocation"  runat="server" Text="Submit" Visible="false" />                
                <asp:Button ID="btnChangeLocation"  runat="server" Text="Change" OnClick="btnChangeLocation_Click"/>
                <asp:ImageButton ImageUrl="~/Media/Delivery/btnNext.gif" ID="imgNext" runat="server" Visible="false" CommandName="Next" OnClick="imgNext_Click1"/>
                <asp:ImageButton ImageUrl="~/Media/Delivery/btnPrevious.gif" ID="imgPrevious" runat="server" Visible="false" CommandName="Previous" OnClick="imgPrevious_Click1" />                        
            </div>            
        </div>
    </div>
</center>
