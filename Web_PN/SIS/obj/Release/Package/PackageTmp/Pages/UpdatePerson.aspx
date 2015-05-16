<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UpdatePerson.aspx.cs"
    Inherits="SIS.Pages.UpdatePerson" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/demos.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/MainPage.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.datepicker-en-GB.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">



        $("#<%=datepicker.ClientID %>").datepicker($.datepicker.regional["en-GB"]);
        $(function () {
            $("#<%=datepicker.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true
            });

        });

        function fillCell(row, cellNumber, text) {
            var cell = row.insertCell(cellNumber);
            cell.innerHTML = text;
            cell.style.borderBottom = cell.style.borderRight = "solid 1px #aaaaff";
        }
        function addToClientTable(name, text) {

        }

        function uploadError(sender, args) {
            addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
        }
        function uploadComplete(sender, args) {
            var contentType = args.get_contentType();
            var text = args.get_length() + " bytes";
            if (contentType.length > 0) {
                text += ", '" + contentType + "'";
            }
            addToClientTable(args.get_fileName(), text);
        }

    </script>


    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblstatus" runat="server" CssClass="lable" Text=""></asp:Label>
            </td>

            <td align="right">
                <asp:Label ID="lblPersonid" runat="server" CssClass="lable" Text=""></asp:Label>
            </td>
        </tr>
    </table>


    <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="1"
        FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="HeadingBG" HeaderSelectedCssClass="HeadingBG"
        TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header><span class="arrow">Personal Detail</span></Header>
                <Content>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">

                        <tr>
                            <td>&nbsp;Main Person
                &nbsp;</td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddlMainPerson" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td class="textbox_adjust">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="textbox_adjust">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Current Status
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddcurrentstate" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                            <td>Is Active?</td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddlactive" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle">
                                    <asp:ListItem Selected="True" Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Sampark Karyakar</td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddlkaryakar" runat="server" AutoCompleteMode="SuggestAppend"
                                    AutoPostBack="False" CaseSensitive="False" CssClass="WindowsStyle" DropDownStyle="DropDownList"
                                    Width="245px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblcity" runat="server" Text="Xetra"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddlXetra" runat="server" Width="245px">
                                </asp:DropDownList>
                            </td>
                            <td>

                                <asp:Label ID="lblarea" runat="server" Text="Mandal"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddlMandal" runat="server" Width="245px">
                                </asp:DropDownList>
                                <ajaxToolkit:CascadingDropDown ID="ccdXetra" runat="server" TargetControlID="ddlXetra"
                                    SelectedValue="1" Category="Xetra" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                                    ServiceMethod="GetXetra">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" TargetControlID="ddlMandal"
                                    ParentControlID="ddlXetra" Category="Mandal" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                                    ServiceMethod="GetMandal">
                                </ajaxToolkit:CascadingDropDown>
                            </td>
                            <td>&nbsp;</td>
                            <td class="textbox_adjust">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFName0" runat="server" Text="Dharmada Id"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtDId" runat="server" Width="245px" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label35" runat="server" Text="Blood Group"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbbloodgrp" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblLastName0" runat="server" Text="Category"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:ListBox ID="lstcategory" runat="server" Width="243px"
                                    SelectionMode="Multiple"></asp:ListBox>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="lblFName" runat="server" Text="First Name"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtFName" runat="server" Width="245px" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValFName" runat="server" ControlToValidate="txtFName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtMiddelName" runat="server" Width="245px" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValMName" runat="server" ControlToValidate="txtMiddelName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtLastName" runat="server" Width="245px" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValLastName" runat="server" ControlToValidate="txtLastName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox runat="server" ID="datepicker" Style="margin-bottom: 0px" ValidationGroup="StudentInfo"
                                    Width="160px" />
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="datepicker"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                    ErrorTooltipEnabled="True" />
                                <asp:Label ID="lblage" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddlgender" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle">
                                    <asp:ListItem Selected="True">Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label32" runat="server" Text="Mother Toungue"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtmothertougue" runat="server" Width="245px" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Two Whealer"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txttwowheler" runat="server" CssClass="inputbox" Width="160px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttwowheler"
                                    Mask="99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Number" ErrorTooltipEnabled="True" />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Four Whealer"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtfourwheler" runat="server" CssClass="inputbox" Width="160px"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfourwheler"
                                    Mask="99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Number" ErrorTooltipEnabled="True" />
                            </td>
                            <td>
                                <asp:Label ID="lblstudy" runat="server" Text="Study "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddcactstudydid" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header><span class="arrow">Contact Detail</span></Header>
                <Content>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text="Current Address"></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" Width="680px" ColumnSpan="2" Height="44px"
                                    TextMode="MultiLine" ValidationGroup="StudentInfo" CssClass="inputbox"></asp:TextBox><br />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblccountry" runat="server" Text="Country "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbcountry" runat="server" Width="245px" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblstate" runat="server" Text="State "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbstate" runat="server" Width="245px" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDistrict" runat="server" Text="District"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbDistrict" runat="server" Width="245px" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lablcity" runat="server" Text="City "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbcity" runat="server" Width="245px" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblVillage" runat="server" Text="Village"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtVillage" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                                <ajaxToolkit:CascadingDropDown ID="cddCountry" runat="server" TargetControlID="cmbcountry"
                                    Category="Country" LoadingText="Please wait ..." ServicePath="~/WebServices/GeomatryDetail.asmx"
                                    ServiceMethod="GetCountry">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="cddState" runat="server" TargetControlID="cmbstate"
                                    ParentControlID="cmbcountry" Category="State" LoadingText="Please wait ..." ServicePath="~/WebServices/GeomatryDetail.asmx"
                                    ServiceMethod="GetState">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="cddDistrict" runat="server" TargetControlID="cmbDistrict"
                                    ParentControlID="cmbstate" Category="District" ServicePath="~/WebServices/GeomatryDetail.asmx"
                                    ServiceMethod="GetDistrict">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="cddCity" runat="server" TargetControlID="cmbcity"
                                    ParentControlID="cmbDistrict" Category="City" LoadingText="Please wait ..." ServicePath="~/WebServices/GeomatryDetail.asmx"
                                    ServiceMethod="GetCity">
                                </ajaxToolkit:CascadingDropDown>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblpin" runat="server" Text="Pin "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtPin" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtPermanentAddress" runat="server" Width="680px" ColumnSpan="2"
                                    Height="44px" TextMode="MultiLine" ValidationGroup="StudentInfo" CssClass="inputbox"></asp:TextBox><br />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPCountry" runat="server" Text="Country "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbPCountry" runat="server" Width="245px" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblpstate" runat="server" Text="State "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbpstate" runat="server" Width="245px" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPDistrict" runat="server" Text="District "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbPDistrict" runat="server" Width="245px" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPcity" runat="server" Text="City "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbPCity" runat="server" Width="245px" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPVillage" runat="server" Text="Village "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtPVillage" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                                <ajaxToolkit:CascadingDropDown ID="ccdPCountry" runat="server" TargetControlID="cmbPCountry"
                                    Category="Country" LoadingText="Please wait ..." ServicePath="~/WebServices/GeomatryDetail.asmx"
                                    ServiceMethod="GetCountry">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdPState" runat="server" TargetControlID="cmbpstate"
                                    ParentControlID="cmbPCountry" Category="State" LoadingText="Please wait ..."
                                    ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetState">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdPDistrict" runat="server" TargetControlID="cmbPDistrict"
                                    ParentControlID="cmbpstate" Category="District" LoadingText="Please wait ..."
                                    ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetDistrict">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdPCity" runat="server" TargetControlID="cmbPCity"
                                    ParentControlID="cmbPDistrict" Category="City" LoadingText="Please wait ..."
                                    ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetCity">
                                </ajaxToolkit:CascadingDropDown>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPPin" runat="server" Text="Pin "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtPPin" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblnative" runat="server" Text="Native Place "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtnative" runat="server" CssClass="inputbox" Width="245px"></asp:TextBox>
                            </td>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPhoneMobile" runat="server" Text="Mobile 1"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtMobile" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPhoneMobile2" runat="server" Text="Mobile 2"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtMobile2" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPhoneMobile3" runat="server" Text="Mobile 3 "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtMobile3" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblResidence" runat="server" Text="Residence 1 "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtResidence" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="Label37" runat="server" Text="Residence 2 "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtResidence2" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td>Is DND?</td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddldnd" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle">
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Selected="True" Text="No" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtEmailAddress" runat="server" Width="245px" ColumnSpan="2" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="ValEmail" runat="server" ErrorMessage="Enter Valid Email"
                                    ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtEmailAddress" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblaltemail" runat="server" Text="Alt Email Address 1 "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtaltemail" runat="server" Width="245px" ColumnSpan="2" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="Valaltemail" runat="server" ErrorMessage="Enter Valid Email"
                                    ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtaltemail" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label36" runat="server" Text="Alt Email Address 2 "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtaltemail2" runat="server" Width="245px" ColumnSpan="2" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Email"
                                    ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtaltemail2" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>

                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header><span class="arrow">Job Information</span></Header>
                <Content>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblOccupation" runat="server" Text="Occupation "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddcOccupation" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblTypeOfServ" runat="server" Text="Type Of Service "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddctypeofserv" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                            <td>
                                <asp:Label ID="lblDesignation" runat="server" Text="Designation "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesignation" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblname" runat="server" Text="Office Name "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="5">
                                <asp:TextBox ID="txtofficename" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOfficeAddress" runat="server" Text="Office Address "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="5">
                                <asp:TextBox ID="txtOfficeAddress" runat="server" Width="680px" ColumnSpan="2" Height="44px"
                                    TextMode="MultiLine" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblOCountry" runat="server" Text="Country "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbOCountry" runat="server" Width="245px" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblOState" runat="server" Text="State "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbOstate" runat="server" Width="245px" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblODistrict" runat="server" Text="District "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbODistrict" runat="server" Width="245px" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblOCity" runat="server" Text="City "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbOCity" runat="server" Width="245px" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOVillage" runat="server" Text="Village "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtOVillage" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                                <ajaxToolkit:CascadingDropDown ID="ccdOCoutry" runat="server" TargetControlID="cmbOCountry"
                                    Category="Country" LoadingText="Please wait ..." ServicePath="~/WebServices/GeomatryDetail.asmx"
                                    ServiceMethod="GetCountry">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdOState" runat="server" TargetControlID="cmbOstate"
                                    ParentControlID="cmbOCountry" Category="State" LoadingText="Please wait ..."
                                    ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetState">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdODistrict" runat="server" TargetControlID="cmbODistrict"
                                    ParentControlID="cmbOstate" Category="District" LoadingText="Please wait ..."
                                    ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetDistrict">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdOCity" runat="server" TargetControlID="cmbOCity"
                                    ParentControlID="cmbODistrict" Category="City" LoadingText="Please wait ..."
                                    ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetCity">
                                </ajaxToolkit:CascadingDropDown>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblOPin" runat="server" Text="Pin "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtOPin" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblofficephone" runat="server" Text="Office Phone "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtOfficePhone" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblofficefax" runat="server" Text="Office Fax "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtofficefax" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>

                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header><span class="arrow">Satsang Information</span></Header>
                <Content>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblPooja" runat="server" Text="Pooja"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbpooja" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                            <td>
                                <asp:Label ID="lblTilakChandlo" runat="server" Text="Tilak Chandlo "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkTilakChandlo" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label45" runat="server" Text="Satsang From "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtsatsangfrom" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label46" runat="server" Text="Outside Food "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkosfood" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label47" runat="server" Text="TV/Film "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chktvfilm" Text="Yes" runat="server" />
                            </td>
                            <td colspan="2"></td>

                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblGharSabha" runat="server" Text="Ghar Sabha "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkGharSabha" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label42" runat="server" Text="Chesta "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkChesta" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="lblSabha" runat="server" Text="Sabha"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbsabha" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>

                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblGharMandir" runat="server" Text="Ghar Mandir "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkGharMandir" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label43" runat="server" Text="Mandir Darshan "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbdarshan" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" Font-Names="Arial" />

                            </td>
                            <td>
                                <asp:Label ID="Label44" runat="server" Text="Belive In? "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtbelivein" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblExam" runat="server" Text="Last Exam Given"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbcExam" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />


                            </td>
                            <td>
                                <asp:Label ID="Label38" runat="server" Text="Enrolled this Year in SSP? "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkshield" Text="Yes" runat="server" />
                            </td>

                            <td>
                                <asp:Label ID="Label48" runat="server" Text="Exam No "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtno" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblcategory" runat="server" Text="Satsang Category"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="ddlsatsangcategory" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" Font-Names="Arial" />
                            </td>
                            <td>
                                <asp:Label ID="lblLocalActivity" runat="server" Text="Local Activity"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:DropDownList ID="cmbcLocalActivity" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" Font-Names="Arial" />
                            </td>
                            <td>
                                <asp:Label ID="lbldosatsangactivity" runat="server" Text="Intrest in Local Satsang Activity? "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkdolocalsatsangactivity" Text="Yes" runat="server" />
                            </td>
                        </tr>

                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
                <Header><span class="arrow">Satsang Magazine Information</span></Header>
                <Content>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">


                        <tr>

                            <td>
                                <asp:Label ID="lblSwaminarayanPrakash" runat="server" Text="Swaminarayan Prakash "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox runat="server" ID="datepickerprakash" Style="margin-bottom: 0px" ValidationGroup="StudentInfo"
                                    Width="160px" />
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="datepickerprakash"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                    ErrorTooltipEnabled="True" />
                            </td>

                            <td>
                                <asp:Label ID="Label39" runat="server" Text="Premvati "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox runat="server" ID="datepickerpremvati" Style="margin-bottom: 0px" ValidationGroup="StudentInfo"
                                    Width="160px" />
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="datepickerpremvati"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                    ErrorTooltipEnabled="True" />
                            </td>
                            <td>
                                <asp:Label ID="Label40" runat="server" Text="Bliss "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox runat="server" ID="datepickerbliss" Style="margin-bottom: 0px" ValidationGroup="StudentInfo"
                                    Width="160px" />
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="datepickerbliss"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                    ErrorTooltipEnabled="True" />
                            </td>

                        </tr>

                        <tr>

                            <td>
                                <asp:Label ID="Label41" runat="server" Text="Bal Prakash "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox runat="server" ID="datepickerbalprakash" Style="margin-bottom: 0px" ValidationGroup="StudentInfo"
                                    Width="160px" />
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="datepickerbalprakash"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                    ErrorTooltipEnabled="True" />
                            </td>

                            <td colspan="4"></td>


                        </tr>
                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                <Header><span class="arrow">Skill Information</span></Header>
                <Content>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Singing"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chksing" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Vadan "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtvadan" runat="server" Width="245px"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Painting"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkpainting" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Decoration "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkdecoration" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label29" runat="server" Text="MS Office "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkmsoffice" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Dance"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkdance" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Drama "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkdrama" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Speach "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkspeach" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Tailor"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chktailor" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Car Painter "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkcarpainter" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Plumbing "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkplumbing" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Welding"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkWelding" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="Desingning "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkdesigning" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Computer "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkcomputer" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="Car Driving"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkcardriving" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="Electric "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkelectric" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="Construction "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkConstruction" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="Sound/Mike"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chksound" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Medical "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkmedical" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Cooking "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkcooking" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="Photography"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkphotography" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="Housekeeping "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkhousekeeping" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label25" runat="server" Text="Video "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkvedio" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" Text="Video Editing"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkvedioediting" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label27" runat="server" Text="Photo Editing "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkphotoediting" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label28" runat="server" Text="Gujarati Typing "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkgujtype" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label33" runat="server" Text="Gardening"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkgardning" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label34" runat="server" Text="P.R. "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkpr" Text="Yes" runat="server" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label30" runat="server" Text="Other Skill "></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtother" runat="server" TextMode="MultiLine" Height="44px" Width="580px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label31" runat="server" Text="Intrestead Paper Seva "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkpasti" Text="Yes" runat="server" />
                            </td>
                        </tr>
                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>

    <table>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-medium btn-primary" />
            </td>
            <td colspan="2"></td>
            <td colspan="2"></td>
        </tr>
    </table>
</asp:Content>
