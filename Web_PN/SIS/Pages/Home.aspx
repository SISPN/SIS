<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="SIS.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
        .style2
        {
            font-family: Verdana;
            padding:0px;
           
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr>
            <td class="style2" >
                This is central information system of satsangi.
                <br />
                 <br />
                <span class="style1"><strong>The Objectives of this system are</strong></span>
                   <ul><li>
                    
                        We can stay in touch with Satsang and our Activities.
                    </li>
                    <li>
                        We want to make our Satsang Activity "World Best". This is going to be our collective
                        effort. We can share ideas about that. We can help each other for job/educational etc.
                        purpose.
                    </li>
                    <li>
                        A central location where we can keep our updated contact details which can be 
                        easily available to any of us.</li>
                </ul>
            </td>
            <td align="right">
                <img src="../Images/homepage.jpg" />
            </td>
        </tr>
    </table>
</asp:Content>
