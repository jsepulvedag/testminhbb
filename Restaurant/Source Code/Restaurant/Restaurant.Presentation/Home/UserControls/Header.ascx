<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Restaurant.Presentation.Home.UserControls.Header" %>
<div id="Header">
    <div class="headerTop"></div>	
	<div id="headerTopText" >
	    
		<div class="headerLogin" >
            <asp:HyperLink ID="lnkBtnLogin" runat="server">Login</asp:HyperLink></div>
		<div class="headerCreateAccount" >
		    <asp:HyperLink ID="lnkBtnViewProfile" runat="server">Create new account |</asp:HyperLink>
		</div>
		<div class="headerNewUser"><asp:Label ID="lblHi" runat="server" Text=""></asp:Label>
		</div>
		<div style=" height:20px; padding-right:5px; width:100px; float:right;">
	        <asp:DropDownList ID="drpCity" runat="server" Visible="true" Height="20px" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="drpCity_SelectedIndexChanged"></asp:DropDownList>
	    </div>
	   
	</div>
	<div class="headerCuisine"></div>	
	<div id="headerTextBottom" >
		<div class="headerTextEmpty"></div>
		<div class="headerTextFeature"><asp:HyperLink ID="lnkFeature" runat="server" Text="Features"></asp:HyperLink></div>
		<div class="headerTextBlog" ><a href ="#">Blogs</a>.</div>
		<div class="headerTextVideo" ><a href="#">Video</a>.</div>
		<div class="headerTextDeal" ><a href="#">Deals</a>.</div>
	</div>
</div>

<div id="menu" style="padding-bottom:3px;" >
    <div id="menuTextMain" >
			<div class="menuHome" >
			    <asp:HyperLink ID="lnkHome"  runat="server" Text="HOME" ForeColor="Black" ></asp:HyperLink>
			</div>
			<div class="menuRestaurantOwner" >
			    <asp:HyperLink ID="lnkRestaurantOwnerProgram" runat="server" Text="RESTAURANT OWNER PROGRAM" ForeColor="Black"></asp:HyperLink>			
			</div>
			<div class="menuVideo " >
			    <asp:HyperLink ID="lnkVideo" runat="server" Text="VIDEO" ForeColor="Black"></asp:HyperLink>
			</div>
		
			<div class="menuPodCast" >
			    <asp:HyperLink ID="HyperLink1" runat="server" Text="PODCAST" ForeColor="Black"></asp:HyperLink>
			</div>
			<div class="menuMobile">
			<asp:HyperLink ID="HyperLink2" runat="server" Text="MOBILE" ForeColor="Black"></asp:HyperLink>
			</div>
			<div class="menuEthnic" >
			<asp:HyperLink ID="HyperLink3" runat="server" Text="ETHNIC STORES" ForeColor="Black"></asp:HyperLink>
			</div>
			
			<div class="menuJob">
			<asp:HyperLink ID="HyperLink4" runat="server" Text="JOB PORTAL" ForeColor="Black"></asp:HyperLink>
			</div>
			<div class="menuContact" >
			    <asp:HyperLink ID="lnkContactUs" runat="server" Text="CATERING" ForeColor="Black"></asp:HyperLink>
			</div>
		</div>
</div>