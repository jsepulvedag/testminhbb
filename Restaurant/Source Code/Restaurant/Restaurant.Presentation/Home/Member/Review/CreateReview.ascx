<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CreateReview.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Member.Review.CreateReview" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="ReviewLeft" TagPrefix="uc1" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="ReviewRight"
    TagPrefix="uc2" %>
<%@ Register Src="~/Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail"
    TagPrefix="uc3" %>

<script language="javascript" type="text/javascript">
  
function setTextAreaLength(Object, MaxLength)
{
    return (Object.value.length <= MaxLength);
}
//<%=txtYourReview.ClientID%>
function count(Object)
{
    return document.getElementById('label1') = Object.value.length;
}
</script>

<div style="margin: 0 auto; width: 869px; height: auto;">
    <div id="pageRestaurantByCuisineHeader">
    </div>
    <div class="pageRestaurantByCuisineCenter">
        <div style="width: 660px; float: left;">
            <uc3:RestaurantDetail ID="RestaurantDetail2" runat="server" />
        </div>
        <div class="ResultRate" style="padding-left: 26px; width: 181px; text-align: center;">
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
            <table style="width: 869px; margin: 0 auto;">
                <tr>
                    <td style="width: 174px;" valign="top">
                        <div>
                            <uc1:ReviewLeft ID="RestaurantReviewLeft" runat="server"></uc1:ReviewLeft>
                        </div>
                    </td>
                    <td style="width: auto; text-align: left;" valign="top" align="left">
                        <div>
                            <div>
                                <asp:Label ID="lblReviewCount" runat="server" Width="100%" Font-Bold="False" Font-Size="18px"></asp:Label><br />
                                <asp:Label ID="lblRestaurantName" runat="server" Width="100%" Font-Bold="False" Font-Size="18px"></asp:Label><br />
                                <br />
                            </div>
                            <div style="background-color: #414141;">
                                <table style="width: 100%">
                                    <tr style="height: 25px;">
                                        <td style="width: 150px">
                                            Meal Type :</td>
                                        <td style="width: 321px">
                                            <asp:RadioButton ID="rdoBreakFirst" runat="server" Text="BreakFast" GroupName="MealType" />&nbsp;
                                            <asp:RadioButton ID="rdoLunch" runat="server" Text="Lunch" GroupName="MealType" />&nbsp;
                                            <asp:RadioButton ID="rdoDinner" runat="server" Text="Dinner" GroupName="MealType" />&nbsp;
                                            <asp:RadioButton ID="rdoOther" runat="server" Text="Other" GroupName="MealType" Checked="True" /></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td style="width: 150px">
                                            Display Name :</td>
                                        <td style="width: 321px">
                                            <asp:TextBox ID="txtDisplayName" runat="server" Width="295px"></asp:TextBox><span
                                                style="color: #ff0000"><strong>(*)</strong></span></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td colspan="2">
                                            Rate Your Experience :</td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td style="width: 150px">
                                            Food :</td>
                                        <td style="width: 321px">
                                            <asp:DropDownList ID="dropFood" runat="server" Width="100px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td style="width: 150px">
                                            Service :</td>
                                        <td style="width: 321px">
                                            <asp:DropDownList ID="dropService" runat="server" Width="100px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td style="width: 150px">
                                            Price :</td>
                                        <td style="width: 321px">
                                            <asp:DropDownList ID="dropPrice" runat="server" Width="100px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr style="height: 25px">
                                        <td style="width: 150px">
                                            Decor:</td>
                                        <td style="width: 321px">
                                            <asp:DropDownList ID="dropDecor" runat="server" Width="100px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td style="width: 150px; height: 25px;">
                                            Visit Again ?</td>
                                        <td style="width: 321px; height: 25px;">
                                            <asp:RadioButton ID="rdoVisitYes" runat="server" Text="Yes" GroupName="VisitAgain" />&nbsp;
                                            <asp:RadioButton ID="rdoVisitMaybe" runat="server" Text="Maybe" GroupName="VisitAgain"
                                                Checked="True" />&nbsp;
                                            <asp:RadioButton ID="rdoVisitNever" runat="server" Text="Never" GroupName="VisitAgain" /></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td style="width: 150px">
                                            Party Size :</td>
                                        <td style="width: 321px">
                                            <asp:DropDownList ID="dropPartySize" runat="server" Width="130px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td style="width: 150px">
                                            Price Range :</td>
                                        <td style="width: 321px">
                                            <asp:DropDownList ID="dropPriceRange" runat="server" Width="130px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td colspan="2">
                                            <strong>What did you order?</strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtYourOrder" Width="450px" Height="30px" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td colspan="2">
                                            Let us know what your table ordered: The appetizers, entrees, dishes, drinks,<br />
                                            etc. Separate them with a comma, and feel free to include brand names and
                                            <br />
                                            ingredients if you wish.<br />
                                        </td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td colspan="2" style="height: 19px">
                                            <strong>Your Review : &nbsp;&nbsp;
                                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></strong></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtYourReview" Width="450px" Height="200px" runat="server" TextMode="MultiLine"
                                                MaxLength="10" ></asp:TextBox></td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td colspan="2" style="height: 19px">
                                            Share as much detail as you can about your dining experience. Please review<br />
                                            responsibly.</td>
                                    </tr>
                                    <tr style="height: 25px;">
                                        <td colspan="2" style="height: 19px; text-align: center;">
                                            <asp:ImageButton ID="imgButSubmit" runat="server" ImageUrl="~/Media/Images/reviewimg_r6_c3.jpg"
                                                OnClick="imgButSubmit_Click" />&nbsp
                                            <asp:ImageButton ID="imgButReset" runat="server" ImageUrl="~/Media/Images/reviewimg_r6_c5.jpg"
                                                OnClick="imgButReset_Click" /></td>
                                    </tr>
                                    <tr style="height: 25px">
                                        <td colspan="2" style="height: 19px; text-align: center">
                                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="14px"
                                                ForeColor="Red" Visible="False" Width="100%"></asp:Label></td>
                                    </tr>
                                    <tr style="height: 25px">
                                        <td colspan="2" style="height: 19px; text-align: center">
                                            <asp:HyperLink ID="hplResponseURL" runat="server" Font-Italic="True" Visible="False"
                                                Width="100%">HyperLink</asp:HyperLink></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td style="width: 191px" valign="top">
                        <div style="width: 191px; text-align: center;">
                            <uc2:ReviewRight ID="ReviewRight" runat="server"></uc2:ReviewRight>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>
