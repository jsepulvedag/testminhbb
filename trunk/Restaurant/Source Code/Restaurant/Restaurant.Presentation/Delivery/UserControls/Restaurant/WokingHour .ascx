<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WokingHour .ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.WokingHour" %>

<asp:Repeater ID="rptOrderTime" runat="server" OnItemDataBound="rptOrderTime_ItemDataBound">
    <HeaderTemplate>
        <table width="400px" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse;margin:0 auto;">
            <tr style="background-color:#EDE5D0;font-weight:bold">
                <td></td>
                <td >Business Hours</td>
                <td >Delivery Hours</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td >
                <asp:Literal ID="ltDayOfWeek" runat="server"></asp:Literal>
                <%#Eval("DayOfWeek") %>
                <asp:Literal ID="BusinessHour" runat="server"></asp:Literal>
            </td>
            <td>
                <asp:Literal ID="ltBusinessHour" runat="server"></asp:Literal>
            </td>
            <td>
                <asp:Literal ID="ltDeliveryHour" runat="server"></asp:Literal>
            </td>
        </tr>
    </ItemTemplate>
    
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
