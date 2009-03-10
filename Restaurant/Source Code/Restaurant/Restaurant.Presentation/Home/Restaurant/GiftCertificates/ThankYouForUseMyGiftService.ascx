<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThankYouForUseMyGiftService.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.GiftCertificates.ThankForUseMyGiftService" %>
<%@ Register Src="~/Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail" TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="ReviewLeft" TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="ReviewRight" TagPrefix="uc" %>
<div style="margin: 0 auto; width: 869px; height: auto;">
    <div id="Div1">
    </div>
    <div class="pageRestaurantByCuisineCenter">
    <div style="width: 869px; float: left;">
        <uc:RestaurantDetail ID="RestaurantDetail2" runat="server" />
    </div>
    <div style="width: 869px; float: left;">
        <table style="width: 100%">
            <tr>
                <td rowspan="2" style="width: 174px" valign="top">
                    <uc:ReviewLeft ID="RestaurantReviewLeft" runat="server"></uc:ReviewLeft>
                </td>
                <td rowspan="1" style="width: auto; height: 50px; padding-left: 15px;" valign="top">
                    <table style="width:485px;">
                        <tr>
                            <td colspan="2" style="font-size:larger;font-weight:bold;text-align:center;">
                                <asp:Label runat="server" ID="lbl" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width:50%;text-align:right;height:28px;text-align:center;">
                                <asp:Button ID="btnContinue" runat="server" Text="My gift" Width="130px" CssClass="Button" OnClick="btnContinue_Click"/></td>
                            
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
    <div id="Div2">
    </div>
</div>

