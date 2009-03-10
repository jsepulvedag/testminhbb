<%@ Control Language="C#" AutoEventWireup="true" Codebehind="RestaurantDetail.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Restaurant.RestaurantDetail.RestaurantDetail" %>
<%@ Register Src="../../../Delivery/UserControls/Common/Footer.ascx" TagName="Footer"
    TagPrefix="uc2" %>
<%@ Register Src="../../../Delivery/UserControls/Common/Header.ascx" TagName="Header"
    TagPrefix="uc3" %>
<%@ Register Src="../UserControls/TabBar.ascx" TagName="TabBar" TagPrefix="uc1" %>
<div id="formConntent">
    <div class="formContentCenter" style ="padding-left:20px;width:849px;">
        <table>
            <asp:DataList ID="dlRestaurantDetail" runat="server" OnItemDataBound="dlRestaurantDetail_ItemDataBound"
                BorderColor="Brown">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td colspan="5" style="width: 700px;text-align:right;color:#FF0000;padding-top:20px;">
                        <table width="100%">
                        <tr>
                        <td style="width: 500px;font-size:40px;">
                                    <%#Eval("Name") %>
                            </td>
                        <td style="width: 100px;">
                        <asp:Image ID="imgPrint" runat="server" ImageUrl="~/Media/Images/printIcon.jpg" />
                        <asp:LinkButton ID="lbPrint" runat="server" Text="Print" />
                        </td>
                        <td style="width: 100px;">
                        <asp:Image ID="imgHelp" runat="server" ImageUrl="~/Media/Images/helpIcon.jpg" />
                        <asp:LinkButton ID="lbHelp" runat="server" Text="Help" />
                        </td>
                        </tr>
                        </table>
                            <br />
                        </td>
                    </tr>
                    <tr style="height:20px;">
                        
                        <td  style="width: 300px;font-size:12px;" colspan="2">
                            <%#Eval("Name") %>.<%#Eval("Address")%></td>
                        <td  rowspan="4" align="center" style="width: 10px;">
                            <asp:Image runat="server" ID="img" ImageUrl="~/Media/Images/rate.jpg" Height="60"
                                Width="1px" />
                        </td>
                        <td  rowspan="2" style="width: 100px;font-size:12px;">
                            Cuisine:</td>
                        <td  rowspan="2" style="width: 250px;font-size:12px;">
                            <asp:DataList ID="dtlCuisine" runat="server">
                                <ItemTemplate>
                                      <%#Eval("CuisineName")%>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr style="height:20px;">
                        <td style="width: 60px;font-size:12px;">
                            Phone:</td>
                        <td style="font-size:12px;">
                           <%#Eval("PhoneContact") %></td>
                    </tr>
                    <tr style="height:20px;">
                        <td style="font-size:12px;">
                            Fax:</td>
                        <td style="font-size:15px;">
                            <%#Eval("FaxContact") %></td>
                        <td rowspan="2" align="right" style="font-size:12px;">
                            Neighbourhood:</td>
                        <td rowspan="2" style="font-size:12px;">
                            <asp:DataList ID="dtlNeighbourhood" runat="server">
                            <ItemTemplate>
                                    <%#Eval("NeighbourhoodName")%>
                            </ItemTemplate>
                        </asp:DataList>
                        </td>
                    </tr>
                    <tr style="height:20px;">
                        <td style="font-size:12px;">
                            Website:</td>
                        <td style="font-size:12px;">
                            <%#Eval("Website") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:DataList></table>
    </div>
</div>
<uc1:TabBar ID="TabBar1" runat="server" />
&nbsp;
