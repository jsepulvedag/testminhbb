<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiftPurchaseManagement.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.GiftCertificates.GiftPurchaseManagement" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>

        <table style="width:100%; padding-left:10px;">
            <tr>
                <td>
                    Status&nbsp;&nbsp;<asp:DropDownList ID="drpStatusFilter" runat="server">
                        <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                        <asp:ListItem Value="1">Pending</asp:ListItem>
                        <asp:ListItem Value="2">Confirmed</asp:ListItem>
                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;&nbsp;<radCln:RadDatePicker ID="fromDate" runat="server" Width="110px">
                        <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" "
                            Title="" TitleIconImageUrl="" TitleUrl=""></DateInput>
                    </radCln:RadDatePicker>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To&nbsp;&nbsp;<radCln:RadDatePicker ID="toDate" runat="server" Width="110px">
                        <DateInput CatalogIconImageUrl="" Description="" DisplayPromptChar="_" PromptChar=" "
                            Title="" TitleIconImageUrl="" TitleUrl=""></DateInput>
                    </radCln:RadDatePicker>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" CssClass="Button" runat="server" Width="90px" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvGiftCertificate" Width="98%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        OnPageIndexChanging="gvGiftCertificate_PageIndexChanging"
                        PageSize="6" OnSelectedIndexChanged="gvGiftCertificate_SelectedIndexChanged" OnRowDataBound="gvGiftCertificate_RowDataBound" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="FullName" HeaderText="Member" />
                            <asp:BoundField DataField="GiftName" HeaderText="Gift" />
                            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" />
                            <asp:BoundField DataField="SendGift" HeaderText="SendGift" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Price" />
                            <asp:BoundField DataField="CreateDate" HeaderText="Created on" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry on" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" Width="90px" ID="drpStatus">
                                        <asp:ListItem Value="1" Selected="True">Pending</asp:ListItem>
                                        <asp:ListItem Value="2">Confirmed</asp:ListItem>
                                        <asp:ListItem Value="3">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField runat="server" id="hdID" Value='<%#Eval("ID") %>' ></asp:HiddenField>
                                    <asp:HiddenField runat="server" id="lblStatus" Value='<%#Eval("Status") %>' ></asp:HiddenField>
                                    <asp:Label ID="lblStatusGift" Visible="false" runat="server" Text='<%# Eval("Status") %>' Width="90px"
                                         Enabled="false" Font-Size="13px" BackColor="white" ForeColor="black"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                        </Columns>
                        <PagerStyle Height="30px" HorizontalAlign="Right" />
                        <HeaderStyle Height="30px" HorizontalAlign="Center" BackColor="Gray" />
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
