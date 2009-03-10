<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourRestaurant.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Renew.YourRestaurant" %>
<div id="formConntentManagement">
        <table style="width:100%;">
            <caption style="text-align: left; font-size: 13px; margin-left: 10px; font-weight: bold; padding-top:10px;">
        Your restaurant has created by administrator expired, please created !</caption>
        
            <tr>
                <td style="text-align:right;">
                    <br /><asp:Button ID="btnCreate" runat="server" Text="Create restaurant" Width="130px" OnClick="btnCreate_Click" CssClass="Button" /></td>
                <td>
                    <br /><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" OnClick="btnCancel_Click" CssClass="Button" /></td>
            </tr>
        </table>
</div>