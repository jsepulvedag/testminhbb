<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MyGift.ascx.cs" Inherits="Restaurant.Presentation.Management.Member.GiftCertificates.MyGift" %>
<%@ Register Assembly="RadCalendar.Net2" Namespace="Telerik.WebControls" TagPrefix="radCln" %>

<script language="javascript" type="text/javascript">
    function popup(giftID)
    {
        window.open('Member/GiftCertificates/PrintGift.aspx?GidUrl=' + giftID,'Print gift certificate');
    }
    function onClick(url)
    {
        window.open(url);
    }
</script>

<div style="width: 645px; margin: 0 auto; padding-top: 13px;text-align:center;">

                <asp:GridView ID="gvMyGift" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="3" OnPageIndexChanging="gvMyGift_PageIndexChanging" OnRowDataBound="gvMyGift_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="GiftName" HeaderText="Gift name">
                        </asp:BoundField>
                        <%--<asp:HyperLinkField HeaderText="Restaurant" DataTextField="RestaurantName" DataNavigateUrlFields="RestaurantId"
                            DataNavigateUrlFormatString="/Default.aspx?pid=ListReview&amp;RidUrl={0}">
                        </asp:HyperLinkField>--%>
                         <asp:TemplateField HeaderText="Restaurant">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtRestaurant" runat="server" Text='<%# Eval("RestaurantName") %>' 
                                        ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Price" HeaderText="Price">
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedDate" HeaderText="Created on" DataFormatString="{0:d}">
                        </asp:BoundField>
                        <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry on" DataFormatString="{0:d}">
                        </asp:BoundField>
                        <asp:BoundField DataField="SendGift" HeaderText="Send gift">
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Print">
                            <ItemTemplate>
                                <asp:ImageButton CommandName="imgBtnPrint" CommandArgument='<%#Eval("ID") %>' runat="server"
                                    ID="imgBtnPrint" ImageUrl="~/Media/Images/Printer.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" HorizontalAlign="Right" />
                    <PagerStyle ForeColor="White" HorizontalAlign="Right" Width="30px" Height="30px" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" Width="30px" HorizontalAlign="Center"
                        Height="30px" CssClass="textcenter" />
                    <RowStyle ForeColor="White" Height="25px" />
                </asp:GridView>
</div>
