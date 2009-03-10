<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChoosePackage.ascx.cs" Inherits="Restaurant.Presentation.Administrator.RestaurantPackage.ChoosePackage" %>
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
<br /><br />
    <div class="formConntentHeader" style="text-align:center; color:black; font-size:17px; font-weight:bold;">
    <asp:Label ID="lblMess" Visible="False" runat="server" Font-Italic="True" ForeColor="#FF0000" ></asp:Label>
  </div>
        <center>
        <asp:DataList ID="dlPackage" runat="server" OnItemDataBound="dlPackage_ItemDataBound" BorderColor="Black" BorderWidth="1px">
            <HeaderTemplate>
                <table style="width:869px;height:auto;border:1px black; color:Black;">
                    <tr>
                        <td style="width:200px;height:auto;text-align:left;font-size:larger ; font-weight:bold; color:Black;">Package</td>
                        <td style="width:419px;height:auto;text-align:left;font-size:larger;font-weight:bold;color:Black;">Description</td>
                        <td style="width:250px;height:auto;text-align:left;font-size:larger;color:Black;font-weight:bold;">Subscription plan</td>
                    </tr>
                    <tr>
                        <td colspan="3"><hr style="color:Black;width:99%;margin:0 auto;border:solid 1px;" /></td>
                    </tr> 
            </HeaderTemplate>
            
            <ItemTemplate>               
                    <tr>
                        <td style="width:170px;height:auto;text-align:left;color:Black;">
                            <asp:Label runat="server" ID="lblPackageID" Text='<%#DataBinder.Eval(Container.DataItem,"ID")%>' Visible="false"></asp:Label>
                            <%#DataBinder.Eval(Container.DataItem,"Name")%>
                        </td>
                        <td style="width:379px;height:auto;text-align:left;color:Black;">
                            <%#DataBinder.Eval(Container.DataItem,"Description")%>
                        </td>
                        <td style="width:250px;height:auto;text-align:left;">
                            <asp:Repeater runat="server" ID="rptPackageDetail">
                                <HeaderTemplate>
                                    <table>
                                       <tr>
                                            <td style="width:110px;height:auto;text-align:left;font-weight:bolder;">Plan expiry</td>
                                            <td style="width:90px; height:auto;text-align:left;font-weight:bolder;">Price</td>
                                            <td style="width:50px;height:auto;text-align:left;font-weight:bolder;">Select</td>
                                       </tr>                                       
                                </HeaderTemplate>
                                
                                <ItemTemplate>
                                    <tr> 
                                        <td style="width:90px;height:auto;text-align:left;"> <asp:Label runat="server" ID="lblPackageDetailID" Text='<%#DataBinder.Eval(Container.DataItem,"ID") %>' Visible="false"></asp:Label><%#DataBinder.Eval(Container.DataItem,"ExpiryMonth")%> months</td>
                                        <td style="width:70px; height:auto;text-align:left">Free</td>
                                        <td style="width:40px;height:auto;text-align:left;">
                                            <asp:RadioButton runat="server" ID="rdSelected" GroupName="rdSelected"/>
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
                        <td colspan="3"><hr style="color:Black;width:99%;margin:0 auto;" /></td>
                    </tr>                                    
            </ItemTemplate>                   
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
        
        <table style="width:869px;height:auto;border:0px;">
            <tr>            
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnContinue" runat="server" Text="Continue" Width="130px" CssClass="Button" OnClick="btnContinue_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnRestaurant" runat="server" Text="Back to Restaurant" Width="130px" CssClass="Button" OnClick="btnRestaurant_Click" /></td>
            </tr>
        </table>  
        </center>    
<br />