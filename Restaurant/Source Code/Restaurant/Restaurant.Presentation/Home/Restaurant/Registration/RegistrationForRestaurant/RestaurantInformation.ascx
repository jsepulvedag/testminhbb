<%@ Control Language="C#" AutoEventWireup="true" Codebehind="RestaurantInformation.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant.RestaurantInformation" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>

<script type="text/javascript" language="javascript">
    function CheckSameCurrentContact(checkBox)
    {
        if(document.getElementById(checkBox).checked == true)
        {
            document.getElementById('divNewRestaurantContact').style.display = 'none';
        }
        else
        {
            document.getElementById('divNewRestaurantContact').style.display = 'block';
        }       
    }
    function SwapListBox(list,selected)
    {        
        var count = document.getElementById(list).options.length;  
        var i;
        for(i = 0; i < count; i++)
        {
            if(document.getElementById(list).options[i].selected == true)
            {
                var txt = document.getElementById(list).options[i].text;
                var val = document.getElementById(list).options[i].value;
                var opt = new Option(txt,val);                
                
                document.getElementById(selected).options.add(opt);                
                document.getElementById(list).remove(i);         
            }
        }   
    }
    function ChangeTextBox(txtContact,txtRestaurant)
    { 
        document.getElementById(txtRestaurant).value = document.getElementById(txtContact).value
    }
    function OnFocus(txt)
    {
        document.getElementById(txt).value='';    
    }
    function OnBlur(txt,val)
    {                
        if(document.getElementById(txt).value == '')
        {
            document.getElementById(txt).value = val;
        }
    }
