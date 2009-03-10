<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListReviewLeft.ascx.cs" Inherits="Restaurant.Presentation.Home.UserControls.ListReviewLeft" %>
<table><tr><td>
    <asp:DataList ID="dtlRestaurantInfo" runat="server" OnItemDataBound="dtlRestaurantInfo_ItemDataBound">
    <ItemTemplate>
            <div>
                <table style="width: 100%">
                    <tr>
                        <td align="center" colspan="2" valign="top">                            
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' Width="170px" Height="200px" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                        <div style="text-align:center;">
                            <asp:HyperLink ID="hplViewPhoto" runat="server">View Photo</asp:HyperLink> >>
                        </div>
                            <div style="text-align:center;">
                                <asp:Image ID = "image2" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" Width="100%" />
                            </div>
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="width:100%; text-align:center;"><br />
                            <asp:Label ID="lblRestaurantName" runat="server" Width="100%" Text='<%# Eval("Name") %>'></asp:Label>
                            <br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100%; color:Red;padding-left:10px;">
                            Meals Served:</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: auto; padding-left:30px;">
                            <asp:Label ID="lblMeals" runat="server" Width="100%" Text='<%# Eval("MealServed") %>'></asp:Label><br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="color:Red; padding-left:10px;">
                            Payment:</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%; padding-left:30px;">
                            <asp:Label ID="lblPayment" runat="server" Text='<%# Eval("CreditCard") %>'></asp:Label><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="height: 21px; color:Red;padding-left:10px;">
                            Dress Code:</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%; padding-left:30px;">
                            <asp:Repeater ID="repeaterDressCode" runat="server" >
                            <ItemTemplate>
                                <div style="width:100%;">
                                    <asp:Label ID="lblDressCode" runat="server" Text='<%# Eval("AttireName") %>'></asp:Label><br />
                                </div>
                            </ItemTemplate>
                            </asp:Repeater>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="color:Red;padding-left:10px;">
                            Dated Opened:</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%; padding-left:30px;">
                            <asp:Label ID="lblDateOpened" runat="server" Text='<%# Eval("DateOpen") %>' Width="100%"></asp:Label><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="color:Red;padding-left:10px;">
                            Good For:</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%; padding-left:30px;">
                            <asp:Repeater ID="repeaterGoodFor" runat="server" >
                            <ItemTemplate>
                                <div style="width:100%;">
                                    <asp:Label ID="lblGoodFor" runat="server" Text='<%# Eval("GoodForName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            </asp:Repeater><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="color:Red;padding-left:10px;">
                            Special Feature:</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%; padding-left:30px;">
                            <asp:Repeater ID="repeaterSpecial" runat="server">
                            <ItemTemplate>
                                <div style="width:100%;">
                                    <asp:Label ID="lblSpecial" runat="server" Text='<%# Eval("SpecialName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            </asp:Repeater><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="color:Red;padding-left:10px;">
                            Vibe/Atmosphere:</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%; padding-left:30px;">
                            <asp:Repeater ID="repeaterAtmosphere" runat="server">
                            <ItemTemplate>
                                <div style="width:100%;">
                                    <asp:Label ID="lblAtmosphere" runat="server" Text='<%# Eval("AtmosphereName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            </asp:Repeater><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="color:Red; padding-left:10px;">
                            Hours:</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%; padding-left:30px;">
                            <asp:Repeater ID="repeaterHours" runat="server">
                            <ItemTemplate>
                                <div style="width:100%;">
                                    <asp:Label ID="lblHours" runat="server" Text='<%# Eval("Hours") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            </asp:Repeater><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="width:100%;">
                            <asp:Image ID = "image3" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Media/Images/leftAds2.jpg" Width="170px" Height="300px" />
                        </td>
                    </tr>
                </table>
            
            </div>
        </ItemTemplate>

    </asp:DataList>

</td></tr></table>