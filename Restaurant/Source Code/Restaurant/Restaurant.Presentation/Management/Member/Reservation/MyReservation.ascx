<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MyReservation.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Member.Reservation.MyReservation" %>
<div style="width: 645px; margin: 0 auto; padding-top: 15px; text-align: center;">
    <asp:GridView ID="gvMyReservation" runat="server" AutoGenerateColumns="False" Width="100%"
        AllowPaging="True" ForeColor="White" HorizontalAlign="Center" OnPageIndexChanging="gvMyReservation_PageIndexChanging">
        <RowStyle Height="25" />
        <Columns>
            <asp:HyperLinkField HeaderText="Restaurant" DataTextField="RestaurantName" DataNavigateUrlFields="RestaurantId"
                DataNavigateUrlFormatString="/Default.aspx?pid=ListReview&amp;RidUrl={0}"></asp:HyperLinkField>
            <asp:BoundField DataField="CreateDate" HeaderText="Created on" DataFormatString="{0:d}">
            </asp:BoundField>
            <asp:BoundField DataField="ReservationDate" HeaderText="Reservation on" DataFormatString="{0:hh:mm MM-dd-yyyy}">
            </asp:BoundField>
            <asp:BoundField DataField="ReserDescription" HeaderText="Special instruction"></asp:BoundField>
            <asp:BoundField DataField="ConfirmByRestaurant" HeaderText="Status"></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle ForeColor="White" HorizontalAlign="Right" Width="30px" Height="30px" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" Width="30px" HorizontalAlign="Center"
            Height="30px" />
    </asp:GridView>
</div>
