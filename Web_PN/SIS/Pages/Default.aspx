<%@ Page Language="C#" AutoEventWireup="true" 
    EnableViewState="false" CodeBehind="Default.aspx.cs" 
    Inherits="jQueryFiveAjaxCalls.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Demo Code for 5 Ajax Calls Using jQuery</title>
    <link rel="SHORTCUT ICON" href="Images/icon_tong.ico" />
    <link href="Styles/AppStyles.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.4.1.min.js" type="text/javascript"></script>
     <link href="../Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/demos.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/MainPage.js" type="text/javascript"></script>
   
  
    <script src="../Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>

    <script src="../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ui.datepicker-en-GB.js" type="text/javascript"></script>
    
     

    <script language="javascript" type="text/javascript">
        alert('1');


        $("#cmbcountry1").change(function () {
            alert('2');
            $("#cmbstate1").html("");
            var CountryID = $("#cmbcountry1 option:selected").val();
            alert('3');
            $.getJSON('GeographyResponse.aspx?CountryID=' + CountryID, function (states) {

                $.each(states, function () {

                    $("#cmbstate1").append($("<option></option>").val(this['StateCode']).html(this['StateName']));

                });
            });

        }).change();


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
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        var $target = $("#MainContent");
        var $resource = "StudentRecordArchive/StudentRecordsHTMLFragment.aspx";
        var $jsresource = "JS/ExampleScript.js";
        var $information = $("#lblInformation");
        var $informationDefaultTextNotSelected =
            "Please select the number of records to retrieve and click on one of the links above ...";
        var $informationDefaultTextSelected =
            "Please click on one of the links above ...";
        var $ajax_load = "<img src='Images/ajax-loader.gif' alt='Loading ...'/>";

        $.ajaxSetup({ cache: false });

        $("#selNoOfStudentRecords").change(function() {
            $target.html("");
            if ($('#selNoOfStudentRecords').val() == "*") {
                $(":button").attr("disabled", true);
                $(":button").removeClass("ButtonStyle");
                $(":button").addClass("ButtonDisabled");
                $information.html($informationDefaultTextNotSelected);
                
            } else {
                $(":button").attr("disabled", false);
                $(":button").removeClass("ButtonDisabled");
                $(":button").addClass("ButtonStyle");
                $information.html($informationDefaultTextSelected);
            }
        }).change();

        $("a").hover(function() {
            this.style.color = "red";
        }, function() {
            this.style.color = "";
        });

        $("#btnClear").click(function(e) {
            e.preventDefault();

            $target.html("");
            $information.html($informationDefaultTextSelected);
        });

        $("#btnUseLoad").click(function(e) {
            e.preventDefault();

            var $nRecord = $('#selNoOfStudentRecords').val();
            $target.html($ajax_load).load($resource, { NRECORD: $nRecord });
            $information.html("Information retrieved by load method ...");
        });

        $("#btnUseGet").click(function(e) {
            e.preventDefault();

            var $nRecord = $('#selNoOfStudentRecords').val();
            $target.html($ajax_load);
            $.get($resource, { NRECORD: $nRecord }, function($x) {
                $target.html($x);
                $information.html("Information retrieved by get method ...");
            });
        });

        $("#btnUsePost").click(function(e) {
            e.preventDefault();

            var $nRecord = $('#selNoOfStudentRecords').val();
            $target.html($ajax_load);
            $.post($resource, { NRECORD: $nRecord }, function($x) {
                $target.html($x);
                $information.html("Information retrieved by post method ...");
            });
        });

        $("#btnUseGetJSON").click(function(e) {
            e.preventDefault();

            var $nRecord = $('#selNoOfStudentRecords').val();
            $target.html($ajax_load);

            $.getJSON($resource, { NRECORD: $nRecord, RETURNJSON: "True" }, function($x) {
                $target.html($x.TB);
                $information.html("Information retrieved by getJSON method ...");
            });
        });

        $("#btnUseGetScript").click(function(e) {
            e.preventDefault();

            var $nRecord = $('#selNoOfStudentRecords').val();
            $target.html($ajax_load);
            $.getScript($jsresource, function() {
                $.loadStudentHtmlFragment($target, $resource, { NRECORD: $nRecord });
                $information.html("Information retrieved by getScript method and run this script ...");
            });
        });

    });
    
</script>
</head>

