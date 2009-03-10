<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyOrder.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.MyOrder" %>
<table style="background:pink;">
    <tr>
        <td style="width: 220px;padding-bottom:1px;">
            My Order
            <hr />
        </td>
    </tr>
    <tr>
        <td style="width: 220px; padding-bottom:1px;">
            <asp:Label ID="lblItem" runat="server" Text="No items yet" Visible="False"></asp:Label><br />
            <hr />
        </td>
    </tr>
    <tr>
        <td style="width: 220px;padding-bottom:1px;padding-top:1px; ">
            SubTotal:<br />
            Tax:<br />
            <hr />
            <hr />
        </td>
    </tr>
    <tr>
        <td style="width: 220px">
            Order to delivery
        </td>
    </tr>
    <tr>
        <td style="width: 220px">
            Pick date/time</td>
    </tr>
    <tr>
        <td style="width: 220px">
        </td>
    </tr>
</table>

