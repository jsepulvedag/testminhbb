<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileManagement.ascx.cs" Inherits="Restaurant.Presentation.Management.Member.Profile.ProfileManagement" %>

<div>  <br />
    <table style="width: 600px">
        <tr>
            <td colspan="2">
                <h3><strong>&nbsp;Profile Management </strong></h3><br />
            </td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Email</td>
            <td style="width: auto">
          <asp:TextBox ID="txtEmail" runat="server" Width="220px" maxlength="60" />
           <asp:Label ID="lbEmail" runat="server" Width="81px" /></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                FirstName</td>
            <td style="width: auto">
          <asp:TextBox ID="txtFirstName" runat="server" Width="220px"/></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Last Name</td>
            <td style="width: auto">
          <asp:TextBox ID="txtLastName" runat="server" Width="220px" /></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Birthday</td>
            <td style="width: auto">
                <asp:DropDownList ID="drdMonth" runat="server" Width="87px" >
               </asp:DropDownList>
                /
                <asp:DropDownList ID="drdDate" runat="server" Width="42px" >
               </asp:DropDownList>
                /
               <asp:DropDownList ID="drdYear" runat="server" Width="60px" >
               </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Title</td>
            <td style="width: auto">
              <asp:DropDownList ID="drdGender" runat="server" Width="87px"  >
              <asp:ListItem>Ms</asp:ListItem>
              <asp:ListItem>Mr</asp:ListItem>
              <asp:ListItem>Mrs</asp:ListItem>
	          </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Zipcode</td>
            <td style="width: auto">
      <asp:TextBox ID="txtZipcode" runat="server" Width="98px" /></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Address</td>
            <td style="width: auto">
                <asp:DropDownList ID="drdCountry" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="drdCountry_SelectedIndexChanged" >
       </asp:DropDownList>&nbsp;<asp:DropDownList ID="drdState" runat="server" Width="104px" AutoPostBack="True" OnSelectedIndexChanged="drdState_SelectedIndexChanged">
       </asp:DropDownList>&nbsp;<asp:DropDownList ID="drdCity" runat="server" Width="92px"  >
      </asp:DropDownList>
                (Country - State - City)</td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Address Detail</td>
            <td style="width: auto">
            <asp:TextBox ID="txtAddress" runat="server" Width="301px" /></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Phone Number</td>
            <td style="width: auto">
            <asp:TextBox ID="txtPhone" runat="server" Width="156px"/></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
                Fax</td>
            <td style="width: auto">
            <asp:TextBox ID="txtFax" runat="server" Width="156px" /></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
            </td>
            <td style="width: auto">
            <asp:CheckBox ID="cbReciveMail" runat="server" Text=" Is want recieve Email ?" /></td>
        </tr>
        <tr>
            <td style="width: 74px; padding-left: 20px;">
            </td>
            <td style="width: auto">
        <asp:Button ID="btnRegister"  runat="server" OnClick="btnOk_Click" Text="Update" Width="60px" /></td>
        </tr>
    </table>
    <br />  
      
</div>