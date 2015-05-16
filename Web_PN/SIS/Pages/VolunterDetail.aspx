<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="VolunterDetail.aspx.cs" Inherits="SIS.Pages.VolunterDetai" %>

<%@ Register Src="~/HelperClass/MultiCheckCombo.ascx" TagName="MultiCheckCombo" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">


        function ClientItemSelected(sender, e) {
            $get("<%=hfPersonId.ClientID %>").value = e.get_value();
            var res = $get("<%=myTextBox.ClientID %>").value.split(",");
            $get("<%=myTextBox.ClientID %>").value = res[0];

        }

        function ClearHidden(source, eventArgs) {

            document.getElementById('<%=this.hfPersonId.ClientID%>').value = null;
        }
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
                <asp:TextBox runat="server" ID="myTextBox" Width="300" autocomplete="off" ValidationGroup="StudentInfo" />
                <ajaxToolkit:AutoCompleteExtender
                    runat="server"
                    BehaviorID="AutoCompleteEx"
                    ID="AutoCompleteExtender1"
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

                <asp:RequiredFieldValidator ID="ValMName" runat="server" ControlToValidate="myTextBox"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Designation
            </td>
            <td class="textbox_adjust">
                <asp:DropDownList ID="cmbcLocalActivity" runat="server" Width="245px" AutoPostBack="False"
                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                    CssClass="WindowsStyle" Font-Names="Arial" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblcity" runat="server" Text="Xetra"></asp:Label>
            </td>
            <td class="textbox_adjust">
                <asp:DropDownList ID="ddlXetra" runat="server" Width="245px" AutoPostBack="true" OnSelectedIndexChanged="ddlXetra_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblarea" runat="server" Text="Mandal"></asp:Label>
            </td>
            <td class="textbox_adjust">
               
                    <uc1:MultiCheckCombo ID="lstmandal1" runat="server" />
                <ajaxToolkit:CascadingDropDown ID="ccdXetra" runat="server" TargetControlID="ddlXetra"
                    SelectedValue="0" Category="Xetra" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                    ServiceMethod="GetXetra">
                </ajaxToolkit:CascadingDropDown>
             

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="UserNameLabel" runat="server">User Name</asp:Label>
            </td>
            <td class="textbox_adjust">
                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>


            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="PasswordLabel" runat="server">Password</asp:Label>
            </td>
            <td class="textbox_adjust">
                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>


            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ConfirmPasswordLabel" runat="server">Confirm Password</asp:Label>
            </td>
            <td class="textbox_adjust">
                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>

                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    ErrorMessage="The Password and Confirmation Password must match."
                    ValidationGroup="StudentInfo">*</asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label1" runat="server">Select Role</asp:Label>
            </td>
            <td class="textbox_adjust">
                <asp:RadioButtonList ID="rdiolistofrole" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr>
            <td class="textbox_adjust" colspan="2">
                <asp:Button ID="btnsaveandenterother" runat="server" Text="Save"
                    OnClick="btnsaveandenterother_Click" ValidationGroup="StudentInfo"  class="btn btn-medium btn-primary"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="textbox_adjust">
                <asp:Label ID="lblnodata" runat="server">No Data Found</asp:Label>
                <asp:GridView ID="dlresultlist" runat="server" DataKeyNames="VoluntierId"
                    AutoGenerateColumns="False" AutoGenerateDeleteButton="True"
                    AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnRowDeleting="dlresultlist_RowDeleting"
                    OnRowEditing="dlresultlist_RowEditing" OnRowUpdating="dlresultlist_RowUpdating"
                    OnRowCancelingEdit="dlresultlist_RowCancelingEdit" OnRowDataBound="dlresultlist_RowDataBound">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                    <Columns>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                            ControlStyle-Width="300px">
                            <EditItemTemplate>

                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'
                                    Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValMName" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <%# Eval("Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PersonId" HeaderStyle-HorizontalAlign="Left"
                            ControlStyle-Width="100px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonId" runat="server" Text='<%# Bind("PersonId") %>'
                                    Width="100px"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <%# Eval("PersonId")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Desig." HeaderStyle-HorizontalAlign="Left"
                            ControlStyle-Width="100px">
                            <EditItemTemplate>

                                <asp:DropDownList ID="txtDesig" runat="server" Width="245px" AutoPostBack="False"
                                    DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                    CssClass="WindowsStyle" Font-Names="Arial" />
                            </EditItemTemplate>

                            <ItemTemplate>
                                <%# Eval("Designation")%>
                            </ItemTemplate>
                        </asp:TemplateField>

       


                        <asp:TemplateField HeaderText="Mandal" HeaderStyle-HorizontalAlign="Left"
                            ControlStyle-Width="150px">
                            <EditItemTemplate>

                                 <asp:TextBox ID="txtMandal" runat="server" Text='<%# Bind("MandalOwn") %>'
                                    Width="100px"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <%# Eval("MandalOwn")%>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField DataField="VoluntierId" ShowHeader="false" Visible="false" />



                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />


                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

            </td>
        </tr>
    </table>
</asp:Content>
