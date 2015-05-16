<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="BulkUpload.aspx.cs" Inherits="SIS.Pages.BulkUpload"
    MasterPageFile="~/Site.master" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--deepaksolanki/dipak222--%>
    <link href="../Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.datepicker-en-GB.js" type="text/javascript"></script>
    <link href="../Styles/demos.css" rel="stylesheet" type="text/css" />

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
    <div style="border: 5px hidden; border-color: #3BB9FF;">
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:Label ID="lblcity" runat="server" Text="Xetra"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:DropDownList ID="ddlXetra" runat="server" Width="245px">
                    </asp:DropDownList>
                </td>
                <td style="width: 60%;">&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblarea" runat="server" Text="Mandal"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMandal" runat="server" Width="245px">
                    </asp:DropDownList>
                    <ajaxToolkit:CascadingDropDown ID="ccdXetra" runat="server" TargetControlID="ddlXetra"
                        SelectedValue="1" Category="Xetra" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                        ServiceMethod="GetXetra">
                    </ajaxToolkit:CascadingDropDown>
                    <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" TargetControlID="ddlMandal" UseContextKey="true"
                        ParentControlID="ddlXetra" Category="Mandal" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                        ServiceMethod="GetMandal">
                    </ajaxToolkit:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td style="width: 15%;">
                    <asp:Label ID="lblupload" runat="server" Text="Bulk Upload : "></asp:Label>
                </td>
                <td style="width: 25%;" class="textbox_adjust">
                    <asp:FileUpload ID="fudata" runat="server" />
                </td>
                <td style="width: 60%;">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="1" align="left" style="padding-bottom: 20px;">
                    <asp:Button ID="btnshow" runat="server" Text="Show" Font-Size="Medium" OnClick="btnsearch_Click"   class="btn btn-medium btn-primary" />
                </td>
                <td colspan="1" align="left" style="padding-bottom: 20px;">
                    <asp:Button ID="btnupload" runat="server" Text="Upload" Font-Size="Medium" OnClick="btnupload_Click"  class="btn btn-medium btn-primary" />
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr colspan="3">
            <td>
                <asp:Label ID="lblnodata" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

        <tr>

            <td colspan="3">
                <asp:ListView ID="dlresultlist" runat="server" ItemPlaceholderID="itemPlaceHolderId"
                    OnItemDataBound="dlresultlist_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0" style="border-bottom: 1px solid #000; border-top: 1px solid #000; border-right: 1px solid #000; border-left: 1px solid #000;">
                            <tr class="Grid_Header">
                                <td style="width: 10%; padding-left: 5px;">
                                    <asp:Label ID="lblStudentid" runat="server" Text="Person Id" CssClass="normal_link_header_bold"></asp:Label>
                                </td>


                                <td style="width: 25%;">
                                    <asp:Label ID="lblpersonname1" runat="server" Text="Full Name" CssClass="normal_link_header_bold"></asp:Label>
                                </td>

                                <td style="width: 15%;">
                                    <asp:Label ID="lblMobile1" runat="server" Text="Mobile Phone" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 10%;">
                                    <asp:Label ID="lblresident1" runat="server" Text="Resident Phone" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 15%;">
                                    <asp:Label ID="lblemail1" runat="server" Text="Email" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 5%;">
                                    <asp:Label ID="lblactive" runat="server" Text="Active?" CssClass="normal_link_header_bold"></asp:Label>
                                </td>

                                <td style="width: 25%;">
                                    <asp:Label ID="lblSamparkkaryakar" runat="server" Text="Sampark Karyakar" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 25%;">
                                    <asp:Label ID="Label1" runat="server" Text="Category" CssClass="normal_link_header_bold"></asp:Label>
                                </td>

                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolderId" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class='<%# Container.DisplayIndex % 2 == 0 ? "RowStyle": "AlterRowStyle"%>' style="height: 25px;">
                            <td class="normalText" style="padding-left: 5px;">
                                <asp:Label ID="lblstudentid" runat="server" Text='<%# Eval("PersonId") %>'></asp:Label>
                            </td>


                            <td class="normalText">
                                <asp:Label ID="lblstudentname" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </td>

                            <td class="normalText">
                                <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("MobilePhone") %>'></asp:Label>
                            </td>
                            <td class="normalText">
                                <asp:Label ID="lblresident" runat="server" Text='<%# Eval("HomePhone") %>'></asp:Label>
                            </td>
                            <td class="normalText">
                                <asp:Label ID="lblemail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </td>
                            <td class="normalText">
                                <asp:Label ID="lblactivestate" runat="server" Text='<%# Eval("CurrentStatus") %>'></asp:Label>
                            </td>

                            <td class="normalText">
                                <asp:Label ID="lblkaryakar" runat="server" Text='<%# Eval("Karyakar") %>'></asp:Label>
                            </td>
                            <td class="normalText">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
</asp:Content>
