<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoManagement.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Video.VideoManagement" %>


<style type="text/css">
    .text
    {
        text-align:center;
        
    }
</style>

<div id="Video" runat="server" visible="true">

        <br />&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbAdd" runat="server" Text="Add" 
            Font-Bold="True" Font-Size="14px" Font-Underline="True" OnClick="lbAdd_Click" />
        <p />
        <br />
        <div style="padding-left:6px;">
        <asp:DataGrid ID="dgrListVideo" runat="server" AutoGenerateColumns="False" SkinID="BasicSkin"
             Width="649px" OnItemCommand="dgrListVideo_ItemCommand" OnSelectedIndexChanged="dgrListVideo_SelectedIndexChanged">
            <Columns>
                <asp:BoundColumn HeaderText="Restaurant" DataField="RestaurantName" HeaderStyle-BackColor="#868686">
                    <HeaderStyle Width="200px" CssClass="text" Font-Bold="True" Height="25px" Font-Size="13px"  />
                    <ItemStyle HorizontalAlign="Center" CssClass="text" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Title" DataField="Title" HeaderStyle-BackColor="#868686">
                    <HeaderStyle Width="100px" CssClass="text" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="13px"
                        Font-Strikeout="False" Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" CssClass="text" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Description" DataField="Description" HeaderStyle-BackColor="#868686">
                    <HeaderStyle Width="200px" CssClass="text" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="13px"
                        Font-Strikeout="False" Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" CssClass="text" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderStyle-BackColor="#868686" >
                    <HeaderTemplate>
                        <p style="text-align: center; font-size: 13px;">
                            Video</p>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <p style="text-align: center; font-size: 13px;">
                            <asp:Image ID="imgPhoto" ImageUrl='<%#Eval("Picture") %>' runat="server" Width="120px" />
                           
                        </p>
                    </ItemTemplate>
                    <HeaderStyle Width="120px" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                        Font-Strikeout="False" Font-Underline="False" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <p style="text-align: center;">
                            <asp:LinkButton ID="lbEdit" runat="server" CommandName="_edit" CommandArgument='<%#Eval("VideoID") %>'
                              Text="Edit" /></p>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" BackColor="#868686"/>
                    <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="True" />
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <p style="text-align: center;">
                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="_delete" CommandArgument='<%#Eval("VideoID") %>'
                                OnClientClick="return confirm('Do you want to Delete video?')">Delete</asp:LinkButton>
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
<asp:Panel ID="pnADD" runat="server" Visible="false" >
            <span style="margin-left:20px;"><asp:Label ID="lblVideo" runat="server" ForeColor="Red" Visible="False"></asp:Label></span>
            <br />
           <span style="margin-left:20px;"> <asp:Label ID="lblPhoto" runat="server" ForeColor="Red" Visible="False"></asp:Label></span>
        <div style=" padding-left: 6px;">
            <table style="width: 100%; color:White;">
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                       Title</td>
                    <td style="width: 215px;">
                        <asp:TextBox ID="txtTitle" runat="server" Text="" Width="212px"/></td>
                </tr>
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                       Description</td>
                    <td style="width: 215px;">
                        <asp:TextBox ID="txtDescription" runat="server" Text="" Width="212px"/></td>
                </tr>
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                        Picture</td>
                    <td style="width: 215px">
                        <asp:FileUpload Width="200px" ID="uploadPhoto" runat="server" /></td>
                </tr>
                   <tr>
                    <td style="width: 100px; padding-left:10px;">
                        Video</td>
                    <td style="width: 215px">
                        <asp:FileUpload Width="200px" ID="upLoadVideo" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 26px;">
                    </td>
                    <td style="width: 215px; height: 26px;">
                        <asp:Button runat="server" ID="btnOK" Text="Add Video" Width="85px" OnClick="btnOK_Click" />
                        <asp:Button runat="server" ID="btnCancel" Text="Cancel"  Width="85px" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
        </div>

</asp:Panel>
&nbsp;

<asp:Panel ID="pnEdit" runat="server" Visible="true" >
<span style="margin-left:20px;"><asp:Label ID="lblEditPhoto" runat="server" ForeColor="Red" Visible="False"></asp:Label></span>
            <br />
           <span style="margin-left:20px;"> <asp:Label ID="lblEditVideo" runat="server" ForeColor="Red" Visible="False"></asp:Label></span>
        
        <div style=" padding-left: 6px;">
        <table style="width: 100%; color:White;">
        <asp:DataList ID="dtlEdit"  runat="server"  OnItemCommand="dtlEdit_OnItemCommand">
        <ItemTemplate>
       
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                       Title</td>
                    <td style="width: 215px;">
                        <asp:TextBox ID="uploadTitle" runat="server" Text='<%#Eval("Title") %>' Width="212px"/></td>
                </tr>
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                       Description</td>
                    <td style="width: 215px;">
                        <asp:TextBox ID="uploadDescription" runat="server" Text='<%#Eval("Description") %>' Width="212px"/></td>
                </tr>
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                        Picture</td>
                    <td style="width: 215px">
                        <asp:FileUpload Width="200px" ID="uploadPicture" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                       Old Picture</td>
                    <td style="width: 215px">
                      <asp:Image ID="imgPhoto" ImageUrl='<%#Eval("Picture") %>' runat="server" Width="100px" /></td>
                </tr>
                   <tr>
                    <td style="width: 100px; padding-left:10px;">
                        Video</td>
                    <td style="width: 215px">
                        <asp:FileUpload Width="200px" ID="uploadVideo" runat="server" ></asp:FileUpload></td>
                </tr>     
                <tr>
                    <td style="width: 100px; height: 26px;">
                    <td style="width: 215px; height: 26px;">
                        <asp:Button runat="server" ID="Update" Text="Update" Width="85px" OnClick="Update_Click" CommandName="update" CommandArgument='<%#Eval("VideoID") %>' />
                        <asp:Button runat="server" ID="Cancel" Text="Cancel"  Width="85px" OnClick="Cancel_Click"  />
        </ItemTemplate>
        </asp:DataList></table>
        </div>

</asp:Panel>