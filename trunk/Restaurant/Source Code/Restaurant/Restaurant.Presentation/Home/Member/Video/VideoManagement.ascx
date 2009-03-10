<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VideoManagement.ascx.cs"
    Inherits="Restaurant.Presentation.Home.Member.Video.VideoManagement" %>

<%@ Register Src="ListVideo.ascx" TagName="ListVideo" TagPrefix="uc2" %>
<div id="formConntent">
   
<table style="width:869px; " >
    <tr>
        <td valign="top" style="width:619px; " rowspan="2">
       <asp:DataList ID="dtlVideo" runat="server">
            <ItemTemplate>
        <table style="width: 100%" >
                    <tr >
                        <td colspan="2" >
                            <object id="VIDEO"  
                                classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" type="application/x-oleobject" width="400px" height="300px">
                                <param name="URL" value='<%#Eval("VideoPath") %>' />
                                <param name="SendPlayStateChangeEvents" value="True" />
                                <param name="AutoStart" value="True" />
                                <param name="uiMode" value="full" />
                                <param name="PlayCount" value="9999" />
                            </object>                        </td>
                      
                    </tr>
                    <tr>
                        <td>
                            <%#Eval("Title") %>                        </td>
                        <td>&nbsp;                            </td>
                    </tr>
                    <tr>
                        <td>
                            <%#Eval("Description") %>                        </td>
                        <td>&nbsp;                            </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        </td>
        <td valign="top" style="width:250px;" rowspan="2">
       &nbsp;<uc2:ListVideo ID="ListVideo1" runat="server" />
        </td>
    </tr>
    <tr>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
</table>
</div>