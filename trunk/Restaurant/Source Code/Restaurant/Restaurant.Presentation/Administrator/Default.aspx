<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="Restaurant.Presentation.Administrator.Default"
    ValidateRequest="false" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" SmartNavigation="true" %>

<%@ Register Src="~/Administrator/UserControls/Header.ascx" TagName="PageHeader"
    TagPrefix="uc" %>
<%@ Register Src="~/Administrator/UserControls/Footer.ascx" TagName="PageFooter"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="cphHeader" runat="server" ID="acHeader">
    <uc:PageHeader ID="ucHeader" runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="acContent">
    <div style="margin: 0 auto;">
<%--        <div>
            <div class="adminPage_left_header">
            </div>--%>
            <div ><%--class="adminPage_center_header"--%>
                <div style="font-size: 20px; color:blue; padding-left: 100px; font-weight: bold;">
                    <br />
                    <asp:Label ID="lblTitle" Font-Size="18px" runat="server" ForeColor="#FF6600"></asp:Label>
                </div>
                <div>
                    <hr size="1" style="border: thin 1px #CCCCCC;" />
                </div>
            </div>
          <%--  <div class="adminPage_right_header">
            </div>
        </div>--%>
        <div>
           <%-- <div class="middle_left">
            </div>--%>
            <div  > <%--class="middle"--%>
                <asp:PlaceHolder ID="aphMain" runat="server"></asp:PlaceHolder>
            </div>
            <%--<div class="middle_right">
            </div>
            --%>
        </div>
<%--        <div>
            <div class="footer_left">
            </div>
            <div class="footer_middle">
            </div>
            <div class="footer_right">
            </div>
        </div>--%>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="cphFooter" runat="server" ID="acFooter">
    <uc:PageFooter ID="ucFooter" runat="server" />
</asp:Content>
