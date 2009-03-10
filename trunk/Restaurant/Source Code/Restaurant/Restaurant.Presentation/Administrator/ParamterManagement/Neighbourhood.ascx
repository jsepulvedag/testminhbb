<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Neighbourhood.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.ParamterManagement.Neighbourhood" %>

<style type="text/css">
    .textcenter
    {
        text-align:center;
    }
</style>
<div class="adminPage" style="margin: 0 auto; padding-left: 200px;">
    
    <div>
    <br />
        <table style="width: 300px">
            <tr>
                <td style="width: 130px">Choose Country
                </td>
                <td style="width: 170px"><asp:DropDownList ID="drdCountry" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="drdCountry_SelectedIndexChanged" Width="100px">
        </asp:DropDownList>
               </td>
            </tr>
            <tr>
                <td style="width: 130px">
        Choose State</td>
                <td style="width: 170px">
                     <asp:DropDownList ID="drdState" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="drdState_SelectedIndexChanged">
        </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 130px">
        Choose City</td>
                <td style="width: 170px">
                    <asp:DropDownList ID="drdCity" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="drdCity_SelectedIndexChanged">
        </asp:DropDownList></td>
            </tr>
        </table>
        
        <br />
    </div>
    <div>
        &nbsp;</div>
    <div>
       <asp:LinkButton ID="hpAdd" runat="server" Text="Add Neighbourhood" OnClick="hpAdd_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
       <asp:Label ID="lbError" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label><br />
        <br />
    </div>
    <div id="neighbourhood" runat="server" visible="true">
        <asp:DataGrid ID="dgrNeighbourhood" runat="server" CellPadding="2" CellSpacing="2"
            HeaderStyle-Height="30px" ItemStyle-Height="25px" HeaderStyle-BackColor="#CCCCCC"
            HeaderStyle-Font-Bold="true" AutoGenerateColumns="false" OnItemDataBound="dgrNeighbourhood_ItemDataBound"
            OnItemCommand="dgrNeighbourhood_ItemCommand" Width="800px">
            <Columns>
                <asp:BoundColumn DataField="City" HeaderText="City Name">
                    <ItemStyle Width="100px"/>
                </asp:BoundColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Neighbourhood Name</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton CommandName="Edit" CommandArgument="ID" Text='<%#Eval("Name") %>'
                            ID="lbtEdit" runat="server" Visible="true" />
                        <asp:TextBox ID="txtName" runat="server" Visible="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="170px"/>
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
                        <asp:DropDownList ID="drdActive" runat="server" Width="80px" />
                        <asp:HiddenField ID="hdActive" runat="server" Value='<%#Eval("IsActive") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="textcenter" Width="80px"/>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtUpdate" runat="server" Text="Update" CommandName="Update"
                            CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="textcenter" Width="80px"/>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Delete" CommandName="Delete"
                            CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Do you want to Delete neighbourhood?')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="textcenter" Width="80px"/>
                </asp:TemplateColumn>
            </Columns>
            <ItemStyle Height="25px" />
            <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Height="30px" CssClass="textcenter" />
        </asp:DataGrid>
        <br />
    </div>
    <div>
        <asp:Panel ID="pnAdd" runat="server" Visible="false">
            <table style="width: 560px" border="1">
                <tr style="background-color: #CCCCCC; height: 30px; color: Black; font-weight:bold;">
                    <td style="width: 200px" align="center">
                        Name</td>
                    <td style="width: 260px" align="center">
                        Description</td>
                    <td align="center" style="width: 100px">
                        Status</td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <asp:TextBox ID="txtname" runat="server" Width="100%" /></td>
                    <td style="width: 260px">
                        <asp:TextBox ID="txtDescription" runat="server" Width="100%" /></td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="drdIsactive" runat="server" Width="100%" /></td>
                </tr>
                <tr>
                    <td align="left" colspan="3">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Neighbourhood" OnClick="btnAdd_Click" Width="150px" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <br />
</div>


