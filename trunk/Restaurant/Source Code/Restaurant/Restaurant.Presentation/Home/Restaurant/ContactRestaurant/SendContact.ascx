<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendContact.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.ContactRestaurant.SendContact" %>
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
                <td rowspan="1" style="width: 502px; height: 50px; padding-left: 15px;" valign="top">
                    <table style="width:485px;">
                        <caption style="font-weight:bold;font-size:medium;text-align:center;padding-bottom:15px;">Contact Of You!</caption>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td align="center">
                                <asp:Label ID="lblMess" runat="server" Font-Italic="True" ForeColor="Yellow" Text="Label"
                                    Visible="False" Width="100%" Font-Size="17px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">Your email</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="***" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="***"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" valign="top">
                                Your message</td>
                            <td valign="top">
                                <asp:TextBox ID="txtMessage" runat="server" Height="160px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMessage"
                                    ErrorMessage="***"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 100px"></td>
                            <td>
                                <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send Your Contact"
                                    Width="125px" CssClass="Button" /></td>
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