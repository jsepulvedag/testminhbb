<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Restaurant.Presentation.Administrator.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Administrator Login</title>
</head>
<body style="background-color:#333333">
    <form id="frmLoginAdmin" runat="server">
        <center>
            <asp:Panel ID="pnLogin" runat="server" Width="600px" Height="400px" style="margin:0 auto; padding-top:100px;">
            <table style="font-family: 'Times New Roman'; width: 428px; height: 126px;">
                <caption style="color:White;font-size:x-large;font-weight:normal;">Login for administrator</caption>
                <tr>
                    <td style="width: 90px; text-align:right;color:White;font-size:large;">
                        User name&nbsp;</td>
                    <td style="width: 209px" align="left">
                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" Width="220px" Height="20px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 90px; height: 25px;text-align:right;color:White; font-size:large;">
                        Password&nbsp;</td>
                    <td style="height: 26px; width: 209px;" align="left">
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="32" TextMode="Password" Width="220px" Height="20px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 90px; height: 41px;" align="right">
                        </td>
                    <td style="width: 209px; height: 41px;" align="left">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log in" Width="100px" OnClick="btnLogIn_Click" Font-Size="14pt" Height="30px" /></td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td style="color:Yellow;font-size:larger;padding-left:100px;"><asp:Label runat="server" ID="lblAlert" Visible="False">* User name or password is valid, please try again!</asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
     </center>
    </form>
</body>
</html>
