<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Special.ascx.cs" Inherits="Restaurant.Presentation.Administrator.ParamterManagement.Special" %>

<style type="text/css">
    .textcenter
    {
        text-align:center;
    }
</style>

<div class="adminPage" style="margin: 0 auto; padding-left: 200px;">
    <br />
    <div>
        &nbsp;</div>
    <div>
       <asp:LinkButton ID="hpAdd" runat="server" Font-Size="14px" Text="Add Special" OnClick="hpAdd_Click" />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="lbError" runat="server" Font-Italic="True" ForeColor="red"></asp:Label><br />
        <br />
    </div>
    <div>
        <asp:DataGrid ID="dgrSpecial" runat="server" CellPadding="2" CellSpacing="2" HeaderStyle-Height="30px"
            ItemStyle-Height="25px" HeaderStyle-BackColor="#CCCCCC" HeaderStyle-Font-Bold="true"
            AutoGenerateColumns="false" OnItemDataBound="dgrSpecial_ItemDataBound" OnItemCommand="dgrSpecial_ItemCommand"
            Width="700px">
            <Columns>
                <asp:BoundColumn DataField="ID" HeaderText="ID">
                    <ItemStyle Width="30px" CssClass="textcenter" />
                </asp:BoundColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Cuisine Name</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton CommandName="Edit" CommandArgument="ID" Text='<%#Eval("Name") %>'
                            ID="lbtEdit" runat="server" Visible="true" />
                        <asp:TextBox ID="txtName" runat="server" Visible="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="130px" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Description</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                        <asp:TextBox ID="txtDescription" runat="server" Visible="false" Text='<%#Eval("Description") %>'></asp:TextBox>
                    </ItemTemplate>
                    
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Status</HeaderTemplate>
                    <ItemTemplate>
                        <asp:DropDownList Width="80px" ID="drdActive" runat="server" />
                        <asp:HiddenField ID="hdActive" runat="server" Value='<%#Eval("IsActive") %>' />
                    </ItemTemplate>
                    <ItemStyle Width="80px" CssClass="textcenter" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtUpdate" runat="server" Text="Update" CommandName="Update"
                            CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="80px" CssClass="textcenter" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Delete" CommandName="Delete"
                            CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Do you want to Delete Special?')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="80px" CssClass="textcenter" />
                </asp:TemplateColumn>
            </Columns>
            <ItemStyle Height="25px" />
            <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Height="30px" CssClass="textcenter" />
        </asp:DataGrid><br />
    </div>
    <div>
        <asp:Panel ID="pnAdd" runat="server" Visible="false">
            <table style="width: 540px" border="1">
                <tr style="background-color: #CCCCCC; height: 30px; color: Black; font-weight:bold;">
                    <td style="width: 150px" align="center">
                        Name</td>
                    <td align="center">
                        Description</td>
                    <td align="center" style="width: 100px">
                        Status</td>
                </tr>
                <tr style="height: 25px;">
                    <td style="width: 150px">
                        <asp:TextBox ID="txtname" runat="server" Width="150px" /></td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" Width="100%" /></td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="drdIsactive" runat="server" Width="100%" /></td>
                </tr>
                <tr>
                    <td align="left" colspan="3">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Special" OnClick="btnAdd_Click" Width="100px" />&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <br />
</div>


