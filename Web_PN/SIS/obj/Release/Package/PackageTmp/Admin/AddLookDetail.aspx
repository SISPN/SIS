<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLookDetail.aspx.cs"
    Inherits="SIS.Admin.AddLookDetail" MasterPageFile="~/Site.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <table style="width: 100%;" cellpadding="2" cellspacing="0" border="0">
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="lblstatus" runat="server" Text=" " Font-Bold="true" Font-Names="verdana"
                        ForeColor="Green"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 13%;">
                    <asp:Label ID="lblFieldName" runat="server" Text="Field Name "></asp:Label>
                </td>
                <td style="width: 87%;" class="textbox_adjust">
                    <ajaxToolkit:ComboBox ID="ddfield" runat="server" Width="230px" AutoPostBack="true"
                        DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                        CssClass="WindowsStyle" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbldisplay" runat="server" Text="Display Text "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtDisplayText" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblValue" runat="server" Text="Value "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtvalue" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRelatedValue" runat="server" Text="Related Value " Visible="false"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <ajaxToolkit:ComboBox ID="ddrelatedvalue" runat="server" Width="230px" AutoPostBack="False"
                        DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                        CssClass="WindowsStyle" Visible="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnsave" runat="server" Text="Save" Height="26px" Width="60px" Font-Bold="true"
                        OnClick="btnsave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
