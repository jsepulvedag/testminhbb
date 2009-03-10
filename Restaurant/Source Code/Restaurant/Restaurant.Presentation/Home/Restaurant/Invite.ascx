<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Invite.ascx.cs" Inherits="Restaurant.Presentation.Home.Member.Invite" %>
<style type="text/css">
    .submit
    {
        text-align:center;
    }
</style>

<div id="formConntent">
<div class="formConntentHeader"  style="height:35px;" > 
    <div style=" font-size:20px; padding-left:20px; padding-top:7px;">Invite A Friend</div></div>
    <div class="formContentCenter" style="padding-left: 20px; width: 849px;"><br />
<table>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 714px">
            <table border="0">
               
                <tr>
                    <td colspan="2" style="height: 65px">
                        <span style="font-size: 14pt">Know someone who loves to eat out?<br />
                            <br />
                            <asp:Label ID="lbError" runat="server" ForeColor="Red" Visible="False" Font-Bold="False" Font-Size="12pt">Your Email has been sent sucessfully!</asp:Label></span></td>
                    <td style="width: 491px; height: 65px;">
                        &nbsp;<br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 185px">
                        Subject</td>
                    <td style="width: 284px">
                        <asp:TextBox ID="txtSubject" runat="server" Width="215px" /></td>
                    <td style="width: 491px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 185px">
                        Your full name</td>
                    <td style="width: 284px">
                        <asp:TextBox ID="txtName" runat="server" Width="215px" /></td>
                    <td style="width: 491px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 185px">
                        Your email address</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" Width="215px" />
                         <asp:RequiredFieldValidator ID="emailReqVal" ControlToValidate="txtAddress" ErrorMessage="Email. "
                        Display="Dynamic" runat="server">
            *
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailRegexVal" ControlToValidate="txtAddress" ErrorMessage="Email. "
                        Display="Static" ValidationExpression="^[\w.-]+@[\w-]+\.(com|net|org|edu|mil)$"
                        runat="server">
            Not a valid e-mail address.  Must follow email@host.domain.
                    </asp:RegularExpressionValidator>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 185px">
                        Your friend's name</td>
                    <td style="width: 284px">
                        <asp:TextBox ID="txtName2" runat="server" Width="215px" /></td>
                    <td style="width: 491px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 185px">
                        Your friend's email address</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtAddress2" runat="server" Width="215px" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAddress2" ErrorMessage="Email. "
                        Display="Dynamic" runat="server">
            *
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtAddress2" ErrorMessage="Email. "
                        Display="Static" ValidationExpression="^[\w.-]+@[\w-]+\.(com|net|org|edu|mil)$"
                        runat="server">
            Not a valid e-mail address.  Must follow email@host.domain.
                    </asp:RegularExpressionValidator>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 185px" valign="top">
                        Your invitation message</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" Width="98%">
    How's it going? I just discovered 212Cuisine.com.
 
212Cuisine helps me find the best places to eat, wherever I am and whatever I'm craving. I can read reviews before making a choice and write my own afterwards. When you join, we can share reviews, pictures and videos.

Check it out for yourself: http://www.212cuisine.com/
                        </asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 185px">
                        </td>
                    <td colspan="2">
                        This is the message we'll send to your friend - but feel free to edit or remove
                        it.</td>
                </tr>
                <tr>
                    <td style="width: 185px">
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" CssClass="submit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                            Width="78px" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    </div>
<div id="pageRestaurantByCuisineFooter"></div>
</div>
