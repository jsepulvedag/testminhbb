<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Successfull.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Member.Registration.Successfull" %>
<div style="margin: 0 auto; width: 869px; height: auto; background-repeat: repeat-x;">
    <div class="formConntentHeader" style="text-align: left; padding-top: 7px; padding-left: 13px;
        font-size: 18px; vertical-align: middle; width: 869px;">
        Thanks you!
    </div>
    <div class="formContentCenter" style="padding-top: 7px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 27px; text-align: center;">
                    <span style="font-size: medium;">Thank you for registering! Click here for Login...</span>
                </td>
            </tr>
            <tr align="center">
                <td align="center" style="height: 27px; text-align: center;">
                    <asp:Button runat="server" ID="Login" Text="Login" OnClick="Login_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>
