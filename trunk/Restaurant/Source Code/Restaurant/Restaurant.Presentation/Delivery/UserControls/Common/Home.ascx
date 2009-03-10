<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Common.Home" %>
<%@ Register Src="~/Delivery/UserControls/Restaurant/Filter.ascx" TagName="Filter" TagPrefix="uc1" %>
<%@ Register Src="~/Delivery/UserControls/Restaurant/DeliverySearch.ascx" TagName="DeliverySearch" TagPrefix="uc2" %>
<table style="width: 869px; margin:0 auto;">
    <tr>
        <td style="width: 200px;" valign="top" align="left">
            <div class="homeSearch_left_Cuisine"><uc1:Filter ID="filter" runat="server" /></div>
        </td>
        <td style="width: auto" valign="top">
            <uc2:DeliverySearch ID="deliverySearch" runat="server" />
        </td>
    </tr>
</table>
