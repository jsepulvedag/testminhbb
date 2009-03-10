<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AddRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.RestaurantManagement.ListRestaurant.AddRestaurant" %>
<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadUpload.Net2" Namespace="Telerik.WebControls" TagPrefix="radU" %>

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
</script>
<br />
<div id="formConntent" style="color: black; font-family:Tahoma; font-size:12px; margin-left: 100px;
    margin-right: 100px; ">
    <div class="formConntentHeader" style="text-align: center; font-size: 17px; font-weight: bold;">
        <asp:Label ID="lblMess" runat="server" Font-Italic="True" Visible="False"
            Width="100%" ForeColor="Red"></asp:Label>
    </div>
    <div class="formContentCenter">
        <table style="width: 900px;">
            <caption style="text-align: left; font-size: 20px; margin-left: 5px; font-weight: bold;">
                Restaurant information detail</caption>
            <tr>
                <td style="width: 200px; text-align: left;">
                    Restaurant name &nbsp;</td>
                <td style="width: 250px;">
                    <asp:TextBox ID="txtRestaurantName" runat="server" Width="200px"></asp:TextBox>
                    <strong><span style="color: #ff0000">(*)</span></strong><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRestaurantName"
                        ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
                <td style="width: 200px; text-align: right;">
                    
                </td>
                <td style="width: 250px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 200px; text-align: left;">
                    Restaurant admin first name &nbsp;</td>
                <td style="width: 250px;">
                    <asp:TextBox ID="txtContactFirstName" runat="server" Width="200px"></asp:TextBox>
                    <strong><span style="color: #ff0000">(*)</span></strong><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactFirstName"
                        ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
                <td style="width: 200px; text-align: left;">
                    Restaurant admin last name &nbsp;
                </td>
                <td style="width: 250px;">
                    <asp:TextBox ID="txtContactLastName" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 200px; text-align: left;">
                    Fax&nbsp;</td>
                <td style="width: 250px;">
                    <asp:TextBox ID="txtRestaurantFax" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRestaurantFax"
                        ErrorMessage="(*)" ValidationExpression="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"></asp:RegularExpressionValidator></td>
                <td style="width: 200px; text-align: left;">
                    Phone 1 &nbsp;&nbsp;
                </td>
                <td style="width: 250px;">
                    <asp:TextBox ID="txtRestaurantPhone1" runat="server" Width="200px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRestaurantPhone1"
                        ErrorMessage="(*)" ValidationExpression="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRestaurantPhone1"
                        ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 200px; text-align: left">
                    Website&nbsp;&nbsp;</td>
                <td style="width: 250px">
                    <asp:TextBox ID="txtRestaurantWebsite" runat="server" Width="200px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRestaurantWebsite"
                        ErrorMessage="(*)" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRestaurantWebsite"
                            ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
                <td style="width: 200px; text-align: left">
                    Phone 2 &nbsp;&nbsp;</td>
                <td style="width: 250px">
                    <asp:TextBox ID="txtRestaurantPhone2" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 200px; text-align: left;">
                    Email &nbsp;&nbsp;</td>
                <td style="width: 250px">
                    <asp:TextBox ID="txtRestaurantEmail" runat="server" Width="200px"></asp:TextBox><strong><span
                        style="color: #ff0000">(*)<asp:RegularExpressionValidator
                        ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRestaurantEmail"
                        ErrorMessage="(*)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></span></strong></td>
                <td style="width: 200px; text-align: left;">
                    </td>
                <td style="width: 250px">
                    &nbsp;<strong><span style="color: #ff0000"></span><span style="color: #ff0000"></span></strong></td>
            </tr>
            <tr>
                <td style="width: 200px; text-align: left">
                    Image&nbsp;</td>
                <td colspan="3" style="width: 720px">
                    <asp:FileUpload ID="fuImage" runat="server" Height="21px" Width="199px" /></td>
            </tr>
        </table>
        <table style="width: 900px">
            <tr>
                <td style="width: 190px; text-align: right;">
                    &nbsp;</td>
                <td style="width: 700px">
                    <asp:CheckBox ID="chkAcceptCreditCard" runat="server" Text="Accept credit card ?" /></td>
            </tr>
            <tr>
                <td style="width: 190px; text-align: left;" align="left">
                    Address &nbsp;</td>
                <td style="width: 700px">
                    <asp:DropDownList ID="drpRestaurantCountry" runat="server" Width="135px" OnSelectedIndexChanged="drpRestaurantCountry_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpRestaurantState" runat="server"
                        Width="135px" OnSelectedIndexChanged="drpRestaurantState_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpRestaurantCity" runat="server"
                        Width="135px" AutoPostBack="True" OnSelectedIndexChanged="drpRestaurantCity_SelectedIndexChanged">
                    </asp:DropDownList>
                    (Country - State - City)</td>
            </tr>
            <tr>
                <td style="width: 190px; text-align: left" >
                    Neighbourhood</td>
                <td style="width: 700px">
                    <asp:DropDownList ID="dropNeighbourhood" runat="server" Width="135px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 190px; text-align: left;" >
                    Address Detail </td>
                <td style="width: 700px">
                    <asp:TextBox ID="txtRestaurantAddress" runat="server" Width="650px" Height="17px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 190px; text-align: left;" >
                    Zipcode
                </td>
                <td style="width: 700px">
                    <asp:TextBox ID="txtRestaurantZipcode" runat="server" Width="100px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRestaurantZipcode"
                        ErrorMessage="(*)" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRestaurantZipcode"
                        ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 190px; text-align: left" align="left">
                    Description &nbsp;
                </td>
                <td style="width: 700px">
                    <asp:TextBox ID="txtRestaurantDescription" runat="server" Rows="3" TextMode="MultiLine"
                        Width="650px"></asp:TextBox></td>
            </tr>
        </table>
        <table style="width: 550px; margin-left: 190px;">
            <caption style="text-align: left; font-size: medium; margin-left: 230px; font-weight:bold;">
                Good for</caption>
            <tr>
                <td style="width: 40%; text-align: center; height: 79px;">
                    <asp:ListBox ID="listGoodFor" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 20%; height: 79px;">
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
                <td style="width: 40%; text-align: center; height: 79px;">
                    <asp:ListBox ID="listSelectedGoodFor" runat="server" Width="222px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        
        <table style="width: 550px; margin-left: 190px;">
            <caption style="text-align: left; font-size: medium;margin-left: 230px; font-weight:bold;">
                Restaurant cuisine
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="listSelectedCuisine"
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
        <table style="width: 550px; margin-left: 190px;">
            <caption style="text-align: left; font-size: medium; margin-left: 230px; font-weight:bold;">
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
        <table style="width: 550px; margin-left: 190px;">
            <caption style="text-align: left; font-size: medium; margin-left: 230px; font-weight:bold;">
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
        <table style="width: 550px; margin-left: 190px;">
            <caption style="text-align: left; font-size: medium; margin-left: 230px; font-weight:bold;">
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
        <table style="width: 550px; margin-left: 190px;">
            <caption style="text-align: left; font-size: medium; margin-left: 230px; font-weight:bold;">
                Restaurant Atmosphere</caption>
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
        <table style="width: 900px;">
            <tr>
                <td style="text-align: right; width: 50%;">
                    <asp:Button ID="btnContinue" runat="server" Text="Add Restaurant" Width="130px" OnClick="btnContinue_Click"
                        CssClass="Button" /></td>
                <td style="text-align: left; width: 50%;">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" CssClass="Button"
                        OnClick="btnCancel_Click" CausesValidation="False" /></td>
            </tr>
        </table>
    </div>
    <div class="formConntentFooter">
        &nbsp;</div>
</div>
<br />