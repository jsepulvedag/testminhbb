<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefineGiftDesign.ascx.cs" Inherits="Restaurant.Presentation.Administrator.GiftCertificates.DefineGiftDesign" %>
<%@ Register Assembly="CustomControls" Namespace="CustomControls" TagPrefix="cc1" %>

<table style="width:100%;color:black;">
   <caption style="text-align:center;font-size:large;font-weight:bold;">Define Gift Design</caption>
    <tr>
        <td style="color:black;">&nbsp;Gift Design
            <asp:DropDownList ID="drpFilterGiftDesign" runat="server" Width="170px">
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filter"
                Width="100px" CausesValidation="false" /></td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvGiftDesign" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CellSpacing="2" OnPageIndexChanging="gvGiftDesign_PageIndexChanging" PageSize="6" OnRowCommand="gvGiftDesign_RowCommand">
                <Columns>  
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Title
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkBtnGiftType" CommandArgument='<%#Eval("ID")%>' CommandName="lnkBtnGiftType" Text='<%#Eval("Title")%>' CausesValidation="false"></asp:LinkButton>
                            <asp:HiddenField runat="server" ID="hdGiftTypeID" Value='<%#Eval("GiftTypeID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Image
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image runat="server" ID="image" ImageUrl='<%#Eval("ImageSmallURL")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>              
                    <asp:BoundField DataField="GiftType" HeaderText="GiftType" />                    
                    <asp:BoundField DataField="ToX" HeaderText="ToX" />
                    <asp:BoundField DataField="ToY" HeaderText="ToY" />
                    <asp:BoundField DataField="FromX" HeaderText="FrX" />
                    <asp:BoundField DataField="FromY" HeaderText="FrY" />
                    <asp:BoundField DataField="MsgX" HeaderText="MsgX" />
                    <asp:BoundField DataField="MsgY" HeaderText="MsgY" />
                    <asp:BoundField DataField="RestaurantX" HeaderText="ResX" />
                    <asp:BoundField DataField="RestaurantY" HeaderText="ResY" />
                    <asp:BoundField DataField="SignatureX" HeaderText="SgnX" />
                    <asp:BoundField DataField="SignatureY" HeaderText="SgnY" />
                    <asp:BoundField DataField="PriceX" HeaderText="PriceX" />
                    <asp:BoundField DataField="PriceY" HeaderText="PriceY" />
                    <asp:BoundField DataField="AddressX" HeaderText="AddrX" />
                    <asp:BoundField DataField="AddressY" HeaderText="AddrY" />
                    <asp:BoundField DataField="ExpiredDateX" HeaderText="ExpX" />
                    <asp:BoundField DataField="ExpiredDateY" HeaderText="ExpY" />
                    <asp:BoundField DataField="ColorText" HeaderText="Color" />
                    <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Right" Height="30px" />
                <SelectedRowStyle BackColor="#C0C0FF" Font-Bold="True" ForeColor="Black" />
                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" />
            </asp:GridView>            
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <table style="width:100%;color:black;">
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">ID</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtID" runat="server" Width="200px" ReadOnly="true"></asp:TextBox></td>
                    <td style="width: 130px;text-align:left;">Gift type</td>
                    <td>
                        <asp:DropDownList ID="drpGiftDesign" runat="server" Width="205px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">Title</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtTitle" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    <td style="width: 130px;text-align:left;">Image</td>
                    <td>
                        <asp:FileUpload ID="fuImage" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        To X</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtToX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtToX"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        To Y</td>
                    <td>
                        <asp:TextBox ID="txtToY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtToY"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        From X</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtFromX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFromX"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        From Y</td>
                    <td>
                        <asp:TextBox ID="txtFromY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFromY"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        Message X</td>
                    <td style="width: 220px;">
                        <asp:TextBox ID="txtMessageX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMessageX"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        Message Y</td>
                    <td>
                        <asp:TextBox ID="txtMessageY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMessageY"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        Restaurant X</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtRestaurantX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtRestaurantX"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        Restaurant Y</td>
                    <td>
                        <asp:TextBox ID="txtRestaurantY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtRestaurantY"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        Signature X</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtSignatureX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtSignatureX"
                            ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        Signature Y</td>
                    <td>
                        <asp:TextBox ID="txtSignatureY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                            ControlToValidate="txtSignatureY" ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        Price X</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtPriceX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                            ControlToValidate="txtPriceX" ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        Price Y</td>
                    <td>
                        <asp:TextBox ID="txtPriceY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                            ControlToValidate="txtPriceY" ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        Address X</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtAddressX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                            ControlToValidate="txtAddressX" ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        Address Y</td>
                    <td>
                        <asp:TextBox ID="txtAddressY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                            ControlToValidate="txtAddressY" ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        Expiry date X</td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtExpiryDateX" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                            ControlToValidate="txtExpiryDateX" ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                    <td style="width: 130px;text-align:left;">
                        Expiry date Y</td>
                    <td>
                        <asp:TextBox ID="txtExpiryDateY" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                            ControlToValidate="txtExpiryDateY" ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 105px;text-align:left; padding-left: 250px;">
                        Color text</td>
                    <td style="width: 220px">
                        <cc1:ColorPicker ID="colorText" runat="server" />
                        </td>
                    <td style="width: 130px;text-align:left;">
                        Active</td>
                    <td>
                        <asp:RadioButton ID="rdYes" runat="server" GroupName="grActive" Text="Yes" />
                        <asp:RadioButton ID="rdNo" runat="server" Checked="True" GroupName="grActive" Text="No" /></td>
                </tr>
                <tr>                    
                    <td colspan="4">
                        <table style="width:100%;">
                            <tr>
                                <td style="width: 465px;text-align:right;">
                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="100px" OnClick="Insert_Click" CausesValidation="False" /></td>
                                <td style="width:100px;">
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="100px" OnClick="btnEdit_Click" /></td>
                                <td style="width:100px;">
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="100px" OnClick="btnDelete_Click" CausesValidation="False" /></td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" OnClick="btnCancel_Click" CausesValidation="False" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<br />