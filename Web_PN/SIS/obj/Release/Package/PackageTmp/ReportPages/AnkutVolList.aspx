<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AnkutVolList.aspx.cs" Inherits="SIS.Reports.AnkutVolList" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_textboxcontainer input
        {
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
                <asp:Label ID="lblisankutsevak" runat="server" Text="Ankut Group"></asp:Label>
            </td>
            <td class="textbox_adjust" colspan="2">
                <asp:DropDownList ID="ddlankutGroup" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="true" CaseSensitive="False" CssClass="WindowsStyle" DropDownStyle="DropDownList" OnSelectedIndexChanged="ddlisankutsevak_SelectedIndexChanged" Width="245px">
                </asp:DropDownList>
            </td>
             <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="Group Persons"></asp:Label>
            </td>
            <td class="textbox_adjust" colspan="2">
                <asp:DropDownList ID="ddlgroupperson" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="true" CaseSensitive="False" CssClass="WindowsStyle" DropDownStyle="DropDownList"  Width="245px" OnSelectedIndexChanged="ddlgroupperson_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
             <td>
                <asp:Label ID="Label3" runat="server" Text="Ankut Karyakar"></asp:Label>
            </td>
            <td class="textbox_adjust" colspan="2">
                <asp:DropDownList ID="ddlak" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="true" CaseSensitive="False" CssClass="WindowsStyle" DropDownStyle="DropDownList"  Width="245px" >
                </asp:DropDownList>
            </td>
        </tr>
              <tr>
                     <td>
          Category</td>
                  <td> 
                      <asp:DropDownList ID="ddlcategory" runat="server" Width="245px">
                          <asp:ListItem Text="--Select--" Value="-1" Selected="True"></asp:ListItem>
                          <asp:ListItem Text="Group A" Value="A"></asp:ListItem>
                          <asp:ListItem Text="Group B" Value="B"></asp:ListItem>
                          <asp:ListItem Text="Group C" Value="C"></asp:ListItem>
                          <asp:ListItem Text="Group D" Value="D"></asp:ListItem>
                          <asp:ListItem Text="Group E" Value="E"></asp:ListItem>
                          <asp:ListItem Text="Group F" Value="F"></asp:ListItem>
                          <asp:ListItem Text="Ankut Karyakar" Value="AK"></asp:ListItem>
                          <asp:ListItem Text="Ankut Sevak" Value="AS"></asp:ListItem>
                </asp:DropDownList>

                  </td>
            <td colspan="2"/>
               
             
        </tr>

            <tr>
                <td colspan="3" class="textbox_adjust">
                    <asp:Button ID="btnshowrpt" runat="server" Text="Show Report" Height="26px" Width="100px"  class="btn btn-medium btn-primary" 
                        Font-Bold="true" OnClick="btnshowrpt_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 100%;" class="textbox_adjust">
                    <rsweb:ReportViewer ID="rptAreaWise" runat="server" Width="100%" Height="100%" EnableViewState="true"
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
