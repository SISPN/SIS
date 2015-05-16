<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="SevaEntry.aspx.cs"
    Inherits="SIS.Pages.SevaEntry" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

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
            var res = $get("<%=myTextBox.ClientID %>").value.split(",");
            $get("<%=myTextBox.ClientID %>").value = res[0];

        }

        function ClearHidden(source, eventArgs) {

            document.getElementById('<%=this.hfPersonId.ClientID%>').value = null;
        }

        function BringClearHidden(source, eventArgs) {

            document.getElementById('<%=this.hfbringperson.ClientID%>').value = null;
        }

        function BringClientItemSelected(sender, e) {
            $get("<%=hfbringperson.ClientID %>").value = e.get_value();
            var res = $get("<%=txtbringname.ClientID %>").value.split(",");
            $get("<%=txtbringname.ClientID %>").value = res[0];

        }

        function EnableTxt() {

        }
        function check() {
            if ($get("<%=txtamount.ClientID %>").value > 0) {
                $get("<%=txtbook.ClientID %>").disabled = false;
                $get("<%=txtreciept.ClientID %>").disabled = false;
                $get("<%=txtmale.ClientID %>").disabled = false;
                $get("<%=txtfemale.ClientID %>").disabled = false;



            }
            else {

                $get("<%=txtbook.ClientID %>").disabled = true;
                $get("<%=txtreciept.ClientID %>").disabled = true;
                $get("<%=txtmale.ClientID %>").disabled = true;
                $get("<%=txtfemale.ClientID %>").disabled = true;

                $get("<%=txtbook.ClientID %>").value = "";
                $get("<%=txtreciept.ClientID %>").value = "";
                $get("<%=txtmale.ClientID %>").value = "0";
                $get("<%=txtfemale.ClientID %>").value = "0";
            }
            // Things to do when the textbox changes
        }

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" onload="check();">

                <tr>

                    <td colspan="6">
                        <asp:Label ID="lblstatus" runat="server" CssClass="lable" Text=""></asp:Label>

                    </td>
                </tr>


                <tr>
                    <td class="HeadingBG" colspan="5">
                        <span class="arrow">Personal Detail</span>
                    </td>
                    <td class="HeadingBG" align="right"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Person Name"></asp:Label>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfPersonId" runat="server" />
                        <asp:TextBox runat="server" ID="myTextBox" Width="300" autocomplete="off" />
                        <ajaxToolkit:AutoCompleteExtender
                            runat="server"
                            BehaviorID="AutoCompleteEx"
                            ID="autoComplete1"
                            TargetControlID="myTextBox"
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

                    </td>
                    <td colspan="4">
                        <asp:LinkButton ID="lnkgetId" runat="server" OnClick="lnkgetId_Click">Get Person Id</asp:LinkButton>
                        <asp:TextBox ID="txtmasterid" runat="server" autocomplete="off" Width="300" Style="display: none" />
                    </td>
                </tr>
                <tr>
                    <td>Xetra</td>
                    <td class="textbox_adjust">
                        <asp:DropDownList ID="ddlXetra" runat="server" Width="245px">
                        </asp:DropDownList>
                    </td>
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
                        <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" TargetControlID="ddlMandal"
                            ParentControlID="ddlXetra" Category="Mandal" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                            ServiceMethod="GetMandal">
                        </ajaxToolkit:CascadingDropDown>
                    </td>
                    <td colspan="2"></td>
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
                        <asp:Label ID="lblVillage" runat="server" Text="Village/Area"></asp:Label>
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
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhoneMobile" runat="server" Text="Mobile "></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtMobile" runat="server" Width="245px" CssClass="inputbox"></asp:TextBox>
                    </td>
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
                    <td>Category</td>
                    <td>
                        <asp:DropDownList ID="ddlsatsangcategory" runat="server" Width="245px" AutoPostBack="False"
                            DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                            CssClass="WindowsStyle" Font-Names="Arial" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Amount"></asp:Label>
                    </td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtamount" runat="server" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px" onchange="check();"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                            ControlToValidate="txtamount" ErrorMessage="Value must be a whole number" />
                    </td>
                    <td>
                        <asp:Label ID="lblaltemail0" runat="server" Text="Book No "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbook" runat="server" ColumnSpan="2" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <%--    <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                            ControlToValidate="txtbook" ErrorMessage="Value must be a whole number" />--%>

                    </td>
                    <td>
                        <asp:Label ID="lblaltemail1" runat="server" Text="Reciept No "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtreciept" runat="server" ColumnSpan="2" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <%--<asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                            ControlToValidate="txtreciept" ErrorMessage="Value must be a whole number" />--%>
                    </td>
                </tr>
                <tr>
                    <td>Probable Seva?</td>
                    <td class="textbox_adjust">
                        <asp:TextBox ID="txtprobableseva" runat="server" CssClass="inputbox" Width="245px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator6" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                            ControlToValidate="txtprobableseva" ErrorMessage="Value must be a whole number" />
                    </td>
                    <td>Male Yajman</td>
                    <td>
                        <asp:TextBox ID="txtmale" runat="server" ColumnSpan="2" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator5" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                            ControlToValidate="txtmale" ErrorMessage="Value must be a whole number" />
                    </td>
                    <td>Female Yajman</td>
                    <td>
                        <asp:TextBox ID="txtfemale" runat="server" ColumnSpan="2" CssClass="inputbox" ValidationGroup="StudentInfo" Width="245px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red"
                            ControlToValidate="txtfemale" ErrorMessage="Value must be a whole number" />
                    </td>
                </tr>
                <tr>
                    <td class="HeadingBG" colspan="6">
                        <span class="arrow">Seva Bring Person's Information</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Seva Bring Person Name"></asp:Label>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfbringperson" runat="server" />
                        <asp:TextBox runat="server" ID="txtbringname" Width="300" autocomplete="off" />
                        <ajaxToolkit:AutoCompleteExtender
                            runat="server"
                            BehaviorID="AutoCompleteEx1"
                            ID="AutoCompleteExtender1"
                            TargetControlID="txtbringname"
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
                            OnClientItemSelected="BringClientItemSelected"
                            OnClientPopulating="BringClearHidden">
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
                                var behavior = $find('AutoCompleteEx1');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
                            
                            <%-- Expand from 0px to the appropriate size while fading in --%>
                            <Parallel Duration=".4">
                                <FadeIn />
                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx1')._height" />
                            </Parallel>
                        </Sequence>
                    </OnShow>
                    <OnHide>
                        <%-- Collapse down to 0px and fade out --%>
                        <Parallel Duration=".4">
                            <FadeOut />
                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx1')._height" EndValue="0" />
                        </Parallel>
                    </OnHide>
                            </Animations>
                        </ajaxToolkit:AutoCompleteExtender>

                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="chkself" runat="server" Text="Self" />
                    </td>
                    <td colspan="2"></td>
                </tr>


                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save"  class="btn btn-medium btn-primary"/>

                    </td>
                    <td colspan="2"></td>
                    <td></td>
                </tr>
            </table>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkgetId" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>
    <asp:Button ID="btnexportdata" runat="server" Text="Export to Excel" OnClick="btnexportdata_Click"  class="btn btn-medium btn-primary"/>
</asp:Content>
