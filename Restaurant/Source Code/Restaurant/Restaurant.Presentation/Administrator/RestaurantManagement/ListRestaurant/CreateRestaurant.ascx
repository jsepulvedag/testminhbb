<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CreateRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.RestaurantManagement.ListRestaurant.CreateRestaurant" %>

<script language="javascript" type="text/javascript">
function checkMemberExist(rdoNew,droExist)
{
    if(document.getElementById(rdoNew).checked == true)
    {
        document.getElementById('divExist').style.display = 'none';
        document.getElementById('divNew').style.display = 'block';
    }
    else
    {
        if(document.getElementById(droExist).checked == true)
        {
            document.getElementById('divNew').style.display = 'none';
            document.getElementById('divExist').style.display = 'block';
        }
        else
        {
            document.getElementById('divNew').style.display = 'none';
            document.getElementById('divExist').style.display = 'none';
        }
    }
}
</script>

<div id="formConntent" style="color: black; margin-left: 100px;border:solid 1px #999999; font-family:Tahoma; font-size:12px;
    margin-right: 100px;">
    <div class="formConntentHeader" style="text-align: center; font-size: 17px; font-weight: bold;">
        <asp:Label ID="lblMess" runat="server" Font-Italic="True" Visible="False"
            Width="100%" ForeColor="Red"></asp:Label>
    </div>
    <div class="formContentCenter">
        <br />
        <table style="width: 100%">
            <caption style="text-align: left; font-size: 20px; margin-left: 5px; font-weight: bold;">
                Your current restaurant contact</caption>
            <tr>
                <td colspan="2" style="padding-left: 15px;">
                    <asp:RadioButton ID="rdoCreateMember" runat="server" Font-Bold="True" 
                        GroupName="groupCreate" Text="Create new member" Checked="True" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%">
                    <table id="divNew" style="width: 100%">
                        <tr>
                            <td style="width: 200px; height: 26px;" align="right">
                                UserName &nbsp;
                            </td>
                            <td style="width: auto; height: 26px;">
                                <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                                <span style="color: #ff0000"><strong>(*)</strong></span></td>
                        </tr>
                        <tr>
                            <td style="width: 200px" align="right">
                                Password &nbsp;
                            </td>
                            <td style="width: auto">
                                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                <strong><span style="color: #ff0000">(*)</span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 200px" align="right">
                                Confirm Password &nbsp;
                            </td>
                            <td style="width: auto">
                                <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                <strong><span style="color: #ff0000">(*)</span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 200px" align="right">
                                Title &nbsp;
                            </td>
                            <td style="width: auto">
                                <asp:DropDownList ID="drpCurrentGender" runat="server" Width="90px">
                                    <asp:ListItem Selected="True">Mr</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 200px" align="right">
                                Birthday &nbsp;
                            </td>
                            <td style="width: auto">
                                <asp:DropDownList ID="drpCurrentMonth" runat="server" Width="90px">
                                </asp:DropDownList>&nbsp;&nbsp;
                                <asp:DropDownList ID="drpCurrentDay" runat="server" Width="50px">
                                </asp:DropDownList>&nbsp;
                                <asp:DropDownList ID="drpCurrentYear" runat="server" Width="60px">
                                </asp:DropDownList>&nbsp; (Month / Day / Year)
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                            </td>
                            <td style="width: auto">
                                <asp:CheckBox ID="checkReceiveMail" runat="server" Text="You want to receive mail from Admin ?" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-left: 15px;">
                    <asp:RadioButton ID="rdoExistMember" runat="server" Font-Bold="True" GroupName="groupCreate"
                        Text="Using existing member" /></td>
            </tr>
            <tr>
                <td style="width: 100%">
                    <table id="divExist" style="width: 100%">
                        <tr>
                            <td style="width: 200px; height: 26px;" align="right">
                                UserName &nbsp;
                            </td>
                            <td style="width: auto; height: 26px;">
                                <asp:TextBox ID="txtUserNameExist" runat="server" Width="200px"></asp:TextBox>
                                <strong><span style="color: #ff0000">(*)</span></strong></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 200px; padding-left:210px;">
                    <asp:Button ID="btnAddMember" runat="server" Visible="true" Text="Add Member" OnClick="btnAddMember_Click" /></td>
                <td style="width: auto">
                    </td>
            </tr>
        </table>
    </div>
</div>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
