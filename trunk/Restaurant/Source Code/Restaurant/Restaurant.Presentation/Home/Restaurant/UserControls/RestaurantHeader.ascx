<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantHeader.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.UserControls.RestaurantHeader" %>
<div id="pageHeader">
 	<div class="blast_header">
		<div class="blast_header_left"></div>
		<div class="blast_header_center"> Restaurant</div>
		<div class="blast_header_right"></div>
	</div>
	<div class="page_header_rate">
		<div class="page_rate">
			<div class="page_rate_title">
				
			    <asp:DataList ID="dtlHeaderRestaurantInfo" runat="server">
			           <HeaderTemplate>
			           
			           </HeaderTemplate>
			           <ItemTemplate>
			                <div class="page_rate_retaurant_name"><asp:Label ID="lblRestaurantInfoName" runat="server" Text='<%#Eval("Name")%>'></asp:Label> </div>
				<div class="page_rate_retaurant_info">
					<div class="page_rate_retaurant_detail">
						<div class="page_rate_retaurant_detail1"><asp:Label ID="lblAddressInfo" runat="server" Text='<%#Eval("Address") %>'></asp:Label></div>
						<div class="page_rate_retaurant_detail1">
							<div class="page_rate_retaurant_phone">phone:</div>
							<div class="page_rate_retaurant_phone_detail"><asp:Label ID="lblPhoneInfo" runat="server" Text='<%#Eval("Phone") %>'></asp:Label></div>
						</div>
						<div class="page_rate_retaurant_detail1">
							<div class="page_rate_retaurant_phone">fax  :</div>
							<div class="page_rate_retaurant_phone_detail"><asp:Label ID="lblFaxInfo" runat="server" Text='<%#Eval("Fax") %>'></asp:Label></div>
						</div>
						<div class="page_rate_retaurant_detail1">
							<div class="page_rate_retaurant_phone">website:</div>
							<div class="page_rate_retaurant_phone_detail"><asp:Label ID="lblWebSite" runat="server" Text='<%#Eval("Website") %>'></asp:Label></div>
						</div>
					</div>
					<div class="page_rate_retaurant_detail_right">
						<div class="page_rate_retaurant_detail_right1">
							<div class="page_rate_retaurant_detail_cuisine">Cuisine</div>
							<div class="page_rate_retaurant_detail_cuisine1"><asp:Label ID="lblCuisineInfo" runat="server" Text='<%#Eval("CuisineName") %>'></asp:Label></div>
						</div>
						
						<div class="page_rate_retaurant_detail_right1">
							<div class="page_rate_retaurant_detail_cuisine">Neighborhood:</div>
							<div class="page_rate_retaurant_detail_cuisine1"><asp:Label ID="lblNeighborhood" runat="server" Text='<%#Eval("Neighborhood") %>'></asp:Label></div>
						</div>
						
					</div>
				</div>
			           </ItemTemplate>
                </asp:DataList>
				
			</div>
	  </div>
		<div class="page_rate_right">
			<div class="page_rate_right_header">	
			</div>
			<div class="page_rate_right_center">
				<div class="page_rate_tip">Rate tip </div>
				<div class="page_rate_tip_right">
					<div class="page_rate_tip_right1">1-2 :poor </div>
					<div class="page_rate_tip_right2">3-4 :normal </div>
					<div class="page_rate_tip_right3">5-6 :good </div>
				</div>
			</div>
			<div class="page_rate_right_footer">	
			</div>
		</div>
	</div>
	<div class="page_header_button">
	    <asp:Panel runat="server" ID="pnReview">
		    <div class="page_header_menu_review">
		        <asp:HyperLink ID="lnkReview" runat="server" Text="Review"></asp:HyperLink>
		    </div>
		</asp:Panel>
		<asp:Panel runat="server" ID="pnMenu">
		    <div class="page_header_menu_review">
		        <asp:HyperLink ID="lnkMenu" runat="server" Text="Menu"></asp:HyperLink>
		    </div>
		</asp:Panel>
		<asp:Panel runat="server" ID="pnPhoto">
		    <div class="page_header_menu_review">
		        <asp:HyperLink ID="lnkPhoto" runat="server" Text="Photo"></asp:HyperLink>
		    </div>
	    </asp:Panel>
	    <asp:Panel runat="server" ID="pnVideo">
		    <div class="page_header_menu_review"><asp:HyperLink ID="lnkVideo" runat="server" Text="Video"></asp:HyperLink></div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnEvent">		    
		    <div class="page_header_menu_review"><asp:HyperLink ID="lnkEvent" runat="server" Text="Event"></asp:HyperLink></div>
		</asp:Panel>
		<asp:Panel runat="server" ID="pnMap">    
		    <div class="page_header_menu_review"><asp:HyperLink ID="lnkMap" runat="server" Text="Map"></asp:HyperLink></div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnGift">		    
		    <div class="page_header_menu_review"><asp:HyperLink ID="lnkGift" runat="server" Text="Gift"></asp:HyperLink></div>
		</asp:Panel>
		<asp:Panel runat="server" ID="pnReservation">    
		    <div class="page_header_menu_review"><asp:HyperLink ID="lnkReservation" runat="server" Text="Reservation"></asp:HyperLink></div>
		</asp:Panel>   
    		
	</div>
</div>