<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="SMS.aspx.cs"
    Inherits="SIS.Pages.SMS" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

<%@ Register Src="~/HelperClass/MultiCheckCombo.ascx" TagName="MultiCheckCombo" TagPrefix="uc1" %>
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
    <script type="text/javascript">
        function LimtCharacters(txtMsg, CharLength, indicator) {
            chars = txtMsg.value.length;
            document.getElementById(indicator).innerHTML = CharLength - chars;
            if (chars > CharLength) {
                txtMsg.value = txtMsg.value.substring(0, CharLength);
            }
        }
    </script>

    <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="2"
        FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="HeadingBG" HeaderSelectedCssClass="HeadingBG"
        TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header><span class="arrow">Master Database Group</span></Header>
                <Content>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblcity" runat="server" Text="Xetra"></asp:Label>
                            </td>
                            <td class="textbox_adjust" colspan="2">
                                <asp:DropDownList ID="ddlXetra" runat="server" Width="245px">
                                </asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMandal" runat="server" Text="Mandal "></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlMandal" runat="server" Width="245px">
                                </asp:DropDownList>
                                <ajaxToolkit:CascadingDropDown ID="ccdXetra" runat="server" TargetControlID="ddlXetra"
                                    SelectedValue="1" Category="Xetra" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx"
                                    ServiceMethod="GetXetra">
                                </ajaxToolkit:CascadingDropDown>
                                <ajaxToolkit:CascadingDropDown ID="ccdMandal" runat="server" TargetControlID="ddlMandal" UseContextKey="true"
                                    Category="Mandal" LoadingText="Please wait ..." ServicePath="~/WebServices/XetraMandal.asmx" ParentControlID="ddlXetra"
                                    ServiceMethod="GetMandalFromMapId">
                                </ajaxToolkit:CascadingDropDown>
                            </td>

                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="Label1" runat="server" Text="SMS Groups from MasterDB : "></asp:Label>
                            </td>
                            <td>
                                <uc1:MultiCheckCombo ID="MultiCheckCombo1" runat="server" />

                            </td>

                        </tr>
                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header><span class="arrow">Karyakar Group</span></Header>
                <Content>
                    <table style="width: 100%;">
                        <tr>
                            <td>Karyakar Groups</td>
                            <td>
                                <asp:CheckBoxList ID="chkkaryakar" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                                    <asp:ListItem>Karyakar</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header><span class="arrow">Contact List Group</span></Header>
                <Content>
                    <table style="width: 100%;">
                        <tr>
                            <td>Contact List Groups</td>
                            <td>
                                <asp:CheckBoxList ID="chkcontactlist" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                                    <asp:ListItem>chkcontactlist</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header><span class="arrow">Configuration Setting And Send SMS</span></Header>
                <Content>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="SMS "></asp:Label>
                            </td>
                            <td>
                                <div style="font-family: Verdana; font-size: 13px">
                                    Number of Characters Left:
                        <label id="lblcount" style="background-color: #E2EEF1; color: Red; font-weight: bold;">480</label><br />
                                    <asp:TextBox runat="server" ID="mytextbox" Rows="5" onkeyup="LimtCharacters(this,480,'lblcount');" Height="80px" Width="359px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>SMS Key</td>
                            <td>
                                <asp:TextBox ID="txtkey" runat="server" Width="360px" Text="74995A1rvZ1YLfhG54708e99"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>SMS URL</td>
                            <td>
                                <asp:TextBox ID="txturl" runat="server" Width="360px" Text="https://control.msg91.com/sendhttp.php"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>SMS Sender</td>
                            <td>
                                <asp:TextBox ID="txtSender" runat="server" Width="360px" Text="BAPSPN"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Msg String</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtmobile" Rows="5" Height="80px" Width="359px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="textbox_adjust">
                                <asp:Button ID="btngetcnt" runat="server" Text="Get Count" Height="26px" Width="100px"
                                    Font-Bold="true" OnClick="btngetcnt_Click"  class="btn btn-medium btn-primary"/>
                                <asp:Button ID="btnshowrpt" runat="server" Text="Send Message" Height="26px" Width="126px"
                                    Font-Bold="true" OnClick="btnshowrpt_Click"  class="btn btn-medium btn-primary"/>

                            </td>
                        </tr>
                    </table>
                </Content>
            </ajaxToolkit:AccordionPane>

        </Panes>
    </ajaxToolkit:Accordion>

</asp:Content>
