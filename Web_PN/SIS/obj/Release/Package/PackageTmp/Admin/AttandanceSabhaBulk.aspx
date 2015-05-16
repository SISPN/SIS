<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttandanceSabhaBulk.aspx.cs" Inherits="SIS.Admin.AttandanceSabhaBulk"
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
    <script language="javascript" type="text/javascript">
        $("#<%=datepicker.ClientID %>").datepicker($.datepicker.regional["en-GB"]);
        $(function () {
            $("#<%=datepicker.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true
            });

        });



        function fnOpen(url) {
            window.showModalDialog(url, "", "dialogHeight: 350px; dialogWidth: 800px; dialogTop: 200px; dialogLeft: 400px; center: Yes; resizable: No; status: Yes;");
        }
    </script>
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
    <div style="border: 5px hidden; border-color: #3BB9FF;">
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td style="width: 15%;">
                        <asp:Label ID="lblPersonid" runat="server" Text="Person Id "></asp:Label>
                    </td>
                    <td style="width: 25%;" class="textbox_adjust">
                        <asp:TextBox ID="txtstudentid" runat="server" Width="245px" ValidationGroup="StudentInfo"
                            CssClass="inputbox"></asp:TextBox>
                    </td>
                    <td style="width: 60%;">
                        &nbsp;
                    </td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lblfamilyid" runat="server" Text="Family Id "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtfamilyid" runat="server" Width="245px" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFName" runat="server" Text="First Name "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtFName" runat="server" Width="245px" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmiddel" runat="server" Text="Middle Name "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtmiddle" runat="server" Width="245px" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastname" runat="server" Text="Last Name "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtLastName" runat="server" Width="245px" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDob" runat="server" Text="Date Of Birth"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox runat="server" ID="datepicker" Width="245px" Style="margin-bottom: 0px"
                        ValidationGroup="StudentInfo" CssClass="inputbox" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="datepicker"
                        Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                        ErrorTooltipEnabled="True" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPhoneMobile" runat="server" Text="Mobile "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtMobile" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblResidence" runat="server" Text="Residence Phone"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtResidence" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtEmailAddress" runat="server" Width="245px" ColumnSpan="2" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="ValEmail" runat="server" ErrorMessage="Enter Valid Email"
                        Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmailAddress" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr>
            <td colspan="3" align="left" style="padding-bottom: 20px;">
                <asp:Button ID="btnsearch" runat="server" Text="Search" Font-Size="Medium" OnClick="btnsearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                <asp:Label ID="lblnodata" runat="server" Text="No Data to Display" ForeColor="Maroon"
                    Style="display: none;" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ListView ID="dlresultlist" runat="server" ItemPlaceholderID="itemPlaceHolderId"
                    OnItemDataBound="dlresultlist_ItemDataBound">
                    <LayoutTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0" style="border-bottom: 1px solid #000;
                            border-top: 1px solid #000; border-right: 1px solid #000; border-left: 1px solid #000;">
                            <tr class="Grid_Header">
                                <td style="width: 10%; padding-left: 5px;">
                                    <asp:Label ID="lblStudentid" runat="server" Text="Person Id" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 10%; padding-left: 5px;">
                                    <asp:Label ID="Label1" runat="server" Text="Family Id" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 10%; padding-left: 5px;">
                                    <asp:Label ID="Label2" runat="server" Text="Xetra/Mandal" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 25%;">
                                    <asp:Label ID="lblpersonname1" runat="server" Text="Full Name" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 10%;">
                                    <asp:Label ID="lblDob1" runat="server" Text="DOB" CssClass="normal_link_header_bold"></asp:Label>
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
                                    <asp:Label ID="lbleditdata" runat="server" Text="Need Update?" CssClass="normal_link_header_bold"></asp:Label>
                                </td>
                                <td style="width: 5%;">
                                    <asp:Label ID="lbledit" runat="server" Text="Edit?" CssClass="normal_link_header_bold"></asp:Label>
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
                                <asp:HiddenField ID="hdnSId" runat="server" Value='<%# Eval("PId") %>' />
                                <asp:Label ID="lblchattralayaname" runat="server" Text='<%# Eval("FamilyId") %>'></asp:Label>
                            </td>
                            <td class="normalText">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Xetra") + "/" + Eval("Mandal") %>'></asp:Label>
                            </td>
                            <td class="normalText">
                                <asp:Label ID="lblstudentname" runat="server" Text='<%# Eval("FirstName")+ " " + Eval("MiddleName")+ " "+ Eval("LastName") %>'></asp:Label>
                            </td>
                            <td class="normalText">
                                <asp:Label ID="lblDob" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
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
                                <asp:Image ID="imgneedupdate" runat="server" ImageUrl="~/Images/images.png"/>
                                <asp:HiddenField ID="hdnlstupdatedate" runat="server" Value='<%# Eval("UpdateDate") %>'/>
                            </td>
                            <td class="normalText">
                                <asp:HyperLink ID="hlnkedit" runat="server" Text="Edit" NavigateUrl=' <%#  "~/Pages/UpdatePerson.aspx?PersonId=" + Eval("PersonId") %>'></asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
</asp:Content>