</script>
<div style="margin: 0 auto; width: 869px; height: auto; background-repeat:repeat-x;">
    <div class="formConntentHeader" style="text-align: left; padding-top: 7px;
        padding-left: 13px; font-size: 18px; vertical-align: middle; width:869px;">
            STEP 2/4 - Restaurant Information Entry
    </div>
    <div class="formContentCenter">
        <table style="width: 700px">            
            <tr>
                <td style="width: 100px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Restaurant name</div>
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantName" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: #ff0000">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRestaurantName"
                        ErrorMessage="***"></asp:RequiredFieldValidator></td>
                <td style="width: 100px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Image</div></td>
                <td style="width: 200px;">
                    <asp:FileUpload ID="fuImage" runat="server" Height="21px" Width="200px" /></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Fax</div></td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantFax" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: #ff0000">*</span><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRestaurantFax"
                        ErrorMessage="***" ValidationExpression="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"></asp:RegularExpressionValidator></td>
                <td style="width: 100px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Website</div>
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantWebsite" runat="server" Width="200px" Text="http://www.yourwebsite.com"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRestaurantWebsite"
                        ErrorMessage="***" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Phone1</div>
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantPhone1" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: #ff0000">*</span><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRestaurantPhone1"
                        ErrorMessage="***" ValidationExpression="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRestaurantPhone1"
                        ErrorMessage="***"></asp:RequiredFieldValidator></td>
                <td style="width: 100px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Email </div>
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantEmail" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRestaurantEmail"
                        ErrorMessage="***" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Phone2</div>
                </td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtRestaurantPhone2" runat="server" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; text-align: left;">
                    &nbsp;</td>
                <td style="width: 200px">
                    &nbsp;</td>
            </tr>
        </table>
        <table style="width: 700px">
            <tr>
                <td style="width: 112px; text-align: left;">
                    &nbsp;</td>
                <td>
                    <asp:CheckBox ID="chkAcceptCreditCard" runat="server" Text="  Accept credit card" /></td>
            </tr>
            <tr>
                <td style="width: 112px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Date opened </div>
                </td>
                <td>
                    <asp:DropDownList ID="drpOpenedMonth" runat="server" Width="90px">
                    </asp:DropDownList>&nbsp;&nbsp;<asp:DropDownList ID="drpOpenedDay" runat="server"
                        Width="50px">
                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtOpendYear" runat="server" Width="58px"
                        MaxLength="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOpendYear"
                        ErrorMessage="RequiredFieldValidator">***</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtOpendYear"
                        ErrorMessage="RangeValidator" MaximumValue="2100" MinimumValue="1950">***</asp:RangeValidator>
                    (month/day/year)</td>
            </tr>
            <tr>
                <td style="width: 112px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Address </div>
                </td>
                <td>
                    <asp:DropDownList ID="drpRestaurantCountry" runat="server" Width="135px" OnSelectedIndexChanged="drpRestaurantCountry_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpRestaurantState" runat="server"
                        Width="135px" OnSelectedIndexChanged="drpRestaurantState_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpRestaurantCity" runat="server"
                        Width="135px" AutoPostBack="True" OnSelectedIndexChanged="drpRestaurantCity_SelectedIndexChanged">
                    </asp:DropDownList>(Country - State - City)</td>
            </tr>
            <tr>
                <td style="width: 112px; text-align: left" align="left">
                    <div style="padding-left:30px;">Neighbourhood </div>
                </td>
                <td>
                    <asp:DropDownList ID="dropNeighbourhood" runat="server" Width="135px">
                    </asp:DropDownList>
                    <span style="color: #ff0000">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ControlToValidate="dropNeighbourhood" ErrorMessage="***"></asp:RequiredFieldValidator></span></td>
            </tr>
            <tr>
                <td style="width: 112px; text-align: left;" align="left">
                    <div style="padding-left:30px;">Address Detail </div>
                </td>
                <td>
                    <asp:TextBox ID="txtRestaurantAddress" runat="server" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 112px; text-align: left" align="left">
                    <div style="padding-left:30px;">Zipcode</div>
                </td>
                <td>
                    <asp:TextBox ID="txtRestaurantZipcode" runat="server" Width="100px"></asp:TextBox>
                    <span style="color: #ff0000">*</span><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRestaurantZipcode"
                        ErrorMessage="***" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRestaurantZipcode"
                        ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        <br />
        <hr style="color: White; border: 1px; width: 600px; text-align: center; margin: 0 auto;" />
        <br />
        <table style="width: 550px; margin-left: 118px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;">
                Good for</caption>
            <tr>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listGoodFor" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 20%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnSelectedGoodFor" runat="server" Text=">>" Width="80px" CssClass="Button"
                                    OnClick="btnSelectedGoodFor_Click" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnGoodFor" runat="server" Text="<<" Width="80px" CssClass="Button"
                                    OnClick="btnGoodFor_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listSelectedGoodFor" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        
        <table style="width: 550px; margin-left: 118px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;">
                Restaurant cuisine <span style="color: #ff0000">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="listSelectedCuisine"
                    ErrorMessage="(*)"></asp:RequiredFieldValidator></caption>
            <tr>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listCuisine" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 20%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnSelectedCuisine" runat="server" Text=">>" Width="80px" CssClass="Button"
                                    OnClick="btnSelectedCuisine_Click" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnCuisine" runat="server" Text="<<" Width="80px" CssClass="Button"
                                    OnClick="btnCuisine_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listSelectedCuisine" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 550px; margin-left: 118px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;">
                Restaurant special</caption>
            <tr>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listSpecial" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 20%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnSelectedSpecial" runat="server" Text=">>" Width="80px" CssClass="Button"
                                    OnClick="btnSelectedSpecial_Click" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnSpecial" runat="server" Text="<<" Width="80px" CssClass="Button"
                                    OnClick="btnSpecial_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listSelectedSpecial" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 550px; margin-left: 118px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;">
                Restaurant music</caption>
            <tr>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listMusic" runat="server" Width="222px" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td style="width: 20%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnSelectedMusic" runat="server" Text=">>" Width="80px" CssClass="Button"
                                    OnClick="btnSelectedMusic_Click" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnMusic" runat="server" Text="<<" Width="80px" CssClass="Button"
                                    OnClick="btnMusic_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listSelectedMusic" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 550px; margin-left: 118px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;">
                Restaurant attire</caption>
            <tr>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listAttire" runat="server" Width="222px" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td style="width: 20%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnSelectedAttire" runat="server" Text=">>" Width="80px" CssClass="Button"
                                    OnClick="btnSelectedAttire_Click" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnAttire" runat="server" Text="<<" Width="80px" CssClass="Button"
                                    OnClick="btnAttire_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listSelectedAttire" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 550px; margin-left: 118px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;">
                Restaurant atmosphere</caption>
            <tr>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listAtmosphere" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 20%">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnSelectedAtmosphere" runat="server" Text=">>" Width="80px" CssClass="Button"
                                    OnClick="btnSelectedAtmosphere_Click" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; text-align: center;">
                                <asp:Button ID="btnAtmosphere" runat="server" Text="<<" Width="80px" CssClass="Button"
                                    OnClick="btnAtmosphere_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40%; text-align: center;">
                    <asp:ListBox ID="listSelectedAtmosphere" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <br />
        <hr style="color: White; border: 1px; width: 600px; text-align: center; margin: 0 auto;" />
        <br />
        <table style="width: 700px;">
            <tr>
                <td style="text-align: right; width: 50%;">
                    <asp:Button ID="btnContinue" runat="server" Text="Continue" Width="130px" OnClick="btnContinue_Click"
                        CssClass="Button" /></td>
                <td style="text-align: left; width: 50%;">
                    <asp:Button ID="btnBack" runat="server" Text="Back to step 1/4" Width="130px" CssClass="Button" CausesValidation="False" OnClick="btnBack_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" CssClass="Button" CausesValidation="False" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>
    </div>
<div id="pageRestaurantByCuisineFooter"></div>
</div>
