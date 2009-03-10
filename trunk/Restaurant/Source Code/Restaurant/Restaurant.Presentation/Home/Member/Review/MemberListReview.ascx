<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberListReview.ascx.cs" Inherits="Restaurant.Presentation.Home.Member.Review.MemberListReview" %>
<table>
    <tr><td style="font-size:17px; font-weight:bold; ">
        List Review</td></tr>
    <tr>
        <td style="width: 100%">
            <asp:DataList ID="dtlMemberListReview" runat="server" Width="100%" >
            <ItemTemplate>
                <span style="color: #ff3300">
                </span>
                <table style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Title" Font-Bold="true" Font-Size="17px" runat="server" Text='<%#Eval("Title") %>' Width="100%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">Create On:</td>                
                        <td style="width: auto">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("CreateReview")%>'></asp:Label></td>
                    </tr>
                    <tr><td colspan="2">
	                    <asp:Image ID = "image1" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" Width="100%" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Member Count:</td>
                        <td style="width: auto">
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("PartySize")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Year old</td>
                        <td style="width: auto">
                            <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Price for meal:
                        </td>
                        <td style="width: auto">
                <asp:Label ID="lblPriceRage" runat="server" Text='<%#Eval("PriceRange")%>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                Food:</td>
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
        
        </asp:DataList>
        </td>
    </tr>
    <tr>
        <td style="width: 100%" align="right">
            Page :&nbsp;
            <asp:DropDownList ID="dropPage" runat="server" Width="60px" OnSelectedIndexChanged="dropPage_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
</table>
