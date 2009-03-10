<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ListReview.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Restaurant.Review.ListReview" %>
<%@ Register Src="../RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail"
    TagPrefix="uc3" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="ReviewLeft" TagPrefix="uc1" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="ReviewRight"
    TagPrefix="uc2" %>
<div style="margin: 0 auto; width: 869px; height: auto;">
    <div id="pageRestaurantByCuisineHeader">
    </div>
    <div class="pageRestaurantByCuisineCenter">
        <div style="width: 660px; float: left;">
            <uc3:RestaurantDetail ID="RestaurantDetail1" runat="server" />
        </div>
        <div class="ResultRate" style="padding-left:26px; width:181px; text-align:center;">
        <div class="ResultRateHeader">
                </div>
        <div class="ResultRateCenter">
            <div class="rateTip">
                Rating Tips
            </div>
            <div class="rateText">
                <div class="ratePoor">
                    1:Poor
                </div>
                <div class="ratePoor">
                    2:Bad
                </div>
                <div class="ratePoor">
                    3:Fair
                </div>
                <div class="ratePoor">
                    4:Good
                </div>
                <div class="ratePoor">
                    5:Excellent
                </div>
            </div>
        </div>
        <div class="ResultRateFooter">
                </div>
        </div>
        <div style="width: 869px; float: left;">
            <table style="width: 100%">
                <tr>
                    <td rowspan="2" style="width: 174px" valign="top">
                        <uc1:ReviewLeft ID="RestaurantReviewLeft" runat="server"></uc1:ReviewLeft>
                    </td>
                    <td rowspan="1" style="width: auto; height: 50px; padding-left: 15px;" valign="top">
                        <asp:Label ID="lblReviewCount" runat="server" Font-Size="18px" Font-Bold="False"
                            Width="100%"></asp:Label><br />
                        <asp:Label ID="lblRestaurantName" runat="server" Font-Size="18px" Font-Bold="False"
                            Width="100%"></asp:Label><br />
                        <asp:Label ID="lblMess" Visible="false" runat="server" Font-Size="18px" Font-Bold="False"
                            Width="100%"></asp:Label>
                        <asp:HyperLink ID="hplCreateReview" Font-Size="15px" runat="server" Visible="false">Add your Review</asp:HyperLink>
                    </td>
                    <td rowspan="2" style="width: 181px" valign="top">
                        <uc2:ReviewRight ID="ReviewRight" runat="server"></uc2:ReviewRight>
                    </td>
                </tr>
                <tr>
                    <td style="width: auto" valign="top" rowspan="2">
                        <div>
                            <asp:DataList ID="dtlListReview" runat="server" Width="100%" OnItemCommand="dtlListReview_ItemCommand">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="right" valign="top">
                                                <table style="width: 100%; background-color: #414141;">
                                                    <tr>
                                                        <td style="width: auto" align="left" valign="top">
                                                            <br />
                                                            <asp:LinkButton ID="lkbutTitle" Font-Bold="true" Font-Size="17px" Width="100%" ForeColor="#FFFF80"
                                                                CommandArgument='<%# Eval("ID") %>' CommandName="Title" runat="server" Text='<%# Eval("Title") %>'></asp:LinkButton>
                                                        </td>
                                                        <td colspan="2" rowspan="8" valign="top" style="width: 160px;">
                                                            <br />
                                                            <table style="width: 140px; background-color: #565455; font-weight: bold;">
                                                                <tr>
                                                                    <td rowspan="4" style="width: 60px; text-align: center;" valign="middle">
                                                                        <asp:Label ID="lblAvgRate" Font-Size="30px" runat="server" Text='<%# Eval("AvgRate") %>'></asp:Label></td>
                                                                    <td style="width: 90px; color: #E8BBBC;">
                                                                        <asp:Label ID="lblRateFood" Width="10px" runat="server" Font-Size="15px" Text='<%#Eval("RateFood") %>'></asp:Label>
                                                                        &nbsp; &nbsp; Food</td>
                                                                </tr>
                                                                <tr class="color2;">
                                                                    <td style="width: 90px; color: #E8BBBC;">
                                                                        <asp:Label ID="lblRateService" Width="10px" runat="server" Font-Size="15px" Text='<%#Eval("RateService") %>'></asp:Label>
                                                                        &nbsp; &nbsp; Service</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 90px; color: #E8BBBC;">
                                                                        <asp:Label ID="lblPrice" Width="10px" runat="server" Font-Size="15px" Text='<%#Eval("RatePrice") %>'></asp:Label>
                                                                        &nbsp; &nbsp; Price</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 90px; color: #E8BBBC;">
                                                                        <asp:Label ID="lblDecor" Width="10px" Font-Size="15px" runat="server" Text='<%#Eval("Decor") %>'></asp:Label>
                                                                        &nbsp;&nbsp;&nbsp; Decor</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: auto" align="left" valign="top">
                                                            Review by &nbsp
                                                            <asp:Label ID="lblMember" Font-Bold="true" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>&nbsp
                                                            on
                                                            <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreateReview") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: auto" align="left" valign="top">
                                                            <hr size="1" style="border: 1px solid rgb(65, 65, 65); width: 350px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: auto; font-size: 12px;" valign="top">
                                                            <asp:Label ID="lblPartyS" runat="server" ForeColor="#E8BBBC" Text="Number of peple"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lblPartySize" runat="server" Text='<%#Eval("PartySize") %>'></asp:Label><br />
                                                            <asp:Label ID="lblPriceR" ForeColor="#E8BBBC" runat="server" Text="Total amount"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            &nbsp;<asp:Label ID="lblPriceRange" runat="server" Text='<%#Eval("PriceRange") %>'></asp:Label>&nbsp;
                                                            on party
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: auto; font-size: 12px;" valign="top" rowspan="4">
                                                            <span style="color: #E8BBBC">Visit again?</span> &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lblVisitAgain" runat="server" Text='<%#Eval("VisitAgain") %>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                    </tr>
                                                    <tr>
                                                    </tr>
                                                    <tr>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: auto" valign="top">
                                                            <span style="font-size: 15px"><strong>
                                                                <br />
                                                                Order</strong></span></td>
                                                        <td colspan="2" rowspan="1" align="center">
                                                            <asp:LinkButton ID="lkbutAddReview" Font-Bold="true" Font-Size="13px" Width="100%"
                                                                ForeColor="#6E6CBD" CommandArgument='<%# Eval("MemberID") %>' CommandName="AddReview"
                                                                runat="server" Text="Add Your Review >>"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Label ID="lblOrder" runat="server" Text='<%#Eval("TableOrderService") %>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <hr size="1" style="border: solid 1px #414141; width: 350px;" />
                                                            &nbsp;&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" valign="top">
                                                            <span style="font-size: 15px"><strong>Review</strong></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" valign="top" style="height: 21px">
                                                            <asp:Label ID="lblReview" runat="server" Text='<%#Eval("Descript") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <div style="width: auto; float: right; color: White;">
                            <asp:Label ID="lblPage" Visible="false" runat="server" Text="Page : "></asp:Label>
                            &nbsp;&nbsp;<asp:DropDownList ID="dropPage" Width="50px" runat="server" OnSelectedIndexChanged="dropPage_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>
