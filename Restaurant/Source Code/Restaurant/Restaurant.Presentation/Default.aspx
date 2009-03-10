<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Restaurant.Presentation._Default" 
    ValidateRequest="false" EnableEventValidation="false"
    MaintainScrollPositionOnPostback="true" SmartNavigation="true" %>
<%@ Register Src="~/Home/UserControls/Header.ascx" TagPrefix="uc" TagName="PageHeader"%>
<%@ Register Src="~/Home/UserControls/Footer.ascx" TagPrefix="uc" TagName="PageFooter" %>

<asp:Content ContentPlaceHolderID="cphHeader" runat="server" ID="acHeader">
    <uc:PageHeader ID="ucHeader" runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="acContent">
    <asp:PlaceHolder ID="aphMain" runat="server">
    </asp:PlaceHolder>
</asp:Content>
<asp:Content ContentPlaceHolderID="cphFooter" runat="server" ID="acFooter">
    <uc:PageFooter ID="ucFooter" runat="server" />
</asp:Content>