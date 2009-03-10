<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ViewFavouriteRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Member.FavouriteRestaurant" %>
<div>
    <asp:Repeater runat="server" ID="rptFavourite">
        <ItemTemplate>
            <asp:Label ID="lblRestaurant" runat="server" Text='<%# Eval("RestaurantName") %>'></asp:Label>
            <br />
        </ItemTemplate>
    </asp:Repeater>
</div>
