<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginForPurchase.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.UserControls.LoginForPurchase" %>

<div id="formConntent">
    <div class="formConntentHeader" style="text-align: left; padding-top: 8px; padding-left: 13px;
        font-size: 18px; vertical-align: middle;">
        Login
    </div>
    <div class="formContentCenter">
        <table style="width:600px;">
            <tr>
                <td style="width:40%;text-align:right;color:White;font-size:small; height: 26px;">
                    User name&nbsp;</td>
                <td style="height: 26px">
                    &nbsp;<asp:TextBox ID="txtUserName" runat="server" Width="243px" MaxLength="100"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width:40%;text-align:right;color:White;font-size:small;">
                    Password&nbsp;</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtPassword" runat="server" Width="243px" TextMode="Password" MaxLength="32"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width:40%;text-align:right;color:White;font-size:small;"></td>
                <td>
                    <asp:Label ID="lblError" runat="server" Text="* Invalid username or password, please try again !" ForeColor="yellow" Visible="false"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:40%;text-align:right;color:White;font-size:small;">
                    </td>
                <td>
                    <asp:Button CssClass="Button" ID="btnLogin" runat="server" Text="Login" Width="120px" OnClick="btnLogin_Click" Font-Size="Small" />&nbsp;&nbsp
                    <asp:Button CssClass="Button" ID="btnSigup" runat="server" Text="New member" Width="120px" OnClick="btnSigup_Click" Font-Size="Small" /></td>
            </tr>
        </table>
    </div>  
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>
