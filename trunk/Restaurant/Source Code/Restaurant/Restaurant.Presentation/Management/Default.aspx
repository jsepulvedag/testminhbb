<%@ Page Language="C#" MasterPageFile="~/Management/Member.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="Restaurant.Presentation.Member.Default"
    ValidateRequest="false" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" SmartNavigation="true" %>

<%@ Register Src="Member/UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="~/Management/UserControls/Header.ascx" TagPrefix="uc" TagName="PageHeader" %>
<%@ Register Src="~/Management/UserControls/Footer.ascx" TagPrefix="uc" TagName="PageFooter" %>
<%@ Register Src="~/Management/UserControls/Address.ascx" TagPrefix="uc" TagName="PageAddress" %>



<asp:Content ContentPlaceHolderID="cphHeader" runat="server" ID="acHeader">
    <uc:PageHeader ID="ucHeader" runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="acContent">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="padding-top: 10px;">
                <div style="margin: 0 auto; width: 869px; height: auto;">
                    <table cellpadding="0" cellspacing="0" border="0" width="869px">
                        <tr>
                            <td width="200" valign="top">
                                <uc1:Menu ID="Menu1" runat="server" />
                            </td>
                            <td width="7px">
                                &nbsp;</td>
                            <td valign="top">
                                    <div style="float:left;">
                                        <uc:PageAddress ID="pageAddress" runat="server" />                                        
                                    </div>
                                    <div class="formConntentHeaderManagement" style="float:left;text-align: left; padding-top: 7px;
                                        padding-left: 13px; font-size: 18px; vertical-align: middle;">
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                    </div>
                                    <div class="formContentCenterManagement" style="float:left;"> 
                                        <asp:PlaceHolder ID="aphMain" runat="server"></asp:PlaceHolder>
                                    </div>
                                <div class="formConntentFooterManagement">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="cphFooter" runat="server" ID="acFooter">
    <uc:PageFooter ID="ucFooter" runat="server" />
</asp:Content>
