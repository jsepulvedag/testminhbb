<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TabBar.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.UserControls.TabBar" %>

<div id="formConntent">
    <div class="formContentCenter" style ="padding-left:20px;width:849px;padding-top:20px;padding-bottom:10px;">
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="background-image: url(../Media/Images/restaurant_review.jpg); width: 95px;
            height: 34px;" align="center">
           <p style="text-align:center; font-size:15px;"> 
            <asp:HyperLink ID="lbReview" runat="server"  >Review</asp:HyperLink> 
        </p></td>
        <td style="background-image: url(../Media/Images/restaurant_review.jpg);
            width: 95px; height: 34px;font-size:15px;" align="center">
        <p style="text-align:center;">  
             <asp:HyperLink ID="lbMenu" runat="server"  NavigateUrl="#">Menu</asp:HyperLink> 
           </p></td>
        <td style="font-size:15px;background-image: url(../Media/Images/restaurant_review.jpg);width: 95px;
             height: 34px;" align="center">
        <p style="text-align:center;">
        <asp:HyperLink ID="lbPhotos" runat="server">Photos</asp:HyperLink> 
        </p></td>
        <td style="font-size:15px;background-image: url(../Media/Images/restaurant_review.jpg);width: 95px;
            height: 34px;" align="center">
         <p style="text-align:center;">     
          <asp:HyperLink ID="lbVideo" runat="server"  NavigateUrl="~/Default.aspx?pid=Video">Video</asp:HyperLink>
         </p></td>
        <td style="font-size:15px;background-image: url(../Media/Images/restaurant_review.jpg);width: 95px;
            " align="center">
           <p style="text-align:center;">   
                     <asp:HyperLink ID="lbEvents" runat="server"  NavigateUrl="#">Events</asp:HyperLink>
           </p></td>
        <td style="font-size:15px;background-image: url(../Media/Images/restaurant_review.jpg);width: 95px;
             height: 34px;" align="center">
           <p style="text-align:center;">  
             <asp:HyperLink ID="lbMap" runat="server"  NavigateUrl="#">Map</asp:HyperLink>
           </p>
        </td>
        <%--<td style="font-size:15px;background-image: url(../Media/Images/restaurant_review.jpg);width: 95px;
             height: 34px;" align="center">
           <p style="text-align:center;">  
             <asp:HyperLink ID="lbGift" runat="server"  NavigateUrl="#">Gift</asp:HyperLink>
           </p>
        </td>--%>
        <td valign="bottom"> </td>
    </tr>
</table>
</div></div>
