<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SIS.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
        DestinationPageUrl="~/Pages/Home.aspx">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
    
            

      <form class="form-signin">
        <h2 class="form-signin-heading">Please sign in</h2>
        <input class="input-block-level" placeholder="Email address" type="text">
        <input class="input-block-level" placeholder="Password" type="password">
        <label class="checkbox">
          <input value="remember-me" type="checkbox"> Remember me
        </label>
        <button class="btn btn-large btn-primary" type="submit">Sign in</button>
      </form>

    
                    <div class="accountInfo">
                <fieldset class="login">
                    <legend>Account Information</legend>
                    <p>    
                        <asp:TextBox ID="UserName" runat="server" placeholder="User Name" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>                       
                        <asp:TextBox ID="Password" runat="server" placeholder="Password" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" class="btn btn-large btn-primary" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
