<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeVideo.ascx.cs" Inherits="Restaurant.Presentation.Home.UserControls.HomeVideo" %>

<div id="pageVideoHome">
	<div class="pageVideoHome_header">
		
	</div>
	<div class="pageVideoHome_center">
	  	<div class="pageVideoHome_center_left">
			
		    <asp:DataList ID="dlVideo" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
		        <ItemTemplate>
		            <div class="pageVideoHome_center_left_image">
				        <asp:ImageButton ID="imgbtnVideo" runat="server" ImageUrl='~/Media/Images/viewVideo.jpg' />
			        </div>
			    <div class="pageVideoHome_center_left_image_below">
				    <div class="pageVideoHome_center_left_image_below_left">
					    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Media/Images/viewVideo.jpg" />
				    </div>
				<div class="pageVideoHome_center_left_image_below_right">
				        <asp:Label ID="lblVideo" runat="server" Text='nhatnv'></asp:Label>					
				</div>
			</div>	
		        </ItemTemplate>
            </asp:DataList>
			
		</div>
		<div class="pageVideoHome_center_right">	
		</div>
	</div>
	<div class="pageVideoHome_center_more"><a href="#">view more videos...</a>	  </div>
	<div class="pageVideoHome_footer"></div>
</div>