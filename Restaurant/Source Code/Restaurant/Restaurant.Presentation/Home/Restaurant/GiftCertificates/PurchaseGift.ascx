<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PurchaseGift.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.GiftCertificates.PurchaseGift" %>
<%@ Register Src="~/Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail" TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="ReviewLeft" TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="ReviewRight" TagPrefix="uc" %>

<div style="margin: 0 auto; width: 869px; height: auto;">
    <div id="pageRestaurantByCuisineHeader">
    </div>
    <div class="pageRestaurantByCuisineCenter">
    <div style="width: 869px; float: left;">
        <uc:RestaurantDetail ID="RestaurantDetail1" runat="server" />
    </div>
    <div style="width: 869px; float: left;">
        <table style="width: 100%">
            <tr>
                <td rowspan="2" style="width: 174px" valign="top">
                    <uc:ReviewLeft ID="RestaurantReviewLeft" runat="server"></uc:ReviewLeft>
                </td>
                <td rowspan="1" style="width: auto; height: 50px; padding-left: 15px;" valign="top"><br />
                    <asp:Label ID="lblMess" runat="server" Visible= "false" ></asp:Label>
                    <table style="width:485px;">
                        <caption style="font-weight:bold;font-size:medium;">Payment for your gift certificate</caption>
                        <tr>
                            <td style="width:80px;text-align:left;padding-top:5px;">
                                Holder's Name&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtHolderName" runat="server" Text="" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHolderName"
                                    ErrorMessage="(*)"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:80px;text-align:left;padding-top:5px;">
                                Card type&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="drpCardType" runat="server" Width="95px">
                                    <asp:ListItem Selected="True">Visa</asp:ListItem>
                                    <asp:ListItem>Mastercard</asp:ListItem>
                                    <asp:ListItem>Amex</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width:80px;text-align:left;padding-top:5px;">
                                Card number&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtCardNumber" runat="server" Width="200px"></asp:TextBox>(1111-1111-1111-1111)<asp:Label
                                    ID="lblError" runat="server" ForeColor="Red" Text="(*)" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width:80px;text-align:left;padding-top:5px;">
                                Exp date&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="drpExpMonth" runat="server" Width="95px">
                                </asp:DropDownList>&nbsp;
                                <asp:DropDownList ID="drpExYear" runat="server" Width="50px">
                                </asp:DropDownList>&nbsp;(month/year)<asp:Label ID="lblError1" runat="server" ForeColor="Red"
                                    Text="(*)" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width:80px;text-align:left;padding-top:5px;">
                                CCV&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtCCV" runat="server" Width="93px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width:80px;text-align:left;padding-top:5px;">
                                
                            </td>
                            <td>
                                <asp:Button ID="btnContinue" runat="server" Text="Continue" Width="96px" CssClass="Button" OnClick="btnContinue_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="96px" CssClass="Button" OnClick="btnCancel_Click"/>
                            </td>
                        </tr>
                    </table>
                </td>
                <td rowspan="2" style="width: 181px" valign="top">
                    <uc:ReviewRight ID="ReviewRight" runat="server"></uc:ReviewRight>
                </td>
            </tr>
        </table>
    </div>
    </div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>

        
        
