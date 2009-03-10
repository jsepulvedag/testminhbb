<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Restaurant.ascx.cs" Inherits="Restaurant.Presentation.Delivery.UserControls.Restaurant.Restaurant" %>
<%@ Register Src="MyOrder.ascx" TagName="MyOrder" TagPrefix="uc4" %>
<%@ Register Src="~/Delivery/UserControls/Restaurant/RestaurantDetail .ascx" TagName="RestaurantDetail" TagPrefix="uc1" %>
<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<%@ Register Src="~/Delivery/UserControls/Restaurant/WokingHour .ascx" TagName="WokingHour" TagPrefix="uc3" %>



<%--<div >
 <table style="margin-left:265px;" border="1">
  <tr valign="top" >
    <td rowspan="2" style="margin-left:200px; " valign="top">
        <uc2:Menu ID="Menu1" runat="server" />
    </td>
    <td valign="top" align="left" style="margin-top:10px; width: 179px;">
        <uc1:RestaurantDetail id="RestaurantDetail1" runat="server"></uc1:RestaurantDetail>
    </td>
      <td align="left" rowspan="2" style="margin-top: 10px; width: 179px" valign="top">
          <uc4:MyOrder ID="MyOrder1" runat="server" />
      </td>
  </tr>
  <tr valign="top">
    <td valign="top" style="width: 179px">
        <uc3:WokingHour id="WokingHour1" runat="server"></uc3:WokingHour>
     </td>
  </tr>
</table></div>--%>
<table style="width: 100%">
    <tr>
        <td style="width: 200px" rowspan="2" valign="top">
            <uc2:Menu ID="menu" runat="server" />
        </td>
        <td style="width: 100px" valign="top">
        <uc1:RestaurantDetail ID="resDetail" runat="server" />
        </td>
        <td style="width: 200px" rowspan="2" valign="top">
            <uc4:MyOrder ID="myOrder" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 100px" valign="top">
            <uc3:WokingHour  ID="working" runat="server" />
        </td>
    </tr>
</table>
