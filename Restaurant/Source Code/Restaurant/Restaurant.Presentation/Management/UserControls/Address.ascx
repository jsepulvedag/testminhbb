<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Address.ascx.cs" Inherits="Restaurant.Presentation.Management.UserControls.Address" %>

<script language="javascript" type="text/javascript">
function checkAddress(flag)
{
    if(flag=='True')
    {
        document.getElementById('address').style.display = 'none';
    }
    else
    {
        document.getElementById('address').style.display = 'block';
    }
}
</script>
<div id="address">
    <div style="padding-left:-1px;">
        <div class="formConntentHeaderManagement1" >
        </div>
    </div>
    <div class="formContentCenterManagement" style="text-align: left; padding-top: 3px;
        padding-left: 13px; font-size: 16px; font-weight: bold; vertical-align: middle;
        width: 650px;">
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label> <br />
        <asp:Label ID="lblAlert" runat="server" ForeColor="Yellow" Font-Size="12px" /> 
    </div>
    <div class="formConntentFooterManagement">
    </div>
</div>
<asp:Literal ID="ltrScript" runat="server"></asp:Literal>