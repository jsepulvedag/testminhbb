<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Header.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Common.Header" %>
<%@ Register Src="../Restaurant/RestaurantDetail .ascx" TagName="RestaurantDetail "
    TagPrefix="uc1" %>
<%@ Register Src="../Restaurant/WokingHour .ascx" TagName="WokingHour " TagPrefix="uc2" %>



<center>
  <table style="width: 869px; height: 133px;"  >
    <tr>
        <td colspan="2" style="height: 20px; width: 287px;" align="right">
        </td>
        <td style=" height: 20px;text-align:right;" align="right" >
        <table style="width: 100%" >
            <tr align="right">
            <td style="height: 26px; width: 1094px;" align="right" valign="bottom" ><asp:HyperLink ID="lnkBtnHome" runat="server" ForeColor="black">Home |</asp:HyperLink></td>
            <td style="height: 26px; width: 75px;" align="right" valign="bottom"><asp:HyperLink ID="lnkBtnSignIN" runat="server" ForeColor="black">Login |</asp:HyperLink></td>
            <td style="height: 26px; width: 123px;" align="left" valign="bottom"><asp:Label ID="lblHi" runat="server" Width="120px"></asp:Label>
                <asp:HyperLink ID="lnkBtnCreateAccount" runat="server" ForeColor="Black" Width="108px">Create Account |</asp:HyperLink></td>
            <td style="height: 26px" align="right" valign="bottom"><asp:HyperLink ID="lnkBtnHelp" runat="server" ForeColor="black">Help</asp:HyperLink></td>
            </tr>
        </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" style=" height: 120px; width: 287px;">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Media/Delivery/logo.gif" />
        </td>
        <td style=" height: 120px" align="right">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Media/Delivery/vocation.jpg" ImageAlign="Right" />
        </td>
    </tr>
</table>
<div id="headerSearch"  >
        &nbsp;<table style="width: 869px;color:Black; "cellpadding="0" cellspacing="0"  >
			    <tr>
                    <td style="width: 10px">
                    </td>
			        <td style=" width: 232px;"></td>
			        <td style="width: 11px; "></td>
			        <td style="width: 155px" ><asp:Image ImageUrl="~/Media/Images/find.jpg" ID="imgAddress" runat="server" Visible="false"/></td>
			        <td><asp:Image ImageUrl="~/Media/Images/deliveryIconDisable.jpg" ID="imgZipcode" runat="server" Visible="false"/></td>
			    </tr>
			    <tr >
                    <td style="background: url(../../../Media/Delivery/search_r1_c2.jpg);background-repeat:no-repeat; width: 10px; height: 42px;">
                    </td>
			        <td style="background:url(../../../Media/Delivery/search_r1_c3.jpg); width: 232px; height: 42px;"></td>
			        <td  style="background:url(../../../Media/Delivery/search_r1_c3.jpg); height: 42px;">
                        <strong>
                        Address:</strong></td>
			        <td  style="background:url(../../../Media/Delivery/search_r1_c3.jpg); width: 155px; height: 42px;">
                        <asp:TextBox ID="txtAddress" runat="server" Visible="false"/>
                        <asp:Label ID="lbAddress" runat="server" Width="151px" /></td>
			        <td  style="background:url(../../../Media/Delivery/search_r1_c3.jpg); height: 42px;">
                        <asp:TextBox ID="txtZipCode" runat="server" Visible="false" Width="81px"/>
                        <asp:Label ID="lbZipCode" runat="server" Width="1px"/></td>
			        <td  style="background:url(../../../Media/Delivery/search_r1_c3.jpg); height: 42px;"><asp:ImageButton ImageUrl="~/Media/Images/btnNext.png" ID="imgNext" runat="server" Visible="true" CommandName="Next" OnClick="imgNext_Click1"  />
                        <asp:ImageButton ImageUrl="~/Media/Images/btnPrevious.png" ID="imgPrevious" runat="server" Visible="false" CommandName="Previous" OnClick="imgPrevious_Click1" /></td>
			        <td  style="background:url(../../../Media/Delivery/search_r1_c3.jpg); height: 42px;">
                        <strong>Search:</strong></td>
			        <td  style="background:url(../../../Media/Delivery/search_r1_c3.jpg); height: 42px; width: 155px;"><asp:TextBox ID="txtKeyword" runat="server" Text="Keyword"/></td>
			        <td  style="background:url(../../../Media/Delivery/search_r1_c3.jpg); height: 42px; width: 77px;"><asp:ImageButton ImageUrl="~/Media/Images/gift_r7_c8.jpg" ID="imgSearch" runat="server" Visible="true" OnClick="imgSearch_Click1" /></td>
			        <td style="background: url(../../../Media/Delivery/search_r1_c5.jpg);background-repeat:no-repeat; width: 11px;"></td>
			    </tr>
			</table>
		</div>
</center>
