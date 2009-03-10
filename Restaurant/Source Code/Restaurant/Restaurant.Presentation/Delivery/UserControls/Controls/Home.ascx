<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Common.Home" %>
<%@ Register Src="~/Delivery/UserControls/Restaurant/Filter.ascx" TagName="Filter" TagPrefix="uc1" %>
<%@ Register Src="~/Delivery/UserControls/Restaurant/DeliverySearch.ascx" TagName="DeliverySearch" TagPrefix="uc2" %>
<table style="width: 100%;padding:0px;border:0px;">
    <tr>
        <td style="width: 200px;" valign="top" align="left">
            <uc1:Filter ID="filter" runat="server" />
        </td>
        <td style="width: auto" valign="top">
            <uc2:DeliverySearch ID="deliverySearch" runat="server" />
        </td>
    </tr>
</table>
