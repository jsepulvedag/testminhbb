<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MenuItem.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.Menu.MenuItem" %>
<%@ Register Src="~/Home/Restaurant/UserControls/TabBar.ascx" TagName="TabBar" TagPrefix="uc1" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="Left" TagPrefix="uc2" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="Right" TagPrefix="uc3" %>
<%@ Register Src="~/Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail"
    TagPrefix="uc4" %>
<script language="javascript" type="text/javascript">
function SetUniqueRadioButton(nameregex, current)
{
   re = new RegExp(nameregex);
   for(i = 0; i < document.forms[0].elements.length; i++)
   {
      elm = document.forms[0].elements[i];
      if (elm.type == 'radio')
      {
         if (re.test(elm.name))
         {
            elm.checked = false;
         }
      }
   }
   current.checked = true;
}

</script>
    
<div id="pageRestaurantByCuisine" style="margin:0 auto;">
    <div id="pageRestaurantByCuisineHeader">
    </div>
    <div class="pageRestaurantByCuisineCenter" style="margin: 0 auto; width: 869px; height: auto;">
    <div style="width: 869px; float: left;">
        <uc4:RestaurantDetail runat="server" ID="resDetail"></uc4:RestaurantDetail>
    </div>
    <div style="width: 869px; float: left;">
        <table width="100%">
            <tr>
                <td style="width: 174px" align="center" valign="top">
                    <uc2:Left ID="ucLeft" runat="server"></uc2:Left>
                </td>
                <td style="width: 504px" align="left" valign="top">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: auto; height: 19px;">
                                <asp:Label ID="lblmnItemName" Font-Size="15px" Text="" runat="server" Visible="true"></asp:Label></td>
                            <td rowspan="2" style="width: 200px">
                                <asp:Image ID="imgItem" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: auto;">
                                <asp:Label ID="lblmnItemDescription" Font-Size="15px" Text="" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" rowspan="1">
                            <br />
                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        <table width="100%" style="background-color:#414141;">
                                            <tr>
                                                <td>
                                                    <asp:Image ID="idimg" ImageUrl="~/Media/Images/arrow.jpg" runat="server" />
                                                    <asp:Label ID="lblAddonGroupName" Text='<%# Eval("Name") %>' runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 30px;">
                                                    <asp:RadioButtonList ID="rdoListAddon" runat="server" TextAlign="Right">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnOrder" runat="server" Font-Bold="True" OnClick="btnOrder_Click"
                        Text="Order" /></td>
                <td style="width: 181px" align="center" valign="top">
                    <uc3:Right ID="Right" runat="server"></uc3:Right>
                </td>
            </tr>
        </table>
    </div>
    </div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>