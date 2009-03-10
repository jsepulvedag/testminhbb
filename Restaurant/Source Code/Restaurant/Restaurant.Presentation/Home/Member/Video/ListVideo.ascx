<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListVideo.ascx.cs" Inherits="Restaurant.Presentation.Home.Member.Video.ListVideo" %>

<asp:Image ID="TopVideo" runat="server" ImageUrl="~/Media/Images/video2_2_1.jpg" />   

<asp:DataList ID="dtlListVideo" runat="server" Width="26%" RepeatLayout="Table" RepeatColumns="1" RepeatDirection="Horizontal" OnItemCommand="dtlListVideo_ItemCommand"  OnItemDataBound="dtlListVideo_ItemDataBound" >
    <ItemTemplate>
        <table  width="100%"> 
            <tr>
                <td rowspan="3" style="width:120px;">
              <span style="margin-left:7px;">  <asp:ImageButton ID="imgVideo" runat="server" ImageUrl='<%#Eval("Picture") %>' Width="120px" Height="100px" CommandArgument='<%#Eval("VideoID")%>' CommandName="picture"/></span>
                </td>
                <td rowspan="3" style="width:10px;"></td>
                <td >
              saowefffwefweee
                </td>
            </tr>
            <tr>
                <td>   <%#Eval("Title") %>
                </td>
            </tr>
            <tr >
                <td >
                 <asp:Label ID="lblDescription" runat="server" /><asp:HyperLink ID="hplMore" runat="server" Text="...MORE" ForeColor="#C04000"></asp:HyperLink>
                                 <asp:Label ID="lblDes" runat="server" Text=' <%#Eval("Description") %>' Visible="false"/> 
                </td>
            </tr>
        </table>
   </ItemTemplate>
    <FooterTemplate>
    <span style="margin-left:235px;"><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/Media/Images/video2_2_4.jpg"></asp:ImageButton></span>
    </FooterTemplate>
    <ItemStyle Width="250px"/>
    <FooterStyle  HorizontalAlign="Right" VerticalAlign="Bottom"/>
</asp:DataList>

