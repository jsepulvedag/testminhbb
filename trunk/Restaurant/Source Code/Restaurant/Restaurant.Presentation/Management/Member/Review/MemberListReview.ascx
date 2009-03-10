<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MemberListReview.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Member.Review.MemberListReview" %>

    <div>
        <table width="98%"  style="margin:0 auto; padding-left:5px; padding-right:0px;">
            <tr>
                <td style="font-size: 17px; font-weight: bold; padding-left:13px;padding-top:5px;">
                    <asp:Label ID="lblReview" runat="server" Text="List Review"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:100%; padding-left: 30px; background-color: #414141">
                    <asp:DataList ID="dtlMemberListReview" runat="server" Width="100%" OnItemDataBound="dtlMemberListReview_ItemDataBound">
                        <ItemTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Title" Font-Bold="True" ForeColor="Yellow" Font-Size="17px" runat="server"
                                            Text='<%# Eval("Title") %>' Width="45%"></asp:Label>
                                        <strong><span style="font-size: 14px">Status:</span> </strong>
                                        <asp:Label Font-Italic="true" Font-Size="15px" ID="lblActive" runat="server" Text='<%# Eval("Active") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        Restaurant Name</td>
                                    <td style="width: auto">
                                        <%--<asp:Label ID="lblRestaurantName" runat="server" Text='<%# Eval("RestaurantName") %>'></asp:Label>--%>
                                        <asp:HyperLink ID="hplRestaurantName" Font-Bold="true" runat="server" Text='<%# Eval("RestaurantName") %>'></asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        Create On:</td>
                                    <td style="width: auto">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("CreateReview")%>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr size="1" style="border: 1px solid rgb(0, 255, 255); width: 350px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        Member Count:</td>
                                    <td style="width: auto">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("PartySize")%>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        Price for meal</td>
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
                                        <asp:Label ID="lblDecor" runat="server" Text='<%# Eval("Decor") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        Visit again?</td>
                                    <td style="width: auto">
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("VisitAgain")%>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr size="1" style="border: 1px #FFFFFF; width: 350px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; font-size: 13px; font-weight: bold;">
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
                                        <hr size="1" style="border: 1px; border-bottom-color: White; width: 350px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-size: 13px; font-weight: bold;">
                                        Review</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("Description")%>' Width="100%"></asp:Label></td>
                                    <br />
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr align="right">
                <td style="width: 100%; float: right; text-align: right;" align="right">
                    <asp:Label ID="lblPage" runat="server" Text="Page :" Visible="False"></asp:Label>&nbsp;
                    <asp:DropDownList ID="dropPage" runat="server" Width="60px" OnSelectedIndexChanged="dropPage_SelectedIndexChanged"
                        Visible="False">
                    </asp:DropDownList></td>
            </tr>
        </table>
    </div>
