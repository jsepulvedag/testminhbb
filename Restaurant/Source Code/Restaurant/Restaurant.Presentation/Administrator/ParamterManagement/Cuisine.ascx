<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Cuisine.ascx.cs" Inherits="Restaurant.Presentation.Administrator.ParamterManagement.Cuisine" %>
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
       <asp:LinkButton ID="hpAdd" runat="server" Font-Size="14px" Text="Add Cuisine" OnClick="hpAdd_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;
       <asp:Label ID="lbError" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label><br />
    </div>
    <div><br />
        <asp:DataGrid ID="dgrCuisine" runat="server" CellPadding="2" CellSpacing="2" HeaderStyle-Height="30px"
            ItemStyle-Height="25px" HeaderStyle-BackColor="#CCCCCC" HeaderStyle-Font-Bold="true"
            AutoGenerateColumns="false" OnItemDataBound="dgrCuisine_ItemDataBound" OnItemCommand="dgrCuisine_ItemCommand"
            Width="770px" AllowPaging="True" OnPageIndexChanged="dgrCuisine_PageIndexChanged">
            <Columns>
                <asp:BoundColumn DataField="ID" HeaderText="ID">
                    <ItemStyle CssClass="textcenter" Width="30px" />
                </asp:BoundColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Cuisine Name</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton CommandName="Edit" CommandArgument="ID" Text='<%#Eval("Name") %>'
                            ID="lbtEdit" runat="server" Visible="true" />
                        <asp:TextBox ID="txtName" runat="server" Visible="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle  Width="200px"/>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Description</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                        <asp:TextBox ID="txtDescription" runat="server" Visible="false" Text='<%#Eval("Description") %>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle  Width="300px"/>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Status</HeaderTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="drdActive" runat="server" Width="80px" />
                        <asp:HiddenField ID="hdActive" runat="server" Value='<%#Eval("IsActive") %>' />
                    </ItemTemplate>
                    <ItemStyle  Width="80px" CssClass="textcenter"/>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtUpdate" runat="server" Text="Update" CommandName="Update"
                            CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle  Width="80px" CssClass="textcenter"/>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Delete" CommandName="Delete"
                            CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Do you want to Delete Cuisine?')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle  Width="80px" CssClass="textcenter"/>
                </asp:TemplateColumn>
            </Columns>
            <ItemStyle Height="25px" />
            <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Height="30px" CssClass="textcenter" />
            <PagerStyle HorizontalAlign="Right" Mode="NumericPages" NextPageText="" PrevPageText="" />
        </asp:DataGrid>
        <br />
    </div>
    <div>
        <asp:Panel ID="pnAdd" runat="server" Visible="false">
            <table style="width: 530px" border="1">
                <tr style="background-color: #CCCCCC; height: 30px; color: Black; font-weight:bold;">
                    <td style="width: 150px" align="center">
                        Name</td>
                    <td align="center">
                        Description</td>
                    <td style="width: 100px" align="center">
                        Status</td>
                </tr>
                <tr>
                    <td style="width: 150px">
                        <asp:TextBox ID="txtname" runat="server" Width="100%" /></td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" Width="100%" /></td>
                    <td style="width:100px">
                        <asp:DropDownList ID="drdIsactive" runat="server" Width="100px" /></td>
                </tr>
                <tr>
                    <td align="left" colspan="3">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Cuisine" OnClick="btnAdd_Click" Width="100px" />&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</div>
<br />
<br />
