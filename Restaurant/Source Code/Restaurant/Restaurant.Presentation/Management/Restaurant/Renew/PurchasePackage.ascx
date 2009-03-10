<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PurchasePackage.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Renew.PurchasePackage" %>

        <table style="width:700px;">
            <tr>
                <td style="width:40%;text-align:right;height:28px;">
                    Payment&nbsp;</td>
                <td>
                    <asp:DropDownList ID="drpPayment" runat="server" Width="130px">
                        <asp:ListItem Selected="True" Value="0">Paypal</asp:ListItem>
                        <asp:ListItem Value="1">Authorize</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width:40%;text-align:right;height:28px;">
                    Card type&nbsp;</td>
                <td>
                    <asp:DropDownList ID="drpCardType" runat="server" Width="130px">
                        <asp:ListItem Selected="True">Visa</asp:ListItem>
                        <asp:ListItem>Mastercard</asp:ListItem>
                        <asp:ListItem>Amex</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width:40%;text-align:right;height:28px;">
                    Card number&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtCardNumber" runat="server" Width="200px"></asp:TextBox>(1111-1111-1111-1111)<asp:Label
                        ID="lblError" runat="server" ForeColor="Red" Text="Invalid !" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:40%;text-align:right;height:28px;">
                    Exp date&nbsp;</td>
                <td>
                    <asp:DropDownList ID="drpExpMonth" runat="server" Width="112px">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="drpExYear" runat="server" Width="83px">
                    </asp:DropDownList>&nbsp;(month/year)<asp:Label ID="lblError1" runat="server" ForeColor="Red"
                        Text="Invalid !" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:40%;text-align:right;height:28px;">
                    CCV&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtCCV" runat="server" Width="128px"></asp:TextBox></td>
            </tr>
        </table>
        <hr style="color:White;border:1px;width:600px;text-align:center;margin:0 auto;" />
        <table  style="width:700px;">
            <tr>
                <td style="width:50%;text-align:right;height:28px;">
                    <asp:Button ID="btnContinue" runat="server" Text="Continue" Width="130px" CssClass="Button" OnClick="btnContinue_Click"/></td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" CssClass="Button" OnClick="btnCancel_Click"/></td>
            </tr>
        </table>
