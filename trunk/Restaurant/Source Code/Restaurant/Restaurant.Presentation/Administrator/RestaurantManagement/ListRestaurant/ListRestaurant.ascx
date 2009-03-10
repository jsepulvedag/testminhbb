<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ListRestaurant.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.RestaurantManagement.ListRestaurant.ListRestaurant" %>
<%@ Register Src="~/Administrator/RestaurantManagement/ListRestaurant/CreateRestaurant.ascx"
    TagName="CreateRestaurant" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">
    function onClick(url)
    {
        window.open(url);
    }
</script>

<br />
<div style="width: 99%; margin: 0 auto; color: Black;">
    <%--border:solid 1px #999999;--%>
    <div style="width: 100%; color: Black;">
        <br />
        <div class="banner_contact" style="width: 402; padding-left: 17px; color: black;
            font-weight: bold;">
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;">
                Restaurant Name</div>
            <div style="margin: 0 auto; height: 25px; padding-left: 135px;">
                <asp:TextBox ID="txtRestaurantName" runat="server" Width="200px" Height="15px" BorderStyle="Solid"
                    BorderWidth="1px"></asp:TextBox>
            </div>
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;">
                Country</div>
            <div style="margin: 0 auto; height: 25px; padding-left: 135px;">
                <asp:DropDownList ID="drpCountry" runat="server" Width="202px" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList></div>
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;">
                State</div>
            <div style="margin: 0 auto; height: 25px; padding-left: 135px;">
                <asp:DropDownList ID="drpState" runat="server" Width="202px" OnSelectedIndexChanged="drpState_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList></div>
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;">
                City</div>
            <div style="margin: 0 auto; height: 25px; padding-left: 135px;">
                <asp:DropDownList ID="drpCity" runat="server" Width="202px">
                </asp:DropDownList>
            </div>
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;">
                Zipcode</div>
            <div style="margin: 0 auto; height: 25px; padding-left: 135px;">
                <asp:TextBox ID="txtZip" runat="server" Width="200px" Height="15px" BorderStyle="Solid"
                    BorderWidth="1px"></asp:TextBox>
            </div>
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;">
                Cuisine</div>
            <div style="margin: 0 auto; height: 25px; padding-left: 135px;">
                <asp:DropDownList ID="drpCuisine" runat="server" Width="202px">
                </asp:DropDownList>
            </div>
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;" align="right">
            </div>
            <div style="margin: 0 auto; height: 25px">
                <asp:Button ID="butSearch" runat="server" Font-Bold="True" Text="Search" OnClick="butSearch_Click"
                    Width="80px" /></div>
            <div style="width: 130px; float: left; margin: 0 auto; height: 25px;" align="right">
            </div>
            <div style="margin: 0 auto; height: 25px; padding-left: 135px;">
                <a href="/Administrator/Default.aspx?ctrl=AddRestaurant"><span style="color: #0066cc">
                    Add New Restaurant</span></a>
            </div>
        </div>
    </div>
    <div style="width: 98%; text-align: center; color: White; font-size: 20px;">
        <asp:Label ID="lblMess" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <table width="97%" style="margin: 0 auto;">
        <tr>
            <td style="width: 100%;">
                <asp:GridView ID="grvRestaurant" runat="server" AutoGenerateColumns="False" ForeColor="White"
                    HorizontalAlign="Center" PageSize="5" Width="100%" OnRowDataBound="grvRestaurant_RowDataBound"
                    OnRowCommand="grvRestaurant_RowCommand">
                    <RowStyle Height="25px" HorizontalAlign="Left" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="Restaurant Name" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Label ID="lblnameRes" ForeColor="#0066cc" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="FullName" HeaderText="Member Name">
                            <ItemStyle ForeColor="black" HorizontalAlign="Left" Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DateOpen" HeaderText="Date Opened">
                            <ItemStyle ForeColor="black" HorizontalAlign="Left" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                        <asp:BoundField DataField="CountryName" HeaderText="Country">
                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StateName" HeaderText="State">
                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="City" DataField="CityName" />
                        <asp:BoundField HeaderText="Accept Credit Card" DataField="AcceptCreditCard">
                            <ItemStyle ForeColor="black" Width="90px" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtReservation" CommandArgument='<%# Eval("ID") %>' runat="server"
                                    ImageUrl="~/Media/Images/icon_02.jpg" Visible=false CommandName="ibtnResevation" Width="15px" />
                                <asp:HyperLink ID="hlkReservation" runat="server" >
                                <img src="/Media/Images/icon_02.jpg" border="0" /></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="dropStatus" runat="Server" Width="100%">
                                    <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Reject"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdfStatus" Value='<%# Eval("IsActive") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approve">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkApprove" ForeColor="#0066cc" CommandArgument='<%# Eval("ID")%>'
                                    CommandName="ApproveUpdate" runat="server">Update</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Log As">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkLogAs" ForeColor="#0066cc" CommandArgument='<%# Eval("ID")%>'
                                    CommandName="LogAsThisRestaurant" runat="server">LogAs</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" ForeColor="Black" />
                    <HeaderStyle BackColor="#CCCCCC" Height="30px" ForeColor="Black" />
                    <FooterStyle ForeColor="Black" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100%" align="right">
                <asp:Label ID="lblPage" Font-Bold="true" ForeColor="black" Visible="false" Text="Page :  "
                    runat="server"></asp:Label>
                <asp:DropDownList ID="dropPage" AutoPostBack="true" Visible="false" runat="server"
                    Width="70px" OnSelectedIndexChanged="dropPage_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<br />
