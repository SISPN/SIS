<%@ Page Title="Log In" Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SIS.Account.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
   
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
   
  <title>SIS Login</title>

    <!-- Bootstrap core CSS -->
   <link href="../Scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
  
<link href="../Scripts/bootstrap/css/Signin.css" rel="stylesheet" />
   

  
</head>

<body>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="../Scripts/bootstrap/js/bootstrap.min.js"></script>
<form id="Form1" runat="server">  
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
        DestinationPageUrl="~/Pages/Home.aspx">
        <LayoutTemplate>    
        <div class="container">
          <div class="row">
              <div class="col-md-6 col-md-offset-4"  style="margin-left: 35%;margin-top: 13%;">

                        <div class="form-group">
                            <asp:TextBox ID="UserName"  class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                             <asp:TextBox ID="Password" runat="server" placeholder="Password" class="form-control"  TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                             <asp:Button ID="LoginButton" runat="server" class="btn btn-large btn-primary" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click" />
                        </div>

             </div>
           </div>
        </div>
        </LayoutTemplate>
    </asp:Login>
</form>
</body>
</html>

