<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingMailServer.ascx.cs" Inherits="Restaurant.Presentation.Administrator.ParamterManagement.SettingMailServer" %>
<center>
<br />
<table style="width:800px;height:auto;color:black">
    <caption style="text-align:center;font-size:large;font-weight:bold;">Setting Mail Server</caption>
    <tr>
        <td colspan="2"><br />
            <asp:GridView ID="gvMailServer" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="6" CellPadding="4" CellSpacing="2" Visible="False">
                <Columns>
                    <asp:BoundField DataField="MailServerHost" HeaderText="Host" />
                    <asp:BoundField DataField="MailServerPort" HeaderText="Port" />
                    <asp:BoundField DataField="MailServerUserName" HeaderText="User's name" />
                    <asp:BoundField DataField="MailServerPassword" HeaderText="Password" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Created on" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="ModifiedDate" HeaderText="Modified on" DataFormatString="{0:d}" />
                </Columns>
                <RowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#8080FF" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" />
            
            </asp:GridView>
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <table style="width: 68%;margin:0 auto; padding-left:100px;">
                <tr>
                    <td style="text-align:left;width:22%;">
                        Mail
                        server host</td>
                    <td>
                        <asp:TextBox ID="txtHost" runat="server" Width="190px"></asp:TextBox>
                        <asp:Label ID="lblHost" runat="server" Text="MailServerHost" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align:left;width:22%;">
                        Mail
                        server port</td>
                    <td>
                        <asp:TextBox ID="txtPort" runat="server" Width="190px"></asp:TextBox>
                        <asp:Label ID="lblPort" runat="server" Text="MailServerPort" Visible="False"></asp:Label></td>
                </tr> 
                <tr>
                    <td style="text-align:left;width:22%;">
                        User's name</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Width="190px"></asp:TextBox>
                        <asp:Label ID="lblUserName" runat="server" Text="MailServerUserName" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align:left;width:22%;">
                        Password</td>
                    <td>
                       <asp:TextBox ID="txtPassword" runat="server" Width="190px"></asp:TextBox> 
                        <asp:Label ID="lblPassword" runat="server" Text="MailServerPassword" Visible="False"></asp:Label></td>
                </tr>   
                <tr>
                    <td style="text-align:right;width:22%; height: 22px;">
                        </td>
                    <td style="height: 22px;">
                        <asp:Button ID="btnEdit" runat="server" Text="Save" Width="100px" OnClick="btnEdit_Click" />
                    </td>        
                </tr>
            </table>
        </td>
    </tr> 
</table> 
</center>
<br />