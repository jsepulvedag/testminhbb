<%@ Page Language="C#" MasterPageFile="~/Delivery/Delivery.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="Restaurant.Presentation.Delivery.Default"
    Title="212 Delivery" %>

<%@ Register Src="~/Delivery/UserControls/Controls/Header.ascx" TagPrefix="uc" TagName="PageHeader" %>
<%@ Register Src="~/Delivery/UserControls/Controls/Footer.ascx" TagPrefix="uc" TagName="PageFooter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <uc:PageHeader ID="header" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div style="padding: 10px 0px 10px 0px;">
        <asp:PlaceHolder ID="aphDelivery" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <uc:PageFooter ID="footer" runat="server" />
</asp:Content>
