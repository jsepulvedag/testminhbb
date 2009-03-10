<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AddMember.ascx.cs" Inherits="Restaurant.Presentation.Administrator.MemberManagement.MemberManagement" %>
<div id="formConntent" style="color: Black;">
    <div class="formContentHeader">
    </div>
    <div class="formContentCenter" style="float:left; margin-left:200px;">
        <table>
            <tr>
                <td style="width: 30%; color: black;">
                </td>
                <td style="color: black; width: 879px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 879px">
                        <tr>
                            <td colspan="5" align="left" style="height: 27px;">
                                <h4>
                                    <strong>&nbsp;1.Create membership </strong>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; User name:
                            </td>
                            <td colspan="4" align="left" style="width: 621px; height: 27px;">
                                &nbsp;
                                <asp:TextBox ID="txtUseName" runat="server" Width="220px" />
                                <asp:RequiredFieldValidator ID="requiredUsername" ControlToValidate="txtUseName"
                                    ErrorMessage="User Name. " Display="Dynamic" runat="server">
            *
                                </asp:RequiredFieldValidator>
                                <asp:Label ID="lbUsename" runat="server" Text="" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; Password:
                            </td>
                            <td align="left" colspan="4" style="width: 621px; height: 27px;">
                                &nbsp;
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="156px" MaxLength="20" />
                                <asp:RequiredFieldValidator ID="passwdReqVal" ControlToValidate="txtPassword" ErrorMessage="Password. "
                                    Display="Dynamic" runat="server">
              *
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; Comfirm password:</td>
                            <td colspan="5" style="height: 27px; width: 725px;" align="left">
                                &nbsp;
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" Width="156px" />
                                <asp:RequiredFieldValidator ID="passwd2reqval" ControlToValidate="txtconfirmpassword"
                                    ErrorMessage="re-enter password. " Display="dynamic" runat="server">
            *
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="comparepasswd" ControlToValidate="txtconfirmpassword" ControlToCompare="txtpassword"
                                    ErrorMessage="re-enter password. " Display="static" runat="server">
            password fields don't match
                                </asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; Email:</td>
                            <td colspan="5" align="left" style="width: 725px; height: 24px">
                                &nbsp;
                                <asp:TextBox ID="txtEmail" runat="server" Width="220px" MaxLength="60" />
                                <asp:RequiredFieldValidator ID="emailReqVal" ControlToValidate="txtEmail" ErrorMessage="Email. "
                                    Display="Dynamic" runat="server">
            *
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="emailRegexVal" ControlToValidate="txtEmail" ErrorMessage="Email. "
                                    Display="Static" ValidationExpression="^[\w-]+@[\w-]+\.(com|net|org|edu|mil)$"
                                    runat="server">
            Not a valid e-mail address.  Must follow email@host.domain.
                                </asp:RegularExpressionValidator>
                                <asp:Label ID="lbEmail" runat="server" Width="81px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; Confirm email:
                            </td>
                            <td colspan="4" style="height: 26px; width: 621px;" align="left">
                                &nbsp;
                                <asp:TextBox ID="txtConfirmEmail" runat="server" Width="220px" />
                                <asp:RequiredFieldValidator ID="email2ReqVal" ControlToValidate="txtConfirmEmail"
                                    ErrorMessage="Re-enter Email. " Display="Dynamic" runat="server">
            *
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="compareEmail" ControlToValidate="txtConfirmEmail" ControlToCompare="txtEmail"
                                    ErrorMessage="Re-enter Email. " Display="Static" runat="server">
            Email fields don't match
                                </asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="height: 1px" align="left">
                                <h4>
                                    <strong>&nbsp;2.Enter your profile </strong>
                                </h4>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; height: 27px; text-align: left">
                                &nbsp; &nbsp; Title:</td>
                            <td align="left" colspan="4" style="width: 621px; height: 24px">
                                &nbsp;
                                <asp:DropDownList ID="drdGender" runat="server" Width="75px">
                                    <asp:ListItem Selected="true">Mr</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; First name:
                            </td>
                            <td colspan="4" style="height: 24px; width: 621px;" align="left">
                                &nbsp;
                                <asp:TextBox ID="txtFirstName" runat="server" Width="220px" />
                                <asp:RequiredFieldValidator ID="requiredFirstname" ControlToValidate="txtFirstName"
                                    ErrorMessage="First Name. " Display="Dynamic" runat="server">
            *
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; Last name:
                            </td>
                            <td colspan="4" style="height: 26px; width: 621px;" align="left">
                                &nbsp;
                                <asp:TextBox ID="txtLastName" runat="server" Width="218px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastName"
                                    ErrorMessage="Last Name. " Display="Dynamic" runat="server">
            *
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; height: 27px; width: 139px;">
                                &nbsp; &nbsp; Birthday:
                            </td>
                            <td colspan="4" style="height: 27px" align="left">
                                <table>
                                    <tr>
                                        <td align="left" style="height: 27px">
                                            &nbsp;<asp:DropDownList ID="drdMonth" runat="server" Width="87px">
                                            </asp:DropDownList></td>
                                        <td align="center" style="width: 14px; height: 27px; text-align: center;">
                                            /</td>
                                        <td align="left" style="height: 27px">
                                            &nbsp;<asp:DropDownList ID="drdDate" runat="server" Width="42px">
                                            </asp:DropDownList></td>
                                        <td align="center" style="width: 14px; height: 27px; text-align: center;">
                                            /</td>
                                        <td align="left" style="height: 27px">
                                            <asp:DropDownList ID="drdYear" runat="server" Width="60px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; text-align: left; height: 27px;">
                                &nbsp; &nbsp; Zipcode:</td>
                            <td align="left" colspan="4" style="width: 621px">
                                &nbsp;
                                <asp:TextBox ID="txtZipcode" runat="server" Width="156px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtZipcode"
                                    ErrorMessage="Zipcode. " Display="Dynamic" runat="server">
            *
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regularExpressionZipcode" ControlToValidate="txtZipcode"
                                    ErrorMessage="Zip Code. " ValidationExpression="^\d{5}$" Display="Static" runat="server">
            Zip code must be 5 numeric digits
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; height: 27px; width: 139px;">
                                &nbsp; &nbsp; Address:</td>
                            <td align="left" colspan="4" style="height: 27px;">
                                <table>
                                    <tr>
                                        <td style="height: 27px;" align="left">
                                            &nbsp;<asp:DropDownList ID="drdCountry" runat="server" Width="100px" AutoPostBack="true"
                                                OnSelectedIndexChanged="drdCountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="text-align: left; width: 34px; height: 27px;">
                                            State:</td>
                                        <td style="width: 99px; height: 27px;">
                                            <asp:DropDownList ID="drdState" runat="server" Width="104px" AutoPostBack="true"
                                                OnSelectedIndexChanged="drdState_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 27px; text-align: left; height: 27px;">
                                            City:
                                        </td>
                                        <td style="width: 91px; height: 27px;">
                                            <asp:DropDownList ID="drdCity" runat="server" Width="92px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; height: 27px; width: 139px;">
                                &nbsp; &nbsp; Address Detail:</td>
                            <td colspan="4" style="height: 27px;" align="left">
                                &nbsp;
                                <asp:TextBox ID="txtAddress" runat="server" Width="284px" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 139px; height: 27px;">
                                &nbsp; &nbsp; Phone number:
                            </td>
                            <td align="left" colspan="4" style="height: 27px; width: 621px;">
                                &nbsp;
                                <asp:TextBox ID="txtPhone" runat="server" Width="156px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 139px; height: 27px;">
                                &nbsp; &nbsp; Fax:
                            </td>
                            <td align="left" colspan="4" style="height: 27px; width: 621px;">
                                &nbsp;
                                <asp:TextBox ID="txtFax" runat="server" Width="156px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 139px; height: 27px;">
                                &nbsp;</td>
                            <td align="left" colspan="4" style="height: 27px; width: 621px;">
                                &nbsp;
                                <asp:CheckBox ID="cbReciveMail" runat="server" Text="  I want to receive e-mails" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 139px; height: 27px;">
                                &nbsp;</td>
                            <td align="left" colspan="4" style="height: 27px; width: 621px;">
                                &nbsp;
                                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                    CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table><br />
    </div>
    <div class="formContentFooter">
    </div>
</div>
