<%@ Page Title="Unloak User" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="UnLockUser.aspx.cs" Inherits="SIS.Account.UnLockUser" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        UnLock User
    </h2>
    <p>
        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
            CssClass="failureNotification" ErrorMessage="E-mail is requnuired." ToolTip="E-mail is required."
            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
           &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkunlock" runat="server" Text="Unlock" />
       
    </p>
    <p   >
      

             <asp:Button ID="btnSave" runat="server" Text="Save" onclick="UnlockUserButton_Click" Height="26px"
                                    Width="79px" Font-Bold="true" />
    </p>
</asp:Content>
