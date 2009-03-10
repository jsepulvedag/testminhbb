<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListReviewRight.ascx.cs" Inherits="Restaurant.Presentation.Home.Restaurant.Review.ListReviewRight" %>
<div id="page_right">
	<div class="page_right_button">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Media/Images/writeReview.jpg" />
	</div>
	<div class="page_right_main_link" style="text-align:left; padding-left:12px;">
	    <div class="page_right_link">+         
            <asp:LinkButton ID="lnkOnlineOrdering" runat="server" >Online Ordering</asp:LinkButton>
        </div>
        <div class="page_right_link">+
            <asp:LinkButton ID="lnkOnlineReservation" runat="server"> Online Reservation</asp:LinkButton>
		</div>
	    <div class="page_right_link">+
            <asp:LinkButton ID="lnkAddWatchlist" runat="server">Add To Watchlist</asp:LinkButton>
		</div>	
		<div class="page_right_link">+ <asp:HyperLink ID="lnkContactRestaurant" 
                runat="server" Text="Contact Restaurant" ></asp:HyperLink>
        </div>
		<div class="page_right_link">+ 
		    <asp:LinkButton ID ="lnkRecommendToFriend" runat="server" Text="Recommend To Friend"></asp:LinkButton>
		</div>
		<div class="page_right_link">+
            <asp:LinkButton ID="lnkYourRestaurant" runat="server" 
                Text="Is this your Restaurant?" OnClick="lnkYourRestaurant_Click" ></asp:LinkButton>
        </div>
        <div class="page_right_link">+
            <asp:LinkButton ID="lnkReportError" runat="server" 
                Text="Report Error" ></asp:LinkButton>
        </div>
	</div>
	<div class="page_right_hr" >
	  <asp:Image ID = "imageHr" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" />
	</div>
	<div class="page_right_ads1">
	    <asp:ImageButton ID="ImageAds1" runat="server" 
            ImageUrl="~/Media/Images/map.jpg" />
	</div>
	<div class="page_right_main_cb">
		<div class="page_right_main_cb_box">
			<div class="page_right_main_cb_box1" style="text-align:left; padding-left:30px;">Find places near</div>
			<div class="page_right_main_cb_box1" style="text-align:left; padding-left:30px;">
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'></asp:Label></div>
			<div class="page_right_main_cb_box2" style="text-align:left; padding-left:50px;">
			  <label>
			  <input type="checkbox" name="checkbox" value="checkbox" />
			  Restaurants</label>
			</div>
			<div class="page_right_main_cb_box2" style="text-align:left; padding-left:50px;"><label>
			  <input type="checkbox" name="checkbox" value="checkbox" /> Nightlight</label></div>
			<div class="page_right_main_cb_box2" style="text-align:left; padding-left:50px;"><label>
			  <input type="checkbox" name="checkbox" value="checkbox" /> Hotels</label></div>
			<div class="page_right_main_cb_box2" style="text-align:left; padding-left:50px;"><label>
			  <input type="checkbox" name="checkbox" value="checkbox" />
			  Attractions</label>
				
			</div>
			<div class="page_right_main_cb_box3" style="text-align:right; padding-right:30px;"><asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/Media/Images/find.jpg" /></div>
		</div>
		<div class="page_right_hr">
		<asp:Image ID = "image1" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" />
		</div>
	</div>
	
	<div class="page_right_ads2">
        <asp:ImageButton ID="ImageButton4" runat="server" 
            ImageUrl="~/Media/Images/adv123.jpg" />
    </div>
</div>