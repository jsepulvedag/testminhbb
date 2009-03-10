<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiftParameter.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.GiftCertificates.GiftParameter" %>

    <div >
        <table style="width:100%;color:White;">
            <tr>
                <td style="width:100%; padding-left:7px;">
                <br />
                    <asp:GridView ID="gvGiftParameter" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" PageSize="6" CellSpacing="2" Width="99%" Visible="false" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="MinimunGiftCertificate" HeaderText="Min price" />
                            <asp:BoundField HeaderText="Max price" DataField="MaximunGiftCertificate" />
                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry days" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Created on" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Modified on" DataFormatString="{0:d}" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Right" Width="30px" Height="30px" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" Width="30px" HorizontalAlign="Center" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>

            <tr>
                <td style="width:100%;">
                    <table style="width:100%;">
                        <tr>
                            <td style="width:27%;text-align:left; padding-left: 100px;">Minimum price&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtMinPrice" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                USD
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMinPrice"
                                    ErrorMessage="*" ValidationExpression="^(((([0-9]+(\.)?)|([0-9]*\.[0-9]+))([eE][+\-]?[0-9]+)?))$"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td style="width:27%;text-align:left; padding-left: 100px;">Maximum price&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtMaxPrice" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                USD
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMaxPrice"
                                    ErrorMessage="*" ValidationExpression="^(((([0-9]+(\.)?)|([0-9]*\.[0-9]+))([eE][+\-]?[0-9]+)?))$"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td style="width:27%;text-align:left; padding-left: 100px;">Expiry days&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtExpirydays" runat="server" Width="130px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtExpirydays"
                                    ErrorMessage="*" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td style="width:27%;text-align:left; padding-left: 100px;"></td>
                            <td>
                                <asp:Button CssClass="Button" ID="btnEdit" runat="server" Text="Save" Width="100px" OnClick="btnEdit_Click" />
                            </td>                            
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
