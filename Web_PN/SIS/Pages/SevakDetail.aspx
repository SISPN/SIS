<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="SevakDetail.aspx.cs" Inherits="SIS.Pages.SevakDetail" %>

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


        function ClientItemSelected(sender, e) {
            $get("<%=hfPersonId.ClientID %>").value = e.get_value();
             var res = $get("<%=txtfullname.ClientID %>").value.split(",");
             $get("<%=txtfullname.ClientID %>").value = res[0];
             $get("<%=txtmobile.ClientID %>").value = res[1];

         }

         function ClearHidden(source, eventArgs) {

             document.getElementById('<%=this.hfPersonId.ClientID%>').value = null;
         }
         $("#<%=datepicker.ClientID %>").datepicker($.datepicker.regional["en-GB"]);
        $(function () {
            $("#<%=datepicker.ClientID %>").datepicker({
                 changeMonth: true,
                 changeYear: true
             });

         });


         $("#<%=datepicker1.ClientID %>").datepicker($.datepicker.regional["en-GB"]);
        $(function () {
            $("#<%=datepicker1.ClientID %>").datepicker({
                 changeMonth: true,
                 changeYear: true
             });

         });


    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblstatus" runat="server" CssClass="lable" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="HeadingBG" colspan="2">
                <span class="arrow">Personal Detail</span>
            </td>
            <td class="HeadingBG" align="right">
                <asp:Label ID="lblPersonid" runat="server" CssClass="lable" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Full Name
            </td>
            <td class="textbox_adjust">
                <asp:HiddenField ID="hfPersonId" runat="server" />
                <asp:TextBox ID="txtfullname" runat="server" Width="245px" ValidationGroup="StudentInfo"
                    CssClass="inputbox"></asp:TextBox>


                <ajaxToolkit:AutoCompleteExtender
                    runat="server"
                    BehaviorID="AutoCompleteEx"
                    ID="autoComplete1"
                    TargetControlID="txtfullname"
                    ServicePath="~/WebServices/AutoComplete.asmx"
                    ServiceMethod="GetCompletionList"
                    MinimumPrefixLength="2"
                    CompletionInterval="1000"
                    EnableCaching="true"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    DelimiterCharacters=";, :"
                    ShowOnlyCurrentWordInCompletionListItem="true"
                    OnClientItemSelected="ClientItemSelected"
                    OnClientPopulating="ClearHidden">
                    <Animations>
                    <OnShow>
                        <Sequence>
                            <%-- Make the completion list transparent and then show it --%>
                            <OpacityAction Opacity="0" />
                            <HideAction Visible="true" />
                            
                            <%--Cache the original size of the completion list the first time
                                the animation is played and then set it to zero --%>
                            <ScriptAction Script="
                                // Cache the size and setup the initial size
                                var behavior = $find('AutoCompleteEx');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
                            
                            <%-- Expand from 0px to the appropriate size while fading in --%>
                            <Parallel Duration=".4">
                                <FadeIn />
                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                            </Parallel>
                        </Sequence>
                    </OnShow>
                    <OnHide>
                        <%-- Collapse down to 0px and fade out --%>
                        <Parallel Duration=".4">
                            <FadeOut />
                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                        </Parallel>
                    </OnHide>
                    </Animations>
                </ajaxToolkit:AutoCompleteExtender>

                <asp:RequiredFieldValidator ID="ValMName" runat="server" ControlToValidate="txtfullname"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Mobile
            </td>
            <td class="textbox_adjust">
                <asp:TextBox ID="txtmobile" runat="server" Width="245px" ValidationGroup="StudentInfo"
                    Text="" CssClass="inputbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmobile"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Age</td>
            <td class="textbox_adjust">
                <asp:TextBox ID="txtage" runat="server" Width="245px" ValidationGroup="StudentInfo"
                    Text="" CssClass="inputbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtage"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>From Date</td>
            <td class="textbox_adjust">
                <asp:TextBox runat="server" ID="datepicker" Style="margin-bottom: 0px" ValidationGroup="StudentInfo"
                    Width="160px" />
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="datepicker"
                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                    ErrorTooltipEnabled="True" />
            </td>
        </tr>
        <tr>
            <td>To Date</td>
            <td class="textbox_adjust">
                <asp:TextBox runat="server" ID="datepicker1" Style="margin-bottom: 0px" ValidationGroup="StudentInfo"
                    Width="160px" />
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="datepicker1"
                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                    ErrorTooltipEnabled="True" />
            </td>
        </tr>
        <tr>
            <td class="HeadingBG" colspan="6">
                <span class="arrow">Skill Information</span>
            </td>
        </tr>
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
            <td>
                <asp:Label ID="Label1" runat="server" Text="Architecture "></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkarc" Text="Yes" runat="server" />
            </td>
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
            <td>
                <asp:Label ID="Label3" runat="server" Text="Pasti "></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkpasti" Text="Yes" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Account"></asp:Label>
            </td>
            <td class="textbox_adjust">
                <asp:CheckBox ID="chkaccount" Text="Yes" runat="server" />
            </td>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td>Notes</td>
            <td class="textbox_adjust">
                <asp:TextBox ID="txtnotes" runat="server" Width="238px" ColumnSpan="2" Height="44px"
                    TextMode="MultiLine" ValidationGroup="StudentInfo" CssClass="inputbox"></asp:TextBox></td>
        </tr>



        <tr>
            <td>Mandal
            </td>
            <td class="textbox_adjust">
                <asp:DropDownList ID="ddlMandal" runat="server" Width="245px">
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" TargetControlID="ddlMandal"
                    Category="Mandal" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                    ServiceMethod="GetMandalFromMapId">
                </ajaxToolkit:CascadingDropDown>
            </td>
        </tr>



        <tr>
            <td>Gender</td>
            <td class="textbox_adjust">
                    <asp:DropDownList ID="ddlgender" runat="server" Width="245px" AutoPostBack="False"
                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                    CssClass="WindowsStyle">
                    <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnsaveandenterother" runat="server" Text="Save"  class="btn btn-medium btn-primary" 
                    OnClick="btnsaveandenterother_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
