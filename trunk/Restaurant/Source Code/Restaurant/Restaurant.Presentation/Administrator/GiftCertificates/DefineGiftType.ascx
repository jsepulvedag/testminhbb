<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefineGiftType.ascx.cs" Inherits="Restaurant.Presentation.Administrator.GiftCertificates.DefineGiftType" %>
<style type="text/css">
    .GridView
    {
        margin:0 auto;
        float:left;
        margin-left:200px;
    }
</style>
<div style="width:100%;height:auto; border:1px #FFFFFF;color:black;">    
    <table style="width:100%;">
        <caption style="text-align:left; margin-left:300px; font-size :large;font-weight:bold;">Define Gift Type</caption>
        <tr>
            <td style="width:100%;text-align:left;"><br />
                <asp:GridView ID="gvGiftType" CssClass="GridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" CellSpacing="2" OnPageIndexChanging="gvGiftType_PageIndexChanging"
                    OnSelectedIndexChanged="gvGiftType_SelectedIndexChanged" PageSize="6" Width="420px">
                    <RowStyle ForeColor="Black" HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Gift name" />
                        <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
                        <asp:CommandField ShowSelectButton="True" >
                            <ItemStyle ForeColor="Blue" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" Height="30px" />
                    <SelectedRowStyle BackColor="#C0C0FF" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" Height="30px" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width:100%;margin:0 auto;"><br />
                <table style="width:420px;margin:0 auto; float:left; margin-left:200px;">
                    <tr>
                        <td style="width:73px;text-align:left">ID</td>
                        <td style="width: 280px">
                            <asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:73px;text-align:left">Gift name</td>
                        <td style="width: 280px">
                            <asp:TextBox ID="txtGiftName" runat="server" ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGiftName"
                                ErrorMessage="* Can not empty"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width:73px;text-align:left">Is active</td>
                        <td style="width: 280px">
                            <asp:RadioButton ID="rdYes" runat="server" GroupName="gvActive" Text="Yes" Enabled="False" />
                            &nbsp;
                            <asp:RadioButton ID="rdNo" runat="server" Checked="True" GroupName="gvActive" Text="No" Enabled="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table style="width:100%;">
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="100px" OnClick="btnInsert_Click" CausesValidation="False" /></td>
                                    <td style="width:100px;"><asp:Button ID="btnEdit" runat="server" Text="Edit" Width="100px" OnClick="btnEdit_Click" Enabled="False" /></td>
                                    <td style="width:100px;"><asp:Button ID="btnDelete" runat="server" Text="Delete" Width="100px" OnClick="btnDelete_Click" Enabled="False" /></td>
                                    <td><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" OnClick="btnCancel_Click" CausesValidation="False" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table><br />
</div>