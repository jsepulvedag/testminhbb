<%@ Control Language="C#" AutoEventWireup="true" Codebehind="EditPhoto.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Photo.EditPhoto" %>
<style type="text/css">
    .text
    {
        text-align:center;
    }
</style>
<div>

        <br />
        <div style="width: 98%; padding-left: 6px;">
            <asp:DataGrid ID="dgrEditPhoto" runat="server" AutoGenerateColumns="False" SkinID="BasicSkin"
                OnItemCommand="dgrEditPhoto_ItemCommand" OnItemDataBound="dgrEditPhoto_ItemDataBound">
                <Columns>
                    <asp:BoundColumn HeaderText="PhotoID" DataField="PhotoID" HeaderStyle-BackColor="#868686">
                        <HeaderStyle Width="100px" CssClass="text" Font-Bold="True" Height="25px" Font-Size="13px" />
                        <ItemStyle HorizontalAlign="Center" CssClass="text" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            <p style="text-align: center; font-size: 13px;">
                                <strong>Photo Name</strong></p>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <p style="text-align: center;">
                                <asp:TextBox ID="txtPhotoName" runat="server" Text='<%#Eval("PhotoName")%>' Width="98%"
                                    Height="100%" TextMode="MultiLine" /></p>
                        </ItemTemplate>
                        <HeaderStyle Width="200px" BackColor="#868686" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            <p style="text-align: center; font-size: 13px;">
                                Old Photo</p>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <p style="text-align: center;">
                                <asp:Image ID="imgPhoto" ImageUrl='<%#Eval("Image") %>' runat="server" Width="100px" /></p>
                        </ItemTemplate>
                        <HeaderStyle Width="100px" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                            BackColor="#868686" Font-Strikeout="False" Font-Underline="False" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderStyle-BackColor="#868686">
                        <HeaderTemplate>
                            <p style="text-align: center; font-size: 13px;">
                                <strong>Upload Photo</strong></p>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <p style="text-align: center;">
                                <asp:FileUpload ID="uploadPhoto" runat="server" /></p>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderStyle-BackColor="#868686">
                        <ItemTemplate>
                            <p style="text-align: center;">
                                <asp:LinkButton ID="lbEdit" runat="server" CommandName="_edit" Text="Edit" /></p>
                        </ItemTemplate>
                        <HeaderStyle Width="40px" />
                        <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="True" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderStyle-BackColor="#868686">
                        <ItemTemplate>
                            <p style="text-align: center;">
                                <asp:LinkButton ID="lbCancel" runat="server" CommandName="_cancel" Text="Cancel" /></p>
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="True" />
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </div>
</div>
