<%@ Control Language="C#" AutoEventWireup="true" Codebehind="State.ascx.cs" Inherits="Restaurant.Presentation.Administrator.ParamterManagement.State" %>
<div class="adminPage" style="margin: 0 auto; padding-left: 200px;">
<br />
    <div class="adminPage_right_center">
        Choose Country &nbsp;<asp:DropDownList ID="drdCountry" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="drdCountry_SelectedIndexChanged" Width="100px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:LinkButton ID="hpAdd" runat="server" Text="Add State" OnClick="hpAdd_Click1" />
        &nbsp;
        <asp:Label ID="lbError" runat="server" Font-Italic="True" ForeColor="red"></asp:Label><br />
        <br />
        &nbsp;<asp:Panel ID="pnState" runat="server" Visible="true">
            <asp:DataGrid ID="dgrState" runat="server" CellPadding="0" HeaderStyle-Height="30px"
                ItemStyle-Height="25px" HeaderStyle-BackColor="#CCCCCC" HeaderStyle-Font-Bold="true"
                AutoGenerateColumns="false" OnItemDataBound="dgrCountry_ItemDataBound" OnItemCommand="dgrCountry_ItemCommand"
                Width="630px">
                <Columns>
                    <asp:BoundColumn DataField="Country" HeaderText="Country">
                    <ItemStyle Width="150px" HorizontalAlign="Center" /></asp:BoundColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            State Name</HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton CommandName="Edit" CommandArgument="ID" Text='<%#Eval("Name") %>'
                                ID="lbtEdit" runat="server" Visible="true" />
                            <asp:TextBox ID="txtEdit" runat="server" Visible="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            Status</HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="drdActive" Width="75px" runat="server" />
                            <asp:HiddenField ID="hdActive" runat="server" Value='<%#Eval("IsActive") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtUpdate" runat="server" Text="Update" CommandName="Update"
                                CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtUp" runat="server" Text="Up" CommandName="Up" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtDown" runat="server" Text="Down" CommandName="Down" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtDelete" runat="server" Text="Delete" CommandName="Delete"
                                CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Do you want to Delete state?')"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                    </asp:TemplateColumn>
                </Columns>
                <ItemStyle Height="25px" />
                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Height="30px" HorizontalAlign="Center" />
            </asp:DataGrid></asp:Panel>
        <br />
        <asp:Panel ID="pnAdd" runat="server" Visible="false">
            <table style="width: 269px" border="1">
                <tr style="background-color: #CCCCCC; height: 30px; color: Black; font-size: 13px;
                    font-weight: bold;">
                    <td style="width: 160px; height: 30px;" align="center">
                        Name</td>
                    <td style="width: 100px; height: 30px;" align="center">
                        Status</td>
                </tr>
                <tr style="height: 25px;">
                    <td style="width: 160px">
                        <asp:TextBox ID="txtname" runat="server" Width="98%" /></td>
                    <td>
                        <asp:DropDownList ID="drdIsactive" Width="100px" runat="server" >
                            <asp:ListItem Selected="True">active</asp:ListItem>
                            <asp:ListItem>inactive</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr style="height: 25px;">
                    <td style="height: 25px" align="left" colspan="2">
                        <asp:Button ID="btnAdd" runat="server" Text="Add State" Font-Underline="True" OnClick="btnAdd_Click"
                            Width="100px" />&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</div>
<br /><br />