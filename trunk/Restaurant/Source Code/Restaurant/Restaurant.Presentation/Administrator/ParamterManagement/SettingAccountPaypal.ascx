<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingAccountPaypal.ascx.cs" Inherits="Restaurant.Presentation.Administrator.ParamterManagement.SettingAccountPaypal" %>
<center>
<br />
<table style="width:800px;height:auto;color:black">
    <caption style="text-align:center;font-size:large;font-weight:bold;">Setting Business Account Paypal</caption>
    <tr>
        <td colspan="2"><br />
            <asp:GridView ID="gvPaypalParameter" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="6" CellPadding="4" CellSpacing="2">
                <Columns>
                    <asp:BoundField DataField="PaypalUserName" HeaderText="Paypal User's name" />
                    <asp:BoundField DataField="PaypalPassword" HeaderText="Paypal Password" />
                    <asp:BoundField DataField="PaypalSignature" HeaderText="Paypal Signature " />
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
            <table style="width: 68%;margin:0 auto; float:left;">
                <tr>
                    <td style="text-align:left;width:11%;">
                        <asp:Label ID="lblUserName" runat="server" Text="PaypalUserName"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Width="415px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:left;width:11%;">
                        <asp:Label ID="lblPassword" runat="server" Text="PaypalPassword"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="415px"></asp:TextBox></td>
                </tr> 
                <tr>
                    <td style="text-align:left;width:11%;">
                        <asp:Label ID="lblSignature" runat="server" Text="PaypalSignature"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtSignature" runat="server" Width="415px"></asp:TextBox>
                    </td>
                </tr>   
                <tr>
                    <td style="text-align:right;width:11%; height: 22px;">
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