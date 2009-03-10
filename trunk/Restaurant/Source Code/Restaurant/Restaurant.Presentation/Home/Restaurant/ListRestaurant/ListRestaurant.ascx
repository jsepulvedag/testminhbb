<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ListRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Restaurant.ListRestaurant.ListRestaurant" %>
<div id="pageRestaurantByCuisine">
    <!-- header-->
    <div id="pageRestaurantSearch" style="float: left; text-align: left; padding-top: 10px;
        padding-left: 13px; font-size: 14px; vertical-align: middle;">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
    </div>
    <!-- header-->
    <!--center-->
    <div class="pageRestaurantByCuisineCenter">
        <!--rate-->
        <div class="pageResultRate">
            <div class="Result">
                <div class="ResultFound">
                    <b>
                        <asp:Literal ID="ltResult" runat="server"></asp:Literal></b> results found<!-- in : Asian Cuisine-->
                </div>
                <div class="ResultFound">
                    <div class="ResultFoundPrint">
                        <asp:Image ID="imgPrint" runat="server" ImageUrl="/Media/Images/printIcon.jpg" />
                        <a href="#">print</a>
                    </div>
                    <div class="ResultFoundHelp">
                        <asp:Image ID="Image1" runat="server" ImageUrl="/Media/Images/helpIcon.jpg" />
                        <a href="#">help</a>
                    </div>
                    <div class="perpage">
                        <asp:DropDownList ID="ddlPerpage" Width="45px" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlPerpage_SelectedIndexChanged">
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="15">15</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                        </asp:DropDownList>
                        Record Per Page
                    </div>
                </div>
            </div>
            <div class="ResultRate">
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
        </div>
        <!--rate-->
        <!--main-->
        <div class="pageResultByCuisineMain">
            <br />
            <asp:DataGrid ID="dgPage" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                ShowHeader="false" BorderWidth="0" GridLines="none" AllowCustomPaging="True"
                OnPageIndexChanged="dgPage_PageIndexChanged" Font-Bold="True" Font-Size="13px">
                <PagerStyle CssClass="pager" Mode="NumericPages" />
                <Columns>
                    <asp:TemplateColumn></asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
            <div class="pageResultByCuisineMainLeft">
                <%--<div class="hr">
						<hr size="1" style="border:solid 1px #414141" />
					</div>--%>
                <!--left-->
                <span style="text-align: right"></span>
                <table cellpadding="0" cellspacing="0" border="1" width="651" style="border-collapse: collapse;
                    border-color: #414141; background-color: #3d393a;">
                    <tr>
                        <td style="text-align: left;">
                            &nbsp&nbsp&nbsp<asp:Label ID="lblMess" ForeColor="Red" Font-Italic="True" Font-Bold="True"
                                Font-Size="15px" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <asp:Repeater ID="rptRestaurant" runat="server" OnItemDataBound="rptRestaurant_ItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr style="height: 30px;">
                                            <td style="width: 10px;">
                                                &nbsp;</td>
                                            <td style="width: 200px;" class="listrestaurantheader color1">
                                                Restaurant Name
                                            </td>
                                            <td style="width: 99px;" class="listrestaurantheader color2">
                                                Neighbourhood</td>
                                            <td style="width: 100px;" class="listrestaurantheader color2">
                                                Cuisine</td>
                                            <td style="width: 50px;" class="listrestaurantheader color2">
                                                Score</td>
                                            <td style="width: 50px;" class="listrestaurantheader color4">
                                                Food</td>
                                            <td style="width: 50px;" class="listrestaurantheader color4">
                                                Service</td>
                                            <td style="width: 50px;" class="listrestaurantheader color4">
                                                Price</td>
                                            <td class="listrestaurantheader color4">
                                                Decor</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr style="height: 30px;">
                                            <td style="width: 10px;">
                                                &nbsp;</td>
                                            <td style="width: 200px; font-size: 12px; font-weight: bold;">
                                                <a class="color1" href='/Default.aspx?pid=ListReview&RidUrl=<%#Eval("ID") %>'>
                                                    <%#Eval("Name") %>
                                                </a>
                                            </td>
                                            <td style="width: 99px;">
                                                <%#Eval("Neighbourhood") %>
                                            </td>
                                            <td style="width: 100px;">
                                                <%#Eval("Cuisine") %>
                                            </td>
                                            <td style="width: 50px; font-size: 12pt; font-weight: bold;">
                                                <%#Eval("Score") %>
                                            </td>
                                            <td style="width: 50px;">
                                                <span class="red_square">&nbsp;<%#Eval("FoodPoint") %>&nbsp;</span></td>
                                            <td style="width: 50px;">
                                                <span class="red_square">&nbsp;<%#Eval("PricePoint") %>&nbsp;</span></td>
                                            <td style="width: 50px;">
                                                <span class="red_square">&nbsp;<%#Eval("ServicePoint") %>&nbsp;</span></td>
                                            <td>
                                                <span class="red_square">&nbsp;<%#Eval("DecorPoint") %>&nbsp;</span></td>
                                        </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td style="width: 427px;" class="color5">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr height="20px">
                                                        <td>
                                                            &nbsp;<%#Eval("Address") %>&nbsp;|&nbsp;<a class="color2" href="#">Map</a>
                                                        </td>
                                                    </tr>
                                                    <tr height="20px">
                                                        <td>
                                                            &nbsp;<%#Eval("CityName") %>
                                                            ,
                                                            <%#Eval("StateName") %>
                                                        </td>
                                                    </tr>
                                                    <tr height="20px">
                                                        <td>
                                                            &nbsp;<%#Eval("Phone1") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr height="20px">
                                                        <td>
                                                            <a class="color2" href="/Default.aspx?pid=ListReview&RidUrl=<%#Eval("Id") %>">
                                                                <%#Eval("Review") %>
                                                                review(s)</a>&nbsp;|&nbsp; <a class="color3" href="/Default.aspx?pid=MemberCreateReview&RidUrl=<%#Eval("Id") %>">
                                                                    Add your Review</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;<br />
                                    <span>
                                        <asp:HyperLink ID="hlkHome" runat="server">
                                            <asp:Image ID="imgHome" runat="server" ToolTip="Home" ImageUrl="/Media/Images/homeIcon.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span><span>
                                        <asp:HyperLink ID="hlkMenu" runat="server">
                                            <asp:Image ID="imgMenu" runat="server" ToolTip="Menu" ImageUrl="/Media/Images/iconMenu.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span><span>
                                        <asp:HyperLink ID="hlkReservation" runat="server">
                                            <asp:Image ID="imgReservation" runat="server" ToolTip="Reservation" ImageUrl="/Media/Images/reservationInvisibleIcon.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span><span>
                                        <asp:HyperLink ID="hlkGift" runat="server">
                                            <asp:Image ID="imgGift" runat="server" ToolTip="Gift Certificate" ImageUrl="/Media/Images/giftIcon.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span><span>
                                        <asp:HyperLink ID="hlkOrder" runat="server">
                                            <asp:Image ID="imgOrder" runat="server" ToolTip="Delivery" ImageUrl="/Media/Images/deliveryIcon.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span><span>
                                        <asp:HyperLink ID="hlkPhoto" runat="server">
                                            <asp:Image ID="imgPhoto" runat="server" ToolTip="Photo" ImageUrl="/Media/Images/photoIcon.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span><span>
                                        <asp:HyperLink ID="hlkVideo" runat="server">
                                            <asp:Image ID="imgVideo" runat="server" ToolTip="Video" ImageUrl="/Media/Images/VideoIcon.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span><span>
                                        <asp:HyperLink ID="hlkMobile" runat="server">
                                            <asp:Image ID="imgMobile" runat="server" ToolTip="Mobile" ImageUrl="/Media/Images/mobileIcon.jpg"
                                                BorderWidth="0" /></asp:HyperLink>
                                    </span>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <table cellpadding="0" cellspacing="0" border="1" width="651" style="border-collapse: collapse;
                    border-color: #414141; background-color: #3d393a;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <asp:DataList ID="dtlRestaurant" runat="server">
                    <HeaderTemplate>
                        <table id="Table1" class="pageResultByCuisineMainTable" runat="server" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <td class="pageResultByCuisineMainNameTitle">
                                    <asp:LinkButton ID="lbtRestaurantName" runat="server" Text="RestaurantName" />
                                </td>
                                <td class="pageResultByCuisineMainNeighborhood">
                                    <asp:LinkButton ID="lbt" runat="server" Text="Neighborhood" />
                                </td>
                                <td class="pageResultByCuisineMainNeighborhood">
                                    <asp:LinkButton ID="lbtCuisine" runat="server" Text="Cuisine" />
                                </td>
                                <td class="pageResultByCuisineMainScoreTitle">
                                    <asp:Label ID="lblScore" runat="server" Text="Score"></asp:Label>
                                </td>
                                <td class="pageResultByCuisineMainScoreTitle">
                                    <asp:Label ID="lblFood" runat="server" Text="Food"></asp:Label>
                                </td>
                                <td class="pageResultByCuisineMainScoreTitle">
                                    <asp:Label ID="lblService" runat="server" Text="Service"></asp:Label>
                                </td>
                                <td class="pageResultByCuisineMainPrice">
                                    <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div class="hr">
                            <hr size="1" style="border: solid 1px #414141" />
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table id="Table2" class="pageResultByCuisineMainTable" runat="server" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <td class="pageResultByCuisineMainName">
                                    <a href="Default.aspx?pid=ListReview&RestaurantID=<%#Eval("ID")%>">
                                        <%#Eval("Name")%>
                                    </a>
                                </td>
                                <td class="pageResultByCuisineMainNeighborhoodContent">
                                    <asp:Label ID="lblNeighborhood" runat="server" Text="Neighborhood"></asp:Label>
                                </td>
                                <td class="pageResultByCuisineMainNeighborhoodContent">
                                    <asp:Label ID="lblCuisine" runat="server" Text="CuisineName"></asp:Label>
                                </td>
                                <td class="pageResultByCuisineMainScoreNumber">
                                    <asp:Label ID="lblScore" runat="server" Text="4"></asp:Label>
                                </td>
                                <td class="pageResultByCuisineMainScore">
                                    <span class="red_square">
                                        <asp:Label ID="lblFood" runat="server" Text="4"></asp:Label>
                                    </span>
                                </td>
                                <td class="pageResultByCuisineMainScore">
                                    <span class="red_square">
                                        <asp:Label ID="lblService" runat="server" Text="3"></asp:Label>
                                    </span>
                                </td>
                                <td class="pageResultByCuisineMainPriceContent">
                                    <span class="red_square">
                                        <asp:Label ID="lblPrice" runat="server" Text="5"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td class="address">
                                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="address">
                                    <asp:Label ID="lblCity" runat="server" Text="CityName"></asp:Label>
                                    -<asp:HyperLink ID="lnkMap" runat="server" Text="Map"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="icon">
                                    <span>
                                        <asp:ImageButton ID="ibtnHome" runat="server" AlternateText="Home" ToolTip="Home"
                                            ImageUrl="/Media/Images/homeIcon.jpg" CommandName="Home" /></span> <span>
                                                <asp:ImageButton ID="ibtnMenu" runat="server" AlternateText="Menu" ToolTip="Menu"
                                                    ImageUrl="/Media/Images/iconMenu.jpg" CommandName="Menu" CommandArgument='<%#Eval("ID") %>' /></span>
                                    <span>
                                        <asp:ImageButton ID="ibtnReservation" runat="server" AlternateText="Reservation"
                                            ToolTip="Reservation" ImageUrl="/Media/Images/reservationInvisibleIcon.jpg" CommandName="Reservation"
                                            CommandArgument='<%#Eval("ID") %>' /></span> <span>
                                                <asp:ImageButton ID="ibtnGift" runat="server" AlternateText="gift" ToolTip="Gift"
                                                    ImageUrl="/Media/Images/giftIcon.jpg" CommandName="Gift" CommandArgument='<%#Eval("ID") %>' /></span>
                                    <span>
                                        <asp:ImageButton ID="ibtnDelivery" runat="server" AlternateText="Delivery" ToolTip="Delivery"
                                            ImageUrl="/Media/Images/deliveryIcon.jpg" CommandName="Delivery" CommandArgument='<%#Eval("ID") %>' /></span>
                                    <span><a href='/Default.aspx?pid=ListPhoto&RestaurantId=<%#Eval("ID") %>'>
                                        <img src="/Media/Images/photoIcon.jpg" border="0" /></a> </span><span>
                                            <asp:ImageButton ID="ibtnVideo" runat="server" AlternateText="Video" ToolTip="Video"
                                                ImageUrl="/Media/Images/VideoIcon.jpg" CommandName="Video" CommandArgument='<%#Eval("ID") %>' /></span>
                                    <span>
                                        <asp:ImageButton ID="ibtnMobile" runat="server" AlternateText="Mobile" ToolTip="Mobile"
                                            ImageUrl="/Media/Images/mobileIcon.jpg" CommandName="Mobile" CommandArgument='<%#Eval("ID") %>' /></span>
                                </td>
                            </tr>
                        </table>
                        <div class="hr">
                            <hr size="1" style="border: solid 1px #414141" />
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <!--end main left-->
            <div class="pageResultByCuisineMainRight">
                <div class="pageResultByCuisineMainRightJoin">
                    <asp:ImageButton ID="imgbtnJoin" runat="server" ImageUrl="/Media/Images/restaurantByCuisineJoin.jpg"
                        OnClick="imgbtnJoin_Click" />
                </div>
                <div class="pageResultByCuisineMainRightJoin">
                    <asp:ImageButton ID="imgbtnInvite" runat="server" ImageUrl="/Media/Images/restaurantInCuisineInvite.jpg"
                        OnClick="imgbtnInvite_Click1" />
                </div>
                <div class="pageResultByCuisineMainRightJoin">
                    <asp:ImageButton ID="imgbtnLinktoUs" runat="server" ImageUrl="/Media/Images/restaurantInfoLink.jpg"
                        OnClick="imgbtnLinktoUs_Click1" />
                </div>
                <div class="pageResultByCuisineMainRightRefine">
                    Refine your result
                </div>
                <div class="refine_result">
                    <img src="/Media/Images/arrow.jpg" width="11" height="11" />
                    By Neighbourhood</div>
                <asp:Repeater ID="rptNeighborhood" runat="server">
                    <ItemTemplate>
                        <div class="refine_result" style="padding-left: 40px;">
                            <a href='<%# "Default.aspx?pid=ListRestaurant&cityId=" + Request.QueryString["cityId"]+ "&cuisineId=" + Request.QueryString["cuisineId"]+ "&neighborhoodId="+ Eval("ID")  %>'>
                                <%# Eval("Name")%>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="refine_result">
                    <img src="/Media/Images/arrow1.jpg" width="10" height="10" /><asp:HyperLink ID="lnkMoreNeighborhood"
                        runat="server" Text="More Neighborhood"></asp:HyperLink></div>
            </div>
            <!--end main right-->
        </div>
        <!--main-->
    </div>
    <!--center-->
    <!-- footer -->
    <div id="pageRestaurantByCuisineFooter">
    </div>
    <!-- footer -->
</div>
<br />
