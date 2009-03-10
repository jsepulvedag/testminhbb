<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingService.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Profile.SettingService" %>
<table style="width:650px;margin:0 auto;">
    <tr>
        <td colspan="2" style="padding-top:13px;padding-bottom:13px;">
            <asp:GridView ID="gvActive"  Width="100%" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="AllowGiftCertificate" HeaderText="Active Gift Certificate" />
                    <asp:BoundField DataField="AllowOnlineReservation" HeaderText="Active Online Reservation" />
                    <asp:BoundField DataField="AllowOnlineOrder" HeaderText="Active Online Order" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Right" Width="30px" Height="30px" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" Width="30px" HorizontalAlign="Center" Height="30px" />
                <RowStyle ForeColor="White" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td style="width:130px;text-align:left;padding-left:200px;">Active Gift Certificate</td>
        <td>
            <asp:RadioButton ID="rdGYes" runat="server" Text="Yes" GroupName="rdG" Checked="True" />
            <asp:RadioButton ID="rdGNo" runat="server" Text="No" GroupName="rdG" />
        </td>
    </tr>
     <tr>
        <td style="width:130px;text-align:left;padding-left:200px;">Active Online Reservation</td>
        <td>
            <asp:RadioButton ID="rdRYes" runat="server" Text="Yes" GroupName="rdR" Checked="True" />
            <asp:RadioButton ID="rdRNo" runat="server" Text="No" GroupName="rdR" />
        </td>
    </tr>
    <tr>
        <td style="width:130px;text-align:left;padding-left:200px;">Active Online Order</td>
        <td>
            <asp:RadioButton ID="rdOYes" runat="server" Text="Yes" GroupName="rdO" Checked="True" />
            <asp:RadioButton ID="rdONo" runat="server" Text="No" GroupName="rdO" />
        </td>
    </tr>
    <tr>
        <td style="width:130px;text-align:left;padding-left:200px;"></td>
        <td>
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="Button" Width="90px" OnClick="btnSave_Click" />
        </td>
    </tr>
</table>