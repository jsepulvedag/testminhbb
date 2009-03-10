<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Video.ascx.cs" Inherits="Restaurant.Presentation.Home.Member.Video.Video" %>
<%@ Register Assembly="ASPNetFlashVideo.NET2.AJAX" Namespace="ASPNetFlashVideo" TagPrefix="ASPNetFlashVideo" %>
<%@ Register Src="ListVideo.ascx" TagName="ListVideo" TagPrefix="uc2" %>
<div id="formConntent">
    <table style="width: 869px; margin-top: 20px;" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top" style="width: 619px;" rowspan="2">
                <object type="video/x-ms-wmv" height="300px" width="480px">
                    <param name="src" value="" id="prmSrc" runat="server" />
                </object>
                <br />
                <br />
                <asp:DataList ID="dtlVideo" runat="server" OnItemDataBound="dtlVideo_ItemDataBound"
                    Width="449px">
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("VideoPath")%>' Visible="false"></asp:Label>
                                    <h2>
                                        <strong>
                                            <%#Eval("Title") %>
                                        </strong>
                                    </h2>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 60%;">
                                    <%#Eval("Description") %>
                                </td>
                                <td align="right">
                                    Added:
                                    <%#Eval("UploadedDate") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td valign="top" rowspan="2">
                &nbsp;<uc2:ListVideo ID="ListVideo1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
</div>
