<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MenuTabbar.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Restaurant.Menu.MenuTabbar" %>
<div id="formConntent" style="width:600px;padding-left:0px; float:left;" >
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-image: url(../Media/Images/restaurant_review.jpg); width: 94px; 
                    height: 34px; background-repeat:repeat-x;" align="center">
                    <p style="text-align: center; font-size: 13px;">
                        <asp:HyperLink ID="lbMenuItem" runat="server" Width="67px">Menu Item</asp:HyperLink>
                    </p>
                </td>
                <td style="background-image: url(../Media/Images/restaurant_review.jpg); width: 97px;
                    height: 34px;background-repeat:repeat-x; font-size: 13px;" align="center">
                    <p style="text-align: center;">
                        <asp:HyperLink ID="lbMenuCategry" runat="server" NavigateUrl="#" Width="96px">Menu Category</asp:HyperLink>
                    </p>
                </td>
                               
                <td valign="bottom">
                </td>
            </tr>
        </table>
</div>
