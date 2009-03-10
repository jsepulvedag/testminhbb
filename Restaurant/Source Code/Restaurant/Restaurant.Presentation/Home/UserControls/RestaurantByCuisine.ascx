<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantByCuisine.ascx.cs" Inherits="Restaurant.Presentation.Home.UserControls.RestaurantByCuisine" %>

<div id="pageCuisineHome">
	<div class="pageCuisineHome_header">
	    
	</div>
	
	<div class="pageCuisineHome_center">
	  <asp:Repeater ID="rptRestaurantInCuisine" runat="server" OnItemDataBound="rptRestaurantInCuisine_ItemDataBound">
	       <ItemTemplate>
	       <div class="pageCuisineHome_center_left">
	            <asp:HyperLink ID="hplListRestaurant" Text='<%#Eval("Name") %>' runat="server" ></asp:HyperLink>
	        </div>
	      </ItemTemplate>
	 
        </asp:Repeater>
	  
	</div>
	<div class="pageCuisineHome_center_more"><a href="#">More Cuisine...</a></div>
	<div class="pageCuisineHome_footer">
	</div>
</div>