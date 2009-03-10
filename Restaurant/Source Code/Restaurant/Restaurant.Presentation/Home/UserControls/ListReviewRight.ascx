<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListReviewRight.ascx.cs" Inherits="Restaurant.Presentation.Home.UserControls.ListReviewRight" %>
<div id="page_right">
	<div class="page_right_button" style="text-align:center;">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Media/Images/writeReview.jpg" OnClick="ImageButton1_Click" />
	</div>
	<div class="page_right_main_link" style="text-align:left; padding-left:15px;">
	    <div class="page_right_link">+         
            <asp:LinkButton ID="lbtGiftCertificate" runat="server" Text="Gift Certificate" OnClick="lbtGiftCertificate_Click" CausesValidation="False"></asp:LinkButton>
        </div>
	    <div class="page_right_link">+         
            <asp:LinkButton ID="lbtOnlineOrdering" runat="server" Text="Online Ordering" OnClick="lbtOnlineOrdering_Click" CausesValidation="False"></asp:LinkButton>
        </div>
        <div class="page_right_link">+
            <asp:LinkButton ID="lbtOnlineReservation" runat="server" Text="Online Reservation" OnClick="lbtOnlineReservation_Click" CausesValidation="False"></asp:LinkButton>
		</div>
	    <div class="page_right_link">+
            <asp:LinkButton ID="lbtAddWatchlist" runat="server" Text="Add To Watchlist" CausesValidation="False" OnClick="lbtAddWatchlist_Click"></asp:LinkButton>
            <%--<asp:Label ID="lblAddWatchlist" runat="server" Visible="false" Text=""></asp:Label>--%>
		</div>	
		<div class="page_right_link">+ 
		    <asp:LinkButton ID="lbtContactRestaurant" 
                runat="server" Text="Contact Restaurant" CausesValidation="False" OnClick="lbtContactRestaurant_Click" ></asp:LinkButton>
        </div>
		<div class="page_right_link">+ 
		    <asp:LinkButton ID ="lbtRecommendToFriend" runat="server" Text="Recommend To Friend" CausesValidation="False" OnClick="lbtRecommendToFriend_Click"></asp:LinkButton>
		</div>
		<div class="page_right_link">
            <asp:LinkButton ID="lbtYourRestaurant" runat="server" 
                Text="+ Is this your Restaurant?" OnClick="lbtYourRestaurant_Click" CausesValidation="False"></asp:LinkButton>
        </div>
        <div class="page_right_link">+
            <asp:LinkButton ID="lbtReportError" runat="server" 
                Text="Report Error" CausesValidation="False" ></asp:LinkButton>
        </div>
	</div>
	<div class="page_right_hr" style="text-align:center;" >
	  <asp:Image ID = "imageHr" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" />
	</div>
	<div class="page_right_ads1" style="text-align:center;">
        &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" 
            ImageUrl="~/Media/Images/adv123.jpg" /></div>
	<div class="page_right_main_cb">
		<div class="page_right_main_cb_box">
			<%--<div class="page_right_main_cb_box1" style="text-align:left; padding-left:30px;">Find places near</div>
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
            ImageUrl="~/Media/Images/find.jpg" /></div>--%>
		</div>
		<div class="page_right_hr" style="text-align:center;">
		<asp:Image ID = "image1" runat ="server" ImageUrl = "~/Media/Images/hr.jpg" />
		</div>
	</div>
	<br /><br />
	<div class="page_right_ads2" style="text-align:center;">
        &nbsp;</div>
</div>