<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DeliverySearch.ascx.cs"
    Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.DeliverySearch" %>
<div>
    <div style="margin-left: 7px;">
        <div class="homeSearch_right_header_sponsor" style="padding-left: 10px; font-size: 17px;">
            Search Results
            <hr size="1" style="border: thin 1px #CCCCCC;" />
        </div>
        <div class="homeSearch_right_center_sponsor">
            Your search for Restaurants has returned the following <b>
                <asp:Literal ID="ltResult" runat="server"></asp:Literal></b> results.
        </div>
        <div class="homeSearch_right_footer_sponsor">
        </div>
    </div>
    <div class="homeSearch_right">
        <div class="homeSearch_right_header">
            BROWSE RESTAURANT
            <hr size="1" style="border: thin 1px #CCCCCC" />
        </div>
        <div class="homeSearch_right_center">
            <!--Page Index-->
            <asp:DataGrid ID="dgPage" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                ShowHeader="false" BorderWidth="0" GridLines="none" AllowCustomPaging="True"
                OnPageIndexChanged="dgPage_PageIndexChanged" Font-Bold="True" Font-Size="13px">
                <PagerStyle Mode="NumericPages" />
                <Columns>
                    <asp:TemplateColumn></asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </div>
        <div class="homeSearch_right_center">
            <div>
                <table cellpadding="0" cellspacing="0" border="1" width="99%" style="border-collapse: collapse;
                    border-color: #414141; background-color: White; padding-left: 7px; margin-left: 4px;">
                    <%--#3d393a--%>
                    <tr>
                        <td style="text-align: right; font-size:13px;">
                            <asp:DropDownList ID="ddlPerpage" Width="45px" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlPerpage_SelectedIndexChanged">
                                <asp:ListItem Value="5" Selected="True">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                            </asp:DropDownList>&nbsp;&nbsp;Record Per Page&nbsp;&nbsp;
                        </td>
                    </tr>
                    <asp:Repeater ID="rptRestaurant" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr style="height: 30px;">
                                            <td style="width: 20px;">
                                                &nbsp;</td>
                                            <td style="width: 200px; color: #336699;" align="center">
                                                Restaurant Name
                                            </td>
                                            <td style="width: 100px; color: #336699;" align="left">
                                                &nbsp;Neighbourhood</td>
                                            <td style="width: 80px; color: #336699;" align="left">
                                                &nbsp;Cuisine</td>
                                            <td style="width: 100px; color: #336699;" align="left">
                                                &nbsp;Delivery</td>
                                            <td style="width: 100px; color: #336699;" align="left">
                                                &nbsp;Rating</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td align="center" style="width: 70px;">
                                                <asp:Image ID="imgPhoto" Width="70px" Visible="true" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                            </td>
                                            <td style="width: 200px; font-size: 12px; color: #336699;">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr style="height:20px;" >
                                                        <td>
                                                            <a class="colorA" href='Default.aspx?did=Restaurant&restaurantID=<%#Eval("ID") %>'>
                                                                <%#Eval("Name") %>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                  <tr style="height:20px;" >
                                                        <td>
                                                            &nbsp;<%#Eval("Address") %>
                                                        </td>
                                                    </tr>
                                                    <tr style="height:20px;" >
                                                        <td>
                                                            &nbsp;<%#Eval("CityName") %>
                                                            ,
                                                            <%#Eval("StateName") %>
                                                        </td>
                                                    </tr>
                                                   <tr style="height:20px;" >
                                                        <td>
                                                            &nbsp;Phone:&nbsp; &nbsp;<%#Eval("Phone1") %>
                                                        </td>
                                                    </tr>
                                                  <tr style="height:20px;" >
                                                        <td>
                                                            &nbsp;Zipcode:&nbsp; &nbsp;<%#Eval("Zipcode") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 100px;">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="font-size: 14px; text-align: left;">
                                                            <%# Eval("Neighbourhood") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 80px;">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="font-size: 14px; text-align: left;">
                                                            <%# Eval("Cuisine")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 100px;">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="font-size: 14px; text-align: left;">
                                                            Fee&nbsp;$<%# Eval("Fee")%><br />
                                                            Minimum&nbsp;$<%# Eval("MinimumPrice")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 100px; font-size: 14px; padding-left: 10px;">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="width: 50px;">
                                                            Score
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <asp:Image ID="imgScore" runat="server" ImageUrl='<%# "~/Media/Delivery/"+ Eval("Score") +"Star.jpg" %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Food
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <asp:Image ID="imgFood" runat="server" ImageUrl='<%# "~/Media/Delivery/"+ Eval("FoodPoint") +"Star.jpg" %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Price
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <asp:Image ID="imgPrice" runat="server" ImageUrl='<%# "~/Media/Delivery/"+ Eval("PricePoint") +"Star.jpg" %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Service
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <asp:Image ID="imgService" runat="server" ImageUrl='<%# "~/Media/Delivery/"+ Eval("ServicePoint") +"Star.jpg" %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Decor
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <asp:Image ID="imgDecore" runat="server" ImageUrl='<%# "~/Media/Delivery/"+ Eval("DecorPoint") +"Star.jpg" %>' />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <asp:DataList ID="dtlRestaurant" runat="server">
                    <HeaderTemplate>
                        <table id="Table1" class="pageResultByCuisineMainTable" runat="server" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <td style="width: 80px;">
                                </td>
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
                                <td style="width: 80px;">
                                </td>
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
                            </tr>
                            <tr>
                                <td style="width: 100px;" rowspan="4">
                                    <asp:Image ID="imgPhoto" Width="100px" Visible="true" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                </td>
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
                        </table>
                        <div class="hr">
                            <hr size="1" style="border: solid 1px #414141" />
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="homeSearch_right_footer">
            &nbsp;</div>
    </div>
</div>
