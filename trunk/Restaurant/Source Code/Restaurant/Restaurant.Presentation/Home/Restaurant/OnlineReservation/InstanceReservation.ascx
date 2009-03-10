<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanceReservation.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.OnlineReservation.InstanceReservation" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>
<%@ Register Src="~/Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx" TagName="RestaurantDetail" TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewLeft.ascx" TagName="ReviewLeft" TagPrefix="uc" %>
<%@ Register Src="~/Home/UserControls/ListReviewRight.ascx" TagName="ReviewRight" TagPrefix="uc" %>

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
                    <table style="width:485px;">
                        <caption style="font-size:larger;font-weight:bold;text-align:center;">Online Reservation</caption>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Reservation's Date</td>
                            <td><radCln:RadDateTimePicker ID="radDateReservation" runat="server">
                                </radCln:RadDateTimePicker>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Special Instruction</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtReDescription" TextMode="MultiLine" Rows="3" Columns="32" Width="255px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReDescription"
                                    ErrorMessage="(*)"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Customer's Firstname</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFirstName" Width="185px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="*"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Customer's Lastname</td>
                            <td><asp:TextBox runat="server" ID="txtLastName" Width="185px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width:100px;text-align:left;padding-top:5px;font-weight:bold;">Title</td>
                            <td>
                                <asp:DropDownList runat="server" ID="listGender" Width="87px">
                                    <asp:ListItem Selected="True">Mr</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                    <asp:ListItem>Ms</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Address</td>
                            <td>
                                <asp:DropDownList ID="listCountry" runat="server" Width="110px" AutoPostBack="True" OnSelectedIndexChanged="listCountry_SelectedIndexChanged" />
                                <asp:DropDownList ID="listState" runat="server" Width="110px" AutoPostBack="True" OnSelectedIndexChanged="listState_SelectedIndexChanged" />
                                <asp:DropDownList ID="listCity" runat="server" Width="110px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Address detail</td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" Width="260px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ErrorMessage="(*)" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Phone</td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server" Width="185px" MaxLength="20" ></asp:TextBox>
                            </td>
                        </tr>    
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Fax</td>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server" Width="185" MaxLength="20" ></asp:TextBox> 
                            </td>
                        </tr>
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;">Email</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Width="185" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="(*)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                            </td>
                        </tr> 
                        <tr>
                            <td style="width:130px;text-align:left;padding-top:5px;font-weight:bold;"></td>
                            <td>
                                <asp:Button ID="btnOK" runat="server" Text="Reservation" Width="100px" CssClass="Button" OnClick="btnOK_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" CssClass="Button" OnClick="btnCancel_Click" CausesValidation="False" />
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
