<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ListRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Restaurant.ListRestaurant.ListRestaurant" %>
<table width="98%">
    <tr>
        <td style="width: 100%; font-size: 20px;">
            My Restaurant</td>
    </tr>
    <tr>
        <td style="width: 100%; margin-left: 20px;">
            <asp:Repeater ID="repeaterListRestaurant" runat="server">
                <ItemTemplate>
                    <div style="width: 100%;">
                        <asp:HyperLink ID="hplListRestaurant" runat="server" Text='<%# Eval("Name") %>'></asp:HyperLink><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>
