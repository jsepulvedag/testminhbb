<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AddPhoto.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Photo.AddPhoto" %>
<style type="text/css">
    .text
    {
        text-align:center;
    }
</style>
<div>
        <br />
        <div style="width: 98%; padding-left: 6px;">
            <table style="width: 100%; color:White;">
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                        Photo Name</td>
                    <td style="width: auto;">
                        <asp:TextBox ID="txtPhotoName" runat="server" Text="" Width="212px"/></td>
                </tr>
                <tr>
                    <td style="width: 100px; padding-left:10px;">
                        Photo Image</td>
                    <td style="width: auto">
                        <asp:FileUpload Width="200px" ID="uploadPhoto" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: auto">
                        <asp:Button runat="server" ID="btnOK" Text="Add Photo" OnClick="btnOK_Click" Width="85px" />
                        <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" Width="85px" /></td>
                </tr>
            </table>
        </div>
</div>
