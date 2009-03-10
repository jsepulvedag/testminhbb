<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReservationCommission.ascx.cs" Inherits="Restaurant.Presentation.Administrator.Reservation.ReservationCommission" %>


<center>
<br />
<table style="width:75%;height:auto;color:black; ">
    <caption style="text-align:center;font-size:large;font-weight:bold;">Define Reservation Commission</caption>
    <tr>
        <td>
            <asp:GridView ID="gvCommission" Width="100%" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" PageSize="6" CellPadding="4" CellSpacing="2">
                <Columns>
                    <asp:BoundField DataField="GroupName" HeaderText="Group" />
                    <asp:BoundField DataField="Key" HeaderText="Title" />
                    <asp:BoundField DataField="Value" HeaderText="Commission" />
                    <asp:BoundField DataField="Unit" HeaderText="Type" />
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
            <table style="width: 90%;margin:0 auto;float:left;">
                <tr>
                    <td style="text-align:left;width:11%;">
                        Group&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtGroup" runat="server" Width="190px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:left;width:11%;">
                        Title&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtKey" runat="server" ReadOnly="True" Width="190px"></asp:TextBox></td>
                </tr> 
                <tr>
                    <td style="text-align:left;width:11%;">
                        Commission&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtCommission" runat="server" Width="190px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCommission"
                            ErrorMessage="* Can not empty !"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCommission"
                            ErrorMessage="* min 1, max 99" MaximumValue="99" MinimumValue="1"></asp:RangeValidator>
                        <asp:Label ID="lblMess" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align:left;width:11%;">
                        Type&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="drpType" runat="server">
                            <asp:ListItem Selected="True" Value="1">Percentage</asp:ListItem>
                            <asp:ListItem Value="2">Fixed Amount</asp:ListItem>
                        </asp:DropDownList></td>
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