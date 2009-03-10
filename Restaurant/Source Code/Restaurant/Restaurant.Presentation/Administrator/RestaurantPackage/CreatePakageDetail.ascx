<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatePakageDetail.ascx.cs" Inherits="Restaurant.Presentation.Administrator.RestaurantPackage.CreatePakageDetail" %>
<br />
<div style="width:98%; margin-left:15px; height:auto;border:1px #FFFFFF;color:Black;">
    <asp:GridView ID="gvPackageDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#999999" CellPadding="4" CellSpacing="2" PageSize="6" Width="100%" OnPageIndexChanging="gvPackageDetail_PageIndexChanging" OnSelectedIndexChanged="gvPackageDetail_SelectedIndexChanged">
        <RowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="PackageID" HeaderText="PackageID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="ExpiryMonth" HeaderText="Expiry month" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Priority" HeaderText="Priority" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <PagerStyle ForeColor="Black" HorizontalAlign="Right" Height="30px" />
        <SelectedRowStyle BackColor="#C0C0FF" Font-Bold="False" ForeColor="Black" />
        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" Height="30px" HorizontalAlign="Center" />
    </asp:GridView>
    <div style="margin:0 auto; color:Black;">
        <center>
            <table style="width:700px;height:auto;">
                <tr>
                    <td style="width:120px;height:auto;text-align:left;color:Black; padding-left:20px;">
                        ID</td>
                    <td style="width:399px;">
                        <asp:TextBox ID="txtID" runat="server" Width="170px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width:100px;height:auto;text-align:left;color:Black;">
                        PackageID</td>
                    <td style="width:230px;">
                        <asp:DropDownList ID="drpPackageID" runat="server" Width="146px" Enabled="False">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width:120px;height:auto;text-align:left;color:Black; padding-left: 20px;">
                        Name</td>
                    <td style="width:399px;">
                        <asp:TextBox ID="txtName" runat="server" Width="170px" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="* Can not empty"></asp:RequiredFieldValidator></td>
                    <td style="width:100px;height:auto;text-align:left;color:Black;">
                        Expiry month</td>
                    <td style="width:230px;">
                        <asp:DropDownList ID="drpExpiryMonth" runat="server" Width="146px" Enabled="False">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width:120px;height:auto;text-align:left;color:Black; padding-left: 20px;">
                        Price</td>
                    <td style="width:399px;">
                        <asp:TextBox ID="txtPrice" runat="server" Width="170px" ReadOnly="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrice"
                            ErrorMessage="*" ValidationExpression="^(((([0-9]+(\.)?)|([0-9]*\.[0-9]+))([eE][+\-]?[0-9]+)?))$"></asp:RegularExpressionValidator></td>
                    <td style="width:100px;height:auto;text-align:left;color:Black;">
                        Priority</td>
                    <td style="width:230px;">
                        <asp:DropDownList ID="drpPriority" runat="server" Width="146px" Enabled="False">
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
                    <td style="width:120px;height:auto;text-align:left;color:Black; padding-left: 20px;" valign="top">
                        Description</td>
                    <td style="width:399px;">
                        <asp:TextBox ID="txtDescription" runat="server" Width="170px" ReadOnly="True" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
                    <td style="width:100px;height:auto;text-align:left;color:Black;" valign="top">
                        Is active</td>
                    <td style="width:230px;" valign="top">
                        <asp:RadioButton ID="rdYes" runat="server" GroupName="grActive" Text="Yes" Enabled="False" />
                        <asp:RadioButton ID="rdNo" runat="server" Checked="True" GroupName="grActive" Text="No" Enabled="False" /></td>
                </tr>
                
            </table>
            <table style="width:400px;">
                <tr>
                    <td style="width:100px;">
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" Width="100px" /></td>
                    <td style="width:100px;">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" Enabled="False" OnClick="btnEdit_Click" Width="100px" /></td>
                    <td style="width:100px;">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Enabled="False" OnClick="btnDelete_Click" Width="100px" /></td>
                    <td style="width:100px;">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="100px" CausesValidation="False" /></td>
                </tr>
            </table>
        </center>
    </div>
</div>
<br />