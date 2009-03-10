<%@ Control Language="C#" AutoEventWireup="true" Codebehind="YourFavouriteRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Member.FavouriteRestaurant.YourFavouriteRestaurant" %>
<style type="text/css">
.textA
{
    color:#00ffff;
}
</style>

<div style="width: 640px; padding-left: 10px; font-size: 14px;">
    <div>
        <asp:Label ID="lblMess" runat="server" Visible="False"></asp:Label><br />
    </div>
    <div>
        <asp:Repeater runat="server" ID="rptFavourite" OnItemCommand="rptFavourite_ItemCommand">
            <HeaderTemplate>
                <div>
                    <table style="background-color: #565455; height: 30px; text-align:center; width: 640px;
                        border: solid 1px gray;  font-size:13px;font-weight:bold;">
                        <tr>
                            <td style="width: 150px;">
                                Restaurant Name</td>
                            <td style="width: 200px;">
                                Address</td>
                            <td style="width: 240px;">
                                Website Info</td>
                            <td ></td>
                                
                        </tr>
                    </table>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div>
                    <table style=" width: 640px; border: solid 1px gray; font-size:13px;">
                        <tr align="left">
                            <td style="width: 150px;">
                                <asp:HyperLink ID="hplFavourite" ForeColor="#00ffff" runat="server" NavigateUrl='<%# "~/Default.aspx?pid=ListReview&RidUrl=" + Eval("RestaurantID")  %>'
                                    Text='<%# Eval("Name") %>'></asp:HyperLink>
                            </td>
                            <td style="width: 200px;">
                                <asp:Label ID="lblAddress" runat="server" ForeColor="#00ffff" Text='<%# Eval("Address") %>'></asp:Label><br />
                                Country:&nbsp;&nbsp;<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label><br />
                                City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCity" runat="server" Text='<%# Eval("CityName") %>'></asp:Label><br />
                            </td>
                            <td style="width: 240px;">
                                <a href='<%# Eval("Website") %>' class="textA"> 
                                    <%# Eval("Website") %>
                                </a>
                                <br />
                                Email:&nbsp;&nbsp;<asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label><br />
                                Phone:&nbsp;&nbsp;<asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone1") %>'></asp:Label>
                            </td>
                            <td style="width: 50px;">
                                <asp:LinkButton ID="lbtRemove" ForeColor="#00ffff" runat="server" CommandArgument='<%# Eval("RestaurantID") %>' CommandName="Remove" Text="Remove"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                   
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
