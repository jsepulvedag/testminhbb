<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AddOn.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.AddOn" %>

<table style="background-color:Maroon;">
<tr>
<td style="background-color:Gray ; width: 515px;">
 <asp:Label ID="lblmnItemName" Font-Size="15px" Text="" runat="server" Visible="true"></asp:Label></td>
</tr>
<tr>
<td style="width: 515px" align="right">
    Quantity:
<asp:DropDownList ID="drdQuality" runat="server" Width="106px" ></asp:DropDownList>
</td>
</tr>
<tr>
<td style="width: 515px">
<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
    <ItemTemplate>
        <table width="100%" >
            <tr>
                <td>
                    <asp:Image ID="idimg" ImageUrl="~/Media/Images/arrow.jpg" runat="server" />
                    <asp:Label ID="lblAddonGroupName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px;">
                    <asp:RadioButtonList ID="rdoListAddon" runat="server" TextAlign="Right">
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>
</td>
</tr>
<tr>
<td style="width: 515px" align="center">
   <asp:Button ID="btnCart" runat="server" Text="Add To Cart" OnClick="btnCart_Click" />
</td>
</tr>
</table>
