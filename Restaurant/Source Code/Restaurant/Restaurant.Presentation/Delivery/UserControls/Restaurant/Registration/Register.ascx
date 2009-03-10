<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Register.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.Registration.Register" %>
<%@ Register Src="../../Common/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../../Common/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width:260px;">
        </td>
        <td>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="5" align="left" style="height: 27px;">
                        <h4>
                            <strong>&nbsp;1.Create membership </strong>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td style="width: 147px; text-align: right; height: 27px;">
                        User name:
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
                    <td style="width: 147px; text-align: right;">
                        Password:
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
                    <td style="width: 147px; text-align: right; height: 27px;">
                        Comfirm password:</td>
                    <td colspan="5" style="height: 27px; width: 725px;" align="left">
                        &nbsp;
                        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" Width="156px" />
                        <asp:RequiredFieldValidator ID="passwd2ReqVal" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="Re-enter Password. " Display="Dynamic" runat="server">
            *
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="ComparePasswd" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                            ErrorMessage="Re-enter Password. " Display="Static" runat="server">
            Confirm password fields don't match
                        </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 147px; text-align: right; height: 27px;">
                        Email:</td>
                    <td colspan="5" align="left" style="width: 725px; height: 24px">
                        &nbsp;
                        <asp:TextBox ID="txtEmail" runat="server" Width="220px" MaxLength="60" />
                        <asp:RequiredFieldValidator ID="emailReqVal" ControlToValidate="txtEmail" ErrorMessage="Email. "
                            Display="Dynamic" runat="server">
            *
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="emailRegexVal" ControlToValidate="txtEmail" ErrorMessage="Email. "
                            Display="Static" ValidationExpression="^[\w.-]+@[\w-]+\.(com|net|org|edu|mil)$"
                            runat="server">
            Not a valid e-mail address.  Must follow email@host.domain.
                        </asp:RegularExpressionValidator>
                        <asp:Label ID="lbEmail" runat="server" Width="81px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 147px; text-align: right; height: 27px;">
                        Confirm email:
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
            Confirm email fields don't match
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
                    <td style="width: 147px; height: 27px; text-align: right">
                        Title:</td>
                    <td align="left" colspan="4" style="width: 621px; height: 24px">
                        &nbsp;
                        <asp:DropDownList ID="drdGender" runat="server" Width="75px">
                            <asp:ListItem Selected="true">Mr</asp:ListItem>
                            <asp:ListItem>Mrs</asp:ListItem>
                            <asp:ListItem>Ms</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 147px; text-align: right; height: 27px;">
                        First name:
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
                    <td style="width: 147px; text-align: right; height: 27px;">
                        Last name:
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
                    <td style="text-align: right; height: 27px; width: 147px;">
                        Birthday:
                    </td>
                    <td colspan="4" style="height: 27px" align="left">
                        <table>
                            <tr>
                                <td align="left" style="height: 27px">
                                    &nbsp;<asp:DropDownList ID="drdMonth" runat="server" Width="95px">
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
                    <td style="width: 147px; text-align: right; height: 27px;">
                        Zipcode:</td>
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
                    <td style="text-align: right; height: 27px; width: 147px;">
                        Address:</td>
                    <td align="left" colspan="4" style="height: 27px;">
                        <table>
                            <tr>
                                <td style="height: 27px;" align="left">
                                    &nbsp;<asp:DropDownList ID="drdCountry" runat="server" AutoPostBack="true" Width="100px"
                                        OnSelectedIndexChanged="drdCountry_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right; width: 34px; height: 27px;">
                                    State:</td>
                                <td style="width: 99px; height: 27px;">
                                    <asp:DropDownList ID="drdState" runat="server" AutoPostBack="true" Width="104px"
                                        OnSelectedIndexChanged="drdState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 27px; text-align: right; height: 27px;">
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
                    <td style="text-align: right; height: 27px; width: 147px;">
                        Address Detail:</td>
                    <td colspan="4" style="height: 27px;" align="left">
                        &nbsp;
                        <asp:TextBox ID="txtAddress" runat="server" Width="284px" /></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 147px; height: 27px;">
                        Phone number:
                    </td>
                    <td align="left" colspan="4" style="height: 27px; width: 621px;">
                        &nbsp;
                        <asp:TextBox ID="txtPhone" runat="server" Width="156px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 147px; height: 27px;">
                        Fax:
                    </td>
                    <td align="left" colspan="4" style="height: 27px; width: 621px;">
                        &nbsp;
                        <asp:TextBox ID="txtFax" runat="server" Width="156px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 147px; height: 27px;">
                    </td>
                    <td align="left" colspan="4" style="height: 27px; width: 621px;">
                        &nbsp;
                        <asp:CheckBox ID="cbReciveMail" runat="server" Text="   I want to receive e-mails" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 147px; height: 27px; text-align: right">
                    </td>
                    <td align="left" colspan="4" style="width: 621px; height: 27px">
                        <div id="Div1">
                            <div>
                                <%--class="formContentCenter"--%>
                                <table style="width: 621px">
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtTerm" TextMode="MultiLine" ReadOnly="true" runat="server" Style="width: 600px;
                                                text-align: justify;" Rows="9"> 
1. Your relationship with Google
2. Your use of Google’s products, software, services and web sites (referred to collectively as the “Services” in this document and excluding any services provided to you by Google under a separate written agreement) is subject to the terms of a legal agreement between you and Google. “Google” means Google Inc., whose principal place of business is at 1600 Amphitheatre Parkway, Mountain View, CA 94043, United States. This document explains how the agreement is made up, and sets out some of the terms of that agreement.
  
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 27px;">
                                            &nbsp;
                                            <asp:CheckBox ID="CheckTerm" runat="server" OnCheckedChanged="CheckTerm_CheckedChanged" />
                                            I have read, and agree to abite by the term and condition
                                            <asp:Label ID="lbCheck" runat="server" Text="" ForeColor="red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="5" style="height: 27px">
                        <%--<uc1:TeamOfUse ID="ucTeam" runat="server" />--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 147px; height: 27px;">
                        &nbsp;</td>
                    <td align="left" colspan="4" style="height: 27px; width: 621px;">
                        &nbsp;
                        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register"
                            Width="85px" CssClass="Button" />
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                            Width="85px" CssClass="Button" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