<body>

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
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="HeadingBG" colspan="2">
                    <div style="border: 1px; border-color: Blue;">
                        <span class="arrow">Personal Information</span></div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblstatus" runat="server" CssClass="lable" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 40%; vertical-align: top;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Current Status
                            </td>
                            <td style="padding-left: 58px;">
                                <ajaxToolkit:ComboBox ID="ddcurrentstate" runat="server" Width="222px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblcity" runat="server" Text="Xetra"></asp:Label>
                            </td>
                            <td style="padding-left: 58px;">
                                <ajaxToolkit:ComboBox ID="ddlXetra" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbXetra_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblarea" runat="server" Text="Mandal"></asp:Label>
                            </td>
                            <td style="padding-left: 58px;">
                                <ajaxToolkit:ComboBox ID="ddlMandal" runat="server" Width="222px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFName" runat="server" Text="First Name"></asp:Label>
                            </td>
                            <td style="padding-left: 58px;" class="textbox_adjust">
                                <asp:TextBox ID="txtFName" runat="server" Width="245px" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValFName" runat="server" ControlToValidate="txtFName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
                            </td>
                            <td style="padding-left: 58px;" class="textbox_adjust">
                                <asp:TextBox ID="txtMiddelName" runat="server" Width="245px" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValMName" runat="server" ControlToValidate="txtMiddelName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                            </td>
                            <td style="padding-left: 58px;" class="textbox_adjust">
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
                            <td style="padding-left: 58px;" class="textbox_adjust">
                                <asp:TextBox runat="server" ID="datepicker" Style="margin-bottom: 0px" ValidationGroup="StudentInfo" />
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="datepicker"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                    ErrorTooltipEnabled="True" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding-left: 58px;" class="textbox_adjust">
                                <asp:ImageButton ID="btncheckavailability" runat="server" AlternateText="Check Availability"
                                    ImageUrl="~/Images/AlreadyExists.jpg" OnClick="btncheckavailability_Click1" Style="width: 10%;
                                    height: 10%; border: 1px solid #0080FF;" ToolTip="Click to check wether record already exists or not based on First name, Last name and Date of Birth?" />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblavailabilitystate" runat="server" Text=" "></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btncheckavailability" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblblood" runat="server" Text="Blood Group"></asp:Label>
                            </td>
                            <td style="padding-left: 58px;" class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbbloodgrp" runat="server" Width="200px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 60%; vertical-align: top;" class="textbox_adjust">
                    <div style="float: left; width: 100%; display: table;">
                        <div style="width: 60%; float: left; height: 250px; overflow-y: auto; overflow-x: hidden;">
                            <asp:ListView ID="lstvwChatralay" runat="server" ItemPlaceholderID="itemPlaceHolderId"
                                OnItemDataBound="lstvwChatralay_ItemDataBound">
                                <LayoutTemplate>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <asp:PlaceHolder ID="itemPlaceHolderId" runat="server"></asp:PlaceHolder>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkChatralay" runat="server" />
                                            <asp:HiddenField ID="hdnChatralayaId" runat="server" Value='<%#Eval("Value") %>' />
                                        </td>
                                        <td>
                                            <%#Eval("DisplayText") %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFrom" runat="server" Width="60px" CssClass="inputbox"></asp:TextBox>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom"
                                                Mask="9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                                ControlToValidate="txtFrom" IsValidEmpty="False" MaximumValue="3000" InvalidValueMessage="*"
                                                MaximumValueMessage="*" MinimumValueMessage="*" MinimumValue="1960" Display="Dynamic"
                                                TooltipMessage="*" InvalidValueBlurredMessage="*" MaximumValueBlurredMessage="*"
                                                MinimumValueBlurredText="*" ForeColor="Red" ValidationGroup="StudentInfo" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTo" runat="server" Width="60px" CssClass="inputbox"></asp:TextBox>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTo"
                                                Mask="9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Number" InputDirection="RightToLeft" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                ControlToValidate="txtTo" IsValidEmpty="False" MaximumValue="3000" InvalidValueMessage="*"
                                                MaximumValueMessage="*" MinimumValueMessage="*" MinimumValue="1960" Display="Dynamic"
                                                TooltipMessage="*" InvalidValueBlurredMessage="*" MaximumValueBlurredMessage="*"
                                                MinimumValueBlurredText="*" ForeColor="Red" ValidationGroup="StudentInfo" />
                                        </td>
                                        <td>
                                            <ajaxToolkit:ComboBox ID="ddcstudy" runat="server" Width="130px" AutoPostBack="False"
                                                DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                                CssClass="WindowsStyle" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <div style="width: 40%; height: 250px; overflow: auto; float: left;">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="padding-left: 15px;">
                                        Select Photo
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 15px;" class="textbox_adjust">
                                        <ajaxToolkit:AsyncFileUpload OnClientUploadError="uploadError" OnClientUploadComplete="uploadComplete"
                                            runat="server" ID="AsyncFileUpload1" Width="280px" UploaderStyle="Modern" UploadingBackColor="#CCFFFF"
                                            ThrobberID="myThrobber" ClientIDMode="AutoID" OnUploadedComplete="AsyncFileUpload1_UploadedComplete1"
                                            OnUploadedFileError="AsyncFileUpload1_UploadedFileError1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 15px;">
                                        <asp:Label runat="server" ID="myThrobber" Style="display: none;"><img align="absmiddle" alt="" src="../Images/uploading.gif" /></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 15px;" class="textbox_adjust" align="center">
                                        <asp:Image ID="StudentPhoto" AlternateText="Upload Photo" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top: 10px;">
                    <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td class="HeadingBG" colspan="4">
                                <span class="arrow">Contact Information</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text="Current Address"></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" Width="470px" ColumnSpan="2" Height="44px"
                                    TextMode="MultiLine" ValidationGroup="StudentInfo" CssClass="inputbox"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblVillage" runat="server" Text="Village"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtVillage" runat="server" Width="200px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lablcity" runat="server" Text="City "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbcity" runat="server" Width="222px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDistrict" runat="server" Text="District"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbDistrict" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbDistrict_SelectedIndexChanged" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblstate" runat="server" Text="State "></asp:Label>
                            </td>
                            <td class="textbox_adjust">

                            <asp:DropDownList ID="cmbstate1" runat="server" /> 
                                <ajaxToolkit:ComboBox ID="cmbstate" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbstate_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblccountry" runat="server" Text="Country "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                            <asp:DropDownList ID="cmbcountry1" runat="server" /> 
                                <ajaxToolkit:ComboBox ID="cmbcountry" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbcountry_SelectedIndexChanged" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblpin" runat="server" Text="Pin "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtPin" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:CheckBox ID="chkSameascurrent" Text="Same as Current" runat="server" OnClick="CopyText()" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtPermanentAddress" runat="server" Width="470px" ColumnSpan="2"
                                    Height="44px" TextMode="MultiLine" ValidationGroup="StudentInfo" CssClass="inputbox"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPVillage" runat="server" Text="Village "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtPVillage" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPcity" runat="server" Text="City "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbPCity" runat="server" Width="222px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPDistrict" runat="server" Text="District "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbPDistrict" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbPDistrict_SelectedIndexChanged" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblpstate" runat="server" Text="State "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbpstate" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbpstate_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPCountry" runat="server" Text="Country "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbPCountry" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbPCountry_SelectedIndexChanged" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblPPin" runat="server" Text="Pin "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtPPin" runat="server" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblstudy0" runat="server" Text="Actual Study "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <ajaxToolkit:ComboBox ID="ddcactstudydid" runat="server" Width="230px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPhoneMobile" runat="server" Text="Mobile "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtMobile" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblResidence" runat="server" Text="Residence "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtResidence" runat="server" Width="239px" CssClass="inputbox"></asp:TextBox>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtEmailAddress" runat="server" Width="470px" ColumnSpan="2" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="ValEmail" runat="server" ErrorMessage="Enter Valid Email"
                                    ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtEmailAddress" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblaltemail" runat="server" Text="Alternate Email Address "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtaltemail" runat="server" Width="470px" ColumnSpan="2" ValidationGroup="StudentInfo"
                                    CssClass="inputbox"></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="Valaltemail" runat="server" ErrorMessage="Enter Valid Email"
                                    ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtaltemail" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="HeadingBG" colspan="4">
                                <span class="arrow">Job Information</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOccupation" runat="server" Text="Occupation "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="ddcOccupation" runat="server" Width="230px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblTypeOfServ" runat="server" Text="Type Of Service "></asp:Label>
                                <ajaxToolkit:ComboBox ID="ddctypeofserv" runat="server" Width="50px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblDesignation" runat="server" Text="Designation "></asp:Label>
                                <asp:TextBox ID="txtDesignation" runat="server" Width="235px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOfficeAddress" runat="server" Text="Office Address "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtOfficeAddress" runat="server" Width="777px" ColumnSpan="2" Height="44px"
                                    TextMode="MultiLine" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOVillage" runat="server" Text="Village "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtOVillage" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblOCity" runat="server" Text="City "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                 <ajaxToolkit:ComboBox ID="cmbOCity" runat="server" Width="222px" AutoPostBack="false"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle"  />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblODistrict" runat="server" Text="District "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbODistrict" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbODistrict_SelectedIndexChanged" />
                            </td>
                            <td class="textbox_adjust">
                               <asp:Label ID="lblOState" runat="server" Text="State "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbOstate" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbOstate_SelectedIndexChanged" />
                            </td>
                        </tr>

                        <tr>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblOCountry" runat="server" Text="Country "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbOCountry" runat="server" Width="222px" AutoPostBack="true"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" OnSelectedIndexChanged="cmbOCountry_SelectedIndexChanged" />
                            </td>
                            <td class="textbox_adjust">
                                 <asp:Label ID="lblOPin" runat="server" Text="Pin "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtOPin" runat="server" Width="239px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblofficephone" runat="server" Text="Office Phone "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtOfficePhone" runat="server" Width="239px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="HeadingBG" colspan="4">
                                <span class="arrow">Satsang Information</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPooja" runat="server" Text="Pooja"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkPooja" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="lblTilakChandlo" runat="server" Text="Tilak Chandlo "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkTilakChandlo" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSabha" runat="server" Text="Sabha"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkSabha" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="lblExam" runat="server" Text="Exam "></asp:Label>
                            </td>
                            <td>
                                <ajaxToolkit:ComboBox ID="cmbcExam" runat="server" Width="200px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSwaminarayanPrakash" runat="server" Text="Swaminarayan Prakash "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkSwaminarayanPrakash" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="lblGharMandir" runat="server" Text="Ghar Mandir "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkGharMandir" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblGharSabha" runat="server" Text="Ghar Sabha "></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:CheckBox ID="chkGharSabha" Text="Yes" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="lblParentsInSatsang" runat="server" Text="Parents in Satsang "></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkParentsInSatsang" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblActivity" runat="server" Text="Activity "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:TextBox ID="txtActivity" runat="server" TextMode="MultiLine" Width="658px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblExStudentActivity" runat="server" Text="Interested in ex student activity? "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:CheckBox ID="chkExStudentActivity" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblActiveParticipation" runat="server" Text="Interested in participating actively? "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:CheckBox ID="chkActiveParticipation" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLocalActivity" runat="server" Text="Local Activity"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <ajaxToolkit:ComboBox ID="cmbcLocalActivity" runat="server" Width="240px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" Font-Names="Arial" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblResponsibityInSatsang" runat="server" Text="Interested in taking responsibilty in local Satsang? "></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="3">
                                <asp:CheckBox ID="chkResponsibityInSatsang" Text="Yes" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblKnownToSaints" runat="server" Text="Enter two Known local Saints names ?  1]"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtSaint1" runat="server" Width="262px" CssClass="inputbox"></asp:TextBox>
                            </td>
                            <td class="textbox_adjust">
                                <asp:Label ID="lblSaint2" runat="server" Text="2]"></asp:Label>
                            </td>
                            <td class="textbox_adjust">
                                <asp:TextBox ID="txtSaint2" runat="server" Width="262px" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left;">
                                <hr />
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="26px"
                                    Width="79px" Font-Bold="true" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

