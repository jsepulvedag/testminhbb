<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ChooseCity.ascx.cs"
    Inherits="Restaurant.Presentation.Delivery.UserControls.Common.ChooseCity" %>
<div style="border: solid 1px black; width: 900px; margin: 0 auto;">
    <table style="width: 869px; margin: 0 auto;">
        <tr>
            <td>
                <div style="margin: 0 auto; text-align: center; font-size: 25px; font-weight: bold;
                    color: Red;">
                    CHOOSE CITY FOR DELIVERY
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; padding-top: 10px;">
                <asp:DropDownList ID="drpCity" runat="server" Width="200px">
                </asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <div id="cityList">
                    <div style="padding-left: 200px;">
                        <span style="font-size: 15px; font-weight: bold;">Popular Cities</span>
                        <br />
                        <ul>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                        </ul>
                        <ul class="reset">
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                        </ul>
                        <ul class="reset">
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                        </ul>
                        <ul class="reset">
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                        </ul>
                        <ul class="reset">
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                            <li><a href="/ga/atlanta/">Atlanta</a> </li>
                        </ul>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</div>
