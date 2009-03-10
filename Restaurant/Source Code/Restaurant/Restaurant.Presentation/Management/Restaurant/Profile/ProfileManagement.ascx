<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileManagement.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Profile.ProfileManagement" %>
<div>    
    <div >
        <table id="tableContact" style="width: 662px">
            <caption style="text-align: left; font-size: medium; padding-left:10px;height:30px; padding-top:5px; font-weight: bold;">
                Your current restaurant contact</caption>
            <tr>
                <td style="width: 71px; text-align: left; padding-left: 10px;">
                    Title</td>
                <td style="width: 200px">
                    <asp:DropDownList ID="drpCurrentGender" runat="server" Width="80px">
                        <asp:ListItem Selected="True">Mr</asp:ListItem>
                        <asp:ListItem>Mrs</asp:ListItem>
                        <asp:ListItem>Ms</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 58px; text-align: left; padding-left: 10px;">
                    Email</td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtCurrentEmail" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 71px; text-align: left; padding-left: 10px;">
                    First name&nbsp;</td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtCurrentFirstName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentFirstName"
                        ErrorMessage="***"></asp:RequiredFieldValidator></td>
                <td style="width: 58px; text-align: left; padding-left: 10px;">
                    Last name&nbsp;</td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtCurrentLastName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCurrentLastName"
                        ErrorMessage="***"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 71px; text-align: left; padding-left: 10px;">
                    Zipcode&nbsp;</td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtCurrentZipCode" runat="server" Width="78px" MaxLength="5"></asp:TextBox></td>
                <td style="width: 58px; text-align: left; padding-left: 10px;">
                    Phone&nbsp;</td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtCurrentPhone" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 71px; text-align: left; padding-left: 10px;">
                    Fax&nbsp;</td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtCurrentFax" runat="server" Width="200px"></asp:TextBox></td>
                <td style="width: 58px; text-align: right;">
                    </td>
                <td style="width: 200px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 106px; text-align: left; padding-left: 10px;">
                    Birth day&nbsp;</td>
                <td colspan="3" style="width: 561px">
                    <asp:DropDownList ID="drpCurrentMonth" runat="server" Width="90px">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="drpCurrentDay" runat="server" Width="50px">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="drpCurrentYear" runat="server" Width="60px">
                    </asp:DropDownList>&nbsp;(month/day/year)</td>
            </tr>
            <tr>
                <td style="width: 106px; text-align: left; padding-left: 10px;">
                    Address Detail&nbsp;</td>
                <td colspan="3" style="height: 23px; width: 561px;">
                    <asp:TextBox ID="txtCurrentAddress" runat="server" Width="530px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 106px; text-align: left; padding-left: 10px;">
                    Address&nbsp;</td>
                <td colspan="3" style="width: 561px">
                    <asp:DropDownList ID="drpCurrentCountry" runat="server" Width="135px" AutoPostBack="True" OnSelectedIndexChanged="drpCurrentCountry_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpCurrentState" runat="server" Width="135px" AutoPostBack="True" OnSelectedIndexChanged="drpCurrentState_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpCurrentCity" runat="server" Width="135px">
                    </asp:DropDownList>(Country - State - City)</td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: left; font-size: medium; padding-left:10px;height:30px; padding-top:5px; font-weight: bold;">
                    Restaurant information detail
                </td>
            </tr>
            <tr>
                <td style="width: 83px; text-align: left; padding-left: 10px;">
                    Restaurant name&nbsp;</td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRestaurantName"
                        ErrorMessage="***"></asp:RequiredFieldValidator></td>
                <td style="width: 57px; text-align: left; padding-left: 10px;">
                    Email &nbsp;</td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantEmail" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRestaurantEmail"
                        ErrorMessage="***" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 83px; text-align: left; padding-left: 10px;">
                    Zipcode&nbsp;</td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantZipcode" runat="server" Width="100px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRestaurantZipcode"
                        ErrorMessage="***" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator></td>
                <td style="width: 57px; text-align: left; padding-left: 10px;">
                    Website&nbsp;</td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantWebsite" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRestaurantWebsite"
                        ErrorMessage="***" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 83px; text-align: left; padding-left: 10px;">
                    Phone1&nbsp;</td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantPhone1" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRestaurantPhone1"
                        ErrorMessage="***" ValidationExpression="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"></asp:RegularExpressionValidator></td>
                <td style="width: 57px; text-align: left; padding-left: 10px;">
                    Phone2 &nbsp;</td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtRestaurantPhone2" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 83px; text-align: left; padding-left: 10px;">
                    Fax &nbsp;</td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtRestaurantFax" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRestaurantFax"
                        ErrorMessage="***" ValidationExpression="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"></asp:RegularExpressionValidator>
                </td>
                <td style="width: 57px; text-align: right;">
                    &nbsp;&nbsp;</td>
                <td style="width: 200px" rowspan="3">
                    &nbsp;<asp:Image ID="imgRestaurant" runat="server" Height="80px" Width="80px" /></td>
            </tr>
            <tr>
                <td style="width: 83px; text-align: left; padding-left: 10px;">
                    Image</td>
                <td colspan="2">
                    <asp:FileUpload ID="fuImage" runat="server" Height="21px" Width="226px" /></td>
            </tr>
            <tr>
                <td style="width: 83px; text-align: right">
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="chkAcceptCreditCard" runat="server" Text="Accept credit card" /></td>
            </tr>
            <tr>
                <td style="width: 90px; text-align: left; padding-left: 10px;">
                    Date opened &nbsp;</td>
                <td colspan="3">
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
                <td style="width: 90px; text-align: left; padding-left: 10px;">
                    Address &nbsp;</td>
                <td colspan="3">
                    <asp:DropDownList ID="drpRestaurantCountry" runat="server" Width="135px"
                        AutoPostBack="True" OnSelectedIndexChanged="drpRestaurantCountry_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpRestaurantState" runat="server"
                        Width="135px"
                        AutoPostBack="True" OnSelectedIndexChanged="drpRestaurantState_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="drpRestaurantCity" runat="server"
                        Width="135px" AutoPostBack="True" OnSelectedIndexChanged="drpRestaurantCity_SelectedIndexChanged">
                    </asp:DropDownList>(Country- State - City)</td>
            </tr>
            <tr>
                <td style="width: 90px; text-align: left; padding-left: 10px;">
                    Neighbourhood</td>
                <td colspan="3">
                    <asp:DropDownList ID="dropNeighbourhood" runat="server" Width="135px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 90px; text-align: left; padding-left: 10px;">
                    Address Detail &nbsp;</td>
                <td colspan="3">
                    <asp:TextBox ID="txtRestaurantAddress" runat="server" Width="540px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
        <table style="width: 582px;margin-left:80px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px; font-weight:bold;">
                Good for</caption>
            <tr>
                <td style="text-align: right; width: 251px;">
                    <asp:ListBox ID="listGoodFor" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 17%">
                    <table style="width: 100px;">
                        <tr>
                            <td style="width: 80px;text-align:center;">
                                <asp:Button ID="btnGoodForSelected" runat="server" Text=">>" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnSelectedGoodFor_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align:center;">
                                <asp:Button ID="btnGoodFor" runat="server" Text="<<" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnGoodFor_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:251px;">
                    <asp:ListBox ID="listGoodForSelected" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>       
        <table style="width: 582px;margin-left:80px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;font-weight:bold;">
                Restaurant cuisine</caption>
            <tr>
                <td style="text-align: right; width: 251px;">
                    <asp:ListBox ID="listCuisine" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 17%">
                    <table style="width: 100px;">
                        <tr>
                            <td style="width: 80px;text-align:center;">
                                <asp:Button ID="btnCuisineSelected" runat="server" Text=">>" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnSelectedCuisine_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align:center;">
                                <asp:Button ID="btnCuisine" runat="server" Text="<<" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnCuisine_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:251px;">
                    <asp:ListBox ID="listCuisineSelected" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 582px;margin-left:80px;">
            <caption style="text-align: left; font-size: medium; margin-left: 50px;font-weight:bold;">
                Restaurant special</caption>
            <tr>
                <td style="text-align: right; width: 251px;">
                    <asp:ListBox ID="listSpecial" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 17%">
                    <table style="width: 100px;">
                        <tr>
                            <td style="width: 80px;text-align:center;">
                                <asp:Button ID="btnSpecialSelected" runat="server" Text=">>" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnSelectedSpecial_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align:center;">
                                <asp:Button ID="btnSpecial" runat="server" Text="<<" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnSpecial_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:251px;">
                    <asp:ListBox ID="listSpecialSelected" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 582px;margin-left:80px;">
            <caption style="text-align: left;font-weight:bold; font-size: medium; margin-left: 50px;">
                Restaurant music</caption>
            <tr>
                <td style="text-align: right; width: 251px;">
                    <asp:ListBox ID="listMusic" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 17%">
                    <table style="width: 100px;">
                        <tr>
                            <td style="width: 80px;text-align:center;">
                                <asp:Button ID="btnMusicSelected" runat="server" Text=">>" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnSelectedMusic_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align:center;">
                                <asp:Button ID="btnMusic" runat="server" Text="<<" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnMusic_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:251px;">
                    <asp:ListBox ID="listMusicSelected" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 582px;margin-left:80px;">
            <caption style="font-weight:bold;text-align: left; font-size: medium; margin-left: 50px;">
                Restaurant attire</caption>
            <tr>
                <td style="text-align: right; width: 251px;">
                    <asp:ListBox ID="listAttire" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 17%">
                    <table style="width: 100px;">
                        <tr>
                            <td style="width: 80px;text-align:center;">
                                <asp:Button ID="btnAttireSelected" runat="server" Text=">>" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnSelectedAttire_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align:center;">
                                <asp:Button ID="btnAttire" runat="server" Text="<<" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnAttire_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:251px;">
                    <asp:ListBox ID="listAttireSelected" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 582px;margin-left:80px;">
            <caption style="text-align: left;font-weight:bold; font-size: medium; margin-left: 50px;">
                Restaurant atmosphere</caption>
            <tr>
                <td style="text-align: right; width: 251px;">
                    <asp:ListBox ID="listAtmosphere" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td style="width: 17%">
                    <table style="width: 100px;">
                        <tr>
                            <td style="width: 80px;text-align:center;">
                                <asp:Button ID="btnAtmosphereSelected" runat="server" Text=">>" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnSelectedAtmosphere_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align:center;">
                                <asp:Button ID="btnAtmosphere" runat="server" Text="<<" Width="80px" CssClass="Button"
                                     CausesValidation="False" OnClick="btnAtmosphere_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:251px;">
                    <asp:ListBox ID="listAtmosphereSelected" runat="server" Width="225px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width:662px;">
            <tr>
                <td style="width:50%;text-align:center; padding-left:80px;">
                    <asp:Button ID="btnEdit" runat="server" Text="Update" Width="80px" CssClass="Button" OnClick="btnEdit_Click" /></td>
            </tr>
        </table>
</div>