<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MenuItem.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.MenuItem" %>

<table width="869px" >
<tr>
<td style="width:200px;"></td>
<td style="width:500px;">
<asp:Repeater ID="rptMenuCategory" runat="server" OnItemDataBound="rptMenuCategory_ItemDataBound">
    <ItemTemplate>
        <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: Blue;
            width: 100%">
            <tr style="height: 30px;">
                <td style="width: 5px;">
                </td>
                <td style="width: 395px;" class="menuCategory color7">
                     <%#Eval("Name") %>
                </td>
                <td style="width: 70px;">
                    <%#Eval("PriceHeading1") %>
                    &nbsp;
                </td>
                <td style="width: 70px;">
                    <%#Eval("PriceHeading2") %>
                    &nbsp;
                </td>
                <td style="width: 70px;">
                    <%#Eval("PriceHeading3") %>
                    &nbsp;
                </td>
                <td style="width: 50px;">
                </td>
            
            </tr>
        </table>
        <asp:Repeater ID="rptMenuItem" runat="server" OnItemDataBound="rptMenuItem_ItemDataBound">
          
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="0" style="background-color:Silver;
                    width: 100%">
                    <tr style="height: 30px;">
                        <td style="width: 5px;">
                        </td>
                        <td style="width: 400px;">
                        <asp:HyperLink ID="hplItem" runat="server" Text='<%#Eval("Name") %>' NavigateUrl='<%#"~/Delivery/Default.aspx?did=AddOn&menuItemID="+Eval("ID") %>'></asp:HyperLink>
                          
                            &nbsp;&nbsp;<span class="color4"><%#Eval("ShortDescription") %></span>
                        </td>
                        <td style="width: 70px;" class="color6">
                            <asp:Literal ID="ltPrice1" runat="server"></asp:Literal>
                            &nbsp;
                        </td>
                        <td style="width: 70px;" class="color6">
                            <asp:Literal ID="ltPrice2" runat="server"></asp:Literal>
                            &nbsp;
                        </td>
                        <td style="width: 70px;" class="color6">
                            <asp:Literal ID="ltPrice3" runat="server"></asp:Literal>
                            &nbsp;
                        </td>
                   
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </ItemTemplate>
</asp:Repeater>
</td>
<td></td>
</tr>
</table>

