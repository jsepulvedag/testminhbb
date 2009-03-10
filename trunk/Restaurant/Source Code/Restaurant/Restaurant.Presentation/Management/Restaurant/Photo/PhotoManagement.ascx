<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PhotoManagement.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Restaurant.Photo.PhotoManagement" %>
<%@ Register Src="../../../Home/Restaurant/RestaurantDetail/RestaurantDetail.ascx"
    TagName="RestaurantDetail" TagPrefix="uc1" %>
<style type="text/css">
    .text
    {
        text-align:center;
        
    }
</style>

<div >

        <br />&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbAdd" runat="server" Text="Add" OnClick="lbAdd_Click1"
            Font-Bold="True" Font-Size="14px" Font-Underline="True" />
        <p />
        <br />
        <div style="padding-left:6px;">
        <asp:DataGrid ID="dgrListPhoto" runat="server" AutoGenerateColumns="False" SkinID="BasicSkin"
            OnItemCommand="dgrListPhotos_ItemCommand" Width="649px">
            <Columns>
                <asp:BoundColumn HeaderText="Restaurant" DataField="RestaurantName" HeaderStyle-BackColor="#868686">
                    <HeaderStyle Width="200px" CssClass="text" Font-Bold="True" Height="25px" Font-Size="13px"  />
                    <ItemStyle HorizontalAlign="Center" CssClass="text" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Name" DataField="PhotoName" HeaderStyle-BackColor="#868686">
                    <HeaderStyle Width="400px" CssClass="text" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="13px"
                        Font-Strikeout="False" Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" CssClass="text" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderStyle-BackColor="#868686" >
                    <HeaderTemplate>
                        <p style="text-align: center; font-size: 13px;">
                            Photo</p>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <p style="text-align: center; font-size: 13px;">
                            <asp:Image ID="imgPhoto" ImageUrl='<%#Eval("Image") %>' runat="server" Width="120px" /></p>
                    </ItemTemplate>
                    <HeaderStyle Width="120px" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                        Font-Strikeout="False" Font-Underline="False" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <p style="text-align: center;">
                            <asp:LinkButton ID="lbEdit" runat="server" PostBackUrl='<%#"~/Management/Default.aspx?mid=EditPhoto&PhotoID="+ Eval("PhotoID")+"&RestaurantID="+Eval("RestaurantID")%>'
                                Text="Edit" /></p>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" BackColor="#868686"/>
                    <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="True" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <p style="text-align: center;">
                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="_delete" CommandArgument='<%#Eval("PhotoID") %>'
                                OnClientClick="return confirm('Do you want to Delete photo?')">Delete</asp:LinkButton>
                        </p>
                    </ItemTemplate>
                    <HeaderStyle Width="70px" BackColor="#868686" />
                    <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="True" />
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
        </div>

</div>
