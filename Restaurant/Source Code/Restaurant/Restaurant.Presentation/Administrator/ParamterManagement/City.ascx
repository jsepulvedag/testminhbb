<%@ Control Language="C#" AutoEventWireup="true" Codebehind="City.ascx.cs" Inherits="Restaurant.Presentation.Administrator.ParamterManagement.City" %>

<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>
<style type="text/css">
    .textcenter
    {
        text-align:center;
    }
</style>
<br />
<div class="adminPage" style="margin: 0 auto; padding-left: 200px;">
   
        <table style="width: 400px">
            <tr>
                <td style="width: 100px" align="left">
                    Choose Country
                </td>
                <td style="width: 200px">
                    <asp:DropDownList ID="drdCountry" Width="100px" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="drdCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="left">
                    Choose State
                </td>
                <td style="width: 200px">
                    <asp:DropDownList ID="drdState" Width="100px" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="drdState_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100px">
                    <br /><asp:LinkButton ID="hpAdd" runat="server" Font-Size="14px" Text="Add City" OnClick="hpAdd_Click" />
                </td>
                <td style="width: 200px">
                    <br /><asp:Label ID="lbError" runat="server" ForeColor="red" Font-Italic="true"></asp:Label>
                </td>
            </tr>
        </table>
       
            <br />
        <div>
            
            <asp:Panel ID="pnCity" runat="server" Visible="true">
                <asp:DataGrid ID="dgrCity" runat="server" CellPadding="2" CellSpacing="2" HeaderStyle-Height="30px"
                    ItemStyle-Height="25px" HeaderStyle-BackColor="#CCCCCC" HeaderStyle-Font-Bold="true"
                    AutoGenerateColumns="false" OnItemDataBound="dgrCity_ItemDataBound" OnItemCommand="dgrCity_ItemCommand"
                    Width="650px">
                    <Columns>
                        <asp:BoundColumn DataField="State" HeaderText="State">
                        <ItemStyle Width="100px"/>
                        </asp:BoundColumn>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                City Name</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="Edit" CommandArgument="ID" Text='<%#Eval("Name") %>'
                                    ID="lbtEdit" runat="server" Visible="true" />
                                <asp:TextBox ID="txtEdit" runat="server" Visible="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="150px"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                Status</HeaderTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="drdActive" runat="server" Width="80px" />
                                <asp:HiddenField ID="hdActive" runat="server" Value='<%#Eval("IsActive") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="80px"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtUpdate" runat="server" Text="Update" CommandName="Update"
                                    CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle  CssClass="textcenter" Width="80px"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtUp" runat="server" Text="Up" CommandName="Up" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle  CssClass="textcenter" Width="80px"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtDown" runat="server" Text="Down" CommandName="Down" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle  CssClass="textcenter" Width="80px"/>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtDelete" runat="server" Text="Delete" CommandName="Delete"
                                    CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Do you want to Delete City?')"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle  CssClass="textcenter" Width="80px"/>
                        </asp:TemplateColumn>
                    </Columns>
                    <ItemStyle Height="25px" />
                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Height="30px" CssClass="textcenter" />
                </asp:DataGrid></asp:Panel><br />
        </div>
        <div>
            <asp:Panel ID="pnAdd" runat="server" Visible="false" Width="448px">
                <table style="width: 410px" id="TABLE1" onclick="return TABLE1_onclick()" border="1">
                    <tr style="background-color: #CCCCCC; height: 30px; color: Black; font-weight: bold;">
                        <td style="width: 310px" align="center">
                            Name</td>
                        <td align="center" style="width: 100px">
                            Status</td>
                    </tr>
                    <tr>
                        <td style="width: 310px">
                            <asp:TextBox ID="txtname" runat="server" Width="100%" /></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="drdIsactive" runat="server" Width="100%" >
                                <asp:ListItem Selected="True">active</asp:ListItem>
                                <asp:ListItem>inactive</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="height: 26px;" align="left" colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text="Add City" Font-Underline="False" Width="100px"
                                OnClick="btnAdd_Click" /></td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
        </div>
    </div>
