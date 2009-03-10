<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.Login" %>

<div >
<table  style="width: 324px;margin-left:275px;padding-top:10px;" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2" align="center" style="background-color:Black; height: 33px;">
        <span style="color: #ffcc33"><strong>Sign In</strong></span></td>
  </tr>
  <tr style="background-color:#F9E9CA;">
    <td style="width: 40px;padding-bottom:5px;padding-top:5px;">
        Username</td>
    <td style="width: 182px"><asp:TextBox ID="txtUsername" runat="server" Width="140px" /></td>
  </tr>
  <tr style="background-color:#F9E9CA;">
    <td style="width: 40px;padding-bottom:5px;padding-top:5px; height: 34px;">
        Password</td>
    <td style="width: 182px; height: 34px;"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="140px" /></td>
  </tr>
  <tr style="background-color:#F9E9CA;">
    <td style="width: 40px;padding-bottom:5px;padding-top:5px;">&nbsp;</td>
    <td style="width: 182px"><asp:HyperLink ID="HyperLink1" runat="server" Text="Forgot your password?"></asp:HyperLink></td>
  </tr>
  <tr style="background-color:#F9E9CA;">
    <td style="width: 40px;padding-bottom:5px;padding-top:5px;">&nbsp;</td>
    <td style="width: 182px"><asp:Button ID="bntLogin" runat="server" Text="Login" Width="77px" OnClick="bntLogin_Click" /></td>
  </tr>
  <tr style="background-color:#F9E9CA;">
    <td style="width: 40px;padding-bottom:5px;padding-top:5px;">&nbsp;</td>
    <td style="width: 182px"> <asp:Label ID="lblAlert" runat="server" Text="* Invalid username or password, please try again !" Width="126%" Font-Bold="False" Font-Italic="True"></asp:Label>
                    <asp:Label ID="lblError" runat="server" Text="* Sorry your account is inactive!" Width="124%" Font-Bold="False" Font-Italic="True" Visible="False"></asp:Label></td>
  </tr>
</table>
</div>