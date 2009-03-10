<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MenuCategory.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Restaurant.Menu.MenuCategory" %>
<%@ Register Src="MenuTabbar.ascx" TagName="MenuTabbar" TagPrefix="uc1" %>
<style type="text/css">
    .text
    {
        text-align:center;
    }
    .name
    {
        padding-left:10px;
    }
    </style>

        <div style="width:98%; padding-left:5px;">
        <br />
        <div style="float: left;">
            <uc1:MenuTabbar ID="MenuTabbar1" runat="server" />
        </div>
        <br />
        <br />
        <br />
        <strong>
            <h3>&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="hlAddMenuCat" runat="server" Text="Add" />&nbsp;</h3>
        </strong>
        <br />
        <asp:GridView ID="grvMenuCat" runat="server" AutoGenerateColumns="false" OnRowCommand="grvMenuCat_RowCommand"
            Width="100%">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="Name" HeaderStyle-Height="30px" HeaderStyle-BackColor="#868686">
                    <HeaderStyle CssClass="name"/>
                    <ItemStyle CssClass="name" />
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-Width="50px" HeaderStyle-Height="30px" HeaderStyle-BackColor="#868686"
                    ItemStyle-Height="25px">
                    <ItemTemplate>
                        <strong>
                            <asp:LinkButton ID="lblEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("ID") %>'
                                CommandName="_edit" /></strong>
                    </ItemTemplate>
                    <ItemStyle CssClass="text" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100px" HeaderStyle-Height="30px" HeaderStyle-BackColor="#868686"
                    ItemStyle-Height="25px">
                    <ItemTemplate>
                        <strong>
                            <asp:HyperLink ID="hplOption" runat="server" Text="Menu Addon" NavigateUrl='<%# "/Management/Default.aspx?mid=Addon&MenuCategoryID="+ Eval("ID") %>' /></strong>
                    </ItemTemplate>
                    <ItemStyle CssClass="text" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="50px" HeaderStyle-Height="30px" HeaderStyle-BackColor="#868686"
                    ItemStyle-Height="25px">
                    <ItemTemplate>
                        <strong>
                            <asp:LinkButton ID="lblDown" runat="server" Text="Down" CommandArgument='<%#Eval("ID") %>'
                                CommandName="_down" /></strong>
                    </ItemTemplate>
                    <ItemStyle CssClass="text" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="50px" HeaderStyle-Height="30px" HeaderStyle-BackColor="#868686"
                    ItemStyle-Height="25px">
                    <ItemTemplate>
                        <strong>
                            <asp:LinkButton ID="lblUp" runat="server" Text="Up" CommandArgument='<%#Eval("ID") %>'
                                CommandName="_up" /></strong>
                    </ItemTemplate>
                    <ItemStyle CssClass="text" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="50px" HeaderStyle-Height="30px" HeaderStyle-BackColor="#868686"
                    ItemStyle-Height="25px">
                    <ItemTemplate>
                        <strong>
                            <asp:LinkButton ID="lblDelete" runat="server" Text="Delete" CommandArgument='<%#Eval("ID") %>'
                                CommandName="_delete" OnClientClick="return confirm('Do you want to Delete this member category?')" /></strong>
                    </ItemTemplate>
                    <ItemStyle CssClass="text" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Panel runat="server" ID="pnEdit" Visible="false">
            <asp:HiddenField ID="hdID" runat="server" Value="" />
            <br />
            <br />
            <table>
                <tr>
                    <td style="width: 76px; text-align: left; padding-left: 20px;">
                        Name:</td>
                    <td colspan="2" style="width: 341px; padding-bottom: 5px;">
                        <asp:TextBox ID="txtName" runat="server" Width="267px" /></td>
                </tr>
                <tr>
                    <td style="width: 76px; text-align: left; padding-left: 20px;">
                        Description:
                    </td>
                    <td colspan="2" style="padding-bottom: 5px;">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="405px" /></td>
                </tr>
                <tr>
                    <td style="width: 76px; text-align: left; padding-left: 20px;">
                        Image:</td>
                    <td colspan="2" style="width: 341px; padding-bottom: 5px;">
                        <asp:FileUpload ID="UplImage" runat="server" Width="270px" /></td>
                </tr>
                <tr>
                    <td style="width: 76px; text-align: left; padding-left: 20px;">
                        Price Heading:</td>
                    <td style="padding-bottom: 5px; width: 341px;" colspan="2">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 9px; padding-bottom: 5px; padding-right: 10px; padding-bottom: 5px;">
                                    <asp:TextBox ID="txtPrHeading1" runat="server" Width="128px" /></td>
                                <td style="width: 123px; padding-bottom: 5px; padding-right: 10px; padding-bottom: 5px;">
                                    <asp:TextBox ID="txtPrHeading2" runat="server" Width="128px" /></td>
                                <td style="width: 77px; padding-bottom: 5px; padding-bottom: 5px;">
                                    <asp:TextBox ID="txtPrHeading3" runat="server" Width="128px" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 76px">
                        &nbsp;</td>
                    <td colspan="2">
                        <asp:Button ID="btnEdit" Text="Update" CssClass="text" runat="server" OnClick="btnEdit_Click"
                            Width="70px" />
                        <asp:Button ID="btncancel" Text="Cancel" CssClass="text" runat="server" OnClick="btncancel_Click" Width="70px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        </div>
