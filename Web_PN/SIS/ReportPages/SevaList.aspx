<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SevaList.aspx.cs" Inherits="SIS.Reports.SevaList" %>


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
                    <asp:Label ID="lblcity" runat="server" Text="Xetra"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:DropDownList ID="ddlXetra" runat="server" Width="245px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblListtype" runat="server" Text="From Amount "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtamountfrom" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px" onchange="check();"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                        ControlToValidate="txtamountfrom" ErrorMessage="Value must be a whole number" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMandal" runat="server" Text="Mandal "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:DropDownList ID="ddlMandal" runat="server" Width="245px">
                    </asp:DropDownList>
                    <ajaxToolkit:CascadingDropDown ID="ccdXetra" runat="server" TargetControlID="ddlXetra"
                        SelectedValue="1" Category="Xetra" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                        ServiceMethod="GetXetra">
                    </ajaxToolkit:CascadingDropDown>
                    <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" TargetControlID="ddlMandal" UseContextKey="true"
                        Category="Mandal" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx" ParentControlID="ddlXetra"
                        ServiceMethod="GetMandalFromMapId">
                    </ajaxToolkit:CascadingDropDown>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="To Amount"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtamountto" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px" onchange="check();"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                        ControlToValidate="txtamountto" ErrorMessage="Value must be a whole number" /></td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Report Type "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:DropDownList ID="ddltype" runat="server" Width="230px">
                        <asp:ListItem Text="Report" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Lable" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2"></td>
            </tr>
    </div>



    <tr>
        <td colspan="4" class="textbox_adjust">
            <asp:Button ID="btnshowrpt" runat="server" Text="Show Report" Height="26px" Width="100px"  class="btn btn-medium btn-primary" 
                Font-Bold="true" OnClick="btnshowrpt_Click" />
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
