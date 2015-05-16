<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AnkutSevaEntrySNRDID.aspx.cs"
    Inherits="SIS.Pages.AnkutSevaEntrySNRDID" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 113px;
        }

        .auto-style2 {
            padding-top: 7px;
            width: 113px;
        }
    </style>
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


    </script>
  
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>

                    <td colspan="6">
                        <asp:Label ID="lblstatus" runat="server" CssClass="lable" Text=""></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td class="HeadingBG" colspan="5">
                        <span class="arrow">Personal Detail</span>
                    </td>
                    <td class="HeadingBG" align="right">
                        <asp:Label ID="lblPersonid" runat="server" CssClass="lable" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblcity0" runat="server" Text="Xetra"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:DropDownList ID="ddlPersonXetra" runat="server" Width="245px">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="ddlXetra0_CascadingDropDown" runat="server" Category="Xetra" LoadingText="Please wait ..." ServiceMethod="GetXetra" ServicePath="~/WebServices/XetraMandal.asmx" TargetControlID="ddlPersonXetra">
                        </ajaxToolkit:CascadingDropDown>
                    </td>
                    <td>
                        <asp:Label ID="lblarea0" runat="server" Text="Mandal"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:DropDownList ID="ddlPersonMandal" runat="server" Width="245px">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="ddlMandal0_CascadingDropDown" runat="server" Category="Mandal" LoadingText="Please wait ..." ParentControlID="ddlPersonXetra" ServiceMethod="GetMandal" ServicePath="~/WebServices/XetraMandal.asmx" TargetControlID="ddlPersonMandal">
                        </ajaxToolkit:CascadingDropDown>
                    </td>
                    <td>&nbsp;</td>
                    <td class="textbox_adjust">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFName" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtFName" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="ValFName" runat="server" ControlToValidate="txtFName" ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtMiddelName" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValMName" runat="server" ControlToValidate="txtMiddelName" ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Master Data Id "></asp:Label>
                    </td>
                    <td class="textbox_adjust">

                        <asp:TextBox ID="txtmasterdataid" runat="server" ColumnSpan="2" Width="245px" ValidationGroup="StudentInfo"
                            CssClass="inputbox"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblavailabilitystate" runat="server" Text=""></asp:Label>

                        <br />
                    </td>
                  
                </tr>
                <tr>
                    <td class="HeadingBG" colspan="6">
                        <span class="arrow">Contact Information</span>
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
                            SelectedValue="499d837a-5c8f-43fa-bd8a-1c5c807bd626" Category="Country" LoadingText="Please wait ..."
                            ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetCountry">
                        </ajaxToolkit:CascadingDropDown>
                        <ajaxToolkit:CascadingDropDown ID="cddState" runat="server" TargetControlID="cmbstate"
                            SelectedValue="1407cd1e-9f8b-4246-afcc-94e585bda6bd" ParentControlID="cmbcountry"
                            Category="State" LoadingText="Please wait ..." ServicePath="~/WebServices/GeomatryDetail.asmx"
                            ServiceMethod="GetState">
                        </ajaxToolkit:CascadingDropDown>
                        <ajaxToolkit:CascadingDropDown ID="cddDistrict" runat="server" TargetControlID="cmbDistrict"
                            SelectedValue="cbc0f5d5-fc27-4039-a1f5-b09f8e648989" ParentControlID="cmbstate"
                            Category="District" ServicePath="~/WebServices/GeomatryDetail.asmx" ServiceMethod="GetDistrict">
                        </ajaxToolkit:CascadingDropDown>
                        <ajaxToolkit:CascadingDropDown ID="cddCity" runat="server" TargetControlID="cmbcity"
                            SelectedValue="a512c386-fa27-4c94-8cb7-0c43facc1ebb" ParentControlID="cmbDistrict"
                            Category="City" LoadingText="Please wait ..." ServicePath="~/WebServices/GeomatryDetail.asmx"
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
                    <td></td>
                    <td></td>
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
                    <td>
                        <asp:Label ID="lblaltemail2" runat="server" Text="Sent Padharamni Needed"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chksant" runat="server" Text="Yes" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Amount"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtamount" runat="server" Width="245px" ValidationGroup="StudentInfo"
                            CssClass="inputbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblaltemail0" runat="server" Text="Book No "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbook" runat="server" Width="245px" ColumnSpan="2" ValidationGroup="StudentInfo"
                            CssClass="inputbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblaltemail1" runat="server" Text="Reciept No "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtreciept" runat="server" Width="245px" ColumnSpan="2" ValidationGroup="StudentInfo"
                            CssClass="inputbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="HeadingBG" colspan="6">
                        <span class="arrow">Seva Bring Person's Information</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblcity" runat="server" Text="Xetra"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:DropDownList ID="ddlXetra" runat="server" Width="245px">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="ccdXetra" runat="server" Category="Xetra" LoadingText="Please wait ..." ServiceMethod="GetXetra" ServicePath="~/WebServices/XetraMandal.asmx" TargetControlID="ddlXetra">
                        </ajaxToolkit:CascadingDropDown>
                    </td>
                    <td>
                        <asp:Label ID="lblarea" runat="server" Text="Mandal"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:DropDownList ID="ddlMandal" runat="server" Width="245px">
                        </asp:DropDownList>
                        <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" Category="Mandal" LoadingText="Please wait ..." ParentControlID="ddlXetra" ServiceMethod="GetMandal" ServicePath="~/WebServices/XetraMandal.asmx" TargetControlID="ddlMandal">
                        </ajaxToolkit:CascadingDropDown>
                    </td>
                    <td colspan="2"></td>
                </tr>
            </table>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Dharmada Id"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtdid" runat="server" Width="245px" ValidationGroup="StudentInfo"
                            CssClass="inputbox"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:LinkButton ID="lnkgetId0" runat="server" OnClick="lnkgetId0_Click">Get Person </asp:LinkButton>
                        <asp:Label ID="lblavailabilitystateSevabring" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td class="textbox_adjust" colspan="2">
                        &nbsp;</td>


                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFName0" runat="server" Text="AS First Name"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtBringFName1" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                    </td>
                    <td class="textbox_adjust">AS Middle Name</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtBringMiddelName1" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                    </td>
                    <td class="textbox_adjust">AS Last Name</td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtBringLastName" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="textbox_adjust">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Mobile "></asp:Label>
                    </td>
                    <td class="textbox_adjust" colspan="2">
                        <asp:TextBox ID="txtbringMobile" runat="server" CssClass="inputbox" Width="245px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Residence "></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtbringresident" runat="server" CssClass="inputbox" Width="245px"></asp:TextBox>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Email Address "></asp:Label>
                    </td>
                    <td class="textbox_adjust" colspan="2">
                        <asp:TextBox ID="txtbringemail" runat="server" ColumnSpan="2" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label7" runat="server" Text="Alt Email Address "></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtbringaltemail" runat="server" ColumnSpan="2" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtaltemail" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="StudentInfo">Enter Valid Email</asp:RegularExpressionValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" />
                    </td>
                    <td colspan="2"></td>
                    <td colspan="2"></td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkgetId0" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
