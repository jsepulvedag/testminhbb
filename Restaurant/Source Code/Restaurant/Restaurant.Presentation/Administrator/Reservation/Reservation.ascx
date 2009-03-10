<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Reservation.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.Reservation.Reservation" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>
<div style="width: 99%; margin: 0 auto; color: Black;">
    <%--border:solid 1px #999999;--%>
    <div style="width: 100%; color: Black;">
        <table style="width: 98%; padding-left: 10px; padding-top: 5px; padding-bottom: 15px;">
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
                        <asp:ListItem Value="0">All status</asp:ListItem>
                        <asp:ListItem Value="1">Pending</asp:ListItem>
                        <asp:ListItem Value="2">Confirmed</asp:ListItem>
                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; Restaurant&nbsp;&nbsp;
                    <asp:DropDownList ID="drpRestaurant" runat="server" Visible="true" Height="20px"
                        Width="150px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" CausesValidation="False"
                        CssClass="Button" Text="Search" Width="90px" OnClick="btnSearch_Click" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvReservation" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        Width="100%" AllowPaging="True" ForeColor="Black" OnPageIndexChanging="gvReservation_PageIndexChanging"
                        OnSelectedIndexChanged="gvReservation_SelectedIndexChanged" OnRowDataBound="gvReservation_RowDataBound"
                        OnRowCommand="gvReservation_RowCommand">
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Right" Width="30px" Height="30px" />
                        <SelectedRowStyle BackColor="#C0C0FF" Font-Bold="True" ForeColor="Black" />
                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" Width="30px"
                            Height="30px" HorizontalAlign="Left" />
                        <Columns>
                        <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant"><ItemStyle  Width="150px"/></asp:BoundField>
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
                            <asp:BoundField DataField="ReserDescription" HeaderText="Special instruction">
                            </asp:BoundField>
                            <asp:BoundField DataField="ConfirmByRestaurant" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Realized">
                                <ItemTemplate>
                                    <asp:DropDownList ID="drpRealized" runat="server" Width="100%">
                                        <asp:ListItem Value="1" Text="Realized"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Not Realized"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="idReservation" runat="server" Value='<%# Eval("Realized") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    &nbsp;&nbsp;<asp:LinkButton ID="lbtUpdate" runat="server" CommandName="UpdateReservation"
                                        CommandArgument='<%# Eval("ID") %>' Text="Update" ForeColor="Blue"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</div>
