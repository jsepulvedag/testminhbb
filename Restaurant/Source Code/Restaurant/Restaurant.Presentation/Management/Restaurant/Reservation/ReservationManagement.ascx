<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ReservationManagement.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Restaurant.Reservation.ReservationManagement" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>
<table style="width: 650px; padding-left: 10px; padding-top: 5px; padding-bottom: 15px;">
    <tr>
        <td>
            From&nbsp;&nbsp;
            <radCln:RadDatePicker ID="fromDate" runat="server" Width="110px">
                <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" "
                    Title="" TitleIconImageUrl="" TitleUrl="" />
            </radCln:RadDatePicker>
            &nbsp;&nbsp;&nbsp;&nbsp; To&nbsp;&nbsp;
            <radCln:RadDatePicker ID="toDate" runat="server" Width="110px">
                <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" "
                    Title="" TitleIconImageUrl="" TitleUrl="" />
            </radCln:RadDatePicker>
            &nbsp;&nbsp;&nbsp;&nbsp; Status&nbsp;&nbsp;
            <asp:DropDownList ID="drpStatusSearch" runat="server" Width="100px">
                <asp:ListItem Value="0" Selected="True">All status</asp:ListItem>
                <asp:ListItem Value="1">Pending</asp:ListItem>
                <asp:ListItem Value="2">Confirmed</asp:ListItem>
                <asp:ListItem Value="3">Rejected</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server"
                CausesValidation="False" CssClass="Button" Text="Search" Width="90px" OnClick="btnSearch_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvReservation" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" AllowPaging="True" ForeColor="White" OnPageIndexChanging="gvReservation_PageIndexChanging"
                OnSelectedIndexChanged="gvReservation_SelectedIndexChanged" OnRowDataBound="gvReservation_RowDataBound">
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Right" Width="30px" Height="30px" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="25" />
                <HeaderStyle BackColor="Gray" Font-Bold="True" CssClass="textcenter" ForeColor="White"
                    Width="30px" Height="30px" />
                <Columns>
                    <asp:TemplateField HeaderText="Customer name">
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hdID" Value='<%#Eval("ID")%>' />
                            <asp:HiddenField runat="server" ID="hdTransactionID" Value='<%#Eval("TransactionID")%>' />
                            <asp:Label runat="server" ID="lblCustomerName" Text='<%#Eval("CustomerName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="ReservationDate" HeaderText="Reservation on" DataFormatString="{0:hh:mm MM-dd-yyyy}" />
                    <asp:BoundField DataField="ReserDescription" HeaderText="Special instruction" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="drpStatus" Width="90px">
                                <asp:ListItem Text="Pending" Value="1" Selected="True">                                        
                                </asp:ListItem>
                                <asp:ListItem Text="Confirmed" Value="2">                                        
                                </asp:ListItem>
                                <asp:ListItem Text="Rejected" Value="3">                                        
                                </asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label runat="server" ID="lblStatus" Visible="false" Text='<%#Eval("ConfirmByRestaurant") %>' />
                            <asp:HiddenField runat="server" ID="hdStatus" Value='<%#Eval("ConfirmByRestaurant")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Update" SelectText="Update">
                        <ItemStyle ForeColor="Cyan" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