<%--<div>
<div class="AppTitle">A Working Example of the Five Ways to Make jQuery Ajax Calls</div>
<div class="AuthorTitle"><asp:Label ID="lblAuthorInformation" runat="server"></asp:Label></div>

<div>
<table style="width: 100%" cellpadding="0px" cellspacing="0px">
    <tr>
        <td style="white-space: nowrap" align="left">
            <span>
                <span>
                    <input type="button" id="btnUseLoad" 
                        class="ButtonStyle" value="Call by load (...)" />
                </span>
                <span>
                    <input type="button" id="btnUseGet" 
                        class="ButtonStyle" value="Call by get (...)" />
                </span>
                <span>
                    <input type="button" id="btnUsePost" 
                        class="ButtonStyle" value="Call by post (...)" />
                </span>
                <span>
                    <input type="button" id="btnUseGetJSON" 
                        class="ButtonStyle" value="Call by getJSON (...)" />
                </span>
                <span>
                    <input type="button" id="btnUseGetScript" 
                        class="ButtonStyle" value="Call by getScript (...)" />
                </span>
                <span>
                    <input type="button" id="btnClear" 
                        class="ButtonStyle" value="Clear" />
                </span>
            </span>
        </td>
        <td>&nbsp;&nbsp;&nbsp;</td>
        <td style="white-space: nowrap">
            <span style="float: right">
                <span>
                    <span>Select the number of records to retrieve&nbsp;&nbsp;</span>
                    <span>
                        <select id="selNoOfStudentRecords" class="SmallText">
                            <option value="*">** Please select **</option>
                            <option value="5">5</option>
                            <option value="10">10</option>
                            <option value="20">20</option>
                            <option value="50">50</option>
                        </select>
                    </span>
                </span>
            </span>
        </td>
    </tr>
</table>
</div>

<div class="Information"><label id="lblInformation"></label></div>
<div id="MainContent" class="MainContent"></div>
<div class="Copyright">Copy right: The Code Project Open License (CPOL)</div>
</div>--%>
</body>
</html>
