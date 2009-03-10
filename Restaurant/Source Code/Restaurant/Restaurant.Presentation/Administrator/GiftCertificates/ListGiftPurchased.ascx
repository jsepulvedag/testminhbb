<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ListGiftPurchased.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.GiftCertificates.ListGiftPurchased" %>
<div class="adminPage">
<br />
    <div style="margin-left:7px;">
        <asp:DataGrid ID="dgrListGift" runat="server" AutoGenerateColumns="False" ItemStyle-ForeColor="white"
            HeaderStyle-ForeColor="white" AllowPaging="True" OnPageIndexChanged="dgrListGift_PageIndexChanged" PageSize="5">
            <Columns>
                <asp:BoundColumn HeaderText="MemberName" DataField="MemberName">
                    <HeaderStyle Width="150px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Restaurant Name" DataField="RestaurantName">
                    <HeaderStyle Width="150px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Number Transaction" DataField="NumberTransaction">
                    <HeaderStyle Width="150px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="TotalPrice" DataField="TotalPrice">
                    <HeaderStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Fee" DataField="Fee">
                    <HeaderStyle Width="50px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Tax" DataField="Tax">
                    <HeaderStyle Width="50px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Status" DataField="Status">
                    <HeaderStyle Width="50px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="StatusDate" DataField="StatusDate">
                    <HeaderStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Type" DataField="Type">
                    <HeaderStyle Width="50px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Supplier Payment" DataField="SupplierPayment">
                    <HeaderStyle Width="100px" />
                </asp:BoundColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Image Gift
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgGift" ImageUrl='<%#Eval("GiftImageURL") %>' runat="server" Width="80" />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn HeaderText="Create Date" DataField="CreateDate">
                    <HeaderStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Expired Date" DataField="ExpiredDate">
                    <HeaderStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="ToMsg" DataField="ToMsg">
                    <HeaderStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="FromMsg" DataField="FromMsg">
                    <HeaderStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Send Gift" DataField="SendGift" />
            </Columns>
            <ItemStyle HorizontalAlign="Center" ForeColor="Black" />
            <HeaderStyle ForeColor="Black" BackColor="#CCCCCC" Height="30px" HorizontalAlign="Center"
                Font-Bold="True" />
            <PagerStyle ForeColor="Blue" HorizontalAlign="Right" Mode="NumericPages" />
        </asp:DataGrid>
    </div><br />
</div>
