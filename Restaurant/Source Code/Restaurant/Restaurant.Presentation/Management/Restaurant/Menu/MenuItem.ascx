<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MenuItem.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Menu.MenuItem" %>
<%@ Register Src="~/Management/Restaurant/Menu/MenuTabbar.ascx" TagName="MenuTabbar"
    TagPrefix="uc1" %>

<style type="text/css">
    .center
    {
        text-align: center;
    }
</style>
    <div >
        <table width="99%" style="padding-left:5px;">
            <tr style="width: 100%">
                <td colspan="2">
                    <uc1:MenuTabbar ID="menutab" runat="server" />
                    <br />
                    <br /><br /><br />
                </td>
            </tr>
            <tr style="width: 100%;">
                <td style="color: White; text-align: left; height: 64px;" align="left" colspan="2">
                    Menu Category 
                    <asp:DropDownList ID="dropCategoryName" runat="server" Width="200px" AutoPostBack="True"
                        OnSelectedIndexChanged="dropCategoryName_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="btnAddMNItem" runat="server" Text="Add Menu Item" Width="100px" OnClick="btnAddMNItem_Click" /><br />
                    <br />
                </td>
            </tr>
            <tr style="width: 100%;">
                <td style="width: 100%;" colspan="2">
                    <asp:Repeater ID="rptMenuCategory" runat="server" OnItemDataBound="rptMenuCategory_ItemDataBound">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="background-color: #403e3f;
                                width: 100%">
                                <tr style="height: 30px;">
                                    <td style="width: 5px;">
                                    </td>
                                    <td style="width: 395px;" class="menuCategory color7">
                                        <%#Eval("Name") %>
                                    </td>
                                    <td style="width: 70px;">
                                        <%#Eval("PriceHeading1") %>
                                        &nbsp;
                                    </td>
                                    <td style="width: 70px;">
                                        <%#Eval("PriceHeading2") %>
                                        &nbsp;
                                    </td>
                                    <td style="width: 70px;">
                                        <%#Eval("PriceHeading3") %>
                                        &nbsp;
                                    </td>
                                    <td style="width: 50px;">
                                    </td>
                                    <td style="width: 50px;">
                                    </td>
                                    <td style="width: 50px;">
                                    </td>
                                    <td style="width: 30px;">
                                    </td>
                                    <td style="width: 50px;">
                                    </td>
                                    <td style="width: 50px;">
                                    </td>
                                </tr>
                            </table>
                            <asp:Repeater ID="rptMenuItem" runat="server" OnItemDataBound="rptMenuItem_ItemDataBound"
                                OnItemCommand="rptMenuItem_ItemCommand">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" style="background-color: #393738;
                                        width: 100%">
                                        <tr style="height: 30px;">
                                            <td style="width: 5px;">
                                            </td>
                                            <td style="width: 400px;">
                                                    <%#Eval("Name") %> &nbsp;&nbsp;<span class="color4"><%#Eval("ShortDescription") %></span>
                                            </td>
                                            <td style="width: 70px;" class="color6">
                                                <asp:Literal ID="ltPrice1" runat="server"></asp:Literal>
                                                &nbsp;
                                            </td>
                                            <td style="width: 70px;" class="color6">
                                                <asp:Literal ID="ltPrice2" runat="server"></asp:Literal>
                                                &nbsp;
                                            </td>
                                            <td style="width: 70px;" class="color6">
                                                <asp:Literal ID="ltPrice3" runat="server"></asp:Literal>
                                                &nbsp;
                                            </td>
                                            <td style="width: 50px;" class="color6">
                                                <asp:LinkButton ID="lbtEdit" Text="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditMenuItem"
                                                    runat="server"></asp:LinkButton>
                                            </td>
                                            <td style="width: 50px;" class="color6">
                                                <asp:LinkButton ID="lbtDrop" Text="Drop" CommandArgument='<%# Eval("ID") %>' CommandName="DropMenuItem"
                                                    runat="server"></asp:LinkButton>
                                            </td>
                                            <td style="width: 50px;" class="color6">
                                                <asp:LinkButton ID="lbtDown" Text="Down" CommandArgument='<%# Eval("ID") %>' CommandName="Down"
                                                    runat="server"></asp:LinkButton>
                                            </td>
                                            <td style="width: 30px;" class="color6">
                                                <asp:LinkButton ID="lbtUp" Text="Up" CommandArgument='<%# Eval("ID") %>' CommandName="Up"
                                                    runat="server"></asp:LinkButton>
                                            </td>
                                            <td style="width: 50px;" class="color6">
                                                <asp:LinkButton ID="lbtShow" Text="" CommandArgument='<%# Eval("ID") %>' runat="server"></asp:LinkButton>
                                                <asp:HiddenField ID="HiddenField1" Value='<%# Eval("IsActive") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        <br />
        <div style="width:99%; padding-left:5px;">
        <asp:Panel Width="100%" ID="panelMenuItem" Visible="false" runat="server">
            <table style="width: 99%; background-color: #414141;">
                <tr>
                    <td align="left" style="width: 97px">
                        Name &nbsp;
                    </td>
                    <td style="width: auto">
                        <asp:TextBox ID="txtName" runat="server" Width="287px"></asp:TextBox>
                        <span style="color: #ff0033"><strong>(*)<asp:Label ID="lblMess" runat="server" Text="Name is not null"
                            Visible="false"></asp:Label></strong></span></td>
                </tr>
                <tr>
                    <td align="left" style="width: 97px">
                        Menu Category &nbsp;
                    </td>
                    <td style="width: auto">
                        <asp:DropDownList ID="dropCategoryEdit" runat="server" Width="143px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="left" style="width: 97px; height: 26px">
                        Price &nbsp;
                    </td>
                    <td style="width: auto; height: 26px">
                        <asp:TextBox ID="txtPrice1" runat="server" Width="90px"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtPrice2" runat="server" Width="90px"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtPrice3" runat="server" Width="90px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" style="width: 97px">
                        Short Description &nbsp;</td>
                    <td style="width: auto">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txtShortDescription" runat="server" Rows="2" TextMode="MultiLine"
                            Width="420px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" style="width: 97px">
                        Full Description &nbsp;
                    </td>
                    <td style="width: auto">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txtFullDescription" runat="server" Rows="2" TextMode="MultiLine"
                            Width="420px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" style="width: 97px">
                        Upload Image &nbsp;
                    </td>
                    <td style="width: auto">
                        <asp:FileUpload ID="fileuploadImage" runat="server" /></td>
                </tr>
                <tr>
                    <td align="left" style="width: 97px">
                    </td>
                    <td style="width: auto">
                        <asp:Button ID="Button1" CssClass="center" runat="server" Text="Update" Width="80px" OnClick="Button1_Click" />
                        <asp:Button ID="btnAdd" CssClass="center" runat="server" Text="Add Menu" Width="80px" OnClick="btnAdd_Click"
                            Enabled="False" /></td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        </div>
    </div>
