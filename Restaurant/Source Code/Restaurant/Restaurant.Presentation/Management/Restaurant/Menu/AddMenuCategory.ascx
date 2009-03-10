<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AddMenuCategory.ascx.cs"
    Inherits="Restaurant.Presentation.Management.Restaurant.Menu.AddMenuCategory" %>

<div >
    <table cellpadding="0" cellspacing="0" >
        <tr>
            <td style="width: 40px;">
            </td>
            <td style="width: 598px" >
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style=" padding-bottom: 10px; height: 24px;padding-top: 10px;" colspan="4">
                         <h3>  <strong> Add MenuCategory</strong></h3>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; padding-left: 10px;">
                            Name:</td>
                        <td colspan="3" style="height: 26px;padding-bottom: 5px;" >
                            <asp:TextBox ID="txtName" runat="server" Width="58%" /></td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px;text-align: left; ">
                            Description:</td>
                        <td colspan="3" style="height: 40px;padding-bottom: 5px;">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="91%" Text=""/></td>
                    </tr>
                    <tr>
                        <td style=" text-align: left; padding-left: 10px;">
                            Image:</td>
                        <td colspan="3" style=" padding-bottom: 5px;">
                            <asp:FileUpload ID="UplImage" runat="server" Width="85%" /></td>
                    </tr>
                    <tr>
                        <td style="  padding-left: 10px;text-align: left;">
                            Price Heading:</td>
                        <td style="width: 469px; height: 32px;padding-bottom: 5px;" colspan="3">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 9px; padding-bottom: 5px;padding-right:10px;">
                                        <asp:TextBox ID="txtPrHeading1" runat="server" Width="128px" Text=""/></td>
                                    <td style="width: 123px; padding-bottom: 5px;padding-right:10px;" >
                                        <asp:TextBox ID="txtPrHeading2" runat="server" Width="128px" Text=""/></td>
                                    <td style="width: 77px; padding-bottom: 5px;">
                                        <asp:TextBox ID="txtPrHeading3" runat="server" Width="128px" Text="" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 24px" >
                            &nbsp;</td>
                        <td style="width: 9px; height: 24px;">
                            <asp:Button ID="btnAdd" Text="Add" runat="server" OnClick="btnAdd_Click" Width="56px" /></td>
                        <td style="width: 9px; height: 24px">
                            <asp:Button ID="btnCancel" Text="Cancel" runat="server" Width="63px" OnClick="btnCancel_Click" /></td>
                        <td style="width: 63px; height: 24px;">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</div>
