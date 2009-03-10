<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Menu.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.Menu.Menu" %>
<%@ Register Src="~/Home/Restaurant/UserControls/TabBar.ascx" TagName="TabBar" TagPrefix="uc1" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="Left" TagPrefix="uc2" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="Right" TagPrefix="uc3" %>
<%@ Register Src="~/Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail"
    TagPrefix="uc4" %>
<div style="margin: 0 auto; text-align: center; width: 869px;">
    <div id="pageRestaurantByCuisineHeader">
    </div>
    <div class="pageRestaurantByCuisineCenter" style="margin: 0 auto; width: 869px; height: auto;">
        <div style="width: 869px; float: left;">
            <uc4:RestaurantDetail runat="server" ID="resDetail"></uc4:RestaurantDetail>
        </div>
        <div class="pageRestaurantByCuisineCenter" style="width: 869px; float: right;">
            <table style="width: 100%">
                <tr>
                    <td colspan="3" valign="top">
                        <table width="100%">
                            <tr>
                                <td style="width: 100px;">
                                    <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/Media/Images/menuIcon.jpg"
                                        Width="100px" />
                                </td>
                                <td style="width: auto; font-size: 30pt; color: #ff0000; padding-left:10px;">
                                    <span><em>Menu</em></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 174px" valign="top">
                        <uc2:Left ID="left" runat="server" />
                    </td>
                    <td style="width: auto" valign="top">
                        <asp:Repeater ID="rptMenuCategory" runat="server" OnItemDataBound="rptMenuCategory_ItemDataBound" OnItemCommand="rptMenuCategory_ItemCommand">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" width="99%" border="0" style="background-color: #403e3f;
                                    width: 100%">
                                    <tr style="height: 30px;">
                                        <td style="width: 5px;">
                                        </td>
                                        <td style="width: 300px;" class="menuCategory color7">
                                            <%#Eval("Name") %>
                                        </td>
                                        <td style="width: 50px;">
                                            <%#Eval("PriceHeading1") %>
                                            &nbsp;
                                        </td>
                                        <td style="width: 50px;">
                                            <%#Eval("PriceHeading2") %>
                                            &nbsp;
                                        </td>
                                        <td style="width: 50px;">
                                            <%#Eval("PriceHeading3") %>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <asp:Repeater ID="rptMenuItem" runat="server" OnItemDataBound="rptMenuItem_ItemDataBound">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" style="background-color: #393738;
                                            width: 100%">
                                            <tr style="height: 30px;">
                                                <td style="width: 5px;">
                                                </td>
                                                <td style="width: 300px;">
                                                    <b><span class="menuItem"><a href='/Default.aspx?pid=MenuItem&menuItemId=<%#Eval("Id")+ "&RidUrl=" + Convert.ToString(GetRestaurantID) %>'>
                                                        <%#Eval("Name") %>
                                                    </a></span></b>&nbsp;<span class="color4"><%#Eval("ShortDescription") %></span>
                                                </td>
                                                <td style="width: 50px;" class="color6">
                                                    <asp:Literal ID="ltPrice1" runat="server"></asp:Literal>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 50px;" class="color6">
                                                    <asp:Literal ID="ltPrice2" runat="server"></asp:Literal>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 50px;" class="color6">
                                                    <asp:Literal ID="ltPrice3" runat="server"></asp:Literal>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                        </asp:Repeater>
                        <br /><br />
                       <%-- <asp:Repeater ID="rptMenuAddonGroup" runat="server" OnItemDataBound="rptMenuAddonGroup_ItemDataBound" >
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" width="99%" border="0" style="background-color: #403e3f;
                                    width: 100%">
                                    <tr style="height: 30px;">
                                        <td style="width: 5px;">
                                        </td>
                                        <td style="width: 300px;" class="menuCategory color1">
                                            <%#Eval("Name") %>
                                        </td>
                                        <td style="width: 150px;">
                                            <%#Eval("Description") %>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <asp:Repeater ID="rptMenuAddon" runat="server" OnItemDataBound="rptMenuAddon_ItemDataBound">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" style="background-color: #393738;
                                            width: 100%">
                                            <tr style="height: 30px;">
                                                <td style="width: 5px;">
                                                </td>
                                                <td style="width: 300px;">
                                                    <b><span class="menuItem">
                                                        <%#Eval("Name") %>
                                                    </span></b>&nbsp;
                                                </td>
                                                <td style="width: 150px;" class="color6">
                                                    <asp:Literal ID="ltPriceAddon" runat="server"></asp:Literal>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                        </asp:Repeater>--%>
                    </td>
                    <td style="width: 181px" valign="top">
                        <uc3:Right ID="right" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" valign="top" align="center" style="padding-left: 3px;">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Media/Images/menuTouchmore.jpg"
                            Width="99%" /></td>
                </tr>
            </table>
        </div>
    </div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>
