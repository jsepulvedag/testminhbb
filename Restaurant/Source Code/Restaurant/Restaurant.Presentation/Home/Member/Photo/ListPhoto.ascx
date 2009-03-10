<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ListPhoto.ascx.cs" Inherits="Restaurant.Presentation.Home.Member.Photo.ListPhoto" %>
<%@ Register Src="../../../Delivery/UserControls/Common/Footer.ascx" TagName="Footer"
    TagPrefix="uc4" %>
<%@ Register Src="../../../Delivery/UserControls/Common/Header.ascx" TagName="Header"
    TagPrefix="uc5" %>
<%@ Register Src="../../UserControls/ListReviewLeft.ascx" TagName="ListReviewLeft"
    TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/ListReviewRight.ascx" TagName="ListReviewRight"
    TagPrefix="uc3" %>
<%@ Register Src="../../Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail"
    TagPrefix="uc1" %>
&nbsp;<div style="margin: 0 auto; width: 869px; height: auto;">
    <div class="pageRestaurantByCuisineCenter">
        <div style="width: 869px; float: left;">
            <uc1:RestaurantDetail ID="RestaurantDetail2" runat="server" />
        </div>
        <div style="width: 869px; float: left;">
            <table style="width: 98%">
                <tr>
                    <td rowspan="2" style="width: 174px" valign="top">
                        <uc2:ListReviewLeft ID="left" runat="server" />
                    </td>
                    <td style="width: auto" valign="top">
                        <asp:Panel runat="server" ID="pnNoImage" Visible="false">
                                <table style="width: 460px; height: auto;" border="0">
                                    <tr>
                                        <td valign="top">
                                            <strong>
                                                <h2>
                                                    <asp:Label runat="server" ID="lbNOImage" Text="No image in restaurant!" /></h2>
                                            </strong>
                                            <br />
                                            Do you want to add photo? <strong>
                                                <h2>
                                                    <asp:LinkButton runat="server" ID="lbAddImage" OnClick="lbAddImage_Click" Text="Add Photo" /></h2>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                    </td>
                    <td rowspan="2" style="width: 181px" valign="top">
                        <uc3:ListReviewRight ID="right" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: auto;" valign="top">
                        <asp:Panel runat="server" ID="pnlist" Visible="true">
                                <table style="background-color: #414141; width: 95.7%; " border="0" cellpadding="0"
                                    cellspacing="0">
                                    <tr>
                                        <td align="left" style="color: #FF0000; padding-left: 10px; padding-right:30px; ">
                                            <asp:Image ID="imgr3c3" runat="server" ImageUrl="~/Media/Images/restaurant_photos_r3_c3.jpg" />
                                            <asp:Label ID="lbPhotos" runat="server" Text="Photos" Font-Size="XX-Large" ForeColor="red" />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 50px;  padding-bottom: 40px; padding-left: 10px; font-size: medium;">
                                            <asp:Label runat="server" ID="lbPhoto" />
                                            Photos Available
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #414141;">
                                            <table>
                                                <tr>
                                                    <td style="width: 20px;" valign="top">
                                                        &nbsp;</td>
                                                    <td style="width: auto; background-image: url(../../Media/Images/restaurantByCuisineBg.jpg);">
                                                        <p style="text-align: center; font-size: 14px;">
                                                            <asp:Image ID="imgDetail" runat="server" Width="99%" /><!--450-->
                                                            <br />
                                                            <br />
                                                        </p>
                                                        &nbsp;<asp:Label runat="server" ID="lbPhotoName" />
                                                        <asp:Label ID="lbPhotoID" runat="server" Visible="false" />
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td style="width: 20px;" valign="top">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #414141;">
                                        <td>
                                            <p style="text-align: center;">
                                                <asp:ImageButton ID="imgPreview" runat="server" ImageUrl="~/Media/Images/3.png" OnCommand="imgPreview_Command" />
                                                <asp:Label ID="lbCountPhoto" runat="server" Text="" />
                                                <asp:ImageButton ID="imgNext" runat="server" ImageUrl="~/Media/Images/1.png" OnCommand="imgNext_Command"
                                                    ToolTip="Next" /></p>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #414141; width: auto; padding-left: 50px;">
                                        <td align="left" style="background-color: #414141; padding-left: 20px; padding-top: 50px;
                                            padding-bottom: 15px; font-size: 13px;">
                                            Click on a thumbnail to see larger
                                        </td>
                                    </tr>
                                    <tr style="background-color: #414141; padding-top: 50px;">
                                        <%--padding-left: 50px;padding-right: 50px--%>
                                        <asp:DataList ID="dtlListPhoto" runat="server" OnItemCommand="dtlListPhoto_ItemCommand"
                                            RepeatColumns="4" BackColor=" #414141">
                                            <ItemTemplate>
                                                <td style="padding-left: 10px; padding-right: 26px; padding-bottom: 30px; background-color: #414141">
                                                    <asp:ImageButton runat="server" ID="ibtListPhoto" ImageUrl='<%#Eval("Image") %>'
                                                        CommandArgument='<%#Eval("ID") %>' CommandName="listPhoto" Width="80px" Height="80px" />
                                                </td>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        </tr>
                                </table>
                            </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div id="pageRestaurantByCuisineFooter">
        </div>
    </div>
</div>
