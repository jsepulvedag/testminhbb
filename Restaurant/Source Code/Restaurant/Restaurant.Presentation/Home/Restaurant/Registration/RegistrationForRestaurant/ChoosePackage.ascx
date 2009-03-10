<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ChoosePackage.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant.ChoosePackage" %>
<%@ Register Assembly="RadWindow.Net2" Namespace="Telerik.WebControls" TagPrefix="radW" %>

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

<div style="margin: 0 auto; width: 869px; height: auto; background-repeat:repeat-x;">
    <div class="formConntentHeader" style="text-align: left; padding-top: 7px;
        padding-left: 13px; font-size: 18px; vertical-align: middle; width:869px;">
            STEP 1/4 - Subscription Plan Selection
    </div>
    <div class="formContentCenter" style="padding-top:5px;">
        <center>
            <asp:DataList ID="dlPackage" runat="server" OnItemDataBound="dlPackage_ItemDataBound">
                <HeaderTemplate>
                    <table style="width: 869px; height: auto; border: 1px;">
                        <tr>
                            <td style="width: 195px; height: auto; text-align: left; font-size: larger;padding-left:5px;">
                                Package</td>
                            <td style="width: 419px; height: auto; text-align: left; font-size: larger;">
                                Description</td>
                            <td style="width: 250px; height: auto; text-align: left; font-size: larger;">
                                Subscription plan</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr style="color: White; border: 1px; width: 99%; margin: 0 auto;" />
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width: 170px; height: auto; text-align: left; color: White;padding-left:5px;">
                            <asp:Label runat="server" ID="lblPackageID" Text='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                Visible="false"></asp:Label>
                            <%#DataBinder.Eval(Container.DataItem,"Name")%>
                        </td>
                        <td style="width: 379px; height: auto; text-align: left; color: White;">
                            <%#DataBinder.Eval(Container.DataItem,"Description")%>
                        </td>
                        <td style="width: 250px; height: auto; text-align: left;">
                            <asp:Repeater runat="server" ID="rptPackageDetail">
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td style="width: 110px; height: auto; text-align: left; font-weight: bolder;">
                                                Plan expiry</td>
                                            <td style="width: 90px; height: auto; text-align: left; font-weight: bolder;">
                                                Price</td>
                                            <td style="width: 50px; height: auto; text-align: center; font-weight: bolder;">
                                                Select</td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 90px; height: auto; text-align: left;">
                                            <asp:Label runat="server" ID="lblPackageDetailID" Text='<%#DataBinder.Eval(Container.DataItem,"ID") %>'
                                                Visible="false"></asp:Label><%#DataBinder.Eval(Container.DataItem,"ExpiryMonth")%>
                                            months</td>
                                        <td style="width: 70px; height: auto; text-align: left">
                                            <%#DataBinder.Eval(Container.DataItem,"Price")%>
                                            USD</td>
                                        <td style="width: 40px; height: auto; text-align: center;">
                                            <asp:RadioButton runat="server" ID="rdSelected" GroupName="rdSelected" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr style="color: White; border: 1px; width: 99%; margin: 0 auto;" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
            <table style="width: 869px; height: auto; border: 0px;">
                <tr>
                    <td style="text-align: right; width: 50%;">
                        <asp:Button ID="btnContinue" runat="server" Text="Next" Font-Bold="False"
                            Width="140px" CssClass="Button" OnClick="btnContinue_Click" />&nbsp;</td>
                    <td>
                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Back to Restaurant" Font-Bold="False"
                            Width="140px" CssClass="Button" OnClick="btnCancel_Click" Visible="true" /></td>
                </tr>
            </table>
        </center>
    </div>
    <div id="pageRestaurantByCuisineFooter"></div>
</div>
