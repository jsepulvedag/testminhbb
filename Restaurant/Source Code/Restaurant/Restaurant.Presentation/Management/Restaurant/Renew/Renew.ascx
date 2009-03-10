<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Renew.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Renew.Renew" %>

        <table style="width:100%;">
            <caption style="text-align: left; font-size: medium; padding-left:10px;height:30px; padding-top:5px; font-weight: bold;">
                Your restaurant is expired, please renew !</caption>
            <tr>
                <td style="text-align:right;">
                    <asp:Button ID="btnRenew" runat="server" Text="Renew restaurant" Width="130px" CssClass="Button" OnClick="btnRenew_Click" /></td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" CssClass="Button" /></td>
            </tr>
        </table>