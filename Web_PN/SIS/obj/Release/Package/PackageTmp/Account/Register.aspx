<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="SIS.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <div class="accountInfo">
        <fieldset class="register">
            <legend>Account Information</legend>
            <p>
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                    CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="Emailvalid" runat="server" ControlToValidate="Email"
                    CssClass="failureNotification" ErrorMessage="Valid E-mail is required." ToolTip="Valid E-mail is required."
                    ValidationGroup="RegisterUserValidationGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            
            <p>
                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                    ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server"
                    ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                    ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
            </p>
               <p>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="ConfirmPassword">Select Role:</asp:Label>
                <asp:RadioButtonList ID="rdiolistofrole" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="CreateUserButton" runat="server" Text="Create User"
                ValidationGroup="RegisterUserValidationGroup"
                OnClick="CreateUserButton_Click" />
        </p>
    </div>

</asp:Content>
