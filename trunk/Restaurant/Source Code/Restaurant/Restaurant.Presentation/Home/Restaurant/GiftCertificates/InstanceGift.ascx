<%@ Control Language="C#" AutoEventWireup="true" Codebehind="InstanceGift.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Restaurant.GiftCertificates.InstanceGift" %>
<%@ Register Src="~/Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail"
    TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="ReviewLeft" TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="ReviewRight"
    TagPrefix="uc" %>

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
function CheckShippingMail(rdmail,rdprint,txtShippingMail)
{    
    if(document.getElementById(rdmail).checked == true)
    {  
        document.getElementById('ShippingMail').style.display = 'block'; 
        document.getElementById(txtShippingMail).focus();      
    }
    else if(document.getElementById(rdprint).checked == true)
    {
        document.getElementById('ShippingMail').style.display = 'none';
    }
}
 function popup(giftID,amount,to,from,message,restaurantid)
 {
    window.open('Home/Restaurant/GiftCertificates/PreviewGift.aspx?GidUrl='+giftID+"&amount="+amount+"&to="+to+"&from="+from+"&message="+message+"&RidUrl="+restaurantid,'Privew gift certificate');
 }
</script>

<div style="margin: 0 auto; width: 869px; height: auto;">
    <div id="pageRestaurantByCuisineHeader">
    </div>
    <div class="pageRestaurantByCuisineCenter">
        <div style="width: 869px; float: left;">
            <uc:RestaurantDetail ID="RestaurantDetail1" runat="server" />
        </div>
        <div style="width: 869px; float: left;">
            <table style="width: 100%">
                <tr>
                    <td rowspan="2" style="width: 174px" valign="top">
                        <uc:ReviewLeft ID="RestaurantReviewLeft" runat="server"></uc:ReviewLeft>
                    </td>
                    <td rowspan="1" style="width: auto; height: 50px; padding-left: 15px;" valign="top">
                        <table style="width: 485px;">
                            <caption style="font-weight: bold; font-size: medium; text-align: center; padding-bottom: 15px;">
                                Design your gift certificate, preview it, and then send or print it immediately.
                                It's fast and easy!</caption>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 8px; font-weight: bold;">
                                    Choose an amount</td>
                                <td>
                                    <asp:TextBox ID="txtAmount" runat="server" Width="100px">10</asp:TextBox>
                                    <asp:Label ID="lblRange" runat="server" Text="(Minimum 5$, maximum 250$)"></asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 8px; font-weight: bold;">
                                    Choose a design</td>
                                <td>
                                    <asp:DropDownList ID="listDesign" runat="server" Width="130px" AutoPostBack="True"
                                        OnSelectedIndexChanged="listDesign_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left;">
                                </td>
                                <td>
                                    <asp:DataList ID="listImage" runat="server" RepeatColumns="3" OnItemDataBound="listImage_ItemDataBound">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdocheck" runat="server" GroupName='<% #DataBinder.Eval(Container.DataItem,"GiftTypeID")%>'
                                                            Text='<% #DataBinder.Eval(Container.DataItem,"Title")%>'></asp:RadioButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Image runat="server" ID="image" ImageUrl='<% #DataBinder.Eval(Container.DataItem,"ImageSmallURL")%>'
                                                            DescriptionUrl='<% #DataBinder.Eval(Container.DataItem,"ID")%>' />
                                                        <asp:TextBox runat="server" ID="url" Text='<% #DataBinder.Eval(Container.DataItem,"ImageLargeURL")%>'
                                                            Visible="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left; padding-top: 8px; font-weight: bold;">
                                    Who are you sending it to ?</td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 8px; padding-left: 50px;">
                                    To
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTo" Width="206px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTo"
                                        ErrorMessage="Can not empty !"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 8px; padding-left: 50px;">
                                    From
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtFrom" Width="206px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFrom"
                                        ErrorMessage="Can not empty !"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 8px; font-weight: bold;">
                                    Include message</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 0px; padding-left: 50px;"
                                    valign="top">
                                    Message
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMessage" runat="server" Rows="4" TextMode="MultiLine" Width="318px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left; padding-top: 8px; font-weight: bold;">
                                    How do you want to send the gift ?</td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 8px;">
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="width: 50px;">
                                                <asp:RadioButton ID="rdMail" runat="server" GroupName="sendGift" Text=" Email" /></td>
                                            <td>
                                                <div id="ShippingMail">
                                                    <asp:TextBox ID="txtShippingMail" runat="server" Width="206px"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 110px; text-align: left; padding-top: 8px;">
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButton ID="rdPrint" runat="server" GroupName="sendGift" Text=" I'll print it, and send to myself"
                                                    Checked="True" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td style="text-align: right; width: 50%;">
                                                <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click"
                                                    CausesValidation="False" />
                                            </td>
                                            <td style="width: 79px">
                                                <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td rowspan="2" style="width: 181px" valign="top">
                        <uc:ReviewRight ID="ReviewRight" runat="server"></uc:ReviewRight>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="pageRestaurantByCuisineFooter">
    </div>
</div>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>
<asp:Literal ID="litPopup" runat="server"></asp:Literal>
