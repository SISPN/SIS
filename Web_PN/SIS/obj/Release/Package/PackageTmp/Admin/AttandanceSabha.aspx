

    <%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AttandanceSabha.aspx.cs" Inherits="SIS.Admin.AttandanceSabha" 
MasterPageFile="~/Site.Master" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <link href="../Styles/demos.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
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

        function test() {

        }

        function fnOpen(url) {
            window.showModalDialog(url, "", "dialogHeight: 350px; dialogWidth: 800px; dialogTop: 200px; dialogLeft: 400px; center: Yes; resizable: No; status: Yes;");
        }

        function OnContactSelected(source, eventArgs) {
            var results = eval('(' + eventArgs.get_value() + ')');

           


  
           
          
            $get('<%=hdnpersonid.ClientID%>').value = results.PersonId;

            if (results.CAddress != null)
                $get('<%=txtAddress.ClientID%>').value = results.CAddress;
            if (results.CCountry != null)
                $get('<%=cmbcountry.ClientID%>').value = results.CCountry;


            //   $find('<%=ccdMandal.ClientID%>')._onParentChange(null, true);
            

            if (results.CState != null)
                $get('<%=cmbstate.ClientID%>').value = results.CState;

            // $find('<%=ccdMandal.ClientID%>')._onParentChange(null, true);
          

            if (results.CDistrict != null)
                $get('<%=cmbDistrict.ClientID%>').value = results.CDistrict;

            //    $find('<%=ccdMandal.ClientID%>')._onParentChange(null, true);
          

            if (results.CTauko != null)
                $get('<%=cmbcity.ClientID%>').value = results.CTauko;
            if (results.CVillage != null)
                $get('<%=txtVillage.ClientID%>').value = results.CVillage;
            if (results.CPin != null)
                $get('<%=txtPin.ClientID%>').value = results.CPin;
            if (results.PAddress != null)
                $get('<%=txtPermanentAddress.ClientID%>').value = results.PAddress;



            if (results.PCountry != null)
                $get('<%=cmbPCountry.ClientID%>').value = results.PCountry;

            //  $find('<%=ccdPCountry.ClientID%>')._onParentChange(null, true);
          

            if (results.PState != null)
                $get('<%=cmbpstate.ClientID%>').value = results.PState;

            //  $find('<%=ccdPState.ClientID%>')._onParentChange('cmbPCountry', true);
          

            if (results.PDistrict != null)
                $get('<%=cmbPDistrict.ClientID%>').value = results.PDistrict;

            // $find('<%=ccdPDistrict.ClientID%>')._onParentChange('cmbpstate', true);
          

            if (results.PTaluko != null)
                $get('<%=cmbPCity.ClientID%>').value = results.PTaluko;
            if (results.PVillage != null)
                $get('<%=txtPVillage.ClientID%>').value = results.PVillage;
            if (results.PPin != null)
                $get('<%=txtPPin.ClientID%>').value = results.PPin;
            if (results.NativePlace != null)
                $get('<%=txtnative.ClientID%>').value = results.NativePlace;
            if (results.MobilePhone != null)
                $get('<%=txtMobile.ClientID%>').value = results.MobilePhone;
            if (results.HomePhone != null)
                $get('<%=txtResidence.ClientID%>').value = results.HomePhone;
            if (results.Email != null)
                $get('<%=txtEmailAddress.ClientID%>').value = results.Email;
            if (results.AltEmail != null)
                $get('<%=txtaltemail.ClientID%>').value = results.AltEmail;

            $get('<%=ddcOccupation.ClientID%>').value = results.Job;
            $get('<%=ddctypeofserv.ClientID%>').value = results.TypeOfService;

            if (results.Designation != null)
                $get('<%=txtDesignation.ClientID%>').value = results.Designation;
            if (results.CompanyName != null)
                $get('<%=txtofficename.ClientID%>').value = results.CompanyName;
            if (results.JobAddress != null)
                $get('<%=txtOfficeAddress.ClientID%>').value = results.JobAddress;


            if (results.JCountry != null)
                $get('<%=cmbOCountry.ClientID%>').value = results.JCountry;

            //  $find('<%=ccdOCoutry.ClientID%>')._onParentChange(null, true);
          

            if (results.JState != null)
                $get('<%=cmbOstate.ClientID%>').value = results.JState;

            //  $find('<%=ccdOState.ClientID%>')._onParentChange('cmbOCountry', true);
          

            if (results.JDistrict != null)
                $get('<%=cmbODistrict.ClientID%>').value = results.JDistrict;

            //  $find('<%=ccdODistrict.ClientID%>')._onParentChange('cmbOstate', true);
          

            if (results.JTaluko != null)
                $get('<%=cmbOCity.ClientID%>').value = results.JTaluko;
            if (results.JVillage != null)
                $get('<%=txtOVillage.ClientID%>').value = results.JVillage;
            if (results.JPin != null)
                $get('<%=txtOPin.ClientID%>').value = results.JPin;
            if (results.JobPhone != null)
                $get('<%=txtOfficePhone.ClientID%>').value = results.JobPhone;
            if (results.JFax != null)
                $get('<%=txtofficefax.ClientID%>').value = results.JFax;

           

            $find('<%=ccdMandal.ClientID%>')._onParentChange(null, true);

            $get('<%=ddlXetra.ClientID%>').value = results.Xetra;
            $get('<%=ddlMandal.ClientID%>').value = results.Mandal;

            //$get('<%=ddlMandal.ClientID%>').value = results.Xetra;

            
        }

        function wait(msecs) {
            var start = new Date().getTime();
            var cur = start
            while (cur - start < msecs) {
                cur = new Date().getTime();
            }
        }

    </script>
   
    <div style="border: 5px hidden; border-color: #3BB9FF;">
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
         <tr>
                <td colspan="6">
                    <asp:Label ID="lblstatus" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lblsabhadate" runat="server" Text="Date Of Sabha"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox runat="server" ID="datepicker" Width="245px" Style="margin-bottom: 0px"
                        ValidationGroup="StudentInfo" CssClass="inputbox" />
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="datepicker"
                        Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                        ErrorTooltipEnabled="True" />
                        <asp:RequiredFieldValidator ID="rfdate" runat="server" 
                        ErrorMessage="You must select enter valid date." ControlToValidate="datepicker" 
                        ValidationGroup="StudentInfo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
           <%-- <tr>
                <td style="width: 15%;">
                    <asp:Label ID="lblPersonid" runat="server" Text="Person Id "></asp:Label>
                </td>
                <td style="width: 25%;" class="textbox_adjust">
                    <asp:TextBox ID="txtstudentid" runat="server" Width="245px" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox>
                </td>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td style="width: 15%;">
                    <asp:Label ID="lblPersonName" runat="server" Text="Person Name "></asp:Label>
                </td>
                <td style="width: 25%;" class="textbox_adjust">
                    <asp:TextBox ID="txtpersonname" runat="server" Width="245px" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox>
                        
                    <asp:RequiredFieldValidator ID="rfperson" runat="server" 
                        ErrorMessage="You must select Person Name." ControlToValidate="txtpersonname" 
                        ValidationGroup="StudentInfo" ForeColor="Red"></asp:RequiredFieldValidator>
                    <ajaxToolkit:AutoCompleteExtender ID="contactExtender" runat="server" TargetControlID="txtpersonname"
                        ServicePath="../WebServices/AutoComplete.asmx" ServiceMethod="GetCompletionList"
                        MinimumPrefixLength="1" ContextKey="1234" UseContextKey="True" OnClientItemSelected="OnContactSelected">
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 15%;">
                    <asp:Label ID="lblsabha" runat="server" Text="Sabha "></asp:Label>
                </td>
                <td style="width: 25%;" class="textbox_adjust">
                    <asp:DropDownList ID="ddlsabha" runat="server" Width="245px">
                    </asp:DropDownList>
                </td>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="6" align="left" style="padding-bottom: 20px;">
                   <%-- <asp:Button ID="btnsearch" runat="server" Text="Search" Font-Size="Medium" OnClick="btnsearch_Click" />
                    &nbsp;&nbsp;--%>
                    <asp:Button ID="btnpresentandupdate" runat="server" Text="Present & Update" Font-Size="Medium" ValidationGroup="StudentInfo"
                        OnClick="btnpresentandupdate_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnpresent" runat="server" Text="Present" Font-Size="Medium"  OnClick="btnpresent_Click" ValidationGroup="StudentInfo"/>
                    <asp:HiddenField ID="hdnpersonid" runat="server" Value="" />
                </td>
            </tr>
            <tr>
                <td class="HeadingBG" colspan="5">
                    <span class="arrow">Personal Detail</span>
                </td>
                <td class="HeadingBG" align="right">
                    <asp:Label ID="Label1" runat="server" CssClass="lable" Text=""></asp:Label>
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
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblarea" runat="server" Text="Mandal"></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:DropDownList ID="ddlMandal" runat="server" Width="245px">
                    </asp:DropDownList>
                    <ajaxToolkit:CascadingDropDown ID="ccdXetra" runat="server" TargetControlID="ddlXetra"
                        Category="Xetra" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx" 
                        ServiceMethod="GetXetra">
                    </ajaxToolkit:CascadingDropDown>
                    <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" TargetControlID="ddlMandal"  
                        ParentControlID="ddlXetra" Category="Mandal" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                        ServiceMethod="GetMandal">
                    </ajaxToolkit:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Current Address"></asp:Label>
                </td>
                <td class="textbox_adjust" colspan="3">
                    <asp:TextBox ID="txtAddress" runat="server" Width="680px" ColumnSpan="2" Height="44px"
                        TextMode="MultiLine" ValidationGroup="StudentInfo" CssClass="inputbox"></asp:TextBox><br />
                </td>
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address "></asp:Label>
                </td>
                <td class="textbox_adjust" colspan="3">
                    <asp:TextBox ID="txtPermanentAddress" runat="server" Width="680px" ColumnSpan="2"
                        Height="44px" TextMode="MultiLine" ValidationGroup="StudentInfo" CssClass="inputbox"></asp:TextBox><br />
                </td>
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblnative" runat="server" Text="Native Place "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtnative" runat="server" CssClass="inputbox" Width="245px"></asp:TextBox>
                </td>
                <td colspan="4">
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
                    <asp:TextBox ID="txtResidence" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                </td>
                <td colspan="2">
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
                    <asp:Label ID="lblaltemail" runat="server" Text="Alt Email Address "></asp:Label>
                </td>
                <td class="textbox_adjust">
                    <asp:TextBox ID="txtaltemail" runat="server" Width="245px" ColumnSpan="2" ValidationGroup="StudentInfo"
                        CssClass="inputbox"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="Valaltemail" runat="server" ErrorMessage="Enter Valid Email"
                        ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtaltemail" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td class="HeadingBG" colspan="6">
                    <span class="arrow">Job Information</span>
                </td>
            </tr>
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
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
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
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="btnsaveandupdatebottom" runat="server" Text="Present & Update" Font-Size="Medium" ValidationGroup="StudentInfo"
                        OnClick="btnsaveandupdatebottom_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
