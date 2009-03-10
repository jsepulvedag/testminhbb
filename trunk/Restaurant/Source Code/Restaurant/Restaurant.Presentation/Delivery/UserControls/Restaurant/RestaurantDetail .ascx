<%@ Control Language="C#" AutoEventWireup="true" Codebehind="RestaurantDetail .ascx.cs"
    Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.RestaurantDetail" %>


    
                <table style="color: Black; width: 269px;">
                    <asp:DataList ID="dtlRestaurantDetail" runat="server" OnItemDataBound="dtlRestaurantDetail_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td style="height: 127px; width: 289px;">
                                    <table width="100%" style="color: Black;">
                                        <tr>
                                            <td rowspan="5" style="width: 100px" align="left" valign="top">
                                                <asp:Image ID="imgRestaunrant" runat="server" ImageUrl='<%#Eval("Image") %>' Width="100px" />
                                            </td>
                                            <td style="padding-bottom: 5px; height: 28px;" valign="bottom">
                                                <asp:HyperLink ID="hplName" runat="server" Text='<%#Eval("Name") %>' Font-Bold="true"
                                                    Font-Underline="true" ForeColor="red" Font-Size="X-Large" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("Address") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("Country") %>
                                                ,
                                                <%#Eval("State") %>
                                                &nbsp;
                                                <%#Eval("ZipCode") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="height: 127px; width: 112px;" valign="top">
                                    <table style="color: Black;">
                                        <tr>
                                            <td>
                                                Food: <span style="color: Red;">
                                                    <asp:Label ID="lbFood" runat="server" /></span></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Service: <span style="color: Red;">
                                                    <asp:Label ID="lbService" runat="server" /></span></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Price: <span style="color: Red;">
                                                    <asp:Label ID="lbPrice" runat="server" /></span></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                                Decor: <span style="color: Red;">
                                                    <asp:Label ID="lbDecor" runat="server" /></span></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:DataList></table>
        

