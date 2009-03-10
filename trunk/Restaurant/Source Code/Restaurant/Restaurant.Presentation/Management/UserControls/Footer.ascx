<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Restaurant.Presentation.Member.UserControls.Footer" %>
<div id="footer">
    <%--<div class="footer" style="background: #2b3840; background-repeat: no-repeat; width: 100%;
        height: 45px; padding-top: 10px; margin-top: 100%;">--%>
        <ul>
            <li class="init">
               <br /> <asp:HyperLink runat="server" ID="ftLnkHome" Text="Home"></asp:HyperLink></li>
            <li><a href="#">Search Restaurant </a></li>
            <li>
                <asp:HyperLink runat="server" ID="ftLnkRestaurantOwnerProgram" Text="Restaurant Owner Program "></asp:HyperLink></li>
            <li><a href="#">Job Portal </a></li>
            <li><a href="#">Video </a></li>
            <li><a href="#">Contact Us </a></li>
            <li><a href="#">Privacy Policy </a></li>
            <li><a href="#">About Us </a></li>
            <li><a href="#">PodCast </a><span>
                <br />
                <br />
                <span style="text-align: center; ">Copyrights 212Cuisine.com </span>
            </span></li>
        </ul>
    <%--</div>--%>
</div>
