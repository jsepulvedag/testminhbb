<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CreatePackage.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.RestaurantPackage.CreatePackage" %>
<div style="width: 98%; height: auto; margin-left: 2px; border: 1px #FFFFFF; color: White;
    margin-left: 10px;">
    <br />
    <asp:GridView ID="gvPackage" runat="server" Width="100%" AutoGenerateColumns="False"
        OnSelectedIndexChanged="gvPackage_SelectedIndexChanged" AllowPaging="True" PageSize="6"
        OnPageIndexChanging="gvPackage_PageIndexChanging" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                <ControlStyle ForeColor="White" />
                <ItemStyle  HorizontalAlign="center" Width="30px"/>
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name">
                <ControlStyle ForeColor="White" />
                <FooterStyle ForeColor="White" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="AllowOnlineOrder" HeaderText="Order">
                <ControlStyle ForeColor="White" />
                <FooterStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowGiftCertificate" HeaderText="Gift">
                <ControlStyle ForeColor="White" />
                <FooterStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowReservation" HeaderText="Reservation">
                <ControlStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowMap" HeaderText="Map">
                <ControlStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowVideo" HeaderText="Video">
                <ControlStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowPhoto" HeaderText="Photo">
                <ControlStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowEvent" HeaderText="Event">
                <ControlStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowJobPortal" HeaderText="Jobportal">
                <ControlStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowMenu" HeaderText="Menu">
                <ControlStyle ForeColor="White" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="AllowSponsored" HeaderText="Sponsored" />
            <asp:BoundField DataField="Priority" HeaderText="Priority">
                <ControlStyle ForeColor="White" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:CommandField ShowSelectButton="True">
                <ItemStyle ForeColor="Blue" HorizontalAlign="center" />
            </asp:CommandField>
        </Columns>
        <PagerStyle HorizontalAlign="Right" ForeColor="Blue" />
        <HeaderStyle BackColor="#CCCCCC" ForeColor="Black" />
        <RowStyle ForeColor="Black" />
        <SelectedRowStyle BackColor="#C0C0FF" Font-Bold="True" ForeColor="Black" />
    </asp:GridView>
    <br />
    <div style="margin: 0 auto;">
        <center>
            <table style="width: 800px">
                <tr>
                    <td style="width: 100px; height: 26px; text-align: left; color: Black; padding-left: 10px;">
                        ID</td>
                    <td style="width: 200px; height: 26px;">
                        <asp:TextBox ID="txtID" runat="server" ReadOnly="True" Width="150px"></asp:TextBox></td>
                    <td style="width: 100px; height: 26px; text-align: left; color: Black; padding-left: 10px;">
                        Name</td>
                    <td style="width: 300px; height: 26px;">
                        <asp:TextBox ID="txtName" runat="server" Width="210px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="* Can not empty"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px; padding-left:10px; height: auto; text-align: left; color: Black;">
                        Online order</td>
                    <td style="width: 200px; height: auto;">
                        <asp:RadioButtonList ID="rdOrder" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Gift certificate</td>
                    <td style="width: 300px; height: auto;">
                        <asp:RadioButtonList ID="rdGift" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Reservation</td>
                    <td style="width: 200px; height: auto;">
                        <asp:RadioButtonList ID="rdReservation" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Map</td>
                    <td style="width: 300px; height: auto;">
                        <asp:RadioButtonList ID="rdMap" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Video</td>
                    <td style="width: 200px; height: 21px;">
                        <asp:RadioButtonList ID="rdVideo" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Photo</td>
                    <td style="width: 300px; height: 21px;">
                        <asp:RadioButtonList ID="rdPhoto" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Event</td>
                    <td style="width: 200px; height: auto;">
                        <asp:RadioButtonList ID="rdEvent" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Job portal</td>
                    <td style="width: 300px; height: auto;">
                        <asp:RadioButtonList ID="rdJobportal" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Menu</td>
                    <td style="width: 200px; height: auto;">
                        <asp:RadioButtonList ID="rdMenu" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Priority</td>
                    <td style="width: 300px; height: auto;">
                        <asp:RadioButtonList ID="rdIsActive" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" ForeColor="White">
                            <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Sponsored</td>
                    <td style="width: 200px; height: auto;">
                        <asp:RadioButtonList ID="rdSponsored" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" ForeColor="White">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;">
                        Is Active</td>
                    <td style="width: 300px; height: auto;">
                        <asp:DropDownList ID="drpPriority" runat="server" Width="83px">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: auto; text-align: left; color: Black; padding-left: 10px;" valign="top">
                        Description</td>
                    <td colspan="3" style="height: auto; text-align: left; color: White;">
                        <asp:TextBox ID="txtDescription" runat="server" Width="560px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                            ErrorMessage="* Can not empty"></asp:RequiredFieldValidator></td>
                </tr>
            </table>
            <table style="width: 400px; margin-left: 100px;">
                <tr>
                    <td style="width: 100px">
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="100px" OnClick="btnInsert_Click"
                            CausesValidation="False" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="100px" OnClick="btnEdit_Click"
                            Enabled="False" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="100px" OnClick="btnDelete_Click"
                            Enabled="False" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" OnClick="btnCancel_Click"
                            CausesValidation="False" /></td>
                </tr>
            </table>
            <br />
        </center>
    </div>
</div>
