<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChoosePackage.ascx.cs" Inherits="Restaurant.Presentation.Management.Restaurant.Renew.ChoosePackage" %>

         <asp:DataList Width="662px" ID="dlPackage" runat="server" OnItemDataBound="dlPackage_ItemDataBound">
                <HeaderTemplate>
                    <table style="width: 660px; height: auto; border: 1px;">
                        <tr>
                            <td style=" width:145px;height: auto; text-align: left; font-size: larger;padding-left:5px;">
                                Package</td>
                            <td style="width:300px;height: auto; text-align: left; font-size: larger;">
                                Description</td>
                            <td style="width:250px;height: auto; text-align: left; font-size: larger;">
                                Subscription plan</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr style="color: White; border: 1px; width: 99%; margin: 0 auto;" />
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="height: auto; text-align: left; color: White;padding-left:5px;">
                            <asp:Label runat="server" ID="lblPackageID" Text='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                Visible="false"></asp:Label>
                            <%#DataBinder.Eval(Container.DataItem,"Name")%>
                        </td>
                        <td style="height: auto; text-align: left; color: White;">
                            <%#DataBinder.Eval(Container.DataItem,"Description")%>
                        </td>
                        <td style="height: auto; text-align: left;">
                            <asp:Repeater runat="server" ID="rptPackageDetail">
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td style="width:100px;height: auto; text-align: left; font-weight: bolder;">
                                                Plan expiry</td>
                                            <td style="width:100px;height: auto; text-align: left; font-weight: bolder;">
                                                Price</td>
                                            <td style="width:50px;height: auto; text-align: center; font-weight: bolder;">
                                                Select</td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="height: auto; text-align: left;">
                                            <asp:Label runat="server" ID="lblPackageDetailID" Text='<%#DataBinder.Eval(Container.DataItem,"ID") %>'
                                                Visible="false"></asp:Label><%#DataBinder.Eval(Container.DataItem,"ExpiryMonth")%>
                                            months</td>
                                        <td style="height: auto; text-align: left">
                                            <%#DataBinder.Eval(Container.DataItem,"Price")%>
                                            USD</td>
                                        <td style="height: auto; text-align: center;">
                                            <asp:RadioButton runat="server" ID="rdSelected" GroupName="rdSelected" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr style="color: White; border: 1px; width: 99%; margin: 0 auto;" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
            <table style="width: 660px; height: auto; border: 0px;">
                <tr>
                    <td style="text-align: right; width: 50%;">
                        <asp:Button ID="btnContinue" runat="server" Text="Renew Restaurant" Font-Bold="False" Width="140px" CssClass="Button" OnClick="btnContinue_Click"
                            />&nbsp;</td>
                    <td style="width: 432px">
                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Back to Restaurant" Font-Bold="False" Width="140px" CssClass="Button"
                            Visible="true" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>