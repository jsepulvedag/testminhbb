<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThankYouForRegistration.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant.ThankYouForRegistration" %>
<div style="margin: 0 auto; width: 869px; height: auto; background-repeat:repeat-x;">
    <div class="formConntentHeader" style="text-align: left; padding-top: 7px;
        padding-left: 13px; font-size: 18px; vertical-align: middle; width:869px;">
            Thanks you!
    </div>
    <div class="formContentCenter" style="padding-top:7px;">
        <table style="width:98%;">
            <tr>
                <td style="text-align:center; height:100px; padding-top:100px; font-size:15px;">
                    212Cusine.com thanks for use my service
                </td>
            </tr>
        </table><br />
        <hr style="color:White;border:1px;width:600px;text-align:center;margin:0 auto;" /><br />
        <table  style="width:100%;">
            <tr>
                <td style="text-align:center; height:80px; padding-top:0px;" valign="top">
                    <asp:Button ID="btnContinue" runat="server" Text="My restaurant" Width="130px" CssClass="Button" OnClick="btnContinue_Click"/></td>
            </tr>
        </table>

    </div>
        <div id="pageRestaurantByCuisineFooter">
    </div>
</div>
