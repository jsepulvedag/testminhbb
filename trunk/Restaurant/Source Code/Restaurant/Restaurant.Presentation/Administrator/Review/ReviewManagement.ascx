<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ReviewManagement.ascx.cs"
    Inherits="Restaurant.Presentation.Administrator.Review.ReviewManagement" %>
<%@ Register Assembly="RadGrid.Net2" Namespace="Telerik.WebControls" TagPrefix="radG" %>
<style type="text/css">
    .text
    {
       /* text-align:center; */
        
    }
</style>
<table style="width: 98%; margin: 0 auto; font-family: Tahoma; font-size: 12px;">
    <tr>
        <td style="width: 100%; color: Red;" align="center">
            <asp:Label ID="lblMessage" runat="server" Text="Don't have member review for Restaurant"
                Visible="False" Font-Italic="True" Font-Size="15px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 100%; color: Black;" align="left">
            Filter State &nbsp;&nbsp;<asp:DropDownList ID="dropFilter" runat="server" Width="90px" AutoPostBack="true" OnSelectedIndexChanged="dropFilter_SelectedIndexChanged">
                <asp:ListItem Value="3" Text="All State" Selected="true"></asp:ListItem>
                <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                <asp:ListItem Value="0" Text="Reject"></asp:ListItem>
                <asp:ListItem Value="2" Text="Pending"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 100%; height: 154px;">
            <asp:GridView ID="grvReviewAdmin" AutoGenerateColumns="False" HorizontalAlign="Center"
                runat="server" Width="100%" ForeColor="White" OnSelectedIndexChanged="grvReviewAdmin_SelectedIndexChanged"
                OnRowCommand="grvReviewAdmin_RowCommand" AllowPaging="True" OnPageIndexChanging="grvReviewAdmin_PageIndexChanging"
                PageSize="15" OnRowDataBound="grvReviewAdmin_RowDataBound" BorderColor="#999999">
                <Columns>
                    <asp:BoundField HeaderText="Restaurant Name" DataField="RestaurantName">
                        <ItemStyle ForeColor="Black" HorizontalAlign="Left" Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Member Name" DataField="FullName">
                        <ItemStyle ForeColor="Black" HorizontalAlign="Left" Width="130px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Title Review" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" ForeColor="#0066cc" runat="server" CausesValidation="False"
                                CommandArgument='<%# Eval("ID")+"&"+ Eval("MemberID")+"&"+Eval("RestaurantID") %>'
                                CommandName="Select" Text='<%# Eval("Title")%>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="220px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Create Date">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("CreateReview") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("CreateReview") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Visit Again" DataField="VisitAgain">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Avg" DataField="AvgRate">
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Description">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Descript") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descript") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:DropDownList ID="dropStatus" runat="Server" Width="100px">
                                <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Reject"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Pending"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfStatus" Value='<%# Eval("Active") %>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkApprove" ForeColor="#0066cc" CommandArgument='<%# Eval("ID")+"&"+ Eval("MemberID")+"&"+Eval("RestaurantID") %>'
                                CommandName="ApproveUpdate" runat="server">Update</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDelete" ForeColor="#0066cc" CommandArgument='<%# Eval("ID") %>'
                                CommandName="DeleteUpdate" runat="server">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Right" Height="30px" ForeColor="Black" />
                <RowStyle HorizontalAlign="Left" Height="25px" ForeColor="Black" />
                <HeaderStyle BackColor="#CCCCCC" Height="30px" ForeColor="Black" CssClass="text" />
            </asp:GridView>
        </td>
    </tr>
    <tr> 
        <td style="width: auto; text-align: left;" valign="top" align="center">
            <asp:Panel ID="Panel1" runat="server" Width="100%" BorderWidth="1px" BorderColor="#999999"
                Visible="false" ForeColor="black">
                <div style="width: 100%; text-align: left;">
                    <table style="width: 100%">
                        <tr>
                            <td colspan="1" style="width: 100px">
                                <br />
                                <br />
                            </td>
                            <td colspan="4">
                                <br />
                                <asp:CheckBox ID="checkDetail" runat="server" Visible="false" AutoPostBack="True"
                                    OnCheckedChanged="checkDetail_CheckedChanged" Text="Invisible Info" Font-Bold="True" /><br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                            </td>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Meal Type</td>
                            <td colspan="3">
                                <asp:RadioButton ID="rdoBreakFirst" runat="server" Text="BreakFast" GroupName="MealType" />&nbsp;
                                <asp:RadioButton ID="rdoLunch" runat="server" Text="Lunch" GroupName="MealType" />&nbsp;&nbsp;<asp:RadioButton ID="rdoDinner" runat="server" Text="Dinner" GroupName="MealType" />&nbsp;&nbsp;<asp:RadioButton ID="rdoOther" runat="server" Text="Other" GroupName="MealType" /></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Title</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtDisplayName" runat="server" Width="300px"></asp:TextBox><strong><span
                                    style="color: #ff0000">(*)</span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Food</td>
                            <td style="width: 150px">
                                <asp:DropDownList ID="dropFood" runat="server" Width="60px">
                                </asp:DropDownList></td>
                            <td style="width: 100px">
                                Decor</td>
                            <td style="width: auto">
                                <asp:DropDownList ID="dropDecor" runat="server" Width="130px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Service</td>
                            <td style="width: 150px">
                                <asp:DropDownList ID="dropService" runat="server" Width="60px">
                                </asp:DropDownList></td>
                            <td style="width: 100px">
                                Party Size</td>
                            <td style="width: auto">
                                <asp:DropDownList ID="dropPartySize"
                                    runat="server" Width="130px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Price</td>
                            <td style="width: 150px">
                                <asp:DropDownList ID="dropPrice" runat="server" Width="60px">
                                </asp:DropDownList></td>
                            <td style="width: 100px">
                                Price Range</td>
                            <td style="width: auto">
                                <asp:DropDownList ID="dropPriceRange" runat="server" Width="130px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Visit Again?</td>
                            <td colspan="3">
                                <asp:RadioButton ID="rdoVisitYes" runat="server" Text="Yes" GroupName="VisitAgain" />&nbsp;
                                <asp:RadioButton ID="rdoVisitMaybe" runat="server" Text="Maybe" GroupName="VisitAgain" />&nbsp;
                                <asp:RadioButton ID="rdoVisitNever" runat="server" Text="Never" GroupName="VisitAgain" /></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Table Order Service</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtYourOrder" Width="600px" Height="30px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px" valign="top">
                                Your Review</td>
                            <td colspan="3">
                                    <asp:TextBox ID="txtYourReview" Width="600px" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 130px">
                            </td>
                            <td colspan="3">
                                <asp:Button ID="butAccept" runat="server" Text="Accept" Width="70px" Font-Bold="False"
                                    OnClick="butAccept_Click" /><asp:Button ID="butReject" runat="server" Text="Reject" Width="70px" Font-Bold="False"
                                    OnClick="butReject_Click" /><asp:Button ID="butEdit" runat="server" Text="Edit" Width="70px" Font-Bold="False"
                                    OnClick="butEdit_Click" /></td>
                        </tr>
                    </table>
                    <br />
                    
                </div>
            </asp:Panel>
            <br />
        </td>
    </tr>
</table>
