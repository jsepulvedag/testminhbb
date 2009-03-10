<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewDetail.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.Review.ReviewDetail" %>
<%@ Register Src="../RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail"
    TagPrefix="uc3" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="ReviewLeft" TagPrefix="uc1" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="ReviewRight" TagPrefix="uc2" %>
 
<div style="margin: 0 auto; width: 869px; height: auto;">
    <div id="pageRestaurantByCuisineHeader">
    </div>
    <div class="pageRestaurantByCuisineCenter">
    <div style="width:869px;float:left;">
    <uc3:RestaurantDetail ID="RestaurantDetail1" runat="server" />
    </div>
<div style="width:869px; float:left;">
<table style="width: 869px; margin:0 auto;">
   
    <tr>
        <td style="width: 174px" valign="top">
                <uc1:ReviewLeft ID="RestaurantReviewLeft" runat="server" ></uc1:ReviewLeft>
        </td>
        <td style="width: auto; text-align: right;" valign="top">
        <asp:DataList ID="dtlReviewDetail" runat="server" Width="100%" >
            <ItemTemplate>
                <span style="color: #ff3300">
                </span>
                <table style="width: 100%">
                    <tr>
                        <td colspan="2">
                <asp:Label ID="Title" Font-Bold="true" Font-Size="17px" runat="server" Text='<%#Eval("Title") %>' Width="100%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                Review by
                <asp:Label ID="lableMemberName" Font-Bold="true" Font-Italic="true" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                            on
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("CreateReview")%>'></asp:Label><br />
	              <asp:Image ID = "image1" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" Width="100%" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Member Count</td>
                        <td style="width: auto">
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("PartySize")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Price for meal
                        </td>
                        <td style="width: auto">
                <asp:Label ID="lblPriceRage" runat="server" Text='<%#Eval("PriceRange")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Food</td>
                        <td style="width: auto">
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("RateFood")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Service</td>
                        <td style="width: auto">
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("RateService")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Price</td>
                        <td style="width: auto">
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("RatePrice")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Decor</td>
                        <td style="width: auto">
                            <asp:Label ID="lblDecor" runat="server" Text='<%#Eval("RateDecor")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Visit again?</td>
                        <td style="width: auto">
                <asp:Label ID="Label4" runat="server" Text='<%#Eval("VisitAgain")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2">
	              <asp:Image ID = "image2" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" Width="100%" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; font-size:15px; font-weight:bold;">
                            Order</td>
                        <td style="width: auto">
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("TableOrderService")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: auto">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 21px">
	              <asp:Image ID = "image3" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" Width="100%" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-size:15px;font-weight:bold;">
                            Review</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                <asp:Label ID="Label5" runat="server" Text='<%#Eval("Description")%>' Width="100%"></asp:Label></td>
                    </tr>
                </table>
            </ItemTemplate>
        
        </asp:DataList><br />
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#FFFF66">Back to List Review</asp:HyperLink>
        </td>
        <td style="width: 181px" valign="top">
    <uc2:ReviewRight ID="ReviewRight" runat="server" ></uc2:ReviewRight>
            </td>
    </tr>
</table>
</div>
</div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>

