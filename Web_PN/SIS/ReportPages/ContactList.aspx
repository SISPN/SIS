<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ContactList.aspx.cs" Inherits="SIS.Reports.ContactList" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_textboxcontainer input {
            margin: 0px 0px 0px 0px;
            border: solid 1px #cccccc;
            border-right: 0px none;
            padding: 0px 0px 0px 5px;
            font-size: 12px;
            font-family: Arial, Verdana;
            height: 22px;
        }
    </style>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Cetegory "></asp:Label>
                </td>
                <td colspan="3">
                    <asp:CheckBoxList ID="chkcategory" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"></asp:CheckBoxList>
                </td>

            </tr>
            <tr>
                <td>Report Type</td>
                <td class="textbox_adjust">
                    <asp:DropDownList ID="ddlpostal" runat="server" Width="245px" AutoPostBack="False"
                        DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                        CssClass="WindowsStyle">
                        <asp:ListItem Selected="True" Value="All">All</asp:ListItem>
                        <asp:ListItem Value="Hand">Hand to Hand</asp:ListItem>
                        <asp:ListItem Value="POST">Post</asp:ListItem>
                        <asp:ListItem Value="CR">Courier</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Report Type "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:DropDownList ID="ddltype" runat="server" Width="230px">
                        <asp:ListItem Text="Report" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Lable" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
  



    <tr>
        <td colspan="4" class="textbox_adjust">
            <asp:Button ID="btnshowrpt" runat="server" Text="Show Report" Height="26px" Width="100px"  class="btn btn-medium btn-primary" 
                Font-Bold="true" OnClick="btnshowrpt_Click"  class="btn btn-medium btn-primary"/>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="width: 100%;" class="textbox_adjust">
            <rsweb:ReportViewer ID="rptXetraWise" runat="server" Width="100%" Height="100%" EnableViewState="true"
                ProcessingMode="Remote" AsyncRendering="true" ShowToolBar="true" ShowBackButton="false"
                ShowCredentialPrompts="false" ShowDocumentMapButton="false" ShowExportControls="true"
                ShowFindControls="false" ShowPageNavigationControls="true" ShowPrintButton="true"
                ShowPromptAreaButton="false" ShowRefreshButton="true" ShowReportBody="true" ShowWaitControlCancelLink="false"
                ShowZoomControl="false" PageCountMode="Actual" ShowParameterPrompts="false">
            </rsweb:ReportViewer>
        </td>
    </tr>
    </table>
    </div>
</asp:Content>
