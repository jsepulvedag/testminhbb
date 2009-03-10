<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantContact.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant.RestaurantContact" %>
<script language="javascript" type="text/javascript">
    function CheckMember(index)
    {        
        if(index == 1)
        {
            document.getElementById('contact').style.display = 'block';
            document.getElementById('login').style.display = 'none';
        }
        else if(index == 0)
        {
            document.getElementById('contact').style.display = 'none';
            document.getElementById('login').style.display = 'block';
        }
    }
</script>
<div style="margin: 0 auto; width: 869px; height: auto; background-repeat:repeat-x;">
    <div class="formConntentHeader" style="text-align: left; padding-top: 7px;
        padding-left: 13px; font-size: 18px; vertical-align: middle; width:869px;">
            STEP 3/4 - Current Restaurant Contact
    </div>
   <!-- <div class="formContentCenter" id="login" style="padding-top:7px;">
        <table style="width: 800px;padding-left:60px;">
            <tr>
                <td style="text-align: left;height:20px;font-weight:bold; width: 90px;" align="left">
                    Im' not a member</td>
                <td style="width: 400px">
                    <asp:RadioButton ID="rdYes" GroupName="Member" Checked="true" runat="server" /></td>
            </tr>
            <tr>
                <td style="text-align: left;height:20px; width: 90px;" align="left">
                    <div style="padding-left:60px;">User's name</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="200px" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;height:20px; width: 90px;" align="left">
                    <div style="padding-left:60px;">Password</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtPassword" runat="server" Width="200px" />
                </td>
            </tr>
        </table>
    </div> -->
    <div class="formContentCenter" id="contact" style="padding-top:7px;">
        <table style="width: 800px;padding-left:60px;">
       <!--     <tr>
                <td style="width: 117px; text-align: left;height:20px;font-weight:bold;" align="left">                  
                       I'm a member</td>
                <td style="width: 400px">
                    <asp:RadioButton ID="rdNo" runat="server" GroupName="Member" /></td>
            </tr>
            <tr>
                <td style="text-align: left;height:20px; width: 117px;" align="left">
                    <div style="padding-left:60px;">User's name</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtNewUserName" runat="server" Width="200px" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;height:20px; width: 117px;" align="left">
                    <div style="padding-left:60px;">Password</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtNewPassword" runat="server" Width="200px" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;height:20px; width: 117px;" align="left">
                    <div style="padding-left:60px;">Confirm password</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtNewConfirmPassword" runat="server" Width="200px" />
                </td>
            </tr> -->
            <tr>
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Title</div></td>
                <td style="width: 400px">
                    <asp:DropDownList ID="drpCurrentGender" runat="server" Width="80px">
                        <asp:ListItem Selected="True">Mr</asp:ListItem>
                        <asp:ListItem>Mrs</asp:ListItem>
                        <asp:ListItem>Ms</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">First name</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtCurrentFirstName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentFirstName"
                        ErrorMessage="***"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>    
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Last name</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtCurrentLastName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCurrentLastName"
                        ErrorMessage="***"></asp:RequiredFieldValidator>
                </td>              
            </tr>
            <tr>    
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Phone</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtCurrentPhone" runat="server" Width="200px"></asp:TextBox>
                </td>              
            </tr>
            <tr>
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Fax</div></td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtCurrentFax" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>    
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Email</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtCurrentEmail" runat="server" Width="200px"></asp:TextBox>
                </td>              
            </tr>
            <tr>
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Zipcode</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtCurrentZipCode" runat="server" Width="78px" MaxLength="5"></asp:TextBox></td>
            </tr>            
            <tr>
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Birth day</div></td>
                <td style="width: 400px">
                    <asp:DropDownList ID="drpCurrentMonth" runat="server" Width="90px">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="drpCurrentDay" runat="server" Width="40px">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="drpCurrentYear" runat="server" Width="60px">
                    </asp:DropDownList>&nbsp;(month/day/year)
                </td>
           </tr>
            <tr>    
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Address Detail</div></td>
                <td style="width: 400px">
                    <asp:TextBox ID="txtCurrentAddress" runat="server" Width="420px"></asp:TextBox>
                </td>              
            </tr>
            <tr>    
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;">Address</div></td>
                <td style="width: 400px">
                    <asp:DropDownList ID="drpCurrentCountry" runat="server" Width="135px" AutoPostBack="True" OnSelectedIndexChanged="drpCurrentCountry_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;&nbsp;<asp:DropDownList ID="drpCurrentState" runat="server" Width="135px" AutoPostBack="True" OnSelectedIndexChanged="drpCurrentState_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;
                    <asp:DropDownList ID="drpCurrentCity" runat="server" Width="135px">
                    </asp:DropDownList>&nbsp;(Country - State - City)
                </td>              
            </tr>
            <tr />
            <tr>
                <td colspan="2"><br />
                    <hr style="color: White; border: 1px; width: 600px; text-align: center; margin: 0 auto;"  /><br />
                </td>
            </tr> 
            <tr />           
            <tr>    
                <td style="width: 117px; text-align: left;height:20px;" align="left">
                    <div style="padding-left:60px;"></div></td>
                <td style="width: 400px">
                    <asp:Button ID="btnContinue" runat="server" Text="Proceed to Pay" Width="130px" CssClass="Button" OnClick="btnContinue_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="Back to step 2/4" Width="130px" CssClass="Button" CausesValidation="False" OnClick="btnBack_Click" />
                </td>              
            </tr>
        </table>
    </div>
<div id="pageRestaurantByCuisineFooter"></div>
</div>
