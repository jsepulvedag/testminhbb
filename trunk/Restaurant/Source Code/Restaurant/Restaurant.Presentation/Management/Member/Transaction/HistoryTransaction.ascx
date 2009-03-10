<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HistoryTransaction.ascx.cs" Inherits="Restaurant.Presentation.Management.Member.Transaction.HistoryTransaction" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>

<div>
    <table style="width:645px;padding-left:5px;padding-top:15px;">
        <tr>
            <td style="padding-bottom:10px;">
                Type&nbsp;<asp:DropDownList ID="drpType" runat="server">
                    <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">Package</asp:ListItem>
                    <asp:ListItem Value="2">Gift</asp:ListItem>
                    <asp:ListItem Value="3">Order</asp:ListItem>
                    <asp:ListItem Value="4">Reservation</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                Status&nbsp;<asp:DropDownList ID="drpStatus" runat="server">
                    <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">Pending</asp:ListItem>
                    <asp:ListItem Value="2">Confirmed</asp:ListItem>
                    <asp:ListItem Value="3">Rejected</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                From&nbsp;<radCln:RadDatePicker ID="fromDate" runat="server" Width="110px">
                </radCln:RadDatePicker> &nbsp;&nbsp;&nbsp;
                To&nbsp;<radCln:RadDatePicker ID="toDate" runat="server" Width="110px">
                </radCln:RadDatePicker>
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" Width="70px" OnClick="btnSearch_Click" CssClass="Button" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvTransaction" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="gvTransaction_PageIndexChanging">
                
                    <PagerStyle Height="30px" HorizontalAlign="Right" />
                    <HeaderStyle Height="30px" HorizontalAlign="Center" BackColor="Gray" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="RestaurantID" DataNavigateUrlFormatString="/Default.aspx?pid=ListReview&amp;RidUrl={0}"
                            DataTextField="RestaurantName" HeaderText="Restaurant" />
                        <asp:BoundField DataField="Type" HeaderText="Type">
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedOn" DataFormatString="{0:d}" HeaderText="Created on">
                        </asp:BoundField>
                        <asp:BoundField DataField="Price" HeaderText="Price">
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status">
                        </asp:BoundField>
                        <asp:BoundField DataField="StatusDate" DataFormatString="{0:d}" HeaderText="Status date">
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>