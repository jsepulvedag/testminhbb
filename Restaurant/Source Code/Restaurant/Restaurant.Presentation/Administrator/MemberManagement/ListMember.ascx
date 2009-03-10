<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ListMember.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.MemberManagement.ListMember" %>
<style type="text/css">
    .textcenter
    {
        text-align:center;
        
    }
</style>
<asp:Panel ID="pnSearch" runat="server" Visible="true" ForeColor="black" Width="98%">
    <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 10px;">
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left; height: 27px; width:70px;">
                Key word
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtkeyword" runat="server" Width="220px" /></td>
        </tr>
        <tr>
            <td style="text-align: left; height: 27px;width:70px;">
                Status
            </td>
            <td style="height: 27px;">
                <asp:DropDownList ID="drdStatus" runat="server" Width="120px">
                    <asp:ListItem> </asp:ListItem>
                    <asp:ListItem Value="1">active</asp:ListItem>
                    <asp:ListItem Value="0">inctive</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 23px">
                &nbsp;</td>
            <td style="height: 23px">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
        </tr>
        <tr>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
                <asp:HyperLink ID="hlAddMember" runat="server" ForeColor="white" NavigateUrl="~/Administrator/Default.aspx?ctrl=AddMember"
                    Text="Add Member" /></td>
        </tr>
    </table>
</asp:Panel>
&nbsp;<br />
<p style="text-align: center;">
    <asp:Label ID="lbError" runat="server" Text="You can't delete this member!" ForeColor="red"
        Visible="false" /></p>
<asp:Panel ID="pnListMember" Visible="true" runat="server">
    <div style="width: 98%; padding-left:10px;">
        <asp:DataGrid ID="dgrListMember" runat="server" AutoGenerateColumns="false" HeaderStyle-ForeColor="white"
            ItemStyle-ForeColor="white" Width="100%" HeaderStyle-BackColor="gray" ItemStyle-Width="25px"
            HeaderStyle-Height="30px" OnItemCommand="dgrListMember_ItemCommand" OnPageIndexChanged="dgrListMember_PageIndexChanged"
            OnItemDataBound="dgrListMember_ItemDataBound" Height="30px">
            <Columns>
                <asp:BoundColumn HeaderText="ID" DataField="ID">
                    <HeaderStyle Width="30px" CssClass="textcenter" />
                    <ItemStyle CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        User Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbUserName" runat="server" Text='<%#Eval("UserName") %>' CommandName="Edit"
                            ForeColor="#0066cc" CommandArgument='<%#Eval("ID") %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="90px" CssClass="textcenter" />
                </asp:TemplateColumn>
                <asp:BoundColumn HeaderText="Email" DataField="Email">
                    <HeaderStyle Width="110px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Full Name" DataField="FullName">
                    <HeaderStyle Width="100px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Gender" DataField="Gender">
                    <HeaderStyle Width="40px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Address" DataField="Address">
                    <HeaderStyle Width="120px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Country" DataField="CountryName">
                    <HeaderStyle Width="70px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="State" DataField="StateName">
                    <HeaderStyle Width="60px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="City" DataField="CityName">
                    <HeaderStyle Width="60px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="ZipCode" DataField="ZipCode">
                    <HeaderStyle Width="40px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Phone" DataField="Phone">
                    <HeaderStyle Width="50px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        <p style="text-align: center;">
                            Status</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="drdActive" runat="server" Width="100%" />
                        <asp:HiddenField ID="hdActive" runat="server" Value='<%#Eval("IsActive") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="textcenter" />
                    <HeaderStyle Width="60px" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lblUpdate" runat="server" Text="Update" ForeColor="#0066cc" CommandArgument='<%#Eval("ID") %>'
                            CommandName="Update" />
                    </ItemTemplate>
                    <ItemStyle CssClass="textcenter" />
                    <HeaderStyle Width="40px" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbLogAd" runat="server" Text="Log As" ForeColor="#0066cc" CommandArgument='<%#Eval("ID") %>'
                            CommandName="LogAsThisMember" />
                    </ItemTemplate>
                    <ItemStyle CssClass="textcenter" />
                    <HeaderStyle Width="40px" />
                </asp:TemplateColumn>
            </Columns>
            <FooterStyle HorizontalAlign="Right" />
            <ItemStyle ForeColor="Black" Width="25px" Height="30px" />
            <HeaderStyle ForeColor="White" BackColor="Gray" />
            <PagerStyle HorizontalAlign="Right" Mode="NumericPages" />
            <EditItemStyle Height="30px" />
        </asp:DataGrid>
    </div>
    <div style="width: 100%; text-align: right; padding-right: 0px;">
        <asp:Label ID="lblPage" runat="server" ForeColor="black" Text="Page" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dropPage" runat="server" OnSelectedIndexChanged="dropPage_SelectedIndexChanged"
            AutoPostBack="true" Width="50px" />&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
