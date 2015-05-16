<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AdminPanel.aspx.cs" Inherits="SIS.Account.AdminPanel" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div style ="height:450px;">
<h2>Admin Panel:</h2>
<table>
<tr>
<td>
    <asp:TextBox ID="txtrolename" runat="server"></asp:TextBox>
    <asp:Button ID="btnCreateRole" runat="server" Text="CreateRole" OnClick="btnCreateRole_Click"/>
</td>
</tr>
<tr>
<td>
<table>
<tr>
<td>Available Users</td>
<td>Available Roles</td>
</tr>
<tr>
<td style="height: 72px">
    <asp:ListBox ID="lstusers" runat="server" Height="95px" Width="105px"></asp:ListBox>
</td>
<td style="height: 72px">
    <asp:ListBox ID="lstRoles" runat="server" Height="92px" Width="95px"></asp:ListBox>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnAssignRoleToUser" runat="server" Text="Assign Role To User" Width="211px" OnClick="btnAssignRoleToUser_Click" />
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnRemoveUserFromUser" runat="server" Text="Remove User From Role" OnClick="btnRemoveUserFromUser_Click" />
    
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnRemoveRoles" runat="server" Text="Delete Roles" Width="210px" OnClick="btnRemoveRoles_Click" />
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btndeleteuser" runat="server" Text="Delete User" Width="210px" OnClick="btndeleteuser_Click"/>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</td>
</tr>
</table>
</div>

</asp:Content>
