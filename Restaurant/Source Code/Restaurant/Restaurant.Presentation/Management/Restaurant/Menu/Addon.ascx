<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Addon.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Menu.Addon" %>
<%@ Register Src="MenuTabbar.ascx" TagName="MenuTabbar" TagPrefix="uc1" %>
<uc1:MenuTabbar ID="MenuTabbar1" runat="server" />
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr style="height: 30px;">
        <td style="width: 5px;">
            &nbsp;</td>
        <td style="width: 100px;">
            Add Addon Group</td>
        <td style="width: 230px;">
            Name:&nbsp;<asp:TextBox ID="txtAddAddonGroupName" Width="180px" runat="server" Text=""></asp:TextBox></td>
        <td>
            &nbsp; &nbsp;
           <asp:Button ID="bntAddAddonGroup" runat="server"  Text="Add" OnClick="bntAddAddonGroup_Click" />
        </td>
    </tr>
</table>
<asp:Repeater ID="rptAddonGroup" runat="server" OnItemDataBound="rptAddonGroup_ItemDataBound"
    OnItemCommand="rptAddonGroup_ItemCommand">
    <ItemTemplate>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr style="height: 30px; background-color: #868686;">
                <td style="width: 5px;">
                    &nbsp;</td>
                <td style="width: 100px;">
                    Edit Addon Group</td>
                <td style="width: 230px;">
                    Name:&nbsp;<asp:TextBox ID="txtAddonGroupName" Width="180px" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox></td>
                <td>
                    <asp:LinkButton ID="lkbUpdate" runat="server" Text="Update" CommandName="Update"
                        CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lkbShowHide" runat="server"  CommandName="ShowHide" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                    <asp:LinkButton ID="lkbUp" runat="server" Text="Up" CommandName="Up" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lkbDown" runat="server" Text="Down" CommandName="Down" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lkbDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                    <asp:HiddenField ID="hdIsActive" runat="server" Value='<%#Eval("IsActive") %>' />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr style="height: 30px;">
                <td style="width: 50px;">
                    &nbsp;</td>
                <td style="width: 100px;">
                    Add Addon</td>
                <td style="width: 200px;">
                    Name:&nbsp;<asp:TextBox ID="txtAddonName" runat="server" Text=""></asp:TextBox></td>
                <td style="width: 100px;">
                    Price:&nbsp;<asp:TextBox ID="txtAddonPrice" Width="50px" runat="server"></asp:TextBox></td>
                </td>
                <td> 
                    <asp:LinkButton ID="lkbAddonAdd" runat="server" Text="Add" CommandName="AddAddon"
                        CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <hr />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdfAddonGroupID" runat="server" Value='<%#Eval("Id")%>'  />
        <asp:Repeater ID="rptAddon" runat="server" OnItemDataBound="rptAddon_ItemDataBound"
            OnItemCommand="rptAddon_ItemCommand">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr style="height: 30px;">
                        <td style="width: 50px;">
                            &nbsp;</td>
                        <td style="width: 100px;">
                            Edit Addon</td>
                        <td style="width: 200px;">
                            Name:&nbsp;<asp:TextBox ID="txtEditAddonName" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox></td>
                        <td style="width: 100px;">
                            Price:&nbsp;<asp:TextBox ID="txtEditAddonPrice" Width="50px" runat="server" Text='<%#Eval("Price") %>'></asp:TextBox></td>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdfIsActive" runat="server" Value='<%#Eval("IsActive") %>' />
                            <asp:LinkButton ID="lkbAddonUpdate" runat="server" Text="Update" CommandName="Update"
                                CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lkbAddonShowHide" runat="server"  CommandName="ShowHide"  CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lkbAddonUp" runat="server" Text="Up" CommandName="Up"  CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lkbAddonDown" runat="server" Text="Down" CommandName="Down"  CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lkbAddonDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('Do you want to Delete this addon?')"></asp:LinkButton>&nbsp;
                             <asp:HiddenField ID="AddonGroupID" runat="server" Value='<%#Eval("MenuAddonGroupID")%>'  />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:Repeater>
