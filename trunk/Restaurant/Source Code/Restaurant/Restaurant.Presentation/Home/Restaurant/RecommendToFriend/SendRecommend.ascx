<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendRecommend.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.RecommendToFriend.SendRecommend" %>
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
                <td rowspan="1" style="width: auto; height: 50px; padding-left: 15px;" valign="top">
                    <table style="width:485px;">
                        <caption style="font-weight:bold;font-size:medium;text-align:center;padding-bottom:15px;">Recommend To Your Friend!</caption>
                        <tr>
                            <td style="width: 98px">
                            </td>
                            <td align="center">
                                <asp:Label ID="lblMess" runat="server" Font-Italic="True" ForeColor="Yellow" Text="Label"
                                    Visible="False" Width="100%" Font-Size="17px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 98px">
                                Your email</td>
                            <td>
                                <asp:TextBox ID="txtYourMail" runat="server" Width="300px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="***" ControlToValidate="txtYourMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="***" ControlToValidate="txtYourMail"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 98px">
                                Friend's email&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtFriendMail" runat="server" Width="300px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="***" ControlToValidate="txtFriendMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="***" ControlToValidate="txtFriendMail"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 98px" valign="top">
                                Your message&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtMessage" runat="server" Width="300px" Height="160px" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="***" ControlToValidate="txtMessage"></asp:RequiredFieldValidator></td>
                        </tr>
                         <tr>
                            <td style="width: 98px">
                                </td>
                            <td>
                                <asp:Button ID="btnSendMail" runat="server" CssClass="Button" OnClick="btnSendMail_Click"
                                    Text="Send Your Recommend" Width="155px" /></td>
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