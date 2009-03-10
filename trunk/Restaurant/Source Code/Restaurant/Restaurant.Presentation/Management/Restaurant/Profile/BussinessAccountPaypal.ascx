<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BussinessAccountPaypal.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Profile.BussinessAccountPaypal" %>
<table style="width:650px;padding-left:10px;padding-top:15px;">
    <tr>
        <td colspan="2" style="padding-bottom:15px;">
            <asp:GridView ID="gvPaypalAccount" runat="server" AutoGenerateColumns="False" Width="100%">            
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Right" Width="30px" Height="30px" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" Width="30px" HorizontalAlign="Center" Height="30px" /><RowStyle ForeColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="User's name" DataField="APIUserName" />
                    <asp:BoundField HeaderText="Password" DataField="APIPassword" />
                    <asp:BoundField HeaderText="Signature" DataField="APISignature" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td style="width: 120px">Paypal user's name</td>
        <td><asp:TextBox ID="txtUserName" runat="server" Width="415px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Can not null"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td style="width: 120px">Paypal password</td>
        <td><asp:TextBox ID="txtPassword" runat="server" Width="415px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Can not null"></asp:RequiredFieldValidator></td>
    </tr> 
    <tr>
        <td style="width: 120px">Paypal signature</td>
        <td><asp:TextBox ID="txtSignature" runat="server" Width="415px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSignature" ErrorMessage="Can not null"></asp:RequiredFieldValidator></td>
    </tr>   
    <tr>
        <td style="width: 120px"></td>
        <td><asp:Button ID="btnEdit" runat="server" CssClass="Button" Text="Save" Width="100px" OnClick="btnEdit_Click" /><asp:Button ID="btnDelete" CssClass="Button" runat="server" Text="Delete" Width="100px" OnClick="btnDelete_Click" /></td>        
    </tr>
</table>