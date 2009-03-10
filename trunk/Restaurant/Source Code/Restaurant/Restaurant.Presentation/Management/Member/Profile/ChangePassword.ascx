<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="Restaurant.Presentation.Management.Member.Profile.ChangePassword" %>
<table style="width:500px;padding-left:150px;padding-top:10px;">
    <tr>
        <td style="width:100px;padding-top:5px;">Old password</td>
        <td>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width:100px;padding-top:5px;">New password</td>
        <td>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width:100px;padding-top:5px;">Confirm password</td>
        <td >
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                ControlToValidate="txtConfirmPassword" ErrorMessage="*"></asp:CompareValidator></td>
    </tr>
    <tr>
        <td style="width:100px;text-align:right;">
            <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="Save" Width="100px" OnClick="btnSave_Click" /></td>
        <td>
            <asp:Button ID="btnCancel" runat="server" CssClass="Button" Text="Cancel" Width="100px" CausesValidation="False" OnClick="btnCancel_Click" /></td>
    </tr>
</table>