</asp:Panel>
<p style="text-align: center; color: red;">
    <asp:Label ID="lbsearch" runat="server" Visible="false" Text="We did not find results for your require!" /></p>
<asp:Panel ID="pnEdit" runat="server" Visible="false" ForeColor="black">
    <table>
        <tr>
            <td style="width: 400px;">
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="5" style="height: 1px" align="left">
                            <h4>
                                <strong>&nbsp;Edit Member Information </strong>
                            </h4>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 147px; text-align: right; height: 27px;">
                            Email:</td>
                        <td colspan="5" align="left" style="width: 725px; height: 24px">
                            &nbsp;
                            <asp:TextBox ID="txtEmail" runat="server" Width="220px" MaxLength="60" />
                            <asp:Label ID="lbEmail" runat="server" Width="81px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 157px; text-align: right; height: 27px;">
                            First name:
                        </td>
                        <td colspan="4" style="height: 24px; width: 621px;" align="left">
                            &nbsp;
                            <asp:TextBox ID="txtFirstName" runat="server" Width="220px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 157px; text-align: right; height: 27px;">
                            Last name:
                        </td>
                        <td colspan="4" style="height: 26px; width: 621px;" align="left">
                            &nbsp;
                            <asp:TextBox ID="txtLastName" runat="server" Width="218px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 27px;">
                            Birthday:
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
                        <td style="width: 157px; text-align: right; height: 27px;">
                            Title:</td>
                        <td style="height: 27px; width: 216px;" colspan="4">
                            &nbsp;
                            <asp:DropDownList ID="drdGender" runat="server" Width="75px">
                                <asp:ListItem Selected="true">Mr</asp:ListItem>
                                <asp:ListItem>Mrs</asp:ListItem>
                                <asp:ListItem>Ms</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 157px; text-align: right; height: 27px;">
                            Zipcode:</td>
                        <td align="left" colspan="4" style="width: 621px">
                            &nbsp;
                            <asp:TextBox ID="txtZipcode" runat="server" Width="156px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 27px; width: 157px;">
                            Address:</td>
                        <td align="left" colspan="4" style="height: 27px;">
                            <table>
                                <tr>
                                    <td style="height: 27px;" align="left">
                                        &nbsp;<asp:DropDownList ID="drdCountry" runat="server" Width="100px" AutoPostBack="true"
                                            OnSelectedIndexChanged="drdCountry_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: right; width: 34px; height: 27px;">
                                        State:</td>
                                    <td style="width: 99px; height: 27px;">
                                        <asp:DropDownList ID="drdState" runat="server" Width="104px" AutoPostBack="true"
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
                        <td style="text-align: right; height: 27px; width: 157px;">
                            Address Detail:</td>
                        <td colspan="4" style="height: 27px;" align="left">
                            &nbsp;
                            <asp:TextBox ID="txtAddress" runat="server" Width="284px" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 157px; height: 27px;">
                            Phone number:
                        </td>
                        <td align="left" colspan="4" style="height: 27px; width: 621px;">
                            &nbsp;
                            <asp:TextBox ID="txtPhone" runat="server" Width="156px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 157px; height: 27px;">
                            Fax:
                        </td>
                        <td align="left" colspan="4" style="height: 27px; width: 621px;">
                            &nbsp;
                            <asp:TextBox ID="txtFax" runat="server" Width="156px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 157px; height: 27px;">
                            Is Want Recive Mail:
                        </td>
                        <td align="left" colspan="4" style="height: 27px; width: 621px;">
                            &nbsp;
                            <asp:CheckBox ID="cbReciveMail" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 157px; height: 27px;">
                            Is Active:
                        </td>
                        <td align="left" colspan="4" style="height: 27px; width: 621px;">
                            &nbsp;
                            <asp:DropDownList runat="server" ID="drdActive">
                                <asp:ListItem Text="active" Value="True"> </asp:ListItem>
                                <asp:ListItem Text="inactive" Value="False"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 157px; height: 27px;">
                            &nbsp;</td>
                        <td align="left" colspan="4" style="height: 27px; width: 621px;">
                            &nbsp;
                            <asp:Button ID="btnRegister" runat="server" OnClick="btnOk_Click" Text="Update" Width="52px" />
                            <asp:Button ID="Cancel" runat="server" Text="Cancel" Width="52px" OnClick="Cancel_Click" />
                            <asp:Label ID="lbmemberID" runat="server" Visible="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />