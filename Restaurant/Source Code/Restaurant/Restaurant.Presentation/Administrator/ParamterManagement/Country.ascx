<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Country.ascx.cs" Inherits="Restaurant.Presentation.Administrator.ParamterManagement.Country" %>
<div class="adminPage" style="margin: 0 auto; padding-left: 200px;">
<br />
<div>
    
    <div>
        <asp:LinkButton ID="hpAdd" runat="server" Font-Size="14px" Text="Add Country" OnClick="hpAdd_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="lbError" runat="server" Font-Italic="true" ForeColor="red"></asp:Label><br />
        <br />
    </div>
    </div>
    <div>
        <asp:DataGrid ID="dgrCountry" runat="server" CellPadding="0" HeaderStyle-Height="30px"
            ItemStyle-Height="25px" HeaderStyle-BackColor="#CCCCCC" HeaderStyle-Font-Bold="true"
            AutoGenerateColumns="false" OnItemDataBound="dgrCountry_ItemDataBound" OnItemCommand="dgrCountry_ItemCommand"
            Width="489px">
            <Columns>
                <asp:BoundColumn DataField="ID" HeaderText="ID">
                    <ItemStyle Width="25px" HorizontalAlign="Center" />
                </asp:BoundColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Country Name</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton CommandName="Edit" CommandArgument="ID" Text='<%#Eval("Name") %>'
                            ID="lbtEdit" runat="server" Visible="true" />
                        <asp:TextBox ID="txtEdit" runat="server" Visible="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Status</HeaderTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="drdActive" runat="server" />
                        <asp:HiddenField ID="hdActive" runat="server" Value='<%#Eval("IsActive") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
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
                            CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Do you want to Delete country?')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateColumn>
            </Columns>
            <ItemStyle Height="25px" />
            <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Height="30px" HorizontalAlign="Center" />
        </asp:DataGrid><br />
    </div>
    <div>
        <asp:Panel ID="pnAdd" runat="server" Visible="false">
            <table style="width: 358px" border="1">
                <tr style="background-color: #CCCCCC; height: 30px; color: Black; font-size: 13px;
                    font-weight: bold;">
                    <td style="width: 258px; height: 30px;" align="center">
                        Name</td>
                    <td style="width: 100px; height: 30px;" align="center">
                        Status</td>
                </tr>
                <tr>
                    <td style="width: 258px">
                        <asp:TextBox ID="txtname" runat="server" Width="100%" /></td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="drdIsactive" runat="server" Width="100px" >
                            <asp:ListItem Selected="True">active</asp:ListItem>
                            <asp:ListItem>inactive</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="height: 26px;" align="left" colspan="2">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Country" OnClick="btnAdd_Click"
                            Width="100px" /></td>
                </tr>
            </table><br />
        <br />
        </asp:Panel>

    </div>
    </div>
