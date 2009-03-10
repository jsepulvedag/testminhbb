<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Restaurant.Presentation.Administrator.UserControls.Header" %>
<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>

    <style type="text/css">
        .style2
        {
            height: 65px;
            text-align: right;
            color: #FFFFFF;            
            font-weight: bold;
            font-size: x-large;
            background-image: url(../Media/Images/AdminHeaderBottomLeft.jpg);
        }
        .style3
        {
            width: 405px;
            height:150px;
            text-align: left;
            background-image: url(../Media/Images/AdminHeader.jpg);
            border-spacing:0px
           
        }
    </style>
    <table cellpadding="0" cellspacing="0" width="100%" border="0px">
        <tr>
            <td class="style2">
                <table width="100%" border="0px" cellpadding="0" cellspacing="0">
                    <tr> 
                     <td  class="style3">
                     </td>
                     <td> 
                     </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="background-image:url(../Media/Images/AdminMenuBackground.jpg);background-repeat:repeat-x;padding-bottom:20px;">
                <radM:RadMenu ID="radAdminMenu" runat="server" Skin="Mac" BorderWidth="0" CausesValidation="False">
                </radM:RadMenu>
            </td>
        </tr>
    </table>
    
