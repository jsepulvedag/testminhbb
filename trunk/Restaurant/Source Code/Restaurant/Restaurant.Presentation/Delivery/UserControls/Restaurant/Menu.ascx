<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Menu.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.Menu" %>
<style type="text/css">
    .memberMenuHeader
    {
        background-color: #565455; 
        font-weight: bold;
        height: 27px;
        padding-left: 4px;
        width:150px;
    }
</style>
<table cellpadding="0" cellspacing="0" border="0" width="200px" style="margin:0 auto">
    <asp:DataList ID="dtlMenu" runat="server" >
        <HeaderTemplate>
            &nbsp;&nbsp;Menu
        </HeaderTemplate>
        <HeaderStyle CssClass="memberMenuHeader" />
        <ItemTemplate>
            <tr >
                <td style="height:20px;padding-left:10px;">
                    <asp:HyperLink ID="hplMenu" Text='<%#Eval("Name") %>' runat="server"  NavigateUrl='<%# "~/Delivery/Default.aspx?did=MenuItem&MenuCategoryID=" + Eval("ID") %>' ></asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
    </asp:DataList>
</table>
