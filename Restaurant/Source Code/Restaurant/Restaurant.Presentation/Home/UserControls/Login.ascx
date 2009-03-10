<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Restaurant.Presentation.Home.UserControls.Login" %>
<div id="pagelogin">
	<div id="left_content_login">
		<div class="login_box">
			<div class="blast_login">
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            </div>
			<div class="content_login_box">
			<div class="content_login_form">
			
				<div class="content_form_left">Username&nbsp;&nbsp; </div>
				<div class="content_form_right">
				  <asp:TextBox ID="txtUsername" runat="server" Width="125px"></asp:TextBox>
				</div>
			</div>
			<div class="content_login_form">
				<div class="content_form_left">Password&nbsp;&nbsp; </div>				
				<div class="content_form_right">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="125px"></asp:TextBox>
                        </div>
			</div>
						
			<div class="content_login_form">
				<div class="content_form_left"></div>
				<div class="content_form_right"  style="padding-top:15px">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#">Forgot your password?</asp:HyperLink>
                </div>
			</div>
			<div class="content_login_form">
				<div class="content_form_right" style="padding-top:10px;">
                    <asp:ImageButton ID="ibtnLogIn" runat="server" 
                        ImageUrl="~/Media/Images/Login_r8_c5.jpg" OnClick="ibtnLogIn_Click"  />
                </div>
                <%--#A90F0F--%>
                <div class="content_login_form" style="padding-top:10px; margin-left:20px !important; margin-left:10px; text-align:center; color:Yellow; font-size:14px; width:300px;"> 
                    <asp:Label ID="lblAlert" runat="server" Text="* Invalid username or password, please try again !" Width="100%" Font-Bold="False" Font-Italic="True"></asp:Label>
                    <asp:Label ID="lblError" runat="server" Text="* Sorry your account is inactive!" Width="100%" Font-Bold="False" Font-Italic="True" Visible="false"></asp:Label>

                </div>
			</div>
		
			</div>
			<div class="bottom_bg"></div>		
		</div>
		<div class="ads_box">
            <asp:Image ID="Image1" runat="server" 
                ImageUrl="~/Media/Images/Login_r15_c4.jpg"/>
            </div>
		
	</div>
	
	<div id="right_content_login" >
		<div class="blast_right_content">
		</div>
		
		<!---->
		<div id="right_content_temple">
			<div id="right_content_bg">
				<div class="blast_text">
					<div class="blast_left_text">
					<p>&nbsp;</p>
					  <p>not a member? join over 900.000 other registered users. </p>
					</div>
					<div class="blast_right_text">
					  <p>&nbsp;</p>
					  <p>you have a restaurant and you want to promote it to every one? </p>
					</div>
				</div>
					
				<div class="register_box">
					<div class="register_left"><a href="#">Sign up today for free</a></div>
					<div class="register_right"><a href="#">Registered here</a></div>
				</div>
					
				<div class="register_image">
					<div class="register_image_left">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Media/Images/Login_r10_c9.jpg"/>
                    </div>
					<div class="register_image_right">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Media/Images/Login_r10_c11.jpg"/>
                    </div>
			  </div>
				<div class="signup_below">
					<div class="signup_button">
						<div class="signup_button_left">				
						  <asp:ImageButton ID="btnSignup" runat="server" 
                                ImageUrl="~/Media/Images/Login_r16_c10.jpg" OnClick="btnSignup_Click" />
						</div>
						<div class="signup_button_right">
                            <asp:ImageButton ID="btnRegister" runat="server" 
                                ImageUrl="~/Media/Images/Login_r16_c14.jpg" OnClick="btnRegister_Click" />
                        </div>
					</div>
				</div>
			</div>
			<div class="signup_bottom"></div>
			
		</div>
		
		
	</div>
</div>