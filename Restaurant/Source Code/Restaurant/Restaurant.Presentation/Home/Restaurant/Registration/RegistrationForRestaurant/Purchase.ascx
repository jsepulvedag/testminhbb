<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Purchase.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant.Purchase" %>
<div style="margin: 0 auto; width: 869px; height: auto; background-repeat:repeat-x;">
    <div class="formConntentHeader" style="text-align: left; padding-top: 7px;
        padding-left: 13px; font-size: 18px; vertical-align: middle; width:869px;">
            STEP 4/4 - Payment Information
    </div>
    <div class="formContentCenter" style="padding-top:7px;">
        <table style="width:869px;">
            <tr>
                <td align="center" colspan="3" rowspan="1" style="padding-left: 200px; text-align: center"
                    valign="top">
                    
                </td>
            </tr>
            <tr>
                <td rowspan="1" style="padding-left: 20px; width: 25%; text-align: left" valign="top">
                </td>
                <td colspan="2" style="height: 28px; text-align: left">
                    <table style="width: 50%">
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <span style="font-size: 17px; color: #ffff66">Restaurant Information Step 1 - 4<br />
                                    <br />
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px;">
                                Name</td>
                            <td style="font-size: 13px;">
                                <asp:Label ID="lblName" runat="server" CssClass="color1" Font-Italic="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px;">
                                Package</td>
                            <td style="font-size: 13px;">
                                <asp:Label ID="lblPackage" runat="server" CssClass="color1" Font-Italic="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px;">
                                Website</td>
                            <td style="font-size: 13px;">
                                <asp:Label ID="lblWebsite" runat="server" CssClass="color1" Font-Italic="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px;">
                                Email</td>
                            <td style="font-size: 13px;">
                                <asp:Label ID="lblEmail" runat="server" CssClass="color1" Font-Italic="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px;">
                                ZipCode</td>
                            <td style="font-size: 13px;">
                                <asp:Label ID="lblZipcode" runat="server" CssClass="color1" Font-Italic="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px;">
                                Address</td>
                            <td style="font-size: 13px;">
                                <asp:Label ID="lblAddress" runat="server" CssClass="color1" Font-Italic="False"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td rowspan="1" style="padding-left: 20px; text-align: left" valign="top" colspan="3">
                    <br /><hr style="color:White;border:1px;width:600px;text-align:center;margin:0 auto;" /><br />
                </td>
            </tr>
            <tr>
                <td rowspan="5" style="padding-left: 20px; width: 25%; text-align: left" valign="top">
                </td>
                <td style="width:10%;text-align:left;height:28px;">
                    Holder's Name&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtHolderName" Text="" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHolderName"
                        ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width:10%;text-align:left;height:28px;">
                    Card type&nbsp;</td>
                <td>
                    <asp:DropDownList ID="drpCardType" runat="server" Width="130px">
                        <asp:ListItem Selected="True">Visa</asp:ListItem>
                        <asp:ListItem>Mastercard</asp:ListItem>
                        <asp:ListItem>Amex</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width:10%;text-align:left;height:28px;">
                    Card number&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtCardNumber" runat="server" Width="200px"></asp:TextBox>(1111-1111-1111-1111)<asp:Label
                        ID="lblError" runat="server" ForeColor="Red" Text="(*)" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:10%;text-align:left;height:28px;">
                    Exp date&nbsp;</td>
                <td>
                    <asp:DropDownList ID="drpExpMonth" runat="server" Width="112px">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="drpExYear" runat="server" Width="83px">
                    </asp:DropDownList>&nbsp;(month/year)<asp:Label ID="lblError1" runat="server" ForeColor="Red"
                        Text="(*)" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:10%;text-align:left;height:28px;">
                    CCV&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtCCV" runat="server" Width="128px"></asp:TextBox></td>
            </tr>
        </table>
        <br /><hr style="color:White;border:1px;width:600px;text-align:center;margin:0 auto;" /><br />
        <table  style="width:700px;">
            <tr>
                <td style="width:50%;text-align:right;height:28px;">
                    <asp:Button ID="btnContinue" runat="server" Text="Continue" Width="130px" CssClass="Button" OnClick="btnContinue_Click" /></td>
                <td>
                    <asp:Button ID="btnBack" runat="server" Text="Back to Step 3/4" Width="130px" CssClass="Button" OnClick="btnBack_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" CssClass="Button" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>
    </div>
    <div id="pageRestaurantByCuisineFooter"></div>
</div>