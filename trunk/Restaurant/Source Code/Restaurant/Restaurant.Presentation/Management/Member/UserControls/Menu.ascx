<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Menu.ascx.cs" Inherits="Restaurant.Presentation.Management.Member.UserControls.Menu" %>
<style type="text/css">
    .memberMenuHeader
    {
        background-color: #565455; 
        font-weight: bold;
        height: 27px;
        padding-left: 4px;
    }
</style>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr class="memberMenuHeader">
        <td>
            &nbsp;&nbsp;My Account
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hplProfile" Text="My Profile" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hplChangePassword" Text="Change password" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hplMyReservation" Text="My Reservation" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hplOrder" Text="My Order" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hplMyGiftCertificate" Text="My Gift Certificate" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hplReview" Text="My Review" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td style="border-bottom: 1px; border-color: #565455;">
                        <asp:HyperLink ID="hplFavourite" Text="My Favourite" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="16px">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hplTransactionHistory" Text="Transaction History" runat="server"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <asp:Panel ID="pnlRestaurantMenu" runat="server">
        <tr class="memberMenuHeader">
            <td>
                &nbsp;&nbsp;My Restaurant
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplRestaurantInfo" Text="Restaurant Info" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                           <asp:HyperLink ID="hplMenu" Text="Menu" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplPhoto" Text="Photo" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplVideo" Text="Video" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplEvents" Text="Events" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplSettingService" Text="Setting Service" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplBusinessAccount" Text="Business Account Paypal" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplReservation" Text="Reservation" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <%--<tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplReservationParam" Text="Reservation Param" runat="server"></asp:HyperLink>
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplOnlineOrder" Text="Online Order" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplOrderingOnlineParam" Text="Ordering Online Param" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplGiftCertificate" Text="Gift Certificate" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="hplGiftCertificateParam" Text="Gift Certificate Param" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="memberMenuHeader">
            <td>
                &nbsp;&nbsp;Switch Restaurant
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="16px">
                            &nbsp;</td>
                        <td>
                            <asp:Repeater ID="rptRestaurant" runat="server" OnItemDataBound="rptRestaurant_OnItemDataBound"
                                OnItemCommand="rptRestaurant_ItemCommand">
                                <ItemTemplate>
                                    <asp:Literal ID="ltRestaurantName" runat="server"></asp:Literal>
                                    <asp:LinkButton ID="lkbRestaurantName" CommandName="SwitchRestaurant" CommandArgument='<%#Eval("Id")%>'
                                        runat="server"></asp:LinkButton>
                                    <asp:HyperLink ID="hplRestaurantName" Visible="false" runat="server" Text='<%# Eval("Name") %>'></asp:HyperLink>
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </asp:Panel>
</table>
